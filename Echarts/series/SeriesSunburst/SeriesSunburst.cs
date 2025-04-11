using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     旭日图（Sunburst）由多层的环形图组成，在数据结构上，内圈是外圈的父节点。因此，它既能像饼图一样表现局部和整体的占比，又能像矩形树图一样表现层级关系。
///     示例：
///     数据下钻
///     旭日图默认支持数据下钻，也就是说，当用户点击了某个扇形块之后，将会以该节点作为根结点显示，并且在中间出现一个返回上层节点的圆。如果不希望有数据下钻功能，可以通过将 series-sunburst.nodeClick 设置为
///     false 实现。
/// </summary>
public class SeriesSunburst
{
	/// <summary>
	/// </summary>
	[JsonProperty("type")]
	public string Type { get; set; } = "sunburst";

	/// <summary>
	///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	///     系列名称，用于tooltip的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	///     所有图形的 zlevel 值。
	///     zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的
	///     Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
	///     zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
	/// </summary>
	[JsonProperty("zlevel")]
	public double? Zlevel { get; set; }

	/// <summary>
	///     组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
	///     z相比zlevel优先级更低，而且不会创建新的 Canvas。
	/// </summary>
	[JsonProperty("z")]
	public double? Z { get; set; }

	/// <summary>
	///     旭日图的中心（圆心）坐标，数组的第一项是横坐标，第二项是纵坐标。
	///     支持设置成百分比，设置成百分比时第一项是相对于容器宽度，第二项是相对于容器高度。
	///     使用示例：
	///     // 设置成绝对的像素值
	///     center: [400, 300]
	///     // 设置成相对的百分比
	///     center: ['50%', '50%']
	/// </summary>
	[JsonProperty("center")]
	public ArrayOrSingle Center { get; set; }

	/// <summary>
	///     旭日图的半径。可以为如下类型：
	///     number：直接指定外半径值。
	///     string：例如，'20%'，表示外半径为可视区尺寸（容器高宽中较小一项）的 20% 长度。
	///     Array.<number| string>：数组的第一项是内半径，第二项是外半径。每一项遵从上述 number string 的描述。
	/// </summary>
	[JsonProperty("radius")]
	public ArrayOrSingle Radius { get; set; }

	/// <summary>
	///     series-sunburst.data 的数据格式是树状的，例如：
	///     [{
	///     name: 'parent1',
	///     value: 10,          // 可以不写父元素的 value，则为子元素之和；
	///     // 如果写了，并且大于子元素之和，可以用来表示还有其他子元素未显示
	///     children: [{
	///     value: 5,
	///     name: 'child1',
	///     children: [{
	///     value: 2,
	///     name: 'grandchild1',
	///     itemStyle: {
	///     // 每个数据可以有自己的样式，覆盖 series.itemStyle 和 level.itemStyle
	///     },
	///     label: {
	///     // 标签样式，同上
	///     }
	///     }]
	///     }, {
	///     value: 3,
	///     name: 'child2'
	///     }],
	///     itemStyle: {
	///     // parent1 的图形样式，不会被后代继承
	///     },
	///     label: {
	///     // parent1 的标签样式，不会被后代继承
	///     }
	///     }, {
	///     name: 'parent2',
	///     value: 4
	///     }]
	/// </summary>
	[JsonProperty("data")]
	public SeriesSunburst_Data[] Data { get; set; }

	/// <summary>
	///     点击节点后的行为。可取值为：
	///     false：节点点击无反应。
	///     'rootToNode'：点击节点后以该节点为根结点。
	///     'link'：如果节点数据中有 link 点击节点后会进行超链接跳转。
	/// </summary>
	[JsonProperty("nodeClick")]
	public StringOrBool NodeClick { get; set; }

	/// <summary>
	///     扇形块根据数据 value 的排序方式，如果未指定 value，则其值为子元素 value 之和。默认值 'desc' 表示降序排序；还可以设置为 'asc' 表示升序排序；null
	///     表示不排序，使用原始数据的顺序；或者用回调函数进行排列：
	///     function(nodeA, nodeB) {
	///     return nodeA.getValue() - nodeB.getValue();
	///     }
	/// </summary>
	[JsonProperty("sort")]
	public string Sort { get; set; }

	/// <summary>
	///     如果数据没有 name，是否需要渲染文字。
	/// </summary>
	[JsonProperty("renderLabelForZeroData")]
	public bool? RenderLabelForZeroData { get; set; }

	/// <summary>
	///     旭日图的扇区是否是顺时针排布。
	/// </summary>
	[JsonProperty("clockwise")]
	public bool? Clockwise { get; set; }

	/// <summary>
	///     起始角度，支持范围[0, 360]。
	/// </summary>
	[JsonProperty("startAngle")]
	public double? StartAngle { get; set; }

