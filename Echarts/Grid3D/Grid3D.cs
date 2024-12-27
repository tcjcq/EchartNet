using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     三维笛卡尔坐标系组件。需要和 xAxis3D，yAxis3D，zAxis3D 三个坐标轴组件一起使用。
	///     可以在三维笛卡尔坐标系上绘制三维折线图，三维柱状图，三维散点/气泡图，曲面图。
	///     你可以设置 postEffect, light 等配置项提升grid3D中三维图表的显示效果。
	///     下面是 grid3D 中坐标轴配置项的说明。
	///     注意： xAxis3D，yAxis3D，zAxis3D 上单独设置的 axisLine, axisTick, axisLabel, splitLine, splitArea, axisPointer` 会覆盖grid3D
	///     下的相应配置项。
	/// </summary>
	public class Grid3D
	{
		/// <summary>
		///     是否显示三维笛卡尔坐标系。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     三维笛卡尔坐标系在三维场景中的宽度。配合 viewControl.distance 可以得到最合适的展示尺寸。
		/// </summary>
		[JsonProperty("boxWidth")]
		public double? BoxWidth { get; set; }

		/// <summary>
		///     三维笛卡尔坐标系在三维场景中的高度。
		/// </summary>
		[JsonProperty("boxHeight")]
		public double? BoxHeight { get; set; }

		/// <summary>
		///     三维笛卡尔坐标系在三维场景中的深度。
		/// </summary>
		[JsonProperty("boxDepth")]
		public double? BoxDepth { get; set; }

		/// <summary>
		///     坐标轴轴线相关设置。
		/// </summary>
		[JsonProperty("axisLine")]
		public Grid3D_AxisLine AxisLine { get; set; }

		/// <summary>
		///     坐标轴刻度标签的相关设置。
		/// </summary>
		[JsonProperty("axisLabel")]
		public Grid3D_AxisLabel AxisLabel { get; set; }

		/// <summary>
		///     坐标轴刻度相关设置。
		/// </summary>
		[JsonProperty("axisTick")]
		public AxisTick1 AxisTick { get; set; }

		/// <summary>
		///     坐标轴轴线相关设置。
		/// </summary>
		[JsonProperty("splitLine")]
		public Grid3D_AxisLine SplitLine { get; set; }

		/// <summary>
		///     坐标轴在 grid3D 的平面上的分隔区域。
		/// </summary>
		[JsonProperty("splitArea")]
		public Grid3D_SplitArea SplitArea { get; set; }

		/// <summary>
		///     坐标轴指示线。
		/// </summary>
		[JsonProperty("axisPointer")]
		public ZAxis3D_AxisPointer AxisPointer { get; set; }

		/// <summary>
		///     环境贴图。支持纯色、渐变色、全景贴图的 url。默认为 'auto'，在配置有 light.ambientCubemap.texture 的时候会使用该纹理作为环境贴图。否则则不显示环境贴图。
		///     示例：
		///     // 配置为全景贴图
		///     environment: 'asset/starfield.jpg'
		///     // 配置为纯黑色的背景
		///     environment: '#000'
		///     // 配置为垂直渐变的背景
		///     environment: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
		///     offset: 0, color: '#00aaff' // 天空颜色
		///     }, {
		///     offset: 0.7, color: '#998866' // 地面颜色
		///     }, {
		///     offset: 1, color: '#998866' // 地面颜色
		///     }], false)
		/// </summary>
		[JsonProperty("environment")]
		public string Environment { get; set; }

		/// <summary>
		///     光照相关的设置。在 shading 为 'color' 的时候无效。
		///     光照的设置会影响到组件以及组件所在坐标系上的所有图表。
		///     合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
		/// </summary>
		[JsonProperty("light")]
		public Grid3D_Light Light { get; set; }

		/// <summary>
		///     后处理特效的相关配置。后处理特效可以为画面添加高光、景深、环境光遮蔽（SSAO）、调色等效果。可以让整个画面更富有质感。
		///     下面分别是关闭和开启 postEffect 的区别。
		///     注意在开启 postEffect 的时候默认会开启 temporalSuperSampling 在画面静止后持续对画面增强，包括抗锯齿、景深、SSAO、阴影等。
		/// </summary>
		[JsonProperty("postEffect")]
		public SeriesMap3D_PostEffect PostEffect { get; set; }

		/// <summary>
		///     分帧超采样。在开启 postEffect 后，WebGL 默认的 MSAA 会无法使用，所以我们需要自己解决锯齿的问题。
		///     分帧超采样是用来解决锯齿问题的方法，它在画面静止后会持续分帧对一个像素多次抖动采样，从而达到抗锯齿的效果。而且在这个分帧采样的过程中，echarts-gl 也会对 postEffect 中一些需要采样保证效果的特效，例如
		///     SSAO, 景深，以及阴影进行渐进增强。
		///     下面是未开启和开启temporalSuperSampling的区别。
		/// </summary>
		[JsonProperty("temporalSuperSampling")]
		public Globe_TemporalSuperSampling TemporalSuperSampling { get; set; }

		/// <summary>
		///     viewControl用于鼠标的旋转，缩放等视角控制。
		/// </summary>
		[JsonProperty("viewControl")]
		public Grid3D_ViewControl ViewControl { get; set; }

		/// <summary>
		///     组件所在的层。
		///     zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的
		///     Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		///     zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		///     注: echarts-gl 中组件的层需要跟 echarts 中组件的层分开。同一个 zlevel 不能同时用于 WebGL 和 Canvas 的绘制。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		///     组件的视图离容器左侧的距离。
		///     left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		///     如果 left 的值为'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		///     组件的视图离容器上侧的距离。
		///     top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		///     如果 top 的值为'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		///     组件的视图离容器右侧的距离。
		///     right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		///     默认自适应。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		///     组件的视图离容器下侧的距离。
		///     bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		///     默认自适应。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		///     组件的视图宽度。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		///     组件的视图高度。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }
	}
}