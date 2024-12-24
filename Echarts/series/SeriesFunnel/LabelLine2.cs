using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 标签的视觉引导线样式，在 label 位置 设置为'left'或者'right'的时候会显示视觉引导线。
	/// </summary>
	public class LabelLine2
	{
		/// <summary>
		/// 是否显示视觉引导线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 视觉引导线的长度。
		/// </summary>
		[JsonProperty("length")]
		public double? Length { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}
}