	/// <summary>
	///     label 描述了每个扇形块中，文本标签的样式。
	///     优先级：series.data.label > series.levels.label > series.label。
	///     图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	[JsonProperty("label")]
	public Label9 Label { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的视觉引导线配置。
	/// </summary>
	[JsonProperty("labelLine")]
	public LabelLine1 LabelLine { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的统一布局配置。
	///     该配置项是在每个系列默认的标签布局基础上，统一调整标签的(x, y)位置，标签对齐等属性以实现想要的标签布局效果。
	///     该配置项也可以是一个有如下参数的回调函数
	///     // 标签对应数据的 dataIndex
	///     dataIndex: number
	///     // 标签对应的数据类型，只在关系图中会有 node 和 edge 数据类型的区分
	///     dataType?: string
	///     // 标签对应的系列的 index
	///     seriesIndex: number
	///     // 标签显示的文本
	///     text: string
	///     // 默认的标签的包围盒，由系列默认的标签布局决定
	///     labelRect: {x: number, y: number, width: number, height: number}
	///     // 默认的标签水平对齐
	///     align: 'left' | 'center' | 'right'
	///     // 默认的标签垂直对齐
	///     verticalAlign: 'top' | 'middle' | 'bottom'
	///     // 标签所对应的数据图形的包围盒，可用于定位标签位置
	///     rect: {x: number, y: number, width: number, height: number}
	///     // 默认引导线的位置，目前只有饼图(pie)和漏斗图(funnel)有默认标签位置
	///     // 如果没有该值则为 null
	///     labelLinePoints?: number[][]
	///     示例：
	///     将标签显示在图形右侧 10px 的位置，并且垂直居中：
	///     labelLayout(params) {
	///     return {
	///     x: params.rect.x + 10,
	///     y: params.rect.y + params.rect.height / 2,
	///     verticalAlign: 'middle',
	///     align: 'left'
	///     }
	///     }
	///     根据图形的包围盒尺寸决定文本尺寸
	///     labelLayout(params) {
	///     return {
	///     fontSize: Math.max(params.rect.width / 10, 5)
	///     };
	///     }
	/// </summary>
	[JsonProperty("labelLayout")]
	public LabelLayout0 LabelLayout { get; set; }

	/// <summary>
	///     旭日图扇形块的样式。
	///     可以在 series.itemStyle 定义所有扇形块的样式，也可以在 series.levels.itemStyle 定义每一层扇形块的样式，还可以在 series.data.itemStyle
	///     定义每个扇形块单独的样式，这三者的优先级从低到高。也就是说，如果定义了 series.data.itemStyle，将会覆盖 series.itemStyle 和 series.levels.itemStyle。
	///     优先级：series.data.itemStyle > series.levels.itemStyle > series.itemStyle。
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle6 ItemStyle { get; set; }

	/// <summary>
	///     高亮状态配置。
	/// </summary>
	[JsonProperty("emphasis")]
	public SeriesSunburst_Emphasis Emphasis { get; set; }

	/// <summary>
	///     淡出状态配置。开启 emphasis.focus 后有效。
	/// </summary>
	[JsonProperty("blur")]
	public Blur9 Blur { get; set; }

	/// <summary>
	///     选中状态配置。开启 selectedMode 后有效。
	/// </summary>
	[JsonProperty("select")]
	public Blur9 Select { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     选中模式的配置，表示是否支持多个选中，默认关闭，支持布尔值和字符串，字符串取值可选'single'，'multiple'，'series' 分别表示单选，多选以及选择整个系列。
	///     从 v5.3.0 开始支持 'series'。
	/// </summary>
	[JsonProperty("selectedMode")]
	public StringOrBool SelectedMode { get; set; }

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
	[JsonProperty("levels")]
	public SeriesSunburst_Levels[] Levels { get; set; }

	/// <summary>
	///     本系列特定的 tooltip 设定。
	/// </summary>
	[JsonProperty("tooltip")]
	public Tooltip1 Tooltip { get; set; }

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
	///     初始动画的时长，支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的初始动画效果：
	///     animationDuration: function (idx) {
	///     // 越往后的数据时长越大
	///     return idx * 100;
	///     }
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
	///     如下示例：
	///     animationDelay: function (idx) {
	///     // 越往后的数据延迟越大
	///     return idx * 100;
	///     }
	///     也可以看该示例
	/// </summary>
	[JsonProperty("animationDelay")]
	public StringOrNumber AnimationDelay { get; set; }

	/// <summary>
	///     数据更新动画的时长。
	///     支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的更新动画效果：
	///     animationDurationUpdate: function (idx) {
	///     // 越往后的数据时长越大
	///     return idx * 100;
	///     }
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
	///     如下示例：
	///     animationDelayUpdate: function (idx) {
	///     // 越往后的数据延迟越大
	///     return idx * 100;
	///     }
	///     也可以看该示例
	/// </summary>
	[JsonProperty("animationDelayUpdate")]
	public StringOrNumber AnimationDelayUpdate { get; set; }
}