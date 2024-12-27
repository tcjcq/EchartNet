using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     标线的数据数组。每个数组项可以是一个两个值的数组，分别表示线的起点和终点，每一项是一个对象，有下面几种方式指定起点或终点的位置。
	///     通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
	///     用 coord 属性指定数据在相应坐标系上的坐标位置，单个维度支持设置 'min', 'max', 'average'。
	///     当多个属性同时存在时，优先级按上述的顺序。
	///     data: [
	///     [
	///     {
	///     name: '两个坐标之间的标线',
	///     coord: [10, 20]
	///     },
	///     {
	///     coord: [20, 30]
	///     }
	///     ], [{
	///     // 固定起点的 x 像素位置，用于模拟一条指向最大值的水平线
	///     yAxis: 'max',
	///     x: '90%'
	///     }, {
	///     type: 'max'
	///     }],
	///     [
	///     {
	///     name: '两个屏幕坐标之间的标线',
	///     x: 100,
	///     y: 100
	///     },
	///     {
	///     x: 500,
	///     y: 200
	///     }
	///     ]
	///     ]
	/// </summary>
	public class SeriesMap_MarkLine_Data
	{
		/// <summary>
		///     起点的数据。
		/// </summary>
		[JsonProperty("0")]
		public SeriesMap_MarkLine_Data_D0 D0 { get; set; }

		/// <summary>
		///     终点的数据。
		/// </summary>
		[JsonProperty("1")]
		public SeriesMap_MarkLine_Data_D0 D1 { get; set; }
	}
}