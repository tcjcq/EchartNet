using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnPath_Shape
	{
		/// <summary>
		/// </summary>
		[JsonProperty("pathData")]
		public string PathData { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("d")]
		public string D { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("layout")]
		public string Layout { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}
}