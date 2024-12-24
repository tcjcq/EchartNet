using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 注：treemap中 itemStyle 属性可能在多处地方存在：
	/// 
	/// 
	/// 
	/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
	/// 
	/// 
	/// 
	/// 
	/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
	/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
	/// </summary>
	public class ItemStyle8
	{
		/// <summary>
		/// 矩形的颜色。默认从全局调色盘 option.color 获取颜色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 矩形圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 矩形边框线宽。为 0 时无边框。而矩形的内部子矩形（子节点）的间隔距离是由 gapWidth 指定的。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 矩形内部子矩形（子节点）的间隔距离。
		/// </summary>
		[JsonProperty("gapWidth")]
		public double? GapWidth { get; set; }

		/// <summary>
		/// 矩形边框 和 矩形间隔（gap）的颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 矩形边框的颜色的饱和度。取值范围是 0 ~ 1 之间的浮点数。
		/// 注意：
		/// 如果设置此属性，则 borderColor 的设置无效，而是：取当前节点计算出的颜色（比如从父节点遗传而来），在此颜色值上设置 borderColorSaturation 得到最终颜色。这种方式，能够做出『不同区块有不同色调的矩形间隔线』的效果，能够便于区分层级。
		/// 矩形边框（border）/缝隙（gap）设置如何避免混淆
		/// 如果统一用一种颜色设置矩形的缝隙（gap），那么当不同层级的矩形同时展示时可能会出现混淆。
		/// 参见 例子，注意其中红色的区块中的子矩形其实是更深层级，和其他用白色缝隙区分的矩形不是在一个层级。所以，红色区块中矩形的分割线的颜色，我们在 borderColorSaturation 中设置为『加了饱和度变化的红颜色』，以示区别。
		/// </summary>
		[JsonProperty("borderColorSaturation")]
		public Color BorderColorSaturation { get; set; }

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

		/// <summary>
		/// 图形的贴花图案，在 aria.enabled 与 aria.decal.show 都是 true 的情况下才生效。
		/// 如果为 'none' 表示不使用贴花图案。
		/// </summary>
		[JsonProperty("decal")]
		public Decal0 Decal { get; set; }
	}
}