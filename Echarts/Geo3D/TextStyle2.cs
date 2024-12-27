using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     标签的字体样式。
	/// </summary>
	public class TextStyle2
	{
		/// <summary>
		///     文字的颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		///     文字的描边宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		///     文字的描边颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public string BorderColor { get; set; }

		/// <summary>
		///     文字的字体系列。
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		///     文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		///     文字字体的粗细。
		///     可选：
		///     'normal'
		///     'bold'
		///     'bolder'
		///     'lighter'
		///     100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public string FontWeight { get; set; }
	}
}