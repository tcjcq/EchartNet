using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts;

public class EChartOption
{
	/// <summary>
	///     是否开启动画。
	/// </summary>
	[JsonProperty("animation")]
	public bool? Animation { get; set; }

	/// <summary>
	///     是否开启动画的阈值，当单个系列显示的图形数量大于这个阈值时会关闭动画。
	/// </summary>
	[JsonProperty("animationThreshold")]
	public double? AnimationThreshold { get; set; }

	/// <summary>
	///     初始动画的时长，支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的初始动画效果。
	/// </summary>
	[JsonProperty("animationDuration")]
	public StringOrNumber AnimationDuration { get; set; }

	/// <summary>
	///     初始动画的缓动效果。不同的缓动效果可以参考 缓动示例。
	/// </summary>
	[JsonProperty("animationEasing")]
	public string AnimationEasing { get; set; }

	/// <summary>
	///     初始动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的初始动画效果。
	/// </summary>
	[JsonProperty("animationDelay")]
	public StringOrNumber AnimationDelay { get; set; }

	/// <summary>
	///     数据更新动画的时长。
	/// </summary>
	[JsonProperty("animationDurationUpdate")]
	public StringOrNumber AnimationDurationUpdate { get; set; }

	/// <summary>
	///     数据更新动画的缓动效果。
	/// </summary>
	[JsonProperty("animationEasingUpdate")]
	public string AnimationEasingUpdate { get; set; }

	/// <summary>
	///     数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
	/// </summary>
	[JsonProperty("animationDelayUpdate")]
	public StringOrNumber AnimationDelayUpdate { get; set; }

	/// <summary>
	///     状态切换的动画配置，支持在每个系列里设置单独针对该系列的配置。
	/// </summary>
	[JsonProperty("stateAnimation")]
	public StateAnimation StateAnimation { get; set; }


	/// <summary>
	///     标题组件，包含主标题和副标题。
	///     在 ECharts 2.x 中单个 ECharts 实例最多只能拥有一个标题组件。
	///     但是在 ECharts 3 中可以存在任意多个标题组件，这在需要标题进行排版，或者单个实例中的多个图表都需要标题时会比较有用。
	/// </summary>
	[JsonProperty("title")]
	[JsonConverter(typeof(SingleOrArrayConverter<Title>))]

	public List<Title> Title { get; set; }

	/// <summary>
	///     W3C 制定了无障碍富互联网应用规范集（WAI-ARIA，the Accessible Rich Internet Applications Suite），
	///     致力于使得网页内容和网页应用能够被更多残障人士访问。Apache ECharts 4 遵从这一规范，
	///     支持自动根据图表配置项智能生成描述，使得盲人可以在朗读设备的帮助下了解图表内容，
	///     让图表可以被更多人群访问。
	///     除此之外，Apache ECharts 5 新增支持贴花纹理，作为颜色的辅助表达，进一步用以区分数据。
	///     默认关闭，需要通过将 aria.enabled 设置为 true 开启。
	/// </summary>
	[JsonProperty("aria")]
	public Aria Aria { get; set; }

	/// <summary>
	///     调色盘颜色列表。如果系列没有设置颜色，则会依次循环从该列表中取颜色作为系列颜色。 默认为：
	///     ['#5470c6', '#91cc75', '#fac858', '#ee6666', '#73c0de', '#3ba272', '#fc8452', '#9a60b4', '#ea7ccc']
	/// </summary>
	[JsonProperty("color")]
	[JsonConverter(typeof(SingleOrArrayConverter<Color>))]
	public List<Color> Color { get; set; }

	/// <summary>
	///     背景色，默认无背景。
	///     支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，
	///     也支持设置为渐变色和纹理填充，具体见option.color
	/// </summary>
	[JsonProperty("backgroundColor")]
	public Color BackgroundColor { get; set; }

	/// <summary>
	///     各种图表数据
	/// </summary>
	[JsonProperty("series")]
	[JsonConverter(typeof(SeriesListConverter))]
	public List<object> Series { get; set; }

