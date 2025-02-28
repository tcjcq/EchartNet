using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class LegendDataConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		// 同时支持单个对象和列表
		return objectType == typeof(Legend_Data)
		       || objectType == typeof(List<Legend_Data>);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		// 处理字符串直接构造对象
		if (reader.TokenType == JsonToken.String)
			return new Legend_Data { Name = (string)reader.Value };

		// 处理数组
		var token = JToken.Load(reader);
		if (token.Type == JTokenType.Array)
		{
			var list = new List<Legend_Data>();
			foreach (var item in token)
				if (item.Type == JTokenType.String)
				{
					list.Add(new Legend_Data { Name = item.Value<string>() });
				}
				else if (item.Type == JTokenType.Object)
				{
					// 使用序列化器反序列化对象，确保所有属性正确映射
					var data = new Legend_Data();
					serializer.Populate(item.CreateReader(), data);
					list.Add(data);
				}
				else
				{
					throw new JsonException("Unsupported token type in array");
				}

			return list;
		}

		throw new JsonException("Unexpected token type");
	}


	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		// 处理 List<Legend_Data> 情形
		if (value is List<Legend_Data> list)
		{
			writer.WriteStartArray();
			foreach (var item in list) WriteLegendDataItem(writer, item, serializer);
			writer.WriteEndArray();
			return;
		}

		// 处理单个 Legend_Data 情形
		if (value is Legend_Data data)
		{
			WriteLegendDataItem(writer, data, serializer);
			return;
		}

		throw new JsonSerializationException($"Unexpected type: {value?.GetType()}");
	}

	private void WriteLegendDataItem(JsonWriter writer, Legend_Data data, JsonSerializer serializer)
	{
		// 简单模式处理（仅序列化为字符串）
		if (data.IsSimpleString())
		{
			writer.WriteValue(data.Name);
			return;
		}

		// 反射模式写入（序列化为对象）
		writer.WriteStartObject();
		writer.WritePropertyName("name");
		writer.WriteValue(data.Name);

		foreach (var prop in typeof(Legend_Data).GetProperties()
			         .Where(p => p.Name != nameof(Legend_Data.Name)))
		{
			var propValue = prop.GetValue(data);
			if (ShouldSerialize(prop, propValue))
			{
				writer.WritePropertyName(GetJsonPropertyName(prop));
				serializer.Serialize(writer, propValue);
			}
		}

		writer.WriteEndObject();
	}

	private bool ShouldSerialize(PropertyInfo prop, object value)
	{
		// 处理空值忽略逻辑
		if (value == null) return false;

		// 处理特殊类型
		if (prop.PropertyType == typeof(StringOrNumber))
			return ((StringOrNumber)value).Value != null;

		// 处理默认值判断
		var defaultValue = GetDefaultValue(prop);
		return !value.Equals(defaultValue);
	}

	private string GetJsonPropertyName(PropertyInfo prop)
	{
		return prop.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName
		       ?? prop.Name;
	}

	private object GetDefaultValue(PropertyInfo prop)
	{
		return prop.PropertyType.IsValueType
			? Activator.CreateInstance(prop.PropertyType)
			: null;
	}
}