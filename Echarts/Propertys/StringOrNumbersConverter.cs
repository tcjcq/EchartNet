using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class StringOrNumbersConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(StringOrNumbers);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		// 检查是否为 null 令牌
		if (reader.TokenType == JsonToken.Null) return null;

		var token = JToken.Load(reader);
		switch (token.Type)
		{
			case JTokenType.String:
				return new StringOrNumbers(token.ToObject<string>());
			case JTokenType.Float:
			case JTokenType.Integer:
				return new StringOrNumbers(token.ToObject<double>());
			case JTokenType.Array:
				return new StringOrNumbers(token.ToObject<double[]>());
			default:
				throw new JsonSerializationException("Unexpected token type for StringOrNumbers: " + token.Type);
		}
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (value is StringOrNumbers stringOrNumbers)
			serializer.Serialize(writer, stringOrNumbers.Value);
		else
			writer.WriteNull();
	}
}