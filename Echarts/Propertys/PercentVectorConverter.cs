using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Echarts
{
	/// <summary>
	/// 自定义 JSON 转换器，用于序列化和反序列化 PercentVector。
	/// </summary>
	public class PercentVectorConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(PercentVector);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartArray)
			{
				var list = serializer.Deserialize<List<string>>(reader);
				return new PercentVector { ArrayValues = list };
			}
			else if (reader.TokenType == JsonToken.String || reader.TokenType == JsonToken.Float ||
			         reader.TokenType == JsonToken.Integer)
			{
				var singleValue = serializer.Deserialize<string>(reader);
				return new PercentVector { SingleValue = singleValue };
			}

			throw new JsonSerializationException("Invalid PercentVector format.");
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var percentVector = (PercentVector)value;
			if (percentVector.IsSingleValue)
				serializer.Serialize(writer, percentVector.SingleValue);
			else if (percentVector.IsArrayValues)
				serializer.Serialize(writer, percentVector.ArrayValues);
			else
				throw new JsonSerializationException("Invalid PercentVector state.");
		}
	}
}