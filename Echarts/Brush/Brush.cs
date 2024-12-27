using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     brush 是区域选择组件，用户可以选择图中一部分数据，从而便于向用户展示被选中数据，或者他们的一些统计计算结果。
	///     刷子的类型和启动按钮
	///     目前 brush 组件支持的图表类型：scatter、bar、candlestick（parallel 本身自带刷选功能，但并非由 brush 组件来提供）。
	///     点击 toolbox 中的按钮，能够进行『区域选择』、『清除选择』等操作。
	///     横向刷子 的示例如下（点击 toolbox 中的按钮启动刷选）：
	///     bar 图中的 brush（点击 toolbox 中的按钮启动刷选）：
	///     启动 brush 的按钮既可以在 toolbox 中指定（参见 toolbox.feature.brush.type），也可以在 brush 组件的配置中指定（参见 brush.toolbox）。
	///     支持这几种选框：矩形刷子，任意形状刷子，横向刷子，纵向刷子。参见 brush.toolbox。
	///     可以使用 保持选择 按钮，切换单选和多选模式。
	///     单选即同时只能存在一个选框，可单击空白区域消除选框。
	///     多选即同时可存在多个选框，单击空白区域不能消除选框，需要点击『清除按钮』消除线框。
	///     刷选和坐标系的关系
	///     可以设置 brush 是『全局的』还是『属于坐标系的』。
	///     全局 brush
	///     在 echarts 实例中任意地方刷选。这是默认情况。如果没有指定为『坐标系 brush』，就是『全局 brush』。
	///     坐标系 brush
	///     在 指定的坐标系中刷选。选框可以跟随坐标系的缩放和平移（roam 和 dataZoom）而移动。
	///     坐标系 brush 实际更为常用，尤其是在 geo 中。
	///     通过指定 brush.geoIndex 或 brush.xAxisIndex 或 brush.yAxisIndex 来规定可以在哪些坐标系中进行刷选。
	///     这几个配置项的取值可以是：
	///     'all'，表示所有
	///     number，如 0，表示这个 index 所对应的坐标系。
	///     Array，如 [0, 4, 2]，表示指定这些 index 所对应的坐标系。
	///     'none' 或 null 或 undefined，表示不指定。
	///     例如：
	///     option = {
	///     geo: {
	///     ...
	///     },
	///     brush: {
	///     geoIndex: 'all', // 只可以在所有 geo 坐标系中刷选，也就是上面定义的 geo 组件中。
	///     ...
	///     }
	///     };
	///     例如：
	///     option = {
	///     grid: [
	///     {...}, // grid 0
	///     {...}  // grid 1
	///     ],
	///     xAxis: [
	///     {gridIndex: 1, ...}, // xAxis 0，属于 grid 1。
	///     {gridIndex: 0, ...}  // xAxis 1，属于 grid 0。
	///     ],
	///     yAxis: [
	///     {gridIndex: 1, ...}, // yAxis 0，属于 grid 1。
	///     {gridIndex: 0, ...}  // yAxis 1，属于 grid 0。
	///     ],
	///     brush: {
	///     xAxisIndex: [0, 1], // 只可以在 xAxisIndex 为 `0` 和 `1` 的 xAxis 所在的直角坐标系中刷选。
	///     ...
	///     }
	///     };
	///     使用 API 控制选框
	///     可以通过调用 dispatchAction 来用程序主动渲染选框，例如：
	///     myChart.dispatchAction({
	///     type: 'brush',
	///     areas: [
	///     {
	///     geoIndex: 0,
	///     // 指定选框的类型。
	///     brushType: 'polygon',
	///     // 指定选框的形状。
	///     coordRange: [[119.72,34.85],[119.68,34.85],[119.5,34.84],[119.19,34.77]]
	///     }
	///     ]
	///     });
	///     详情参见 action.brush
	///     brushLink
	///     不同系列间，选中的项可以联动。
	///     参见如下效果（刷选一个 scatter，其他 scatter 以及 parallel 图都会有选中效果）：
	///     brushLink 配置项是一个数组，内容是 seriesIndex，指定了哪些 series 可以被联动。例如可以是：
	///     [3, 4, 5] 表示 seriesIndex 为 3, 4, 5 的 series 可以被联动。
	///     'all' 表示所有 series 都进行 brushLink。
	///     'none' 或 null 或 undefined 表示不启用 brushLink 功能。
	///     注意
	///     brushLink 是通过 dataIndex 进行映射，所以需要保证，联动的每个系列的 data 都是 index 对应的。*
	///     例如：
	///     option = {
	///     brush: {
	///     brushLink: [0, 1]
	///     },
	///     series: [
	///     {
	///     type: 'bar'
	///     data: [232,    4434,    545,      654]     // data 有四个项
	///     },
	///     {
	///     type: 'parallel',
	///     data: [[4, 5], [3, 5], [66, 33], [99, 66]] // data 同样有四个项，两个系列的 data 是对应的。
	///     }
	///     ]
	///     };
	///     参见 brush.brushLink。
	///     throttle / debounce / 事件延迟
	///     默认情况，刷选或者移动选区的时候，会不断得发 brushSelected 事件，从而告诉外界选中的内容。
	///     但是频繁的事件可能导致性能问题，或者动画效果很差。所以 brush 组件提供了 brush.throttleType，brush.throttleDelay 来解决这个问题。
	///     throttleType 取值可以是：
	///     'debounce'：表示只有停止动作了（即一段时间没有操作了），才会触发事件。时间阈值由 brush.throttleDelay 指定。
	///     'fixRate'：表示按照一定的频率触发事件，时间间隔由 brush.throttleDelay 指定。
	///     被选中项和未被选中项的视觉设置
	///     参见 brush.inBrush 和 brush.outOfBrush。
	///     下面是详细配置。
	/// </summary>
	public class Brush
	{
		/// <summary>
		///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     使用在 toolbox 中的按钮。
		///     brush 相关的 toolbox 按钮有：
		///     'rect'：开启矩形选框选择功能。
		///     'polygon'：开启任意形状选框选择功能。
		///     'lineX'：开启横向选择功能。
		///     'lineY'：开启纵向选择功能。
		///     'keep'：切换『单选』和『多选』模式。后者可支持同时画多个选框。前者支持单击清除所有选框。
		///     'clear'：清空所有选框。
		/// </summary>
		[JsonProperty("toolbox")]
		public double[] Toolbox { get; set; }

		/// <summary>
		///     不同系列间，选中的项可以联动。
		///     参见如下效果（刷选一个 scatter，其他 scatter 以及 parallel 图都会有选中效果）：
		///     brushLink 配置项是一个数组，内容是 seriesIndex，指定了哪些 series 可以被联动。例如可以是：
		///     [3, 4, 5] 表示 seriesIndex 为 3, 4, 5 的 series 可以被联动。
		///     'all' 表示所有 series 都进行 brushLink。
		///     'none' 或 null 或 undefined 表示不启用 brushLink 功能。
		///     注意
		///     brushLink 是通过 dataIndex 进行映射，所以需要保证，联动的每个系列的 data 都是 index 对应的。*
		///     例如：
		///     option = {
		///     brush: {
		///     brushLink: [0, 1]
		///     },
		///     series: [
		///     {
		///     type: 'bar'
		///     data: [232,    4434,    545,      654]     // data 有四个项
		///     },
		///     {
		///     type: 'parallel',
		///     data: [[4, 5], [3, 5], [66, 33], [99, 66]] // data 同样有四个项，两个系列的 data 是对应的。
		///     }
		///     ]
		///     };
		/// </summary>
		[JsonProperty("brushLink")]
		public ArrayOrSingle BrushLink { get; set; }

		/// <summary>
		///     指定哪些 series 可以被刷选，可取值为：
		///     'all': 所有 series
		///     'Array': series index 列表
		///     'number': 某个 series index
		/// </summary>
		[JsonProperty("seriesIndex")]
		public StringOrNumber[] SeriesIndex { get; set; }

		/// <summary>
		///     指定哪些 geo 可以被刷选。
		///     可以设置 brush 是『全局的』还是『属于坐标系的』。
		///     全局 brush
		///     在 echarts 实例中任意地方刷选。这是默认情况。如果没有指定为『坐标系 brush』，就是『全局 brush』。
		///     坐标系 brush
		///     在 指定的坐标系中刷选。选框可以跟随坐标系的缩放和平移（roam 和 dataZoom）而移动。
		///     坐标系 brush 实际更为常用，尤其是在 geo 中。
		///     通过指定 brush.geoIndex 或 brush.xAxisIndex 或 brush.yAxisIndex 来规定可以在哪些坐标系中进行刷选。
		///     这几个配置项的取值可以是：
		///     'all'，表示所有
		///     number，如 0，表示这个 index 所对应的坐标系。
		///     Array，如 [0, 4, 2]，表示指定这些 index 所对应的坐标系。
		///     'none' 或 null 或 undefined，表示不指定。
		///     例如：
		///     option = {
		///     geo: {
		///     ...
		///     },
		///     brush: {
		///     geoIndex: 'all', // 只可以在所有 geo 坐标系中刷选，也就是上面定义的 geo 组件中。
		///     ...
		///     }
		///     };
		///     例如：
		///     option = {
		///     grid: [
		///     {...}, // grid 0
		///     {...}  // grid 1
		///     ],
		///     xAxis: [
		///     {gridIndex: 1, ...}, // xAxis 0，属于 grid 1。
		///     {gridIndex: 0, ...}  // xAxis 1，属于 grid 0。
		///     ],
		///     yAxis: [
		///     {gridIndex: 1, ...}, // yAxis 0，属于 grid 1。
		///     {gridIndex: 0, ...}  // yAxis 1，属于 grid 0。
		///     ],
		///     brush: {
		///     xAxisIndex: [0, 1], // 只可以在 xAxisIndex 为 `0` 和 `1` 的 xAxis 所在的直角坐标系中刷选。
		///     ...
		///     }
		///     };
		/// </summary>
		[JsonProperty("geoIndex")]
		public StringOrNumber[] GeoIndex { get; set; }

		/// <summary>
		///     指定哪些 xAxisIndex 可以被刷选。
		///     可以设置 brush 是『全局的』还是『属于坐标系的』。
		///     全局 brush
		///     在 echarts 实例中任意地方刷选。这是默认情况。如果没有指定为『坐标系 brush』，就是『全局 brush』。
		///     坐标系 brush
		///     在 指定的坐标系中刷选。选框可以跟随坐标系的缩放和平移（roam 和 dataZoom）而移动。
		///     坐标系 brush 实际更为常用，尤其是在 geo 中。
		///     通过指定 brush.geoIndex 或 brush.xAxisIndex 或 brush.yAxisIndex 来规定可以在哪些坐标系中进行刷选。
		///     这几个配置项的取值可以是：
		///     'all'，表示所有
		///     number，如 0，表示这个 index 所对应的坐标系。
		///     Array，如 [0, 4, 2]，表示指定这些 index 所对应的坐标系。
		///     'none' 或 null 或 undefined，表示不指定。
		///     例如：
		///     option = {
		///     geo: {
		///     ...
		///     },
		///     brush: {
		///     geoIndex: 'all', // 只可以在所有 geo 坐标系中刷选，也就是上面定义的 geo 组件中。
		///     ...
		///     }
		///     };
		///     例如：
		///     option = {
		///     grid: [
		///     {...}, // grid 0
		///     {...}  // grid 1
		///     ],
		///     xAxis: [
		///     {gridIndex: 1, ...}, // xAxis 0，属于 grid 1。
		///     {gridIndex: 0, ...}  // xAxis 1，属于 grid 0。
		///     ],
		///     yAxis: [
		///     {gridIndex: 1, ...}, // yAxis 0，属于 grid 1。
		///     {gridIndex: 0, ...}  // yAxis 1，属于 grid 0。
		///     ],
		///     brush: {
		///     xAxisIndex: [0, 1], // 只可以在 xAxisIndex 为 `0` 和 `1` 的 xAxis 所在的直角坐标系中刷选。
		///     ...
		///     }
		///     };
		/// </summary>
		[JsonProperty("xAxisIndex")]
		public StringOrNumber[] XAxisIndex { get; set; }

		/// <summary>
		///     指定哪些 yAxisIndex 可以被刷选。
		///     可以设置 brush 是『全局的』还是『属于坐标系的』。
		///     全局 brush
		///     在 echarts 实例中任意地方刷选。这是默认情况。如果没有指定为『坐标系 brush』，就是『全局 brush』。
		///     坐标系 brush
		///     在 指定的坐标系中刷选。选框可以跟随坐标系的缩放和平移（roam 和 dataZoom）而移动。
		///     坐标系 brush 实际更为常用，尤其是在 geo 中。
		///     通过指定 brush.geoIndex 或 brush.xAxisIndex 或 brush.yAxisIndex 来规定可以在哪些坐标系中进行刷选。
		///     这几个配置项的取值可以是：
		///     'all'，表示所有
		///     number，如 0，表示这个 index 所对应的坐标系。
		///     Array，如 [0, 4, 2]，表示指定这些 index 所对应的坐标系。
		///     'none' 或 null 或 undefined，表示不指定。
		///     例如：
		///     option = {
		///     geo: {
		///     ...
		///     },
		///     brush: {
		///     geoIndex: 'all', // 只可以在所有 geo 坐标系中刷选，也就是上面定义的 geo 组件中。
		///     ...
		///     }
		///     };
		///     例如：
		///     option = {
		///     grid: [
		///     {...}, // grid 0
		///     {...}  // grid 1
		///     ],
		///     xAxis: [
		///     {gridIndex: 1, ...}, // xAxis 0，属于 grid 1。
		///     {gridIndex: 0, ...}  // xAxis 1，属于 grid 0。
		///     ],
		///     yAxis: [
		///     {gridIndex: 1, ...}, // yAxis 0，属于 grid 1。
		///     {gridIndex: 0, ...}  // yAxis 1，属于 grid 0。
		///     ],
		///     brush: {
		///     xAxisIndex: [0, 1], // 只可以在 xAxisIndex 为 `0` 和 `1` 的 xAxis 所在的直角坐标系中刷选。
		///     ...
		///     }
		///     };
		/// </summary>
		[JsonProperty("yAxisIndex")]
		public StringOrNumber[] YAxisIndex { get; set; }

		/// <summary>
		///     默认的刷子类型。
		///     'rect'：矩形选框。
		///     'polygon'：任意形状选框。
		///     'lineX'：横向选择。
		///     'lineY'：纵向选择。
		/// </summary>
		[JsonProperty("brushType")]
		public string BrushType { get; set; }

		/// <summary>
		///     默认的刷子的模式。可取值为：
		///     'single'：单选。
		///     'multiple'：多选。
		/// </summary>
		[JsonProperty("brushMode")]
		public string BrushMode { get; set; }

		/// <summary>
		///     已经选好的选框是否可以被调整形状或平移。
		/// </summary>
		[JsonProperty("transformable")]
		public bool? Transformable { get; set; }

		/// <summary>
		///     选框的默认样式，值为：
		///     {
		///     borderWidth: 1,
		///     color: 'rgba(120,140,180,0.3)',
		///     borderColor: 'rgba(120,140,180,0.8)'
		///     },
		/// </summary>
		[JsonProperty("brushStyle")]
		public object BrushStyle { get; set; }

		/// <summary>
		///     默认情况，刷选或者移动选区的时候，会不断得发 brushSelected 事件，从而告诉外界选中的内容。
		///     但是频繁的事件可能导致性能问题，或者动画效果很差。所以 brush 组件提供了 brush.throttleType，brush.throttleDelay 来解决这个问题。
		///     throttleType 取值可以是：
		///     'debounce'：表示只有停止动作了（即一段时间没有操作了），才会触发事件。时间阈值由 brush.throttleDelay 指定。
		///     'fixRate'：表示按照一定的频率触发事件，时间间隔由 brush.throttleDelay 指定。
		/// </summary>
		[JsonProperty("throttleType")]
		public string ThrottleType { get; set; }

		/// <summary>
		///     默认为 0 表示不开启 throttle。
		///     默认情况，刷选或者移动选区的时候，会不断得发 brushSelected 事件，从而告诉外界选中的内容。
		///     但是频繁的事件可能导致性能问题，或者动画效果很差。所以 brush 组件提供了 brush.throttleType，brush.throttleDelay 来解决这个问题。
		///     throttleType 取值可以是：
		///     'debounce'：表示只有停止动作了（即一段时间没有操作了），才会触发事件。时间阈值由 brush.throttleDelay 指定。
		///     'fixRate'：表示按照一定的频率触发事件，时间间隔由 brush.throttleDelay 指定。
		/// </summary>
		[JsonProperty("throttleDelay")]
		public double? ThrottleDelay { get; set; }

		/// <summary>
		///     在 brush.brushMode 为 'single' 的情况下，是否支持『单击清除所有选框』。
		/// </summary>
		[JsonProperty("removeOnClick")]
		public bool? RemoveOnClick { get; set; }

		/// <summary>
		///     定义 在选中范围中 的视觉元素。
		///     可选的视觉元素有：
		///     symbol: 图元的图形类别。
		///     symbolSize: 图元的大小。
		///     color: 图元的颜色。
		///     colorAlpha: 图元的颜色的透明度。
		///     opacity: 图元以及其附属物（如文字标签）的透明度。
		///     colorLightness: 颜色的明暗度，参见 HSL。
		///     colorSaturation: 颜色的饱和度，参见 HSL。
		///     colorHue: 颜色的色调，参见 HSL。
		///     大多数情况下，inBrush 可以不指定，维持本来的视觉配置。
		/// </summary>
		[JsonProperty("inBrush")]
		public object InBrush { get; set; }

		/// <summary>
		///     定义 在选中范围外 的视觉元素。
		///     可选的视觉元素有：
		///     symbol: 图元的图形类别。
		///     symbolSize: 图元的大小。
		///     color: 图元的颜色。
		///     colorAlpha: 图元的颜色的透明度。
		///     opacity: 图元以及其附属物（如文字标签）的透明度。
		///     colorLightness: 颜色的明暗度，参见 HSL。
		///     colorSaturation: 颜色的饱和度，参见 HSL。
		///     colorHue: 颜色的色调，参见 HSL。
		///     注意，如果 outOfBrush 没有指定，默认会设置 color: '#ddd'，如果你不想要这个color，比如可以
		///     换成：
		///     brush: {
		///     ...,
		///     outOfBrush: {
		///     colorAlpha: 0.1
		///     }
		///     }
		/// </summary>
		[JsonProperty("outOfBrush")]
		public object OutOfBrush { get; set; }

		/// <summary>
		///     brush 选框的 z-index。当有和不相关组件有不正确的重叠时，可以进行调整。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }
	}
}