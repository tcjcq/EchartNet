using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 这个组件是平行坐标系中的坐标轴。
	/// 平行坐标系介绍
	/// 平行坐标系（Parallel Coordinates） 是一种常用的可视化高维数据的图表。
	/// 例如 series-parallel.data 中有如下数据：
	/// [
	///     [1,  55,  9,   56,  0.46,  18,  6,  '良'],
	///     [2,  25,  11,  21,  0.65,  34,  9,  '优'],
	///     [3,  56,  7,   63,  0.3,   14,  5,  '良'],
	///     [4,  33,  7,   29,  0.33,  16,  6,  '优'],
	///     { // 数据项也可以是 Object，从而里面能含有对线条的特殊设置。
	///         value: [5,  42,  24,  44,  0.76,  40,  16, '优']
	///         lineStyle: {...},
	///     }
	///     ...
	/// ]
	/// 
	/// 数据中，每一行是一个『数据项』，每一列属于一个『维度』。（例如上面数据每一列的含义分别是：『日期』,『AQI指数』, 『PM2.5』, 『PM10』, 『一氧化碳值』, 『二氧化氮值』, 『二氧化硫值』）。
	/// 平行坐标系适用于对这种多维数据进行可视化分析。每一个维度（每一列）对应一个坐标轴，每一个『数据项』是一条线，贯穿多个坐标轴。在坐标轴上，可以进行数据选取等操作。如下：
	/// 
	/// 
	/// 
	/// 配置方式概要
	/// 『平行坐标系』的 option 基本配置如下例：
	/// option = {
	///     parallelAxis: [                     // 这是一个个『坐标轴』的定义
	///         {dim: 0, name: schema[0].text}, // 每个『坐标轴』有个 'dim' 属性，表示坐标轴的维度号。
	///         {dim: 1, name: schema[1].text},
	///         {dim: 2, name: schema[2].text},
	///         {dim: 3, name: schema[3].text},
	///         {dim: 4, name: schema[4].text},
	///         {dim: 5, name: schema[5].text},
	///         {dim: 6, name: schema[6].text},
	///         {dim: 7, name: schema[7].text,
	///             type: 'category',           // 坐标轴也可以支持类别型数据
	///             data: ['优', '良', '轻度污染', '中度污染', '重度污染', '严重污染']
	///         }
	///     ],
	///     parallel: {                         // 这是『坐标系』的定义
	///         left: '5%',                     // 平行坐标系的位置设置
	///         right: '13%',
	///         bottom: '10%',
	///         top: '20%',
	///         parallelAxisDefault: {          // 『坐标轴』的公有属性可以配置在这里避免重复书写
	///             type: 'value',
	///             nameLocation: 'end',
	///             nameGap: 20
	///         }
	///     },
	///     series: [                           // 这里三个系列共用一个平行坐标系
	///         {
	///             name: '北京',
	///             type: 'parallel',           // 这个系列类型是 'parallel'
	///             data: [
	///                 [1,  55,  9,   56,  0.46,  18,  6,  '良'],
	///                 [2,  25,  11,  21,  0.65,  34,  9,  '优'],
	///                 ...
	///             ]
	///         },
	///         {
	///             name: '上海',
	///             type: 'parallel',
	///             data: [
	///                 [3,  56,  7,   63,  0.3,   14,  5,  '良'],
	///                 [4,  33,  7,   29,  0.33,  16,  6,  '优'],
	///                 ...
	///             ]
	///         },
	///         {
	///             name: '广州',
	///             type: 'parallel',
	///             data: [
	///                 [4,  33,  7,   29,  0.33,  16,  6,  '优'],
	///                 [5,  42,  24,  44,  0.76,  40,  16, '优'],
	///                 ...
	///             ]
	///         }
	///     ]
	/// };
	/// 
	/// 需要涉及到三个组件：parallel、parallelAxis、series-parallel
	/// 
	/// parallel
	///   这个配置项是平行坐标系的『坐标系』本身。一个系列（series）或多个系列（如上图中的『北京』、『上海』、『广州』分别各是一个系列）可以共用这个『坐标系』。
	///   和其他坐标系一样，坐标系也可以创建多个。
	///   位置设置，也是放在这里进行。
	/// 
	/// parallelAxis
	///   这个是『坐标系』中的坐标轴的配置。自然，需要有多个坐标轴。
	///   其中有 parallelAxis.parallelIndex 属性，指定这个『坐标轴』在哪个『坐标系』中。默认使用第一个『坐标系』。
	/// 
	/// series-parallel
	///   这个是『系列』的定义。系列被画到『坐标系』上。
	///   其中有 series-parallel.parallelIndex 属性，指定使用哪个『坐标系』。默认使用第一个『坐标系』。
	/// 
	/// 
	/// 配置注意和最佳实践
	/// 配置多个 parallelAxis 时，有些值一样的属性，如果书写多遍则比较繁琐，那么可以放置在 parallel.parallelAxisDefault 里。在坐标轴初始化前，parallel.parallelAxisDefault 里的配置项，会分别融合进 parallelAxis，形成最终的坐标轴的配置。
	/// 如果数据量很大并且发生卡顿
	/// 建议把 series-parallel.lineStyle.width 设为 0.5（或更小），
	/// 可能显著改善性能。
	/// 高维数据的显示
	/// 维度比较多时，比如有 50+ 的维度，那么就会有 50+ 个轴。那么可能会页面显示不下。
	/// 可以通过 parallel.axisExpandable 来改善显示效果。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class ParallelAxis
	{
		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 坐标轴的维度序号。
		/// 例如 series-parallel.data 中有如下数据：
		/// [
		///     [1,  55,  9,   56,  0.46,  18,  6,  '良'],
		///     [2,  25,  11,  21,  0.65,  34,  9,  '优'],
		///     [3,  56,  7,   63,  0.3,   14,  5,  '良'],
		///     [4,  33,  7,   29,  0.33,  16,  6,  '优'],
		///     { // 数据项也可以是 Object，从而里面能含有对线条的特殊设置。
		///         value: [5,  42,  24,  44,  0.76,  40,  16, '优']
		///         lineStyle: {...},
		///     }
		///     ...
		/// ]
		/// 
		/// 数据中，每一行是一个『数据项』，每一列属于一个『维度』。（例如上面数据每一列的含义分别是：『日期』,『AQI指数』, 『PM2.5』, 『PM10』, 『一氧化碳值』, 『二氧化氮值』, 『二氧化硫值』）。
		/// dim 定义了数据的哪个维度（即哪个『列』）会对应到此坐标轴上。
		/// 从 0 开始计数。例如，假设坐标轴的 dim 为 1，则表示数据中的第二列会对应到此坐标轴上。
		/// </summary>
		[JsonProperty("dim")]
		public double? Dim { get; set; }

		/// <summary>
		/// 用于定义『坐标轴』对应到哪个『坐标系』中。
		/// 比如有如下配置：
		/// myChart.setOption({
		///     parallel: [
		///         {...},                      // 第一个平行坐标系
		///         {...}                       // 第二个平行坐标系
		///     ],
		///     parallelAxis: [
		///         {parallelIndex: 1, ...},    // 第一个坐标轴，对应到第二个平行坐标系
		///         {parallelIndex: 0, ...},    // 第二个坐标轴，对应到第一个平行坐标系
		///         {parallelIndex: 1, ...},    // 第三个坐标轴，对应到第二个平行坐标系
		///         {parallelIndex: 0, ...}     // 第四个坐标轴，对应到第一个平行坐标系
		///     ],
		///     ...
		/// });
		/// 
		/// 只有一个平行坐标系时可不用设置，自动取默认值 0。
		/// </summary>
		[JsonProperty("parallelIndex")]
		public double? ParallelIndex { get; set; }

		/// <summary>
		/// 是否坐标轴刷选的时候，实时刷新视图。如果设为 false，则在刷选动作结束时候，才刷新视图。
		/// 大数据量时，建议设置成 false，从而避免卡顿。
		/// </summary>
		[JsonProperty("realtime")]
		public bool? Realtime { get; set; }

		/// <summary>
		/// 在坐标轴上可以进行框选，这里是一些框选的设置。
		/// </summary>
		[JsonProperty("areaSelectStyle")]
		public ParallelAxis_AreaSelectStyle AreaSelectStyle { get; set; }

		/// <summary>
		/// 坐标轴类型。
		/// 可选：
		/// 
		/// 'value'
		///   数值轴，适用于连续数据。
		/// 
		/// 'category'
		///   类目轴，适用于离散的类目数据。为该类型时类目数据可自动从 series.data 或 dataset.source 中取，或者可通过 parallelAxis.data 设置类目数据。
		/// 
		/// 'time'
		///   时间轴，适用于连续的时序数据，与数值轴相比时间轴带有时间的格式化，在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
		/// 
		/// 'log'
		///   对数轴。适用于对数数据。对数轴下的堆积柱状图或堆积折线图可能带来很大的视觉误差，并且在一定情况下可能存在非预期效果，应避免使用。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "value";

		/// <summary>
		/// 坐标轴名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 坐标轴名称显示位置。
		/// 可选：
		/// 
		/// 'start'
		/// 'middle' 或者 'center'
		/// 'end'
		/// </summary>
		[JsonProperty("nameLocation")]
		public string NameLocation { get; set; }

		/// <summary>
		/// 坐标轴名称的文字样式。
		/// </summary>
		[JsonProperty("nameTextStyle")]
		public NameTextStyle0 NameTextStyle { get; set; }

		/// <summary>
		/// 坐标轴名称与轴线之间的距离。
		/// </summary>
		[JsonProperty("nameGap")]
		public double? NameGap { get; set; }

		/// <summary>
		/// 坐标轴名字旋转，角度值。
		/// </summary>
		[JsonProperty("nameRotate")]
		public double? NameRotate { get; set; }

		/// <summary>
		/// 坐标轴名字的截断。
		/// </summary>
		[JsonProperty("nameTruncate")]
		public XAxis_NameTruncate NameTruncate { get; set; }

		/// <summary>
		/// 是否是反向坐标轴。
		/// </summary>
		[JsonProperty("inverse")]
		public bool? Inverse { get; set; }

		/// <summary>
		/// 坐标轴两边留白策略，类目轴和非类目轴的设置和表现不一样。
		/// 类目轴中 boundaryGap 可以配置为 true 和 false。默认为 true，这时候刻度只是作为分隔线，标签和数据点都会在两个刻度之间的带(band)中间。
		/// 非类目轴，包括时间，数值，对数轴，boundaryGap是一个两个值的数组，分别表示数据最小值和最大值的延伸范围，可以直接设置数值或者相对的百分比，在设置 min 和 max 后无效。
		/// 示例：
		/// boundaryGap: ['20%', '20%']
		/// </summary>
		[JsonProperty("boundaryGap")]
		public ArrayOrSingle BoundaryGap { get; set; }

		/// <summary>
		/// 坐标轴刻度最小值。
		/// 可以设置成特殊值 'dataMin'，此时取数据在该轴上的最小值作为最小刻度。
		/// 不设置时会自动计算最小值保证坐标轴刻度的均匀分布。
		/// 在类目轴中，也可以设置为类目的序数（如类目轴 data: ['类A', '类B', '类C'] 中，序数 2 表示 '类C'。也可以设置为负数，如 -3）。
		/// 当设置成 function 形式时，可以根据计算得出的数据最大最小值设定坐标轴的最小值。如：
		/// min: function (value) {
		///     return value.min - 20;
		/// }
		/// 
		/// 其中 value 是一个包含 min 和 max 的对象，分别表示数据的最大最小值，这个函数可返回坐标轴的最小值，也可返回 null/undefined 来表示“自动计算最小值”（返回 null/undefined 从 v4.8.0 开始支持）。
		/// </summary>
		[JsonProperty("min")]
		public StringOrNumber Min { get; set; }

		/// <summary>
		/// 坐标轴刻度最大值。
		/// 可以设置成特殊值 'dataMax'，此时取数据在该轴上的最大值作为最大刻度。
		/// 不设置时会自动计算最大值保证坐标轴刻度的均匀分布。
		/// 在类目轴中，也可以设置为类目的序数（如类目轴 data: ['类A', '类B', '类C'] 中，序数 2 表示 '类C'。也可以设置为负数，如 -3）。
		/// 当设置成 function 形式时，可以根据计算得出的数据最大最小值设定坐标轴的最小值。如：
		/// max: function (value) {
		///     return value.max - 20;
		/// }
		/// 
		/// 其中 value 是一个包含 min 和 max 的对象，分别表示数据的最大最小值，这个函数可返回坐标轴的最大值，也可返回 null/undefined 来表示“自动计算最大值”（返回 null/undefined 从 v4.8.0 开始支持）。
		/// </summary>
		[JsonProperty("max")]
		public StringOrNumber Max { get; set; }

		/// <summary>
		/// 只在数值轴中（type: 'value'）有效。
		/// 是否是脱离 0 值比例。设置成 true 后坐标刻度不会强制包含零刻度。在双数值轴的散点图中比较有用。
		/// 在设置 min 和 max 之后该配置项无效。
		/// </summary>
		[JsonProperty("scale")]
		public bool? Scale { get; set; }

		/// <summary>
		/// 坐标轴的分割段数，需要注意的是这个分割段数只是个预估值，最后实际显示的段数会在这个基础上根据分割后坐标轴刻度显示的易读程度作调整。
		/// 在类目轴中无效。
		/// </summary>
		[JsonProperty("splitNumber")]
		public double? SplitNumber { get; set; }

		/// <summary>
		/// 自动计算的坐标轴最小间隔大小。
		/// 例如可以设置成1保证坐标轴分割刻度显示成整数。
		/// {
		///     minInterval: 1
		/// }
		/// 
		/// 只在数值轴或时间轴中（type: 'value' 或 'time'）有效。
		/// </summary>
		[JsonProperty("minInterval")]
		public double? MinInterval { get; set; }

		/// <summary>
		/// 自动计算的坐标轴最大间隔大小。
		/// 例如，在时间轴（（type: 'time'））可以设置成 3600 * 24 * 1000 保证坐标轴分割刻度最大为一天。
		/// {
		///     maxInterval: 3600 * 24 * 1000
		/// }
		/// 
		/// 只在数值轴或时间轴中（type: 'value' 或 'time'）有效。
		/// </summary>
		[JsonProperty("maxInterval")]
		public double? MaxInterval { get; set; }

		/// <summary>
		/// 强制设置坐标轴分割间隔。
		/// 因为 splitNumber 是预估的值，实际根据策略计算出来的刻度可能无法达到想要的效果，这时候可以使用 interval 配合 min、max 强制设定刻度划分，一般不建议使用。
		/// 无法在类目轴中使用。在时间轴（type: 'time'）中需要传时间戳，在对数轴（type: 'log'）中需要传指数值。
		/// </summary>
		[JsonProperty("interval")]
		public double? Interval { get; set; }

		/// <summary>
		/// 对数轴的底数，只在对数轴中（type: 'log'）有效。
		/// </summary>
		[JsonProperty("logBase")]
		public double? LogBase { get; set; }

		/// <summary>
		/// 从 v5.5.1 开始支持
		/// 
		/// 用于指定轴的起始值。
		/// </summary>
		[JsonProperty("startValue")]
		public double? StartValue { get; set; }

		/// <summary>
		/// 坐标轴是否是静态无法交互。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 坐标轴的标签是否响应和触发鼠标事件，默认不响应。
		/// 事件参数如下：
		/// {
		///     // 组件类型，xAxis, yAxis, radiusAxis, angleAxis
		///     // 对应组件类型都会有一个属性表示组件的 index，例如 xAxis 就是 xAxisIndex
		///     componentType: string,
		///     // 未格式化过的刻度值, 点击刻度标签有效
		///     value: '',
		///     // 坐标轴名称, 点击坐标轴名称有效
		///     name: ''
		/// }
		/// </summary>
		[JsonProperty("triggerEvent")]
		public bool? TriggerEvent { get; set; }

		/// <summary>
		/// 坐标轴轴线相关设置。
		/// </summary>
		[JsonProperty("axisLine")]
		public RadiusAxis_AxisLine AxisLine { get; set; }

		/// <summary>
		/// 坐标轴刻度相关设置。
		/// </summary>
		[JsonProperty("axisTick")]
		public AxisTick0 AxisTick { get; set; }

		/// <summary>
		/// 从 v4.6.0 开始支持
		/// 
		/// 坐标轴次刻度线相关设置。
		/// 注意：次刻度线无法在类目轴（type: 'category'）中使用。
		/// 示例：
		/// 1) 函数绘图中使用次刻度线
		/// 
		/// 
		/// 
		/// 2) 在对数轴中使用次刻度线
		/// </summary>
		[JsonProperty("minorTick")]
		public XAxis_MinorTick MinorTick { get; set; }

		/// <summary>
		/// 坐标轴刻度标签的相关设置。
		/// </summary>
		[JsonProperty("axisLabel")]
		public RadiusAxis_AxisLabel AxisLabel { get; set; }

		/// <summary>
		/// 类目数据，在类目轴（type: 'category'）中有效。
		/// 如果没有设置 type，但是设置了 axis.data，则认为 type 是 'category'。
		/// 如果设置了 type 是 'category'，但没有设置 axis.data，则 axis.data 的内容会自动从 series.data 中获取，这会比较方便。不过注意，axis.data 指明的是 'category' 轴的取值范围。如果不指定而是从 series.data 中获取，那么只能获取到 series.data 中出现的值。比如说，假如 series.data 为空时，就什么也获取不到。
		/// 示例：
		/// // 所有类目名称列表
		/// data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
		/// // 每一项也可以是具体的配置项，此时取配置项中的 `value` 为类目名
		/// data: [{
		///     value: '周一',
		///     // 突出周一
		///     textStyle: {
		///         fontSize: 20,
		///         color: 'red'
		///     }
		/// }, '周二', '周三', '周四', '周五', '周六', '周日']
		/// </summary>
		[JsonProperty("data")]
		public XAxis_Data Data { get; set; }

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
	/// 在坐标轴上可以进行框选，这里是一些框选的设置。
	/// </summary>
	public class ParallelAxis_AreaSelectStyle
	{
		/// <summary>
		/// 框选范围的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 选框的边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 选框的边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 选框的填充色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 选框的透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }
	}
}