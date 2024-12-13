using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Echarts
{
	public class StringOrBoolConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(StringOrBool);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;

			var token = JToken.Load(reader);
			switch (token.Type)
			{
			case JTokenType.String:
				return new StringOrBool(token.ToObject<string>(serializer));
			case JTokenType.Boolean:
				return new StringOrBool(token.ToObject<bool>(serializer));
			default:
				throw new JsonSerializationException($"无法反序列化 {token.Type} 类型到 StringOrBool。");
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var stringOrBool = (StringOrBool)value;
			if (stringOrBool != null) serializer.Serialize(writer, stringOrBool.Value);
		}
	}
}