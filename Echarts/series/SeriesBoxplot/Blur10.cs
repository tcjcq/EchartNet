using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     从 v5.0.0 开始支持
///     淡出时的图形样式和标签样式。开启 emphasis.focus 后有效
/// </summary>
public class Blur10
{
	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public HandleStyle0 ItemStyle { get; set; }
}