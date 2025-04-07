using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
///     单个数据的淡出图形和标签样式。
/// </summary>
public class Blur6
{
	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label5 Label { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的视觉引导线配置。
	/// </summary>
	[JsonProperty("labelLine")]
	public XAxis_MinorSplitLine LabelLine { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public HandleStyle0 ItemStyle { get; set; }
}