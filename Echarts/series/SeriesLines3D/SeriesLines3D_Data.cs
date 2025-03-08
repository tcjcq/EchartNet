using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     三维飞线图的数据数组，通常数据的每一项可以是一个包含起点和终点的坐标集。在 polyline 设置为 true 时支持多于两个的坐标。
///     如下：
///     data: [
///     [
///     [120, 66, 1], // 起点的经纬度和海拔坐标
///     [122, 67, 2]  // 终点的经纬度和海拔坐标
///     ]
///     ]
///     有些时候需要配置数据项的名字或者单独的样式。需要把经纬度坐标写到 coords 属性下。如下：
///     data: [
///     {
///     coords: [ [120, 66], [122, 67] ],
///     // 数据值
///     value: 10,
///     // 数据名
///     name: 'foo',
///     // 线条样式
///     lineStyle: {}
///     }
///     ]
/// </summary>
public class SeriesLines3D_Data
{
	/// <summary>
	///     一个包含两个到多个经纬度坐标的数组。在 polyline 设置为 true 时支持多于两个的坐标。
	/// </summary>
	[JsonProperty("coords")]
	public double[] Coords { get; set; }

	/// <summary>
	///     数据值。
	/// </summary>
	[JsonProperty("value")]
	public ArrayOrSingle Value { get; set; }

	/// <summary>
	///     单个数据（单条线）的样式设置。
	/// </summary>
	[JsonProperty("lineStyle")]
	public LineStyle6 LineStyle { get; set; }
}