using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	///     数据选中时的图形样式和标签样式。开启 selectedMode 后有效。
	/// </summary>
	public class Select8
	{
		/// <summary>
		///     从 v5.3.0 开始支持
		///     是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}
}