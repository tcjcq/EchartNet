using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     极坐标系，可以用于散点图和折线图。每个极坐标系拥有一个角度轴和一个半径轴。
	///     示例：
	/// </summary>
	public class Polar
	{
		/// <summary>
		///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     所有图形的 zlevel 值。
		///     zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的
		///     Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		///     zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		///     组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		///     z相比zlevel优先级更低，而且不会创建新的 Canvas。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		///     极坐标系的中心（圆心）坐标，数组的第一项是横坐标，第二项是纵坐标。
		///     支持设置成百分比，设置成百分比时第一项是相对于容器宽度，第二项是相对于容器高度。
		///     使用示例：
		///     // 设置成绝对的像素值
		///     center: [400, 300]
		///     // 设置成相对的百分比
		///     center: ['50%', '50%']
		/// </summary>
		[JsonProperty("center")]
		public double[] Center { get; set; }

		/// <summary>
		///     极坐标系的半径。可以为如下类型：
		///     number：直接指定外半径值。
		///     string：例如，'20%'，表示外半径为可视区尺寸（容器高宽中较小一项）的 20% 长度。
		///     Array.<number| string>：数组的第一项是内半径，第二项是外半径。每一项遵从上述 number string 的描述。
		/// </summary>
		[JsonProperty("radius")]
		public StringOrNumber[] Radius { get; set; }

		/// <summary>
		///     本坐标系特定的 tooltip 设定。
		///     提示框组件的通用介绍：
		///     提示框组件可以设置在多种地方：
		///     可以设置在全局，即 tooltip
		///     可以设置在坐标系中，即 grid.tooltip、polar.tooltip、single.tooltip
		///     可以设置在系列中，即 series.tooltip
		///     可以设置在系列的每个数据项中，即 series.data.tooltip
		/// </summary>
		[JsonProperty("tooltip")]
		public SingleAxis_Tooltip Tooltip { get; set; }
	}
}