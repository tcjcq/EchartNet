using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class ArrayOrSingleConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(ArrayOrSingle);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		// 检查是否为 null 令牌
		if (reader.TokenType == JsonToken.Null) return null;
		switch (reader.TokenType)
		{
			case JsonToken.StartArray:
				// 反序列化整数数组
				var token = JToken.Load(reader);
				var ls = new List<StringOrNumber>();
				foreach (var r in token)
					if (r != null)
						switch (r.Type)
						{
							case JTokenType.Integer:
								ls.Add(r.ToObject<int>());
								break;
							case JTokenType.Float:
								ls.Add(r.ToObject<double>());
								break;
							case JTokenType.String:
								ls.Add(r.ToObject<string>());
								break;
							case JTokenType.None:
								break;
							case JTokenType.Object:
								break;
							case JTokenType.Array:
								break;
							case JTokenType.Constructor:
								break;
							case JTokenType.Property:
								break;
							case JTokenType.Comment:
								break;
							case JTokenType.Boolean:
								break;
							case JTokenType.Null:
								break;
							case JTokenType.Undefined:
								break;
							case JTokenType.Date:
								break;
							case JTokenType.Raw:
								break;
							case JTokenType.Bytes:
								break;
							case JTokenType.Guid:
								break;
							case JTokenType.Uri:
								break;
							case JTokenType.TimeSpan:
								break;
						}

				return new ArrayOrSingle(ls);
			case JsonToken.Boolean:
				return new ArrayOrSingle(Convert.ToBoolean(reader.Value));
			case JsonToken.Integer:
				// 反序列化单个整数
				return new ArrayOrSingle(Convert.ToInt32(reader.Value));
			case JsonToken.Float:
				// 反序列化单个浮点数
				return new ArrayOrSingle(Convert.ToDouble(reader.Value));
			case JsonToken.String:
				// 反序列化单个字符串
				return new ArrayOrSingle((string)reader.Value);
		}

		return null;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var arrayIntOrString = (ArrayOrSingle)value;

		// 调用ArrayIntOrString的GetValue方法获取值
		if (arrayIntOrString == null) return;
		var result = arrayIntOrString.GetValue();
		switch (result)
		{
			// 检查result的类型并序列化
			case int singleInt:
				// 如果是单个整数，直接写入整数值
				writer.WriteValue(singleInt);
				break;
			case StringOrNumber stringOrNumber:
				// 如果是单个整数，直接写入整数值
				writer.WriteValue(stringOrNumber);
				break;
			case bool singleBool:
				writer.WriteValue(singleBool);
				break;
			case double singleDouble:
				writer.WriteValue(singleDouble);
				break;
			case string singleString:
				// 如果是单个字符串，直接写入字符串值
				writer.WriteValue(singleString);
				break;
			// 如果是整数列表，序列化列表
			case List<int> { Count: 1 } intList:
				writer.WriteValue(intList[0]);
				break;
			case List<StringOrNumber> { Count: 1 } s1:
				serializer.Serialize(writer, s1[0]);
				break;
			case List<StringOrNumber> s2:
				serializer.Serialize(writer, s2);
				break;
			case List<int> intList:
				serializer.Serialize(writer, intList);
				break;
			// 如果是整数列表，序列化列表
			case List<double> { Count: 1 } doubleList:
				writer.WriteValue(doubleList[0]);
				break;
			case List<double> doubleList:
				serializer.Serialize(writer, doubleList);
				break;
			// 如果是字符串列表，序列化列表
			case List<string> { Count: 1 } stringList:
				writer.WriteValue(stringList[0]);
				break;
			case List<string> stringList:
				serializer.Serialize(writer, stringList);
				break;
			default:
				// 如果结果是null或未知类型，写入null
				writer.WriteNull();
				break;
		}
	}
}