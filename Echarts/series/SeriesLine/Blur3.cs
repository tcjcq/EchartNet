using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 标线的淡出样式。淡出的规则跟随所在系列。
	/// </summary>
	public class Blur3
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}
}