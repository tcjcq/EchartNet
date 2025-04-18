using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。可以在网格上绘制折线图，柱状图，散点图（气泡图）。
	///     在 ECharts 2.x 里单个 echarts 实例中最多只能存在一个 grid 组件，在 ECharts 3 中可以存在任意个 grid 组件。
	///     例如下面这个 Anscombe Quartet 的示例：
	/// </summary>
	public class Grid
	{
		/// <summary>
		///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     是否显示直角坐标系网格。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

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
		///     grid 组件离容器左侧的距离。
		///     left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		///     如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		///     grid 组件离容器上侧的距离。
		///     top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		///     如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		///     grid 组件离容器右侧的距离。
		///     right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		///     grid 组件离容器下侧的距离。
		///     bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		///     grid 组件的宽度。默认自适应。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		///     grid 组件的高度。默认自适应。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }

		/// <summary>
		///     grid 区域是否包含坐标轴的刻度标签。
		///     containLabel 为 false 的时候：
		///     grid.left grid.right grid.top grid.bottom grid.width grid.height 决定的是由坐标轴形成的矩形的尺寸和位置。
		///     这比较适用于多个 grid 进行对齐的场景，因为往往多个 grid 对齐的时候，是依据坐标轴来对齐的。
		///     containLabel 为 true 的时候：
		///     grid.left grid.right grid.top grid.bottom grid.width grid.height 决定的是包括了坐标轴标签在内的所有内容所形成的矩形的位置。
		///     这常用于『防止标签溢出』的场景，标签溢出指的是，标签长度动态变化时，可能会溢出容器或者覆盖其他组件。
		/// </summary>
		[JsonProperty("containLabel")]
		public bool? ContainLabel { get; set; }

		/// <summary>
		///     网格背景色，默认透明。
		///     颜色可以使用 RGB 表示，比如 'rgb(128, 128, 128)'   ，如果想要加上 alpha 通道，可以使用 RGBA，比如 'rgba(128, 128, 128, 0.5)'，也可以使用十六进制格式，比如
		///     '#ccc'
		///     注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		///     网格的边框颜色。支持的颜色格式同 backgroundColor。
		///     注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		///     网格的边框线宽。
		///     注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		///     图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		///     示例：
		///     {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		///     }
		///     注意：此配置项生效的前提是，设置了 show: true 以及值不为 transparent 的背景色 backgroundColor。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		///     阴影颜色。支持的格式同color。
		///     注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		///     阴影水平方向上的偏移距离。
		///     注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		///     阴影垂直方向上的偏移距离。
		///     注意：此配置项生效的前提是，设置了 show: true。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

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