using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// </summary>
	public class Shape0
	{
		/// <summary>
		///     图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		///     图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		///     图形元素的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		///     图形元素的高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		///     可以用于设置圆角矩形。r: [r1, r2, r3, r4]，
		///     左上、右上、右下、左下角的半径依次为r1、r2、r3、r4。
		///     可以缩写，例如：
		///     r 缩写为 1         相当于 [1, 1, 1, 1]
		///     r 缩写为 [1]       相当于 [1, 1, 1, 1]
		///     r 缩写为 [1, 2]    相当于 [1, 2, 1, 2]
		///     r 缩写为 [1, 2, 3]1 相当于[1, 2, 3, 2]`
		/// </summary>
		[JsonProperty("r")]
		public double[] R { get; set; }

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