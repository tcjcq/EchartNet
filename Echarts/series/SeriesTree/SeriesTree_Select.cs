using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
///     选中状态的相关配置。开启 selectedMode 后有效。
/// </summary>
public class SeriesTree_Select
{
	/// <summary>
	///     从 v5.3.0 开始支持
	///     是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
	/// </summary>
	[JsonProperty("disabled")]
	public bool? Disabled { get; set; }

	/// <summary>
	///     该节点的样式。
	/// </summary>
	[JsonProperty("itemStyle")]
	public HandleStyle0 ItemStyle { get; set; }

	/// <summary>
	///     定义树图边的样式。
	/// </summary>
	[JsonProperty("lineStyle")]
	public LineStyle4 LineStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label1 Label { get; set; }
}