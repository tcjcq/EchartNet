using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
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

	public Color(LinearGradient gradient)
	{
		Value = gradient;
	}

	public Color(IEnumerable<string> colorValue)
	{
		var s = colorValue.Aggregate("", (current, r) => $"{current},{r}");
		Value = s.Trim(',');
	}

	[JsonIgnore] public object Value { get; set; }

	public override string ToString()
	{
		return JsonConvert.SerializeObject(Value);
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


	public static implicit operator string[](Color color)
	{
		if (color.Value is string s)
			return string.IsNullOrEmpty(s)
				? []
				: s.Split([','], StringSplitOptions.RemoveEmptyEntries);
		return [];
	}

	// 从 System.Drawing.Color 到 Color 的隐式转换
	public static implicit operator Color(System.Drawing.Color color)
	{
		return new Color(ColorTranslator.ToHtml(color));
	}


	// 从 Color 到 System.Drawing.Color 的隐式转换
	public static implicit operator System.Drawing.Color(Color color)
	{
		if (color.Value is string s)
		{
			if (string.IsNullOrEmpty(s)) return System.Drawing.Color.Empty;
			return ColorTranslator.FromHtml(s);
		}

		if (color.Value is LinearGradient gradient) return new Color(gradient);
		return System.Drawing.Color.Empty;
	}

	public static implicit operator Color(LinearGradient gradient)
	{
		return new Color(gradient);
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

		if (color.Value is string s)
		{
			// 如果是以 'function' 开头的函数字符串，直接写入函数而不加引号
			if (!string.IsNullOrEmpty(s) && s.TrimStart().StartsWith("function"))
				writer.WriteRawValue(s); // 直接写入函数字符串
			else
				writer.WriteValue(s); // 作为普通字符串写入
		}

		if (color.Value is LinearGradient gradient)
			//writer.WriteValue(JsonConvert.SerializeObject(gradient));
			writer.WriteValue(gradient);
	}
}

public static class EchartsColorParser
{
	public static Color Parse(string input)
	{
		// 匹配渐变色模式 
		var match = Regex.Match(input,
			@"new\s+echarts\.graphic\.LinearGradient\(([^)]+)\)",
			RegexOptions.Singleline);

		if (match.Success)
		{
			var parameters = match.Groups[1].Value.Split(',')
				.Select(x => x.Trim()).ToArray();

			// 提取坐标参数 
			var coords = parameters.Take(4)
				.Select(double.Parse).ToArray();

			// 提取颜色停止点 
			var colorStops = JsonConvert.DeserializeObject<List<ColorStop>>(
				string.Join("", parameters.Skip(4)));

			return new Color(new LinearGradient
			{
				X = coords[0],
				Y = coords[1],
				X2 = coords[2],
				Y2 = coords[3],
				ColorStops = colorStops
			});
		}

		// 普通颜色值 
		return new Color(input.Trim('\'', '"'));
	}
}

public class LinearGradient
{
	public double X { get; set; }
	public double Y { get; set; }
	public double X2 { get; set; }
	public double Y2 { get; set; }
	public List<ColorStop> ColorStops { get; set; }
}

public class ColorStop
{
	public double Offset { get; set; }
	public string Color { get; set; }
}