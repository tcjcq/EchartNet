using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
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
}