using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 系列中的数据内容数组。数组项可以为单个数值，如：
	/// [12, 34, 56, 10, 23]
	/// 
	/// 如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
	/// [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
	/// 
	/// 这时候可以将每项数组中的第二个值指定给 visualMap 组件。
	/// 更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	/// [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值8
	///     value: 10
	/// }, {
	///     name: '数据2',
	///     value: 20
	/// }]
	/// 
	/// 需要对个别内容指定进行个性化定义时：
	/// [{
	///     name: '数据1',
	///     value: 10
	/// }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : 56,
	///     //自定义特殊 tooltip，仅对该数据项有效
	///     tooltip:{},
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	/// }]
	/// </summary>
	public class SeriesGauge_Data
	{
		/// <summary>
		/// 仪表盘标题。
		/// </summary>
		[JsonProperty("title")]
		public SeriesGauge_Title Title { get; set; }

		/// <summary>
		/// 仪表盘详情，用于显示数据。
		/// </summary>
		[JsonProperty("detail")]
		public SeriesGauge_Detail Detail { get; set; }

		/// <summary>
		/// 数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 数据值。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 数据项的指针样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle0 ItemStyle { get; set; }
	}
}