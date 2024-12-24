using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 淡出状态配置。
	/// </summary>
	public class SeriesTreemap_Blur
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("upperLabel")]
		public Label1 UpperLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle7 ItemStyle { get; set; }
	}
}