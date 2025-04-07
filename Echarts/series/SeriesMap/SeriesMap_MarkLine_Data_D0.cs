using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     起点的数据。
/// </summary>
public class SeriesMap_MarkLine_Data_D0
{
	/// <summary>
	///     在使用 type 时有效，用于指定在哪个维度上指定最大值最小值，可以是 0（xAxis, radiusAxis），1（yAxis, angleAxis），默认使用第一个数值轴所在的维度。
	/// </summary>
	[JsonProperty("valueIndex")]
	public double? ValueIndex { get; set; }

	/// <summary>
	///     在使用 type 时有效，用于指定在哪个维度上指定最大值最小值。这可以是维度的直接名称，例如折线图时可以是x、angle等、candlestick 图时可以是open、close等维度名称。
	/// </summary>
	[JsonProperty("valueDim")]
	public string ValueDim { get; set; }

	/// <summary>
	///     起点或终点的坐标。坐标格式视系列的坐标系而定，可以是直角坐标系上的 x, y，也可以是极坐标系上的 radius, angle。
	///     注：对于 axis.type 为 'category' 类型的轴
	///     如果 coord 值为 number，则表示 axis.data 的 index。
	///     如果 coord 值为 string，则表示 axis.data 中具体的值。注意使用这种方式时，xAxis.data 不能写成 [number, number, ...]，而只能写成 [string, string,
	///     ...]，否则不能被 markPoint / markLine 用『具体值』索引到。
	///     例如：
	///     {
	///     xAxis: {
	///     type: 'category',
	///     data: ['5', '6', '9', '13', '19', '33']
	///     // 注意这里不建议写成 [5, 6, 9, 13, 19, 33]，否则不能被 markPoint / markLine 用『具体值』索引到。
	///     },
	///     series: {
	///     type: 'line',
	///     data: [11, 22, 33, 44, 55, 66],
	///     markPoint: { // markLine 也是同理
	///     data: [{
	///     coord: [5, 33.4], // 其中 5 表示 xAxis.data[5]，即 '33' 这个元素。
	///     // coord: ['5', 33.4] // 其中 '5' 表示 xAxis.data中的 '5' 这个元素。
	///     // 注意，使用这种方式时，xAxis.data 不能写成 [number, number, ...]
	///     // 而只能写成 [string, string, ...]
	///     }]
	///     }
	///     }
	///     }
	/// </summary>
	[JsonProperty("coord")]
	public double[] Coord { get; set; }

	/// <summary>
	///     标注名称。定义后可在 label formatter 中作为数据名 {b} 模板变量使用。
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	///     相对容器的屏幕 x 坐标，单位像素。
	/// </summary>
	[JsonProperty("x")]
	public double? X { get; set; }

	/// <summary>
	///     相对容器的屏幕 y 坐标，单位像素。
	/// </summary>
	[JsonProperty("y")]
	public double? Y { get; set; }

	/// <summary>
	///     x 值为给定值的标记线，仅对数据值是一项的设置有效。例如：
	///     data: [{
	///     name: 'X 轴值为 100 的竖直线',
	///     xAxis: 100
	///     }]
	///     或对于 'time' 类型的 xAxis，可以设置为：
	///     {
	///     name: 'X 轴值为 "2020-01-01" 的竖直线',
	///     xAxis: '2020-01-01'
	///     }]
	/// </summary>
	[JsonProperty("xAxis")]
	public StringOrNumber XAxis { get; set; }

	/// <summary>
	///     Y 值为给定值的标记线，仅对数据值是一项的设置有效。例如：
	///     data: [{
	///     name: 'Y 轴值为 100 的水平线',
	///     yAxis: 100
	///     }]
	///     或对于 'time' 类型的 yAxis，可以设置为：
	///     {
	///     name: 'Y 轴值为 "2020-01-01" 的水平线',
	///     yAxis: '2020-01-01'
	///     }]
	/// </summary>
	[JsonProperty("yAxis")]
	public StringOrNumber YAxis { get; set; }

	/// <summary>
	///     标注值，可以不设。
	/// </summary>
	[JsonProperty("value")]
	public double? Value { get; set; }

	/// <summary>
	///     起点标记的图形。
	///     ECharts 提供的标记类型包括
	///     'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
	///     可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
	///     URL 为图片链接例如：
	///     'image://http://example.website/a/b.png'
	///     URL 为 dataURI 例如：
	///     'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
	///     可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从
	///     Adobe Illustrator 等工具编辑导出。
	///     例如：
	///     'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z
	///     M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z
	///     M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z
	///     M27.8,35.8
	///     c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
	/// </summary>
	[JsonProperty("symbol")]
	public string Symbol { get; set; }

	/// <summary>
	///     起点标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
	/// </summary>
	[JsonProperty("symbolSize")]
	public ArrayOrSingle SymbolSize { get; set; }

	/// <summary>
	///     起点标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
	/// </summary>
	[JsonProperty("symbolRotate")]
	public double? SymbolRotate { get; set; }

	/// <summary>
	///     如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
	/// </summary>
	[JsonProperty("symbolKeepAspect")]
	public bool? SymbolKeepAspect { get; set; }

	/// <summary>
	///     起点标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol
	///     相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
	///     例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
	/// </summary>
	[JsonProperty("symbolOffset")]
	public double[] SymbolOffset { get; set; }

	/// <summary>
	///     该数据项线的样式，起点和终点项的 lineStyle会合并到一起。
	/// </summary>
	[JsonProperty("lineStyle")]
	public LineStyle3 LineStyle { get; set; }

	/// <summary>
	///     该数据项标签的样式，起点和终点项的 label会合并到一起。
	/// </summary>
	[JsonProperty("label")]
	public Label4 Label { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("emphasis")]
	public Emphasis3 Emphasis { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	/// </summary>
	[JsonProperty("blur")]
	public Blur4 Blur { get; set; }
}