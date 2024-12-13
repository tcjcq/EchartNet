using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Echarts
{
	[JsonConverter(typeof(BorderRadiusConverter))]
	public class BorderRadiusProperty
	{
		// 分别表示左上、右上、右下、左下四个角的半径
		public int TopLeft { get; private set; }
		public int TopRight { get; private set; }
		public int BottomRight { get; private set; }
		public int BottomLeft { get; private set; }

		// 构造函数，用于设置统一的边框圆角半径

		public BorderRadiusProperty(int uniformRadius)
		{
			TopLeft = TopRight = BottomRight = BottomLeft = uniformRadius;
		}

		// 构造函数，用于分别设置四个角的边框圆角半径
		public BorderRadiusProperty(int[] radii)
		{
			if (radii.Length != 4) throw new ArgumentException("数组必须恰好包含 4 个元素。");

			TopLeft = radii[0];
			TopRight = radii[1];
			BottomRight = radii[2];
			BottomLeft = radii[3];
		}

		// 允许从 int 隐式转换为 BorderRadiusProperty
		public static implicit operator BorderRadiusProperty(int uniformRadius)
		{
			return new BorderRadiusProperty(uniformRadius);
		}

		// 允许从 int[] 隐式转换为 BorderRadiusProperty
		public static implicit operator BorderRadiusProperty(int[] radii)
		{
			return new BorderRadiusProperty(radii);
		}
	}

	public class BorderRadiusConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(BorderRadiusProperty);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			// 检查是否为 null 令牌
			if (reader.TokenType == JsonToken.Null) return null;

			var token = JToken.Load(reader);
			switch (token.Type)
			{
			case JTokenType.Array:
				return new BorderRadiusProperty(token.ToObject<int[]>());
			case JTokenType.Integer:
				return new BorderRadiusProperty((int)token);
			default:
				throw new JsonSerializationException("无效的 JSON 格式用于 BorderRadius");
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null) return;
			var borderRadius = (BorderRadiusProperty)value;
			if (borderRadius.TopLeft == borderRadius.TopRight && borderRadius.TopLeft == borderRadius.BottomRight &&
			    borderRadius.TopLeft == borderRadius.BottomLeft)
				// 所有角半径相同时，序列化为单个整数
				serializer.Serialize(writer, borderRadius.TopLeft);
			else
				// 不同角半径时，序列化为整数数组
				serializer.Serialize(writer,
					new[]
					{
						borderRadius.TopLeft, borderRadius.TopRight, borderRadius.BottomRight, borderRadius.BottomLeft
					});
		}
	}
}