using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     设置日历坐标中 月份轴的样式
/// </summary>
public class Calendar_MonthLabel
{
	/// <summary>
	///     是否在普通状态下显示标签。
	/// </summary>
	[JsonProperty("show")]
	public bool? Show { get; set; }

	/// <summary>
	///     文字水平对齐方式，默认自动。
	///     可选：
	///     'left'
	///     'center'
	///     'right'
	///     rich 中如果没有设置 align，则会取父层级的 align。例如：
	///     {
	///     align: right,
	///     rich: {
	///     a: {
	///     // 没有设置 `align`，则 `align` 为 right
	///     }
	///     }
	///     }
	/// </summary>
	[JsonProperty("align")]
	public string Align { get; set; }

	/// <summary>
	///     月份标签与轴线之间的距离
	/// </summary>
	[JsonProperty("margin")]
	public double? Margin { get; set; }

	/// <summary>
	///     月份的位置 在开头还是结尾。
	///     可选：
	///     'start'
	///     'end'
	/// </summary>
	[JsonProperty("position")]
	public string Position { get; set; }

	/// <summary>
	///     月份显示的效果，默认为'en'。从 v5.2.2 起，默认为初始化图表 时指定的语言 locale，如未指定则根据浏览器语言自动侦测。
	///     可设置中英文以及自定义。从 v5.2.2 起，还可以是任意内置(ZH / EN)或其他已注册的语言包名称（区分大小写）。
	///     下标 0 为对应 1月 的文字显示。
	///     使用示例：
	///     // v5.2.2 以前版本
	///     // 快捷设置英文
	///     // ['Jan', 'Feb', 'Mar','Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
	///     nameMap: 'en',
	///     // 快捷设置中文
	///     // ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月']
	///     nameMap: 'cn',
	///     // v5.2.2 及以后版本
	///     // 快捷设置英文
	///     // ['Jan', 'Feb', 'Mar','Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
	///     nameMap: 'EN',
	///     // 快捷设置中文
	///     // ['1月', '2月', '3月', '4月', '5月', '6月', '7月', '8月', '9月', '10月', '11月', '12月']
	///     nameMap: 'ZH',
	///     // 自定义设置：中英俄混杂 或者不显示
	///     nameMap: [
	///     '一月', 'Feb', '三月',
	///     '四月', 'May', '六月',
	///     'Июль', '八月', '',
	///     '十月', 'Nov', '十二月'
	///     ],
	///     calendar: [{
	///     monthLabel: {
	///     // nameMap: 'en' // v5.2.2 以前版本
	///     nameMap: 'EN'    // v5.2.2 及以后版本
	///     }
	///     }]
	/// </summary>
	[JsonProperty("nameMap")]
	public ArrayOrSingle NameMap { get; set; }

	/// <summary>
	///     用来格式化月份文本，支持字符串模板和回调函数两种形式。
	///     示例：
	///     // 使用字符串模板，例如：2017-02
	///     /*
	///     模板变量{nameMap} 月份原本名称 eg：'Feb'
	///     模板变量{yyyy}   四位数年份 eg: 2017
	///     模板变量{yy}   后两位数年份 eg: 17
	///     模板变量{MM}   两位数月份 eg: 02
	///     模板变量{M}   一位数月份 eg: 2
	///     */
	///     formatter: '{yyyy}-{MM}'
	///     // 使用回调函数
	///     /*
	///     param.nameMap 月份原本名称 eg：'Feb'
	///     param.yyyy   四位数年份 eg: 2017
	///     param.yy   后两位数年份 eg: 17
	///     param.MM   两位数月份 eg: 02
	///     param.M   一位数月份 eg: 2
	///     */
	///     formatter: function (param) {
	///     // ...
	///     return param.MM;
	///     }
	/// </summary>
	[JsonProperty("formatter")]
	public string Formatter { get; set; }

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
	///     文字垂直对齐方式，默认自动。
	///     可选：
	///     'top'
	///     'middle'
	///     'bottom'
	///     rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
	///     {
	///     verticalAlign: bottom,
	///     rich: {
	///     a: {
	///     // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
	///     }
	///     }
	///     }
	/// </summary>
	[JsonProperty("verticalAlign")]
	public string VerticalAlign { get; set; }

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
	///     文字块背景色。
	///     可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
	///     也可以直接使用图片，例如：
	///     backgroundColor: {
	///     image: 'xxx/xxx.png'
	///     // 这里可以是图片的 URL，
	///     // 或者图片的 dataURI，
	///     // 或者 HTMLImageElement 对象，
	///     // 或者 HTMLCanvasElement 对象。
	///     }
	///     当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
	/// </summary>
	[JsonProperty("backgroundColor")]
	public Color BackgroundColor { get; set; }

