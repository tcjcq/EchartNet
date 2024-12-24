using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 定义树图边的样式。
	/// </summary>
	public class LineStyle4
	{
		/// <summary>
		/// 树图边的颜色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 树图边的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 树图边的曲度。
		/// </summary>
		[JsonProperty("curveness")]
		public double? Curveness { get; set; }

		/// <summary>
		/// 图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		/// 示例：
		/// {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		/// }
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影颜色。支持的格式同color。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 阴影水平方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影垂直方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }
	}
}