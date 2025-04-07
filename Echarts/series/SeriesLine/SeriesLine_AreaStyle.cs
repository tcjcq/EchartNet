using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     区域填充样式。设置后显示成区域面积图。
/// </summary>
public class SeriesLine_AreaStyle
{
	/// <summary>
	///     填充的颜色。
	///     支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
	/// </summary>
	[JsonProperty("color")]
	public Color Color { get; set; }

	/// <summary>
	///     图形区域的起始位置。
	///     默认情况下，图形会从坐标轴轴线到数据间进行填充。如果需要填充的区域是坐标轴最大值到数据间，或者坐标轴最小值到数据间，或者某个数值到数据间则可以通过这个配置项进行设置。
	///     可选值包括：
	///     'auto' 填充坐标轴轴线到数据间的区域（默认值）
	///     'start' 填充坐标轴底部（非 inverse 情况是最小值）到数据间的区域
	///     'end' 填充坐标轴顶部（非 inverse 情况是最大值）到数据间的区域
	///     number 填充指定数值到数据间的区域（从 v5.3.2 开始支持）
	/// </summary>
	[JsonProperty("origin")]
	public StringOrNumber Origin { get; set; }

	/// <summary>
	///     图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
	///     示例：
	///     {
	///     shadowColor: 'rgba(0, 0, 0, 0.5)',
	///     shadowBlur: 10
	///     }
	/// </summary>
	[JsonProperty("shadowBlur")]
	public double? ShadowBlur { get; set; }

	/// <summary>
	///     阴影颜色。支持的格式同color。
	/// </summary>
	[JsonProperty("shadowColor")]
	public Color ShadowColor { get; set; }

	/// <summary>
	///     阴影水平方向上的偏移距离。
	/// </summary>
	[JsonProperty("shadowOffsetX")]
	public double? ShadowOffsetX { get; set; }

	/// <summary>
	///     阴影垂直方向上的偏移距离。
	/// </summary>
	[JsonProperty("shadowOffsetY")]
	public double? ShadowOffsetY { get; set; }

	/// <summary>
	///     图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
	/// </summary>
	[JsonProperty("opacity")]
	public double? Opacity { get; set; }
}