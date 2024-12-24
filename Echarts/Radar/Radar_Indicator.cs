using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 雷达图的指示器，用来指定雷达图中的多个变量（维度），如下示例。
	/// indicator: [
	///    { name: '销售（sales）', max: 6500},
	///    { name: '管理（Administration）', max: 16000, color: 'red'}, // 标签设置为红色
	///    { name: '信息技术（Information Techology）', max: 30000},
	///    { name: '客服（Customer Support）', max: 38000},
	///    { name: '研发（Development）', max: 52000},
	///    { name: '市场（Marketing）', max: 25000}
	/// ]
	/// </summary>
	public class Radar_Indicator
	{
		/// <summary>
		/// 指示器名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 指示器的最大值，可选，建议设置
		/// </summary>
		[JsonProperty("max")]
		public double? Max { get; set; }

		/// <summary>
		/// 指示器的最小值，可选，默认为 0。
		/// </summary>
		[JsonProperty("min")]
		public double? Min { get; set; }

		/// <summary>
		/// 标签特定的颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }
	}
}