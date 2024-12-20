using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 直角坐标系 grid 中的 x 轴，一般情况下单个 grid 组件最多只能放上下两个 x 轴，多于两个 x 轴需要通过配置 offset 属性防止同个位置多个 x 轴的重叠。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class XAxis
	{
		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 是否显示 x 轴。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// x 轴所在的 grid 的索引，默认位于第一个 grid。
		/// </summary>
		[JsonProperty("gridIndex")]
		public double? GridIndex { get; set; }

		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 在多个 x 轴为数值轴的时候，可以开启该配置项自动对齐刻度。只对'value'和'log'类型的轴有效。
		/// </summary>
		[JsonProperty("alignTicks")]
		public bool? AlignTicks { get; set; }

		/// <summary>
		/// x 轴的位置。
		/// 可选：
		/// 
		/// 'top'
		/// 'bottom'
		/// 
		/// 默认 grid 中的第一个 x 轴在 grid 的下方（'bottom'），第二个 x 轴视第一个 x 轴的位置放在另一侧。注：若未将 xAxis.axisLine.onZero 设为 false , 则该项无法生效
		/// </summary>
		[JsonProperty("position")]
		public string Position { get; set; }

		/// <summary>
		/// X 轴相对于默认位置的偏移，在相同的 position 上有多个 X 轴的时候有用。注：若未将 xAxis.axisLine.onZero 设为 false , 则该项无法生效
		/// </summary>
		[JsonProperty("offset")]
		public double? Offset { get; set; }

		/// <summary>
		/// 坐标轴类型。
		/// 可选：
		/// 
		/// 'value'
		///   数值轴，适用于连续数据。
		/// 
		/// 'category'
		///   类目轴，适用于离散的类目数据。为该类型时类目数据可自动从 series.data 或 dataset.source 中取，或者可通过 xAxis.data 设置类目数据。
		/// 
		/// 'time'
		///   时间轴，适用于连续的时序数据，与数值轴相比时间轴带有时间的格式化，在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
		/// 
		/// 'log'
		///   对数轴。适用于对数数据。对数轴下的堆积柱状图或堆积折线图可能带来很大的视觉误差，并且在一定情况下可能存在非预期效果，应避免使用。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "category";

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
		public XAxis_AxisLine AxisLine { get; set; }

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
		public XAxis_AxisLabel AxisLabel { get; set; }

		/// <summary>
		/// 坐标轴在 grid 区域中的分隔线。
		/// </summary>
		[JsonProperty("splitLine")]
		public XAxis_SplitLine SplitLine { get; set; }

		/// <summary>
		/// 从 v4.6.0 开始支持
		/// 
		/// 坐标轴在 grid 区域中的次分隔线。次分割线会对齐次刻度线 minorTick
		/// </summary>
		[JsonProperty("minorSplitLine")]
		public XAxis_MinorSplitLine MinorSplitLine { get; set; }

		/// <summary>
		/// 坐标轴在 grid 区域中的分隔区域，默认不显示。
		/// </summary>
		[JsonProperty("splitArea")]
		public XAxis_SplitArea SplitArea { get; set; }

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
		public XAxis_Data[] Data { get; set; }

		/// <summary>
		/// 坐标轴指示器配置项。
		/// </summary>
		[JsonProperty("axisPointer")]
		public SingleAxis_AxisPointer AxisPointer { get; set; }

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
		/// X 轴所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// X 轴组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// z相比zlevel优先级更低，而且不会创建新的 Canvas。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }
	}

	/// <summary>
	/// 坐标轴名称的文字样式。
	/// </summary>
	public class NameTextStyle0
	{
		/// <summary>
		/// 坐标轴名称的颜色，默认取 axisLine.lineStyle.color。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 坐标轴名称文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 坐标轴名称文字字体的粗细。
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
		/// 坐标轴名称文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 坐标轴名称文字的字体大小。
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
	/// 坐标轴名字的截断。
	/// </summary>
	public class XAxis_NameTruncate
	{
		/// <summary>
		/// 截断文本的最大长度，超过此长度会被截断。
		/// </summary>
		[JsonProperty("maxWidth")]
		public double? MaxWidth { get; set; }

		/// <summary>
		/// 截断后文字末尾显示的内容。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }
	}

	/// <summary>
	/// 坐标轴轴线相关设置。
	/// </summary>
	public class XAxis_AxisLine
	{
		/// <summary>
		/// 是否显示坐标轴轴线。
		/// 
		/// 从 v5.0.0 开始，数值轴 (type: 'value') 默认不显示轴线，需要显式配置。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// X 轴或者 Y 轴的轴线是否在另一个轴的 0 刻度上，只有在另一个轴为数值轴且包含 0 刻度时有效。
		/// </summary>
		[JsonProperty("onZero")]
		public bool? OnZero { get; set; }

		/// <summary>
		/// 当有双轴时，可以用这个属性手动指定，在哪个轴的 0 刻度上。
		/// </summary>
		[JsonProperty("onZeroAxisIndex")]
		public double? OnZeroAxisIndex { get; set; }

		/// <summary>
		/// 轴线两边的箭头。可以是字符串，表示两端使用同样的箭头；或者长度为 2 的字符串数组，分别表示两端的箭头。默认不显示箭头，即 'none'。两端都显示箭头可以设置为 'arrow'，只在末端显示箭头可以设置为 ['none', 'arrow']。
		/// </summary>
		[JsonProperty("symbol")]
		public ArrayOrSingle Symbol { get; set; }

		/// <summary>
		/// 轴线两边的箭头的大小，第一个数字表示宽度（垂直坐标轴方向），第二个数字表示高度（平行坐标轴方向）。
		/// </summary>
		[JsonProperty("symbolSize")]
		public double[] SymbolSize { get; set; }

		/// <summary>
		/// 轴线两边的箭头的偏移，如果是数组，第一个数字表示起始箭头的偏移，第二个数字表示末端箭头的偏移；如果是数字，表示这两个箭头使用同样的偏移。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public ArrayOrSingle SymbolOffset { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}

	/// <summary>
	/// 坐标轴刻度相关设置。
	/// </summary>
	public class AxisTick0
	{
		/// <summary>
		/// 是否显示坐标轴刻度。
		/// 
		/// 从 v5.0.0 开始，数值轴 (type: 'value') 默认不显示轴刻度，需要显式配置。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 类目轴中在 boundaryGap 为 true 的时候有效，可以保证刻度线和标签对齐。如下图：
		/// </summary>
		[JsonProperty("alignWithLabel")]
		public bool? AlignWithLabel { get; set; }

		/// <summary>
		/// 坐标轴刻度的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
		/// 默认会采用标签不重叠的策略间隔显示标签。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示隔两个标签显示一个标签，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 坐标轴刻度是否朝内，默认朝外。
		/// </summary>
		[JsonProperty("inside")]
		public bool? Inside { get; set; }

		/// <summary>
		/// 坐标轴刻度的长度。
		/// </summary>
		[JsonProperty("length")]
		public double? Length { get; set; }

		/// <summary>
		/// 刻度线的样式设置。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// 从 v5.5.1 开始支持
		/// 
		/// 自定义要显示的坐标轴刻度位置。例如：
		/// axisTick: {
		///     alignWithLabel: true,
		///     customValues: [0, 0.5, 1, 1.5, 2, 8, 9]
		/// }
		/// </summary>
		[JsonProperty("customValues")]
		public double[] CustomValues { get; set; }
	}

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
	public class XAxis_MinorTick
	{
		/// <summary>
		/// 是否显示次刻度线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 次刻度线分割数，默认会分割成 5 段
		/// </summary>
		[JsonProperty("splitNumber")]
		public double? SplitNumber { get; set; }

		/// <summary>
		/// 次刻度线的长度。
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
	/// 坐标轴刻度标签的相关设置。
	/// </summary>
	public class XAxis_AxisLabel
	{
		/// <summary>
		/// 是否显示刻度标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 坐标轴刻度标签的显示间隔，在类目轴中有效。
		/// 默认会采用标签不重叠的策略间隔显示标签。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示隔两个标签显示一个标签，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 刻度标签是否朝内，默认朝外。
		/// </summary>
		[JsonProperty("inside")]
		public bool? Inside { get; set; }

		/// <summary>
		/// 刻度标签旋转的角度，在类目轴的类目标签显示不下的时候可以通过旋转防止标签之间重叠。
		/// 旋转的角度从 -90 度到 90 度。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 刻度标签与轴线之间的距离。
		/// </summary>
		[JsonProperty("margin")]
		public double? Margin { get; set; }

		/// <summary>
		/// 刻度标签的内容格式器，支持字符串模板和回调函数两种形式。
		/// 示例:
		/// // 使用字符串模板，模板变量为刻度默认标签 {value}
		/// formatter: '{value} kg'
		/// // 使用函数模板，函数参数分别为刻度数值（类目），刻度的索引
		/// formatter: function (value, index) {
		///     return value + 'kg';
		/// }
		/// 
		/// 
		/// 对于时间轴（type: 'time'），formatter 的字符串模板支持多种形式：
		/// 
		/// 字符串模板：简单快速实现常用日期时间模板，string 类型
		/// 回调函数：自定义 formatter，可以用来实现复杂高级的格式，Function 类型
		/// 分级模板：为不同时间粒度的标签使用不同的 formatter，object 类型
		/// 
		/// 下面我们分别介绍这三种形式。
		///  字符串模板 
		/// 使用字符串模板是一种方便实现常用日期时间格式化方式的形式。如果字符串模板可以实现你的效果，那我们优先推荐使用此方式；如果无法实现，再考虑其他两种更复杂的方式。支持的模板如下：
		/// 
		/// 
		/// 
		/// 分类
		/// 模板
		/// 取值（英文）
		/// 取值（中文）
		/// 
		/// 
		/// 
		/// 
		/// Year
		/// {yyyy}
		/// e.g., 2020, 2021, ...
		/// 例：2020, 2021, ...
		/// 
		/// 
		/// 
		/// {yy}
		/// 00-99
		/// 00-99
		/// 
		/// 
		/// Quarter
		/// {Q}
		/// 1, 2, 3, 4
		/// 1, 2, 3, 4
		/// 
		/// 
		/// Month
		/// {MMMM}
		/// e.g., January, February, ...
		/// 一月、二月、……
		/// 
		/// 
		/// 
		/// {MMM}
		/// e.g., Jan, Feb, ...
		/// 1月、2月、……
		/// 
		/// 
		/// 
		/// {MM}
		/// 01-12
		/// 01-12
		/// 
		/// 
		/// 
		/// {M}
		/// 1-12
		/// 1-12
		/// 
		/// 
		/// Day of Month
		/// {dd}
		/// 01-31
		/// 01-31
		/// 
		/// 
		/// 
		/// {d}
		/// 1-31
		/// 1-31
		/// 
		/// 
		/// Day of Week
		/// {eeee}
		/// Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
		/// 星期日、星期一、星期二、星期三、星期四、星期五、星期六
		/// 
		/// 
		/// 
		/// {ee}
		/// Sun, Mon, Tues, Wed, Thu, Fri, Sat
		/// 日、一、二、三、四、五、六
		/// 
		/// 
		/// 
		/// {e}
		/// 1-54
		/// 1-54
		/// 
		/// 
		/// Hour
		/// {HH}
		/// 00-23
		/// 00-23
		/// 
		/// 
		/// 
		/// {H}
		/// 0-23
		/// 0-23
		/// 
		/// 
		/// 
		/// {hh}
		/// 01-12
		/// 01-12
		/// 
		/// 
		/// 
		/// {h}
		/// 1-12
		/// 1-12
		/// 
		/// 
		/// Minute
		/// {mm}
		/// 00-59
		/// 00-59
		/// 
		/// 
		/// 
		/// {m}
		/// 0-59
		/// 0-59
		/// 
		/// 
		/// Second
		/// {ss}
		/// 00-59
		/// 00-59
		/// 
		/// 
		/// 
		/// {s}
		/// 0-59
		/// 0-59
		/// 
		/// 
		/// Millisecond
		/// {SSS}
		/// 000-999
		/// 000-999
		/// 
		/// 
		/// 
		/// {S}
		/// 0-999
		/// 0-999
		/// 
		/// 
		/// 
		/// 
		/// 其他语言请参考相应语言包中的定义，语言包可以通过 echarts.registerLocale 注册。
		/// 
		/// 示例:
		/// formatter: '{yyyy}-{MM}-{dd}' // 得到的 label 形如：'2020-12-02'
		/// formatter: '{d}日' // 得到的 label 形如：'2日'
		/// 
		///  回调函数 
		/// 回调函数可以根据刻度值返回不同的格式，如果有复杂的时间格式化需求，也可以引用第三方的日期时间相关的库（如 Moment.js、date-fns 等），返回显示的文本。
		/// 示例：
		/// // 使用函数模板，函数参数分别为刻度数值（类目），刻度的索引
		/// formatter: function (value, index) {
		///     // 格式化成月/日，只在第一个刻度显示年份
		///     var date = new Date(value);
		///     var texts = [(date.getMonth() + 1), date.getDate()];
		///     if (index === 0) {
		///         texts.unshift(date.getFullYear());
		///     }
		///     return texts.join('/');
		/// }
		/// 
		///  分级模板 
		/// 有时候，我们希望对不同的时间粒度采用不同的格式化策略。例如，在季度图表中，我们可能希望对每个月的第一天显示月份，而其他日期显示日期。我们可以使用以下方式实现该效果：
		/// 示例：
		/// formatter: {
		///     month: '{MMMM}', // 一月、二月、……
		///     day: '{d}日' // 1日、2日、……
		/// }
		/// 
		/// 支持的分级以及各自默认的取值为：
		/// {
		///     year: '{yyyy}',
		///     month: '{MMM}',
		///     day: '{d}',
		///     hour: '{HH}:{mm}',
		///     minute: '{HH}:{mm}',
		///     second: '{HH}:{mm}:{ss}',
		///     millisecond: '{hh}:{mm}:{ss} {SSS}',
		///     none: '{yyyy}-{MM}-{dd} {hh}:{mm}:{ss} {SSS}'
		/// }
		/// 
		/// 以 day 为例，当一个刻度点的值的小时、分钟、秒、毫秒都为 0 时，将采用 day 的分级值作为模板。none 表示当其他规则都不适用时采用的模板，也就是带有毫秒值的刻度点的模板。
		///  富文本 
		/// 以上这三种形式的 formatter 都支持富文本，所以可以做成一些复杂的效果。
		/// 示例：
		/// xAxis: {
		///     type: 'time',
		///     axisLabel: {
		///         formatter: {
		///             // 一年的第一个月显示年度信息和月份信息
		///             year: '{yearStyle|{yyyy}}\n{monthStyle|{MMM}}',
		///             month: '{monthStyle|{MMM}}'
		///         },
		///         rich: {
		///             yearStyle: {
		///                 // 让年度信息更醒目
		///                 color: '#000',
		///                 fontWeight: 'bold'
		///             },
		///             monthStyle: {
		///                 color: '#999'
		///             }
		///         }
		///     }
		/// },
		/// 
		/// 使用回调函数形式实现上面例子同样的效果：
		/// 示例：
		/// xAxis: {
		///     type: 'time',
		///     axisLabel: {
		///         formatter: function (value) {
		///             const date = new Date(value);
		///             const yearStart = new Date(value);
		///             yearStart.setMonth(0);
		///             yearStart.setDate(1);
		///             yearStart.setHours(0);
		///             yearStart.setMinutes(0);
		///             yearStart.setSeconds(0);
		///             yearStart.setMilliseconds(0);
		///             // 判断一个刻度值知否为一年的开始
		///             if (date.getTime() === yearStart.getTime()) {
		///                 return '{year|' + date.getFullYear() + '}\n'
		///                     + '{month|' + (date.getMonth() + 1) + '月}';
		///             }
		///             else {
		///                 return '{month|' + (date.getMonth() + 1) + '月}'
		///             }
		///         },
		///         rich: {
		///             year: {
		///                 color: '#000',
		///                 fontWeight: 'bold'
		///             },
		///             month: {
		///                 color: '#999'
		///             }
		///         }
		///     }
		/// },
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 是否显示最小 tick 的 label。可取值 true, false, null。默认自动判定（即如果标签重叠，不会显示最小 tick 的 label）。
		/// </summary>
		[JsonProperty("showMinLabel")]
		public bool? ShowMinLabel { get; set; }

		/// <summary>
		/// 是否显示最大 tick 的 label。可取值 true, false, null。默认自动判定（即如果标签重叠，不会显示最大 tick 的 label）。
		/// </summary>
		[JsonProperty("showMaxLabel")]
		public bool? ShowMaxLabel { get; set; }

		/// <summary>
		/// 从 v5.5.0 开始支持
		/// 
		/// 最小的坐标刻度标签的对齐方式。如果设置为 null，则和其他标签一致。参见 align。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// null (default)
		/// </summary>
		[JsonProperty("alignMinLabel")]
		public string AlignMinLabel { get; set; }

		/// <summary>
		/// 从 v5.5.0 开始支持
		/// 
		/// 最大的坐标刻度标签的对齐方式。如果设置为 null，则和其他标签一致。参见 align。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// null (default)
		/// </summary>
		[JsonProperty("alignMaxLabel")]
		public string AlignMaxLabel { get; set; }

		/// <summary>
		/// 从 v5.2.0 开始支持
		/// 
		/// 是否隐藏重叠的标签。
		/// </summary>
		[JsonProperty("hideOverlap")]
		public bool? HideOverlap { get; set; }

		/// <summary>
		/// 从 v5.5.1 开始支持
		/// 
		/// 自定义要显示的标签位置。例如：
		/// axisLabel: {
		///     customValues: [0, 4, 7, 8, 9]
		/// }
		/// </summary>
		[JsonProperty("customValues")]
		public double[] CustomValues { get; set; }

		/// <summary>
		/// 刻度标签文字的颜色，默认取 axisLine.lineStyle.color。支持回调函数，格式如下
		/// (val: string) => Color
		/// 
		/// 参数是标签的文本，返回颜色值，如下示例：
		/// textStyle: {
		///     color: function (value, index) {
		///         return value >= 0 ? 'green' : 'red';
		///     }
		/// }
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
	/// 坐标轴在 grid 区域中的分隔线。
	/// </summary>
	public class XAxis_SplitLine
	{
		/// <summary>
		/// 是否显示分隔线。默认数值轴显示，类目轴不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 坐标轴分隔线的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
		/// 默认会采用标签不重叠的策略间隔显示标签。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示隔两个标签显示一个标签，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle2 LineStyle { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class LineStyle2
	{
		/// <summary>
		/// 分隔线颜色，可以设置成单个颜色。
		/// 也可以设置成颜色数组，分隔线会按数组中颜色的顺序依次循环设置颜色。
		/// 示例
		/// splitLine: {
		///     lineStyle: {
		///         // 使用深浅的间隔色
		///         color: ['#aaa', '#ddd']
		///     }
		/// }
		/// </summary>
		[JsonProperty("color")]
		public ArrayOrSingle Color { get; set; }

		/// <summary>
		/// 分隔线线宽。
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
	/// 从 v4.6.0 开始支持
	/// 
	/// 坐标轴在 grid 区域中的次分隔线。次分割线会对齐次刻度线 minorTick
	/// </summary>
	public class XAxis_MinorSplitLine
	{
		/// <summary>
		/// 是否显示次分隔线。默认不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}

	/// <summary>
	/// 坐标轴在 grid 区域中的分隔区域，默认不显示。
	/// </summary>
	public class XAxis_SplitArea
	{
		/// <summary>
		/// 坐标轴分隔区域的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
		/// 默认会采用标签不重叠的策略间隔显示标签。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示隔两个标签显示一个标签，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 是否显示分隔区域。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 分隔区域的样式设置。
		/// </summary>
		[JsonProperty("areaStyle")]
		public AreaStyle0 AreaStyle { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class AreaStyle0
	{
		/// <summary>
		/// 分隔区域颜色。分隔区域会按数组中颜色的顺序依次循环设置颜色。默认是一个深浅的间隔色。
		/// </summary>
		[JsonProperty("color")]
		public double[] Color { get; set; }

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
	public class XAxis_Data
	{
		/// <summary>
		/// 单个类目名称。
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// 类目标签的文字样式。
		/// </summary>
		[JsonProperty("textStyle")]
		public NameTextStyle0 TextStyle { get; set; }
	}

	/// <summary>
	/// 坐标轴指示器配置项。
	/// </summary>
	public class SingleAxis_AxisPointer
	{
		/// <summary>
		/// 默认不显示。但是如果 tooltip.trigger 设置为 'axis' 或者 tooltip.axisPointer.type 设置为 'cross'，则自动显示 axisPointer。坐标系会自动选择显示显示哪个轴的 axisPointer，也可以使用 tooltip.axisPointer.axis 改变这种选择。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 指示器类型。
		/// 可选
		/// 
		/// 'line' 直线指示器
		/// 
		/// 'shadow' 阴影指示器
		/// 
		/// 'none' 无指示器
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "line";

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
		/// 从 v5.4.3 开始支持
		/// 
		/// 是否触发系列强调功能。
		/// </summary>
		[JsonProperty("triggerEmphasis")]
		public bool? TriggerEmphasis { get; set; }

		/// <summary>
		/// 是否触发 tooltip。如果不想触发 tooltip 可以关掉。
		/// </summary>
		[JsonProperty("triggerTooltip")]
		public bool? TriggerTooltip { get; set; }

		/// <summary>
		/// 当前的 value。在使用 axisPointer.handle 时，可以设置此值进行初始值设定，从而决定 axisPointer 的初始位置。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 当前的状态，可取值为 'show' 和 'hide'。
		/// </summary>
		[JsonProperty("status")]
		public bool? Status { get; set; }

		/// <summary>
		/// 拖拽手柄，适用于触屏的环境。参见 例子。
		/// </summary>
		[JsonProperty("handle")]
		public XAxis_AxisPointer_Handle Handle { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class XAxis_AxisPointer_Handle
	{
		/// <summary>
		/// 当 show 设为 true 时开启，这时显示手柄，并且 axisPointer 会一直显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 手柄的图标。
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// 参见 使用图片的例子
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		/// 手柄的尺寸，可以设置单值，如 45，也可以设置为数组：[width, height]。
		/// </summary>
		[JsonProperty("size")]
		public ArrayOrSingle Size { get; set; }

		/// <summary>
		/// 手柄与轴的距离。注意，这是手柄中心点和轴的距离。
		/// </summary>
		[JsonProperty("margin")]
		public double? Margin { get; set; }

		/// <summary>
		/// 手柄颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// 手柄拖拽时触发视图更新周期，单位毫秒，调大这个数值可以改善性能，但是降低体验。
		/// </summary>
		[JsonProperty("throttle")]
		public double? Throttle { get; set; }

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
}