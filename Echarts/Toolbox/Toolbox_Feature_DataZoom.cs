using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 数据区域缩放。目前只支持直角坐标系的缩放。
	/// </summary>
	public class Toolbox_Feature_DataZoom
	{
		/// <summary>
		/// 是否显示该工具。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 缩放和还原的标题文本。
		/// </summary>
		[JsonProperty("title")]
		public Toolbox_Feature_DataZoom_Title Title { get; set; }

		/// <summary>
		/// 缩放和还原的 icon path。
		/// </summary>
		[JsonProperty("icon")]
		public Toolbox_Feature_DataZoom_Title Icon { get; set; }

		/// <summary>
		/// 数据区域缩放 icon 样式设置。由于 icon 的文本信息只在 icon hover 时候才显示，所以文字相关的配置项请在 emphasis 下设置。
		/// </summary>
		[JsonProperty("iconStyle")]
		public HandleStyle0 IconStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Toolbox_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 与 dataZoom.filterMode 含义和取值相同。
		/// </summary>
		[JsonProperty("filterMode")]
		public string FilterMode { get; set; }

		/// <summary>
		/// 指定哪些 xAxis 被控制。如果缺省则控制所有的x轴。如果设置为 false 则不控制任何x轴。如果设置成 3 则控制 axisIndex 为 3 的x轴。如果设置为 [0, 3] 则控制 axisIndex 为 0 和 3 的x轴。
		/// </summary>
		[JsonProperty("xAxisIndex")]
		public ArrayOrSingle XAxisIndex { get; set; }

		/// <summary>
		/// 指定哪些 yAxis 被控制。如果缺省则控制所有的y轴。如果设置为 false 则不控制任何y轴。如果设置成 3 则控制 axisIndex 为 3 的y轴。如果设置为 [0, 3] 则控制 axisIndex 为 0 和 3 的y轴。
		/// </summary>
		[JsonProperty("yAxisIndex")]
		public ArrayOrSingle YAxisIndex { get; set; }

		/// <summary>
		/// 刷选框样式
		/// </summary>
		[JsonProperty("brushStyle")]
		public HandleStyle0 BrushStyle { get; set; }
	}
}