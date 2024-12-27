using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     坐标轴轴线相关设置。
	/// </summary>
	public class XAxis_AxisLine
	{
		/// <summary>
		///     是否显示坐标轴轴线。
		///     从 v5.0.0 开始，数值轴 (type: 'value') 默认不显示轴线，需要显式配置。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     X 轴或者 Y 轴的轴线是否在另一个轴的 0 刻度上，只有在另一个轴为数值轴且包含 0 刻度时有效。
		/// </summary>
		[JsonProperty("onZero")]
		public bool? OnZero { get; set; }

		/// <summary>
		///     当有双轴时，可以用这个属性手动指定，在哪个轴的 0 刻度上。
		/// </summary>
		[JsonProperty("onZeroAxisIndex")]
		public double? OnZeroAxisIndex { get; set; }

		/// <summary>
		///     轴线两边的箭头。可以是字符串，表示两端使用同样的箭头；或者长度为 2 的字符串数组，分别表示两端的箭头。默认不显示箭头，即 'none'。两端都显示箭头可以设置为 'arrow'，只在末端显示箭头可以设置为 ['none',
		///     'arrow']。
		/// </summary>
		[JsonProperty("symbol")]
		public ArrayOrSingle Symbol { get; set; }

		/// <summary>
		///     轴线两边的箭头的大小，第一个数字表示宽度（垂直坐标轴方向），第二个数字表示高度（平行坐标轴方向）。
		/// </summary>
		[JsonProperty("symbolSize")]
		public double[] SymbolSize { get; set; }

		/// <summary>
		///     轴线两边的箭头的偏移，如果是数组，第一个数字表示起始箭头的偏移，第二个数字表示末端箭头的偏移；如果是数字，表示这两个箭头使用同样的偏移。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public ArrayOrSingle SymbolOffset { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}
}