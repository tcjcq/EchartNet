using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     使用 WebGL 绘制的二维散点/气泡图。
	///     使用方式同 scatter。
	/// </summary>
	public class SeriesScatterGL
	{
		/// <summary>
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "scatterGL";

		/// <summary>
		///     系列名称，用于 tooltip 的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     使用的坐标系。
		///     同 scatter.coordinateSystem
		/// </summary>
		[JsonProperty("coordinateSystem")]
		public string CoordinateSystem { get; set; }

		/// <summary>
		///     散点的形状。默认为圆形。
		///     ECharts 提供的标记类型包括
		///     'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		///     可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适（如果是 symbol 的话就是
		///     symbolSize）的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		///     标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		///     如果需要每个数据的图形大小不一样，可以设置为如下格式的回调函数：
		///     (value: Array|number, params: Object) => number|Array
		///     其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// </summary>
		[JsonProperty("symbolSize")]
		public StringOrNumber SymbolSize { get; set; }

		/// <summary>
		///     散点图的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		///     散点图的数据集。
		///     数据格式同 scatter.data
		/// </summary>
		[JsonProperty("data")]
		public SeriesScatterGL_Data[] Data { get; set; }

		/// <summary>
		///     混合模式，目前支持'source-over'，'lighter'，默认使用的'source-over'是通过 alpha 混合，而'lighter'是叠加模式，该模式可以让数据集中的区域因为叠加而产生高亮的效果。
		/// </summary>
		[JsonProperty("blendMode")]
		public string BlendMode { get; set; }

		/// <summary>
		///     组件所在的层。
		///     zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的
		///     Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		///     zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		///     注: echarts-gl 中组件的层需要跟 echarts 中组件的层分开。同一个 zlevel 不能同时用于 WebGL 和 Canvas 的绘制。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		///     启用渐进渲染的阈值，渐进渲染可以让你在加载画面的过程中不会有阻塞。
		/// </summary>
		[JsonProperty("progressiveThreshold")]
		public double? ProgressiveThreshold { get; set; }

		/// <summary>
		///     渐进渲染每次渲染的数据量。
		/// </summary>
		[JsonProperty("progressive")]
		public double? Progressive { get; set; }
	}
}