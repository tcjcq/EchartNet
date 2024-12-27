using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     叶子节点的特殊配置，如上面的树图实例中，叶子节点和非叶子节点的标签位置不同。
	/// </summary>
	public class SeriesTree_Leaves
	{
		/// <summary>
		///     描述了叶子节点所对应的文本标签的样式。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		///     树图中叶子节点的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		///     叶子节点高亮状态的配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis6 Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     叶子节点淡出状态的配置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur8 Blur { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     叶子节点选中状态的配置。
		/// </summary>
		[JsonProperty("select")]
		public Emphasis6 Select { get; set; }
	}
}