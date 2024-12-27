using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     图形和标签高亮的样式。
	/// </summary>
	public class SeriesScatter3D_Emphasis
	{
		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public SeriesScatter3D_Label Label { get; set; }
	}
}