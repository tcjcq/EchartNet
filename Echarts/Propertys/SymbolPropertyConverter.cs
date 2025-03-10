using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class SymbolPropertyConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(SymbolProperty);
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
				return new SymbolProperty(token.ToObject<string>());
			case JTokenType.Array:
				return new SymbolProperty(token.ToObject<string[]>());
			default:
				return new SymbolProperty(token.ToObject<string>());
		}
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (value is not SymbolProperty symbolProperty) return;
		if (symbolProperty.Value is string[])
			serializer.Serialize(writer, symbolProperty.Value);
		else
			writer.WriteValue(symbolProperty.Value.ToString());
	}
}