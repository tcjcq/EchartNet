using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     坐标轴在 grid 区域中的分隔线。
	/// </summary>
	public class Radar_SplitLine
	{
		/// <summary>
		///     是否显示分隔线。默认数值轴显示，类目轴不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle2 LineStyle { get; set; }
	}
}