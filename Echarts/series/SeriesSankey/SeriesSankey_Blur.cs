using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 桑基图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesSankey_Blur
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.4.1 开始支持
		/// 
		/// 关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }
	}
}