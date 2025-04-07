using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     鼠标 hover 高亮时图形和标签的样式。
/// </summary>
public class SeriesPolygons3D_Emphasis
{
	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle12 ItemStyle { get; set; }
}