using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     数据格式是如下的二维数组。
	///     [
	///     [2320.26, 2320.26, 2287.3,  2362.94],
	///     [2300,    2291.3,  2288.26, 2308.38],
	///     { // 数据项也可以是 Object，从而里面能含有对此数据项的特殊设置。
	///     value: [2300,    2291.3,  2288.26, 2308.38],
	///     itemStyle: {...}
	///     },
	///     ...
	///     ]
	///     二维数组的每一数组项（上例中的每行）是渲染一个box，它含有四个量值，依次是：
	///     [open, close, lowest, highest] （即：[开盘值, 收盘值, 最低值, 最高值]）
	/// </summary>
	public class SeriesCandlestick_Data
	{
		/// <summary>
		///     数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     数据项值。
		///     [open, close, lowest, highest] （即：[开盘值, 收盘值, 最低值, 最高值]）
		/// </summary>
		[JsonProperty("value")]
		public double[] Value { get; set; }

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
		///     单个 K 线图数据的图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle9 ItemStyle { get; set; }

		/// <summary>
		///     单个 K 线图数据的高亮状态配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Select9 Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     单个 K 线图数据的淡出状态配置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur11 Blur { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     单个 K 线图数据的选中状态配置。
		/// </summary>
		[JsonProperty("select")]
		public Select9 Select { get; set; }

		/// <summary>
		///     本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}
}