using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// Candlestick 即我们常说的 K线图。
	/// 在 ECharts3 中，同时支持 'candlestick' 和 'k'这两种 'series.type'（'k' 会被自动转为 'candlestick'）。
	/// 示例如下：
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 关于『涨』『跌』的颜色：
	/// 不同国家或地区对于 K线图 的颜色定义不一样，可能是『红涨绿跌』或『红涨蓝跌』（如大陆、台湾、日本、韩国等），可能是『绿涨红跌』（如西方国家、香港、新加坡等）。K线图也不一定要用红蓝、红绿来表示涨跌，也可以是『有色/无色』等表示方法。
	/// 默认配置项，采用的是『红涨蓝跌』。如果想更改这个颜色配置，在这些配置项中更改即可：
	/// 
	/// series-candlestick.itemStyle.color：阳线填充色（即『涨』）
	/// series-candlestick.itemStyle.color0：阴线填充色（即『跌』）
	/// series-candlestick.itemStyle.borderColor：阳线边框色（即『涨』）
	/// series-candlestick.itemStyle.borderColor0：阴线边框色（即『跌』）
	/// series-candlestick.itemStyle.borderColorDoji：十字星边框色（即开盘价等于收盘价时候的边框色）
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesCandlestick
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "candlestick";

		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 该系列使用的坐标系，可选：
		/// 
		/// 'cartesian2d'
		///   使用二维的直角坐标系（也称笛卡尔坐标系），通过 xAxisIndex, yAxisIndex指定相应的坐标轴组件。
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
		/// 是否启用图例 hover 时的联动高亮。
		/// </summary>
		[JsonProperty("legendHoverLink")]
		public bool? LegendHoverLink { get; set; }

		/// <summary>
		/// 布局方式，可选值：
		/// 
		/// 'horizontal'：水平排布各个 box。
		/// 
		/// 'vertical'：竖直排布各个 box。
		/// 
		/// 
		/// 默认值根据当前坐标系状况决定：如果 category 轴为横轴，则水平排布；否则竖直排布；如果没有 category 轴则水平排布。
		/// </summary>
		[JsonProperty("layout")]
		public string Layout { get; set; }

		/// <summary>
		/// 指定柱宽度。可以使用绝对数值（如 10）或百分比（如 '20%'，表示 band width 的百分之多少）。默认自适应。
		/// </summary>
		[JsonProperty("barWidth")]
		public double? BarWidth { get; set; }

		/// <summary>
		/// 指定柱最小宽度。可以使用绝对数值（如 10）或百分比（如 '20%'，表示 band width 的百分之多少）。默认自适应。
		/// </summary>
		[JsonProperty("barMinWidth")]
		public StringOrNumber BarMinWidth { get; set; }

		/// <summary>
		/// 指定柱最大宽度。可以使用绝对数值（如 10）或百分比（如 '20%'，表示 band width 的百分之多少）。默认自适应。
		/// </summary>
		[JsonProperty("barMaxWidth")]
		public StringOrNumber BarMaxWidth { get; set; }

		/// <summary>
		/// K 线图的图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle9 ItemStyle { get; set; }

		/// <summary>
		/// K 线图的高亮状态。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesCandlestick_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// K 线图的淡出状态。开启 emphasis.focus 后有效
		/// </summary>
		[JsonProperty("blur")]
		public Blur11 Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// K 线图的选中状态。开启 selectedMode 后有效。
		/// </summary>
		[JsonProperty("select")]
		public Select9 Select { get; set; }

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
		/// 是否开启大数据量优化，在数据图形特别多而出现卡顿时候可以开启。
		/// 开启后配合 largeThreshold 在数据量大于指定阈值的时候对绘制进行优化。
		/// 缺点：优化后不能自定义设置单个数据项的样式。
		/// </summary>
		[JsonProperty("large")]
		public bool? Large { get; set; }

		/// <summary>
		/// 开启绘制优化的阈值。
		/// </summary>
		[JsonProperty("largeThreshold")]
		public double? LargeThreshold { get; set; }

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
		/// 分片的方式。可选值：
		/// 
		/// 'sequential': 按照数据的顺序分片。缺点是渲染过程不自然。
		/// 'mod': 取模分片，即每个片段中的点会遍布于整个数据，从而能够视觉上均匀得渲染。
		/// </summary>
		[JsonProperty("progressiveChunkMode")]
		public string ProgressiveChunkMode { get; set; }

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
		/// 数据格式是如下的二维数组。
		/// [
		///     [2320.26, 2320.26, 2287.3,  2362.94],
		///     [2300,    2291.3,  2288.26, 2308.38],
		///     { // 数据项也可以是 Object，从而里面能含有对此数据项的特殊设置。
		///         value: [2300,    2291.3,  2288.26, 2308.38],
		///         itemStyle: {...}
		///     },
		///     ...
		/// ]
		/// 
		/// 二维数组的每一数组项（上例中的每行）是渲染一个box，它含有四个量值，依次是：
		/// [open, close, lowest, highest] （即：[开盘值, 收盘值, 最低值, 最高值]）
		/// </summary>
		[JsonProperty("data")]
		public SeriesCandlestick_Data[] Data { get; set; }

		/// <summary>
		/// 图表标注。
		/// </summary>
		[JsonProperty("markPoint")]
		public SeriesCandlestick_MarkPoint MarkPoint { get; set; }

		/// <summary>
		/// 图表标线。
		/// </summary>
		[JsonProperty("markLine")]
		public SeriesPictorialBar_MarkLine MarkLine { get; set; }

		/// <summary>
		/// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
		/// </summary>
		[JsonProperty("markArea")]
		public SeriesPictorialBar_MarkArea MarkArea { get; set; }

		/// <summary>
		/// 从 v4.5.0 开始支持
		/// 
		/// 是否裁剪超出坐标系部分的图形，具体裁剪效果根据系列决定：
		/// 
		/// 散点图/带有涟漪特效动画的散点（气泡）图：忽略中心点超出坐标系的图形，但是不裁剪单个图形
		/// 柱状图：裁掉完全超出的柱子，但是不会裁剪只超出部分的柱子
		/// 折线图：裁掉所有超出坐标系的折线部分，拐点图形的逻辑按照散点图处理
		/// 路径图：裁掉所有超出坐标系的部分
		/// K 线图：忽略整体都超出坐标系的图形，但是不裁剪单个图形
		/// 象形柱图：裁掉所有超出坐标系的部分（从 v5.5.0 开始支持）
		/// 自定义系列：裁掉所有超出坐标系的部分
		/// 
		/// 除了象形柱图和自定义系列，其它系列的默认值都为 true，及开启裁剪，如果你觉得不想要裁剪的话，可以设置成 false 关闭。
		/// </summary>
		[JsonProperty("clip")]
		public bool? Clip { get; set; }

		/// <summary>
		/// K线图所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// K线图组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
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
	/// K 线图的图形样式。
	/// </summary>
	public class ItemStyle9
	{
		/// <summary>
		/// 阳线 图形的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 阴线 图形的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color0")]
		public Color Color0 { get; set; }

		/// <summary>
		/// 阳线 图形的描边颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 阴线 图形的描边颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("borderColor0")]
		public Color BorderColor0 { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 十字星（开盘价等于收盘价）的描边颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("borderColorDoji")]
		public Color BorderColorDoji { get; set; }

		/// <summary>
		/// candlestick 描边线宽。为 0 时无描边。
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
	/// K 线图的高亮状态。
	/// </summary>
	public class SeriesCandlestick_Emphasis
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
		public ItemStyle9 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// K 线图的淡出状态。开启 emphasis.focus 后有效
	/// </summary>
	public class Blur11
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle9 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// K 线图的选中状态。开启 selectedMode 后有效。
	/// </summary>
	public class Select9
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
		[JsonProperty("itemStyle")]
		public ItemStyle9 ItemStyle { get; set; }
	}

	/// <summary>
	/// 数据格式是如下的二维数组。
	/// [
	///     [2320.26, 2320.26, 2287.3,  2362.94],
	///     [2300,    2291.3,  2288.26, 2308.38],
	///     { // 数据项也可以是 Object，从而里面能含有对此数据项的特殊设置。
	///         value: [2300,    2291.3,  2288.26, 2308.38],
	///         itemStyle: {...}
	///     },
	///     ...
	/// ]
	/// 
	/// 二维数组的每一数组项（上例中的每行）是渲染一个box，它含有四个量值，依次是：
	/// [open, close, lowest, highest] （即：[开盘值, 收盘值, 最低值, 最高值]）
	/// </summary>
	public class SeriesCandlestick_Data
	{
		/// <summary>
		/// 数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 数据项值。
		/// [open, close, lowest, highest] （即：[开盘值, 收盘值, 最低值, 最高值]）
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
		/// 单个 K 线图数据的图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle9 ItemStyle { get; set; }

		/// <summary>
		/// 单个 K 线图数据的高亮状态配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Select9 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 单个 K 线图数据的淡出状态配置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur11 Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 单个 K 线图数据的选中状态配置。
		/// </summary>
		[JsonProperty("select")]
		public Select9 Select { get; set; }

		/// <summary>
		/// 本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// 图表标注。
	/// </summary>
	public class SeriesCandlestick_MarkPoint
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
		/// 
		/// 用 coord 属性指定数据在相应坐标系上的坐标位置，单个维度支持设置 'min', 'max', 'average'。
		/// 
		/// 直接用 type 属性标注系列中的最大值，最小值。这时候可以使用 valueIndex 或者 valueDim 指定是在哪个维度上的最大值、最小值、平均值。
		/// 
		/// 
		/// 当多个属性同时存在时，优先级按上述的顺序。
		/// 示例：
		/// data: [
		///     {
		///         name: '最大值',
		///         type: 'max'
		///     }, 
		///     {
		///         name: '某个坐标',
		///         coord: [10, 20]
		///     }, {
		///         name: '固定 x 像素位置',
		///         yAxis: 10,
		///         x: '90%'
		///     }, 
		/// 
		///     {
		///         name: '某个屏幕坐标',
		///         x: 100,
		///         y: 100
		///     }
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesLine_MarkPoint_Data Data { get; set; }

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
}