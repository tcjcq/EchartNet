using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     光照相关的设置。在 shading 为 'color' 的时候无效。
	///     光照的设置会影响到组件以及组件所在坐标系上的所有图表。
	///     合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
	/// </summary>
	public class Globe_Light
	{
		/// <summary>
		///     场景主光源的设置，在 globe 组件中就是太阳光。
		/// </summary>
		[JsonProperty("main")]
		public Globe_Light_Main Main { get; set; }

		/// <summary>
		///     全局的环境光设置。
		/// </summary>
		[JsonProperty("ambient")]
		public Globe_Light_Ambient Ambient { get; set; }

		/// <summary>
		///     ambientCubemap 会使用纹理作为环境光的光源，会为物体提供漫反射和高光反射。可以通过 diffuseIntensity 和 specularIntensity 分别设置漫反射强度和高光反射强度。
		/// </summary>
		[JsonProperty("ambientCubemap")]
		public Globe_Light_AmbientCubemap AmbientCubemap { get; set; }
	}
}