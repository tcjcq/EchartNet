using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// </summary>
	public class Shape4
	{
		/// <summary>
		///     点列表，用于定义形状，如 [[22, 44], [44, 55], [11, 44], ...]
		/// </summary>
		[JsonProperty("points")]
		public double[] Points { get; set; }

		/// <summary>
		///     是否平滑曲线。
		///     如果为 number：表示贝塞尔 (bezier) 差值平滑，smooth 指定了平滑等级，范围 [0, 1]。
		///     如果为 'spline'：表示 Catmull-Rom spline 差值平滑。
		/// </summary>
		[JsonProperty("smooth")]
		public StringOrNumber Smooth { get; set; }

		/// <summary>
		///     是否将平滑曲线约束在包围盒中。smooth 为 number（bezier）时生效。
		/// </summary>
		[JsonProperty("smoothConstraint")]
		public bool? SmoothConstraint { get; set; }

		/// <summary>
		///     可以是一个属性名，或者一组属性名。
		///     被指定的属性，在其指发生变化时，会开启过渡动画。
		///     只可以指定本 shape 下的属性。
		///     例如：
		///     {
		///     type: 'rect',
		///     shape: {
		///     // ...
		///     // 这两个属性会开启过渡动画。
		///     transition: ['mmm', 'ppp']
		///     }
		///     }
		///     我们这样可以指定 shape 下所有属性开启过渡动画：
		///     {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		///     }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}
}