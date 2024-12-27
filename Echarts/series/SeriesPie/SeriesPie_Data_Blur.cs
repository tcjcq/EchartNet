using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	/// </summary>
	public class SeriesPie_Data_Blur
	{
		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public Label8 Label { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle5 ItemStyle { get; set; }
	}
}