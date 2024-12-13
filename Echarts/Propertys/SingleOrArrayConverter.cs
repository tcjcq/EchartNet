using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Echarts
{
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
}