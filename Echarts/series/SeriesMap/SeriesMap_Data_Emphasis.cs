using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     该数据所在区域的多边形高亮状态
/// </summary>
public class SeriesMap_Data_Emphasis
{
	/// <summary>
	///     从 v5.3.0 开始支持
	///     是否关闭高亮状态。
	///     关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
	/// </summary>
	[JsonProperty("disabled")]
	public bool? Disabled { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle1 ItemStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label11 Label { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的视觉引导线配置。
	/// </summary>
	[JsonProperty("labelLine")]
	public XAxis_MinorSplitLine LabelLine { get; set; }
}