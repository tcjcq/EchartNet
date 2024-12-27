using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     全局的环境光设置。
	/// </summary>
	public class Globe_Light_Ambient
	{
		/// <summary>
		///     环境光的颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		///     环境光的强度。
		/// </summary>
		[JsonProperty("intensity")]
		public double? Intensity { get; set; }
	}
}