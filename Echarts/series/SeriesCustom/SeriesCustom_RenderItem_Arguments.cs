using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     renderItem 函数的参数。
/// </summary>
public class SeriesCustom_RenderItem_Arguments
{
	/// <summary>
	///     renderItem 函数的第一个参数，含有：
	///     {
	///     context: // {Object} 一个可供开发者暂存东西的对象。生命周期只为：当前次的渲染。
	///     seriesId: // {string} 本系列 id。
	///     seriesName: // {string} 本系列 name。
	///     seriesIndex: // {number} 本系列 index。
	///     dataIndex: // {number} 数据项的 index。
	///     dataIndexInside: // {number} 数据项在当前坐标系中可见的数据的 index（即 dataZoom 当前窗口中的数据的 index）。
	///     dataInsideLength: // {number} 当前坐标系中可见的数据长度（即 dataZoom 当前窗口中的数据数量）。
	///     actionType: // {string} 触发此次重绘的 action 的 type。
	///     coordSys: // 不同的坐标系中，coordSys 里的信息不一样，含有如下这些可能：
	///     coordSys: {
	///     type: 'cartesian2d',
	///     x: // {number} grid rect 的 x
	///     y: // {number} grid rect 的 y
	///     width: // {number} grid rect 的 width
	///     height: // {number} grid rect 的 height
	///     },
	///     coordSys: {
	///     type: 'calendar',
	///     x: // {number} calendar rect 的 x
	///     y: // {number} calendar rect 的 y
	///     width: // {number} calendar rect 的 width
	///     height: // {number} calendar rect 的 height
	///     cellWidth: // {number} calendar cellWidth
	///     cellHeight: // {number} calendar cellHeight
	///     rangeInfo: {
	///     start: // calendar 日期开端
	///     end: // calendar 日期结尾
	///     weeks: // calendar 周数
	///     dayCount: // calendar 日数
	///     }
	///     },
	///     coordSys: {
	///     type: 'geo',
	///     x: // {number} geo rect 的 x
	///     y: // {number} geo rect 的 y
	///     width: // {number} geo rect 的 width
	///     height: // {number} geo rect 的 height
	///     zoom: // {number} 缩放的比率。如果没有缩放，则值为 1。例如 0.5 表示缩小了一半。
	///     },
	///     coordSys: {
	///     type: 'polar',
	///     cx: // {number} polar 的中心坐标
	///     cy: // {number} polar 的中心坐标
	///     r: // {number} polar 的外半径
	///     r0: // {number} polar 的内半径
	///     },
	///     coordSys: {
	///     type: 'singleAxis',
	///     x: // {number} singleAxis rect 的 x
	///     y: // {number} singleAxis rect 的 y
	///     width: // {number} singleAxis rect 的 width
	///     height: // {number} singleAxis rect 的 height
	///     }
	///     }
	///     其中，关于 dataIndex 和 dataIndexInside 的区别：
	///     dataIndex 指的 dataItem 在原始数据中的 index。
	///     dataIndexInside 指的是 dataItem 在当前数据窗口（参见 dataZoom）中的 index。
	///     renderItem.arguments.api 中使用的参数都是 dataIndexInside 而非 dataIndex，因为从 dataIndex 转换成 dataIndexInside 需要时间开销。
	/// </summary>
	[JsonProperty("params")]
	public object Params { get; set; }

	/// <summary>
	///     renderItem 函数的第二个参数。
	/// </summary>
	[JsonProperty("api")]
	public SeriesCustom_RenderItem_Arguments_Api Api { get; set; }
}