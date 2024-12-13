using Newtonsoft.Json;

namespace FxEchartHtml
{
	public class Item
	{
		[JsonProperty("desc")]
		public string Description { get; set; } // 描述属性，避免与 C# 关键字冲突

		[JsonProperty("uiControl")]
		public UiControl UiControl { get; set; } // 用户界面控制项
	}
	public class UiControl
	{
		[JsonProperty("type")]
		public string ControlType { get; set; } // 控件类型，避免与 C# 关键字冲突

		[JsonProperty("default")]
		public string DefaultValue { get; set; } // 默认值

		[JsonProperty("clean")]
		public string Clean { get; set; } // 清理操作

		[JsonProperty("min")]
		public string MinValue { get; set; } // 最小值

		[JsonProperty("step")]
		public string Step { get; set; } // 步长

		[JsonProperty("options")]
		public string Options { get; set; } // 可选项

		[JsonProperty("dims")]
		public string Dimensions { get; set; } // 维度

		[JsonProperty("max")]
		public string MaxValue { get; set; } // 最大值

		[JsonProperty("separate")]
		public string Separate { get; set; } // 分隔符
	}
}