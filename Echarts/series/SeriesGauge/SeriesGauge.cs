using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     仪表盘
///     示例：
/// </summary>
public class SeriesGauge
{
	/// <summary>
	/// </summary>
	[JsonProperty("type")]
	public string Type { get; set; } = "gauge";

	/// <summary>
	///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	///     系列名称，用于tooltip的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	///     从 v5.2.0 开始支持
	///     从调色盘 option.color 中取色的策略，可取值为：
	///     'series'：按照系列分配调色盘中的颜色，同一系列中的所有数据都是用相同的颜色；
	///     'data'：按照数据项分配调色盘中的颜色，每个数据项都使用不同的颜色。
	/// </summary>
	[JsonProperty("colorBy")]
	public string ColorBy { get; set; }

	/// <summary>
	///     所有图形的 zlevel 值。
	///     zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的
	///     Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
	///     zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
	/// </summary>
	[JsonProperty("zlevel")]
	public double? Zlevel { get; set; }

	/// <summary>
	///     组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
	///     z相比zlevel优先级更低，而且不会创建新的 Canvas。
	/// </summary>
	[JsonProperty("z")]
	public double? Z { get; set; }

	/// <summary>
	///     的中心（圆心）坐标，数组的第一项是横坐标，第二项是纵坐标。
	///     支持设置成百分比，设置成百分比时第一项是相对于容器宽度，第二项是相对于容器高度。
	///     使用示例：
	///     // 设置成绝对的像素值
	///     center: [400, 300]
	///     // 设置成相对的百分比
	///     center: ['50%', '50%']
	/// </summary>
	[JsonProperty("center")]
	public ArrayOrSingle Center { get; set; }

	/// <summary>
	///     仪表盘半径，可以是相对于容器高宽中较小的一项的一半的百分比，也可以是绝对的数值。
	/// </summary>
	[JsonProperty("radius")]
	public StringOrNumber Radius { get; set; }

	/// <summary>
	///     是否启用图例 hover 时的联动高亮。
	/// </summary>
	[JsonProperty("legendHoverLink")]
	public bool? LegendHoverLink { get; set; }

	/// <summary>
	///     仪表盘起始角度。圆心 正右手侧为0度，正上方为90度，正左手侧为180度。
	/// </summary>
	[JsonProperty("startAngle")]
	public double? StartAngle { get; set; }

	/// <summary>
	///     仪表盘结束角度。
	/// </summary>
	[JsonProperty("endAngle")]
	public double? EndAngle { get; set; }

	/// <summary>
	///     仪表盘刻度是否是顺时针增长。
	/// </summary>
	[JsonProperty("clockwise")]
	public bool? Clockwise { get; set; }

	/// <summary>
	///     系列中的数据内容数组。数组项可以为单个数值，如：
	///     [12, 34, 56, 10, 23]
	///     如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
	///     [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
	///     这时候可以将每项数组中的第二个值指定给 visualMap 组件。
	///     更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	///     [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值8
	///     value: 10
	///     }, {
	///     name: '数据2',
	///     value: 20
	///     }]
	///     需要对个别内容指定进行个性化定义时：
	///     [{
	///     name: '数据1',
	///     value: 10
	///     }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : 56,
	///     //自定义特殊 tooltip，仅对该数据项有效
	///     tooltip:{},
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	///     }]
	/// </summary>
	[JsonProperty("data")]
	[JsonConverter(typeof(SingleOrArrayConverter<SeriesGauge_Data>))]
	public List<SeriesGauge_Data> Data { get; set; }

	/// <summary>
	///     最小的数据值，映射到 minAngle。
	/// </summary>
	[JsonProperty("min")]
	public double? Min { get; set; }

	/// <summary>
	///     最大的数据值，映射到 maxAngle。
	/// </summary>
	[JsonProperty("max")]
	public double? Max { get; set; }

	/// <summary>
	///     仪表盘刻度的分割段数。
	/// </summary>
	[JsonProperty("splitNumber")]
	public double? SplitNumber { get; set; }

	/// <summary>
	///     仪表盘轴线相关配置。
	/// </summary>
	[JsonProperty("axisLine")]
	public SeriesGauge_AxisLine AxisLine { get; set; }

	/// <summary>
	///     从 v5.0 开始支持
	///     展示当前进度。
	/// </summary>
	[JsonProperty("progress")]
	public SeriesGauge_Progress Progress { get; set; }

