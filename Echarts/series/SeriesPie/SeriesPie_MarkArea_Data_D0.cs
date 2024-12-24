using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 标域左上角的数据
	/// </summary>
	public class SeriesPie_MarkArea_Data_D0
	{
		/// <summary>
		/// 标注名称，将会作为文字显示。定义后可在 label formatter 中作为数据名 {b} 模板变量使用。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 相对容器的屏幕 x 坐标，单位像素，支持百分比形式，例如 '20%'。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 相对容器的屏幕 y 坐标，单位像素，支持百分比形式，例如 '20%'。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 标域值，可以不设。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 该数据项区域的样式，起点和终点项的 itemStyle 会合并到一起。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 该数据项标签的样式，起点和终点项的 label 会合并到一起。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public Blur2 Blur { get; set; }
	}
}