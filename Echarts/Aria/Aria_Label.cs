using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     如果 aria.enabled 设置为 true，label 默认开启。开启后，会根据图表、数据、标题等情况，自动智能生成关于图表的描述，用户也可以通过配置项修改描述。
	///     例子：
	///     option = {
	///     aria: {
	///     // 下面几行可以不写，因为 label.enabled 默认 true
	///     // label: {
	///     //     enabled: true
	///     // },
	///     enabled: true
	///     },
	///     title: {
	///     text: '某站点用户访问来源',
	///     x: 'center'
	///     },
	///     series: [
	///     {
	///     name: '访问来源',
	///     type: 'pie',
	///     data: [
	///     { value: 335, name: '直接访问' },
	///     { value: 310, name: '邮件营销' },
	///     { value: 234, name: '联盟广告' },
	///     { value: 135, name: '视频广告' },
	///     { value: 1548, name: '搜索引擎' }
	///     ]
	///     }
	///     ]
	///     };
	///     生成的图表 DOM 上，会有一个 aria-label 属性，在朗读设备的帮助下，盲人能够了解图表的内容。其值为：
	///     这是一个关于“某站点用户访问来源”的图表。图表类型是饼图，表示访问来源。其数据是——直接访问的数据是335，邮件营销的数据是310，联盟广告的数据是234，视频广告的数据是135，搜索引擎的数据是1548。
	///     生成描述的基本流程为，如果 aria.enabled 设置为 true（非默认）且 aria.label.enabled 设置为 true（默认），则生成无障碍访问描述，否则不生成。如果定义了
	///     aria.label.description，则将其作为图表的完整描述，否则根据模板拼接生成描述。我们提供了默认的生成描述的算法，仅当生成的描述不太合适时，才需要修改这些模板，甚至使用 aria.label.description
	///     完全覆盖。
	///     使用模板拼接时，先根据是否存在标题 title.text 决定使用 aria.label.general.withTitle 还是 aria.label.general.withoutTitle
	///     作为整体性描述。其中，aria.label.general.withTitle 配置项包括模板变量 '{title}'，将会被替换成图表标题。也就是说，如果 aria.label.general.withTitle 被设置为
	///     '图表的标题是：{title}。'，则如果包含标题 '价格分布图'，这部分的描述为 '图表的标题是：价格分布图。'。
	///     拼接完标题之后，会依次拼接系列的描述（aria.label.series），和每个系列的数据的描述（aria.label.data）。同样，每个模板都有可能包括模板变量，用以替换实际的值。
	///     完整的描述生成流程为：
	/// </summary>
	public class Aria_Label
	{
		/// <summary>
		///     是否开启无障碍访问的标签生成。开启后将生成 aria-label 属性。
		/// </summary>
		[JsonProperty("enabled")]
		public bool? Enabled { get; set; }

		/// <summary>
		///     默认采用算法自动生成图表描述，如果用户需要完全自定义，可以将这个值设为描述。如将其设置为 '这是一个展示了价格走势的图表'，则图表 DOM 元素的 aria-label 属性值即为该字符串。
		///     这一配置项常用于展示单个的数据并不能展示图表内容时，用户显示指定概括性描述图表的文字。例如图表是一个包含大量散点图的地图，默认的算法只能显示数据点的位置，不能从整体上传达作者的意图。这时候，可以将 description
		///     指定为作者想表达的内容即可。
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///     对于图表的整体性描述。
		/// </summary>
		[JsonProperty("general")]
		public Aria_Label_General General { get; set; }

		/// <summary>
		///     系列相关的配置项。
		/// </summary>
		[JsonProperty("series")]
		public Aria_Label_Series Series { get; set; }

		/// <summary>
		///     数据相关的配置项。
		/// </summary>
		[JsonProperty("data")]
		public Aria_Label_Data Data { get; set; }
	}
}