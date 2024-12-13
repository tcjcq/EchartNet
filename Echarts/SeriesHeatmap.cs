using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 热力图
	/// 热力图主要通过颜色去表现数值的大小，必须要配合 visualMap 组件使用。
	/// 可以应用在直角坐标系以及地理坐标系上，这两个坐标系上的表现形式相差很大，直角坐标系上必须要使用两个类目轴。
	/// 下面是在直角坐标系上应用的例子：
	/// 直角坐标系：
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesHeatmap
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

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
		/// 该系列使用的坐标系，可选：
		/// 
		/// 'cartesian2d'
		///   使用二维的直角坐标系（也称笛卡尔坐标系），通过 xAxisIndex, yAxisIndex指定相应的坐标轴组件。
		/// 
		/// 
		/// 
		/// 'geo'
		///   使用地理坐标系，通过 geoIndex 指定相应的地理坐标系组件。
		/// 
		/// 
		/// 
		/// 'calendar'
		///   使用日历坐标系，通过 calendarIndex 指定相应的日历坐标系组件。
		/// </summary>
		[JsonProperty("coordinateSystem")]
		public string CoordinateSystem { get; set; }

		/// <summary>
		/// 使用的 x 轴的 index，在单个图表实例中存在多个 x 轴的时候有用。
		/// </summary>
		[JsonProperty("xAxisIndex")]
		public double? XAxisIndex { get; set; }

		/// <summary>
		/// 使用的 y 轴的 index，在单个图表实例中存在多个 y轴的时候有用。
		/// </summary>
		[JsonProperty("yAxisIndex")]
		public double? YAxisIndex { get; set; }

		/// <summary>
		/// 使用的地理坐标系的 index，在单个图表实例中存在多个地理坐标系的时候有用。
		/// </summary>
		[JsonProperty("geoIndex")]
		public double? GeoIndex { get; set; }

		/// <summary>
		/// 使用的日历坐标系的 index，在单个图表实例中存在多个日历坐标系的时候有用。
		/// </summary>
		[JsonProperty("calendarIndex")]
		public double? CalendarIndex { get; set; }

		/// <summary>
		/// 每个点的大小，在地理坐标系(coordinateSystem: 'geo')上有效。
		/// </summary>
		[JsonProperty("pointSize")]
		public double? PointSize { get; set; }

		/// <summary>
		/// 每个点模糊的大小，在地理坐标系(coordinateSystem: 'geo')上有效。
		/// </summary>
		[JsonProperty("blurSize")]
		public double? BlurSize { get; set; }

		/// <summary>
		/// 最小的透明度，在地理坐标系(coordinateSystem: 'geo')上有效。
		/// </summary>
		[JsonProperty("minOpacity")]
		public double? MinOpacity { get; set; }

		/// <summary>
		/// 最大的透明度，在地理坐标系(coordinateSystem: 'geo')上有效。
		/// </summary>
		[JsonProperty("maxOpacity")]
		public double? MaxOpacity { get; set; }

		/// <summary>
		/// 渐进式渲染时每一帧绘制图形数量，设为 0 时不启用渐进式渲染，支持每个系列单独配置。
		/// 在图中有数千到几千万图形元素的时候，一下子把图形绘制出来，或者交互重绘的时候可能会造成界面的卡顿甚至假死。ECharts 4 开始全流程支持渐进渲染（progressive rendering），渲染的时候会把创建好的图形分到数帧中渲染，每一帧渲染只渲染指定数量的图形。
		/// 该配置项就是用于配置该系列每一帧渲染的图形数，可以根据图表图形复杂度的需要适当调整这个数字使得在不影响交互流畅性的前提下达到绘制速度的最大化。比如在 lines 图或者平行坐标中线宽大于 1 的 polyline 绘制会很慢，这个数字就可以设置小一点，而线宽小于等于 1 的 polyline 绘制非常快，该配置项就可以相对调得比较大。
		/// </summary>
		[JsonProperty("progressive")]
		public double? Progressive { get; set; }

		/// <summary>
		/// 启用渐进式渲染的图形数量阈值，在单个系列的图形数量超过该阈值时启用渐进式渲染。
		/// </summary>
		[JsonProperty("progressiveThreshold")]
		public double? ProgressiveThreshold { get; set; }

		/// <summary>
		/// 在直角坐标系(coordinateSystem: 'cartesian2d')上有效。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

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
		/// 样式设置，在直角坐标系(coordinateSystem: 'cartesian2d')上有效。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle10 ItemStyle { get; set; }

		/// <summary>
		/// 高亮状态的图形样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesHeatmap_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.2.0 开始支持
		/// 
		/// 全局过渡动画相关的配置。
		/// 全局过渡动画（Universal Transition）提供了任意系列之间进行变形动画的功能。开启该功能后，每次setOption，相同id的系列之间会自动关联进行动画的过渡，更细粒度的关联配置见universalTransition.seriesKey配置。
		/// 通过配置数据项的groupId和childGroupId，还可以实现诸如下钻，聚合等一对多或者多对一的动画。
		/// 可以直接在系列中配置 universalTransition: true 开启该功能。也可以提供一个对象进行更多属性的配置。
		/// </summary>
		[JsonProperty("universalTransition")]
		public SeriesLine_UniversalTransition UniversalTransition { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 淡出状态的图形样式。开启 emphasis.focus 后有效。
		/// </summary>
		[JsonProperty("blur")]
		public Blur1 Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 选中状态的图形样式。开启 selectedMode 后有效。
		/// </summary>
		[JsonProperty("select")]
		public Emphasis0 Select { get; set; }

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
		/// 可以定义 data 的哪个维度被编码成什么。比如：
		/// option = {
		///     dataset: {
		///         source: [
		///             // 每一列称为一个『维度』。
		///             // 这里分别是维度 0、1、2、3、4。
		///             [12, 44, 55, 66, 2],
		///             [23, 6, 16, 23, 1],
		///             ...
		///         ]
		///     },
		///     series: {
		///         type: 'xxx',
		///         encode: {
		///             x: [3, 1, 5],      // 表示维度 3、1、5 映射到 x 轴。
		///             y: 2,              // 表示维度 2 映射到 y 轴。
		///             tooltip: [3, 2, 4] // 表示维度 3、2、4 会在 tooltip 中显示。
		///         }
		///     }
		/// }
		/// 
		/// 当使用 dimensions 给维度定义名称后，encode 中可直接引用名称，例如：
		/// series: {
		///     type: 'xxx',
		///     dimensions: ['date', 'open', 'close', 'highest', 'lowest'],
		///     encode: {
		///         x: 'date',
		///         y: ['open', 'close', 'highest', 'lowest']
		///     }
		/// }
		/// 
		/// encode 声明的基本结构如下，其中冒号左边是坐标系、标签等特定名称，如 'x', 'y', 'tooltip' 等，冒号右边是数据中的维度名（string 格式）或者维度的序号（number 格式，从 0 开始计数），可以指定一个或多个维度（使用数组）。通常情况下，下面各种信息不需要所有的都写，按需写即可。
		/// 下面是 encode 支持的属性：
		/// // 在任何坐标系和系列中，都支持：
		/// encode: {
		///     // 使用 “名为 product 的维度” 和 “名为 score 的维度” 的值在 tooltip 中显示
		///     tooltip: ['product', 'score']
		///     // 使用第一个维度和第三个维度的维度名连起来作为系列名。（有时候名字比较长，这可以避免在 series.name 重复输入这些名字）
		///     seriesName: [1, 3],
		///     // 表示使用第二个维度中的值作为 id。这在使用 setOption 动态更新数据时有用处，可以使新老数据用 id 对应起来，从而能够产生合适的数据更新动画。
		///     itemId: 2,
		///     // 指定数据项的名称使用第三个维度在饼图等图表中有用，可以使这个名字显示在图例（legend）中。
		///     itemName: 3,
		///     // 指定数据项的组 ID (groupId)。当全局过渡动画功能开启时，setOption 前后拥有相同 groupId 的数据项会进行动画过渡。
		///     itemGroupId: 4,
		///     // 指定数据项对应的子数据组 ID (childGroupId)，用于实现多层下钻和聚合。详见 childGroupId。
		///     // 从 v5.5.0 开始支持
		///     itemChildGroupId: 5
		/// }
		/// 
		/// // 直角坐标系（grid/cartesian）特有的属性：
		/// encode: {
		///     // 把 “维度1”、“维度5”、“名为 score 的维度” 映射到 X 轴：
		///     x: [1, 5, 'score'],
		///     // 把“维度0”映射到 Y 轴。
		///     y: 0
		/// }
		/// 
		/// // 单轴（singleAxis）特有的属性：
		/// encode: {
		///     single: 3
		/// }
		/// 
		/// // 极坐标系（polar）特有的属性：
		/// encode: {
		///     radius: 3,
		///     angle: 2
		/// }
		/// 
		/// // 地理坐标系（geo）特有的属性：
		/// encode: {
		///     lng: 3,
		///     lat: 2
		/// }
		/// 
		/// // 对于一些没有坐标系的图表，例如饼图、漏斗图等，可以是：
		/// encode: {
		///     value: 3
		/// }
		/// 
		/// 这是个更丰富的 encode 的示例：
		/// 特殊地，在 自定义系列（custom series） 中，encode 中轴可以不指定或设置为 null/undefined，从而使系列免于受这个轴控制，也就是说，轴的范围（extent）不会受此系列数值的影响，轴被 dataZoom 控制时也不会过滤掉这个系列：
		/// var option = {
		///     xAxis: {},
		///     yAxis: {},
		///     dataZoom: [{
		///         xAxisIndex: 0
		///     }, {
		///         yAxisIndex: 0
		///     }],
		///     series: {
		///         type: 'custom',
		///         renderItem: function (params, api) {
		///             return {
		///                 type: 'circle',
		///                 shape: {
		///                     cx: 100, // x 位置永远为 100
		///                     cy: api.coord([0, api.value(0)])[1],
		///                     r: 30
		///                 },
		///                 style: {
		///                     fill: 'blue'
		///                 }
		///             };
		///         },
		///         encode: {
		///             // 这样这个系列就不会被 x 轴以及 x
		///             // 轴上的 dataZoom 控制了。
		///             x: -1,
		///             y: 1
		///         },
		///         data: [ ... ]
		///     }
		/// };
		/// </summary>
		[JsonProperty("encode")]
		public object Encode { get; set; }

		/// <summary>
		/// 当使用 dataset 时，seriesLayoutBy 指定了 dataset 中用行还是列对应到系列上，也就是说，系列“排布”到 dataset 的行还是列上。可取值：
		/// 
		/// 'column'：默认，dataset 的列对应于系列，从而 dataset 中每一列是一个维度（dimension）。
		/// 'row'：dataset 的行对应于系列，从而 dataset 中每一行是一个维度（dimension）。
		/// 
		/// 参见这个 示例
		/// </summary>
		[JsonProperty("seriesLayoutBy")]
		public string SeriesLayoutBy { get; set; }

		/// <summary>
		/// 如果 series.data 没有指定，并且 dataset 存在，那么就会使用 dataset。datasetIndex 指定本系列使用哪个 dataset。
		/// </summary>
		[JsonProperty("datasetIndex")]
		public double? DatasetIndex { get; set; }

		/// <summary>
		/// 该系列所有数据项的组 ID，优先级低于groupId。详见series.data.groupId。
		/// </summary>
		[JsonProperty("dataGroupId")]
		public string DataGroupId { get; set; }

		/// <summary>
		/// 系列中的数据内容数组。数组项通常为具体的数据项。
		/// 注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
		/// 可以使用 series.datasetIndex 指定其他的 dataset。
		/// 通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
		/// series: [{
		///     data: [
		///         // 维度X   维度Y   其他维度 ...
		///         [  3.4,    4.5,   15,   43],
		///         [  4.2,    2.3,   20,   91],
		///         [  10.8,   9.5,   30,   18],
		///         [  7.2,    8.8,   18,   57]
		///     ]
		/// }]
		/// 
		/// 
		/// 在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
		/// 在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
		/// 后面的其他维度是可选的，可以在别处被使用，例如：
		/// 在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
		/// 在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
		/// 使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
		/// 
		/// 
		/// 
		/// 特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
		/// xAxis: {
		///     data: ['a', 'b', 'm', 'n']
		/// },
		/// series: [{
		///     // 与 xAxis.data 一一对应。
		///     data: [23,  44,  55,  19]
		///     // 它其实是下面这种形式的简化：
		///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
		/// }]
		/// 
		/// 『值』与 轴类型 的关系：
		/// 
		/// 当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
		///   其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
		/// 
		/// 当某维度对应于类目轴（axis.type 为 'category'）的时候：
		///   其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
		///   xAxis: {
		///       type: 'category',
		///       data: ['星期一', '星期二', '星期三', '星期四']
		///   },
		///   yAxis: {
		///       type: 'category',
		///       data: ['a', 'b', 'm', 'n', 'p', 'q']
		///   },
		///   series: [{
		///       data: [
		///           // xAxis    yAxis
		///           [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
		///           [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
		///           [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
		///           [  3,        3,    5  ]
		///       ]
		///   }]
		/// 
		///   双类目轴的示例可以参考 Github Punchcard 示例。
		/// 
		/// 当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
		/// 
		/// 一个时间戳，如 1484141700832，表示 UTC 时间。
		/// 或者字符串形式的时间描述：
		/// ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
		/// 部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
		/// 使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
		/// 时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
		/// 
		/// 
		/// 其他的时间字符串，包括（均表示本地时间）:
		/// '2012', '2012-3-1', '2012/3/1', '2012/03/01',
		/// '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
		/// 
		/// 
		/// 或者用户自行初始化的 Date 实例：
		/// 注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
		/// 例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01') 表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
		/// 所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 当需要对个别数据进行个性化定义时：
		/// 数组项可用对象，其中的 value 像表示具体的数值，如：
		/// [
		///     12,
		///     34,
		///     {
		///         value : 56,
		///         //自定义标签样式，仅对该数据项有效
		///         label: {},
		///         //自定义特殊 itemStyle，仅对该数据项有效
		///         itemStyle:{}
		///     },
		///     10
		/// ]
		/// // 或
		/// [
		///     [12, 33],
		///     [34, 313],
		///     {
		///         value: [56, 44],
		///         label: {},
		///         itemStyle:{}
		///     },
		///     [10, 33]
		/// ]
		/// 
		/// 空值：
		/// 当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
		/// 例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
		/// </summary>
		[JsonProperty("data")]
		public SeriesHeatmap_Data[] Data { get; set; }

		/// <summary>
		/// 图表标注。
		/// </summary>
		[JsonProperty("markPoint")]
		public SeriesHeatmap_MarkPoint MarkPoint { get; set; }

		/// <summary>
		/// 图表标线。
		/// </summary>
		[JsonProperty("markLine")]
		public SeriesHeatmap_MarkLine MarkLine { get; set; }

		/// <summary>
		/// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
		/// </summary>
		[JsonProperty("markArea")]
		public SeriesHeatmap_MarkArea MarkArea { get; set; }

		/// <summary>
		/// 热力图所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 热力图组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// z相比zlevel优先级更低，而且不会创建新的 Canvas。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 本系列特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// 样式设置，在直角坐标系(coordinateSystem: 'cartesian2d')上有效。
	/// </summary>
	public class ItemStyle10
	{
		/// <summary>
		/// 图形的颜色。
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
		/// 从 v5.3.1 开始支持
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
	/// 高亮状态的图形样式。
	/// </summary>
	public class SeriesHeatmap_Emphasis
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
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }
	}

	/// <summary>
	/// 系列中的数据内容数组。数组项通常为具体的数据项。
	/// 注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
	/// 可以使用 series.datasetIndex 指定其他的 dataset。
	/// 通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
	/// series: [{
	///     data: [
	///         // 维度X   维度Y   其他维度 ...
	///         [  3.4,    4.5,   15,   43],
	///         [  4.2,    2.3,   20,   91],
	///         [  10.8,   9.5,   30,   18],
	///         [  7.2,    8.8,   18,   57]
	///     ]
	/// }]
	/// 
	/// 
	/// 在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
	/// 在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
	/// 后面的其他维度是可选的，可以在别处被使用，例如：
	/// 在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
	/// 在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
	/// 使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
	/// 
	/// 
	/// 
	/// 特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
	/// xAxis: {
	///     data: ['a', 'b', 'm', 'n']
	/// },
	/// series: [{
	///     // 与 xAxis.data 一一对应。
	///     data: [23,  44,  55,  19]
	///     // 它其实是下面这种形式的简化：
	///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
	/// }]
	/// 
	/// 『值』与 轴类型 的关系：
	/// 
	/// 当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
	///   其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
	/// 
	/// 当某维度对应于类目轴（axis.type 为 'category'）的时候：
	///   其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
	///   xAxis: {
	///       type: 'category',
	///       data: ['星期一', '星期二', '星期三', '星期四']
	///   },
	///   yAxis: {
	///       type: 'category',
	///       data: ['a', 'b', 'm', 'n', 'p', 'q']
	///   },
	///   series: [{
	///       data: [
	///           // xAxis    yAxis
	///           [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
	///           [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
	///           [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
	///           [  3,        3,    5  ]
	///       ]
	///   }]
	/// 
	///   双类目轴的示例可以参考 Github Punchcard 示例。
	/// 
	/// 当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
	/// 
	/// 一个时间戳，如 1484141700832，表示 UTC 时间。
	/// 或者字符串形式的时间描述：
	/// ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
	/// 部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
	/// 使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
	/// 时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
	/// 
	/// 
	/// 其他的时间字符串，包括（均表示本地时间）:
	/// '2012', '2012-3-1', '2012/3/1', '2012/03/01',
	/// '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
	/// 
	/// 
	/// 或者用户自行初始化的 Date 实例：
	/// 注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
	/// 例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01') 表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
	/// 所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 当需要对个别数据进行个性化定义时：
	/// 数组项可用对象，其中的 value 像表示具体的数值，如：
	/// [
	///     12,
	///     34,
	///     {
	///         value : 56,
	///         //自定义标签样式，仅对该数据项有效
	///         label: {},
	///         //自定义特殊 itemStyle，仅对该数据项有效
	///         itemStyle:{}
	///     },
	///     10
	/// ]
	/// // 或
	/// [
	///     [12, 33],
	///     [34, 313],
	///     {
	///         value: [56, 44],
	///         label: {},
	///         itemStyle:{}
	///     },
	///     [10, 33]
	/// ]
	/// 
	/// 空值：
	/// 当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
	/// 例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
	/// </summary>
	public class SeriesHeatmap_Data
	{
		/// <summary>
		/// 数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 数据项值。
		/// </summary>
		[JsonProperty("value")]
		public double[] Value { get; set; }

		/// <summary>
		/// 该数据项的组 ID。当全局过渡动画功能开启时，setOption 前后拥有相同组 ID 的数据项会进行动画过渡。
		/// 若没有指定groupId ，会尝试用series.dataGroupId作为该数据项的组 ID；若series.dataGroupId也没有指定，则会使用数据项的 ID 作为组 ID。
		/// 如果你使用了dataset组件来表达数据，推荐使用encode.itemGroupId来指定哪个维度被编码为组 ID。
		/// </summary>
		[JsonProperty("groupId")]
		public string GroupId { get; set; }

		/// <summary>
		/// 从 v5.5.0 开始支持
		/// 
		/// 该数据项对应的子数据组 ID，用于实现多层下钻和聚合。
		/// 
		/// 
		/// 
		/// 通过groupId已经可以达到数据下钻和聚合的效果，但只支持一层的下钻和聚合。为了实现多层下钻和聚合，我们又引入了childGroupId。
		/// 引入childGroupId后，不同option的数据项之间就能形成逻辑上的父子关系，例如：
		/// data: [                        data: [                        data: [
		///   {                              {                              {
		///     name: 'Animals',               name: 'Dogs',                  name: 'Corgi',
		///     value: 3,                      value: 3,                      value: 5,
		///     groupId: 'things',             groupId: 'animals',            groupId: 'dogs'
		///     childGroupId: 'animals'        childGroupId: 'dogs'         },
		///   },                             },                             {
		///   {                              {                                name: 'Bulldog',
		///     name: 'Fruits',                name: 'Cats',                  value: 6,
		///     value: 3,                      value: 4,                      groupId: 'dogs'
		///     groupId: 'things',             groupId: 'animals',          },
		///     childGroupId: 'fruits'         childGroupId: 'cats',        {
		///   },                             },                               name: 'Shiba Inu',
		///   {                              {                                value: 7,
		///     name: 'Cars',                  name: 'Birds',                 groupId: 'dogs'
		///     value: 2,                      value: 3,                    }
		///     groupId: 'things',             groupId: 'animals',        ]
		///     childGroupId: 'cars'           childGroupId: 'birds'
		///   }                              }
		/// ]                              ]
		/// 
		/// 上面 3 组 data 分别来自 3 个 option ，通过groupId和childGroupId，它们之间存在了“父-子-孙”的关系。在setOption时，Apache ECharts 会尝试寻找前后option数据项间的父子关系，若存在父子关系，则会对相关数据项进行下钻或聚合动画的过渡。
		/// 没有对应子数据组的数据项不需要指定childGroupId。
		/// 如果你使用了dataset组件来表达数据，推荐使用encode.itemChildGroupId来指定哪个维度被编码为子数据组 ID。
		/// </summary>
		[JsonProperty("childGroupId")]
		public string ChildGroupId { get; set; }

		/// <summary>
		/// 在直角坐标系(coordinateSystem: 'cartesian2d')上有效。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		/// 单个数据点的样式设置，在直角坐标系(coordinateSystem: 'cartesian2d')上有效。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle10 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis0 Emphasis { get; set; }
	}

	/// <summary>
	/// 图表标注。
	/// </summary>
	public class SeriesHeatmap_MarkPoint
	{
		/// <summary>
		/// 标记的图形。
		/// ECharts 提供的标记类型包括
		/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// 如果需要每个数据的图形不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => string
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// 标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// 如果需要每个数据的图形大小不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => number|Array
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// </summary>
		[JsonProperty("symbolSize")]
		public StringOrNumber SymbolSize { get; set; }

		/// <summary>
		/// 标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// 如果需要每个数据的旋转角度不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => number
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// 
		/// 从 4.8.0 开始支持回调函数。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public StringOrNumber SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// 标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 标注的文本。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 标注的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 标注的高亮样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标注的淡出样式。淡出的规则跟随所在系列。
		/// </summary>
		[JsonProperty("blur")]
		public Blur2 Blur { get; set; }

		/// <summary>
		/// 标注的数据数组。每个数组项是一个对象，有下面几种方式指定标注的位置。
		/// 
		/// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
		/// 
		/// 当多个属性同时存在时，优先级按上述的顺序。
		/// 示例：
		/// data: [
		/// 
		///     {
		///         name: '某个屏幕坐标',
		///         x: 100,
		///         y: 100
		///     }
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesPie_MarkPoint_Data Data { get; set; }

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
	/// 图表标线。
	/// </summary>
	public class SeriesHeatmap_MarkLine
	{
		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 标线两端的标记类型，可以是一个数组分别指定两端，也可以是单个统一指定，具体格式见 data.symbol。
		/// </summary>
		[JsonProperty("symbol")]
		public ArrayOrSingle Symbol { get; set; }

		/// <summary>
		/// 标线两端的标记大小，可以是一个数组分别指定两端，也可以是单个统一指定。
		/// 注意： 这里无法像一般的 symbolSize 那样通过数组分别指定高宽。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// 标线两端的标记相对于原本位置的偏移，可以是一个数组分别指定两端，也可以是单个统一指定。如果希望单独指定两端标记的水平/垂直偏移，也可以是一个二维数组，每个元素为单个标记的偏移量，例：
		/// symbolOffset: [
		///     [-10, 20],    // 起始标记偏移
		///     ['50%', 100]  // 结束标记偏移
		/// ]
		/// 
		/// 
		/// 从 v5.1.0 开始支持
		/// </summary>
		[JsonProperty("symbolOffset")]
		public StringOrNumber[] SymbolOffset { get; set; }

		/// <summary>
		/// 标线数值的精度，在显示平均值线的时候有用。
		/// </summary>
		[JsonProperty("precision")]
		public double? Precision { get; set; }

		/// <summary>
		/// 标线的文本。
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }

		/// <summary>
		/// 标线的样式
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// 标线的高亮样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis2 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标线的淡出样式。淡出的规则跟随所在系列。
		/// </summary>
		[JsonProperty("blur")]
		public Blur3 Blur { get; set; }

		/// <summary>
		/// 标线的数据数组。每个数组项可以是一个两个值的数组，分别表示线的起点和终点，每一项是一个对象，有下面几种方式指定起点或终点的位置。
		/// 
		/// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
		/// 
		/// 当多个属性同时存在时，优先级按上述的顺序。
		/// data: [
		/// 
		/// [
		///         {
		///             name: '两个屏幕坐标之间的标线',
		///             x: 100,
		///             y: 100
		///         },
		///         {
		///             x: 500,
		///             y: 200
		///         }
		///     ]
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesHeatmap_MarkLine_Data Data { get; set; }

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
	/// 系列中的数据内容数组。数组项通常为具体的数据项。
	/// 注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
	/// 可以使用 series.datasetIndex 指定其他的 dataset。
	/// 通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
	/// series: [{
	///     data: [
	///         // 维度X   维度Y   其他维度 ...
	///         [  3.4,    4.5,   15,   43],
	///         [  4.2,    2.3,   20,   91],
	///         [  10.8,   9.5,   30,   18],
	///         [  7.2,    8.8,   18,   57]
	///     ]
	/// }]
	/// 
	/// 
	/// 在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
	/// 在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
	/// 后面的其他维度是可选的，可以在别处被使用，例如：
	/// 在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
	/// 在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
	/// 使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
	/// 
	/// 
	/// 
	/// 特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
	/// xAxis: {
	///     data: ['a', 'b', 'm', 'n']
	/// },
	/// series: [{
	///     // 与 xAxis.data 一一对应。
	///     data: [23,  44,  55,  19]
	///     // 它其实是下面这种形式的简化：
	///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
	/// }]
	/// 
	/// 『值』与 轴类型 的关系：
	/// 
	/// 当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
	///   其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
	/// 
	/// 当某维度对应于类目轴（axis.type 为 'category'）的时候：
	///   其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
	///   xAxis: {
	///       type: 'category',
	///       data: ['星期一', '星期二', '星期三', '星期四']
	///   },
	///   yAxis: {
	///       type: 'category',
	///       data: ['a', 'b', 'm', 'n', 'p', 'q']
	///   },
	///   series: [{
	///       data: [
	///           // xAxis    yAxis
	///           [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
	///           [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
	///           [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
	///           [  3,        3,    5  ]
	///       ]
	///   }]
	/// 
	///   双类目轴的示例可以参考 Github Punchcard 示例。
	/// 
	/// 当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
	/// 
	/// 一个时间戳，如 1484141700832，表示 UTC 时间。
	/// 或者字符串形式的时间描述：
	/// ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
	/// 部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
	/// 使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
	/// 时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
	/// 
	/// 
	/// 其他的时间字符串，包括（均表示本地时间）:
	/// '2012', '2012-3-1', '2012/3/1', '2012/03/01',
	/// '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
	/// 
	/// 
	/// 或者用户自行初始化的 Date 实例：
	/// 注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
	/// 例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01') 表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
	/// 所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 当需要对个别数据进行个性化定义时：
	/// 数组项可用对象，其中的 value 像表示具体的数值，如：
	/// [
	///     12,
	///     34,
	///     {
	///         value : 56,
	///         //自定义标签样式，仅对该数据项有效
	///         label: {},
	///         //自定义特殊 itemStyle，仅对该数据项有效
	///         itemStyle:{}
	///     },
	///     10
	/// ]
	/// // 或
	/// [
	///     [12, 33],
	///     [34, 313],
	///     {
	///         value: [56, 44],
	///         label: {},
	///         itemStyle:{}
	///     },
	///     [10, 33]
	/// ]
	/// 
	/// 空值：
	/// 当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
	/// 例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
	/// </summary>
	public class SeriesHeatmap_MarkLine_Data
	{
		/// <summary>
		/// 起点的数据。
		/// </summary>
		[JsonProperty("0")]
		public SeriesPie_MarkLine_Data_D0 D0 { get; set; }

		/// <summary>
		/// 终点的数据。
		/// </summary>
		[JsonProperty("1")]
		public SeriesPie_MarkLine_Data_D0 D1 { get; set; }
	}


	/// <summary>
	/// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
	/// </summary>
	public class SeriesHeatmap_MarkArea
	{
		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 标域文本配置。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 该标域的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 高亮的标域样式
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 淡出的标域样式。淡出的规则跟随所在系列。
		/// </summary>
		[JsonProperty("blur")]
		public Blur2 Blur { get; set; }

		/// <summary>
		/// 标域的数据数组。每个数组项是一个两个项的数组，分别表示标域左上角和右下角的位置，每个项支持通过下面几种方式指定自己的位置
		/// 
		/// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
		/// 
		/// 当多个属性同时存在时，优先级按上述的顺序。
		/// data: [
		/// 
		/// [
		///         {
		///             name: '两个屏幕坐标之间的标域',
		///             x: 100,
		///             y: 100
		///         }, {
		///             x: '90%',
		///             y: '10%'
		///         }
		///     ]
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesHeatmap_MarkArea_Data Data { get; set; }

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
	/// 系列中的数据内容数组。数组项通常为具体的数据项。
	/// 注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
	/// 可以使用 series.datasetIndex 指定其他的 dataset。
	/// 通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
	/// series: [{
	///     data: [
	///         // 维度X   维度Y   其他维度 ...
	///         [  3.4,    4.5,   15,   43],
	///         [  4.2,    2.3,   20,   91],
	///         [  10.8,   9.5,   30,   18],
	///         [  7.2,    8.8,   18,   57]
	///     ]
	/// }]
	/// 
	/// 
	/// 在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
	/// 在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
	/// 后面的其他维度是可选的，可以在别处被使用，例如：
	/// 在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
	/// 在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
	/// 使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
	/// 
	/// 
	/// 
	/// 特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
	/// xAxis: {
	///     data: ['a', 'b', 'm', 'n']
	/// },
	/// series: [{
	///     // 与 xAxis.data 一一对应。
	///     data: [23,  44,  55,  19]
	///     // 它其实是下面这种形式的简化：
	///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
	/// }]
	/// 
	/// 『值』与 轴类型 的关系：
	/// 
	/// 当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
	///   其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
	/// 
	/// 当某维度对应于类目轴（axis.type 为 'category'）的时候：
	///   其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
	///   xAxis: {
	///       type: 'category',
	///       data: ['星期一', '星期二', '星期三', '星期四']
	///   },
	///   yAxis: {
	///       type: 'category',
	///       data: ['a', 'b', 'm', 'n', 'p', 'q']
	///   },
	///   series: [{
	///       data: [
	///           // xAxis    yAxis
	///           [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
	///           [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
	///           [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
	///           [  3,        3,    5  ]
	///       ]
	///   }]
	/// 
	///   双类目轴的示例可以参考 Github Punchcard 示例。
	/// 
	/// 当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
	/// 
	/// 一个时间戳，如 1484141700832，表示 UTC 时间。
	/// 或者字符串形式的时间描述：
	/// ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
	/// 部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
	/// 使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
	/// 时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
	/// 
	/// 
	/// 其他的时间字符串，包括（均表示本地时间）:
	/// '2012', '2012-3-1', '2012/3/1', '2012/03/01',
	/// '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
	/// 
	/// 
	/// 或者用户自行初始化的 Date 实例：
	/// 注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
	/// 例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01') 表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
	/// 所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 当需要对个别数据进行个性化定义时：
	/// 数组项可用对象，其中的 value 像表示具体的数值，如：
	/// [
	///     12,
	///     34,
	///     {
	///         value : 56,
	///         //自定义标签样式，仅对该数据项有效
	///         label: {},
	///         //自定义特殊 itemStyle，仅对该数据项有效
	///         itemStyle:{}
	///     },
	///     10
	/// ]
	/// // 或
	/// [
	///     [12, 33],
	///     [34, 313],
	///     {
	///         value: [56, 44],
	///         label: {},
	///         itemStyle:{}
	///     },
	///     [10, 33]
	/// ]
	/// 
	/// 空值：
	/// 当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
	/// 例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
	/// </summary>
	public class SeriesHeatmap_MarkArea_Data
	{
		/// <summary>
		/// 标域左上角的数据
		/// </summary>
		[JsonProperty("0")]
		public SeriesPie_MarkArea_Data_D0 D0 { get; set; }

		/// <summary>
		/// 标域右下角的数据
		/// </summary>
		[JsonProperty("1")]
		public SeriesPie_MarkArea_Data_D0 D1 { get; set; }
	}
}