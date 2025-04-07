using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     桑基图每一层的设置。可以逐层设置，如下：
///     levels: [{
///     depth: 0,
///     itemStyle: {
///     color: '#fbb4ae'
///     },
///     lineStyle: {
///     color: 'source',
///     opacity: 0.6
///     }
///     }, {
///     depth: 1,
///     itemStyle: {
///     color: '#b3cde3'
///     },
///     lineStyle: {
///     color: 'source',
///     opacity: 0.6
///     }
///     }]
///     也可以只设置某一层：
///     levels: [{
///     depth: 3,
///     itemStyle: {
///     color: '#fbb4ae'
///     },
///     lineStyle: {
///     color: 'source',
///     opacity: 0.6
///     }
///     }]
/// </summary>
public class SeriesSankey_Levels
{
	/// <summary>
	///     指定设置的是桑基图哪一层，取值从 0 开始。
	/// </summary>
	[JsonProperty("depth")]
	public double? Depth { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label1 Label { get; set; }

	/// <summary>
	///     从 v5.4.1 开始支持
	///     关系边文本标签的样式。
	/// </summary>
	[JsonProperty("edgeLabel")]
	public EdgeLabel1 EdgeLabel { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public HandleStyle0 ItemStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("lineStyle")]
	public LineStyle5 LineStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("emphasis")]
	public SeriesSankey_Levels_Emphasis Emphasis { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	/// </summary>
	[JsonProperty("blur")]
	public SeriesSankey_Levels_Blur Blur { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	/// </summary>
	[JsonProperty("select")]
	public SeriesSankey_Levels_Emphasis Select { get; set; }
}