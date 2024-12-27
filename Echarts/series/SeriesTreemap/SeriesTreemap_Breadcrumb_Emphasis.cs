using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.4.0 开始支持
	/// </summary>
	public class SeriesTreemap_Breadcrumb_Emphasis
	{
		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public SeriesTreemap_Breadcrumb_ItemStyle ItemStyle { get; set; }
	}
}