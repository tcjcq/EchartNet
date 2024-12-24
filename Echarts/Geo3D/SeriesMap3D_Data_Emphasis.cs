using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 单个区域的标签和样式的高亮设置。
	/// </summary>
	public class SeriesMap3D_Data_Emphasis
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }
	}
}