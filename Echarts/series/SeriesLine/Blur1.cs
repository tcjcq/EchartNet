using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     单个拐点的淡出样式和标签设置。
	/// </summary>
	public class Blur1
	{
		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}
}