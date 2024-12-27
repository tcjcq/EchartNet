using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     数据与数据之间描述的分隔符。
	/// </summary>
	public class Aria_Label_Data_Separator
	{
		/// <summary>
		///     除了最后一个数据后的分隔符。
		/// </summary>
		[JsonProperty("middle")]
		public string Middle { get; set; }

		/// <summary>
		///     最后一个数据后的分隔符。
		///     需要注意的是，通常最后一个数据后是系列的 separator.end，所以 data.separator.end 在大多数情况下为空字符串。
		/// </summary>
		[JsonProperty("end")]
		public string End { get; set; }
	}
}