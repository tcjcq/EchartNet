using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// K 线图的选中状态。开启 selectedMode 后有效。
	/// </summary>
	public class Select9
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
		[JsonProperty("itemStyle")]
		public ItemStyle9 ItemStyle { get; set; }
	}
}