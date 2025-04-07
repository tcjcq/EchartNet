using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
///     桑基图的选中状态。开启 selectedMode 后有效。
/// </summary>
public class SeriesSankey_Select
{
	/// <summary>
	///     从 v5.3.0 开始支持
	///     是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
	/// </summary>
	[JsonProperty("disabled")]
	public bool? Disabled { get; set; }

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
}