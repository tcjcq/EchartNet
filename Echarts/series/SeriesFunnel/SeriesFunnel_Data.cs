using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     系列中的数据内容数组。数组项可以为单个数值，如：
///     [12, 34, 56, 10, 23]
///     如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
///     [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
///     这时候可以将每项数组中的第二个值指定给 visualMap 组件。
///     更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
///     [{
///     // 数据项的名称
///     name: '数据1',
///     // 数据项值8
///     value: 10
///     }, {
///     name: '数据2',
///     value: 20
///     }]
///     需要对个别内容指定进行个性化定义时：
///     [{
///     name: '数据1',
///     value: 10
///     }, {
///     // 数据项名称
///     name: '数据2',
///     value : 56,
///     //自定义特殊 tooltip，仅对该数据项有效
///     tooltip:{},
///     //自定义特殊itemStyle，仅对该item有效
///     itemStyle:{}
///     }]
/// </summary>
public class SeriesFunnel_Data
{
	/// <summary>
	///     数据项名称。
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	///     数据值。
	/// </summary>
	[JsonProperty("value")]
	public double? Value { get; set; }

	/// <summary>
	///     图形样式。
	/// </summary>
	[JsonProperty("itemStyle")]
	public SeriesFunnel_Data_ItemStyle ItemStyle { get; set; }

	/// <summary>
	///     单个数据的标签配置。
	/// </summary>
	[JsonProperty("label")]
	public SeriesFunnel_Data_Label Label { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("labelLine")]
	public LabelLine2 LabelLine { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("emphasis")]
	public Select11 Emphasis { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	/// </summary>
	[JsonProperty("blur")]
	public Blur13 Blur { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	/// </summary>
	[JsonProperty("select")]
	public Select11 Select { get; set; }

	/// <summary>
	///     本系列每个数据项中特定的 tooltip 设定。
	/// </summary>
	[JsonProperty("tooltip")]
	public Tooltip1 Tooltip { get; set; }
}