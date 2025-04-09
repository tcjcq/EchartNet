using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     标域的数据数组。每个数组项是一个两个项的数组，分别表示标域左上角和右下角的位置，每个项支持通过下面几种方式指定自己的位置
///     通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
///     当多个属性同时存在时，优先级按上述的顺序。
///     data: [
///     [
///     {
///     name: '两个屏幕坐标之间的标域',
///     x: 100,
///     y: 100
///     }, {
///     x: '90%',
///     y: '10%'
///     }
///     ]
///     ]
/// </summary>
public class SeriesFunnel_MarkArea_Data
{
	/// <summary>
	///     标域左上角的数据
	/// </summary>
	[JsonProperty("0")]
	public SeriesPie_MarkArea_Data D0 { get; set; }

	/// <summary>
	///     标域右下角的数据
	/// </summary>
	[JsonProperty("1")]
	public SeriesPie_MarkArea_Data D1 { get; set; }
}