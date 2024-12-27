using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	///     淡出状态的图形样式。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesGraph_Blur
	{
		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("edgeLabel")]
		public Label12 EdgeLabel { get; set; }
	}
}