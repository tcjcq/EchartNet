using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     节点间的边。注意: 桑基图理论上只支持有向无环图（DAG, Directed Acyclic Graph），所以请确保输入的边是无环的. 示例：
	///     links: [{
	///     source: 'n1',
	///     target: 'n2'
	///     }, {
	///     source: 'n2',
	///     target: 'n3'
	///     }]
	/// </summary>
	public class SeriesSankey_Links
	{
		/// <summary>
		///     边的源节点名称
		/// </summary>
		[JsonProperty("source")]
		public string Source { get; set; }

		/// <summary>
		///     边的目标节点名称
		/// </summary>
		[JsonProperty("target")]
		public string Target { get; set; }

		/// <summary>
		///     边的数值，决定边的宽度。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		///     从 v5.4.1 开始支持
		///     关系边文本标签的样式。
		/// </summary>
		[JsonProperty("edgeLabel")]
		public EdgeLabel1 EdgeLabel { get; set; }

		/// <summary>
		///     关系边的线条样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle5 LineStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesSankey_Links_Emphasis Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public SeriesSankey_Links_Blur Blur { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("select")]
		public SeriesSankey_Links_Emphasis Select { get; set; }
	}
}