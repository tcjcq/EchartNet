using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
/// </summary>
public class SeriesSankey_Data_Blur
{
	/// <summary>
	/// </summary>
	[JsonProperty("label")]
	public Label5 Label { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle0 ItemStyle { get; set; }
}