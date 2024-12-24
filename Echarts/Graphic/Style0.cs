using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 
	/// </summary>
	public class Style0
	{
		/// <summary>
		/// 图片的内容，可以是图片的 URL，也可以是 dataURI.
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 图形元素的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 图形元素的高度。
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 填充色。
		/// </summary>
		[JsonProperty("fill")]
		public string Fill { get; set; }

		/// <summary>
		/// 线条颜色。
		/// </summary>
		[JsonProperty("stroke")]
		public string Stroke { get; set; }

		/// <summary>
		/// 线条宽度。
		/// </summary>
		[JsonProperty("lineWidth")]
		public double? LineWidth { get; set; }

		/// <summary>
		/// 线条样式。可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// number 或 number 数组。详见 MDN。
		/// </summary>
		[JsonProperty("lineDash")]
		public StringOrNumber[] LineDash { get; set; }

		/// <summary>
		/// 用于设置虚线的偏移量。详见 MDN。
		/// </summary>
		[JsonProperty("lineDashOffset")]
		public double? LineDashOffset { get; set; }

		/// <summary>
		/// 用于指定线段末端的绘制方式。详见 MDN。
		/// </summary>
		[JsonProperty("lineCap")]
		public string LineCap { get; set; }

		/// <summary>
		/// 设置线条转折点的样式。详见 MDN。
		/// </summary>
		[JsonProperty("lineJoin")]
		public string LineJoin { get; set; }

		/// <summary>
		/// 设置斜接面限制比例的属性。详见 MDN。
		/// </summary>
		[JsonProperty("miterLimit")]
		public double? MiterLimit { get; set; }

		/// <summary>
		/// 阴影宽度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影 X 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影 Y 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public double? ShadowColor { get; set; }

		/// <summary>
		/// 不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 style 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     style: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 style 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     style: { ... },
		///     // `style` 下所有属性开启过渡动画。
		///     transition: 'style',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}
}