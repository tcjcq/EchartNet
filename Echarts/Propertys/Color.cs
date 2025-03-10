using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;

namespace Echarts;

[JsonConverter(typeof(ColorConverter))]
public class Color
{
	private static readonly string[] DefaultColors =
		["#5470c6", "#91cc75", "#fac858", "#ee6666", "#73c0de", "#3ba272", "#fc8452", "#9a60b4", "#ea7ccc"];

	public Color() : this(DefaultColors)
	{
	}

	public Color(string colorValue)
	{
		Value = colorValue;
	}

	public Color(IEnumerable<string> colorValue)
	{
		var s = colorValue.Aggregate("", (current, r) => $"{current},{r}");
		Value = s.Trim(',');
	}

	[JsonIgnore] public string Value { get; set; }

	public override string ToString()
	{
		return Value;
	}

	// 从 string 到 Color 的隐式转换
	public static implicit operator Color(string value)
	{
		return new Color(value);
	}

	public static implicit operator Color(string[] value)
	{
		return new Color(value);
	}

	// 从 Color 到 string 的隐式转换
	public static implicit operator string(Color color)
	{
		return color.Value;
	}

	public static implicit operator string[](Color color)
	{
		return string.IsNullOrEmpty(color.Value)
			? []
			: color.Value.Split([','], StringSplitOptions.RemoveEmptyEntries);
	}

	// 从 System.Drawing.Color 到 Color 的隐式转换
	public static implicit operator Color(System.Drawing.Color color)
	{
		return new Color(ColorTranslator.ToHtml(color));
	}


	// 从 Color 到 System.Drawing.Color 的隐式转换
	public static implicit operator System.Drawing.Color(Color color)
	{
		if (color == null || string.IsNullOrEmpty(color.Value)) return System.Drawing.Color.Empty;
		return ColorTranslator.FromHtml(color.Value);
	}
}

public class ColorConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(Color);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		if (reader.TokenType == JsonToken.Null) return null;

		var value = reader.Value as string;

		// 如果是逗号分隔的颜色值，进行分割并转换为数组
		return string.IsNullOrEmpty(value)
			? null
			: new Color(value.Split([','], StringSplitOptions.RemoveEmptyEntries));
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (value is not Color color)
		{
			writer.WriteNull();
			return;
		}

		// 如果是以 'function' 开头的函数字符串，直接写入函数而不加引号
		if (!string.IsNullOrEmpty(color.Value) && color.Value.TrimStart().StartsWith("function"))
			writer.WriteRawValue(color.Value); // 直接写入函数字符串
		else
			writer.WriteValue(color.Value); // 作为普通字符串写入
	}
}