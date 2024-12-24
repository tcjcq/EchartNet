using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 高光特效。高光特效用来表现很“亮”的颜色，因为传统的 RGB 只能表现0 - 255范围的颜色，所以对于超出这个范围特别“亮”的颜色，会通过这种高光溢出的特效去表现。如下图：
	/// </summary>
	public class Globe_PostEffect_Bloom
	{
		/// <summary>
		/// 是否开启光晕特效。
		/// </summary>
		[JsonProperty("enable")]
		public bool? Enable { get; set; }

		/// <summary>
		/// 光晕的强度，默认为 0.1
		/// </summary>
		[JsonProperty("bloomIntensity")]
		public double? BloomIntensity { get; set; }
	}
}