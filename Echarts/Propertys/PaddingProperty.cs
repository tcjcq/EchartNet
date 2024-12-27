using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts
{
	/// <summary>
	///     内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距，或单一数字设定全部方向。
	/// </summary>
	[JsonConverter(typeof(PaddingConverter))]
	public class PaddingProperty
	{
		public PaddingProperty(int uniformPadding)
		{
			Top = Right = Bottom = Left = uniformPadding;
		}

		public PaddingProperty(int[] paddings)
		{
			switch (paddings.Length)
			{
			case 1:
				// 所有方向相同
				Top = Right = Bottom = Left = paddings[0];
				break;
			case 2:
				// 上下相同，左右相同
				Top = Bottom = paddings[0];
				Right = Left = paddings[1];
				break;
			case 4:
				// 分别设置四个方向
				Top = paddings[0];
				Right = paddings[1];
				Bottom = paddings[2];
				Left = paddings[3];
				break;
			default:
				throw new ArgumentException("数组必须包含 1、2 或 4 个元素。");
			}
		}

		public int Top { get; }
		public int Right { get; }
		public int Bottom { get; }
		public int Left { get; }

		public static implicit operator PaddingProperty(int uniformPadding)
		{
			return new PaddingProperty(uniformPadding);
		}

		public static implicit operator PaddingProperty(int[] paddings)
		{
			return new PaddingProperty(paddings);
		}
	}

	public class PaddingConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(PaddingProperty);
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
				return new PaddingProperty(token.ToObject<int[]>());
			case JTokenType.Integer:
				return new PaddingProperty((int)token);
			default:
				throw new JsonSerializationException("无效的 JSON 格式用于 Padding");
			}
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value == null) return;
			var padding = (PaddingProperty)value;
			if (padding.Top == padding.Right && padding.Top == padding.Bottom && padding.Top == padding.Left)
				// 所有边的内边距相同时，序列化为单个整数
				serializer.Serialize(writer, padding.Top);
			else
				// 不同边的内边距时，序列化为整数数组
				serializer.Serialize(writer, new[] { padding.Top, padding.Right, padding.Bottom, padding.Left });
		}
	}
}