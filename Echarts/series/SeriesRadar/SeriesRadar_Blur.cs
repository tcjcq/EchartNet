using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
///     淡出状态的配置。开启 emphasis.focus 后有效。
/// </summary>
public class SeriesRadar_Blur
{
	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public HandleStyle0 ItemStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label1 Label { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("lineStyle")]
	public LineStyle1 LineStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("areaStyle")]
	public ShadowStyle0 AreaStyle { get; set; }
}