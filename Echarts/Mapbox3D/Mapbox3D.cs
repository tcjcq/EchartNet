using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     基于 mapbox-gl-js 的地理组件。支持在 mapbox 的地图上绘制三维的散点图，飞线图，柱状图和地图。你可以利用 Mapbox 强大的地图服务和 ECharts GL 丰富的可视化和渲染效果实现你想要的可视化作品。
	///     在使用 mapbox 组件之前你需要先引入 mapbox 的官方 sdk。
	///     <script src='https://api.mapbox.com/mapbox-gl-js/v0.38.0/mapbox-gl.js'></script>
	///     <link href='https://api.mapbox.com/mapbox-gl-js/v0.38.0/mapbox-gl.css' rel='stylesheet' />
	///     然后获取到 mapbox 提供的 token 后设置到 mapbox.accessToken 上。
	///     mapboxgl.accessToken = '你的 token';
	///     接下来你就可以像使用其它组件一样使用 mapbox 组件了。
	///     chart.setOption({
	///     mapbox: {
	///     style: 'mapbox://styles/mapbox/dark-v9'
	///     }
	///     });
	///     可以前往 https://www.mapbox.com/mapbox-gl-js/api/ 了解更详细的关于 mapbox-gl-js sdk 的内容。
	/// </summary>
	public class Mapbox3D
	{
		/// <summary>
		///     Mapbox 地图样式。同 https://www.mapbox.com/mapbox-gl-js/style-spec/
		/// </summary>
		[JsonProperty("style")]
		public string Style { get; set; }

		/// <summary>
		///     Mapbox 地图中心经纬度。经纬度用数组表示，例如：
		///     mapbox3D: {
		///     center: [104.114129, 37.550339],
		///     zoom: 3
		///     }
		/// </summary>
		[JsonProperty("center")]
		public ArrayOrSingle Center { get; set; }

		/// <summary>
		///     Mapbox 地图的缩放等级。见 https://www.mapbox.com/mapbox-gl-js/style-spec/#root-zoom
		/// </summary>
		[JsonProperty("zoom")]
		public double? Zoom { get; set; }

		/// <summary>
		///     Mapbox 地图的旋转角度。见 https://www.mapbox.com/mapbox-gl-js/style-spec/#root-bearing
		/// </summary>
		[JsonProperty("bearing")]
		public double? Bearing { get; set; }

		/// <summary>
		///     视角俯视的倾斜角度。默认为0，也就是垂直于地图表面。最大的值是60。见 https://www.mapbox.com/mapbox-gl-js/style-spec/#root-pitch
		/// </summary>
		[JsonProperty("pitch")]
		public double? Pitch { get; set; }

		/// <summary>
		///     海拔的缩放。
		/// </summary>
		[JsonProperty("altitudeScale")]
		public double? AltitudeScale { get; set; }

		/// <summary>
		///     mapbox3D中三维图形的着色效果。echarts-gl 中支持下面三种着色方式：
		///     'color'
		///     只显示颜色，不受光照等其它因素的影响。
		///     'lambert'
		///     通过经典的 lambert 着色表现光照带来的明暗。
		///     'realistic'
		///     真实感渲染，配合 light.ambientCubemap 和 postEffect 使用可以让展示的画面效果和质感有质的提升。ECharts GL 中使用了基于物理的渲染（PBR） 来表现真实感材质。
		/// </summary>
		[JsonProperty("shading")]
		public string Shading { get; set; }

		/// <summary>
		///     真实感材质相关的配置项，在 shading 为'realistic'时有效。
		/// </summary>
		[JsonProperty("realisticMaterial")]
		public Globe_RealisticMaterial RealisticMaterial { get; set; }

		/// <summary>
		///     lambert 材质相关的配置项，在 shading 为'lambert'时有效。
		/// </summary>
		[JsonProperty("lambertMaterial")]
		public Globe_LambertMaterial LambertMaterial { get; set; }

		/// <summary>
		///     color 材质相关的配置项，在 shading 为'color'时有效。
		/// </summary>
		[JsonProperty("colorMaterial")]
		public Globe_LambertMaterial ColorMaterial { get; set; }

		/// <summary>
		///     光照相关的设置。在 shading 为 'color' 的时候无效。
		///     光照的设置会影响到组件以及组件所在坐标系上的所有图表。
		///     合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
		/// </summary>
		[JsonProperty("light")]
		public Mapbox3D_Light Light { get; set; }

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
	}
}