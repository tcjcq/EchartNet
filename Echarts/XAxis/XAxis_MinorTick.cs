using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 从 v4.6.0 开始支持
	/// 
	/// 坐标轴次刻度线相关设置。
	/// 注意：次刻度线无法在类目轴（type: 'category'）中使用。
	/// 示例：
	/// 1) 函数绘图中使用次刻度线
	/// 
	/// 
	/// 
	/// 2) 在对数轴中使用次刻度线
	/// </summary>
	public class XAxis_MinorTick
	{
		/// <summary>
		/// 是否显示次刻度线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 次刻度线分割数，默认会分割成 5 段
		/// </summary>
		[JsonProperty("splitNumber")]
		public double? SplitNumber { get; set; }

		/// <summary>
		/// 次刻度线的长度。
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