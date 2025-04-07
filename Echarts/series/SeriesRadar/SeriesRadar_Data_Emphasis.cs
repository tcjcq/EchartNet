using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     单个数据项样式的高亮状态。
/// </summary>
public class SeriesRadar_Data_Emphasis
{
	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public HandleStyle0 ItemStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label5 Label { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("lineStyle")]
	public LineStyle1 LineStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("areaStyle")]
	public ShadowStyle0 AreaStyle { get; set; }
}