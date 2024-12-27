using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.0.0 开始支持
	///     选中的线条和标签样式。开启 selectedMode 后有效。
	/// </summary>
	public class Select10
	{
		/// <summary>
		///     从 v5.3.0 开始支持
		///     是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("label")]
		public Label12 Label { get; set; }
	}
}