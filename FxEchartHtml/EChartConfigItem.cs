using Newtonsoft.Json;

namespace FxEchartHtml
{
	/// <summary>
	/// 表示 ECharts 配置项中的一个元素（属性），包含描述信息与界面控制配置信息。
	/// 该类通常用于对特定配置项的描述、文档说明以及可视化编辑控制。
	/// </summary>
	public class EChartConfigItem
	{
		/// <summary>
		/// 配置项的描述文本（HTML格式字符串）。
		/// 在界面上可用于显示该配置项的使用说明。
		/// </summary>
		[JsonProperty("desc")]
		public string Description { get; set; }

		/// <summary>
		/// 配置项的用户界面控制（UI Control）信息。
		/// 包含了编辑该项值时的一些交互和编辑限制，如控件类型、默认值、选项列表等。
		/// </summary>
		[JsonProperty("uiControl")]
		public UiControl UiControl { get; set; }
	}

	/// <summary>
	/// 表示配置项在界面上的控制信息，用于辅助前端编辑器或后端管理界面。
	/// 可用于指示编辑该项时使用的控件类型、默认值、数据约束和选项列表等信息。
	/// </summary>
	public class UiControl
	{
		/// <summary>
		/// 控件类型（UI类型），例如：textbox、percent、dropdown等。
		/// 用于前端界面选择合适的输入控件。
		/// </summary>
		[JsonProperty("type")]
		public string ControlType { get; set; }

		/// <summary>
		/// 控件的默认值，可在界面初始化时使用。
		/// </summary>
		[JsonProperty("default")]
		public string DefaultValue { get; set; }

		/// <summary>
		/// 清理操作的标识或命令，用于在界面上清理当前输入的值。
		/// </summary>
		[JsonProperty("clean")]
		public string Clean { get; set; }

		/// <summary>
		/// 控件允许的最小值，通常在数值类型控件中适用。
		/// 实际业务中可尝试将其转换为数值类型。
		/// </summary>
		[JsonProperty("min")]
		public string MinValue { get; set; }

		/// <summary>
		/// 控件的步长设置（如数值控件中每次增减的幅度）。
		/// 实际业务中可尝试将其转换为数值类型。
		/// </summary>
		[JsonProperty("step")]
		public string Step { get; set; }

		/// <summary>
		/// 可选项的列表字符串，可用于下拉框、单选框等控件。
		/// 实际可根据需求将其解析为数组或其他数据结构。
		/// </summary>
		[JsonProperty("options")]
		public string Options { get; set; }

		/// <summary>
		/// 维度信息，可用于描述控制项在多维数据下的行为或显示方式。
		/// 实际用途需根据业务需求定义。
		/// </summary>
		[JsonProperty("dims")]
		public string Dimensions { get; set; }

		/// <summary>
		/// 控件允许的最大值，通常在数值类型控件中适用。
		/// 实际业务中可尝试将其转换为数值类型。
		/// </summary>
		[JsonProperty("max")]
		public string MaxValue { get; set; }

		/// <summary>
		/// 分隔符信息，用于在控件中对用户输入进行分割（例如逗号,号）。
		/// </summary>
		[JsonProperty("separate")]
		public string Separate { get; set; }
	}
}
