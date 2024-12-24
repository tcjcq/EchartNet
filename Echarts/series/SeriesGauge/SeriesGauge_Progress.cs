using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 从 v5.0 开始支持
	/// 
	/// 展示当前进度。
	/// </summary>
	public class SeriesGauge_Progress
	{
		/// <summary>
		/// 是否显示进度条。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 多组数据时进度条是否重叠。
		/// </summary>
		[JsonProperty("overlap")]
		public bool? Overlap { get; set; }

		/// <summary>
		/// 进度条宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 是否在两端显示成圆形。
		/// </summary>
		[JsonProperty("roundCap")]
		public bool? RoundCap { get; set; }

		/// <summary>
		/// 是否裁掉超出部分。
		/// </summary>
		[JsonProperty("clip")]
		public bool? Clip { get; set; }

		/// <summary>
		/// 进度条样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}
}