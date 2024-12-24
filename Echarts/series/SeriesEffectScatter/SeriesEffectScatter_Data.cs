using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
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
	public class SeriesEffectScatter_Data
	{
		/// <summary>
		/// 单个数据标记的图形。
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
		/// 单个数据标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// 单个数据标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// 单个数据标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public LabelLine1 LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 单个数据的高亮图形和标签样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis4 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 单个数据的淡出图形和标签样式。
		/// </summary>
		[JsonProperty("blur")]
		public Blur6 Blur { get; set; }

		/// <summary>
		/// 单个数据的选中图形和标签样式。
		/// </summary>
		[JsonProperty("select")]
		public Emphasis4 Select { get; set; }

		/// <summary>
		/// 本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}
}