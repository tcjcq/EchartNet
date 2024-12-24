using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 分帧超采样。在开启 postEffect 后，WebGL 默认的 MSAA 会无法使用，所以我们需要自己解决锯齿的问题。
	/// 分帧超采样是用来解决锯齿问题的方法，它在画面静止后会持续分帧对一个像素多次抖动采样，从而达到抗锯齿的效果。而且在这个分帧采样的过程中，echarts-gl 也会对 postEffect 中一些需要采样保证效果的特效，例如 SSAO, 景深，以及阴影进行渐进增强。
	/// 下面是未开启和开启temporalSuperSampling的区别。
	/// </summary>
	public class Globe_TemporalSuperSampling
	{
		/// <summary>
		/// 是否开启分帧超采样。默认在开启 postEffect 后也会同步开启。
		/// </summary>
		[JsonProperty("enable")]
		public bool? Enable { get; set; }
	}
}