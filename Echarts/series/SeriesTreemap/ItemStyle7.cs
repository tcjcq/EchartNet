using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// </summary>
	public class ItemStyle7
	{
		/// <summary>
		///     矩形的颜色。默认从全局调色盘 option.color 获取颜色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }
	}
}