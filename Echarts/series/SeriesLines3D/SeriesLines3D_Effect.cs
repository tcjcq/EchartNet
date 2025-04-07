using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     飞线的尾迹特效。
/// </summary>
public class SeriesLines3D_Effect
{
	/// <summary>
	///     是否显示尾迹特效，默认不显示。
	/// </summary>
	[JsonProperty("show")]
	public bool? Show { get; set; }

	/// <summary>
	///     尾迹特效的周期。
	/// </summary>
	[JsonProperty("period")]
	public double? Period { get; set; }

	/// <summary>
	///     轨迹特效的移动动画是否是固定速度，单位按三维空间的尺寸，设置为非 null 的值后会忽略 period 配置项。
	/// </summary>
	[JsonProperty("constantSpeed")]
	public double? ConstantSpeed { get; set; }

	/// <summary>
	///     尾迹的宽度。
	/// </summary>
	[JsonProperty("trailWidth")]
	public double? TrailWidth { get; set; }

	/// <summary>
	///     尾迹的长度，范围从 0 到 1，为线条长度的百分比。
	/// </summary>
	[JsonProperty("trailLength")]
	public double? TrailLength { get; set; }

	/// <summary>
	///     尾迹的颜色，默认跟线条颜色相同。
	/// </summary>
	[JsonProperty("trailColor")]
	public string TrailColor { get; set; }

	/// <summary>
	///     尾迹的不透明度，默认跟线条不透明度相同。
	/// </summary>
	[JsonProperty("trailOpacity")]
	public double? TrailOpacity { get; set; }
}