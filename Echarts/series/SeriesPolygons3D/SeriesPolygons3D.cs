using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// polygons3D 用于可视化地图上带有高度信息的多边形数据，常用于建筑群的绘制。下图就是用polygons3D绘制的近 50w 数量的纽约建筑群。
	/// </summary>
	public class SeriesPolygons3D
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "polygons3D";

		/// <summary>
		/// 是否一个数据包含多个多边形。
		/// </summary>
		[JsonProperty("multiPolygon")]
		public bool? MultiPolygon { get; set; }

		/// <summary>
		/// 图形样式，包括颜色、透明度、描边等。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle12 ItemStyle { get; set; }

		/// <summary>
		/// 鼠标 hover 高亮时图形和标签的样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesPolygons3D_Emphasis Emphasis { get; set; }

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
		[JsonProperty("data")]
		public SeriesPolygons3D_Data Data { get; set; }

		/// <summary>
		/// 启用渐进渲染的阈值，渐进渲染可以让你在加载画面的过程中不会有阻塞。
		/// </summary>
		[JsonProperty("progressiveThreshold")]
		public double? ProgressiveThreshold { get; set; }

		/// <summary>
		/// 渐进渲染每次渲染的数据量。
		/// </summary>
		[JsonProperty("progressive")]
		public double? Progressive { get; set; }
	}
}