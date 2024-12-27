using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	///     高亮样式设置。
	/// </summary>
	public class DataZoomSlider_Emphasis
	{
		/// <summary>
		/// </summary>
		[JsonProperty("handleStyle")]
		public HandleStyle0 HandleStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("moveHandleStyle")]
		public HandleStyle0 MoveHandleStyle { get; set; }
	}
}