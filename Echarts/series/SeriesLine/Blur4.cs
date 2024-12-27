using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	/// </summary>
	public class Blur4
	{
		/// <summary>
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }
	}
}