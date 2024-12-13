using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Echarts
{
	/// <summary>
	/// 文字本身的描边类型。
	/// 可选：
	/// 'solid'
	/// 'dashed'
	/// 'dotted'
	/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 textBorderDashOffset 可实现更灵活的虚线效果。
	/// </summary>
	[JsonConverter(typeof(BorderTypeConverter))]
	public class BorderTypeProperty
	{
		private object _value;

		public BorderTypeProperty(string value)
		{
			_value = value;
		}

		public BorderTypeProperty(double value)
		{
			_value = value;
		}

		public BorderTypeProperty(double[] value)
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
		public static implicit operator BorderTypeProperty(string value)
		{
			return new BorderTypeProperty(value);
		}

		public static implicit operator BorderTypeProperty(double value)
		{
			return new BorderTypeProperty(value);
		}

		public static implicit operator BorderTypeProperty(double[] value)
		{
			return new BorderTypeProperty(value);
		}
	}

	public class BorderTypeConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(BorderTypeProperty);
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
				return new BorderTypeProperty(token.ToString());
			case JTokenType.Float:
			case JTokenType.Integer:
				return new BorderTypeProperty((double)token);
			case JTokenType.Array:
				return new BorderTypeProperty(token.ToObject<double[]>());
			default:
				throw new JsonSerializationException("无效的 JSON 类型用于 TextBorderType");
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null) return;
			var textBorderType = (BorderTypeProperty)value;
			serializer.Serialize(writer, textBorderType.Value);
		}
	}
}