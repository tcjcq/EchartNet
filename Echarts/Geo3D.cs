using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 三维的地理坐标系组件。组件提供了三维 GeoJSON 的绘制以及相应的坐标系，开发者可以在上面展示三维的散点图、气泡图、柱状图、飞线图。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class Geo3D
	{
		/// <summary>
		/// 是否显示三维地理坐标系组件。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 地图类型。echarts-gl 中使用的地图类型同 geo 组件相同。
		/// ECharts 提供了两种格式的地图数据，一种是可以直接通过 script 标签引入的 js 文件，引入后会自动注册地图名字和数据。还有一种是 JSON 文件，需要通过 AJAX 异步加载后手动注册。
		/// 下面是两种类型的使用示例：
		///  JavaScript 引入示例 
		/// <script src="echarts.js"></script>
		/// <script src="map/js/china.js"></script>
		/// <script>
		/// var chart = echarts.init(document.getElementById('main'));
		/// chart.setOption({
		///     series: [{
		///         type: 'map',
		///         map: 'china'
		///     }]
		/// });
		/// </script>
		/// 
		///  JSON 引入示例 
		/// $.get('map/json/china.json', function (chinaJson) {
		///     echarts.registerMap('china', chinaJson);
		///     var chart = echarts.init(document.getElementById('main'));
		///     chart.setOption({
		///         series: [{
		///             type: 'map',
		///             map: 'china'
		///         }]
		///     });
		/// });
		/// 
		/// ECharts 使用 GeoJSON 格式的数据作为地图的轮廓。除此之外，你也可以通过其它手段获取地图的 GeoJSON 格式的数据注册到 ECharts 中。
		/// </summary>
		[JsonProperty("map")]
		public string Map { get; set; }

		/// <summary>
		/// 三维地理坐标系组件在三维场景中的宽度。配合 viewControl.distance 可以得到最合适的展示尺寸。
		/// 下面是三维地理坐标系组件 中boxWidth, boxHeight, boxDepth, regionHeight的示意图。
		/// </summary>
		[JsonProperty("boxWidth")]
		public double? BoxWidth { get; set; }

		/// <summary>
		/// 三维地理坐标系组件在三维场景中的高度。
		/// 组件高度。这个高度包含三维地图上的柱状图、散点图的高度。
		/// </summary>
		[JsonProperty("boxHeight")]
		public double? BoxHeight { get; set; }

		/// <summary>
		/// 三维地理坐标系组件在三维场景中的深度。
		/// 组件深度默认自动，保证三维组件的显示比例跟输入的 GeoJSON 的比例相同。
		/// </summary>
		[JsonProperty("boxDepth")]
		public double? BoxDepth { get; set; }

		/// <summary>
		/// 三维地图每个区域的高度。这个高度是模型的高度，小于 boxHeight。boxHeight - regionHeight 这一片区域会被用于三维柱状图，散点图等的展示。
		/// </summary>
		[JsonProperty("regionHeight")]
		public double? RegionHeight { get; set; }

		/// <summary>
		/// 环境贴图。支持纯色、渐变色、全景贴图的 url。默认为 'auto'，在配置有 light.ambientCubemap.texture 的时候会使用该纹理作为环境贴图。否则则不显示环境贴图。
		/// 示例：
		/// // 配置为全景贴图
		/// environment: 'asset/starfield.jpg'
		/// // 配置为纯黑色的背景
		/// environment: '#000'
		/// // 配置为垂直渐变的背景
		/// environment: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
		///   offset: 0, color: '#00aaff' // 天空颜色
		/// }, {
		///   offset: 0.7, color: '#998866' // 地面颜色
		/// }, {
		///   offset: 1, color: '#998866' // 地面颜色
		/// }], false)
		/// </summary>
		[JsonProperty("environment")]
		public string Environment { get; set; }

		/// <summary>
		/// 地面可以让整个组件有个“摆放”的地方，从而使整个场景看起来更真实，更有模型感。
		/// groundPlane 下支持设置单独的 realisticMaterial, colorMaterial, lambertMaterial 等材质。如果不设置则默认取组件下的材质参数。
		/// </summary>
		[JsonProperty("groundPlane")]
		public Geo3D_GroundPlane GroundPlane { get; set; }

		/// <summary>
		/// instancing会将 GeoJSON 中所有的 geometry 合并成一个，在 GeoJSON 拥有特别多（上千）的 geometry 时可以有效提升绘制效率。
		/// </summary>
		[JsonProperty("instancing")]
		public bool? Instancing { get; set; }

		/// <summary>
		/// 标签的相关设置。
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		/// 三维地理坐标系组件 中三维图形的视觉属性，包括颜色，透明度，描边等。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		/// 鼠标 hover 高亮时图形和标签的样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesBar3D_Data_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 地图区域的设置。
		/// </summary>
		[JsonProperty("regions")]
		public Geo3D_Regions[] Regions { get; set; }

		/// <summary>
		/// 三维地理坐标系组件中三维图形的着色效果。echarts-gl 中支持下面三种着色方式：
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
		/// 光照相关的设置。在 shading 为 'color' 的时候无效。
		/// 光照的设置会影响到组件以及组件所在坐标系上的所有图表。
		/// 合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
		/// </summary>
		[JsonProperty("light")]
		public Geo3D_Light Light { get; set; }

		/// <summary>
		/// 后处理特效的相关配置。后处理特效可以为画面添加高光、景深、环境光遮蔽（SSAO）、调色等效果。可以让整个画面更富有质感。
		/// 下面分别是关闭和开启 postEffect 的区别。
		/// 
		///     
		///     
		/// 
		/// 
		/// 注意在开启 postEffect 的时候默认会开启 temporalSuperSampling 在画面静止后持续对画面增强，包括抗锯齿、景深、SSAO、阴影等。
		/// </summary>
		[JsonProperty("postEffect")]
		public SeriesMap3D_PostEffect PostEffect { get; set; }

		/// <summary>
		/// 分帧超采样。在开启 postEffect 后，WebGL 默认的 MSAA 会无法使用，所以我们需要自己解决锯齿的问题。
		/// 分帧超采样是用来解决锯齿问题的方法，它在画面静止后会持续分帧对一个像素多次抖动采样，从而达到抗锯齿的效果。而且在这个分帧采样的过程中，echarts-gl 也会对 postEffect 中一些需要采样保证效果的特效，例如 SSAO, 景深，以及阴影进行渐进增强。
		/// 下面是未开启和开启temporalSuperSampling的区别。
		/// </summary>
		[JsonProperty("temporalSuperSampling")]
		public Globe_TemporalSuperSampling TemporalSuperSampling { get; set; }

		/// <summary>
		/// viewControl用于鼠标的旋转，缩放等视角控制。
		/// </summary>
		[JsonProperty("viewControl")]
		public Geo3D_ViewControl ViewControl { get; set; }

		/// <summary>
		/// 组件所在的层。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// 注: echarts-gl 中组件的层需要跟 echarts 中组件的层分开。同一个 zlevel 不能同时用于 WebGL 和 Canvas 的绘制。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 组件的视图离容器左侧的距离。
		/// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		/// 如果 left 的值为'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 组件的视图离容器上侧的距离。
		/// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		/// 如果 top 的值为'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 组件的视图离容器右侧的距离。
		/// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 组件的视图离容器下侧的距离。
		/// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 组件的视图宽度。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		/// 组件的视图高度。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }
	}

	/// <summary>
	/// 地面可以让整个组件有个“摆放”的地方，从而使整个场景看起来更真实，更有模型感。
	/// groundPlane 下支持设置单独的 realisticMaterial, colorMaterial, lambertMaterial 等材质。如果不设置则默认取组件下的材质参数。
	/// </summary>
	public class Geo3D_GroundPlane
	{
		/// <summary>
		/// 是否显示地面。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 地面颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }
	}

	/// <summary>
	/// 标签的相关设置。
	/// </summary>
	public class Geo3D_Label
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签距离图形的距离，在三维的散点图中这个距离是屏幕空间的像素值，其它图中这个距离是相对的三维距离。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		/// 字符串模板
		/// 模板变量有：
		/// 
		/// {a}：系列名。
		/// {b}：数据名。
		/// {c}：数据值。
		/// 
		/// 示例：
		/// formatter: '{b}: {c}'
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
		///     color: string,
		/// 
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
		/// 标签的字体样式。
		/// </summary>
		[JsonProperty("textStyle")]
		public TextStyle2 TextStyle { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class TextStyle2
	{
		/// <summary>
		/// 文字的颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// 文字的描边宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字的描边颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public string BorderColor { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

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
		public string FontWeight { get; set; }
	}


	/// <summary>
	/// 三维地理坐标系组件 中三维图形的视觉属性，包括颜色，透明度，描边等。
	/// </summary>
	public class ItemStyle13
	{
		/// <summary>
		/// 图形的颜色。 默认从全局调色盘 option.color 获取颜色 
		/// 除了颜色字符串外，支持使用数组表示的 RGBA 值，例如：
		/// // 纯白色
		/// [1, 1, 1, 1]
		/// 
		/// 使用数组表示的时候，每个通道可以设置大于 1 的值用于表示 HDR 的色值。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// 图形的不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 图形描边的宽度。加上描边后可以更清晰的区分每个区域。如下图：
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 图形描边的颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public string BorderColor { get; set; }
	}

	/// <summary>
	/// 鼠标 hover 高亮时图形和标签的样式。
	/// </summary>
	public class SeriesBar3D_Data_Emphasis
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle12 ItemStyle { get; set; }
	}

	/// <summary>
	/// 三维地理坐标系组件 中三维图形的视觉属性，包括颜色，透明度，描边等。
	/// </summary>
	public class ItemStyle12
	{
		/// <summary>
		/// 图形的颜色。
		/// 除了颜色字符串外，支持使用数组表示的 RGBA 值，例如：
		/// // 纯白色
		/// [1, 1, 1, 1]
		/// 
		/// 使用数组表示的时候，每个通道可以设置大于 1 的值用于表示 HDR 的色值。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// 图形的不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }
	}


	/// <summary>
	/// 地图区域的设置。
	/// </summary>
	public class Geo3D_Regions
	{
		/// <summary>
		/// 所对应的地图区域的名称，例如 '广东'，'浙江'。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 区域的高度。可以设置不同的高度用来表达数据的大小。当 GeoJSON 为建筑的数据时，也可以通过这个值表示简直的高度。如下图:
		/// </summary>
		[JsonProperty("regionHeight")]
		public double? RegionHeight { get; set; }

		/// <summary>
		/// 单个区域的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		/// 单个区域的标签设置。
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		/// 单个区域的标签和样式的高亮设置。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesMap3D_Data_Emphasis Emphasis { get; set; }
	}

	/// <summary>
	/// 鼠标 hover 高亮时图形和标签的样式。
	/// </summary>
	public class SeriesMap3D_Data_Emphasis
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }
	}


	/// <summary>
	/// 光照相关的设置。在 shading 为 'color' 的时候无效。
	/// 光照的设置会影响到组件以及组件所在坐标系上的所有图表。
	/// 合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
	/// </summary>
	public class Geo3D_Light
	{
		/// <summary>
		/// 场景主光源的设置，在 globe 组件中就是太阳光。
		/// </summary>
		[JsonProperty("main")]
		public Geo3D_Light_Main Main { get; set; }

		/// <summary>
		/// 全局的环境光设置。
		/// </summary>
		[JsonProperty("ambient")]
		public Globe_Light_Ambient Ambient { get; set; }

		/// <summary>
		/// ambientCubemap 会使用纹理作为环境光的光源，会为物体提供漫反射和高光反射。可以通过 diffuseIntensity 和 specularIntensity 分别设置漫反射强度和高光反射强度。
		/// </summary>
		[JsonProperty("ambientCubemap")]
		public Globe_Light_AmbientCubemap AmbientCubemap { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Geo3D_Light_Main
	{
		/// <summary>
		/// 主光源的颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// 主光源的强度。
		/// </summary>
		[JsonProperty("intensity")]
		public double? Intensity { get; set; }

		/// <summary>
		/// 主光源是否投射阴影。默认为关闭。
		/// 开启阴影可以给场景带来更真实和有层次的光照效果。但是同时也会增加程序的运行开销。
		/// 下图是开启阴影以及关闭阴影的区别。
		/// </summary>
		[JsonProperty("shadow")]
		public bool? Shadow { get; set; }

		/// <summary>
		/// 阴影的质量。可选'low', 'medium', 'high', 'ultra'
		/// 下图是低质量和高质量阴影的区别。
		/// </summary>
		[JsonProperty("shadowQuality")]
		public string ShadowQuality { get; set; }

		/// <summary>
		/// 主光源绕 x 轴，即上下旋转的角度。配合 beta 控制光源的方向。
		/// 如下示意图：
		/// 
		/// globe 组件中可以通过 time 控制日光的时间。
		/// </summary>
		[JsonProperty("alpha")]
		public double? Alpha { get; set; }

		/// <summary>
		/// 主光源绕 y 轴，即左右旋转的角度。
		/// </summary>
		[JsonProperty("beta")]
		public double? Beta { get; set; }
	}


	/// <summary>
	/// viewControl用于鼠标的旋转，缩放等视角控制。
	/// </summary>
	public class Geo3D_ViewControl
	{
		/// <summary>
		/// 投影方式，默认为透视投影'perspective'，也支持设置为正交投影'orthographic'。
		/// </summary>
		[JsonProperty("projection")]
		public string Projection { get; set; }

		/// <summary>
		/// 是否开启视角绕物体的自动旋转查看。
		/// </summary>
		[JsonProperty("autoRotate")]
		public bool? AutoRotate { get; set; }

		/// <summary>
		/// 物体自转的方向。默认是 'cw' 也就是从上往下看是顺时针方向，也可以取 'ccw'，既从上往下看为逆时针方向。
		/// </summary>
		[JsonProperty("autoRotateDirection")]
		public string AutoRotateDirection { get; set; }

		/// <summary>
		/// 物体自转的速度。单位为角度 / 秒，默认为10 ，也就是36秒转一圈。
		/// </summary>
		[JsonProperty("autoRotateSpeed")]
		public double? AutoRotateSpeed { get; set; }

		/// <summary>
		/// 在鼠标静止操作后恢复自动旋转的时间间隔。在开启 autoRotate 后有效。
		/// </summary>
		[JsonProperty("autoRotateAfterStill")]
		public double? AutoRotateAfterStill { get; set; }

		/// <summary>
		/// 鼠标进行旋转，缩放等操作时的迟滞因子，在大于 0 的时候鼠标在停止操作后，视角仍会因为一定的惯性继续运动（旋转和缩放）。
		/// </summary>
		[JsonProperty("damping")]
		public double? Damping { get; set; }

		/// <summary>
		/// 旋转操作的灵敏度，值越大越灵敏。支持使用数组分别设置横向和纵向的旋转灵敏度。
		/// 默认为1。
		/// 设置为0后无法旋转。
		/// // 无法旋转
		/// rotateSensitivity: 0
		/// // 只能横向旋转
		/// rotateSensitivity: [1, 0]
		/// // 只能纵向旋转
		/// rotateSensitivity: [0, 1]
		/// </summary>
		[JsonProperty("rotateSensitivity")]
		public ArrayOrSingle RotateSensitivity { get; set; }

		/// <summary>
		/// 缩放操作的灵敏度，值越大越灵敏。默认为1。
		/// 设置为0后无法缩放。
		/// </summary>
		[JsonProperty("zoomSensitivity")]
		public double? ZoomSensitivity { get; set; }

		/// <summary>
		/// 平移操作的灵敏度，值越大越灵敏。支持使用数组分别设置横向和纵向的平移灵敏度
		/// 默认为1。
		/// 设置为0后无法平移。
		/// </summary>
		[JsonProperty("panSensitivity")]
		public double? PanSensitivity { get; set; }

		/// <summary>
		/// 平移操作使用的鼠标按键，支持：
		/// 
		/// 'left' 鼠标左键（默认）
		/// 
		/// 'middle' 鼠标中键
		/// 
		/// 'right' 鼠标右键
		/// 
		/// 
		/// 注意：如果设置为鼠标右键则会阻止默认的右键菜单。
		/// </summary>
		[JsonProperty("panMouseButton")]
		public string PanMouseButton { get; set; }

		/// <summary>
		/// 旋转操作使用的鼠标按键，支持：
		/// 
		/// 'left' 鼠标左键
		/// 
		/// 'middle' 鼠标中键（默认）
		/// 
		/// 'right' 鼠标右键
		/// 
		/// 
		/// 注意：如果设置为鼠标右键则会阻止默认的右键菜单。
		/// </summary>
		[JsonProperty("rotateMouseButton")]
		public string RotateMouseButton { get; set; }

		/// <summary>
		/// 默认视角距离主体的距离，对于 globe 来说是距离地球表面的距离，对于 grid3D 和 geo3D 等其它组件来说是距离中心原点的距离。在 projection 为'perspective'的时候有效。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 视角通过鼠标控制能拉近到主体的最小距离。在 projection 为'perspective'的时候有效。
		/// </summary>
		[JsonProperty("minDistance")]
		public double? MinDistance { get; set; }

		/// <summary>
		/// 视角通过鼠标控制能拉远到主体的最大距离。在 projection 为'perspective'的时候有效。
		/// </summary>
		[JsonProperty("maxDistance")]
		public double? MaxDistance { get; set; }

		/// <summary>
		/// 正交投影的大小。在 projection 为'orthographic'的时候有效。
		/// </summary>
		[JsonProperty("orthographicSize")]
		public double? OrthographicSize { get; set; }

		/// <summary>
		/// 正交投影缩放的最大值。在 projection 为'orthographic'的时候有效。
		/// </summary>
		[JsonProperty("maxOrthographicSize")]
		public double? MaxOrthographicSize { get; set; }

		/// <summary>
		/// 正交投影缩放的最小值。在 projection 为'orthographic'的时候有效。
		/// </summary>
		[JsonProperty("minOrthographicSize")]
		public double? MinOrthographicSize { get; set; }

		/// <summary>
		/// 视角绕 x 轴，即上下旋转的角度。配合 beta 可以控制视角的方向。
		/// 如下示意图：
		/// </summary>
		[JsonProperty("alpha")]
		public double? Alpha { get; set; }

		/// <summary>
		/// 视角绕 y 轴，即左右旋转的角度。
		/// </summary>
		[JsonProperty("beta")]
		public double? Beta { get; set; }

		/// <summary>
		/// 视角中心点，旋转也会围绕这个中心点旋转，默认为[0,0,0]。
		/// </summary>
		[JsonProperty("center")]
		public double[] Center { get; set; }

		/// <summary>
		/// 上下旋转的最小 alpha 值。即视角能旋转到达最上面的角度。
		/// </summary>
		[JsonProperty("minAlpha")]
		public double? MinAlpha { get; set; }

		/// <summary>
		/// 上下旋转的最大 alpha 值。即视角能旋转到达最下面的角度。
		/// </summary>
		[JsonProperty("maxAlpha")]
		public double? MaxAlpha { get; set; }

		/// <summary>
		/// 左右旋转的最小 beta 值。即视角能旋转到达最左的角度。
		/// </summary>
		[JsonProperty("minBeta")]
		public double? MinBeta { get; set; }

		/// <summary>
		/// 左右旋转的最大 beta 值。即视角能旋转到达最右的角度。
		/// </summary>
		[JsonProperty("maxBeta")]
		public double? MaxBeta { get; set; }

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
}