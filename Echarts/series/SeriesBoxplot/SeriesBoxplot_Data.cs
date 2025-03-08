using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     数据格式是如下的二维数组。
///     [
///     [655, 850, 940, 980, 1175],
///     [672.5, 800, 845, 885, 1012.5],
///     [780, 840, 855, 880, 940],
///     [621.25, 767.5, 815, 865, 1011.25],
///     { // 数据项也可以是 Object，从而里面能含有对此数据项的特殊设置。
///     value: [713.75, 807.5, 810, 870, 963.75],
///     itemStyle: {...}
///     },
///     ...
///     ]
///     二维数组的每一数组项（上例中的每行）是渲染一个box，它含有五个量值，依次是：
///     [min,  Q1,  median (or Q2),  Q3,  max]
///     数据的处理
///     ECharts 并不内置对原始数据的处理，输入给 boxplot 的数据须是如上五个统计结果量值。
///     但是 ECharts 也额外提供了简单的 原始数据处理函数，如这个 例子 使用了echarts.dataTool.prepareBoxplotData 来进行简单的数据统计。
/// </summary>
public class SeriesBoxplot_Data
{
	/// <summary>
	///     数据项名称。
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	///     数据值。
	///     [min,  Q1,  median (or Q2),  Q3,  max]
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
	///     盒须图单个数据样式。
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle0 ItemStyle { get; set; }

	/// <summary>
	///     盒须图单个数据高亮状态配置。
	/// </summary>
	[JsonProperty("emphasis")]
	public Select8 Emphasis { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     盒须图单个数据淡出状态配置。
	/// </summary>
	[JsonProperty("blur")]
	public Blur10 Blur { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     盒须图单个数据选中状态配置。
	/// </summary>
	[JsonProperty("select")]
	public Select8 Select { get; set; }

	/// <summary>
	///     本系列每个数据项中特定的 tooltip 设定。
	/// </summary>
	[JsonProperty("tooltip")]
	public Tooltip1 Tooltip { get; set; }
}