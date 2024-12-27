using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     标域左上角的数据
	/// </summary>
	public class SeriesMap_MarkArea_Data_D0
	{
		/// <summary>
		///     在使用 type 时有效，用于指定在哪个维度上指定最大值最小值，可以是 0（xAxis, radiusAxis），1（yAxis, angleAxis），默认使用第一个数值轴所在的维度。
		/// </summary>
		[JsonProperty("valueIndex")]
		public double? ValueIndex { get; set; }

		/// <summary>
		///     在使用 type 时有效，用于指定在哪个维度上指定最大值最小值。这可以是维度的直接名称，例如折线图时可以是x、angle等、candlestick 图时可以是open、close等维度名称。
		/// </summary>
		[JsonProperty("valueDim")]
		public string ValueDim { get; set; }

		/// <summary>
		///     起点或终点的坐标。坐标格式视系列的坐标系而定，可以是直角坐标系上的 x, y，也可以是极坐标系上的 radius, angle。
		/// </summary>
		[JsonProperty("coord")]
		public double[] Coord { get; set; }

		/// <summary>
		///     标注名称，将会作为文字显示。定义后可在 label formatter 中作为数据名 {b} 模板变量使用。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     相对容器的屏幕 x 坐标，单位像素，支持百分比形式，例如 '20%'。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		///     相对容器的屏幕 y 坐标，单位像素，支持百分比形式，例如 '20%'。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		///     标域值，可以不设。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		///     该数据项区域的样式，起点和终点项的 itemStyle 会合并到一起。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		///     该数据项标签的样式，起点和终点项的 label 会合并到一起。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public Blur2 Blur { get; set; }
	}
}