using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class SingleOrArrayConverter<T> : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(List<T>);
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var list = value as List<T>;
		if (list?.Count == 1)
			// 只有一个元素时，直接写入这个元素
			serializer.Serialize(writer, list[0]);
		else
			// 多个元素时，写入数组
			serializer.Serialize(writer, list);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		// 检查是否为 null 令牌
		if (reader.TokenType == JsonToken.Null) return null;

		if (reader.TokenType == JsonToken.StartArray)
			// JSON 数据为数组时，直接反序列化为 List<T>
			return serializer.Deserialize<List<T>>(reader);

		// JSON 数据为单个值时，创建一个包含这个值的 List<T>
		var instance = serializer.Deserialize<T>(reader);
		return new List<T> { instance };
	}
}

public class DynamicSeriesConverter : JsonConverter
{
	// 类型映射配置（全局连续编号，总计32种）
	private static readonly Dictionary<string, Type> TypeMap =
		new(StringComparer.OrdinalIgnoreCase)
		{
			// ========== 基础图表 ==========
			{ "bar", typeof(SeriesBar) }, //1. [基础] 柱状图（series-bar.js）
			{ "line", typeof(SeriesLine) }, //2. [基础] 折线图（series-line.js）
			{ "pie", typeof(SeriesPie) }, //3. [基础] 饼图（series-pie.js）
			{ "scatter", typeof(SeriesScatter) }, //4. [基础] 散点图（series-scatter.js）
			{ "effectScatter", typeof(SeriesEffectScatter) }, //5. [基础] 涟漪散点图（series-effectScatter.js）
			{ "graph", typeof(SeriesGraph) }, //6. [基础] 关系图（series-graph.js）

			// ========== 统计类图表 ==========
			{ "boxplot", typeof(SeriesBoxplot) }, //7. [统计] 箱线图（series-boxplot.js）
			{ "heatmap", typeof(SeriesHeatmap) }, //8. [统计] 热力图（series-heatmap.js）
			{ "parallel", typeof(SeriesParallel) }, //9. [统计] 平行坐标系（series-parallel.js）

			// ========== 地理类图表 ==========
			{ "map", typeof(SeriesMap) }, //10. [地理] 二维地图（series-map.js）
			{ "map3D", typeof(SeriesMap3D) }, //11. [地理] 三维地图（series-map3D.js）
			{ "lines", typeof(SeriesLines) }, //12. [地理] 二维航线图（series-lines.js）
			{ "lines3D", typeof(SeriesLines3D) }, //13. [地理] 三维航线图（series-lines3D.js）

			// ========== 树形与层级类 ==========
			{ "tree", typeof(SeriesTree) }, //14. [层级] 树图（series-tree.js）
			{ "treemap", typeof(SeriesTreemap) }, //15. [层级] 矩形树图（series-treemap.js）
			{ "sunburst", typeof(SeriesSunburst) }, //16. [层级] 旭日图（series-sunburst.js）
			{ "sankey", typeof(SeriesSankey) }, //17. [层级] 桑基图（series-sankey.js）

			// ========== 多维数据类 ==========
			{ "radar", typeof(SeriesRadar) }, //18. [多维] 雷达图（series-radar.js）
			{ "funnel", typeof(SeriesFunnel) }, //19. [多维] 漏斗图（series-funnel.js）
			{ "gauge", typeof(SeriesGauge) }, //20. [多维] 仪表盘（series-gauge.js）

			// ========== 金融类图表 ==========
			{ "candlestick", typeof(SeriesCandlestick) }, //21. [金融] K线图（series-candlestick.js")

			// ========== 3D类图表 ==========
			{ "bar3D", typeof(SeriesBar3D) }, //22. [3D] 三维柱状图（series-bar3D.js）
			{ "scatter3D", typeof(SeriesScatter3D) }, //23. [3D] 三维散点图（series-scatter3D.js）
			{ "line3D", typeof(SeriesLine3D) }, //24. [3D] 三维折线图（series-line3D.js）
			{ "surface", typeof(SeriesSurface) }, //25. [3D] 三维曲面图（series-surface.js）
			{ "polygons3D", typeof(SeriesPolygons3D) }, //26. [3D] 三维多边形图（series-polygons3D.js")

			// ========== 特殊效果类 ==========
			{ "pictorialBar", typeof(SeriesPictorialBar) }, //27. [特效] 象形柱图（series-pictorialBar.js）
			{ "flowGL", typeof(SeriesFlowGL) }, //28. [特效] GL流式效果（series-flowGL.js）

			// ========== 扩展类 ==========
			{ "custom", typeof(SeriesCustom) }, //29. [扩展] 自定义系列（series-custom.js）
			{ "scatterGL", typeof(SeriesScatterGL) }, //30. [扩展] WebGL加速散点图（series-scatterGL.js）
			{ "graphGL", typeof(SeriesGraphGL) }, //31. [扩展] GL关系图（series-graphGL.js")
			{ "themeRiver", typeof(SeriesThemeRiver) } //32. [扩展] 主题河流图（series-themeRiver.js")
		};

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(object);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		var obj = JObject.Load(reader);
		var typeToken = obj["type"];

		if (typeToken == null)
			throw new JsonSerializationException("Missing required 'type' property");

		var typeName = typeToken.Value<string>();
		if (!TypeMap.TryGetValue(typeName, out var targetType))
			throw new JsonSerializationException($"Unknown series type: {typeName}");

		return obj.ToObject(targetType, serializer);
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		// 直接序列化具体类型
		serializer.Serialize(writer, value);
	}
}

public class SeriesListConverter : JsonConverter
{
	private readonly DynamicSeriesConverter _itemConverter = new();

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(List<object>);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		var array = JArray.Load(reader);
		var list = new List<object>();

		foreach (var item in array)
		{
			var series = _itemConverter.ReadJson(item.CreateReader(), typeof(object), null, serializer);
			list.Add(series);
		}

		return list;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var list = (List<object>)value;
		writer.WriteStartArray();

		foreach (var item in list) _itemConverter.WriteJson(writer, item, serializer);

		writer.WriteEndArray();
	}
}