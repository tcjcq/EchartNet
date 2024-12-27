using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     坐标轴名字的截断。
	/// </summary>
	public class XAxis_NameTruncate
	{
		/// <summary>
		///     截断文本的最大长度，超过此长度会被截断。
		/// </summary>
		[JsonProperty("maxWidth")]
		public double? MaxWidth { get; set; }

		/// <summary>
		///     截断后文字末尾显示的内容。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }
	}
}