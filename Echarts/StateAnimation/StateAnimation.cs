using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 状态切换的动画配置，支持在每个系列里设置单独针对该系列的配置。
	/// </summary>
	public class StateAnimation
	{
		/// <summary>
		/// 状态切换的动画时长，设为 0 则关闭状态动画。
		/// </summary>
		[JsonProperty("duration")]
		public double? Duration { get; set; }

		/// <summary>
		/// 状态切换的动画缓动。
		/// </summary>
		[JsonProperty("easing")]
		public string Easing { get; set; }
	}
}