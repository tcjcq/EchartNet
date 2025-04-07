using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     多层配置
///     旭日图是一种有层次的结构，为了方便同一层样式的配置，我们提供了 levels 配置项。它是一个数组，其中的第 0 项表示数据下钻后返回上级的图形，其后的每一项分别表示从圆心向外层的层级。
///     例如，假设我们没有数据下钻功能，并且希望将最内层的扇形块的颜色设为红色，文字设为蓝色，可以这样设置：
///     series: {
///     // ...
///     levels: [
///     {
///     // 留给数据下钻点的空白配置
///     },
///     {
///     // 最靠内测的第一层
///     itemStyle: {
///     color: 'red'
///     },
///     label: {
///     color: 'blue'
///     }
///     },
///     {
///     // 第二层 ...
///     }
///     ]
///     }
/// </summary>
public class SeriesSunburst_Levels
{
	/// <summary>
	///     从 v5.2.0 开始支持
	///     当前层的内半径和外半径，注意其它层的内外半径不会因为该层的改变自适应。
	/// </summary>
	[JsonProperty("radius")]
	public double[] Radius { get; set; }

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

	/// <summary>
	///     高亮状态配置。
	/// </summary>
	[JsonProperty("emphasis")]
	public Blur9 Emphasis { get; set; }

	/// <summary>
	///     淡出状态配置。
	/// </summary>
	[JsonProperty("blur")]
	public Blur9 Blur { get; set; }

	/// <summary>
	///     选中状态配置。
	/// </summary>
	[JsonProperty("select")]
	public Blur9 Select { get; set; }
}