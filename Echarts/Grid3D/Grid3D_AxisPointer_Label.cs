using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     指示线标签。
	/// </summary>
	public class Grid3D_AxisPointer_Label
	{
		/// <summary>
		///     是否显示指示线标签。默认数值轴显示，类目轴不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     标签格式器，函数第一个参数是当前坐标轴的数值，第二个参数是所有坐标轴的数值数组。
		///     (value: number, valueAll: Array) => string
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		///     标签距离坐标轴的距离。同刻度标签一样，这个距离是三维空间而非屏幕像素。
		/// </summary>
		[JsonProperty("margin")]
		public double? Margin { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("textStyle")]
		public TextStyle2 TextStyle { get; set; }
	}
}