using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 鼠标 hover 高亮时图形和标签的样式。
	/// </summary>
	public class SeriesMap3D_Emphasis
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle12 ItemStyle { get; set; }
	}
}