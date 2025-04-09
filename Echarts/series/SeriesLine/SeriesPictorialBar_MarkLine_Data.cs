using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

/// <summary>
///     标线的数据数组。每个数组项可以是一个两个值的数组，分别表示线的起点和终点，每一项是一个对象，有下面几种方式指定起点或终点的位置。
///     通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
///     用 coord 属性指定数据在相应坐标系上的坐标位置，单个维度支持设置 'min', 'max', 'average'。
///     直接用 type 属性标注系列中的最大值，最小值。这时候可以使用 valueIndex 或者 valueDim 指定是在哪个维度上的最大值、最小值、平均值。
///     如果是笛卡尔坐标系的话，也可以通过只指定 xAxis 或者 yAxis 来实现 X 轴或者 Y 轴为某值的标线，见示例 scatter-weight
///     当多个属性同时存在时，优先级按上述的顺序。
///     也可以是直接通过 type 设置该标线的类型，是最大值的线还是平均线。同样的，这时候可以通过使用 valueIndex 指定维度。
///     data: [
///     {
///     name: '平均线',
///     // 支持 'average', 'min', 'max'
///     type: 'average'
///     },
///     {
///     name: 'Y 轴值为 100 的水平线',
///     yAxis: 100
///     },
///     [
///     {
///     // 起点和终点的项会共用一个 name
///     name: '最小值到最大值',
///     type: 'min'
///     },
///     {
///     type: 'max'
///     }
///     ],
///     [
///     {
///     name: '两个坐标之间的标线',
///     coord: [10, 20]
///     },
///     {
///     coord: [20, 30]
///     }
///     ], [{
///     // 固定起点的 x 像素位置，用于模拟一条指向最大值的水平线
///     yAxis: 'max',
///     x: '90%'
///     }, {
///     type: 'max'
///     }],
///     [
///     {
///     name: '两个屏幕坐标之间的标线',
///     x: 100,
///     y: 100
///     },
///     {
///     x: 500,
///     y: 200
///     }
///     ]
///     ]
/// </summary>
public class MarkDataConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		// 确保只处理对象类型
		return objectType == typeof(MarkDataItem);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var token = JToken.Load(reader);

		if (token.Type == JTokenType.Object)
		{
			// 单点配置：反序列化为 MarkLineDataPoint 并包装成一个列表
			var dataPoint = token.ToObject<MarkDataItem>();
			return new List<object> { dataPoint };
		}

		if (token.Type == JTokenType.Array)
		{
			// 双点配置：反序列化为 MarkLineDataPoint 数组
			var dataPoints = token.ToObject<MarkDataItem[]>();
			return dataPoints.ToList();
		}

		throw new JsonSerializationException("无法识别的标线数据类型");
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		serializer.Serialize(writer, value);
	}
}