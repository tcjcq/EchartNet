using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     线条样式。
	/// </summary>
	public class SeriesLine3D_LineStyle
	{
		/// <summary>
		///     线条的颜色。
		///     除了颜色字符串外，支持使用数组表示的 RGBA 值，例如：
		///     // 纯白色
		///     [1, 1, 1, 1]
		///     使用数组表示的时候，每个通道可以设置大于 1 的值用于表示 HDR 的色值。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		///     线条的不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		///     线条的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }
	}
}