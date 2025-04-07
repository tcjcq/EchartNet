using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     面包屑，能够显示当前节点的路径。
/// </summary>
public class SeriesTreemap_Breadcrumb
{
	/// <summary>
	///     是否显示面包屑。
	/// </summary>
	[JsonProperty("show")]
	public bool? Show { get; set; }

	/// <summary>
	///     面包屑组件离容器左侧的距离。
	///     left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
	///     如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
	/// </summary>
	[JsonProperty("left")]
	public StringOrNumber Left { get; set; }

	/// <summary>
	///     面包屑组件离容器上侧的距离。
	///     top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
	///     如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
	/// </summary>
	[JsonProperty("top")]
	public StringOrNumber Top { get; set; }

	/// <summary>
	///     面包屑组件离容器右侧的距离。
	///     right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
	///     默认自适应。
	/// </summary>
	[JsonProperty("right")]
	public StringOrNumber Right { get; set; }

	/// <summary>
	///     面包屑组件离容器下侧的距离。
	///     bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
	///     默认自适应。
	/// </summary>
	[JsonProperty("bottom")]
	public StringOrNumber Bottom { get; set; }

	/// <summary>
	///     面包屑的高度。
	/// </summary>
	[JsonProperty("height")]
	public double? Height { get; set; }

	/// <summary>
	///     当面包屑没有内容时候，设个最小宽度。
	/// </summary>
	[JsonProperty("emptyItemWidth")]
	public double? EmptyItemWidth { get; set; }

	/// <summary>
	///     图形样式。
	/// </summary>
	[JsonProperty("itemStyle")]
	public SeriesTreemap_Breadcrumb_ItemStyle ItemStyle { get; set; }

	/// <summary>
	///     从 v5.4.0 开始支持
	/// </summary>
	[JsonProperty("emphasis")]
	public SeriesTreemap_Breadcrumb_Emphasis Emphasis { get; set; }
}