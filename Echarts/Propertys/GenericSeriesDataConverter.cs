using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class GenericSeriesDataConverter<T> : JsonConverter<T> where T : new()
{
	private const string ValuePropertyName = "value";

	public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue,
		JsonSerializer serializer)
	{
		var obj = new T();
		var properties = typeof(T).GetProperties();

		switch (reader.TokenType)
		{
			// 处理数值形式（如 12）
			case JsonToken.Float:
			case JsonToken.Integer:
			case JsonToken.String:
				SetPropertyValue(obj, ValuePropertyName,
					reader.TokenType != JsonToken.String ? Convert.ToDouble(reader.Value) : reader.Value.ToString());
				return obj;
			// 处理对象形式（如 { value: 56, name: "特殊点", ... }）
			case JsonToken.StartObject:
			{
				var jObject = JObject.Load(reader);
				foreach (var prop in properties)
				{
					var jsonProp = prop.GetCustomAttribute<JsonPropertyAttribute>();
					if (jsonProp == null || !jObject.TryGetValue(jsonProp.PropertyName, out var token))
						continue;

					var value = token.Type == JTokenType.Null ? null : token.ToObject(prop.PropertyType, serializer);
					prop.SetValue(obj, value);
				}

				return obj;
			}
		}

		// 处理数组形式
		if (reader.TokenType != JsonToken.StartArray) return obj;
		var jArray = JArray.Load(reader);
		var data = new List<T>();

		foreach (var token in jArray)
		{
			using var subReader = token.CreateReader();
			var item = (T)serializer.Deserialize(subReader, typeof(T));
			data.Add(item);
		}

		// 将数据列表赋值给对象的 "data" 属性
		SetPropertyValue(obj, "data", data);

		return obj;
	}

	public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
	{
		if (value == null)
		{
			writer.WriteNull();
			return;
		}

		// 检查是否应序列化为简单数值（仅 value 有值，其他属性为默认）
		if (ShouldSerializeAsValue(value))
		{
			var valueProp = GetProperty(ValuePropertyName);
			writer.WriteValue(valueProp.GetValue(value));
		}
		// 否则序列化为完整对象
		else
		{
			writer.WriteStartObject();
			foreach (var prop in typeof(T).GetProperties())
			{
				var jsonProp = prop.GetCustomAttribute<JsonPropertyAttribute>();
				if (jsonProp?.PropertyName == null) continue;
				var propValue = prop.GetValue(value);
				if (propValue == null) continue;
				writer.WritePropertyName(jsonProp.PropertyName);
				serializer.Serialize(writer, propValue);
			}

			writer.WriteEndObject();
		}
	}

	// 动态设置属性值
	private void SetPropertyValue(T obj, string jsonPropName, object value)
	{
		// 遍历所有属性，优先匹配 [JsonProperty] 的名称
		foreach (var prop in typeof(T).GetProperties())
		{
			// 1. 检查是否存在 [JsonProperty("xxx")] 且名称匹配
			var jsonAttr = prop.GetCustomAttribute<JsonPropertyAttribute>();
			if (jsonAttr != null && jsonAttr.PropertyName == jsonPropName)
			{
				if (prop.PropertyType == typeof(StringOrNumber))
				{
					if (value is List<StringOrNumber> list)
					{
						// 处理 List<StringOrNumber> 的情况
						prop.SetValue(obj, list);
						return;
					}

					// 将值转换为 StringOrNumber
					var v1 = StringOrNumber.FromObject(value);
					prop.SetValue(obj, v1);
					return;
				}

				prop.SetValue(obj, value);
				return;
			}

			// 2. 无 [JsonProperty] 时，按属性名忽略大小写匹配
			if (!string.Equals(prop.Name, jsonPropName, StringComparison.OrdinalIgnoreCase)) continue;
			prop.SetValue(obj, value);
			return;
		}

		// 未找到对应属性时抛出明确异常（或静默忽略）
		//throw new JsonException($"未找到与 JSON 属性 '{jsonPropName}' 匹配的 {typeof(T).Name} 类型属性");
	}

	// 获取指定属性
	private PropertyInfo GetProperty(string name)
	{
		return typeof(T).GetProperty(name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
	}

	// 判断是否应序列化为简单数值
	private bool ShouldSerializeAsValue(T value)
	{
		var allProps = typeof(T).GetProperties();
		var valueProp = GetProperty(ValuePropertyName);
		var valuePropValue = valueProp?.GetValue(value);

		// 检查所有非 value 属性是否为默认值
		return allProps.All(prop =>
		{
			if (prop == valueProp) return true; // 跳过 value 属性
			var propValue = prop.GetValue(value);
			return propValue == null || Equals(propValue, GetDefault(prop.PropertyType));
		}) && valuePropValue != null;
	}

	// 获取类型的默认值
	private static object GetDefault(Type type)
	{
		return type.IsValueType ? Activator.CreateInstance(type) : null;
	}
}