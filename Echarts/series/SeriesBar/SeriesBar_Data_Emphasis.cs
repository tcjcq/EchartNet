using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     单个数据的高亮状态配置。
	/// </summary>
	public class SeriesBar_Data_Emphasis
	{
		/// <summary>
		///     从 v5.3.0 开始支持
		///     是否关闭高亮状态。
		///     关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		///     单个数据的文本配置。
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		///     单个数据的图形样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public SeriesBar_BackgroundStyle ItemStyle { get; set; }
	}
}