	/// <summary>
	///     文字块边框颜色。
	/// </summary>
	[JsonProperty("borderColor")]
	public Color BorderColor { get; set; }

	/// <summary>
	///     文字块边框宽度。
	/// </summary>
	[JsonProperty("borderWidth")]
	public double? BorderWidth { get; set; }

	/// <summary>
	///     文字块边框描边类型。
	///     可选：
	///     'solid'
	///     'dashed'
	///     'dotted'
	///     自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合
	///     borderDashOffset
	///     可实现更灵活的虚线效果。
	///     例如：
	///     {
	///     borderType: [5, 10],
	///     borderDashOffset: 5
	///     }
	/// </summary>
	[JsonProperty("borderType")]
	public ArrayOrSingle BorderType { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     用于设置虚线的偏移量，可搭配
	///     borderType
	///     指定 dash array 实现灵活的虚线效果。
	///     更多详情可以参考 MDN lineDashOffset。
	/// </summary>
	[JsonProperty("borderDashOffset")]
	public double? BorderDashOffset { get; set; }

	/// <summary>
	///     文字块的圆角。
	/// </summary>
	[JsonProperty("borderRadius")]
	public ArrayOrSingle BorderRadius { get; set; }

	/// <summary>
	///     文字块的内边距。例如：
	///     padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
	///     padding: 4：表示 padding: [4, 4, 4, 4]。
	///     padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
	///     注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
	/// </summary>
	[JsonProperty("padding")]
	public ArrayOrSingle Padding { get; set; }

	/// <summary>
	///     文字块的背景阴影颜色。
	/// </summary>
	[JsonProperty("shadowColor")]
	public Color ShadowColor { get; set; }

	/// <summary>
	///     文字块的背景阴影长度。
	/// </summary>
	[JsonProperty("shadowBlur")]
	public double? ShadowBlur { get; set; }

	/// <summary>
	///     文字块的背景阴影 X 偏移。
	/// </summary>
	[JsonProperty("shadowOffsetX")]
	public double? ShadowOffsetX { get; set; }

	/// <summary>
	///     文字块的背景阴影 Y 偏移。
	/// </summary>
	[JsonProperty("shadowOffsetY")]
	public double? ShadowOffsetY { get; set; }

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

	/// <summary>
	///     在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
	///     例如：
	///     label: {
	///     // 在文本中，可以对部分文本采用 rich 中定义样式。
	///     // 这里需要在文本中使用标记符号：
	///     // `{styleName|text content text content}` 标记样式名。
	///     // 注意，换行仍是使用 '\n'。
	///     formatter: [
	///     '{a|这段文本采用样式a}',
	///     '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
	///     ].join('\n'),
	///     rich: {
	///     a: {
	///     color: 'red',
	///     lineHeight: 10
	///     },
	///     b: {
	///     backgroundColor: {
	///     image: 'xxx/xxx.jpg'
	///     },
	///     height: 40
	///     },
	///     x: {
	///     fontSize: 18,
	///     fontFamily: 'Microsoft YaHei',
	///     borderColor: '#449933',
	///     borderRadius: 4
	///     },
	///     ...
	///     }
	///     }
	///     详情参见教程：富文本标签
	/// </summary>
	[JsonProperty("rich")]
	public Dictionary<string, Rich0> Rich { get; set; }
}