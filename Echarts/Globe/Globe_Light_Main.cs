using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     场景主光源的设置，在 globe 组件中就是太阳光。
	/// </summary>
	public class Globe_Light_Main
	{
		/// <summary>
		///     主光源的颜色。
		/// </summary>
		[JsonProperty("color")]
		public string Color { get; set; }

		/// <summary>
		///     主光源的强度。
		/// </summary>
		[JsonProperty("intensity")]
		public double? Intensity { get; set; }

		/// <summary>
		///     主光源是否投射阴影。默认为关闭。
		///     开启阴影可以给场景带来更真实和有层次的光照效果。但是同时也会增加程序的运行开销。
		///     下图是开启阴影以及关闭阴影的区别。
		/// </summary>
		[JsonProperty("shadow")]
		public bool? Shadow { get; set; }

		/// <summary>
		///     阴影的质量。可选'low', 'medium', 'high', 'ultra'
		///     下图是低质量和高质量阴影的区别。
		/// </summary>
		[JsonProperty("shadowQuality")]
		public string ShadowQuality { get; set; }

		/// <summary>
		///     主光源绕 x 轴，即上下旋转的角度。配合 beta 控制光源的方向。
		///     如下示意图：
		///     globe 组件中可以通过 time 控制日光的时间。
		/// </summary>
		[JsonProperty("alpha")]
		public double? Alpha { get; set; }

		/// <summary>
		///     主光源绕 y 轴，即左右旋转的角度。
		/// </summary>
		[JsonProperty("beta")]
		public double? Beta { get; set; }

		/// <summary>
		///     日照的时间，默认使用当前的系统时间。
		/// </summary>
		[JsonProperty("time")]
		public string Time { get; set; }
	}
}