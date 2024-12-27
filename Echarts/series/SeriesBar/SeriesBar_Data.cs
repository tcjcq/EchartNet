using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     系列中的数据内容数组。数组项通常为具体的数据项。
	///     注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
	///     可以使用 series.datasetIndex 指定其他的 dataset。
	///     通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
	///     series: [{
	///     data: [
	///     // 维度X   维度Y   其他维度 ...
	///     [  3.4,    4.5,   15,   43],
	///     [  4.2,    2.3,   20,   91],
	///     [  10.8,   9.5,   30,   18],
	///     [  7.2,    8.8,   18,   57]
	///     ]
	///     }]
	///     在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
	///     在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
	///     后面的其他维度是可选的，可以在别处被使用，例如：
	///     在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
	///     在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
	///     使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
	///     特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
	///     xAxis: {
	///     data: ['a', 'b', 'm', 'n']
	///     },
	///     series: [{
	///     // 与 xAxis.data 一一对应。
	///     data: [23,  44,  55,  19]
	///     // 它其实是下面这种形式的简化：
	///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
	///     }]
	///     『值』与 轴类型 的关系：
	///     当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
	///     其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
	///     当某维度对应于类目轴（axis.type 为 'category'）的时候：
	///     其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
	///     xAxis: {
	///     type: 'category',
	///     data: ['星期一', '星期二', '星期三', '星期四']
	///     },
	///     yAxis: {
	///     type: 'category',
	///     data: ['a', 'b', 'm', 'n', 'p', 'q']
	///     },
	///     series: [{
	///     data: [
	///     // xAxis    yAxis
	///     [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
	///     [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
	///     [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
	///     [  3,        3,    5  ]
	///     ]
	///     }]
	///     双类目轴的示例可以参考 Github Punchcard 示例。
	///     当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
	///     一个时间戳，如 1484141700832，表示 UTC 时间。
	///     或者字符串形式的时间描述：
	///     ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
	///     部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
	///     使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
	///     时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
	///     其他的时间字符串，包括（均表示本地时间）:
	///     '2012', '2012-3-1', '2012/3/1', '2012/03/01',
	///     '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
	///     或者用户自行初始化的 Date 实例：
	///     注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
	///     例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01')
	///     表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
	///     所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
	///     当需要对个别数据进行个性化定义时：
	///     数组项可用对象，其中的 value 像表示具体的数值，如：
	///     [
	///     12,
	///     34,
	///     {
	///     value : 56,
	///     //自定义标签样式，仅对该数据项有效
	///     label: {},
	///     //自定义特殊 itemStyle，仅对该数据项有效
	///     itemStyle:{}
	///     },
	///     10
	///     ]
	///     // 或
	///     [
	///     [12, 33],
	///     [34, 313],
	///     {
	///     value: [56, 44],
	///     label: {},
	///     itemStyle:{}
	///     },
	///     [10, 33]
	///     ]
	///     空值：
	///     当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
	///     例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
	/// </summary>
	public class SeriesBar_Data
	{
		/// <summary>
		///     数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     单个数据项的数值。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		///     该数据项的组 ID。当全局过渡动画功能开启时，setOption 前后拥有相同组 ID 的数据项会进行动画过渡。
		///     若没有指定groupId ，会尝试用series.dataGroupId作为该数据项的组 ID；若series.dataGroupId也没有指定，则会使用数据项的 ID 作为组 ID。
		///     如果你使用了dataset组件来表达数据，推荐使用encode.itemGroupId来指定哪个维度被编码为组 ID。
		/// </summary>
		[JsonProperty("groupId")]
		public string GroupId { get; set; }

		/// <summary>
		///     从 v5.5.0 开始支持
		///     该数据项对应的子数据组 ID，用于实现多层下钻和聚合。
		///     通过groupId已经可以达到数据下钻和聚合的效果，但只支持一层的下钻和聚合。为了实现多层下钻和聚合，我们又引入了childGroupId。
		///     引入childGroupId后，不同option的数据项之间就能形成逻辑上的父子关系，例如：
		///     data: [                        data: [                        data: [
		///     {                              {                              {
		///     name: 'Animals',               name: 'Dogs',                  name: 'Corgi',
		///     value: 3,                      value: 3,                      value: 5,
		///     groupId: 'things',             groupId: 'animals',            groupId: 'dogs'
		///     childGroupId: 'animals'        childGroupId: 'dogs'         },
		///     },                             },                             {
		///     {                              {                                name: 'Bulldog',
		///     name: 'Fruits',                name: 'Cats',                  value: 6,
		///     value: 3,                      value: 4,                      groupId: 'dogs'
		///     groupId: 'things',             groupId: 'animals',          },
		///     childGroupId: 'fruits'         childGroupId: 'cats',        {
		///     },                             },                               name: 'Shiba Inu',
		///     {                              {                                value: 7,
		///     name: 'Cars',                  name: 'Birds',                 groupId: 'dogs'
		///     value: 2,                      value: 3,                    }
		///     groupId: 'things',             groupId: 'animals',        ]
		///     childGroupId: 'cars'           childGroupId: 'birds'
		///     }                              }
		///     ]                              ]
		///     上面 3 组 data 分别来自 3 个 option ，通过groupId和childGroupId，它们之间存在了“父-子-孙”的关系。在setOption时，Apache ECharts
		///     会尝试寻找前后option数据项间的父子关系，若存在父子关系，则会对相关数据项进行下钻或聚合动画的过渡。
		///     没有对应子数据组的数据项不需要指定childGroupId。
		///     如果你使用了dataset组件来表达数据，推荐使用encode.itemChildGroupId来指定哪个维度被编码为子数据组 ID。
		/// </summary>
		[JsonProperty("childGroupId")]
		public string ChildGroupId { get; set; }

		/// <summary>
		///     单个数据的文本配置。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		///     单个数据的图形样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle4 ItemStyle { get; set; }

		/// <summary>
		///     单个数据的高亮状态配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesBar_Data_Emphasis Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     单个数据的淡出状态配置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur5 Blur { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     单个数据的选中状态配置。
		/// </summary>
		[JsonProperty("select")]
		public SeriesBar_Data_Emphasis Select { get; set; }
	}
}