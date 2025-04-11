using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// </summary>
	public class Style1
	{
		/// <summary>
		///     文本块文字。可以使用 \n 来换行。
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

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
		///     字体大小、字体类型、粗细、字体样式。格式参见 css font。
		///     例如：
		///     // size | family
		///     font: '2em "STHeiti", sans-serif'
		///     // style | weight | size | family
		///     font: 'italic bolder 16px cursive'
		///     // weight | size | family
		///     font: 'bolder 2em "Microsoft YaHei", sans-serif'
		/// </summary>
		[JsonProperty("font")]
		public string Font { get; set; }

		/// <summary>
		///     水平对齐方式，取值：'left', 'center', 'right'。
		///     如果为 'left'，表示文本最左端在 x 值上。如果为 'right'，表示文本最右端在 x 值上。
		/// </summary>
		[JsonProperty("textAlign")]
		public string TextAlign { get; set; }

		/// <summary>
		///     文本限制宽度，用于提供 overflow 的参考。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		///     当文本内容超出 width 时的文本显示策略，取值：'break', 'breakAll', 'truncate', 'none'。
		///     'break': 尽可能保证完整的单词不被截断(类似 CSS 中的 word-break: break-word;)
		///     'breakAll': 可在任意字符间断行
		///     'truncate': 截断文本屏显示 '...'，可以使用 ellipsis 来自定义省略号的显示
		///     'none': 不换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		///     当 overflow 设置为 'truncate' 时生效，默认为 ...。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		///     垂直对齐方式，取值：'top', 'middle', 'bottom'。
		///     注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		///     注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		///     itemStyle.color => style.fill
		///     itemStyle.borderColor => style.stroke
		///     label.color => style.textFill
		///     label.textBorderColor => style.textStroke
		///     ...
		/// </summary>
		[JsonProperty("textVerticalAlign")]
		public string TextVerticalAlign { get; set; }

		/// <summary>
		///     填充色。
		/// </summary>
		[JsonProperty("fill")]
		public string Fill { get; set; }

		/// <summary>
		///     线条颜色。
		/// </summary>
		[JsonProperty("stroke")]
		public string Stroke { get; set; }

		/// <summary>
		///     线条宽度。
		/// </summary>
		[JsonProperty("lineWidth")]
		public double? LineWidth { get; set; }

		/// <summary>
		///     线条样式。可选：
		///     'solid'
		///     'dashed'
		///     'dotted'
		///     number 或 number 数组。详见 MDN。
		/// </summary>
		[JsonProperty("lineDash")]
		public ArrayOrSingle LineDash { get; set; }

		/// <summary>
		///     用于设置虚线的偏移量。详见 MDN。
		/// </summary>
		[JsonProperty("lineDashOffset")]
		public double? LineDashOffset { get; set; }

		/// <summary>
		///     用于指定线段末端的绘制方式。详见 MDN。
		/// </summary>
		[JsonProperty("lineCap")]
		public string LineCap { get; set; }

		/// <summary>
		///     设置线条转折点的样式。详见 MDN。
		/// </summary>
		[JsonProperty("lineJoin")]
		public string LineJoin { get; set; }

		/// <summary>
		///     设置斜接面限制比例的属性。详见 MDN。
		/// </summary>
		[JsonProperty("miterLimit")]
		public double? MiterLimit { get; set; }

		/// <summary>
		///     阴影宽度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		///     阴影 X 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		///     阴影 Y 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		///     阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public double? ShadowColor { get; set; }

		/// <summary>
		///     不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		///     可以是一个属性名，或者一组属性名。
		///     被指定的属性，在其指发生变化时，会开启过渡动画。
		///     只可以指定本 style 下的属性。
		///     例如：
		///     {
		///     type: 'rect',
		///     style: {
		///     // ...
		///     // 这两个属性会开启过渡动画。
		///     transition: ['mmm', 'ppp']
		///     }
		///     }
		///     我们这样可以指定 style 下所有属性开启过渡动画：
		///     {
		///     type: 'rect',
		///     style: { ... },
		///     // `style` 下所有属性开启过渡动画。
		///     transition: 'style',
		///     }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}
}