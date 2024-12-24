using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 在坐标轴上可以进行框选，这里是一些框选的设置。
	/// </summary>
	public class ParallelAxis_AreaSelectStyle
	{
		/// <summary>
		/// 框选范围的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 选框的边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 选框的边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 选框的填充色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 选框的透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }
	}
}