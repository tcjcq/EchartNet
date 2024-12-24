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
}