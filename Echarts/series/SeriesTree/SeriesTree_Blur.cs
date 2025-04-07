using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
///     淡出状态的相关配置。开启 emphasis.focus 后有效。
/// </summary>
public class SeriesTree_Blur
{
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