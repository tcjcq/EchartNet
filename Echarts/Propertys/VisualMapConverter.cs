using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class VisualMapConverter : JsonConverter<List<object>>
{
	public override List<object> ReadJson(JsonReader reader, Type objectType, List<object> existingValue,
		bool hasExistingValue, JsonSerializer serializer)
	{
		var result = new List<object>();
		var token = JToken.Load(reader);

		if (token.Type == JTokenType.Array)
			foreach (var item in token)
				result.Add(ParseVisualMapItem(item));
		else if (token.Type == JTokenType.Object) result.Add(ParseVisualMapItem(token));

		return result;
	}

	private object ParseVisualMapItem(JToken itemToken)
	{
		var obj = (JObject)itemToken;
		var type = obj["type"]?.Value<string>();

		return type switch
		{
			"continuous" => obj.ToObject<VisualMapContinuous>(),
			"piecewise"  => obj.ToObject<VisualMapPiecewise>(),
			_            => obj.ToObject<Dictionary<string, object>>() // 处理未知类型
		};
	}

	public override void WriteJson(JsonWriter writer, List<object> value, JsonSerializer serializer)
	{
		writer.WriteStartArray();
		foreach (var item in value)
			if (item is VisualMapContinuous || item is VisualMapPiecewise)
				serializer.Serialize(writer, item);
			else
				// 处理其他类型（如动态对象）
				JObject.FromObject(item).WriteTo(writer);
		writer.WriteEndArray();
	}
}

public class Piece
{
	// 范围条件属性
	[JsonProperty("gt", NullValueHandling = NullValueHandling.Ignore)]
	public double? Gt { get; set; }

	[JsonProperty("lt", NullValueHandling = NullValueHandling.Ignore)]
	public double? Lt { get; set; }

	[JsonProperty("gte", NullValueHandling = NullValueHandling.Ignore)]
	public double? Gte { get; set; }

	[JsonProperty("lte", NullValueHandling = NullValueHandling.Ignore)]
	public double? Lte { get; set; }

	// 核心数值属性
	[JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
	public double? Value { get; set; }

	// 视觉呈现属性
	[JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
	public string Color { get; set; }

	[JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
	public string Label { get; set; }

	[JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
	public string Symbol { get; set; } // 图形标识（如："circle", "rect"）

	[JsonProperty("opacity", NullValueHandling = NullValueHandling.Ignore)]
	public double? Opacity { get; set; } // 透明度（0-1）

	// 扩展视觉属性
	[JsonProperty("strokeColor", NullValueHandling = NullValueHandling.Ignore)]
	public string StrokeColor { get; set; } // 边框颜色

	[JsonProperty("strokeWidth", NullValueHandling = NullValueHandling.Ignore)]
	public double? StrokeWidth { get; set; } // 边框宽度

	[JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
	public double? Size { get; set; } // 图形尺寸

	// 交互属性
	[JsonProperty("clickable", NullValueHandling = NullValueHandling.Ignore)]
	public bool? Clickable { get; set; } // 可点击性

	// 数据关联属性
	[JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
	public string Category { get; set; } // 分类标识
}