using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Echarts
{
	public class StringOrNumberConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(StringOrNumber);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			// 检查是否为 null 令牌
			if (reader.TokenType == JsonToken.Null) return null;

			var token = JToken.Load(reader);
			switch (token.Type)
			{
			case JTokenType.Float:
			case JTokenType.Integer:
				return new StringOrNumber((double)token);
			case JTokenType.String:
				return new StringOrNumber(token.ToString());
			default:
				return (StringOrNumber)null;
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (!(value is StringOrNumber stringOrNumber)) return;
			var val = stringOrNumber.Value;
			if (val is string strVal && strVal.TrimStart().StartsWith("function"))
				writer.WriteRawValue(strVal); // 直接写入原始 JavaScript 函数
			else if (val != null)
				writer.WriteValue(val); // 正常写入数字或字符串
			else
				writer.WriteNull();
		}
	}
}