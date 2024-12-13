using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 地理坐标系组件。
	/// 地理坐标系组件用于地图的绘制，支持在地理坐标系上绘制散点图，线集。
	/// 3.1.10 开始 geo 组件也支持鼠标事件。事件参数为
	/// {
	///     componentType: 'geo',
	///     // Geo 组件在 option 中的 index
	///     geoIndex: number,
	///     // 点击区域的名称，比如"上海"
	///     name: string,
	///     // 传入的点击区域的 region 对象，见 geo.regions
	///     region: Object
	/// }
	/// 
	/// Tip:
	/// geo 区域的颜色也可以被 map series 所控制，参见 series-map.geoIndex。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class Geo
	{
		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 是否显示地理坐标系组件。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 使用 registerMap 注册的地图名称。
		/// geoJSON 引入示例
		/// $.get('map/china_geo.json', function (chinaJson) {
		///     echarts.registerMap('china', {geoJSON: geoJson});
		///     var chart = echarts.init(document.getElementById('main'));
		///     chart.setOption({
		///         geo: [{
		///             map: 'china',
		///             ...
		///         }]
		///     });
		/// });
		/// 
		/// 也参见示例 geoJSON hexbin。
		/// 如上所示，ECharts 可以使用 GeoJSON 格式的数据作为地图的轮廓，你可以获取第三方的 GeoJSON 数据注册到 ECharts 中。例如第三方资源 maps。
		/// SVG 引入示例
		/// $.get('map/topographic_map.svg', function (svg) {
		///     echarts.registerMap('topo', {svg: svg});
		///     var chart = echarts.init(document.getElementById('main'));
		///     chart.setOption({
		///         geo: [{
		///             map: 'topo',
		///             ...
		///         }]
		///     });
		/// });
		/// 
		/// 也参见示例 Flight Seatmap。
		/// 如上所示，ECharts 也可以使用 SVG 格式的地图。详情参见：SVG 底图。
		/// </summary>
		[JsonProperty("map")]
		public string Map { get; set; }

		/// <summary>
		/// 是否开启鼠标缩放和平移漫游。默认不开启。如果只想要开启缩放或者平移，可以设置成 'scale' 或者 'move'。设置成 true 为都开启
		/// </summary>
		[JsonProperty("roam")]
		public StringOrBool Roam { get; set; }

		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 自定义地图投影，至少需要提供project, unproject两个方法分别用来计算投影后的坐标以及计算投影前的坐标。
		/// 比如墨卡托投影：
		/// series: {
		///     type: 'map',
		///     projection: {
		///         project: (point) => [point[0] / 180 * Math.PI, -Math.log(Math.tan((Math.PI / 2 + point[1] / 180 * Math.PI) / 2))],
		///         unproject: (point) => [point[0] * 180 / Math.PI, 2 * 180 / Math.PI * Math.atan(Math.exp(point[1])) - 90]
		///     }
		/// }
		/// 
		/// 除了我们自己实现投影公式，我们也可以使用 d3-geo 等第三方库提供的现成的投影实现：
		/// const projection = d3.geoConicEqualArea();
		/// // ...
		/// series: {
		///     type: 'map',
		///     projection: {
		///         project: (point) => projection(point),
		///         unproject: (point) => projection.invert(point)
		///     }
		/// }
		/// 
		/// 注：自定义投影只有在使用GeoJSON作为数据源的时候有用。
		/// </summary>
		[JsonProperty("projection")]
		public Geo_Projection Projection { get; set; }

		/// <summary>
		/// 当前视角的中心点，默认使用原始坐标（经纬度）。如果设置了projection则用投影后的坐标表示。
		/// 示例：
		/// center: [115.97, 29.71]
		/// 
		/// projection: {
		///     projection: (pt) => project(pt)
		/// },
		/// center: project([115.97, 29.71])
		/// </summary>
		[JsonProperty("center")]
		public double[] Center { get; set; }

		/// <summary>
		/// 这个参数用于 scale 地图的长宽比，如果设置了projection则无效。
		/// 最终的 aspect 的计算方式是：geoBoundingRect.width / geoBoundingRect.height * aspectScale。
		/// </summary>
		[JsonProperty("aspectScale")]
		public double? AspectScale { get; set; }

		/// <summary>
		/// 二维数组，定义定位的左上角以及右下角分别所对应的经纬度。例如
		/// // 设置为一张完整经纬度的世界地图
		/// map: 'world',
		/// left: 0, top: 0, right: 0, bottom: 0,
		/// boundingCoords: [
		///     // 定位左上角经纬度
		///     [-180, 90],
		///     // 定位右下角经纬度
		///     [180, -90]
		/// ],
		/// </summary>
		[JsonProperty("boundingCoords")]
		public double[] BoundingCoords { get; set; }

		/// <summary>
		/// 当前视角的缩放比例。
		/// </summary>
		[JsonProperty("zoom")]
		public double? Zoom { get; set; }

		/// <summary>
		/// 滚轮缩放的极限控制，通过 min 和 max 限制最小和最大的缩放值。
		/// </summary>
		[JsonProperty("scaleLimit")]
		public Geo_ScaleLimit ScaleLimit { get; set; }

		/// <summary>
		/// 自定义地区的名称映射，如：
		/// {
		///     'China' : '中国'
		/// }
		/// </summary>
		[JsonProperty("nameMap")]
		public object NameMap { get; set; }

		/// <summary>
		/// 从 v4.8.0 开始支持
		/// 
		/// 默认是 'name'，针对 GeoJSON 要素的自定义属性名称，作为主键用于关联数据点和 GeoJSON 地理要素。
		/// 例如：
		/// {
		///     nameProperty: 'NAME', // 数据点中的 name：Alabama 会关联到 GeoJSON 中 NAME 属性值为 Alabama 的地理要素{"type":"Feature","id":"01","properties":{"NAME":"Alabama"}, "geometry": { ... }}
		///     data:[
		///         {name: 'Alabama', value: 4822023},
		///         {name: 'Alaska', value: 731449},
		///     ]
		/// }
		/// </summary>
		[JsonProperty("nameProperty")]
		public string NameProperty { get; set; }

		/// <summary>
		/// 选中模式，表示是否支持多个选中，默认关闭，支持布尔值和字符串，字符串取值可选'single'表示单选，或者'multiple'表示多选。
		/// </summary>
		[JsonProperty("selectedMode")]
		public StringOrBool SelectedMode { get; set; }

		/// <summary>
		/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 地图区域的多边形 图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }

		/// <summary>
		/// 高亮状态下的多边形和标签样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public Geo_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 选中状态下的多边形和标签样式。
		/// </summary>
		[JsonProperty("select")]
		public Select0 Select { get; set; }

		/// <summary>
		/// 从 v5.1.0 开始支持
		/// 
		/// 淡出状态下的多边形和标签样式。
		/// </summary>
		[JsonProperty("blur")]
		public Blur0 Blur { get; set; }

		/// <summary>
		/// 所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// z相比zlevel优先级更低，而且不会创建新的 Canvas。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 组件离容器左侧的距离。
		/// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		/// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 组件离容器上侧的距离。
		/// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		/// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 组件离容器右侧的距离。
		/// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 组件离容器下侧的距离。
		/// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// layoutCenter 和 layoutSize 提供了除了 left/right/top/bottom/width/height 之外的布局手段。
		/// 在使用 left/right/top/bottom/width/height 的时候，可能很难在保持地图高宽比的情况下把地图放在某个盒形区域的正中间，并且保证不超出盒形的范围。此时可以通过 layoutCenter 属性定义地图中心在屏幕中的位置，layoutSize 定义地图的大小。如下示例
		/// layoutCenter: ['30%', '30%'],
		/// // 如果宽高比大于 1 则宽度为 100，如果小于 1 则高度为 100，保证了不超过 100x100 的区域
		/// layoutSize: 100
		/// 
		/// 设置这两个值后 left/right/top/bottom/width/height 无效。
		/// </summary>
		[JsonProperty("layoutCenter")]
		public double[] LayoutCenter { get; set; }

		/// <summary>
		/// 地图的大小，见 layoutCenter。支持相对于屏幕宽高的百分比或者绝对的像素大小。
		/// </summary>
		[JsonProperty("layoutSize")]
		public StringOrNumber LayoutSize { get; set; }

		/// <summary>
		/// 在地图中对特定的区域配置样式。
		/// 例如：
		/// regions: [{
		///     name: '广东',
		///     itemStyle: {
		///         areaColor: 'red',
		///         color: 'red'
		///     }
		/// }]
		/// 
		/// geo 区域的颜色也可以被 map series 所控制，参见 series-map.geoIndex。
		/// </summary>
		[JsonProperty("regions")]
		public Geo_Regions[] Regions { get; set; }

		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 从 v5.1.0 开始支持
		/// 
		/// 本坐标系特定的 tooltip 设定。
		/// 提示框组件的通用介绍：
		/// 提示框组件可以设置在多种地方：
		/// 
		/// 可以设置在全局，即 tooltip
		/// 
		/// 可以设置在坐标系中，即 grid.tooltip、polar.tooltip、single.tooltip
		/// 
		/// 可以设置在系列中，即 series.tooltip
		/// 
		/// 可以设置在系列的每个数据项中，即 series.data.tooltip
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip0 Tooltip { get; set; }
	}

	/// <summary>
	/// 从 v5.3.0 开始支持
	/// 
	/// 自定义地图投影，至少需要提供project, unproject两个方法分别用来计算投影后的坐标以及计算投影前的坐标。
	/// 比如墨卡托投影：
	/// series: {
	///     type: 'map',
	///     projection: {
	///         project: (point) => [point[0] / 180 * Math.PI, -Math.log(Math.tan((Math.PI / 2 + point[1] / 180 * Math.PI) / 2))],
	///         unproject: (point) => [point[0] * 180 / Math.PI, 2 * 180 / Math.PI * Math.atan(Math.exp(point[1])) - 90]
	///     }
	/// }
	/// 
	/// 除了我们自己实现投影公式，我们也可以使用 d3-geo 等第三方库提供的现成的投影实现：
	/// const projection = d3.geoConicEqualArea();
	/// // ...
	/// series: {
	///     type: 'map',
	///     projection: {
	///         project: (point) => projection(point),
	///         unproject: (point) => projection.invert(point)
	///     }
	/// }
	/// 
	/// 注：自定义投影只有在使用GeoJSON作为数据源的时候有用。
	/// </summary>
	public class Geo_Projection
	{
		/// <summary>
		/// (coord: [number, number]) => [number, number]
		/// 
		/// 将经纬度坐标投影为其它坐标。
		/// </summary>
		[JsonProperty("project")]
		public string Project { get; set; }

		/// <summary>
		/// (point: [number, number]) => [number, number]
		/// 
		/// 根据投影后坐标计算投影前的经纬度坐标
		/// </summary>
		[JsonProperty("unproject")]
		public string Unproject { get; set; }

		/// <summary>
		/// 该属性主要用于适配 d3-geo 中使用的 stream 接口。在引入 stream 后可以同时引入d3-geo 中实现的Antimeridian Clipping以及Adaptive Sampling算法。
		/// const projection = d3.geoProjection((x, y) => ([x, y / 0.75]))
		///     .rotate([-115, 0]);
		/// // ...
		/// series: {
		///     type: 'map',
		///     projection: {
		///         // project 和 unproject 依旧需要配置。
		///         project: (point) => projection(point),
		///         unproject: (point) => projection.invert(point),
		///         // 可以直接使用 d3-geo 提供的 stream 方法。
		///         stream: projection.stream
		///     }
		/// }
		/// 
		/// 该配置并非是必要的。
		/// </summary>
		[JsonProperty("stream")]
		public string Stream { get; set; }
	}

	/// <summary>
	/// 滚轮缩放的极限控制，通过 min 和 max 限制最小和最大的缩放值。
	/// </summary>
	public class Geo_ScaleLimit
	{
		/// <summary>
		/// 最小的缩放值
		/// </summary>
		[JsonProperty("min")]
		public double? Min { get; set; }

		/// <summary>
		/// 最大的缩放值
		/// </summary>
		[JsonProperty("max")]
		public double? Max { get; set; }
	}

	/// <summary>
	/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	public class Label1
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签的位置。
		/// 
		/// 可以通过内置的语义声明位置：
		///   示例：
		///   position: 'top'
		/// 
		///   支持：top / left / right / bottom / inside / insideLeft / insideRight / insideTop / insideBottom / insideTopLeft / insideBottomLeft / insideTopRight / insideBottomRight
		/// 
		/// 也可以用一个数组表示相对的百分比或者绝对像素值表示标签相对于图形包围盒左上角的位置。
		///   示例：
		///   // 绝对的像素值
		///   position: [10, 10],
		///   // 相对的百分比
		///   position: ['50%', '50%']
		/// 
		/// 
		/// 
		/// 参见：label position。
		/// </summary>
		[JsonProperty("position")]
		public ArrayOrSingle Position { get; set; }

		/// <summary>
		/// 距离图形元素的距离。
		/// 当 position 为字符描述值（如 'top'、'insideRight'）时候有效。
		/// 参见：label position。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 标签旋转。从 -90 度到 90 度。正值是逆时针。
		/// 参见：label rotation。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 是否对文字进行偏移。默认不偏移。例如：[30, 40] 表示文字在横向上偏移 30，纵向上偏移 40。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		/// 字符串模板
		/// 模板变量有：
		/// 
		/// {a}：系列名。
		/// {b}：数据名。
		/// {c}：数据值。
		/// {@xxx}：数据中名为 'xxx' 的维度的值，如 {@product} 表示名为 'product' 的维度的值。
		/// {@[n]}：数据中维度 n 的值，如 {@[3]} 表示维度 3 的值，从 0 开始计数。
		/// 
		/// 示例：
		/// formatter: '{b}: {@score}'
		/// 
		/// 回调函数
		/// 回调函数格式：
		/// (params: Object|Array) => string
		/// 
		/// 参数 params 是 formatter 需要的单个数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 文字水平对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// 
		/// rich 中如果没有设置 align，则会取父层级的 align。例如：
		/// {
		///     align: right,
		///     rich: {
		///         a: {
		///             // 没有设置 `align`，则 `align` 为 right
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 文字垂直对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'top'
		/// 'middle'
		/// 'bottom'
		/// 
		/// rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
		/// {
		///     verticalAlign: bottom,
		///     rich: {
		///         a: {
		///             // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// borderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// borderType: [5, 10],
		/// 
		/// borderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("borderType")]
		public StringOrNumber[] BorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// borderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("borderDashOffset")]
		public double? BorderDashOffset { get; set; }

		/// <summary>
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }
	}

	/// <summary>
	/// 地图区域的多边形 图形样式。
	/// </summary>
	public class ItemStyle1
	{
		/// <summary>
		/// 地图区域的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("areaColor")]
		public Color AreaColor { get; set; }

		/// <summary>
		/// 图形的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 图形的描边颜色。支持的颜色格式同 color，不支持回调函数。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 描边线宽。为 0 时无描边。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// borderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// borderType: [5, 10],
		/// 
		/// borderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("borderType")]
		public StringOrNumber[] BorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// borderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("borderDashOffset")]
		public double? BorderDashOffset { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于指定线段末端的绘制方式，可以是：
		/// 
		/// 'butt': 线段末端以方形结束。
		/// 'round': 线段末端以圆形结束。
		/// 'square': 线段末端以方形结束，但是增加了一个宽度和线段相同，高度是线段厚度一半的矩形区域。
		/// 
		/// 默认值为 'butt'。 更多详情可以参考 MDN lineCap。
		/// </summary>
		[JsonProperty("borderCap")]
		public string BorderCap { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置2个长度不为0的相连部分（线段，圆弧，曲线）如何连接在一起的属性（长度为0的变形部分，其指定的末端和控制点在同一位置，会被忽略）。
		/// 可以是：
		/// 
		/// 'bevel': 在相连部分的末端填充一个额外的以三角形为底的区域， 每个部分都有各自独立的矩形拐角。
		/// 'round': 通过填充一个额外的，圆心在相连部分末端的扇形，绘制拐角的形状。 圆角的半径是线段的宽度。
		/// 'miter': 通过延伸相连部分的外边缘，使其相交于一点，形成一个额外的菱形区域。这个设置可以通过 
		/// borderMiterLimit
		/// 属性看到效果。
		/// 
		/// 默认值为 'bevel'。 更多详情可以参考 MDN lineJoin。
		/// </summary>
		[JsonProperty("borderJoin")]
		public string BorderJoin { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置斜接面限制比例。只有当 
		/// borderJoin
		///  为 miter 时，
		/// borderMiterLimit
		///  才有效。
		/// 默认值为 10。负数、0、Infinity 和 NaN 均会被忽略。
		/// 更多详情可以参考 MDN miterLimit。
		/// </summary>
		[JsonProperty("borderMiterLimit")]
		public double? BorderMiterLimit { get; set; }

		/// <summary>
		/// 图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		/// 示例：
		/// {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		/// }
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影颜色。支持的格式同color。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 阴影水平方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影垂直方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }
	}

	/// <summary>
	/// 高亮状态下的多边形和标签样式。
	/// </summary>
	public class Geo_Emphasis
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 从 v5.1.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 
		/// 示例：
		/// 下面代码配置了 geo 在高亮一个图形的时候，淡出所有其它的图形。
		/// emphasis: {
		///     focus: 'self'
		/// }
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }
	}

	/// <summary>
	/// 选中状态下的多边形和标签样式。
	/// </summary>
	public class Select0
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.1.0 开始支持
	/// 
	/// 淡出状态下的多边形和标签样式。
	/// </summary>
	public class Blur0
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }
	}

	/// <summary>
	/// 在地图中对特定的区域配置样式。
	/// 例如：
	/// regions: [{
	///     name: '广东',
	///     itemStyle: {
	///         areaColor: 'red',
	///         color: 'red'
	///     }
	/// }]
	/// 
	/// geo 区域的颜色也可以被 map series 所控制，参见 series-map.geoIndex。
	/// </summary>
	public class Geo_Regions
	{
		/// <summary>
		/// 地图区域的名称，例如 '广东'，'浙江'。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 该区域是否选中。
		/// </summary>
		[JsonProperty("selected")]
		public bool? Selected { get; set; }

		/// <summary>
		/// 该区域的多边形样式设置
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle1 ItemStyle { get; set; }

		/// <summary>
		/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 高亮状态的设置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Blur0 Emphasis { get; set; }

		/// <summary>
		/// 选中状态的设置。
		/// </summary>
		[JsonProperty("select")]
		public Blur0 Select { get; set; }

		/// <summary>
		/// 从 v5.1.0 开始支持
		/// 
		/// 淡出状态的设置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur0 Blur { get; set; }

		/// <summary>
		/// 从 v5.1.0 开始支持
		/// 
		/// 本 region 中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip0 Tooltip { get; set; }
	}

	/// <summary>
	/// 从 v5.1.0 开始支持
	/// 
	/// 本坐标系特定的 tooltip 设定。
	/// 提示框组件的通用介绍：
	/// 提示框组件可以设置在多种地方：
	/// 
	/// 可以设置在全局，即 tooltip
	/// 
	/// 可以设置在坐标系中，即 grid.tooltip、polar.tooltip、single.tooltip
	/// 
	/// 可以设置在系列中，即 series.tooltip
	/// 
	/// 可以设置在系列的每个数据项中，即 series.data.tooltip
	/// </summary>
	public class Tooltip0
	{
		/// <summary>
		/// 是否显示提示框组件。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 提示框浮层的位置，默认不设置时位置会跟随鼠标的位置。
		/// 可选：
		/// 
		/// Array
		///   通过数组表示提示框浮层的位置，支持数字设置绝对位置，百分比设置相对位置。
		///   示例:
		///   // 绝对位置，相对于容器左侧 10px, 上侧 10 px
		///   position: [10, 10]
		///   // 相对位置，放置在容器正中间
		///   position: ['50%', '50%']
		/// 
		/// 
		/// Function
		///   回调函数，格式如下：
		///   (point: Array, params: Object|Array.<Object>, dom: HTMLDomElement, rect: Object, size: Object) => Array
		/// 
		///   参数：
		///   point: 鼠标位置，如 [20, 40]。
		///   params: 同 formatter 的参数相同。
		///   dom: tooltip 的 dom 对象。
		///   rect: 只有鼠标在图形上时有效，是一个用x, y, width, height四个属性表达的图形包围盒。
		///   size: 包括 dom 的尺寸和 echarts 容器的当前尺寸，例如：{contentSize: [width, height], viewSize: [width, height]}。
		///   返回值：
		///   可以是一个表示 tooltip 位置的数组，数组值可以是绝对的像素值，也可以是相  百分比。
		///   也可以是一个对象，如：{left: 10, top: 30}，或者 {right: '20%', bottom: 40}。
		///   如下示例：
		///   position: function (point, params, dom, rect, size) {
		///       // 固定在顶部
		///       return [point[0], '10%'];
		///   }
		/// 
		///   或者：
		///   position: function (pos, params, dom, rect, size) {
		///       // 鼠标在左侧时 tooltip 显示到右侧，鼠标在右侧时 tooltip 显示到左侧。
		///       var obj = {top: 60};
		///       obj[['left', 'right'][+(pos[0] < size.viewSize[0] / 2)]] = 5;
		///       return obj;
		///   }
		/// 
		/// 
		/// 
		/// 
		/// 'inside'
		///   鼠标所在图形的内部中心位置，只在 trigger 为'item'的时候有效。
		/// 
		/// 'top'
		///   鼠标所在图形上侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'left'
		///   鼠标所在图形左侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'right'
		///   鼠标所在图形右侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'bottom'
		///   鼠标所在图形底侧，只在 trigger 为'item'的时候有效。
		/// </summary>
		[JsonProperty("position")]
		public ArrayOrSingle Position { get; set; }

		/// <summary>
		/// 提示框浮层内容格式器，支持字符串模板和回调函数两种形式。
		/// 1. 字符串模板
		/// 模板变量有 {a}, {b}，{c}，{d}，{e}，分别表示系列名，数据名，数据值等。
		/// 在 trigger 为 'axis' 的时候，会有多个系列的数据，此时可以通过 {a0}, {a1}, {a2} 这种后面加索引的方式表示系列的索引。
		/// 不同图表类型下的 {a}，{b}，{c}，{d} 含义不一样。
		/// 其中变量{a}, {b}, {c}, {d}在不同图表类型下代表数据含义为：
		/// 
		/// 折线（区域）图、柱状（条形）图、K线图 : {a}（系列名称），{b}（类目值），{c}（数值）, {d}（无）
		/// 
		/// 散点图（气泡）图 : {a}（系列名称），{b}（数据名称），{c}（数值数组）, {d}（无）
		/// 
		/// 地图 : {a}（系列名称），{b}（区域名称），{c}（合并数值）, {d}（无）
		/// 
		/// 饼图、仪表盘、漏斗图: {a}（系列名称），{b}（数据项名称），{c}（数值）, {d}（百分比）
		/// 
		/// 
		/// 更多其它图表模板变量的含义可以见相应的图表的 label.formatter 配置项。
		/// 示例：
		/// formatter: '{b0}: {c0}<br />{b1}: {c1}'
		/// 
		/// 2. 回调函数
		/// 回调函数格式：
		/// (params: Object|Array, ticket: string, callback: (ticket: string, html: string)) => string | HTMLElement | HTMLElement[]
		/// 
		/// 支持返回 HTML 字符串或者创建的 DOM 实例。
		/// 第一个参数 params 是 formatter 需要的数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string,
		///     // 饼图/漏斗图的百分比
		///     percent: number,
		///     // 旭日图中当前节点的祖先节点（包括自身）
		///     treePathInfo: Array,
		///     // 树图/矩形树图中当前节点的祖先节点（包括自身）
		///     treeAncestors: Array
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// 
		/// 在 trigger 为 'axis' 的时候，或者 tooltip 被 axisPointer 触发的时候，params 是多个系列的数据数组。其中每项内容格式同上，并且，
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// 
		/// 第二个参数 ticket 是异步回调标识，配合第三个参数 callback 使用。
		/// 第三个参数 callback 是异步回调，在提示框浮层内容是异步获取的时候，可以通过 callback 传入上述的 ticket 和 html 更新提示框浮层内容。
		/// 示例：
		/// formatter: function (params, ticket, callback) {
		///     $.get('detail?name=' + params.name, function (content) {
		///         callback(ticket, toHTML(content));
		///     });
		///     return 'Loading';
		/// }
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// tooltip 中数值显示部分的格式化回调函数。
		/// 回调函数格式：
		/// (value: number | string, dataIndex: number) => string
		/// 
		/// 
		/// 自 v5.5.0 版本起提供 dataIndex。
		/// 
		/// 示例：
		/// // 添加 $ 前缀
		/// valueFormatter: (value) => '$' + value.toFixed(2)
		/// </summary>
		[JsonProperty("valueFormatter")]
		public string ValueFormatter { get; set; }

		/// <summary>
		/// 提示框浮层的背景颜色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 提示框浮层的边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 提示框浮层的边框宽。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 提示框浮层内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。
		/// 使用示例：
		/// // 设置内边距为 5
		/// padding: 5
		/// // 设置上下的内边距为 5，左右的内边距为 10
		/// padding: [5, 10]
		/// // 分别设置四个方向的内边距
		/// padding: [
		///     5,  // 上
		///     10, // 右
		///     5,  // 下
		///     10, // 左
		/// ]
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 提示框浮层的文本样式。
		/// </summary>
		[JsonProperty("textStyle")]
		public Legend_PageTextStyle TextStyle { get; set; }

		/// <summary>
		/// 额外附加到浮层的 css 样式。如下为浮层添加阴影的示例：
		/// extraCssText: 'box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);'
		/// </summary>
		[JsonProperty("extraCssText")]
		public string ExtraCssText { get; set; }
	}
}