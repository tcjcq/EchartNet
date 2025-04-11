using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

	public Color(RadialGradient gradient)
	{
		Value = gradient;
	}

	public Color(TextureFill texture)
	{
		Value = texture;
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

	public static implicit operator Color(RadialGradient gradient)
	{
		return new Color(gradient);
	}

	public static implicit operator Color(TextureFill texture)
	{
		return new Color(texture);
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
		switch (reader.TokenType)
		{
			case JsonToken.StartObject:
				var jo = JObject.Load(reader);

				if (jo["type"] != null)
					return jo["type"].ToString() switch
					{
						"linear" => new Color(jo.ToObject<LinearGradient>()),
						"radial" => new Color(jo.ToObject<RadialGradient>()),
						_        => throw new JsonException("Unknown gradient type")
					};
				if (jo["image"] != null) return new Color(jo.ToObject<TextureFill>());
				break;
			case JsonToken.String:
			{
				var value = reader.Value as string;

				// 如果是逗号分隔的颜色值，进行分割并转换为数组
				return string.IsNullOrEmpty(value)
					? null
					: new Color(value.Split([','], StringSplitOptions.RemoveEmptyEntries));
			}
		}

		return null;
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
				serializer.Serialize(writer, color.Value); // 作为普通字符串写入
			return;
		}

		serializer.Serialize(writer, color.Value);
	}
}

public static class EchartsColorParser
{
	private const string Pattern =
		@"new\s+echarts\.graphic\.LinearGradient$\s*((?:[^()]|(?<Open>[(])|(?<-Open>[)]))*?)\s*$";

	public static string Convert(string input)
	{
		string Evaluator(Match match)
		{
			// 提取参数部分
			var parameters = match.Groups[1].Value;

			// 移除参数中的换行和多余空格
			parameters = Regex.Replace(parameters, @"\s+", " ");

			return $"{{ {parameters} }}";
		}

		return Regex.Replace(input, Pattern, Evaluator, RegexOptions.Singleline);
	}

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
	[JsonProperty("type")] public string Type { get; set; } = "linear";
	[JsonProperty("x")] public double X { get; set; }
	[JsonProperty("y")] public double Y { get; set; }
	[JsonProperty("x2")] public double X2 { get; set; }
	[JsonProperty("y2")] public double Y2 { get; set; }
	[JsonProperty("colorStops")] public List<ColorStop> ColorStops { get; set; }
	[JsonProperty("global")] public bool Global { get; set; }
}

public class RadialGradient
{
	[JsonProperty("type")] public string Type { get; set; } = "radial";
	[JsonProperty("x")] public double X { get; set; }
	[JsonProperty("y")] public double Y { get; set; }
	[JsonProperty("r")] public double R { get; set; }
	[JsonProperty("colorStops")] public List<ColorStop> ColorStops { get; set; }
	[JsonProperty("global")] public bool Global { get; set; }
}

public class ColorStop
{
	[JsonProperty("offset")] public double Offset { get; set; }
	[JsonProperty("color")] public Color Color { get; set; }
}

public class TextureFill
{
	[JsonProperty("image")] public string image { get; set; }
	[JsonProperty("repeat")] public string repeat { get; set; }
}

public class ColorParser
{
	public static string Parse(string input)
	{
		// 去掉换行符和多余空格，简化解析
		input = Regex.Replace(input, @"\s+", " ");

		// 匹配 LinearGradient、RadialGradient 或 Texture
		var match = Regex.Match(input, @"new echarts\.graphic\.(\w+)\((.+)\)");
		if (!match.Success) throw new ArgumentException("无效格式");

		var type = match.Groups[1].Value;
		var paramStr = match.Groups[2].Value;
		switch (type)
		{
			case "LinearGradient":
				return ParseLinearGradient(paramStr).ToString();
			case "RadialGradient":
				return ParseRadialGradient(paramStr).ToString();
			case "Texture":
				return ParseTexture(paramStr);
			default:
				throw new NotSupportedException($"不支持的类型: {type}");
		}
	}

	private static LinearGradient ParseLinearGradient(string paramStr)
	{
		// 0, 0, 0, 1, [ { offset: 0, color: 'red' }, ... ], false
		var parts = SplitParams(paramStr, 6);
		var stops = ParseColorStops(parts[4]);
		var obj = new LinearGradient
		{
			X = double.Parse(parts[0]),
			Y = double.Parse(parts[1]),
			X2 = double.Parse(parts[2]),
			Y2 = double.Parse(parts[3]),
			ColorStops = stops
		};
		return obj;
	}

	private static RadialGradient ParseRadialGradient(string paramStr)
	{
		// x, y, r, colorStops, global
		var parts = SplitParams(paramStr, 5);
		var stops = ParseColorStops(parts[3]);

		var obj = new RadialGradient
		{
			X = double.Parse(parts[0]),
			Y = double.Parse(parts[1]),
			R = double.Parse(parts[2]),
			ColorStops = stops,
			Global = bool.Parse(parts[4])
		};
		return obj;
	}

	private static string ParseTexture(string json)
	{
		// 转换 JS 风格为 JSON（引号）
		json = Regex.Replace(json, @"(\w+):", "\"$1\":");
		json = json.Replace("'", "\"");

		return json;
	}

	private static List<ColorStop> ParseColorStops(string stopsJson)
	{
		stopsJson = Regex.Replace(stopsJson, @"(\w+):", "\"$1\":");
		stopsJson = stopsJson.Replace("'", "\"");
		var i1 = stopsJson.IndexOf(']');
		stopsJson = stopsJson.Substring(0, i1 + 1);
		var array = JArray.Parse(stopsJson);
		var list = new List<ColorStop>();

		foreach (var item in array)
			list.Add(new ColorStop
			{
				Offset = item["offset"].Value<double>(),
				Color = new Color(item["color"].ToString())
			});

		return list;
	}

