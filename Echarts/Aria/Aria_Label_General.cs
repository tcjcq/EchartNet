using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     对于图表的整体性描述。
	/// </summary>
	public class Aria_Label_General
	{
		/// <summary>
		///     如果图表存在 title.text，则采用 withTitle。其中包括模板变量：
		///     {title}：将被替换为图表的 title.text。
		/// </summary>
		[JsonProperty("withTitle")]
		public string WithTitle { get; set; }

		/// <summary>
		///     如果图表不存在 title.text，则采用 withoutTitle。
		/// </summary>
		[JsonProperty("withoutTitle")]
		public string WithoutTitle { get; set; }
	}
}