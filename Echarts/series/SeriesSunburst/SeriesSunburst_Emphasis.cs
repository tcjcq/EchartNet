using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     高亮状态配置。
/// </summary>
public class SeriesSunburst_Emphasis
{
	/// <summary>
	///     从 v5.0.0 开始支持
	///     在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
	///     'none' 不淡出其它图形，默认使用该配置。
	///     'self' 只聚焦（不淡出）当前高亮的数据的图形。
	///     'series' 聚焦当前高亮的数据所在的系列的所有图形。
	///     'ancestor' 聚焦所有祖先节点。
	///     'descendant' 聚焦所有子孙节点。
	///     示例：
	///     下面代码配置了柱状图在高亮一个图形的时候，淡出当前直角坐标系所有其它的系列。
	///     emphasis: {
	///     focus: 'series',
	///     blurScope: 'coordinateSystem'
	///     }
	/// </summary>
	[JsonProperty("focus")]
	public string Focus { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
	///     'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
	///     'series' 淡出范围为系列。
	///     'global' 淡出范围为全局。
	/// </summary>
	[JsonProperty("blurScope")]
	public string BlurScope { get; set; }

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