using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 多边形的数据列表。
	/// data: [{
	///     // A square
	///     coords: [[0, 0], [100, 0], [100, 100], [0, 100]],
	///     // Height
	///     height: 3
	/// }, {
	///     // A triangle
	///     coords: [[50, 0], [100, 100], [0, 100]],
	///     // Height
	///     height: 5
	/// }]
	/// </summary>
	public class SeriesPolygons3D_Data
	{
		/// <summary>
		/// 多边形的坐标列表。如果 multiPolygon 设成 true，则是包含多个多边形的数组。
		/// </summary>
		[JsonProperty("coords")]
		public double[] Coords { get; set; }
	}
}