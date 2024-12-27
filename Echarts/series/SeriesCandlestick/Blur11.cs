using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	///     K 线图的淡出状态。开启 emphasis.focus 后有效
	/// </summary>
	public class Blur11
	{
		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle9 ItemStyle { get; set; }
	}
}