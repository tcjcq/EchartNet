using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;

namespace Echarts
{
	public class NumberOrBoolConverter : JsonConverter
	{
		public override bool CanConvert(Type t)
		{
			return t == typeof(NumberOrBool);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;

			var token = JToken.Load(reader);
			switch (token.Type)
			{
				case JTokenType.Integer:
				case JTokenType.Float:
					return new NumberOrBool(token.ToObject<double>(serializer));
				case JTokenType.Boolean:
					return new NumberOrBool(token.ToObject<bool>(serializer));
				default:
					throw new JsonSerializationException($"无法反序列化 {token.Type} 类型到 NumberOrBool。");
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var numberOrBool = (NumberOrBool)value;
			serializer.Serialize(writer, numberOrBool.Value);
		}

		public override bool CanWrite => true;
	}
}