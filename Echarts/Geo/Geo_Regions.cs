using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 在地图中对特定的区域配置样式。
	/// 例如：
	/// regions: [{
	///     name: '广东',
	///     itemStyle: {
	///         areaColor: 'red',
	///         color: 'red'
	///     }
	/// }]
	/// 
	/// geo 区域的颜色也可以被 map series 所控制，参见 series-map.geoIndex。
	/// </summary>
	public class Geo_Regions
	{
		/// <summary>
		/// 地图区域的名称，例如 '广东'，'浙江'。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 该区域是否选中。
		/// </summary>
		[JsonProperty("selected")]
		public bool? Selected { get; set; }

		/// <summary>
		/// 该区域的多边形样式设置
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }

		/// <summary>
		/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 高亮状态的设置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Blur0 Emphasis { get; set; }

		/// <summary>
		/// 选中状态的设置。
		/// </summary>
		[JsonProperty("select")]
		public Blur0 Select { get; set; }

		/// <summary>
		/// 从 v5.1.0 开始支持
		/// 
		/// 淡出状态的设置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur0 Blur { get; set; }

		/// <summary>
		/// 从 v5.1.0 开始支持
		/// 
		/// 本 region 中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip0 Tooltip { get; set; }
	}
}