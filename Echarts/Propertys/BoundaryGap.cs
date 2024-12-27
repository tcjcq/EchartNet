using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts
{
	[JsonConverter(typeof(BoundaryGapConverter))]
	public class BoundaryGap
	{
		private object _value;

		public BoundaryGap(bool value)
		{
			_value = value;
		}

		public BoundaryGap(string[] value)
		{
			_value = value;
		}

		[JsonIgnore]
		public object Value
		{
			get => _value;
			set
			{
				if (value is bool || value is string[])
					_value = value;
				else
					throw new ArgumentException("值必须是 bool 或 string[] 类型。");
			}
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		// 隐式转换
		public static implicit operator BoundaryGap(bool value)
		{
			return new BoundaryGap(value);
		}

		public static implicit operator BoundaryGap(string[] value)
		{
			return new BoundaryGap(value);
		}
	}

	public class BoundaryGapConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(BoundaryGap);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			// 检查是否为 null 令牌
			if (reader.TokenType == JsonToken.Null) return null;

			var token = JToken.Load(reader);
			switch (token.Type)
			{
			case JTokenType.Boolean:
				return new BoundaryGap((bool)token);
			case JTokenType.Array:
				return new BoundaryGap(token.ToObject<string[]>());
			default:
				throw new JsonSerializationException("无效的 JSON 类型用于 BoundaryGap");
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var boundaryGap = (BoundaryGap)value;
			serializer.Serialize(writer, boundaryGap.Value);
		}
	}
}