using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 数据更新动画的缓动效果。
	/// </summary>
	public class SeriesPictorialBar_AnimationEasingUpdate
	{
		/// <summary>
		/// 动画开始之前的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
		/// 如下示例：
		/// animationDelay: function (dataIndex, params) {
		///     return params.index * 30;
		/// }
		/// 或者反向：
		/// animationDelay: function (dataIndex, params) {
		///     return (params.count - 1 - params.index) * 30;
		/// }
		/// 
		/// 例子：
		/// </summary>
		[JsonProperty("animationDelay")]
		public StringOrNumber AnimationDelay { get; set; }

		/// <summary>
		/// 数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
		/// 如下示例：
		/// animationDelay: function (dataIndex, params) {
		///     return params.index * 30;
		/// }
		/// 或者反向：
		/// animationDelay: function (dataIndex, params) {
		///     return (params.count - 1 - params.index) * 30;
		/// }
		/// 
		/// 例子：
		/// </summary>
		[JsonProperty("animationDelayUpdate")]
		public StringOrNumber AnimationDelayUpdate { get; set; }
	}
}