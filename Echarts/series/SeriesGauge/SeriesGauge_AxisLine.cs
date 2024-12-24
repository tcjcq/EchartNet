using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 仪表盘轴线相关配置。
	/// </summary>
	public class SeriesGauge_AxisLine
	{
		/// <summary>
		/// 是否显示仪表盘轴线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 是否在两端显示成圆形。
		/// </summary>
		[JsonProperty("roundCap")]
		public bool? RoundCap { get; set; }

		/// <summary>
		/// 仪表盘轴线样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public SeriesGauge_AxisLine_LineStyle LineStyle { get; set; }
	}
}