using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     淡出状态配置。开启 emphasis.focus 后有效。
/// </summary>
public class Blur9
{
	/// <summary>
	///     label 描述了每个扇形块中，文本标签的样式。
	///     优先级：series.data.label > series.levels.label > series.label。
	///     图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	[JsonProperty("label")]
	public Label10 Label { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的视觉引导线配置。
	/// </summary>
	[JsonProperty("labelLine")]
	public XAxis_MinorSplitLine LabelLine { get; set; }

	/// <summary>
	///     旭日图扇形块的样式。
	///     可以在 series.itemStyle 定义所有扇形块的样式，也可以在 series.levels.itemStyle 定义每一层扇形块的样式，还可以在 series.data.itemStyle
	///     定义每个扇形块单独的样式，这三者的优先级从低到高。也就是说，如果定义了 series.data.itemStyle，将会覆盖 series.itemStyle 和 series.levels.itemStyle。
	///     优先级：series.data.itemStyle > series.levels.itemStyle > series.itemStyle。
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle5 ItemStyle { get; set; }
}