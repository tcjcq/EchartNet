using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Echarts;

public class AxisDataConverter<T> : JsonConverter<T> where T : new()
{
	public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue,
		JsonSerializer serializer)
	{
		var obj = new T();

		// 处理字符串形式（如 "周一"）
		if (reader.TokenType == JsonToken.String)
		{
			SetPropertyByJsonName(obj, "value", ((string)reader.Value)!, serializer);
			return obj;
		}

		// 处理对象形式（如 { value: "周一", textStyle: { ... } }）
		if (reader.TokenType == JsonToken.StartObject)
		{
			var jObject = JObject.Load(reader);
			foreach (var jProperty in jObject.Properties())
				SetPropertyByJsonName(obj, jProperty.Name, jProperty.Value, serializer);
			return obj;
		}

		throw new JsonException($"无法将 {reader.TokenType} 反序列化为 {typeof(T).Name}");
	}

	public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
	{
		// 判断是否应序列化为简单字符串
		if (ShouldSerializeAsString(value))
		{
			var strValue = GetPropertyByJsonName(value, "value")?.ToString();
			writer.WriteValue(strValue);
		}
		else
		{
			writer.WriteStartObject();
			foreach (var prop in typeof(T).GetProperties())
			{
				var jsonName = GetJsonPropertyName(prop);
				var propValue = prop.GetValue(value);
				if (propValue == null) continue;

				writer.WritePropertyName(jsonName);
				serializer.Serialize(writer, propValue);
			}

			writer.WriteEndObject();
		}
	}

	/// <summary>
	///     动态设置属性（支持 JsonProperty 和大小写不敏感）
	/// </summary>
	private void SetPropertyByJsonName(T obj, string jsonName, JToken jValue, JsonSerializer serializer)
	{
		foreach (var prop in typeof(T).GetProperties())
		{
			var propJsonName = GetJsonPropertyName(prop);
			if (!string.Equals(propJsonName, jsonName, StringComparison.OrdinalIgnoreCase)) continue;

			// 处理特殊类型转换
			var value = jValue.Type switch
			{
				JTokenType.Object => jValue.ToObject(prop.PropertyType, serializer),
				JTokenType.Array  => jValue.ToObject(prop.PropertyType, serializer),
				_                 => Convert.ChangeType(jValue.ToString(), prop.PropertyType)
			};

			prop.SetValue(obj, value);
			return;
		}

		// 可改为静默忽略未知字段
		throw new JsonException($"在 {typeof(T).Name} 中找不到与 JSON 字段 '{jsonName}' 匹配的属性");
	}

	/// <summary>
	///     获取属性值（支持 JsonProperty）
	/// </summary>
	private object GetPropertyByJsonName(T value, string jsonName)
	{
		foreach (var prop in typeof(T).GetProperties())
		{
			var propJsonName = GetJsonPropertyName(prop);
			if (string.Equals(propJsonName, jsonName, StringComparison.OrdinalIgnoreCase))
				return prop.GetValue(value);
		}

		return null;
	}

	/// <summary>
	///     判断是否应序列化为简单字符串
	/// </summary>
	private bool ShouldSerializeAsString(T value)
	{
		var hasValue = GetPropertyByJsonName(value, "value") != null;
		var hasOtherProps = false;

		foreach (var prop in typeof(T).GetProperties())
		{
			var jsonName = GetJsonPropertyName(prop);
			if (jsonName == "value") continue;

			if (prop.GetValue(value) != null)
			{
				hasOtherProps = true;
				break;
			}
		}

		return hasValue && !hasOtherProps;
	}

	/// <summary>
	///     获取属性的 JSON 字段名（优先取 JsonProperty）
	/// </summary>
	private static string GetJsonPropertyName(PropertyInfo prop)
	{
		var jsonAttr = prop.GetCustomAttribute<JsonPropertyAttribute>();
		return jsonAttr?.PropertyName ?? prop.Name;
	}
}