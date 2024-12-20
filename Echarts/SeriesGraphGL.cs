using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 使用 WebGL 绘制的关系图，支持大规模的网络/关系数据的布局和绘制。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesGraphGL
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "graphGL";

		/// <summary>
		/// 系列名称，用于 tooltip 的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 布局的算法，支持使用 gephi 的 forceAtlas2 算法布局。
		/// </summary>
		[JsonProperty("layout")]
		public string Layout { get; set; }

		/// <summary>
		/// forceAtlas2 布局算法。
		/// 该算法对大规模的网络数据有着高效的布局效率和稳定的布局结果。
		/// 支持通过 forceAtlas2.GPU 配置为 GPU 还是 CPU 布局。
		/// CPU 实现的优势是兼容性好，而 GPU 实现在高端显卡中有着数十倍甚至上百倍的性能优势。
		/// 下面是在 GTX1070 和 i7 4GHz 的电脑中对一个 2w 个节点（近 5w 条边）的关系图一次布局的迭代的性能对比。
		/// </summary>
		[JsonProperty("forceAtlas2")]
		public SeriesGraphGL_ForceAtlas2 ForceAtlas2 { get; set; }

		/// <summary>
		/// 散点的形状。默认为圆形。
		/// ECharts 提供的标记类型包括 
		/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适（如果是 symbol 的话就是 symbolSize）的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
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
		/// 节点的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		/// 关系边的样式设置。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }

		/// <summary>
		/// 节点的数据集。
		/// 数据格式同 graph.data
		/// </summary>
		[JsonProperty("data")]
		public SeriesScatterGL_Data Data { get; set; }

		/// <summary>
		/// 同 graphGL.data。
		/// </summary>
		[JsonProperty("nodes")]
		public double[] Nodes { get; set; }

		/// <summary>
		/// 节点间的关系数据。
		/// 数据格式同 graph.links
		/// </summary>
		[JsonProperty("links")]
		public SeriesGraphGL_Links[] Links { get; set; }

		/// <summary>
		/// 同 graphGL.links
		/// </summary>
		[JsonProperty("edges")]
		public double[] Edges { get; set; }

		/// <summary>
		/// 组件所在的层。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// 注: echarts-gl 中组件的层需要跟 echarts 中组件的层分开。同一个 zlevel 不能同时用于 WebGL 和 Canvas 的绘制。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }
	}

	/// <summary>
	/// forceAtlas2 布局算法。
	/// 该算法对大规模的网络数据有着高效的布局效率和稳定的布局结果。
	/// 支持通过 forceAtlas2.GPU 配置为 GPU 还是 CPU 布局。
	/// CPU 实现的优势是兼容性好，而 GPU 实现在高端显卡中有着数十倍甚至上百倍的性能优势。
	/// 下面是在 GTX1070 和 i7 4GHz 的电脑中对一个 2w 个节点（近 5w 条边）的关系图一次布局的迭代的性能对比。
	/// </summary>
	public class SeriesGraphGL_ForceAtlas2
	{
		/// <summary>
		/// 是否启用 GPU 布局。
		/// </summary>
		[JsonProperty("GPU")]
		public bool? GPU { get; set; }

		/// <summary>
		/// 一次更新的迭代次数。因为力引导算法通常会把每次迭代的结果都绘制出来，但是因为绘制时间往往会大于布局的时间，会导致布局的效率降低，这时候我们可以设置更大的steps参数，保证布局和绘制的时间均衡，加快布局的速度。
		/// </summary>
		[JsonProperty("steps")]
		public double? Steps { get; set; }

		/// <summary>
		/// 停止布局的阈值，当布局的全局速度因子小于这个阈值时停止布局。设为 0 则永远不停止。
		/// </summary>
		[JsonProperty("stopThreshold")]
		public double? StopThreshold { get; set; }

		/// <summary>
		/// 是否开启 Barnes Hut 优化，在 forceAtlas2.GPU 为 false 时有效。
		/// 默认在节点数 > 1000时开启。
		/// </summary>
		[JsonProperty("barnesHutOptimize")]
		public bool? BarnesHutOptimize { get; set; }

		/// <summary>
		/// 是否根据节点边的数量来计算节点的斥力因子，建议开启。
		/// </summary>
		[JsonProperty("repulsionByDegree")]
		public double? RepulsionByDegree { get; set; }

		/// <summary>
		/// 是否是lin-log模式。lin-log 模式会让聚类的节点更加紧凑。
		/// </summary>
		[JsonProperty("linLogMode")]
		public bool? LinLogMode { get; set; }

		/// <summary>
		/// 节点受到的向心力。这个力会让节点像中心靠拢。
		/// </summary>
		[JsonProperty("gravity")]
		public double? Gravity { get; set; }

		/// <summary>
		/// 向心力中心的位置。默认去初始位置的中间点。
		/// </summary>
		[JsonProperty("gravityCenter")]
		public double[] GravityCenter { get; set; }

		/// <summary>
		/// 布局的缩放因子，值越大则节点间的斥力越大。
		/// </summary>
		[JsonProperty("scaling")]
		public double? Scaling { get; set; }

		/// <summary>
		/// 边权重的影响因子。值越大，则边权重对于引力的影响也越大。
		/// 注：这个因子是指数级的，因此在边权重为0和1的时候无效。
		/// </summary>
		[JsonProperty("edgeWeightInfluence")]
		public double? EdgeWeightInfluence { get; set; }

		/// <summary>
		/// 边的权重分布。映射自 links.value。
		/// 支持设置为单个数字，这时候就是统一的权重值。
		/// </summary>
		[JsonProperty("edgeWeight")]
		public ArrayOrSingle EdgeWeight { get; set; }

		/// <summary>
		/// 节点的权重分布。映射自 nodes.value。
		/// 支持设置为单个数字，这时候就是统一的权重值。
		/// </summary>
		[JsonProperty("nodeWeight")]
		public ArrayOrSingle NodeWeight { get; set; }

		/// <summary>
		/// 是否开启防止节点重叠。
		/// </summary>
		[JsonProperty("preventOverlap")]
		public bool? PreventOverlap { get; set; }
	}

	/// <summary>
	/// 节点间的关系数据。
	/// 数据格式同 graph.links
	/// </summary>
	public class SeriesGraphGL_Links
	{
		/// <summary>
		/// 边的源节点名称的字符串，也支持使用数字表示源节点的索引。
		/// </summary>
		[JsonProperty("source")]
		public string Source { get; set; }

		/// <summary>
		/// 边的目标节点名称的字符串，也支持使用数字表示源节点的索引。
		/// </summary>
		[JsonProperty("target")]
		public string Target { get; set; }

		/// <summary>
		/// 边的数值。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 单条边的样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }
	}
}