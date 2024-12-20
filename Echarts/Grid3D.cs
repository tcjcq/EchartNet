using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 三维笛卡尔坐标系组件。需要和 xAxis3D，yAxis3D，zAxis3D 三个坐标轴组件一起使用。
	/// 可以在三维笛卡尔坐标系上绘制三维折线图，三维柱状图，三维散点/气泡图，曲面图。
	/// 你可以设置 postEffect, light 等配置项提升grid3D中三维图表的显示效果。
	/// 下面是 grid3D 中坐标轴配置项的说明。
	/// 
	/// 
	/// 
	/// 注意： xAxis3D，yAxis3D，zAxis3D 上单独设置的 axisLine, axisTick, axisLabel, splitLine, splitArea, axisPointer` 会覆盖grid3D 下的相应配置项。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class Grid3D
	{
		/// <summary>
		/// 是否显示三维笛卡尔坐标系。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 三维笛卡尔坐标系在三维场景中的宽度。配合 viewControl.distance 可以得到最合适的展示尺寸。
		/// </summary>
		[JsonProperty("boxWidth")]
		public double? BoxWidth { get; set; }

		/// <summary>
		/// 三维笛卡尔坐标系在三维场景中的高度。
		/// </summary>
		[JsonProperty("boxHeight")]
		public double? BoxHeight { get; set; }

		/// <summary>
		/// 三维笛卡尔坐标系在三维场景中的深度。
		/// </summary>
		[JsonProperty("boxDepth")]
		public double? BoxDepth { get; set; }

		/// <summary>
		/// 坐标轴轴线相关设置。
		/// </summary>
		[JsonProperty("axisLine")]
		public Grid3D_AxisLine AxisLine { get; set; }

		/// <summary>
		/// 坐标轴刻度标签的相关设置。
		/// </summary>
		[JsonProperty("axisLabel")]
		public Grid3D_AxisLabel AxisLabel { get; set; }

		/// <summary>
		/// 坐标轴刻度相关设置。
		/// </summary>
		[JsonProperty("axisTick")]
		public AxisTick1 AxisTick { get; set; }

		/// <summary>
		/// 坐标轴轴线相关设置。
		/// </summary>
		[JsonProperty("splitLine")]
		public Grid3D_AxisLine SplitLine { get; set; }

		/// <summary>
		/// 坐标轴在 grid3D 的平面上的分隔区域。
		/// </summary>
		[JsonProperty("splitArea")]
		public Grid3D_SplitArea SplitArea { get; set; }

		/// <summary>
		/// 坐标轴指示线。
		/// </summary>
		[JsonProperty("axisPointer")]
		public ZAxis3D_AxisPointer AxisPointer { get; set; }

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
		/// 光照相关的设置。在 shading 为 'color' 的时候无效。
		/// 光照的设置会影响到组件以及组件所在坐标系上的所有图表。
		/// 合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
		/// </summary>
		[JsonProperty("light")]
		public Grid3D_Light Light { get; set; }

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
		public Grid3D_ViewControl ViewControl { get; set; }

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
	/// 坐标轴轴线相关设置。
	/// </summary>
	public class Grid3D_AxisLine
	{
		/// <summary>
		/// 是否显示坐标轴轴线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 坐标轴刻度标签的显示间隔，在类目轴中有效。
		/// 默认会自动计算interval以保证较好的展示效果。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示『隔两个标签显示一个标签』，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }
	}

	/// <summary>
	/// 坐标轴刻度标签的相关设置。
	/// </summary>
	public class Grid3D_AxisLabel
	{
		/// <summary>
		/// 是否显示刻度标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 刻度标签与轴线之间的距离。
		/// 注意： 这个距离是三维空间而非屏幕空间的。
		/// </summary>
		[JsonProperty("margin")]
		public double? Margin { get; set; }

		/// <summary>
		/// 坐标轴刻度标签的显示间隔，在类目轴中有效。
		/// 默认会自动计算interval以保证较好的展示效果。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示『隔两个标签显示一个标签』，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textStyle")]
		public TextStyle3 TextStyle { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class TextStyle3
	{
		/// <summary>
		/// 刻度标签文字的颜色，默认取 axisLine.lineStyle.color。支持回调函数，格式如下
		/// (val: string) => Color
		/// 
		/// 参数是标签的文本，返回颜色值，如下示例：
		/// textStyle: {
		///     color: function (value, index) {
		///         return value >= 0 ? 'green' : 'red';
		///     }
		/// }
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

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
	/// 坐标轴刻度相关设置。
	/// </summary>
	public class AxisTick1
	{
		/// <summary>
		/// 是否显示坐标轴刻度。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 坐标轴刻度标签的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
		/// 默认会自动计算interval以保证较好的展示效果。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示『隔两个标签显示一个标签』，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 坐标轴刻度的长度。
		/// </summary>
		[JsonProperty("length")]
		public double? Length { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle7 LineStyle { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class LineStyle7
	{
		/// <summary>
		/// 刻度线的颜色，默认取 axisLine.lineStyle.color。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 线条的不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 线条的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }
	}


	/// <summary>
	/// 坐标轴在 grid3D 的平面上的分隔区域。
	/// </summary>
	public class Grid3D_SplitArea
	{
		/// <summary>
		/// 是否显示分隔区域。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 坐标轴分隔区域的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
		/// 默认会自动计算interval以保证较好的展示效果。
		/// 可以设置成 0 强制显示所有标签。
		/// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示『隔两个标签显示一个标签』，以此类推。
		/// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
		/// (index:number, value: string) => boolean
		/// 
		/// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
		/// </summary>
		[JsonProperty("interval")]
		public StringOrNumber Interval { get; set; }

		/// <summary>
		/// 分隔区域的样式设置。
		/// </summary>
		[JsonProperty("areaStyle")]
		public AreaStyle2 AreaStyle { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class AreaStyle2
	{
		/// <summary>
		/// 分隔区域颜色。分隔区域会按数组中颜色的顺序依次循环设置颜色。默认是一个深浅的间隔色。
		/// </summary>
		[JsonProperty("color")]
		public double[] Color { get; set; }
	}


	/// <summary>
	/// 坐标轴指示线。
	/// </summary>
	public class ZAxis3D_AxisPointer
	{
		/// <summary>
		/// 是否显示坐标轴指示线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle6 LineStyle { get; set; }

		/// <summary>
		/// 指示线标签。
		/// </summary>
		[JsonProperty("label")]
		public Grid3D_AxisPointer_Label Label { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class LineStyle6
	{
		/// <summary>
		/// 线条的颜色。
		/// 除了颜色字符串外，支持使用数组表示的 RGBA 值，例如：
		/// // 纯白色
		/// [1, 1, 1, 1]
		/// 
		/// 使用数组表示的时候，每个通道可以设置大于 1 的值用于表示 HDR 的色值。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		/// 线条的不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 线条的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Grid3D_AxisPointer_Label
	{
		/// <summary>
		/// 是否显示指示线标签。默认数值轴显示，类目轴不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签格式器，函数第一个参数是当前坐标轴的数值，第二个参数是所有坐标轴的数值数组。
		/// (value: number, valueAll: Array) => string
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 标签距离坐标轴的距离。同刻度标签一样，这个距离是三维空间而非屏幕像素。
		/// </summary>
		[JsonProperty("margin")]
		public double? Margin { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textStyle")]
		public TextStyle2 TextStyle { get; set; }
	}


	/// <summary>
	/// 光照相关的设置。在 shading 为 'color' 的时候无效。
	/// 光照的设置会影响到组件以及组件所在坐标系上的所有图表。
	/// 合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
	/// </summary>
	public class Grid3D_Light
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
	/// viewControl用于鼠标的旋转，缩放等视角控制。
	/// </summary>
	public class Grid3D_ViewControl
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
		public object MinBeta { get; set; }

		/// <summary>
		/// 左右旋转的最大 beta 值。即视角能旋转到达最右的角度。
		/// </summary>
		[JsonProperty("maxBeta")]
		public object MaxBeta { get; set; }

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