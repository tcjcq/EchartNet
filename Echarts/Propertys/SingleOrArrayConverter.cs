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
	// 类型映射配置	
	private static readonly Dictionary<string, Type> TypeMap =
		new(StringComparer.OrdinalIgnoreCase)
		{
			{ "bar", typeof(SeriesBar) },
			{ "line", typeof(SeriesLine) }
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