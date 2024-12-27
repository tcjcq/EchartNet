using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	///     节点淡出状态的配置。
	/// </summary>
	public class Blur8
	{
		/// <summary>
		///     该节点的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		///     定义树图边的样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle4 LineStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }
	}
}