using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     数据阴影的样式。
	/// </summary>
	public class DataZoomSlider_DataBackground
	{
		/// <summary>
		///     阴影的线条样式
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		///     阴影的填充样式
		/// </summary>
		[JsonProperty("areaStyle")]
		public ShadowStyle0 AreaStyle { get; set; }
	}
}