using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 选中状态的配置。开启 selectedMode 后有效。
	/// </summary>
	public class Select4
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

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
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}
}