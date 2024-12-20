using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// timeline 组件，提供了在多个 ECharts option 间进行切换、播放等操作的功能。
	/// 示例效果如下：
	/// 
	/// 
	/// 
	/// timeline 和其他场景有些不同，它需要操作『多个option』。我们把传入 setOption 第一个参数的东西，称为 ECOption，然后称传统的 ECharts 单个 option 为 ECUnitOption。
	/// 
	/// 当 timeline 和 media query 没有被设置时，一个 ECUnitOption 就是一个 ECOption。
	/// 当 timeline 或 media query 被使用设置时，一个 ECOption 由几个 ECUnitOption 组成。
	/// ECOption 的各个根属性，形成一个 ECUnitOption，叫做 baseOption，它代表了各种默认设置。
	/// options 数组每项，形成一个 ECUnitOption，我们为了方便也叫做 switchableOption，它代表了每个时间粒度对应的 option。
	/// 
	/// 
	/// baseOption 和一个 switchableOption 会用来计算最终的 finalOption，图表就是根据这个最终结果绘制的。
	/// 
	/// 例如：
	/// // 如下，baseOption 是一个 『原子option』，options 数组
	/// // 中的每一项也是一个 『原子option』。
	/// // 每个『原子option』中就是本文档中描述的各种配置项。
	/// myChart.setOption({
	///     // `baseOption` 的属性.
	///     timeline: {
	///         ...,
	///         // `timeline.data` 中的每一项，对应于 `options`
	///         // 数组中的每个 `option`
	///         data: ['2002-01-01', '2003-01-01', '2004-01-01']
	///     },
	///     grid: { ... },
	///     xAxis: [ ... ],
	///     yAxis: [ ... ],
	///     series: [{
	///         // 系列一的一些其他配置
	///         type: 'bar',
	///         ...
	///     }, {
	///         // 系列二的一些其他配置
	///         type: 'line',
	///         ...
	///     }, {
	///         // 系列三的一些其他配置
	///         type: 'pie',
	///         ...
	///     }],
	///     // `switchableOption`s:
	///     options: [{
	///         // 这是'2002-01-01' 对应的 option
	///         title: {
	///             text: '2002年统计值'
	///         },
	///         series: [
	///             { data: [] }, // 系列一的数据
	///             { data: [] }, // 系列二的数据
	///             { data: [] }  // 系列三的数据
	///         ]
	///     }, {
	///         // 这是'2003-01-01' 对应的 option
	///         title: {
	///             text: '2003年统计值'
	///         },
	///         series: [
	///             { data: [] },
	///             { data: [] },
	///             { data: [] }
	///         ]
	///     }, {
	///         // 这是'2004-01-01' 对应的 option
	///         title: {
	///             text: '2004年统计值'
	///         },
	///         series: [
	///             { data: [] },
	///             { data: [] },
	///             { data: [] }
	///         ]
	///     }]
	/// });
	/// 
	/// 
	/// finalOption 是怎么计算出来的?
	/// 初始化的时候，对应于当前时间的那个 switchableOption 会被合并（merge）到 baseOption，形成 finalOption。而每当时间变化时，对应于新时间的 switchableOption 会被合并（merge）到finalOption。
	/// 有两种合并（merge）策略：
	/// 
	/// 默认使用 NORMAL_MERGE。
	/// 如果 timeline.replaceMerge 被指定了，则使用 REPLACE_MERGE。如果要知道 REPLACE_MERGE 更多信息，可以参见 setOption 中 REPLACE_MERGE 一节。
	/// 。
	/// 
	/// 
	/// 兼容 ECharts4
	/// 如下这种设置方式，也支持：
	/// option = {
	///     baseOption: {
	///         timeline: {},
	///         series: [],
	///         // ... other properties of baseOption.
	///     },
	///     options: []
	/// };
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class Timeline
	{
		/// <summary>
		/// 是否显示 timeline 组件。如果设置为false，不会显示，但是功能还存在。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 这个属性目前只支持为 slider，不需要更改。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "slider";

		/// <summary>
		/// 轴的类型。可选值为：
		/// 
		/// 'value'
		///   数值轴，适用于连续数据。
		/// 
		/// 'category'
		///   类目轴，适用于离散的类目数据。
		/// 
		/// 'time'
		///   时间轴，适用于连续的时序数据，与数值轴相比时间轴带有时间的格式化，在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
		/// </summary>
		[JsonProperty("axisType")]
		public string AxisType { get; set; }

		/// <summary>
		/// 表示当前选中项是哪项。比如，currentIndex 为 0 时，表示当前选中项为 timeline.data[0]（即使用 options[0]）。
		/// </summary>
		[JsonProperty("currentIndex")]
		public double? CurrentIndex { get; set; }

		/// <summary>
		/// 表示是否自动播放。
		/// </summary>
		[JsonProperty("autoPlay")]
		public bool? AutoPlay { get; set; }

		/// <summary>
		/// 表示是否反向播放。
		/// </summary>
		[JsonProperty("rewind")]
		public bool? Rewind { get; set; }

		/// <summary>
		/// 表示是否循环播放。
		/// </summary>
		[JsonProperty("loop")]
		public bool? Loop { get; set; }

		/// <summary>
		/// 表示播放的速度（跳动的间隔），单位毫秒（ms）。
		/// </summary>
		[JsonProperty("playInterval")]
		public double? PlayInterval { get; set; }

		/// <summary>
		/// 拖动圆点的时候，是否实时更新视图。
		/// </summary>
		[JsonProperty("realtime")]
		public bool? Realtime { get; set; }

		/// <summary>
		/// 初始化的时候，对应于当前时间的那个 switchableOption 会被合并（merge）到 baseOption，形成 finalOption。而每当时间变化时，对应于新时间的 switchableOption 会被合并（merge）到finalOption。
		/// 有两种合并（merge）策略：
		/// 
		/// 默认使用 NORMAL_MERGE。
		/// 如果 timeline.replaceMerge 被指定了，则使用 REPLACE_MERGE。如果要知道 REPLACE_MERGE 更多信息，可以参见 setOption 中 REPLACE_MERGE 一节。
		/// 。
		/// 
		/// 
		/// replaceMerge 的值可以是一个组件的 mainType，例如 replaceMerge: 'xAxis'。也可以是 mainType 数组，例如 replaceMerge: ['xAxis', 'series']。
		/// 常见需要使用 replaceMerge 的地方是，如果需要下一个时间刻度的 series 完全替换上一个时间刻度的 series 而不进行任何 merge ，可以设置 replaceMerge: 'series'，并且两个时间刻度的 series id 不相同或者没有 id 。
		/// 参见这个 示例。
		/// </summary>
		[JsonProperty("replaceMerge")]
		public ArrayOrSingle ReplaceMerge { get; set; }

		/// <summary>
		/// 表示『播放』按钮的位置。可选值：'left'、'right'。
		/// </summary>
		[JsonProperty("controlPosition")]
		public string ControlPosition { get; set; }

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
		/// timeline组件离容器左侧的距离。
		/// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		/// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// timeline组件离容器上侧的距离。
		/// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		/// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// timeline组件离容器右侧的距离。
		/// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// timeline组件离容器下侧的距离。
		/// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// timeline内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。
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
		/// 摆放方式，可选值有：
		/// 
		/// 'vertical'：竖直放置。
		/// 'horizontal'：水平放置。
		/// </summary>
		[JsonProperty("orient")]
		public string Orient { get; set; }

		/// <summary>
		/// 是否反向放置 timeline，反向则首位颠倒过来。
		/// </summary>
		[JsonProperty("inverse")]
		public bool? Inverse { get; set; }

		/// <summary>
		/// timeline标记的图形。
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
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// timeline标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// timeline标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// timeline标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public Timeline_LineStyle LineStyle { get; set; }

		/// <summary>
		/// 轴的文本标签。emphasis 是文本高亮的样式，比如鼠标悬浮或者图例联动高亮的时候会使用 emphasis 作为文本的样式。
		/// </summary>
		[JsonProperty("label")]
		public Timeline_Label Label { get; set; }

		/// <summary>
		/// timeline  图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 『当前项』（checkpoint）的图形样式。
		/// </summary>
		[JsonProperty("checkpointStyle")]
		public Timeline_CheckpointStyle CheckpointStyle { get; set; }

		/// <summary>
		/// 『控制按钮』的样式。『控制按钮』包括：『播放按钮』、『前进按钮』、『后退按钮』。
		/// </summary>
		[JsonProperty("controlStyle")]
		public Timeline_ControlStyle ControlStyle { get; set; }

		/// <summary>
		/// 进度条中的线条，拐点，标签的样式。
		/// </summary>
		[JsonProperty("progress")]
		public Timeline_Progress Progress { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Timeline_Emphasis Emphasis { get; set; }

		/// <summary>
		/// timeline 数据。Array 的每一项，可以是直接的数值。
		/// 如果需要对每个数据项单独进行样式定义，则数据项写成 Object。Object中，value属性为数值。其他属性如下例子，可以覆盖 timeline 中的属性配置。
		/// 如下例：
		/// [
		///     '2002-01-01',
		///     '2003-01-01',
		///     '2004-01-01',
		///     {
		///         value: '2005-01-01',
		///         tooltip: {          // 让鼠标悬浮到此项时能够显示 `tooltip`。
		///             formatter: '{b} xxxx'
		///         },
		///         symbol: 'diamond',  // 此项的图形的特别设置。
		///         symbolSize: 16      // 此项的图形大小的特别设置。
		///     },
		///     '2006-01-01',
		///     '2007-01-01',
		///     '2008-01-01',
		///     '2009-01-01',
		///     '2010-01-01',
		///     {
		///         value: '2011-01-01',
		///         tooltip: {          // 让鼠标悬浮到此项时能够显示 `tooltip`。
		///             formatter: function (params) {
		///                 return params.name + 'xxxx';
		///             }
		///         },
		///         symbol: 'diamond',
		///         symbolSize: 18
		///     },
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public double[] Data { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Timeline_LineStyle
	{
		/// <summary>
		/// 是否显示轴线。可以设置为 false 不显示轴线，则可以做出不同的样式效果。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// timeline 线的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// timeline 线宽。
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
	/// 轴的文本标签。emphasis 是文本高亮的样式，比如鼠标悬浮或者图例联动高亮的时候会使用 emphasis 作为文本的样式。
	/// </summary>
	public class Timeline_Label
	{
		/// <summary>
		/// 可选的配置方式：
		/// 
		/// 'auto'：
		///   完全自动决定。
		/// 
		/// 'left'：
		///   贴左边界放置。
		///   当 timline.orient 为 'vertical' 时有效。
		/// 
		/// 'right'：当 timline.orient 为 'vertical' 时有效。
		///   贴右边界放置。
		/// 
		/// 'top'：
		///   贴上边界放置。
		///   当 timline.orient 为 'horizontal' 时有效。
		/// 
		/// 'bottom'：
		///   贴下边界放置。
		///   当 timline.orient 为 'horizontal' 时有效。
		/// 
		/// number：
		///   指定某个数值时，表示 label 和轴的距离。为 0 时则和坐标轴重合，可以为正负值，决定 label 在坐标轴的哪一边。
		/// </summary>
		[JsonProperty("position")]
		public StringOrNumber Position { get; set; }

		/// <summary>
		/// 是否显示 label。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// label 的间隔。当指定为数值时，例如指定为 2，则每隔两个显示一个 label。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// label 的旋转角度。正值表示逆时针旋转。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

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
		/// timeline.lable文字的颜色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// timeline.lable文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// timeline.lable文字字体的粗细。
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
		/// timeline.lable文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// timeline.lable文字的字体大小。
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
	/// 『当前项』（checkpoint）的图形样式。
	/// </summary>
	public class Timeline_CheckpointStyle
	{
		/// <summary>
		/// timeline.checkpointStyle 标记的图形。
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
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// timeline.checkpointStyle 标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// timeline.checkpointStyle 标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// timeline.checkpointStyle 标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

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
		/// timeline组件中『当前项』（checkpoint）在 timeline 播放切换中的移动，是否有动画。
		/// </summary>
		[JsonProperty("animation")]
		public bool? Animation { get; set; }

		/// <summary>
		/// timeline组件中『当前项』（checkpoint）的动画时长。
		/// </summary>
		[JsonProperty("animationDuration")]
		public double? AnimationDuration { get; set; }

		/// <summary>
		/// timeline组件中『当前项』（checkpoint）的动画的缓动效果。不同的缓动效果可以参考 缓动示例。
		/// </summary>
		[JsonProperty("animationEasing")]
		public string AnimationEasing { get; set; }
	}

	/// <summary>
	/// 『控制按钮』的样式。『控制按钮』包括：『播放按钮』、『前进按钮』、『后退按钮』。
	/// </summary>
	public class Timeline_ControlStyle
	{
		/// <summary>
		/// 是否显示『控制按钮』。设置为 false 则全不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 是否显示『播放按钮』。
		/// </summary>
		[JsonProperty("showPlayBtn")]
		public bool? ShowPlayBtn { get; set; }

		/// <summary>
		/// 是否显示『后退按钮』。
		/// </summary>
		[JsonProperty("showPrevBtn")]
		public bool? ShowPrevBtn { get; set; }

		/// <summary>
		/// 是否显示『前进按钮』。
		/// </summary>
		[JsonProperty("showNextBtn")]
		public bool? ShowNextBtn { get; set; }

		/// <summary>
		/// 『控制按钮』的尺寸，单位为像素（px）。
		/// </summary>
		[JsonProperty("itemSize")]
		public double? ItemSize { get; set; }

		/// <summary>
		/// 『控制按钮』的间隔，单位为像素（px）。
		/// </summary>
		[JsonProperty("itemGap")]
		public double? ItemGap { get; set; }

		/// <summary>
		/// 『控制按钮』的位置。
		/// 
		/// 当 timeline.orient 为 'horizontal'时，'left'、'right'有效。
		/// 
		/// 当 timeline.orient 为 'vertical'时，'top'、'bottom'有效。
		/// </summary>
		[JsonProperty("position")]
		public string Position { get; set; }

		/// <summary>
		/// 『播放按钮』的『可播放状态』的图形。
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("playIcon")]
		public string PlayIcon { get; set; }

		/// <summary>
		/// 『播放按钮』的『可停止状态』的图形。
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("stopIcon")]
		public string StopIcon { get; set; }

		/// <summary>
		/// 『后退按钮』的图形
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("prevIcon")]
		public string PrevIcon { get; set; }

		/// <summary>
		/// 『前进按钮』的图形
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("nextIcon")]
		public string NextIcon { get; set; }

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
	}

	/// <summary>
	/// 进度条中的线条，拐点，标签的样式。
	/// </summary>
	public class Timeline_Progress
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label2 Label { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Timeline_Emphasis
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label2 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 当前项『高亮状态』的样式（hover时）。
		/// </summary>
		[JsonProperty("checkpointStyle")]
		public Timeline_CheckpointStyle CheckpointStyle { get; set; }

		/// <summary>
		/// 控制按钮的『高亮状态』的样式（hover时）。
		/// </summary>
		[JsonProperty("controlStyle")]
		public Timeline_ControlStyle ControlStyle { get; set; }
	}

	/// <summary>
	/// 轴的文本标签。emphasis 是文本高亮的样式，比如鼠标悬浮或者图例联动高亮的时候会使用 emphasis 作为文本的样式。
	/// </summary>
	public class Label2
	{
		/// <summary>
		/// 是否显示 label。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// label 的间隔。当指定为数值时，例如指定为 2，则每隔两个显示一个 label。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// label 的旋转角度。正值表示逆时针旋转。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

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
		/// timeline.lable.emphasis文字的颜色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// timeline.lable.emphasis文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// timeline.lable.emphasis文字字体的粗细。
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
		/// timeline.lable.emphasis文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// timeline.lable.emphasis文字的字体大小。
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
}