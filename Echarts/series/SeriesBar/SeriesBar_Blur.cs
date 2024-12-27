using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     淡出时的图形样式和标签样式。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesBar_Blur
	{
		/// <summary>
		///     图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		///     图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public SeriesBar_BackgroundStyle ItemStyle { get; set; }
	}
}