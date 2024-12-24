using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
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
}