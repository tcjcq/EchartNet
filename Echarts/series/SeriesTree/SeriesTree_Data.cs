using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     series-tree.data 的数据格式是树状结构的，例如：
	///     { // 注意，最外层是一个对象，代表树的根节点
	///     name: "flare",    // 节点的名称，当前节点 label 对应的文本
	///     label: {          // 此节点特殊的 label 配置（如果需要的话）。
	///     ...           // label的格式参见 series-tree.label。
	///     },
	///     itemStyle: {      // 此节点特殊的 itemStyle 配置（如果需要的话）。
	///     ...           // label的格式参见 series-tree.itemStyle。
	///     },
	///     children: [
	///     {
	///     name: "flex",
	///     value: 4116,    // value 值，只在 tooltip 中显示
	///     label: {
	///     ...
	///     },
	///     itemStyle: {
	///     ...
	///     },
	///     collapsed: null, // 如果为 true，表示此节点默认折叠。
	///     children: [...] // 叶子节点没有 children, 可以不写
	///     },
	///     ...
	///     ]
	///     };
	/// </summary>
	public class SeriesTree_Data
	{
		/// <summary>
		///     树节点的名称，用来标识每一个节点。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     节点的值，在 tooltip 中显示。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		///     节点初始化是否折叠。
		/// </summary>
		[JsonProperty("collapsed")]
		public bool? Collapsed { get; set; }

		/// <summary>
		///     该节点的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		///     该节点对应的边的样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle4 LineStyle { get; set; }

		/// <summary>
		///     该节点的标签。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		///     节点高亮状态的配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis6 Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     节点淡出状态的配置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur8 Blur { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     节点选中状态的配置。
		/// </summary>
		[JsonProperty("select")]
		public Emphasis6 Select { get; set; }

		/// <summary>
		///     本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }

		/// <summary>
		///     是否开启动画。
		/// </summary>
		[JsonProperty("animation")]
		public bool? Animation { get; set; }

		/// <summary>
		///     是否开启动画的阈值，当单个系列显示的图形数量大于这个阈值时会关闭动画。
		/// </summary>
		[JsonProperty("animationThreshold")]
		public double? AnimationThreshold { get; set; }

		/// <summary>
		///     初始动画的时长，支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的初始动画效果：
		///     animationDuration: function (idx) {
		///     // 越往后的数据时长越大
		///     return idx * 100;
		///     }
		/// </summary>
		[JsonProperty("animationDuration")]
		public StringOrNumber AnimationDuration { get; set; }

		/// <summary>
		///     初始动画的缓动效果。不同的缓动效果可以参考 缓动示例。
		/// </summary>
		[JsonProperty("animationEasing")]
		public string AnimationEasing { get; set; }

		/// <summary>
		///     初始动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的初始动画效果。
		///     如下示例：
		///     animationDelay: function (idx) {
		///     // 越往后的数据延迟越大
		///     return idx * 100;
		///     }
		///     也可以看该示例
		/// </summary>
		[JsonProperty("animationDelay")]
		public StringOrNumber AnimationDelay { get; set; }

		/// <summary>
		///     数据更新动画的时长。
		///     支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的更新动画效果：
		///     animationDurationUpdate: function (idx) {
		///     // 越往后的数据时长越大
		///     return idx * 100;
		///     }
		/// </summary>
		[JsonProperty("animationDurationUpdate")]
		public StringOrNumber AnimationDurationUpdate { get; set; }

		/// <summary>
		///     数据更新动画的缓动效果。
		/// </summary>
		[JsonProperty("animationEasingUpdate")]
		public string AnimationEasingUpdate { get; set; }

		/// <summary>
		///     数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
		///     如下示例：
		///     animationDelayUpdate: function (idx) {
		///     // 越往后的数据延迟越大
		///     return idx * 100;
		///     }
		///     也可以看该示例
		/// </summary>
		[JsonProperty("animationDelayUpdate")]
		public StringOrNumber AnimationDelayUpdate { get; set; }
	}
}