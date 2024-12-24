using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 高亮状态下的多边形和标签样式。
	/// </summary>
	public class Geo_Emphasis
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
		/// 从 v5.1.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 
		/// 示例：
		/// 下面代码配置了 geo 在高亮一个图形的时候，淡出所有其它的图形。
		/// emphasis: {
		///     focus: 'self'
		/// }
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }
	}
}