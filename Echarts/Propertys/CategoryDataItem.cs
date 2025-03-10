using Newtonsoft.Json;

namespace Echarts;

public class CategoryDataItem(string value)
{
	[JsonProperty("value")] public string Value { get; set; } = value;

	[JsonProperty("textStyle")] public TextStyle TextStyle { get; set; }

	// 隐式转换从 string
	public static implicit operator CategoryDataItem(string value)
	{
		return new CategoryDataItem(value);
	}
}