	/// <summary>
	///     图例组件。
	///     图例组件展现了不同系列的标记(symbol)，颜色和名字。可以通过点击图例控制哪些系列不显示。
	///     ECharts 3 中单个 echarts 实例中可以存在多个图例组件，会方便多个图例的布局。
	///     当图例数量过多时，可以使用 滚动图例（垂直） 或 滚动图例（水平），参见：legend.type
	/// </summary>
	[JsonProperty("legend")]
	[JsonConverter(typeof(SingleOrArrayConverter<Legend>))]
	public List<Legend> Legend { get; set; }

	/// <summary>
	///     提示框组件。
	/// </summary>
	[JsonProperty("tooltip")]
	public Tooltip Tooltip { get; set; }

	/// <summary>
	///     直角坐标系 grid 中的 x 轴，一般情况下单个 grid 组件最多只能放上下两个 x 轴，
	///     多于两个 x 轴需要通过配置 offset 属性防止同个位置多个 x 轴的重叠。
	/// </summary>
	[JsonProperty("xAxis")]
	[JsonConverter(typeof(SingleOrArrayConverter<XAxis>))]
	public List<XAxis> XAxis { get; set; }

	/// <summary>
	///     直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，
	///     多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
	/// </summary>
	[JsonProperty("yAxis")]
	[JsonConverter(typeof(SingleOrArrayConverter<YAxis>))]
	public List<YAxis> YAxis { get; set; }

	/// <summary>
	///     visualMap 是视觉映射组件，用于进行『视觉编码』，也就是将数据映射到视觉元素（视觉通道）。
	/// </summary>
	[JsonProperty("visualMap")]
	[JsonConverter(typeof(VisualMapConverter))]
	public List<object> VisualMap { get; set; }

	/// <summary>
	///     dataZoom 组件 用于区域缩放，从而能自由关注细节的数据信息，或者概览数据整体，或者去除离群点的影响。
	/// </summary>
	[JsonProperty("dataZoom")]
	public List<object> DataZoom { get; set; }

	/// <summary>
	///     这是坐标轴指示器（axisPointer）的全局公用设置。
	/// </summary>
	[JsonProperty("axisPointer")]
	public AxisPointer AxisPointer { get; set; }

	/// <summary>
	///     工具栏。内置有导出图片，数据视图，动态类型切换，数据区域缩放，重置五个工具。
	/// </summary>
	[JsonProperty("toolbox")]
	public Toolbox ToolBox { get; set; }

	/// <summary>
	///     brush 是区域选择组件，用户可以选择图中一部分数据，
	///     从而便于向用户展示被选中数据，或者他们的一些统计计算结果。
	/// </summary>
	[JsonProperty("brush")]
	public Brush Brush { get; set; }

	[JsonProperty("geo")] public Geo Geo { get; set; }

	/// <summary>
	///     平行坐标系（Parallel Coordinates） 是一种常用的可视化高维数据的图表。
	/// </summary>
	[JsonProperty("parallel")]
	public Parallel Parallel { get; set; }

	/// <summary>
	///     这个组件是平行坐标系中的坐标轴。
	/// </summary>
	[JsonProperty("parallelAxis")]
	public ParallelAxis ParallelAxis { get; set; }

	/// <summary>
	///     单轴。可以被应用到散点图中展现一维数据
	/// </summary>
	[JsonProperty("singleAxis")]
	public SingleAxis SingleAxis { get; set; }

	/// <summary>
	///     提供了在多个 ECharts option 间进行切换、播放等操作的功能。
	/// </summary>
	[JsonProperty("timeline")]
	public Timeline TimeLine { get; set; }

	/// <summary>
	///     graphic 是原生图形元素组件。可以支持的图形元素包括：
	///     image, text, circle, sector, ring, polygon, poly line, rect, line, bezierCurve, arc, group,
	/// </summary>
	[JsonProperty("graphic")]
	public Graphic[] Graphic { get; set; }

	/// <summary>
	///     日历坐标系组件
	/// </summary>
	[JsonProperty("calendar")]
	public Calendar Calendar { get; set; }

	/// <summary>
	///     用于单独的数据集声明，从而数据可以单独管理，被多个组件复用，并且可以自由指定数据到视觉的映射。这在不少场景下能带来使用上的方便。
	///     关于 dataset 的详情，请参见教程。
	/// </summary>
	[JsonProperty("dataset")]
	public Dataset DataSet { get; set; }

