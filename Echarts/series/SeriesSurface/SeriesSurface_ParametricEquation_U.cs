using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 自变量 u。
	/// </summary>
	public class SeriesSurface_ParametricEquation_U
	{
		/// <summary>
		/// u 的步长。
		/// </summary>
		[JsonProperty("step")]
		public double? Step { get; set; }

		/// <summary>
		/// u 的最小值。
		/// </summary>
		[JsonProperty("min")]
		public double? Min { get; set; }

		/// <summary>
		/// u 的最大值。
		/// </summary>
		[JsonProperty("max")]
		public double? Max { get; set; }
	}
}