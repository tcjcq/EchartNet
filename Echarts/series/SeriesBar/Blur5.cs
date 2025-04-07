using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
///     单个数据的淡出状态配置。
/// </summary>
public class Blur5
{
	/// <summary>
	///     单个数据的文本配置。
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
	///     单个数据的图形样式设置。
	/// </summary>
	[JsonProperty("itemStyle")]
	public SeriesBar_BackgroundStyle ItemStyle { get; set; }
}