	/// <summary>
	///     用于 timeline 的 option 数组。数组的每一项是一个 echarts option (ECUnitOption)。
	/// </summary>
	[JsonProperty("options")]
	public object Options { get; set; }

	/// <summary>
	///     直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。
	///     可以在网格上绘制折线图，柱状图，散点图（气泡图）。
	///     在 ECharts 2.x 里单个 echarts 实例中最多只能存在一个 grid 组件，在 ECharts 3 中可以存在任意个 grid 组件。
	/// </summary>
	[JsonProperty("grid")]
	[JsonConverter(typeof(SingleOrArrayConverter<Grid>))]

	public List<Grid> Grid { get; set; }

	/// <summary>
	///     全局的字体样式。
	/// </summary>
	[JsonProperty("textStyle")]
	public TextStyle TextStyle { get; set; }

	/// <summary>
	///     图形的混合模式， 不同的混合模式见
	///     https://developer.mozilla.org/zh-CN/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation 。
	///     默认为 'source-over'。 支持每个系列单独设置。
	///     'lighter' 也是比较常见的一种混合模式，该模式下图形数量集中的区域会颜色叠加成高亮度的颜色（白色）。
	///     常常能达到突出该区域的效果。见示例 全球飞行航线
	/// </summary>
	[JsonProperty("blendMode")]
	public string BlendMode { get; set; }

	/// <summary>
	///     图形数量阈值，决定是否开启单独的 hover 层，在整个图表的图形数量大于该阈值时开启单独的 hover 层。
	///     单独的 hover 层主要是为了在高亮图形的时候不需要重绘整个图表，
	///     只需要把高亮的图形放入单独的一个 canvas 层进行绘制，
	///     防止在图形数量很多的时候因为高亮重绘所有图形导致卡顿。
	///     ECharts 2 里是底层强制使用单独的层绘制高亮图形，但是会带来很多问题，
	///     比如高亮的图形可能会不正确地遮挡所有其它图形，
	///     还有图形有透明度因为高亮和正常图形叠加导致不正确的透明度显示，
	///     还有移动端上因为每个图表都要多一个 canvas 带来的额外内存开销。
	///     因此 3 里默认不会开启该优化，只有在图形数量特别多，有必要做该优化时才会自动开启。
	/// </summary>
	[JsonProperty("hoverLayerThreshold")]
	public int? HoverLayerThreshold { get; set; }

	/// <summary>
	///     是否使用 UTC 时间。
	///     true: 表示 axis.type 为 'time' 时，
	///     依据 UTC 时间确定 tick 位置，并且 axisLabel 和 tooltip 默认展示的是 UTC 时间。
	///     false: 表示 axis.type 为 'time' 时，依据本地时间确定 tick 位置，并且 axisLabel 和 tooltip 默认展示的是本地时间。
	///     默认取值为false，即使用本地时间。因为考虑到：
	///     很多情况下，需要展示为本地时间（无论服务器存储的是否为 UTC 时间）
	///     如果 data 中的时间为 '2012-01-02' 这样的没有指定时区的时间表达式，往往意为本地时间。
	///     默认情况下，时间被展示时需要和输入一致而非有时差。
	///     注意，这个参数实际影响的是『展示』，而非用户输入的时间值的解析。
	///     关于用户输入的时间值（例如 1491339540396, '2013-01-04' 等）的解析，参见 date 中时间相关部分。
	/// </summary>
	[JsonProperty("useUTC")]
	public bool? UseUtc { get; set; }

	/// <summary>
	///     是否是暗黑模式，默认会根据背景色 backgroundColor 的亮度自动设置。
	///     如果是设置了容器的背景色而无法判断到，就可以使用该配置手动指定，
	///     echarts 会根据是否是暗黑模式调整文本等的颜色。该配置通常会被用于主题中。
	/// </summary>
	[JsonProperty("darkMode")]
	public bool? DarkMode { get; set; }

	/// <summary>
	///     请参见 移动端自适应。
	/// </summary>
	[JsonProperty("media")]
	public Media[] Media { get; set; }
}