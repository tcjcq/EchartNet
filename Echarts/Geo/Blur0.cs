using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.1.0 开始支持
	///     淡出状态下的多边形和标签样式。
	/// </summary>
	public class Blur0
	{
		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }
	}
}