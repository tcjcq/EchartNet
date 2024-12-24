using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// visualMap 组件中，控制器 的 inRange outOfRange 设置。如果没有这个 controller 设置，控制器 会使用外层的 inRange outOfRange 设置；如果有这个 controller 设置，则会采用这个设置。适用于一些控制器视觉效果需要特殊定制或调整的场景。
	/// </summary>
	public class VisualMapContinuous_Controller
	{
		/// <summary>
		/// 定义 在选中范围中 的视觉元素。（用户可以和 visualMap 组件交互，用鼠标或触摸选择范围）
		/// 配置参考 visualMap-continuous.inRange
		/// </summary>
		[JsonProperty("inRange")]
		public object InRange { get; set; }

		/// <summary>
		/// 定义 在选中范围外 的视觉元素。（用户可以和 visualMap 组件交互，用鼠标或触摸选择范围）
		/// 配置参考 visualMap-continuous.inRange
		/// </summary>
		[JsonProperty("outOfRange")]
		public object OutOfRange { get; set; }
	}
}