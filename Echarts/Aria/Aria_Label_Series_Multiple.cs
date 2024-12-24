using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 当图表只包含多个系列时，采用的描述。
	/// </summary>
	public class Aria_Label_Series_Multiple
	{
		/// <summary>
		/// 对于所有系列的整体性描述，显示在每个系列描述之前。其中包括模板变量：
		/// 
		/// {seriesCount}：将被替换为系列个数。
		/// </summary>
		[JsonProperty("prefix")]
		public string Prefix { get; set; }

		/// <summary>
		/// 如果系列有 name 属性，则采用该描述。其中包括模板变量：
		/// 
		/// {seriesName}：将被替换为系列的 name；
		/// {seriesType}：将被替换为系列的类型名称，如：'柱状图'、 '折线图' 等等。
		/// </summary>
		[JsonProperty("withName")]
		public string WithName { get; set; }

		/// <summary>
		/// 如果系列没有 name 属性，则采用该描述。其中包括模板变量：
		/// 
		/// {seriesType}：将被替换为系列的类型名称，如：'柱状图'、 '折线图' 等等。
		/// </summary>
		[JsonProperty("withoutName")]
		public string WithoutName { get; set; }

		/// <summary>
		/// 系列与系列之间描述的分隔符。
		/// </summary>
		[JsonProperty("separator")]
		public Aria_Label_Data_Separator Separator { get; set; }
	}
}