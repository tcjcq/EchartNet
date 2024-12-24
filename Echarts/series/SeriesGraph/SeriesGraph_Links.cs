using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 节点间的关系数据。示例：
	/// links: [{
	///     source: 'n1',
	///     target: 'n2'
	/// }, {
	///     source: 'n2',
	///     target: 'n3'
	/// }]
	/// </summary>
	public class SeriesGraph_Links
	{
		/// <summary>
		/// 边的源节点名称的字符串，也支持使用数字表示源节点的索引。
		/// </summary>
		[JsonProperty("source")]
		public StringOrNumber Source { get; set; }

		/// <summary>
		/// 边的目标节点名称的字符串，也支持使用数字表示源节点的索引。
		/// </summary>
		[JsonProperty("target")]
		public StringOrNumber Target { get; set; }

		/// <summary>
		/// 边的数值，可以在力引导布局中用于映射到边的长度。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 关系边的线条样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label12 Label { get; set; }

		/// <summary>
		/// 该关系边的高亮状态。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesGraph_Links_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 该关系边的淡出状态。
		/// </summary>
		[JsonProperty("blur")]
		public SeriesGraph_Links_Blur Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 该关系边的选中状态。
		/// </summary>
		[JsonProperty("select")]
		public SeriesGraph_Links_Emphasis Select { get; set; }

		/// <summary>
		/// 边两端的标记类型，可以是一个数组分别指定两端，也可以是单个统一指定。
		/// </summary>
		[JsonProperty("symbol")]
		public ArrayOrSingle Symbol { get; set; }

		/// <summary>
		/// 边两端的标记大小，可以是一个数组分别指定两端，也可以是单个统一指定。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// 从 v4.5.0 开始支持
		/// 
		/// 使此边不进行力导图布局的计算。
		/// </summary>
		[JsonProperty("ignoreForceLayout")]
		public bool? IgnoreForceLayout { get; set; }
	}
}