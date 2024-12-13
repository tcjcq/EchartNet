using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 三维柱状图。可以用于三维直角坐标系 grid3D，三维地理坐标系 geo3D，地球 globe，通过高度，颜色等属性展示数据。
	/// 下图就是在 geo3D 上通过三维柱状图展示世界的人口密度数据。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesBar3D
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
		/// 'cartesian3D'
		///   使用三维笛卡尔坐标系，通过 grid3DIndex 指定相应的三维笛卡尔坐标系组件。
		/// 
		/// 
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
		/// 使用的 grid3D 组件的索引。默认使用第一个 grid3D 组件。
		/// </summary>
		[JsonProperty("grid3DIndex")]
		public double? Grid3DIndex { get; set; }

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
		/// 柱子的倒角尺寸。支持设置为从 0 到 1 的值。默认为 0，即没有倒角。
		/// 下面是无倒角和有倒角的区别。
		/// </summary>
		[JsonProperty("bevelSize")]
		public double? BevelSize { get; set; }

		/// <summary>
		/// 柱子倒角的光滑/圆润度，数值越大越光滑/圆润。
		/// </summary>
		[JsonProperty("bevelSmoothness")]
		public double? BevelSmoothness { get; set; }

		/// <summary>
		/// 柱状图堆叠，相同 stack 值的柱状图系列数据会有叠加。注意不同系列需要叠加的数据项在数组中的索引必须是一样的。关于如何定制数值的堆叠方式，参见 stackStrategy。
		/// 注：目前 stack 只支持堆叠于 value 和 log 类型的类目轴上，不支持 time 和 category 类型的类目轴。
		/// </summary>
		[JsonProperty("stack")]
		public string Stack { get; set; }

		/// <summary>
		/// 从 ECharts v5.3.3 开始支持
		/// 
		/// 堆积数值的策略，前提是stack属性已被设置。其值可以是：
		/// 
		/// 'samesign' 只在要堆叠的值与当前累积的堆叠值具有相同的正负符号时才堆叠。
		/// 'all' 堆叠所有的值，不管当前或累积的堆叠值的正负符号是什么。
		/// 'positive' 只堆积正值。
		/// 'negative' 只堆叠负值。
		/// </summary>
		[JsonProperty("stackStrategy")]
		public string StackStrategy { get; set; }

		/// <summary>
		/// 最小柱子高度。
		/// </summary>
		[JsonProperty("minHeight")]
		public double? MinHeight { get; set; }

		/// <summary>
		/// 柱子的样式，包括颜色和不透明度。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle12 ItemStyle { get; set; }

		/// <summary>
		/// 柱子的标签配置。
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		/// 柱子高亮状态的标签和样式配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesBar3D_Data_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 三维柱状图数据数组。数组每一项为一个数据。通常这个数据是用数组存储数据的每个属性/维度。例如下面：
		/// data: [
		///     [[12, 14, 10], [34, 50, 15], [56, 30, 20], [10, 15, 12], [23, 10, 14]]
		/// ]
		/// 
		/// 对于数组中的每一项：
		/// 
		/// 在 grid3D 中，每一项的前三个值分别是x, y, z。
		/// 在 geo3D 以及 globe 中，每一项的前两个值分别是经纬度 lng, lat，第三个值表示数值大小，例如人口的多少。这个值会被映射到 minHeight ~ maxHeight 的范围。
		/// 
		/// 除了默认给坐标系使用的三个值，每一项还可以加入任意多个值，用于给 visualMap 组件映射到颜色等其它图形属性。
		/// 有些时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
		/// [{
		///     // 数据项的名称
		///     name: '数据1',
		///     // 数据项值
		///     value: [12, 14, 10]
		/// }, {
		///     name: '数据2',
		///     value: [34, 50, 15]
		/// }]
		/// 
		/// 需要对个别内容指定进行个性化定义时：
		/// [{
		///     name: '数据1',
		///     value: [12, 14, 10]
		/// }, {
		///     // 数据项名称
		///     name: '数据2',
		///     value : [34, 50, 15],
		///     //自定义特殊itemStyle，仅对该item有效
		///     itemStyle:{}
		/// }]
		/// </summary>
		[JsonProperty("data")]
		public SeriesBar3D_Data[] Data { get; set; }

		/// <summary>
		/// 三维柱状图中三维图形的着色效果。echarts-gl 中支持下面三种着色方式：
		/// 
		/// 'color'
		/// 只显示颜色，不受光照等其它因素的影响。
		/// 
		/// 'lambert'
		/// 通过经典的 lambert 着色表现光照带来的明暗。
		/// 
		/// 'realistic'
		/// 真实感渲染，配合 light.ambientCubemap 和 postEffect 使用可以让展示的画面效果和质感有质的提升。ECharts GL 中使用了基于物理的渲染（PBR） 来表现真实感材质。
		/// </summary>
		[JsonProperty("shading")]
		public string Shading { get; set; }

		/// <summary>
		/// 真实感材质相关的配置项，在 shading 为'realistic'时有效。
		/// </summary>
		[JsonProperty("realisticMaterial")]
		public Globe_RealisticMaterial RealisticMaterial { get; set; }

		/// <summary>
		/// lambert 材质相关的配置项，在 shading 为'lambert'时有效。
		/// </summary>
		[JsonProperty("lambertMaterial")]
		public Globe_LambertMaterial LambertMaterial { get; set; }

		/// <summary>
		/// color 材质相关的配置项，在 shading 为'color'时有效。
		/// </summary>
		[JsonProperty("colorMaterial")]
		public Globe_LambertMaterial ColorMaterial { get; set; }

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

		/// <summary>
		/// 是否开启动画。
		/// </summary>
		[JsonProperty("animation")]
		public bool? Animation { get; set; }

		/// <summary>
		/// 过渡动画的时长。
		/// </summary>
		[JsonProperty("animationDurationUpdate")]
		public double? AnimationDurationUpdate { get; set; }

		/// <summary>
		/// 过渡动画的缓动效果。
		/// </summary>
		[JsonProperty("animationEasingUpdate")]
		public string AnimationEasingUpdate { get; set; }
	}

	/// <summary>
	/// 三维柱状图数据数组。数组每一项为一个数据。通常这个数据是用数组存储数据的每个属性/维度。例如下面：
	/// data: [
	///     [[12, 14, 10], [34, 50, 15], [56, 30, 20], [10, 15, 12], [23, 10, 14]]
	/// ]
	/// 
	/// 对于数组中的每一项：
	/// 
	/// 在 grid3D 中，每一项的前三个值分别是x, y, z。
	/// 在 geo3D 以及 globe 中，每一项的前两个值分别是经纬度 lng, lat，第三个值表示数值大小，例如人口的多少。这个值会被映射到 minHeight ~ maxHeight 的范围。
	/// 
	/// 除了默认给坐标系使用的三个值，每一项还可以加入任意多个值，用于给 visualMap 组件映射到颜色等其它图形属性。
	/// 有些时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	/// [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值
	///     value: [12, 14, 10]
	/// }, {
	///     name: '数据2',
	///     value: [34, 50, 15]
	/// }]
	/// 
	/// 需要对个别内容指定进行个性化定义时：
	/// [{
	///     name: '数据1',
	///     value: [12, 14, 10]
	/// }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : [34, 50, 15],
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	/// }]
	/// </summary>
	public class SeriesBar3D_Data
	{
		/// <summary>
		/// 数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 数据项值。
		/// </summary>
		[JsonProperty("value")]
		public double[] Value { get; set; }

		/// <summary>
		/// 单个数据项的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle12 ItemStyle { get; set; }

		/// <summary>
		/// 单个数据项的标签设置。
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		/// 单个数据项高亮状态的标签和样式配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesBar3D_Data_Emphasis Emphasis { get; set; }
	}
}