using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 漏斗图
	/// 示例：
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesFunnel
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
		/// 从 v5.2.0 开始支持
		/// 
		/// 从调色盘 option.color 中取色的策略，可取值为：
		/// 
		/// 'series'：按照系列分配调色盘中的颜色，同一系列中的所有数据都是用相同的颜色；
		/// 'data'：按照数据项分配调色盘中的颜色，每个数据项都使用不同的颜色。
		/// </summary>
		[JsonProperty("colorBy")]
		public string ColorBy { get; set; }

		/// <summary>
		/// 指定的数据最小值。
		/// </summary>
		[JsonProperty("min")]
		public double? Min { get; set; }

		/// <summary>
		/// 指定的数据最大值。
		/// </summary>
		[JsonProperty("max")]
		public double? Max { get; set; }

		/// <summary>
		/// 数据最小值 min 映射的宽度。
		/// 可以是绝对的像素大小，也可以是相对布局宽度的百分比，如果需要最小值的图形并不是尖端三角，可通过设置该属性实现。
		/// </summary>
		[JsonProperty("minSize")]
		public StringOrNumber MinSize { get; set; }

		/// <summary>
		/// 数据最大值 max 映射的宽度。
		/// 可以是绝对的像素大小，也可以是相对布局宽度的百分比。
		/// </summary>
		[JsonProperty("maxSize")]
		public StringOrNumber MaxSize { get; set; }

		/// <summary>
		/// 漏斗图朝向，支持配置为'vertical'或者'horizontal'。
		/// 
		/// 从 v4.9.0 开始支持
		/// </summary>
		[JsonProperty("orient")]
		public string Orient { get; set; }

		/// <summary>
		/// 数据排序， 可以取 'ascending'，'descending'，'none'（表示按 data 顺序），或者一个函数（即 Array.prototype.sort(function (a, b) { ... })）。
		/// </summary>
		[JsonProperty("sort")]
		public string Sort { get; set; }

		/// <summary>
		/// 数据图形间距。
		/// </summary>
		[JsonProperty("gap")]
		public double? Gap { get; set; }

		/// <summary>
		/// 是否启用图例 hover 时的联动高亮。
		/// </summary>
		[JsonProperty("legendHoverLink")]
		public bool? LegendHoverLink { get; set; }

		/// <summary>
		/// 水平方向对齐布局类型，默认居中对齐，可用选项还有：'left' | 'right' | 'center'
		/// </summary>
		[JsonProperty("funnelAlign")]
		public string FunnelAlign { get; set; }

		/// <summary>
		/// 漏斗图图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
		/// </summary>
		[JsonProperty("label")]
		public Label13 Label { get; set; }

		/// <summary>
		/// 标签的视觉引导线样式，在 label 位置 设置为'left'或者'right'的时候会显示视觉引导线。
		/// </summary>
		[JsonProperty("labelLine")]
		public LabelLine2 LabelLine { get; set; }

		/// <summary>
		/// 图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle0 ItemStyle { get; set; }

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
		/// 高亮的标签和图形样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesFunnel_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 淡出时的图形样式和标签样式。开启 emphasis.focus 后有效
		/// </summary>
		[JsonProperty("blur")]
		public Blur13 Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 数据选中时的图形样式和标签样式。开启 selectedMode 后有效。
		/// </summary>
		[JsonProperty("select")]
		public Select11 Select { get; set; }

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
		/// 漏斗图组件离容器左侧的距离。
		/// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		/// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 漏斗图组件离容器上侧的距离。
		/// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		/// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 漏斗图组件离容器右侧的距离。
		/// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 漏斗图组件离容器下侧的距离。
		/// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 漏斗图组件的宽度。默认自适应。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		/// 漏斗图组件的高度。默认自适应。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }

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
		/// 使用 dimensions 定义 series.data 或者 dataset.source 的每个维度的信息。
		/// 注意：如果使用了 dataset，那么可以在 dataset.dimensions 中定义 dimension ，或者在 dataset.source 的第一行/列中给出 dimension 名称。于是就不用在这里指定 dimension。但如果在这里指定了 dimensions，那么优先使用这里的。
		/// 例如：
		/// option = {
		///     dataset: {
		///         source: [
		///             // 有了上面 dimensions 定义后，下面这五个维度的名称分别为：
		///             // 'date', 'open', 'close', 'highest', 'lowest'
		///             [12, 44, 55, 66, 2],
		///             [23, 6, 16, 23, 1],
		///             ...
		///         ]
		///     },
		///     series: {
		///         type: 'xxx',
		///         // 定义了每个维度的名称。这个名称会被显示到默认的 tooltip 中。
		///         dimensions: ['date', 'open', 'close', 'highest', 'lowest']
		///     }
		/// }
		/// 
		/// series: {
		///     type: 'xxx',
		///     dimensions: [
		///         null,                // 如果此维度不想给出定义，则使用 null 即可
		///         {type: 'ordinal'},   // 只定义此维度的类型。
		///                              // 'ordinal' 表示离散型，一般文本使用这种类型。
		///                              // 如果类型没有被定义，会自动猜测类型。
		///         {name: 'good', type: 'number'},
		///         'bad'                // 等同于 {name: 'bad'}
		///     ]
		/// }
		/// 
		/// dimensions 数组中的每一项可以是：
		/// 
		/// string，如 'someName'，等同于 {name: 'someName'}
		/// Object，属性可以有：
		/// name: string。
		/// type: string，支持
		/// number，默认，表示普通数据。
		/// ordinal，对于类目、文本这些 string 类型的数据，如果需要能在数轴上使用，须是 'ordinal' 类型。ECharts 默认会自动判断这个类型。但是自动判断也是不可能很完备的，所以使用者也可以手动强制指定。
		/// float，即 Float64Array。
		/// int，即 Int32Array。
		/// time，表示时间类型。设置成 'time' 则能支持自动解析数据成时间戳（timestamp），比如该维度的数据是 '2017-05-10'，会自动被解析。时间类型的支持参见 data。
		/// 
		/// 
		/// displayName: 一般用于 tooltip 中维度名的展示。string 如果没有指定，默认使用 name 来展示。
		/// 
		/// 
		/// 
		/// 值得一提的是，当定义了 dimensions 后，默认 tooltip 中对个维度的显示，会变为『竖排』，从而方便显示每个维度的名称。如果没有定义 dimensions，则默认 tooltip 会横排显示，且只显示数值没有维度名称可显示。
		/// </summary>
		[JsonProperty("dimensions")]
		public double[] Dimensions { get; set; }

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
		/// 该系列所有数据项的组 ID，优先级低于groupId。详见series.data.groupId。
		/// </summary>
		[JsonProperty("dataGroupId")]
		public string DataGroupId { get; set; }

		/// <summary>
		/// 系列中的数据内容数组。数组项可以为单个数值，如：
		/// [12, 34, 56, 10, 23]
		/// 
		/// 如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
		/// [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
		/// 
		/// 这时候可以将每项数组中的第二个值指定给 visualMap 组件。
		/// 更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
		/// [{
		///     // 数据项的名称
		///     name: '数据1',
		///     // 数据项值8
		///     value: 10
		/// }, {
		///     name: '数据2',
		///     value: 20
		/// }]
		/// 
		/// 需要对个别内容指定进行个性化定义时：
		/// [{
		///     name: '数据1',
		///     value: 10
		/// }, {
		///     // 数据项名称
		///     name: '数据2',
		///     value : 56,
		///     //自定义特殊 tooltip，仅对该数据项有效
		///     tooltip:{},
		///     //自定义特殊itemStyle，仅对该item有效
		///     itemStyle:{}
		/// }]
		/// </summary>
		[JsonProperty("data")]
		public SeriesFunnel_Data[] Data { get; set; }

		/// <summary>
		/// 图表标注。
		/// </summary>
		[JsonProperty("markPoint")]
		public SeriesHeatmap_MarkPoint MarkPoint { get; set; }

		/// <summary>
		/// 图表标线。
		/// </summary>
		[JsonProperty("markLine")]
		public SeriesFunnel_MarkLine MarkLine { get; set; }

		/// <summary>
		/// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
		/// </summary>
		[JsonProperty("markArea")]
		public SeriesFunnel_MarkArea MarkArea { get; set; }

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
		/// 本系列特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// 标签的视觉引导线样式，在 label 位置 设置为'left'或者'right'的时候会显示视觉引导线。
	/// </summary>
	public class LabelLine2
	{
		/// <summary>
		/// 是否显示视觉引导线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 视觉引导线的长度。
		/// </summary>
		[JsonProperty("length")]
		public double? Length { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}

	/// <summary>
	/// 高亮的标签和图形样式。
	/// </summary>
	public class SeriesFunnel_Emphasis
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
		[JsonProperty("label")]
		public Label14 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 淡出时的图形样式和标签样式。开启 emphasis.focus 后有效
	/// </summary>
	public class Blur13
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label14 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 数据选中时的图形样式和标签样式。开启 selectedMode 后有效。
	/// </summary>
	public class Select11
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
		public Label14 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}

	/// <summary>
	/// 漏斗图图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	public class Label14
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

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
		///     color: string,
		///     // 百分比
		///     percent: number
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
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
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
	/// 系列中的数据内容数组。数组项可以为单个数值，如：
	/// [12, 34, 56, 10, 23]
	/// 
	/// 如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
	/// [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
	/// 
	/// 这时候可以将每项数组中的第二个值指定给 visualMap 组件。
	/// 更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	/// [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值8
	///     value: 10
	/// }, {
	///     name: '数据2',
	///     value: 20
	/// }]
	/// 
	/// 需要对个别内容指定进行个性化定义时：
	/// [{
	///     name: '数据1',
	///     value: 10
	/// }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : 56,
	///     //自定义特殊 tooltip，仅对该数据项有效
	///     tooltip:{},
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	/// }]
	/// </summary>
	public class SeriesFunnel_Data
	{
		/// <summary>
		/// 数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 数据值。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public SeriesFunnel_Data_ItemStyle ItemStyle { get; set; }

		/// <summary>
		/// 单个数据的标签配置。
		/// </summary>
		[JsonProperty("label")]
		public SeriesFunnel_Data_Label Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("labelLine")]
		public LabelLine2 LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Select11 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public Blur13 Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("select")]
		public Select11 Select { get; set; }

		/// <summary>
		/// 本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// 图形样式。
	/// </summary>
	public class SeriesFunnel_Data_ItemStyle
	{
		/// <summary>
		/// 该数据项的高度。默认平均分配高度，如果需要修改，可以将其设为百分比（如：'10%'）或像素值（如：20px）。需要注意总和应为 100%。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }

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
		/// 图形的贴花图案，在 aria.enabled 与 aria.decal.show 都是 true 的情况下才生效。
		/// 如果为 'none' 表示不使用贴花图案。
		/// </summary>
		[JsonProperty("decal")]
		public Decal0 Decal { get; set; }
	}

	/// <summary>
	/// 漏斗图图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	public class SeriesFunnel_Data_Label
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签的位置。
		/// 可选：
		/// 
		/// 'left' 漏斗图左侧，orient 为'vertical'时有效。
		/// 'right' 漏斗图右侧，orient 为'vertical'时有效。
		/// 'top' 漏斗图上侧，orient 为'horizontal'时有效。
		/// 'bottom' 漏斗图下侧，orient 为'horizontal'时有效。
		/// 'inside' 漏斗图梯形内部。
		/// 'insideRight' 漏斗图梯形内部右侧。
		/// 'insideLeft' 漏斗图梯形内部左侧。
		/// 'leftTop' 漏斗图左侧上部。
		/// 'leftBottom'  漏斗图左侧下部。
		/// 'rightTop'  漏斗图右侧上部。
		/// 'rightBottom'  漏斗图右侧下部。
		/// 'inner' 同 'inside'。
		/// 'center' 同 'inside'。
		/// 
		/// 在不是配置为内部的时候标签可以通过视觉引导线连到相应的梯形。
		/// 通过视觉引导线连到相应的梯形。
		/// </summary>
		[JsonProperty("position")]
		public string Position { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 用于控制标签之间的最小距离，当启用 labelLayout 时可能会用到。
		/// </summary>
		[JsonProperty("minMargin")]
		public double? MinMargin { get; set; }

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
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
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
	/// 图表标线。
	/// </summary>
	public class SeriesFunnel_MarkLine
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
		public SeriesFunnel_MarkLine_Data Data { get; set; }

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
	/// 系列中的数据内容数组。数组项可以为单个数值，如：
	/// [12, 34, 56, 10, 23]
	/// 
	/// 如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
	/// [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
	/// 
	/// 这时候可以将每项数组中的第二个值指定给 visualMap 组件。
	/// 更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	/// [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值8
	///     value: 10
	/// }, {
	///     name: '数据2',
	///     value: 20
	/// }]
	/// 
	/// 需要对个别内容指定进行个性化定义时：
	/// [{
	///     name: '数据1',
	///     value: 10
	/// }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : 56,
	///     //自定义特殊 tooltip，仅对该数据项有效
	///     tooltip:{},
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	/// }]
	/// </summary>
	public class SeriesFunnel_MarkLine_Data
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
	public class SeriesFunnel_MarkArea
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
		public SeriesFunnel_MarkArea_Data Data { get; set; }

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
	/// 系列中的数据内容数组。数组项可以为单个数值，如：
	/// [12, 34, 56, 10, 23]
	/// 
	/// 如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
	/// [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
	/// 
	/// 这时候可以将每项数组中的第二个值指定给 visualMap 组件。
	/// 更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	/// [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值8
	///     value: 10
	/// }, {
	///     name: '数据2',
	///     value: 20
	/// }]
	/// 
	/// 需要对个别内容指定进行个性化定义时：
	/// [{
	///     name: '数据1',
	///     value: 10
	/// }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : 56,
	///     //自定义特殊 tooltip，仅对该数据项有效
	///     tooltip:{},
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	/// }]
	/// </summary>
	public class SeriesFunnel_MarkArea_Data
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