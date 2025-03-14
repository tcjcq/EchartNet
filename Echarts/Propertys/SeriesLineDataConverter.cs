using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class SeriesLineDataConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(SeriesLine_Data);
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var data = (SeriesLine_Data)value;

		var allOthersNull = data.Name == null &&
		                    data.GroupId == null &&
		                    data.ChildGroupId == null &&
		                    data.Symbol == null &&
		                    data.SymbolSize == null &&
		                    data.SymbolRotate == null &&
		                    data.SymbolKeepAspect == null &&
		                    data.SymbolOffset == null &&
		                    data.Label == null &&
		                    data.LabelLine == null &&
		                    data.ItemStyle == null &&
		                    data.Emphasis == null &&
		                    data.Blur == null &&
		                    data.Select == null &&
		                    data.Tooltip == null;

		if (allOthersNull && data.Value is { Count: 1 })
		{
			// 只有Value有值时，直接写出一个数值
			writer.WriteValue(data.Value[0]);
		}
		else
		{
			// 否则按对象正常序列化
			var jo = JObject.FromObject(data, serializer);
			jo.WriteTo(writer);
		}
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
		JsonSerializer serializer)
	{
		// 根据当前Token类型判断数据格式
		if (reader.TokenType == JsonToken.Integer || reader.TokenType == JsonToken.Float)
		{
			var a = StringOrNumber.FromObject(reader.Value);
			var ls = new List<StringOrNumber>
			{
				a
			};
			return new SeriesLine_Data { Value = ls };
		}

		if (reader.TokenType == JsonToken.StartObject)
		{
			// 对象情况，直接反序列化为 SeriesLine_Data
			var obj = JObject.Load(reader);
			return obj.ToObject<SeriesLine_Data>(serializer);
		}

		throw new JsonSerializationException("Unexpected token type when parsing SeriesLine_Data: " +
		                                     reader.TokenType);
	}
}