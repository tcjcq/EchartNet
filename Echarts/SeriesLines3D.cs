using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 三维的飞线图。跟二维的飞线图一样用于表现起点终点的线数据。更多用在地理可视化上。
	/// 下图是使用 lines3D 在 globe 上可视化飞机航班的一个例子。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesLines3D
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// 系列名称，用于 tooltip 的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 该系列使用的坐标系，可选：
		/// 
		/// 'geo3D'
		///   使用三维地理坐标系，通过 geo3DIndex 指定相应的三维地理坐标系组件
		/// 
		/// 
		/// 
		/// 'globe'
		///   使用地球坐标系，通过 globeIndex 指定相应的地球坐标系组件
		/// </summary>
		[JsonProperty("coordinateSystem")]
		public string CoordinateSystem { get; set; }

		/// <summary>
		/// 坐标轴使用的 geo3D 组件的索引。默认使用第一个 geo3D 组件。
		/// </summary>
		[JsonProperty("geo3DIndex")]
		public double? Geo3DIndex { get; set; }

		/// <summary>
		/// 坐标轴使用的 globe 组件的索引。默认使用第一个 globe 组件。
		/// </summary>
		[JsonProperty("globeIndex")]
		public double? GlobeIndex { get; set; }

		/// <summary>
		/// 是否是多段线。
		/// 默认为 false，只能用于绘制只有两个端点的线段（表现为被赛尔曲线）。
		/// 如果该配置项为 true，则可以在 data.coords 中设置多于 2 个的顶点用来绘制多段线，在绘制路线轨迹的时候比较有用。
		/// </summary>
		[JsonProperty("polyline")]
		public bool? Polyline { get; set; }

		/// <summary>
		/// 飞线的尾迹特效。
		/// </summary>
		[JsonProperty("effect")]
		public SeriesLines3D_Effect Effect { get; set; }

		/// <summary>
		/// 飞线的线条样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }

		/// <summary>
		/// 三维飞线图的数据数组，通常数据的每一项可以是一个包含起点和终点的坐标集。在 polyline 设置为 true 时支持多于两个的坐标。
		/// 如下：
		/// data: [
		///     [
		///         [120, 66, 1], // 起点的经纬度和海拔坐标
		///         [122, 67, 2]  // 终点的经纬度和海拔坐标
		///     ]
		/// ]
		/// 
		/// 有些时候需要配置数据项的名字或者单独的样式。需要把经纬度坐标写到 coords 属性下。如下：
		/// data: [
		///     {
		///         coords: [ [120, 66], [122, 67] ],
		///         // 数据值
		///         value: 10,
		///         // 数据名
		///         name: 'foo',
		///         // 线条样式
		///         lineStyle: {}
		///     }
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesLines3D_Data[] Data { get; set; }

		/// <summary>
		/// 混合模式，目前支持'source-over'，'lighter'，默认使用的'source-over'是通过 alpha 混合，而'lighter'是叠加模式，该模式可以让数据集中的区域因为叠加而产生高亮的效果。
		/// </summary>
		[JsonProperty("blendMode")]
		public string BlendMode { get; set; }

		/// <summary>
		/// 组件所在的层。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// 注: echarts-gl 中组件的层需要跟 echarts 中组件的层分开。同一个 zlevel 不能同时用于 WebGL 和 Canvas 的绘制。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }
	}

	/// <summary>
	/// 飞线的尾迹特效。
	/// </summary>
	public class SeriesLines3D_Effect
	{
		/// <summary>
		/// 是否显示尾迹特效，默认不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 尾迹特效的周期。
		/// </summary>
		[JsonProperty("period")]
		public double? Period { get; set; }

		/// <summary>
		/// 轨迹特效的移动动画是否是固定速度，单位按三维空间的尺寸，设置为非 null 的值后会忽略 period 配置项。
		/// </summary>
		[JsonProperty("constantSpeed")]
		public double? ConstantSpeed { get; set; }

		/// <summary>
		/// 尾迹的宽度。
		/// </summary>
		[JsonProperty("trailWidth")]
		public double? TrailWidth { get; set; }

		/// <summary>
		/// 尾迹的长度，范围从 0 到 1，为线条长度的百分比。
		/// </summary>
		[JsonProperty("trailLength")]
		public double? TrailLength { get; set; }

		/// <summary>
		/// 尾迹的颜色，默认跟线条颜色相同。
		/// </summary>
		[JsonProperty("trailColor")]
		public string TrailColor { get; set; }

		/// <summary>
		/// 尾迹的不透明度，默认跟线条不透明度相同。
		/// </summary>
		[JsonProperty("trailOpacity")]
		public double? TrailOpacity { get; set; }
	}

	/// <summary>
	/// 三维飞线图的数据数组，通常数据的每一项可以是一个包含起点和终点的坐标集。在 polyline 设置为 true 时支持多于两个的坐标。
	/// 如下：
	/// data: [
	///     [
	///         [120, 66, 1], // 起点的经纬度和海拔坐标
	///         [122, 67, 2]  // 终点的经纬度和海拔坐标
	///     ]
	/// ]
	/// 
	/// 有些时候需要配置数据项的名字或者单独的样式。需要把经纬度坐标写到 coords 属性下。如下：
	/// data: [
	///     {
	///         coords: [ [120, 66], [122, 67] ],
	///         // 数据值
	///         value: 10,
	///         // 数据名
	///         name: 'foo',
	///         // 线条样式
	///         lineStyle: {}
	///     }
	/// ]
	/// </summary>
	public class SeriesLines3D_Data
	{
		/// <summary>
		/// 一个包含两个到多个经纬度坐标的数组。在 polyline 设置为 true 时支持多于两个的坐标。
		/// </summary>
		[JsonProperty("coords")]
		public double[] Coords { get; set; }

		/// <summary>
		/// 数据值。
		/// </summary>
		[JsonProperty("value")]
		public ArrayOrSingle Value { get; set; }

		/// <summary>
		/// 单个数据（单条线）的样式设置。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }
	}
}