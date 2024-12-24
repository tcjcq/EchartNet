using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 
	/// </summary>
	public class Timeline_Emphasis
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label2 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 当前项『高亮状态』的样式（hover时）。
		/// </summary>
		[JsonProperty("checkpointStyle")]
		public Timeline_CheckpointStyle CheckpointStyle { get; set; }

		/// <summary>
		/// 控制按钮的『高亮状态』的样式（hover时）。
		/// </summary>
		[JsonProperty("controlStyle")]
		public Timeline_ControlStyle ControlStyle { get; set; }
	}
}