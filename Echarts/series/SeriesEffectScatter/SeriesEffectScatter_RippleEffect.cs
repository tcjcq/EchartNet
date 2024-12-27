using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     涟漪特效相关配置。
	/// </summary>
	public class SeriesEffectScatter_RippleEffect
	{
		/// <summary>
		///     从 v4.4.0 开始支持
		///     涟漪的颜色，默认为散点的颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		///     从 v5.2.0 开始支持
		///     波纹的数量。
		/// </summary>
		[JsonProperty("number")]
		public double? Number { get; set; }

		/// <summary>
		///     动画的周期，秒数。
		/// </summary>
		[JsonProperty("period")]
		public double? Period { get; set; }

		/// <summary>
		///     动画中波纹的最大缩放比例。
		/// </summary>
		[JsonProperty("scale")]
		public double? Scale { get; set; }

		/// <summary>
		///     波纹的绘制方式，可选 'stroke' 和 'fill'。
		/// </summary>
		[JsonProperty("brushType")]
		public string BrushType { get; set; }
	}
}