	private static string[] SplitParams(string paramStr, int expectedCount)
	{
		var result = new List<string>();
		var depth = 0;
		var start = 0;
		for (var i = 0; i < paramStr.Length; i++)
		{
			var c = paramStr[i];
			if (c is '[' or '{' or '(')
			{
				depth++;
			}
			else if (c is ']' or '}' or ')')
			{
				depth--;
			}
			else if (c == ',' && depth == 0)
			{
				result.Add(paramStr.Substring(start, i - start).Trim());
				start = i + 1;
			}
		}

		result.Add(paramStr.Substring(start).Trim());

		if (result.Count < expectedCount)
			throw new FormatException($"参数数量不匹配：期望 {expectedCount} 个，实际 {result.Count} 个");

		return result.ToArray();
	}
}

public class GradientConverter
{
	private static readonly Regex GradientStartRegex = new(
		@"new\s+echarts\.graphic\.(?<type>\w+)\s*(?<args>\((?>[^()]+|\((?<Depth>)|\)(?<-Depth>))*(?(Depth)(?!))\))",
		RegexOptions.Compiled | RegexOptions.Singleline);


	/// <summary>
	///     转换所有图形对象为JSON格式
	/// </summary>
	public static string ConvertAll(string input)
	{
		var matches = GradientStartRegex.Matches(input);
		var output = new StringBuilder(input);

		// 反向替换以避免位置偏移
		for (var i = matches.Count - 1; i >= 0; i--)
		{
			var match = matches[i];
			try
			{
				var json = ProcessMatch(match);
				output.Remove(match.Index, match.Length);
				output.Insert(match.Index, json);
			}
			catch (Exception ex)
			{
				output.Insert(match.Index + match.Length, $"/* 转换错误: {ex.Message} */");
			}
		}

		return output.ToString();
	}

	private static string ProcessMatch(Match match)
	{
		var typeName = match.Groups[1].Value;
		var paramsStr = match.Groups[2].Value;

		return typeName switch
		{
			"LinearGradient" => JsonConvert.SerializeObject(ParseLinearGradient(paramsStr)),
			"RadialGradient" => JsonConvert.SerializeObject(ParseRadialGradient(paramsStr)),
			"Pattern"        => JsonConvert.SerializeObject(ParsePattern(paramsStr)),
			_                => throw new NotSupportedException($"不支持的类型: {typeName}")
		};
	}

	#region 具体类型解析

	private static LinearGradient ParseLinearGradient(string paramsStr)
	{
		var parameters = ParseParameters(paramsStr);
		if (parameters.Count < 4) throw new FormatException("参数不足");

		return new LinearGradient
		{
			Type = "linear",
			X = double.Parse(parameters[0]),
			Y = double.Parse(parameters[1]),
			X2 = double.Parse(parameters[2]),
			Y2 = double.Parse(parameters[3]),
			ColorStops = ParseColorStops(parameters[4]),
			Global = false
		};
	}

	private static RadialGradient ParseRadialGradient(string paramsStr)
	{
		var parameters = ParseParameters(paramsStr);
		if (parameters.Count < 3) throw new FormatException("参数不足");

		return new RadialGradient
		{
			Type = "radial",
			X = double.Parse(parameters[0]),
			Y = double.Parse(parameters[1]),
			R = double.Parse(parameters[2]),
			ColorStops = ParseColorStops(parameters[3]),
			Global = false
		};
	}

	private static List<ColorStop> ParseColorStops(string stopsJson)
	{
		stopsJson = Regex.Replace(stopsJson, @"(\w+):", "\"$1\":");
		stopsJson = stopsJson.Replace("'", "\"");
		var i1 = stopsJson.IndexOf(']');
		stopsJson = stopsJson.Substring(0, i1 + 1);
		var array = JArray.Parse(stopsJson);
		var list = new List<ColorStop>();

		foreach (var item in array)
			list.Add(new ColorStop
			{
				Offset = item["offset"].Value<double>(),
				Color = new Color(item["color"].ToString())
			});

		return list;
	}


	private static TextureFill ParsePattern(string paramsStr)
	{
		var parameters = ParseParameters(paramsStr);
		if (parameters.Count < 2) throw new FormatException("参数不足");
		var pattern = new TextureFill
		{
			image = parameters[0].Split(':')[1].Trim().Trim('\n'),
			repeat = parameters[1].Split(':')[1].Trim('}').Trim().Trim('\n').Trim('\'')
		};
		return pattern;
	}

	#endregion

	#region 通用解析工具

	private static List<string> ParseParameters(string input)
	{
		var parameters = new List<string>();
		// 去掉最外层括号
		input = input.Trim();
		if (input.StartsWith("(") && input.EndsWith(")")) input = input.Substring(1, input.Length - 2);

		var bracketCount = 0;
		var start = 0;
		for (var i = 0; i < input.Length; i++)
		{
			var c = input[i];
			if (c == '[')
			{
				bracketCount++;
			}
			else if (c == ']')
			{
				bracketCount--;
			}
			else if (c == ',' && bracketCount == 0)
			{
				parameters.Add(input.Substring(start, i - start).Trim());
				start = i + 1;
			}
		}

		if (start < input.Length) parameters.Add(input.Substring(start).Trim());

		return parameters;
	}

	private static JArray ParseColor(JToken token)
	{
		if (token == null) return new JArray();

		return token.Type == JTokenType.Array ? (JArray)token : throw new FormatException("颜色停止点必须是数组");
	}

	#endregion
}

