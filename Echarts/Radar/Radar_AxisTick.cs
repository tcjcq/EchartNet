using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     坐标轴刻度相关设置。
	/// </summary>
	public class Radar_AxisTick
	{
		/// <summary>
		///     是否显示坐标轴刻度。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     坐标轴刻度的长度。
		/// </summary>
		[JsonProperty("length")]
		public double? Length { get; set; }

		/// <summary>
		///     刻度线的样式设置。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		///     从 v5.5.1 开始支持
		///     自定义要显示的坐标轴刻度位置。例如：
		///     axisTick: {
		///     alignWithLabel: true,
		///     customValues: [0, 0.5, 1, 1.5, 2, 8, 9]
		///     }
		/// </summary>
		[JsonProperty("customValues")]
		public double[] CustomValues { get; set; }
	}
}