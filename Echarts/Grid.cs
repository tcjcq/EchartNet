using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。可以在网格上绘制折线图，柱状图，散点图（气泡图）。
	/// 在 ECharts 2.x 里单个 echarts 实例中最多只能存在一个 grid 组件，在 ECharts 3 中可以存在任意个 grid 组件。
	/// 例如下面这个 Anscombe Quartet 的示例：
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class Grid
	{
		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 是否显示直角坐标系网格。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

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
		/// grid 组件离容器左侧的距离。
		/// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		/// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// grid 组件离容器上侧的距离。
		/// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		/// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// grid 组件离容器右侧的距离。
		/// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// grid 组件离容器下侧的距离。
		/// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// grid 组件的宽度。默认自适应。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		/// grid 组件的高度。默认自适应。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }

		/// <summary>
		/// grid 区域是否包含坐标轴的刻度标签。
		/// 
		/// containLabel 为 false 的时候：
		/// grid.left grid.right grid.top grid.bottom grid.width grid.height 决定的是由坐标轴形成的矩形的尺寸和位置。
		/// 这比较适用于多个 grid 进行对齐的场景，因为往往多个 grid 对齐的时候，是依据坐标轴来对齐的。
		/// 
		/// 
		/// containLabel 为 true 的时候：
		/// grid.left grid.right grid.top grid.bottom grid.width grid.height 决定的是包括了坐标轴标签在内的所有内容所形成的矩形的位置。
		/// 这常用于『防止标签溢出』的场景，标签溢出指的是，标签长度动态变化时，可能会溢出容器或者覆盖其他组件。
		/// </summary>
		[JsonProperty("containLabel")]
		public bool? ContainLabel { get; set; }

		/// <summary>
		/// 网格背景色，默认透明。
		/// 
		/// 颜色可以使用 RGB 表示，比如 'rgb(128, 128, 128)'   ，如果想要加上 alpha 通道，可以使用 RGBA，比如 'rgba(128, 128, 128, 0.5)'，也可以使用十六进制格式，比如 '#ccc'
		/// 
		/// 注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 网格的边框颜色。支持的颜色格式同 backgroundColor。
		/// 注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 网格的边框线宽。
		/// 注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		/// 示例：
		/// {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		/// }
		/// 
		/// 注意：此配置项生效的前提是，设置了 show: true 以及值不为 transparent 的背景色 backgroundColor。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影颜色。支持的格式同color。
		/// 注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 阴影水平方向上的偏移距离。
		/// 注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影垂直方向上的偏移距离。
		/// 注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 本坐标系特定的 tooltip 设定。
		/// 提示框组件的通用介绍：
		/// 提示框组件可以设置在多种地方：
		/// 
		/// 可以设置在全局，即 tooltip
		/// 
		/// 可以设置在坐标系中，即 grid.tooltip、polar.tooltip、single.tooltip
		/// 
		/// 可以设置在系列中，即 series.tooltip
		/// 
		/// 可以设置在系列的每个数据项中，即 series.data.tooltip
		/// </summary>
		[JsonProperty("tooltip")]
		public SingleAxis_Tooltip Tooltip { get; set; }
	}

	/// <summary>
	/// 本坐标系特定的 tooltip 设定。
	/// 提示框组件的通用介绍：
	/// 提示框组件可以设置在多种地方：
	/// 
	/// 可以设置在全局，即 tooltip
	/// 
	/// 可以设置在坐标系中，即 grid.tooltip、polar.tooltip、single.tooltip
	/// 
	/// 可以设置在系列中，即 series.tooltip
	/// 
	/// 可以设置在系列的每个数据项中，即 series.data.tooltip
	/// </summary>
	public class SingleAxis_Tooltip
	{
		/// <summary>
		/// 是否显示提示框组件。
		/// 包括提示框浮层和 axisPointer。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 触发类型。
		/// 可选：
		/// 
		/// 'item'
		///   数据项图形触发，主要在散点图，饼图等无类目轴的图表中使用。
		/// 
		/// 'axis'
		///   坐标轴触发，主要在柱状图，折线图等会使用类目轴的图表中使用。
		///   在 ECharts 2.x 中只支持类目轴上使用 axis trigger，在 ECharts 3 中支持在直角坐标系和极坐标系上的所有类型的轴。并且可以通过 axisPointer.axis 指定坐标轴。
		/// 
		/// 'none'
		///   什么都不触发。
		/// </summary>
		[JsonProperty("trigger")]
		public string Trigger { get; set; }

		/// <summary>
		/// 坐标轴指示器配置项。
		/// tooltip.axisPointer 是配置坐标轴指示器的快捷方式。实际上坐标轴指示器的全部功能，都可以通过轴上的 axisPointer 配置项完成（例如 xAxis.axisPointer 或 angleAxis.axisPointer）。但是使用 tooltip.axisPointer 在简单场景下会更方便一些。
		/// 
		/// 注意： tooltip.axisPointer 中诸配置项的优先级低于轴上的 axisPointer 的配置项。
		/// 
		/// 坐标轴指示器是指示坐标轴当前刻度的工具。
		/// 如下例，鼠标悬浮到图上，可以出现标线和刻度文本。
		/// 
		/// 
		/// 
		/// 上例中，使用了 axisPointer.link 来关联不同的坐标系中的 axisPointer。
		/// 坐标轴指示器也有适合触屏的交互方式，如下：
		/// 
		/// 
		/// 
		/// 坐标轴指示器在多轴的场景能起到辅助作用：
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 注意：
		/// 一般来说，axisPointer 的具体配置项会配置在各个轴中（如 xAxis.axisPointer）或者 tooltip 中（如 tooltip.axisPointer）。
		/// 
		/// 
		/// 但是这几个选项只能配置在全局的 axisPointer 中：axisPointer.triggerOn、axisPointer.link。
		/// 
		/// 
		/// 如何显示 axisPointer：
		/// 直角坐标系 grid、极坐标系 polar、单轴坐标系 single 中的每个轴都自己的 axisPointer。
		/// 他们的 axisPointer 默认不显示。有两种方法可以让他们显示：
		/// 
		/// 设置轴上的 axisPointer.show（例如 xAxis.axisPointer.show）为 true，则显示此轴的 axisPointer。
		/// 
		/// 设置 tooltip.trigger 设置为 'axis' 或者 tooltip.axisPointer.type 设置为 'cross'，则此时坐标系会自动选择显示哪个轴的 axisPointer，也可以使用 tooltip.axisPointer.axis 改变这种选择。注意，轴上如果设置了 axisPointer，会覆盖此设置。
		/// 
		/// 
		/// 
		/// 如何显示 axisPointer 的 label：
		/// axisPointer 的 label 默认不显示（也就是默认只显示指示线），除非：
		/// 
		/// 设置轴上的 axisPointer.label.show（例如 xAxis.axisPointer.label.show）为 true，则显示此轴的 axisPointer 的 label。
		/// 
		/// 设置 tooltip.axisPointer.type 为 'cross' 时会自动显示 axisPointer 的 label。
		/// 
		/// 
		/// 
		/// 关于触屏的 axisPointer 的设置
		/// 设置轴上的 axisPointer.handle.show（例如 xAxis.axisPointer.handle.show 为 true 则会显示出此 axisPointer 的拖拽按钮。（polar 坐标系暂不支持此功能）。
		/// 注意：
		/// 如果发现此时 tooltip 效果不良好，可设置 tooltip.triggerOn 为 'none'（于是效果为：手指按住按钮则显示 tooltip，松开按钮则隐藏 tooltip），或者 tooltip.alwaysShowContent 为 true（效果为 tooltip 一直显示）。
		/// 参见例子。
		/// 
		/// 自动吸附到数据（snap）
		/// 对于数值轴、时间轴，如果开启了 snap，则 axisPointer 会自动吸附到最近的点上。
		/// </summary>
		[JsonProperty("axisPointer")]
		public Grid_Tooltip_AxisPointer AxisPointer { get; set; }

		/// <summary>
		/// 提示框浮层的位置，默认不设置时位置会跟随鼠标的位置。
		/// 可选：
		/// 
		/// Array
		///   通过数组表示提示框浮层的位置，支持数字设置绝对位置，百分比设置相对位置。
		///   示例:
		///   // 绝对位置，相对于容器左侧 10px, 上侧 10 px
		///   position: [10, 10]
		///   // 相对位置，放置在容器正中间
		///   position: ['50%', '50%']
		/// 
		/// 
		/// Function
		///   回调函数，格式如下：
		///   (point: Array, params: Object|Array.<Object>, dom: HTMLDomElement, rect: Object, size: Object) => Array
		/// 
		///   参数：
		///   point: 鼠标位置，如 [20, 40]。
		///   params: 同 formatter 的参数相同。
		///   dom: tooltip 的 dom 对象。
		///   rect: 只有鼠标在图形上时有效，是一个用x, y, width, height四个属性表达的图形包围盒。
		///   size: 包括 dom 的尺寸和 echarts 容器的当前尺寸，例如：{contentSize: [width, height], viewSize: [width, height]}。
		///   返回值：
		///   可以是一个表示 tooltip 位置的数组，数组值可以是绝对的像素值，也可以是相  百分比。
		///   也可以是一个对象，如：{left: 10, top: 30}，或者 {right: '20%', bottom: 40}。
		///   如下示例：
		///   position: function (point, params, dom, rect, size) {
		///       // 固定在顶部
		///       return [point[0], '10%'];
		///   }
		/// 
		///   或者：
		///   position: function (pos, params, dom, rect, size) {
		///       // 鼠标在左侧时 tooltip 显示到右侧，鼠标在右侧时 tooltip 显示到左侧。
		///       var obj = {top: 60};
		///       obj[['left', 'right'][+(pos[0] < size.viewSize[0] / 2)]] = 5;
		///       return obj;
		///   }
		/// 
		/// 
		/// 
		/// 
		/// 'inside'
		///   鼠标所在图形的内部中心位置，只在 trigger 为'item'的时候有效。
		/// 
		/// 'top'
		///   鼠标所在图形上侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'left'
		///   鼠标所在图形左侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'right'
		///   鼠标所在图形右侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'bottom'
		///   鼠标所在图形底侧，只在 trigger 为'item'的时候有效。
		/// </summary>
		[JsonProperty("position")]
		public ArrayOrSingle Position { get; set; }

		/// <summary>
		/// 提示框浮层内容格式器，支持字符串模板和回调函数两种形式。
		/// 1. 字符串模板
		/// 模板变量有 {a}, {b}，{c}，{d}，{e}，分别表示系列名，数据名，数据值等。
		/// 在 trigger 为 'axis' 的时候，会有多个系列的数据，此时可以通过 {a0}, {a1}, {a2} 这种后面加索引的方式表示系列的索引。
		/// 不同图表类型下的 {a}，{b}，{c}，{d} 含义不一样。
		/// 其中变量{a}, {b}, {c}, {d}在不同图表类型下代表数据含义为：
		/// 
		/// 折线（区域）图、柱状（条形）图、K线图 : {a}（系列名称），{b}（类目值），{c}（数值）, {d}（无）
		/// 
		/// 散点图（气泡）图 : {a}（系列名称），{b}（数据名称），{c}（数值数组）, {d}（无）
		/// 
		/// 地图 : {a}（系列名称），{b}（区域名称），{c}（合并数值）, {d}（无）
		/// 
		/// 饼图、仪表盘、漏斗图: {a}（系列名称），{b}（数据项名称），{c}（数值）, {d}（百分比）
		/// 
		/// 
		/// 更多其它图表模板变量的含义可以见相应的图表的 label.formatter 配置项。
		/// 示例：
		/// formatter: '{b0}: {c0}<br />{b1}: {c1}'
		/// 
		/// 2. 回调函数
		/// 回调函数格式：
		/// (params: Object|Array, ticket: string, callback: (ticket: string, html: string)) => string | HTMLElement | HTMLElement[]
		/// 
		/// 支持返回 HTML 字符串或者创建的 DOM 实例。
		/// 第一个参数 params 是 formatter 需要的数据集。格式如下：
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
		///     color: string,
		///     // 饼图/漏斗图的百分比
		///     percent: number,
		///     // 旭日图中当前节点的祖先节点（包括自身）
		///     treePathInfo: Array,
		///     // 树图/矩形树图中当前节点的祖先节点（包括自身）
		///     treeAncestors: Array
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
		/// 
		/// 在 trigger 为 'axis' 的时候，或者 tooltip 被 axisPointer 触发的时候，params 是多个系列的数据数组。其中每项内容格式同上，并且，
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
		/// 
		/// 第二个参数 ticket 是异步回调标识，配合第三个参数 callback 使用。
		/// 第三个参数 callback 是异步回调，在提示框浮层内容是异步获取的时候，可以通过 callback 传入上述的 ticket 和 html 更新提示框浮层内容。
		/// 示例：
		/// formatter: function (params, ticket, callback) {
		///     $.get('detail?name=' + params.name, function (content) {
		///         callback(ticket, toHTML(content));
		///     });
		///     return 'Loading';
		/// }
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// tooltip 中数值显示部分的格式化回调函数。
		/// 回调函数格式：
		/// (value: number | string, dataIndex: number) => string
		/// 
		/// 
		/// 自 v5.5.0 版本起提供 dataIndex。
		/// 
		/// 示例：
		/// // 添加 $ 前缀
		/// valueFormatter: (value) => '$' + value.toFixed(2)
		/// </summary>
		[JsonProperty("valueFormatter")]
		public string ValueFormatter { get; set; }

		/// <summary>
		/// 提示框浮层的背景颜色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 提示框浮层的边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 提示框浮层的边框宽。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 提示框浮层内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。
		/// 使用示例：
		/// // 设置内边距为 5
		/// padding: 5
		/// // 设置上下的内边距为 5，左右的内边距为 10
		/// padding: [5, 10]
		/// // 分别设置四个方向的内边距
		/// padding: [
		///     5,  // 上
		///     10, // 右
		///     5,  // 下
		///     10, // 左
		/// ]
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 提示框浮层的文本样式。
		/// </summary>
		[JsonProperty("textStyle")]
		public Legend_PageTextStyle TextStyle { get; set; }

		/// <summary>
		/// 额外附加到浮层的 css 样式。如下为浮层添加阴影的示例：
		/// extraCssText: 'box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);'
		/// </summary>
		[JsonProperty("extraCssText")]
		public string ExtraCssText { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Grid_Tooltip_AxisPointer
	{
		/// <summary>
		/// 指示器类型。
		/// 可选
		/// 
		/// 'line' 直线指示器
		/// 
		/// 'shadow' 阴影指示器
		/// 
		/// 'none' 无指示器
		/// 
		/// 'cross' 十字准星指示器。其实是种简写，表示启用两个正交的轴的 axisPointer。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "line";

		/// <summary>
		/// 指示器的坐标轴。
		/// 默认情况，坐标系会自动选择显示哪个轴的 axisPointer（默认取类目轴或者时间轴）。
		/// 可以是 'x', 'y', 'radius', 'angle'。
		/// </summary>
		[JsonProperty("axis")]
		public string Axis { get; set; }

		/// <summary>
		/// 坐标轴指示器是否自动吸附到点上。默认自动判断。
		/// 这个功能在数值轴和时间轴上比较有意义，可以自动寻找细小的数值点。
		/// </summary>
		[JsonProperty("snap")]
		public bool? Snap { get; set; }

		/// <summary>
		/// 坐标轴指示器的 z 值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 坐标轴指示器的文本标签。
		/// </summary>
		[JsonProperty("label")]
		public Label0 Label { get; set; }

		/// <summary>
		/// axisPointer.type 为 'line' 时有效。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// axisPointer.type 为 'shadow' 时有效。
		/// </summary>
		[JsonProperty("shadowStyle")]
		public ShadowStyle0 ShadowStyle { get; set; }

		/// <summary>
		/// axisPointer.type 为 'cross' 时有效。
		/// </summary>
		[JsonProperty("crossStyle")]
		public LineStyle1 CrossStyle { get; set; }

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
	}

	/// <summary>
	/// 
	/// </summary>
	public class Label0
	{
		/// <summary>
		/// 是否显示文本标签。如果 tooltip.axisPointer.type 设置为 'cross' 则默认显示标签，否则默认不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 文本标签中数值的小数点精度。默认根据当前轴的值自动判断。也可以指定如 2 表示保留两位小数。
		/// </summary>
		[JsonProperty("precision")]
		public StringOrNumber Precision { get; set; }

		/// <summary>
		/// 文本标签文字的格式化器。
		/// 如果为 string，可以是例如：formatter: 'some text {value} some text，其中 {value} 会被自动替换为轴的值。
		/// 如果为 function，可以是例如：
		/// 参数：
		/// {Object} params: 含有：
		/// {Object} params.value: 轴当前值，如果 axis.type 为 'category' 时，其值为 axis.data 里的数值。如果 axis.type 为 'time'，其值为时间戳。
		/// {Array.<Object>} params.seriesData: 一个数组，是当前 axisPointer 最近的点的信息，每项内容为
		/// {string} params.axisDimension: 轴的维度名，例如直角坐标系中是 'x'、'y'，极坐标系中是 'radius'、'angle'。
		/// {number} params.axisIndex: 轴的 index，0、1、2、...
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
		/// 
		/// 每项内容还包括轴的信息：
		/// {
		///     axisDim: 'x', // 'x', 'y', 'angle', 'radius', 'single'
		///     axisId: 'xxx',
		///     axisName: 'xxx',
		///     axisIndex: 3,
		///     axisValue: 121, // 当前 axisPointer 对应的 value。
		///     axisValueLabel: '文本'
		/// }
		/// 
		/// 返回值：
		/// 显示的 string。
		/// 例如：
		/// formatter: function (params) {
		///     // 假设此轴的 type 为 'time'。
		///     return 'some text' + echarts.format.formatTime(params.value);
		/// }
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// label 距离轴的距离。
		/// </summary>
		[JsonProperty("margin")]
		public double? Margin { get; set; }

		/// <summary>
		/// 文字的颜色。
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
		/// axisPointer内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。
		/// 使用示例：
		/// // 设置内边距为 5
		/// padding: 5
		/// // 设置上下的内边距为 5，左右的内边距为 10
		/// padding: [5, 10]
		/// // 分别设置四个方向的内边距
		/// padding: [
		///     5,  // 上
		///     10, // 右
		///     5,  // 下
		///     10, // 左
		/// ]
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文本标签的背景颜色，默认是和 axis.axisLine.lineStyle.color 相同。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public string BackgroundColor { get; set; }

		/// <summary>
		/// 文本标签的边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public string BorderColor { get; set; }

		/// <summary>
		/// 文本标签的边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public string BorderWidth { get; set; }

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
	/// 
	/// </summary>
	public class LineStyle1
	{
		/// <summary>
		/// 线的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 线宽。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 线的类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// dashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// type: [5, 10],
		/// 
		/// dashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("type")]
		public StringOrNumber[] Type { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// type
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("dashOffset")]
		public double? DashOffset { get; set; }

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
		[JsonProperty("cap")]
		public string Cap { get; set; }

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
		/// miterLimit
		/// 属性看到效果。
		/// 
		/// 默认值为 'bevel'。 更多详情可以参考 MDN lineJoin。
		/// </summary>
		[JsonProperty("join")]
		public string Join { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置斜接面限制比例。只有当 
		/// join
		///  为 miter 时，
		/// miterLimit
		///  才有效。
		/// 默认值为 10。负数、0、Infinity 和 NaN 均会被忽略。
		/// 更多详情可以参考 MDN miterLimit。
		/// </summary>
		[JsonProperty("miterLimit")]
		public double? MiterLimit { get; set; }

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
	}

	/// <summary>
	/// 
	/// </summary>
	public class ShadowStyle0
	{
		/// <summary>
		/// 填充的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

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
	}
}