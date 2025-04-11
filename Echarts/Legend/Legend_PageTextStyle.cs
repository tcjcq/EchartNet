using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     legend.type 为 'scroll' 时有效。
	///     图例页信息的文字样式。
	/// </summary>
	public class Legend_PageTextStyle
	{
		/// <summary>
		///     文字的颜色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		///     文字字体的风格。
		///     可选：
		///     'normal'
		///     'italic'
		///     'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		///     文字字体的粗细。
		///     可选：
		///     'normal'
		///     'bold'
		///     'bolder'
		///     'lighter'
		///     100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		///     文字的字体系列。
		///     还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		///     文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		///     行高。
		///     rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		///     {
		///     lineHeight: 56,
		///     rich: {
		///     a: {
		///     // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///     }
		///     }
		///     }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		///     文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		///     文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		///     文字本身的描边颜色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		///     文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		///     文字本身的描边类型。
		///     可选：
		///     'solid'
		///     'dashed'
		///     'dotted'
		///     自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合
		///     textBorderDashOffset
		///     可实现更灵活的虚线效果。
		///     例如：
		///     {
		///     textBorderType: [5, 10],
		///     textBorderDashOffset: 5
		///     }
		/// </summary>
		[JsonProperty("textBorderType")]
		public ArrayOrSingle TextBorderType { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     用于设置虚线的偏移量，可搭配
		///     textBorderType
		///     指定 dash array 实现灵活的虚线效果。
		///     更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		///     文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		///     文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		///     文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		///     文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		///     文字超出宽度是否截断或者换行。配置width时有效
		///     'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		///     'break' 换行
		///     'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		///     在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }
	}
}