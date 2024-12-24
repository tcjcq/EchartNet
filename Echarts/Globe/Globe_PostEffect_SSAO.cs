using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 同 screenSpaceAmbientOcclusion
	/// </summary>
	public class Globe_PostEffect_SSAO
	{
		/// <summary>
		/// 是否开启环境光遮蔽。默认不开启。
		/// </summary>
		[JsonProperty("enable")]
		public bool? Enable { get; set; }

		/// <summary>
		/// 环境光遮蔽的质量。支持'low', 'medium', 'high', 'ultra'。
		/// </summary>
		[JsonProperty("quality")]
		public string Quality { get; set; }

		/// <summary>
		/// 环境光遮蔽的采样半径。半径越大效果越自然，但是需要设置较高的'quality'。
		/// 下面是半径值较小与较大之间的区别：
		/// </summary>
		[JsonProperty("radius")]
		public double? Radius { get; set; }

		/// <summary>
		/// 环境光遮蔽的强度。值越大颜色越深。
		/// </summary>
		[JsonProperty("intensity")]
		public double? Intensity { get; set; }
	}
}