using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// flowGL 组件通过 WebGL 实现的粒子效果可视化向量场的迹线。
	/// 下图是全球的风场通过flowGL可视化后的效果。
	/// </summary>
	public class SeriesFlowGL
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "flowGL";

		/// <summary>
		/// 粒子的密度，实际的粒子数量是设置数目的平方。粒子密度越大迹线效果越好，但是性能开销也会越大。除了该属性，使用 particleType 也可以得到更加清晰连贯的迹线。
		/// </summary>
		[JsonProperty("particleDensity")]
		public double? ParticleDensity { get; set; }

		/// <summary>
		/// 粒子的类型，默认为点 'point'，可以设置成线 'line'。线类型的粒子会用一条线连接上个运动的位置和当前运动的位置，这会让这个轨迹更加连贯。
		/// 下面是类型分别是'point'和'line'的区别。
		/// </summary>
		[JsonProperty("particleType")]
		public string ParticleType { get; set; }

		/// <summary>
		/// 粒子的大小，如果 particleType 是 'line' 的话则会通过线宽的形式表现。
		/// </summary>
		[JsonProperty("particleSize")]
		public double? ParticleSize { get; set; }

		/// <summary>
		/// 粒子的速度，默认为 1。注意在 particleType 为 'point' 的时候过大的速度会让整个轨迹变得断断续续。
		/// </summary>
		[JsonProperty("particleSpeed")]
		public double? ParticleSpeed { get; set; }

		/// <summary>
		/// 粒子的轨迹长度，数值越大轨迹越长。
		/// </summary>
		[JsonProperty("particleTrail")]
		public double? ParticleTrail { get; set; }

		/// <summary>
		/// 画面的超采样比率，采用4的超采样可以有效的提高画面的清晰度，减少画面锯齿。但是因为需要处理更多的像素数量，所以也对性能有更高的要求。
		/// 下面分别是没有超采样和超采样值为 4 的区别。
		/// </summary>
		[JsonProperty("supersampling")]
		public double? Supersampling { get; set; }

		/// <summary>
		/// 传入的网格数据的网格宽度数量。flowGL 会根据这个值和 gridHeight 创建存储向量场的浮点纹理，用于粒子的轨迹计算。
		/// </summary>
		[JsonProperty("gridWidth")]
		public StringOrNumber GridWidth { get; set; }

		/// <summary>
		/// 传入的网格数据的网格高度数量。
		/// </summary>
		[JsonProperty("gridHeight")]
		public StringOrNumber GridHeight { get; set; }

		/// <summary>
		/// 向量场数据，包含向量的位置和向量的方向（包含大小）。flowGL 对数据的存储顺序和没有强制性要求，你甚至可以传入比较稀疏的向量数据。
		/// 如下示例
		/// data: [
		///     // 每个数据项包含四个值，表示位置的 lng、lat 以及相应维度上的速度 sLng、 sLat.
		///     // 如果是直角坐标系上的话则是表示位置的 x、y 以及相应维度上的速度 sx、sy
		///     [0, 0, 1, 1], [1, 0, 1, 1],
		///     [0, 1, 1, 1], [1, 1, 1, 1]
		/// ];
		/// 
		/// 默认flowGL会根据规整的网格形数据自动计算 gridWidth 和 gridHeight。但是因为 flowGL 也支持相对稀疏的数据格式，也可以手动指定这两个值。
		/// </summary>
		[JsonProperty("data")]
		public double[] Data { get; set; }

		/// <summary>
		/// 向量场迹线的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle12 ItemStyle { get; set; }
	}
}