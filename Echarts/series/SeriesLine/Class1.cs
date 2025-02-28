using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

/// <summary>
///     系列数据容器（支持多态数据项）
/// </summary>
public class SeriesLine_Data
{
	[JsonProperty("data")]
	[JsonConverter(typeof(DataItemConverter))]
	public List<DataItem> Data { get; set; } = new();
}

/// <summary>
///     数据项（支持数值/数组/对象形式）
///     完整覆盖ECharts官方文档定义的7种数据形态：
///     1. number  2. string  3. Date  4. [number, number]
///     5. [string, number]  6. [Date, number]  7. 对象结构
/// </summary>
[JsonConverter(typeof(DataItemConverter))]
public class DataItem
{
	/// <summary>
	///     核心数据值（支持6种类型）
	///     - 单值：number/string/DateTime
	///     - 数组：object[]
	///     - 空值：null/NaN/"-"
	/// </summary>
	public object Value { get; set; }

	/// <summary>
	///     数据项名称
	/// </summary>
	[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; }

	/// <summary>
	///     数据分组ID（动画过渡用）
	/// </summary>
	[JsonProperty("groupId", NullValueHandling = NullValueHandling.Ignore)]
	public string GroupId { get; set; }

	/// <summary>
	///     子数据组ID（v5.5.0+）
	/// </summary>
	[JsonProperty("childGroupId", NullValueHandling = NullValueHandling.Ignore)]
	public string ChildGroupId { get; set; }

	/// <summary>
	///     标签样式
	/// </summary>
	[JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
	public object Label { get; set; }

	/// <summary>
	///     数据项样式
	/// </summary>
	[JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
	public object ItemStyle { get; set; }

	/// <summary>
	///     判断是否需要对象包装
	/// </summary>
	public bool NeedObjectWrap()
	{
		return !string.IsNullOrEmpty(Name) ||
		       !string.IsNullOrEmpty(GroupId) ||
		       !string.IsNullOrEmpty(ChildGroupId) ||
		       Label != null ||
		       ItemStyle != null;
	}

	#region 隐式转换

	public static implicit operator DataItem(int val)
	{
		return new DataItem() { Value = val };
	}

	public static implicit operator DataItem(double val)
	{
		return new DataItem() { Value = val };
	}

	public static implicit operator DataItem(string val)
	{
		return new DataItem() { Value = val };
	}

	public static implicit operator DataItem(DateTime val)
	{
		return new DataItem() { Value = val };
	}

	public static implicit operator DataItem(object[] arr)
	{
		return new DataItem() { Value = arr };
	}

	#endregion
}

/// <summary>
///     智能数据项转换器
/// </summary>
public class DataItemConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(DataItem);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var token = JToken.Load(reader);

		// 对象形式
		if (token.Type == JTokenType.Object)
		{
			var item = new DataItem();
			serializer.Populate(token.CreateReader(), item);
			item.Value = token["value"]?.ToObject<object>(serializer);
			return item;
		}

		// 数组/简单值
		return new DataItem
		{
			Value = token.Type == JTokenType.Array
				? token.ToObject<object[]>(serializer)
				: token.ToObject<object>()
		};
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var item = (DataItem)value;

		if (item.NeedObjectWrap())
			WriteObjectForm(writer, item, serializer);
		else
			WriteSimpleValue(writer, item.Value, serializer);
	}

	private void WriteObjectForm(JsonWriter writer, DataItem item, JsonSerializer serializer)
	{
		writer.WriteStartObject();

		// Value字段
		writer.WritePropertyName("value");
		WriteValueField(writer, item.Value, serializer);

		// 其他字段
		if (!string.IsNullOrEmpty(item.Name))
			writer.WriteProperty("name", item.Name, serializer);
		if (!string.IsNullOrEmpty(item.GroupId))
			writer.WriteProperty("groupId", item.GroupId, serializer);
		if (!string.IsNullOrEmpty(item.ChildGroupId))
			writer.WriteProperty("childGroupId", item.ChildGroupId, serializer);
		if (item.Label != null)
			writer.WriteProperty("label", item.Label, serializer);
		if (item.ItemStyle != null)
			writer.WriteProperty("itemStyle", item.ItemStyle, serializer);

		writer.WriteEndObject();
	}

	private void WriteValueField(JsonWriter writer, object value, JsonSerializer serializer)
	{
		switch (value)
		{
			case null:
				writer.WriteNull();
				break;
			case double.NaN:
				writer.WriteRawValue("NaN");
				break;
			case DateTime dt:
				writer.WriteValue(dt.ToString("yyyy-MM-ddTHH:mm:ss"));
				break;
			case object[] arr:
				WriteArray(writer, arr, serializer);
				break;
			default:
				serializer.Serialize(writer, value);
				break;
		}
	}

	private void WriteSimpleValue(JsonWriter writer, object value, JsonSerializer serializer)
	{
		switch (value)
		{
			case null:
				writer.WriteNull();
				break;
			case double.NaN:
				writer.WriteRawValue("NaN");
				break;
			case string s when s == "-":
				writer.WriteRawValue("\"-\"");
				break;
			case DateTime dt:
				writer.WriteValue(dt.ToString("yyyy-MM-ddTHH:mm:ss"));
				break;
			case object[] arr:
				WriteArray(writer, arr, serializer);
				break;
			default:
				serializer.Serialize(writer, value);
				break;
		}
	}

	private void WriteArray(JsonWriter writer, object[] arr, JsonSerializer serializer)
	{
		writer.WriteStartArray();
		foreach (var item in arr) WriteSimpleValue(writer, item, serializer);
		writer.WriteEndArray();
	}
}

/// <summary>
///     JsonWriter扩展方法
/// </summary>
public static class JsonWriterExtensions
{
	public static void WriteProperty(this JsonWriter writer, string name, object value, JsonSerializer serializer)
	{
		writer.WritePropertyName(name);
		serializer.Serialize(writer, value);
	}
}