using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     选中状态下的多边形和标签样式。
	/// </summary>
	public class Select0
	{
		/// <summary>
		///     从 v5.3.0 开始支持
		///     是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

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