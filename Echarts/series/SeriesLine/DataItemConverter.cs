using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class DataItemConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(DataItem);
	}


	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var token = JToken.Load(reader);
		var item = new DataItem();

		switch (token.Type)
		{
			case JTokenType.Object:
				var obj = (JObject)token;
				item.Value = obj["value"]?.ToObject<object>();
				item.Name = obj["name"]?.ToString();
				item.ItemStyle = obj["itemStyle"]?.ToObject<HandleStyle0>();
				break;

			case JTokenType.Array:
				item.Value = ((JArray)token).ToObject<StringOrNumber[]>();
				break;

			default:
				item.Value = token.ToObject<object>();
				break;
		}

		return item;
	}

	private object ParseValue(JToken token)
	{
		return token.Type switch
		{
			JTokenType.Array   => ParseJArray((JArray)token),
			JTokenType.String  => token.Value<string>(),
			JTokenType.Float   => token.Value<double>(),
			JTokenType.Integer => token.Value<long>(),
			JTokenType.Null    => null,
			_                  => token.ToString()
		};
	}

	private object ParseJArray(JArray array)
	{
		var result = new List<object>();
		foreach (var item in array) result.Add(ParseValue(item));
		return result.ToArray();
	}

	private object ParseString(string value)
	{
		// 处理特殊字符串值
		if (value == "-") return value;
		if (double.TryParse(value, out var num)) return num;

		// 处理日期格式
		if (DateTime.TryParseExact(value,
			    new[] { "yyyy-MM-dd", "yyyy-MM-ddTHH:mm:ss" },
			    CultureInfo.InvariantCulture,
			    DateTimeStyles.None,
			    out var date))
			return date;

		return value;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var item = (DataItem)value;

		if (item.HasExtendedProperties())
		{
			writer.WriteStartObject();

			// 处理Value字段
			writer.WritePropertyName("value");
			WriteValue(writer, item.Value, serializer);

			// 处理其他字段
			if (!string.IsNullOrEmpty(item.Name))
				writer.WriteProperty("name", item.Name);
			if (item.Label != null)
				writer.WriteProperty("label", item.Label);
			if (item.ItemStyle != null)
				writer.WriteProperty("itemStyle", item.ItemStyle);

			writer.WriteEndObject();
		}
		else
		{
			WriteValue(writer, item.Value, serializer);
		}
	}

	private void WriteValue(JsonWriter writer, object value, JsonSerializer serializer)
	{
		switch (value)
		{
			case null:
				writer.WriteNull();
				break;
			case DateTime dt:
				writer.WriteValue(dt.ToString("yyyy-MM-dd"));
				break;
			case object[] array:
				writer.WriteStartArray();
				foreach (var element in array) WriteValue(writer, element, serializer);
				writer.WriteEndArray();
				break;
			default:
				serializer.Serialize(writer, value);
				break;
		}
	}
}

public static class JsonWriterExtensions
{
	public static void WriteProperty(this JsonWriter writer, string name, object value)
	{
		writer.WritePropertyName(name);
		writer.WriteValue(value);
	}
}