using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

/// <summary>
///     文字字体的粗细。
///     可选：
///     'normal'
///     'bold'
///     'bolder'
///     'lighter'
///     100 | 200 | 300 | 400...
/// </summary>
[JsonConverter(typeof(FontWeightConverter))]
public class FontWeightProperty
{
	private object _value;

	public FontWeightProperty(string value)
	{
		_value = value;
	}

	public FontWeightProperty(int value)
	{
		_value = value;
	}

	[JsonIgnore]
	public object Value
	{
		get => _value;
		set
		{
			if (value is string || value is int)
				_value = value;
			else
				throw new ArgumentException("值必须是 string 或 int 类型。");
		}
	}

	public override string ToString()
	{
		return _value.ToString();
	}

	// 隐式转换
	public static implicit operator FontWeightProperty(string value)
	{
		return new FontWeightProperty(value);
	}

	public static implicit operator FontWeightProperty(int value)
	{
		return new FontWeightProperty(value);
	}
}

public class FontWeightConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(FontWeightProperty);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		// 检查是否为 null 令牌
		if (reader.TokenType == JsonToken.Null) return null;

		var token = JToken.Load(reader);
		switch (token.Type)
		{
			case JTokenType.Integer:
				return new FontWeightProperty((int)token);
			case JTokenType.String:
				return new FontWeightProperty(token.ToString());
			default:
				throw new JsonSerializationException("无效的 JSON 类型用于 FontWeight");
		}
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (value == null) return;
		var fontWeight = (FontWeightProperty)value;
		serializer.Serialize(writer, fontWeight.Value);
	}
}