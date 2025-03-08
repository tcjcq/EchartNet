using System;
using Newtonsoft.Json;

namespace Echarts;

[JsonConverter(typeof(DimensionValueConverter))]
public class DimensionValue
{
	public DimensionValue(string value)
	{
		Value = value;
	}

	public DimensionValue(int value)
	{
		Value = value;
	}

	public DimensionValue(object[] value)
	{
		if (value.Length != 2 || !(value[0] is string || value[1] is int))
			throw new ArgumentException("DimensionValue 必须是一个包含两个元素（string 或 int）的数组。");
		Value = value;
	}

	[JsonIgnore] public object Value { get; }

	public override string ToString()
	{
		return Value?.ToString() ?? string.Empty;
	}
}

public class DimensionValueConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(DimensionValue);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		switch (reader.TokenType)
		{
			case JsonToken.StartArray:
			{
				// 假设数组格式是 [int, string] 或 [string, int]
				var array = serializer.Deserialize<object[]>(reader);
				return new DimensionValue(array);
			}
			case JsonToken.Integer:
			case JsonToken.String:
				return new DimensionValue(reader.Value?.ToString());
			default:
				throw new JsonSerializationException("Unsupported token type for DimensionValue.");
		}
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var dimensionValue = (DimensionValue)value;
		if (dimensionValue != null)
		{
			if (dimensionValue.Value is object[])
				serializer.Serialize(writer, dimensionValue.Value);
			else
				writer.WriteValue(dimensionValue.Value);
		}
		else
		{
			writer.WriteNull();
		}
	}
}