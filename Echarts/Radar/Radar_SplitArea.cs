using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 坐标轴在 grid 区域中的分隔区域，默认不显示。
	/// </summary>
	public class Radar_SplitArea
	{
		/// <summary>
		/// 是否显示分隔区域。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 分隔区域的样式设置。
		/// </summary>
		[JsonProperty("areaStyle")]
		public AreaStyle0 AreaStyle { get; set; }
	}
}