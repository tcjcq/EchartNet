using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 桑基图 
	/// 是一种特殊的流图（可以看作是有向无环图）。 它主要用来表示原材料、能量等如何从最初形式经过中间过程的加工或转化达到最终状态。
	/// 示例：
	/// 
	/// 
	/// 
	/// 
	/// 可视编码：
	/// 桑基图将原数据中的每个node编码成一个小矩形，不同的节点尽量用不同的颜色展示，小矩形旁边的label编码的是节点的名称。
	/// 此外，图中每两个小矩形之间的边编码的是原数据中的link，边的粗细编码的是link中的value。
	/// 
	/// 排序：
	/// 如果想指定每层节点的顺序是按照 data 中的顺序排列的。可以设置 layoutIterations 为 0。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesSankey
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "sankey";

		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 系列名称，用于tooltip的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// z相比zlevel优先级更低，而且不会创建新的 Canvas。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// sankey组件离容器左侧的距离。
		/// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		/// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// sankey组件离容器上侧的距离。
		/// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		/// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// sankey组件离容器右侧的距离。
		/// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// sankey组件离容器下侧的距离。
		/// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// sankey组件的宽度。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		/// sankey组件的高度。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }

		/// <summary>
		/// 桑基图中每个矩形节点的宽度。
		/// </summary>
		[JsonProperty("nodeWidth")]
		public double? NodeWidth { get; set; }

		/// <summary>
		/// 桑基图中每一列任意两个矩形节点之间的间隔。
		/// </summary>
		[JsonProperty("nodeGap")]
		public double? NodeGap { get; set; }

		/// <summary>
		/// 桑基图中节点的对齐方式，默认是双端对齐，可以设置为左对齐或右对齐，对应的值分别是：
		/// 
		/// justify: 节点双端对齐。
		/// left: 节点左对齐。
		/// right: 节点右对齐。
		/// </summary>
		[JsonProperty("nodeAlign")]
		public string NodeAlign { get; set; }

		/// <summary>
		/// 布局的迭代次数，目的是不断迭代优化图中节点和边的位置，以减少节点和边之间的相互遮盖，默认值是 32。如果希望图中节点的顺序是按照原始 data 中的顺序排列的，可设该值为 0。
		/// </summary>
		[JsonProperty("layoutIterations")]
		public double? LayoutIterations { get; set; }

		/// <summary>
		/// 桑基图中节点的布局方向，可以是水平的从左往右，也可以是垂直的从上往下，对应的参数值分别是 horizontal, vertical。
		/// </summary>
		[JsonProperty("orient")]
		public string Orient { get; set; }

		/// <summary>
		/// 控制节点拖拽的交互，默认开启。开启后，用户可以将图中任意节点拖拽到任意位置。若想关闭此交互，只需将值设为 false 就行了。
		/// </summary>
		[JsonProperty("draggable")]
		public bool? Draggable { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 桑基图每一层的设置。可以逐层设置，如下：
		/// levels: [{
		///     depth: 0,
		///     itemStyle: {
		///         color: '#fbb4ae'
		///     },
		///     lineStyle: {
		///         color: 'source',
		///         opacity: 0.6
		///     }
		/// }, {
		///     depth: 1,
		///     itemStyle: {
		///         color: '#b3cde3'
		///     },
		///     lineStyle: {
		///         color: 'source',
		///         opacity: 0.6
		///     }
		/// }]
		/// 
		/// 也可以只设置某一层：
		/// levels: [{
		///     depth: 3,
		///     itemStyle: {
		///         color: '#fbb4ae'
		///     },
		///     lineStyle: {
		///         color: 'source',
		///         opacity: 0.6
		///     }
		/// }]
		/// </summary>
		[JsonProperty("levels")]
		public SeriesSankey_Levels[] Levels { get; set; }

		/// <summary>
		/// label 描述了每个矩形节点中文本标签的样式。
		/// </summary>
		[JsonProperty("label")]
		public Label6 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的统一布局配置。
		/// 该配置项是在每个系列默认的标签布局基础上，统一调整标签的(x, y)位置，标签对齐等属性以实现想要的标签布局效果。
		/// 该配置项也可以是一个有如下参数的回调函数
		/// // 标签对应数据的 dataIndex
		/// dataIndex: number
		/// // 标签对应的数据类型，只在关系图中会有 node 和 edge 数据类型的区分
		/// dataType?: string
		/// // 标签对应的系列的 index
		/// seriesIndex: number
		/// // 标签显示的文本
		/// text: string
		/// // 默认的标签的包围盒，由系列默认的标签布局决定
		/// labelRect: {x: number, y: number, width: number, height: number}
		/// // 默认的标签水平对齐
		/// align: 'left' | 'center' | 'right'
		/// // 默认的标签垂直对齐
		/// verticalAlign: 'top' | 'middle' | 'bottom'
		/// // 标签所对应的数据图形的包围盒，可用于定位标签位置
		/// rect: {x: number, y: number, width: number, height: number}
		/// // 默认引导线的位置，目前只有饼图(pie)和漏斗图(funnel)有默认标签位置
		/// // 如果没有该值则为 null
		/// labelLinePoints?: number[][]
		/// 
		/// 示例：
		/// 将标签显示在图形右侧 10px 的位置，并且垂直居中：
		/// labelLayout(params) {
		///     return {
		///         x: params.rect.x + 10,
		///         y: params.rect.y + params.rect.height / 2,
		///         verticalAlign: 'middle',
		///         align: 'left'
		///     }
		/// }
		/// 
		/// 根据图形的包围盒尺寸决定文本尺寸
		/// 
		/// labelLayout(params) {
		///     return {
		///         fontSize: Math.max(params.rect.width / 10, 5)
		///     };
		/// }
		/// </summary>
		[JsonProperty("labelLayout")]
		public LabelLayout0 LabelLayout { get; set; }

		/// <summary>
		/// 桑基图节点矩形的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle11 ItemStyle { get; set; }

		/// <summary>
		/// 桑基图边的样式
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }

		/// <summary>
		/// 桑基图的高亮状态。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesSankey_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 桑基图的淡出状态。开启 emphasis.focus 后有效。
		/// </summary>
		[JsonProperty("blur")]
		public SeriesSankey_Blur Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 桑基图的选中状态。开启 selectedMode 后有效。
		/// </summary>
		[JsonProperty("select")]
		public SeriesSankey_Select Select { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 选中模式的配置，表示是否支持多个选中，默认关闭，支持布尔值和字符串，字符串取值可选'single'，'multiple'，'series' 分别表示单选，多选以及选择整个系列。
		/// 
		/// 从 v5.3.0 开始支持 'series'。
		/// </summary>
		[JsonProperty("selectedMode")]
		public StringOrBool SelectedMode { get; set; }

		/// <summary>
		/// 桑基图节点数据列表。
		/// data: [{
		///     name: 'node1',
		///     // This attribute decides the layer of the current node.
		///     depth: 0
		/// }, {
		///     name: 'node2',
		///     depth: 1
		/// }]
		/// 
		/// 注意: 节点的name不能重复。
		/// </summary>
		[JsonProperty("data")]
		public SeriesSankey_Data[] Data { get; set; }

		/// <summary>
		/// 同 data
		/// </summary>
		[JsonProperty("nodes")]
		public double[] Nodes { get; set; }

		/// <summary>
		/// 节点间的边。注意: 桑基图理论上只支持有向无环图（DAG, Directed Acyclic Graph），所以请确保输入的边是无环的. 示例：
		/// links: [{
		///     source: 'n1',
		///     target: 'n2'
		/// }, {
		///     source: 'n2',
		///     target: 'n3'
		/// }]
		/// </summary>
		[JsonProperty("links")]
		public SeriesSankey_Links[] Links { get; set; }

		/// <summary>
		/// 同 links
		/// </summary>
		[JsonProperty("edges")]
		public double[] Edges { get; set; }

		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 是否开启动画。
		/// </summary>
		[JsonProperty("animation")]
		public bool? Animation { get; set; }

		/// <summary>
		/// 是否开启动画的阈值，当单个系列显示的图形数量大于这个阈值时会关闭动画。
		/// </summary>
		[JsonProperty("animationThreshold")]
		public double? AnimationThreshold { get; set; }

		/// <summary>
		/// 初始动画的时长，支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的初始动画效果：
		/// animationDuration: function (idx) {
		///     // 越往后的数据时长越大
		///     return idx * 100;
		/// }
		/// </summary>
		[JsonProperty("animationDuration")]
		public StringOrNumber AnimationDuration { get; set; }

		/// <summary>
		/// 初始动画的缓动效果。不同的缓动效果可以参考 缓动示例。
		/// </summary>
		[JsonProperty("animationEasing")]
		public string AnimationEasing { get; set; }

		/// <summary>
		/// 初始动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的初始动画效果。
		/// 如下示例：
		/// animationDelay: function (idx) {
		///     // 越往后的数据延迟越大
		///     return idx * 100;
		/// }
		/// 
		/// 也可以看该示例
		/// </summary>
		[JsonProperty("animationDelay")]
		public StringOrNumber AnimationDelay { get; set; }

		/// <summary>
		/// 数据更新动画的时长。
		/// 支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的更新动画效果：
		/// animationDurationUpdate: function (idx) {
		///     // 越往后的数据时长越大
		///     return idx * 100;
		/// }
		/// </summary>
		[JsonProperty("animationDurationUpdate")]
		public StringOrNumber AnimationDurationUpdate { get; set; }

		/// <summary>
		/// 数据更新动画的缓动效果。
		/// </summary>
		[JsonProperty("animationEasingUpdate")]
		public string AnimationEasingUpdate { get; set; }

		/// <summary>
		/// 数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
		/// 如下示例：
		/// animationDelayUpdate: function (idx) {
		///     // 越往后的数据延迟越大
		///     return idx * 100;
		/// }
		/// 
		/// 也可以看该示例
		/// </summary>
		[JsonProperty("animationDelayUpdate")]
		public StringOrNumber AnimationDelayUpdate { get; set; }

		/// <summary>
		/// 本系列特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// 从 v5.4.1 开始支持
	/// 
	/// 关系边文本标签的样式。
	/// </summary>
	public class EdgeLabel1
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 距离图形元素的距离。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 标签旋转。从 -90 度到 90 度。正值是逆时针。
		/// 参见：label rotation。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 是否对文字进行偏移。默认不偏移。例如：[30, 40] 表示文字在横向上偏移 30，纵向上偏移 40。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		/// 字符串模板
		/// 字符串模板
		/// 模板变量有：
		/// 
		/// {a}：系列名。
		/// {b}：数据名。
		/// {c}：数据值。
		/// {d}：百分比。
		/// {@xxx}：数据中名为 'xxx' 的维度的值，如 {@product} 表示名为 'product' 的维度的值。
		/// {@[n]}：数据中维度 n 的值，如 {@[3]} 表示维度 3 的值，从 0 开始计数。
		/// 
		/// 示例：
		/// formatter: '{b}: {d}'
		/// 
		/// 回调函数
		/// 回调函数格式：
		/// (params: Object|Array) => string
		/// 
		/// 参数 params 是 formatter 需要的单个数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 文字水平对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// 
		/// rich 中如果没有设置 align，则会取父层级的 align。例如：
		/// {
		///     align: right,
		///     rich: {
		///         a: {
		///             // 没有设置 `align`，则 `align` 为 right
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 文字垂直对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'top'
		/// 'middle'
		/// 'bottom'
		/// 
		/// rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
		/// {
		///     verticalAlign: bottom,
		///     rich: {
		///         a: {
		///             // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// borderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// borderType: [5, 10],
		/// 
		/// borderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("borderType")]
		public StringOrNumber[] BorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// borderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("borderDashOffset")]
		public double? BorderDashOffset { get; set; }

		/// <summary>
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }
	}

	/// <summary>
	/// 桑基图每一层的设置。可以逐层设置，如下：
	/// levels: [{
	///     depth: 0,
	///     itemStyle: {
	///         color: '#fbb4ae'
	///     },
	///     lineStyle: {
	///         color: 'source',
	///         opacity: 0.6
	///     }
	/// }, {
	///     depth: 1,
	///     itemStyle: {
	///         color: '#b3cde3'
	///     },
	///     lineStyle: {
	///         color: 'source',
	///         opacity: 0.6
	///     }
	/// }]
	/// 
	/// 也可以只设置某一层：
	/// levels: [{
	///     depth: 3,
	///     itemStyle: {
	///         color: '#fbb4ae'
	///     },
	///     lineStyle: {
	///         color: 'source',
	///         opacity: 0.6
	///     }
	/// }]
	/// </summary>
	public class SeriesSankey_Levels
	{
		/// <summary>
		/// 指定设置的是桑基图哪一层，取值从 0 开始。
		/// </summary>
		[JsonProperty("depth")]
		public double? Depth { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesSankey_Levels_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public SeriesSankey_Levels_Blur Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("select")]
		public SeriesSankey_Levels_Emphasis Select { get; set; }
	}

	/// <summary>
	/// 桑基图的高亮状态。
	/// </summary>
	public class SeriesSankey_Levels_Emphasis
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 桑基图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesSankey_Levels_Blur
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}


	/// <summary>
	/// 桑基图节点矩形的样式。
	/// </summary>
	public class ItemStyle11
	{
		/// <summary>
		/// 图形的颜色。 默认从全局调色盘 option.color 获取颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 图形的描边颜色。支持的颜色格式同 color，不支持回调函数。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 描边线宽。为 0 时无描边。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// borderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// borderType: [5, 10],
		/// 
		/// borderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("borderType")]
		public StringOrNumber[] BorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// borderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("borderDashOffset")]
		public double? BorderDashOffset { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于指定线段末端的绘制方式，可以是：
		/// 
		/// 'butt': 线段末端以方形结束。
		/// 'round': 线段末端以圆形结束。
		/// 'square': 线段末端以方形结束，但是增加了一个宽度和线段相同，高度是线段厚度一半的矩形区域。
		/// 
		/// 默认值为 'butt'。 更多详情可以参考 MDN lineCap。
		/// </summary>
		[JsonProperty("borderCap")]
		public string BorderCap { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置2个长度不为0的相连部分（线段，圆弧，曲线）如何连接在一起的属性（长度为0的变形部分，其指定的末端和控制点在同一位置，会被忽略）。
		/// 可以是：
		/// 
		/// 'bevel': 在相连部分的末端填充一个额外的以三角形为底的区域， 每个部分都有各自独立的矩形拐角。
		/// 'round': 通过填充一个额外的，圆心在相连部分末端的扇形，绘制拐角的形状。 圆角的半径是线段的宽度。
		/// 'miter': 通过延伸相连部分的外边缘，使其相交于一点，形成一个额外的菱形区域。这个设置可以通过 
		/// borderMiterLimit
		/// 属性看到效果。
		/// 
		/// 默认值为 'bevel'。 更多详情可以参考 MDN lineJoin。
		/// </summary>
		[JsonProperty("borderJoin")]
		public string BorderJoin { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置斜接面限制比例。只有当 
		/// borderJoin
		///  为 miter 时，
		/// borderMiterLimit
		///  才有效。
		/// 默认值为 10。负数、0、Infinity 和 NaN 均会被忽略。
		/// 更多详情可以参考 MDN miterLimit。
		/// </summary>
		[JsonProperty("borderMiterLimit")]
		public double? BorderMiterLimit { get; set; }

		/// <summary>
		/// 图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		/// 示例：
		/// {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		/// }
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影颜色。支持的格式同color。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 阴影水平方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影垂直方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 图形的贴花图案，在 aria.enabled 与 aria.decal.show 都是 true 的情况下才生效。
		/// 如果为 'none' 表示不使用贴花图案。
		/// </summary>
		[JsonProperty("decal")]
		public Decal0 Decal { get; set; }

		/// <summary>
		/// 从 v5.5.1 开始支持
		/// 
		/// 
		/// 
		/// 圆角半径，单位px，支持传入数组分别指定 4 个圆角半径。
		/// 如:
		/// borderRadius: 5, // 统一设置四个角的圆角大小
		/// borderRadius: [5, 5, 0, 0] //（顺时针左上，右上，右下，左下）
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }
	}

	/// <summary>
	/// 桑基图边的样式
	/// </summary>
	public class LineStyle5
	{
		/// <summary>
		/// 桑基图边的颜色。
		/// 
		/// 'source': 使用源节点颜色。
		/// 'target': 使用目标节点颜色。
		/// 'gradient': 以源节点和目标节点的颜色做一个渐变过渡色。(从 v5.0.0 开始支持)
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 桑基图边的透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 桑基图边的曲度。
		/// </summary>
		[JsonProperty("curveness")]
		public double? Curveness { get; set; }

		/// <summary>
		/// 图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		/// 示例：
		/// {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		/// }
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影颜色。支持的格式同color。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 阴影水平方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影垂直方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }
	}

	/// <summary>
	/// 桑基图的高亮状态。
	/// </summary>
	public class SeriesSankey_Emphasis
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 
		/// 
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// 
		/// 
		/// 'adjacency' 聚焦关系图中的邻接点和边的图形。
		/// 
		/// 
		/// 'trajectory' 聚焦所有连接到当前高亮的数据的节点和边。（从 v5.4.3 开始支持）
		/// 
		/// 示例：
		/// 下面代码配置了柱状图在高亮一个图形的时候，淡出当前直角坐标系所有其它的系列。
		/// emphasis: {
		///     focus: 'series',
		///     blurScope: 'coordinateSystem'
		/// }
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 桑基图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesSankey_Blur
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 桑基图的选中状态。开启 selectedMode 后有效。
	/// </summary>
	public class SeriesSankey_Select
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}

	/// <summary>
	/// 桑基图节点数据列表。
	/// data: [{
	///     name: 'node1',
	///     // This attribute decides the layer of the current node.
	///     depth: 0
	/// }, {
	///     name: 'node2',
	///     depth: 1
	/// }]
	/// 
	/// 注意: 节点的name不能重复。
	/// </summary>
	public class SeriesSankey_Data
	{
		/// <summary>
		/// 节点的名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 节点的值，可用来指定节点的纵向高度或横向的宽度。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 节点所在的层，取值从 0 开始。
		/// </summary>
		[JsonProperty("depth")]
		public double? Depth { get; set; }

		/// <summary>
		/// 该节点的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle11 ItemStyle { get; set; }

		/// <summary>
		/// 该节点标签的样式。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesSankey_Data_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public SeriesSankey_Data_Blur Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("select")]
		public SeriesSankey_Data_Emphasis Select { get; set; }

		/// <summary>
		/// 本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// 桑基图的高亮状态。
	/// </summary>
	public class SeriesSankey_Data_Emphasis
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle0 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 桑基图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesSankey_Data_Blur
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle0 ItemStyle { get; set; }
	}


	/// <summary>
	/// 节点间的边。注意: 桑基图理论上只支持有向无环图（DAG, Directed Acyclic Graph），所以请确保输入的边是无环的. 示例：
	/// links: [{
	///     source: 'n1',
	///     target: 'n2'
	/// }, {
	///     source: 'n2',
	///     target: 'n3'
	/// }]
	/// </summary>
	public class SeriesSankey_Links
	{
		/// <summary>
		/// 边的源节点名称
		/// </summary>
		[JsonProperty("source")]
		public string Source { get; set; }

		/// <summary>
		/// 边的目标节点名称
		/// </summary>
		[JsonProperty("target")]
		public string Target { get; set; }

		/// <summary>
		/// 边的数值，决定边的宽度。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 关系边的线条样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesSankey_Links_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public SeriesSankey_Links_Blur Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("select")]
		public SeriesSankey_Links_Emphasis Select { get; set; }
	}

	/// <summary>
	/// 桑基图的高亮状态。
	/// </summary>
	public class SeriesSankey_Links_Emphasis
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 关系边的线条样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 桑基图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesSankey_Links_Blur
	{
		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 关系边的线条样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}
}