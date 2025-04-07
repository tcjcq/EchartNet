using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     高亮状态的图形样式。
/// </summary>
public class SeriesGraph_Emphasis
{
	/// <summary>
	///     从 v5.3.0 开始支持
	///     是否关闭高亮状态。
	///     关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
	/// </summary>
	[JsonProperty("disabled")]
	public bool? Disabled { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     是否开启高亮后节点的放大效果。从 5.3.2 版本开始支持 number，用以设置高亮放大倍数，默认放大 1.1 倍。
	/// </summary>
	[JsonProperty("scale")]
	public NumberOrBool Scale { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
	///     'none' 不淡出其它图形，默认使用该配置。
	///     'self' 只聚焦（不淡出）当前高亮的数据的图形。
	///     'series' 聚焦当前高亮的数据所在的系列的所有图形。
	///     'adjacency' 聚焦关系图中的邻接点和边的图形。
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
	/// </summary>
	[JsonProperty("itemStyle")]
	public HandleStyle0 ItemStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("lineStyle")]
	public LineStyle3 LineStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label1 Label { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("edgeLabel")]
	public Label12 EdgeLabel { get; set; }
}