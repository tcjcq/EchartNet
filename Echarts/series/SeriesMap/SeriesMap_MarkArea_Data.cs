using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 标域的数据数组。每个数组项是一个两个项的数组，分别表示标域左上角和右下角的位置，每个项支持通过下面几种方式指定自己的位置
	/// 
	/// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
	/// 
	/// 
	/// 用 coord 属性指定数据在相应坐标系上的坐标位置，单个维度支持设置 'min', 'max', 'average'。
	/// 
	/// 当多个属性同时存在时，优先级按上述的顺序。
	/// data: [
	/// 
	/// 
	///     [
	///         {
	///             name: '两个坐标之间的标域',
	///             coord: [10, 20]
	///         },
	///         {
	///             coord: [20, 30]
	///         }
	///     ], [
	///         {
	///             name: '60分到80分',
	///             yAxis: 60
	///         },
	///         {
	///             yAxis: 80
	///         }
	///     ], [
	///         {
	///             name: '所有数据范围区间',
	///             coord: ['min', 'min']
	///         },
	///         {
	///             coord: ['max', 'max']
	///         }
	///     ],
	/// [
	///         {
	///             name: '两个屏幕坐标之间的标域',
	///             x: 100,
	///             y: 100
	///         }, {
	///             x: '90%',
	///             y: '10%'
	///         }
	///     ]
	/// ]
	/// </summary>
	public class SeriesMap_MarkArea_Data
	{
		/// <summary>
		/// 标域左上角的数据
		/// </summary>
		[JsonProperty("0")]
		public SeriesMap_MarkArea_Data_D0 D0 { get; set; }

		/// <summary>
		/// 标域右下角的数据
		/// </summary>
		[JsonProperty("1")]
		public SeriesMap_MarkArea_Data_D0 D1 { get; set; }
	}
}