	/// <summary>
	///     分隔线样式。
	/// </summary>
	[JsonProperty("splitLine")]
	public SeriesGauge_SplitLine SplitLine { get; set; }

	/// <summary>
	///     刻度样式。
	/// </summary>
	[JsonProperty("axisTick")]
	public SeriesGauge_AxisTick AxisTick { get; set; }

	/// <summary>
	///     刻度标签。
	/// </summary>
	[JsonProperty("axisLabel")]
	public SeriesGauge_AxisLabel AxisLabel { get; set; }

	/// <summary>
	///     仪表盘指针。
	/// </summary>
	[JsonProperty("pointer")]
	public SeriesGauge_Pointer Pointer { get; set; }

	/// <summary>
	///     从 v5.0 开始支持
	///     表盘中指针的固定点。
	/// </summary>
	[JsonProperty("anchor")]
	public SeriesGauge_Anchor Anchor { get; set; }

	/// <summary>
	///     仪表盘指针样式。
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle0 ItemStyle { get; set; }

	/// <summary>
	///     高亮的仪表盘指针样式
	/// </summary>
	[JsonProperty("emphasis")]
	public Select8 Emphasis { get; set; }

	/// <summary>
	///     仪表盘标题。
	/// </summary>
	[JsonProperty("title")]
	public SeriesGauge_Title Title { get; set; }

	/// <summary>
	///     仪表盘详情，用于显示数据。
	/// </summary>
	[JsonProperty("detail")]
	public SeriesGauge_Detail Detail { get; set; }

	/// <summary>
	///     图表标注。
	/// </summary>
	[JsonProperty("markPoint")]
	public SeriesGauge_MarkPoint MarkPoint { get; set; }

	/// <summary>
	///     图表标线。
	/// </summary>
	[JsonProperty("markLine")]
	public SeriesPie_MarkLine MarkLine { get; set; }

	/// <summary>
	///     图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
	/// </summary>
	[JsonProperty("markArea")]
	public SeriesPie_MarkArea MarkArea { get; set; }

	/// <summary>
	///     图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
	/// </summary>
	[JsonProperty("silent")]
	public bool? Silent { get; set; }

	/// <summary>
	///     是否开启动画。
	/// </summary>
	[JsonProperty("animation")]
	public bool? Animation { get; set; }

	/// <summary>
	///     是否开启动画的阈值，当单个系列显示的图形数量大于这个阈值时会关闭动画。
	/// </summary>
	[JsonProperty("animationThreshold")]
	public double? AnimationThreshold { get; set; }

	/// <summary>
	///     初始动画的时长，支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的初始动画效果：
	///     animationDuration: function (idx) {
	///     // 越往后的数据时长越大
	///     return idx * 100;
	///     }
	/// </summary>
	[JsonProperty("animationDuration")]
	public StringOrNumber AnimationDuration { get; set; }

	/// <summary>
	///     初始动画的缓动效果。不同的缓动效果可以参考 缓动示例。
	/// </summary>
	[JsonProperty("animationEasing")]
	public string AnimationEasing { get; set; }

	/// <summary>
	///     初始动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的初始动画效果。
	///     如下示例：
	///     animationDelay: function (idx) {
	///     // 越往后的数据延迟越大
	///     return idx * 100;
	///     }
	///     也可以看该示例
	/// </summary>
	[JsonProperty("animationDelay")]
	public StringOrNumber AnimationDelay { get; set; }

	/// <summary>
	///     数据更新动画的时长。
	///     支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的更新动画效果：
	///     animationDurationUpdate: function (idx) {
	///     // 越往后的数据时长越大
	///     return idx * 100;
	///     }
	/// </summary>
	[JsonProperty("animationDurationUpdate")]
	public StringOrNumber AnimationDurationUpdate { get; set; }

	/// <summary>
	///     数据更新动画的缓动效果。
	/// </summary>
	[JsonProperty("animationEasingUpdate")]
	public string AnimationEasingUpdate { get; set; }

	/// <summary>
	///     数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
	///     如下示例：
	///     animationDelayUpdate: function (idx) {
	///     // 越往后的数据延迟越大
	///     return idx * 100;
	///     }
	///     也可以看该示例
	/// </summary>
	[JsonProperty("animationDelayUpdate")]
	public StringOrNumber AnimationDelayUpdate { get; set; }

	/// <summary>
	///     本系列特定的 tooltip 设定。
	/// </summary>
	[JsonProperty("tooltip")]
	public Tooltip1 Tooltip { get; set; }
}