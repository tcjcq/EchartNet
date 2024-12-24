using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 单个拐点的高亮样式和标签设置。
	/// </summary>
	public class Emphasis0
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}
}