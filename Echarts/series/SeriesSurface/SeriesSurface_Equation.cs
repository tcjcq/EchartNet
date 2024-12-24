using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 曲面的函数表达式。如果需要展示的是函数曲面，可以不设置 data，通过 equation 去声明函数表达式。例如通过下面这个函数可以模拟波纹效果。
	/// equation: {
	///     x: {
	///         step: 0.1,
	///         min: -3,
	///         max: 3,
	///     },
	///     y: {
	///         step: 0.1,
	///         min: -3,
	///         max: 3,
	///     },
	///     z: function (x, y) {
	///         return Math.sin(x * x + y * y) * x / 3.14
	///     }
	/// }
	/// </summary>
	public class SeriesSurface_Equation
	{
		/// <summary>
		/// 自变量 x。
		/// </summary>
		[JsonProperty("x")]
		public SeriesSurface_ParametricEquation_U X { get; set; }

		/// <summary>
		/// 自变量 y。
		/// </summary>
		[JsonProperty("y")]
		public SeriesSurface_ParametricEquation_U Y { get; set; }

		/// <summary>
		/// 因变量 z。
		/// z 为关于 x, y 的函数。
		/// (x: number, y: number) => number
		/// </summary>
		[JsonProperty("z")]
		public string Z { get; set; }
	}
}