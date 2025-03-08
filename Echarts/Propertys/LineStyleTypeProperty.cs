using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

[JsonConverter(typeof(LineStyleTypePropertyConverter))]
public class LineStyleTypeProperty
{
	private object _value;

	public LineStyleTypeProperty(string value)
	{
		_value = value;
	}

	public LineStyleTypeProperty(double value)
	{
		_value = value;
	}

	public LineStyleTypeProperty(double[] value)
	{
		_value = value;
	}

	[JsonIgnore]
	public object Value
	{
		get => _value;
		set
		{
			if (value is string || value is double || value is double[])
				_value = value;
			else
				throw new ArgumentException("值必须是 string、double 或 double[] 类型。");
		}
	}

	public override string ToString()
	{
		return _value.ToString();
	}

	// 隐式转换
	public static implicit operator LineStyleTypeProperty(string value)
	{
		return new LineStyleTypeProperty(value);
	}

	public static implicit operator LineStyleTypeProperty(double value)
	{
		return new LineStyleTypeProperty(value);
	}

	public static implicit operator LineStyleTypeProperty(double[] value)
	{
		return new LineStyleTypeProperty(value);
	}
}

public class LineStyleTypePropertyConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(LineStyleTypeProperty);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		// 检查是否为 null 令牌
		if (reader.TokenType == JsonToken.Null) return null;

		var token = JToken.Load(reader);
		if (token.Type == JTokenType.String)
			return new LineStyleTypeProperty(token.ToObject<string>());
		if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
			return new LineStyleTypeProperty(token.ToObject<double>());
		if (token.Type == JTokenType.Array)
			return new LineStyleTypeProperty(token.ToObject<double[]>());
		throw new JsonSerializationException("Unexpected token type for LineStyleTypeProperty: " + token.Type);
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (!(value is LineStyleTypeProperty lineStyleTypeProperty))
		{
			writer.WriteNull();
			return;
		}

		var val = lineStyleTypeProperty.Value;
		if (val is double[] arrayVal)
			// 序列化为数组
			serializer.Serialize(writer, arrayVal);
		else
			// 直接序列化值（string 或 double）
			serializer.Serialize(writer, val);
	}
}