using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     custom 系列需要开发者自己提供图形渲染的逻辑。这个渲染逻辑一般命名为 renderItem。例如：
///     var option = {
///     ...,
///     series: [{
///     type: 'custom',
///     renderItem: function (params, api) {
///     var categoryIndex = api.value(0);
///     var start = api.coord([api.value(1), categoryIndex]);
///     var end = api.coord([api.value(2), categoryIndex]);
///     var height = api.size([0, 1])[1] * 0.6;
///     var rectShape = echarts.graphic.clipRectByRect({
///     x: start[0],
///     y: start[1] - height / 2,
///     width: end[0] - start[0],
///     height: height
///     }, {
///     x: params.coordSys.x,
///     y: params.coordSys.y,
///     width: params.coordSys.width,
///     height: params.coordSys.height
///     });
///     return rectShape && {
///     type: 'rect',
///     shape: rectShape,
///     style: api.style()
///     };
///     },
///     data: data
///     }]
///     }
///     对于 data 中的每个数据项（为方便描述，这里称为 dataItem)，会调用此 renderItem 函数。
///     renderItem 函数提供了两个参数：
///     params：包含了当前数据信息和坐标系的信息。
///     api：是一些开发者可调用的方法集合。
///     renderItem 函数须返回根据此 dataItem 绘制出的图形元素的定义信息，参见 renderItem.return。
///     一般来说，renderItem 函数的主要逻辑，是将 dataItem 里的值映射到坐标系上的图形元素。这一般需要用到 renderItem.arguments.api 中的两个函数：
///     api.value(...)，意思是取出 dataItem 中的数值。例如 api.value(0) 表示取出当前 dataItem 中第一个维度的数值。
///     api.coord(...)，意思是进行坐标转换计算。例如 var point = api.coord([api.value(0), api.value(1)]) 表示 dataItem 中的数值转换成坐标系上的点。
///     有时候还需要用到 api.size(...) 函数，表示得到坐标系上一段数值范围对应的长度。
///     返回值中样式的设置可以使用 api.style(...) 函数，他能得到 series.itemStyle 中定义的样式信息，以及视觉映射的样式信息。也可以用这种方式覆盖这些样式信息：api.style({fill:
///     'green', stroke: 'yellow'})。
/// </summary>
public class SeriesCustom_RenderItem
{
	/// <summary>
	///     renderItem 函数的参数。
	/// </summary>
	[JsonProperty("arguments")]
	public SeriesCustom_RenderItem_Arguments Arguments { get; set; }

	/// <summary>
	///     图形元素。每个图形元素是一个 object。详细信息参见：graphic。（width\height\top\bottom 不支持）
	///     如果什么都不渲染，可以不返回任何东西。
	///     例如：
	///     // 单独一个矩形
	///     {
	///     type: 'rect',
	///     shape: {
	///     x: x, y: y, width: width, height: height
	///     },
	///     style: api.style()
	///     }
	///     // 一组图形元素
	///     {
	///     type: 'group',
	///     // 如果 diffChildrenByName 设为 true，则会使用 child.name 进行 diff，
	///     // 从而能有更好的过度动画，但是降低性能。缺省为 false。
	///     // diffChildrenByName: true,
	///     children: [{
	///     type: 'circle',
	///     shape: {
	///     cx: cx, cy: cy, r: r
	///     },
	///     style: api.style()
	///     }, {
	///     type: 'line',
	///     shape: {
	///     x1: x1, y1: y1, x2: x2, y2: y2
	///     },
	///     style: api.style()
	///     }]
	///     }
	/// </summary>
	[JsonProperty("return")]
	public object Return { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_group")]
	public SeriesCustom_RenderItem_ReturnGroup ReturnGroup { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_path")]
	public SeriesCustom_RenderItem_ReturnPath ReturnPath { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_image")]
	public SeriesCustom_RenderItem_ReturnImage ReturnImage { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_text")]
	public SeriesCustom_RenderItem_ReturnText ReturnText { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_rect")]
	public SeriesCustom_RenderItem_ReturnRect ReturnRect { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_circle")]
	public SeriesCustom_RenderItem_ReturnCircle ReturnCircle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_ring")]
	public SeriesCustom_RenderItem_ReturnRing ReturnRing { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_sector")]
	public SeriesCustom_RenderItem_ReturnSector ReturnSector { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_arc")]
	public SeriesCustom_RenderItem_ReturnSector ReturnArc { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_polygon")]
	public SeriesCustom_RenderItem_ReturnPolygon ReturnPolygon { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_polyline")]
	public SeriesCustom_RenderItem_ReturnPolygon ReturnPolyline { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_line")]
	public SeriesCustom_RenderItem_ReturnLine ReturnLine { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("return_bezierCurve")]
	public SeriesCustom_RenderItem_ReturnBezierCurve ReturnBezierCurve { get; set; }
}