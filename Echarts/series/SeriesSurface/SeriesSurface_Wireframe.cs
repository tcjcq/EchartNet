using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     曲面图的网格线。
	/// </summary>
	public class SeriesSurface_Wireframe
	{
		/// <summary>
		///     是否显示网格线。默认显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     网格线的样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }
	}
}