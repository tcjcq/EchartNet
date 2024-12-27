using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts
{
	/// <summary>
	///     贴花图案的基本模式是在横向和纵向上分别以图案
	///     - 空白 - 图案 - 空白 - 图案 - 空白的形式无限循环。
	///     通过设置每个图案和空白的长度，可以实现复杂的图案效果。
	///     dashArrayX 控制了横向的图案模式。
	///     当其值为 number 或 number[] 类型时，与 SVG stroke-dasharray 类似。
	/// </summary>
	[JsonConverter(typeof(DashArrayConverter))]
	public class DashArray
	{
		private object _value;

		public DashArray(double value)
		{
			_value = value;
		}

		public DashArray(double[] value)
		{
			_value = value;
		}

		public DashArray(double[][] value)
		{
			_value = value;
		}

		[JsonIgnore]
		public object Value
		{
			get => _value;
			set
			{
				if (value is double || value is double[] || value is double[][])
					_value = value;
				else
					throw new ArgumentException("值必须是 double、double[] 或 double[][] 类型。");
			}
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		// 隐式转换
		public static implicit operator DashArray(double value)
		{
			return new DashArray(value);
		}

		public static implicit operator DashArray(double[] value)
		{
			return new DashArray(value);
		}

		public static implicit operator DashArray(double[][] value)
		{
			return new DashArray(value);
		}
	}

	public class DashArrayConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DashArray);
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
				return new DashArray((double)token);
			case JTokenType.Array:
				var firstElement = token.First();
				return firstElement.Type == JTokenType.Array
					? new DashArray(token.ToObject<double[][]>())
					: new DashArray(token.ToObject<double[]>());

			default:
				throw new JsonSerializationException("无效的 JSON 类型用于 DashArray");
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null) return;
			var dashArray = (DashArray)value;
			serializer.Serialize(writer, dashArray.Value);
		}
	}
}