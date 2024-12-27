using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     缩放和还原的标题文本。
	/// </summary>
	public class Toolbox_Feature_DataZoom_Title
	{
		/// <summary>
		/// </summary>
		[JsonProperty("zoom")]
		public string Zoom { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("back")]
		public string Back { get; set; }
	}
}