using Newtonsoft.Json;
using System;

namespace Echarts
{
	[JsonConverter(typeof(EdgePropertyConverter))]
	public class EdgeProperty
	{
		private enum SpecialPosition
		{
			Auto,
			Left,
			Center,
			Right,
			Top,
			Bottom,
			Middle
		}

		private readonly int? _pixelValue;
		private readonly string _percentageValue;
		private readonly SpecialPosition? _specialPosition;

		public EdgeProperty(int pixels)
		{
			_pixelValue = pixels;
		}

		public EdgeProperty(string value)
		{
			if (int.TryParse(value, out var pixelValue))
				_pixelValue = pixelValue;
			else if (value != null && value.EndsWith("%") && int.TryParse(value.TrimEnd('%'), out var _))
				_percentageValue = value;
			else if (Enum.TryParse<SpecialPosition>(value, true, out var positionValue))
				_specialPosition = positionValue;
			else
				_specialPosition = SpecialPosition.Auto;
		}

		public static implicit operator EdgeProperty(int pixels)
		{
			return new EdgeProperty(pixels);
		}

		public static implicit operator EdgeProperty(string value)
		{
			return new EdgeProperty(value);
		}

		public override string ToString()
		{
			if (_pixelValue.HasValue) return _pixelValue.Value.ToString();
			if (_percentageValue != null) return _percentageValue;
			if (_specialPosition.HasValue) return _specialPosition.Value.ToString().ToLowerInvariant();
			return "auto";
		}
	}

	public class EdgePropertyConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value != null) writer.WriteValue(value.ToString());
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			// 检查是否为 null 令牌
			if (reader.TokenType == JsonToken.Null) return null;
			return reader.Value != null ? new EdgeProperty(reader.Value.ToString()) : null;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(EdgeProperty);
		}
	}
}