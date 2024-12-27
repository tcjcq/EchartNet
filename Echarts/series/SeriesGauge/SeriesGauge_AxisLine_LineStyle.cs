using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     仪表盘轴线样式。
	/// </summary>
	public class SeriesGauge_AxisLine_LineStyle
	{
		/// <summary>
		///     仪表盘的轴线可以被分成不同颜色的多段。每段的结束位置和颜色可以通过一个数组来表示。
		///     默认取值：
		///     [[1, '#E6EBF8']]
		///     注意: color[i][0] 的值代表整根轴线的百分比，应在 0 到 1 之间；color[i][1] 是对应的颜色。
		///     color: [
		///     [0.1, 'red'], // 0~10% 红轴
		///     [0.2, 'green'], // 10~20% 绿轴
		///     [0.3, 'blue'], // 20~30% 蓝轴
		///     // ...
		///     ]
		/// </summary>
		[JsonProperty("color")]
		public double[] Color { get; set; }

		/// <summary>
		///     轴线宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		///     图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		///     示例：
		///     {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		///     }
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		///     阴影颜色。支持的格式同color。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		///     阴影水平方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		///     阴影垂直方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		///     图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }
	}
}