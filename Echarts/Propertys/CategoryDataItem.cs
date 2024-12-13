using Newtonsoft.Json;

namespace Echarts
{
	public class CategoryDataItem
	{
		[JsonProperty("value")] public string Value { get; set; }

		[JsonProperty("textStyle")] public TextStyle TextStyle { get; set; }

		// 构造函数重载
		public CategoryDataItem(string value)
		{
			Value = value;
		}

		// 隐式转换从 string
		public static implicit operator CategoryDataItem(string value)
		{
			return new CategoryDataItem(value);
		}
	}
}