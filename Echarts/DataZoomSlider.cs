using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 滑动条型数据区域缩放组件（dataZoomInside）
	/// 滑动条型数据区域缩放组件提供了数据缩略图显示，缩放，刷选，拖拽，点击快速定位等数据筛选的功能。下图显示了该组件可交互部分
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class DataZoomSlider
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "slider";

		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 是否显示  组件。如果设置为 false，不会显示，但是数据过滤的功能还存在。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 组件的背景颜色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 数据阴影的样式。
		/// </summary>
		[JsonProperty("dataBackground")]
		public DataZoomSlider_DataBackground DataBackground { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 选中部分数据阴影的样式。
		/// </summary>
		[JsonProperty("selectedDataBackground")]
		public DataZoomSlider_DataBackground SelectedDataBackground { get; set; }

		/// <summary>
		/// 选中范围的填充颜色。
		/// </summary>
		[JsonProperty("fillerColor")]
		public Color FillerColor { get; set; }

		/// <summary>
		/// 边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 圆角半径，单位px，支持传入数组分别指定 4 个圆角半径。
		/// 如:
		/// borderRadius: 5, // 统一设置四个角的圆角大小
		/// borderRadius: [5, 5, 0, 0] //（顺时针左上，右上，右下，左下）
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 两侧缩放手柄的 icon 形状，支持路径字符串，默认为：
		/// 'M-9.35,34.56V42m0-40V9.5m-2,0h4a2,2,0,0,1,2,2v21a2,2,0,0,1-2,2h-4a2,2,0,0,1-2-2v-21A2,2,0,0,1-11.35,9.5Z'
		/// 
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("handleIcon")]
		public string HandleIcon { get; set; }

		/// <summary>
		/// 控制手柄的尺寸，可以是像素大小，也可以是相对于 dataZoom 组件宽度的百分比，默认跟 dataZoom 宽度相同。
		/// </summary>
		[JsonProperty("handleSize")]
		public StringOrNumber HandleSize { get; set; }

		/// <summary>
		/// 两侧缩放手柄的样式配置。
		/// </summary>
		[JsonProperty("handleStyle")]
		public HandleStyle0 HandleStyle { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 移动手柄中间的 icon，支持路径字符串，默认为：
		/// 'M-320.9-50L-320.9-50c18.1,0,27.1,9,27.1,27.1V85.7c0,18.1-9,27.1-27.1,27.1l0,0c-18.1,0-27.1-9-27.1-27.1V-22.9C-348-41-339-50-320.9-50z M-212.3-50L-212.3-50c18.1,0,27.1,9,27.1,27.1V85.7c0,18.1-9,27.1-27.1,27.1l0,0c-18.1,0-27.1-9-27.1-27.1V-22.9C-239.4-41-230.4-50-212.3-50z M-103.7-50L-103.7-50c18.1,0,27.1,9,27.1,27.1V85.7c0,18.1-9,27.1-27.1,27.1l0,0c-18.1,0-27.1-9-27.1-27.1V-22.9C-130.9-41-121.8-50-103.7-50z'
		/// 
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("moveHandleIcon")]
		public string MoveHandleIcon { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 移动手柄的尺寸高度。
		/// </summary>
		[JsonProperty("moveHandleSize")]
		public double? MoveHandleSize { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 移动手柄的样式配置。
		/// </summary>
		[JsonProperty("moveHandleStyle")]
		public HandleStyle0 MoveHandleStyle { get; set; }

		/// <summary>
		/// 显示label的小数精度。默认根据数据自动决定。
		/// </summary>
		[JsonProperty("labelPrecision")]
		public StringOrNumber LabelPrecision { get; set; }

		/// <summary>
		/// 显示的label的格式化器。
		/// 
		/// 如果为 string，表示模板，例如：aaaa{value}bbbb，其中{value}会被替换为实际的数值。
		/// 
		/// 如果为 Function，表示回调函数，例如：
		/// 
		/// 
		/// /**
		///  * @param {*} value 如果 axis.type 为 'category'，则 `value` 为 axis.data 的 index。
		///  *                  否则 `value` 是当前值。
		///  * @param {strign} valueStr 内部格式化的结果。
		///  * @return {string} 返回最终的label内容。
		///  */
		/// labelFormatter: function (value) {
		///     return 'aaa' + value + 'bbb';
		/// }
		/// </summary>
		[JsonProperty("labelFormatter")]
		public string LabelFormatter { get; set; }

		/// <summary>
		/// 是否显示detail，即拖拽时候显示详细数值信息。
		/// </summary>
		[JsonProperty("showDetail")]
		public bool? ShowDetail { get; set; }

		/// <summary>
		/// 是否在 dataZoom-silder 组件中显示数据阴影。数据阴影可以简单地反应数据走势。
		/// </summary>
		[JsonProperty("showDataShadow")]
		public string ShowDataShadow { get; set; }

		/// <summary>
		/// 拖动时，是否实时更新系列的视图。如果设置为 false，则只在拖拽结束的时候更新。
		/// </summary>
		[JsonProperty("realtime")]
		public bool? Realtime { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textStyle")]
		public Legend_PageTextStyle TextStyle { get; set; }

		/// <summary>
		/// 设置 dataZoom-slider 组件控制的 x轴（即xAxis，是直角坐标系中的概念，参见 grid）。
		/// 不指定时，当 dataZoom-slider.orient 为 'horizontal'时，默认控制和 dataZoom 平行的第一个 xAxis。但是不建议使用默认值，建议显式指定。
		/// 如果是 number 表示控制一个轴，如果是 Array 表示控制多个轴。
		/// 例如有如下 ECharts option：
		/// option: {
		///     xAxis: [
		///         {...}, // 第一个 xAxis
		///         {...}, // 第二个 xAxis
		///         {...}, // 第三个 xAxis
		///         {...}  // 第四个 xAxis
		///     ],
		///     dataZoom: [
		///         { // 第一个 dataZoom 组件
		///             xAxisIndex: [0, 2] // 表示这个 dataZoom 组件控制 第一个 和 第三个 xAxis
		///         },
		///         { // 第二个 dataZoom 组件
		///             xAxisIndex: 3      // 表示这个 dataZoom 组件控制 第四个 xAxis
		///         }
		///     ]
		/// }
		/// </summary>
		[JsonProperty("xAxisIndex")]
		public ArrayOrSingle XAxisIndex { get; set; }

		/// <summary>
		/// 设置 dataZoom-slider 组件控制的 y轴（即yAxis，是直角坐标系中的概念，参见 grid）。
		/// 不指定时，当 dataZoom-slider.orient 为 'vertical'时，默认控制和 dataZoom 平行的第一个 yAxis。但是不建议使用默认值，建议显式指定。
		/// 如果是 number 表示控制一个轴，如果是 Array 表示控制多个轴。
		/// 例如有如下 ECharts option：
		/// option: {
		///     yAxis: [
		///         {...}, // 第一个 yAxis
		///         {...}, // 第二个 yAxis
		///         {...}, // 第三个 yAxis
		///         {...}  // 第四个 yAxis
		///     ],
		///     dataZoom: [
		///         { // 第一个 dataZoom 组件
		///             yAxisIndex: [0, 2] // 表示这个 dataZoom 组件控制 第一个 和 第三个 yAxis
		///         },
		///         { // 第二个 dataZoom 组件
		///             yAxisIndex: 3      // 表示这个 dataZoom 组件控制 第四个 yAxis
		///         }
		///     ]
		/// }
		/// </summary>
		[JsonProperty("yAxisIndex")]
		public ArrayOrSingle YAxisIndex { get; set; }

		/// <summary>
		/// 设置 dataZoom-slider 组件控制的 radius 轴（即radiusAxis，是直角坐标系中的概念，参见 polar）。
		/// 如果是 number 表示控制一个轴，如果是 Array 表示控制多个轴。
		/// 例如有如下 ECharts option：
		/// option: {
		///     radiusAxis: [
		///         {...}, // 第一个 radiusAxis
		///         {...}, // 第二个 radiusAxis
		///         {...}, // 第三个 radiusAxis
		///         {...}  // 第四个 radiusAxis
		///     ],
		///     dataZoom: [
		///         { // 第一个 dataZoom 组件
		///             radiusAxisIndex: [0, 2] // 表示这个 dataZoom 组件控制 第一个 和 第三个 radiusAxis
		///         },
		///         { // 第二个 dataZoom 组件
		///             radiusAxisIndex: 3      // 表示这个 dataZoom 组件控制 第四个 radiusAxis
		///         }
		///     ]
		/// }
		/// </summary>
		[JsonProperty("radiusAxisIndex")]
		public ArrayOrSingle RadiusAxisIndex { get; set; }

		/// <summary>
		/// 设置 dataZoom-slider 组件控制的 angle 轴（即angleAxis，是直角坐标系中的概念，参见 polar）。
		/// 如果是 number 表示控制一个轴，如果是 Array 表示控制多个轴。
		/// 例如有如下 ECharts option：
		/// option: {
		///     angleAxis: [
		///         {...}, // 第一个 angleAxis
		///         {...}, // 第二个 angleAxis
		///         {...}, // 第三个 angleAxis
		///         {...}  // 第四个 angleAxis
		///     ],
		///     dataZoom: [
		///         { // 第一个 dataZoom 组件
		///             angleAxisIndex: [0, 2] // 表示这个 dataZoom 组件控制 第一个 和 第三个 angleAxis
		///         },
		///         { // 第二个 dataZoom 组件
		///             angleAxisIndex: 3      // 表示这个 dataZoom 组件控制 第四个 angleAxis
		///         }
		///     ]
		/// }
		/// </summary>
		[JsonProperty("angleAxisIndex")]
		public ArrayOrSingle AngleAxisIndex { get; set; }

		/// <summary>
		/// dataZoom 的运行原理是通过 数据过滤 以及在内部设置轴的显示窗口来达到 数据窗口缩放 的效果。
		/// 数据过滤模式（dataZoom.filterMode）的设置不同，效果也不同。
		/// 可选值为：
		/// 
		/// 'filter'：当前数据窗口外的数据，被 过滤掉。即 会 影响其他轴的数据范围。每个数据项，只要有一个维度在数据窗口外，整个数据项就会被过滤掉。
		/// 
		/// 'weakFilter'：当前数据窗口外的数据，被 过滤掉。即 会 影响其他轴的数据范围。每个数据项，只有当全部维度都在数据窗口同侧外部，整个数据项才会被过滤掉。
		/// 
		/// 'empty'：当前数据窗口外的数据，被 设置为空。即 不会 影响其他轴的数据范围。
		/// 
		/// 'none': 不过滤数据，只改变数轴范围。
		/// 
		/// 
		/// 如何设置，由用户根据场景和需求自己决定。经验来说：
		/// 
		/// 当『只有 X 轴 或 只有 Y 轴受 dataZoom 组件控制』时，常使用 filterMode: 'filter'，这样能使另一个轴自适应过滤后的数值范围。
		/// 
		/// 当『X 轴 Y 轴分别受 dataZoom 组件控制』时：
		/// 
		/// 如果 X 轴和 Y 轴是『同等地位的、不应互相影响的』，比如在『双数值轴散点图』中，那么两个轴可都设为 filterMode: 'empty'。
		/// 
		/// 如果 X 轴为主，Y 轴为辅，比如在『柱状图』中，需要『拖动 dataZoomX 改变 X 轴过滤柱子时，Y 轴的范围也自适应剩余柱子的高度』，『拖动 dataZoomY 改变 Y 轴过滤柱子时，X 轴范围不受影响』，那么就 X轴设为 filterMode: 'filter'，Y 轴设为 filterMode: 'empty'，即主轴 'filter'，辅轴 'empty'。
		/// 
		/// 
		/// 
		/// 
		/// 下面是个具体例子：
		/// option = {
		///     dataZoom: [
		///         {
		///             id: 'dataZoomX',
		///             type: 'slider',
		///             xAxisIndex: [0],
		///             filterMode: 'filter'
		///         },
		///         {
		///             id: 'dataZoomY',
		///             type: 'slider',
		///             yAxisIndex: [0],
		///             filterMode: 'empty'
		///         }
		///     ],
		///     xAxis: {type: 'value'},
		///     yAxis: {type: 'value'},
		///     series{
		///         type: 'bar',
		///         data: [
		///             // 第一列对应 X 轴，第二列对应 Y 轴。
		///             [12, 24, 36],
		///             [90, 80, 70],
		///             [3, 9, 27],
		///             [1, 11, 111]
		///         ]
		///     }
		/// }
		/// 
		/// 上例中，dataZoomX 的 filterMode 设置为 'filter'。于是，假设当用户拖拽 dataZoomX（不去动 dataZoomY）导致其 valueWindow 变为 [2, 50] 时，dataZoomX 对 series.data 的第一列进行遍历，窗口外的整项去掉，最终得到的 series.data 为：
		/// [
		///     // 第一列对应 X 轴，第二列对应 Y 轴。
		///     [12, 24, 36],
		///     // [90, 80, 70] 整项被过滤掉，因为 90 在 dataWindow 之外。
		///     [3, 9, 27]
		///     // [1, 11, 111] 整项被过滤掉，因为 1 在 dataWindow 之外。
		/// ]
		/// 
		/// 过滤前，series.data 中对应 Y 轴的值有 24、80、9、11，过滤后，只剩下 24 和 9，那么 Y 轴的显示范围就会自动改变以适应剩下的这两个值的显示（如果 Y 轴没有被设置 min、max 固定其显示范围的话）。
		/// 所以，filterMode: 'filter' 的效果是：过滤数据后使另外的轴也能自动适应当前数据的范围。
		/// 再从头来，上例中 dataZoomY 的 filterMode 设置为 'empty'。于是，假设当用户拖拽 dataZoomY（不去动 dataZoomX）导致其 dataWindow 变为 [10, 60] 时，dataZoomY 对 series.data 的第二列进行遍历，窗口外的值被设置为 empty （即替换为 NaN，这样设置为空的项，其所对应柱形，在 X 轴还有占位，只是不显示出来）。最终得到的 series.data 为：
		/// [
		///     // 第一列对应 X 轴，第二列对应 Y 轴。
		///     [12, 24, 36],
		///     [90, NaN, 70], // 设置为 empty (NaN)
		///     [3, NaN, 27],  // 设置为 empty (NaN)
		///     [1, 11, 111]
		/// ]
		/// 
		/// 这时，series.data 中对应于 X 轴的值仍然全部保留不受影响，为 12、90、3、1。那么用户对 dataZoomY 的拖拽操作不会影响到 X 轴的范围。这样的效果，对于离群点（outlier）过滤功能，比较清晰。
		/// 如下面的例子：
		/// </summary>
		[JsonProperty("filterMode")]
		public string FilterMode { get; set; }

		/// <summary>
		/// 数据窗口范围的起始百分比。范围是：0 ~ 100。表示 0% ~ 100%。
		/// dataZoom-slider.start 和 dataZoom-slider.end 共同用 百分比 的形式定义了数据窗口范围。
		/// 关于坐标轴范围（axis extent）和 dataZoom-slider.start 的关系的更多信息，请参见：dataZoom-slider.rangeMode。
		/// </summary>
		[JsonProperty("start")]
		public double? Start { get; set; }

		/// <summary>
		/// 数据窗口范围的结束百分比。范围是：0 ~ 100。
		/// dataZoom-slider.start 和 dataZoom-slider.end 共同用 百分比 的形式定义了数据窗口范围。
		/// 关于坐标轴范围（axis extent）和 dataZoom-slider.end 的关系的更多信息，请参见：dataZoom-slider.rangeMode。
		/// </summary>
		[JsonProperty("end")]
		public double? End { get; set; }

		/// <summary>
		/// 数据窗口范围的起始数值。如果设置了 dataZoom-slider.start 则 startValue 失效。
		/// dataZoom-slider.startValue 和 dataZoom-slider.endValue 共同用 绝对数值 的形式定义了数据窗口范围。
		/// 注意，如果轴的类型为 category，则 startValue 既可以设置为 axis.data 数组的 index，也可以设置为数组值本身。
		/// 但是如果设置为数组值本身，会在内部自动转化为数组的 index。
		/// 关于坐标轴范围（axis extent）和 dataZoom-slider.startValue 的关系的更多信息，请参见：dataZoom-slider.rangeMode。
		/// </summary>
		[JsonProperty("startValue")]
		public StringOrNumber StartValue { get; set; }

		/// <summary>
		/// 数据窗口范围的结束数值。如果设置了 dataZoom-slider.end 则 endValue 失效。
		/// dataZoom-slider.startValue 和 dataZoom-slider.endValue 共同用 绝对数值 的形式定义了数据窗口范围。
		/// 注意，如果轴的类型为 category，则 endValue 即可以设置为 axis.data 数组的 index，也可以设置为数组值本身。
		/// 但是如果设置为数组值本身，会在内部自动转化为数组的 index。
		/// 关于坐标轴范围（axis extent）和 dataZoom-slider.endValue 的关系的更多信息，请参见：dataZoom-slider.rangeMode。
		/// </summary>
		[JsonProperty("endValue")]
		public StringOrNumber EndValue { get; set; }

		/// <summary>
		/// 用于限制窗口大小的最小值（百分比值），取值范围是 0 ~ 100。
		/// 如果设置了 dataZoom-slider.minValueSpan 则 minSpan 失效。
		/// </summary>
		[JsonProperty("minSpan")]
		public double? MinSpan { get; set; }

		/// <summary>
		/// 用于限制窗口大小的最大值（百分比值），取值范围是 0 ~ 100。
		/// 如果设置了 dataZoom-slider.maxValueSpan 则 maxSpan 失效。
		/// </summary>
		[JsonProperty("maxSpan")]
		public double? MaxSpan { get; set; }

		/// <summary>
		/// 用于限制窗口大小的最小值（实际数值）。
		/// 如在时间轴上可以设置为：3600 * 24 * 1000 * 5 表示 5 天。
		/// 在类目轴上可以设置为 5 表示 5 个类目。
		/// </summary>
		[JsonProperty("minValueSpan")]
		public StringOrNumber MinValueSpan { get; set; }

		/// <summary>
		/// 用于限制窗口大小的最大值（实际数值）。
		/// 如在时间轴上可以设置为：3600 * 24 * 1000 * 5 表示 5 天。
		/// 在类目轴上可以设置为 5 表示 5 个类目。
		/// </summary>
		[JsonProperty("maxValueSpan")]
		public StringOrNumber MaxValueSpan { get; set; }

		/// <summary>
		/// 布局方式是横还是竖。不仅是布局方式，对于直角坐标系而言，也决定了，缺省情况控制横向数轴还是纵向数轴。
		/// 可选值为：
		/// 
		/// 'horizontal'：水平。
		/// 
		/// 'vertical'：竖直。
		/// </summary>
		[JsonProperty("orient")]
		public string Orient { get; set; }

		/// <summary>
		/// 是否锁定选择区域（或叫做数据窗口）的大小。
		/// 如果设置为 true 则锁定选择区域的大小，也就是说，只能平移，不能缩放。
		/// </summary>
		[JsonProperty("zoomLock")]
		public bool? ZoomLock { get; set; }

		/// <summary>
		/// 设置触发视图刷新的频率。单位为毫秒（ms）。
		/// 如果 animation 设为 true 且 animationDurationUpdate 大于 0，可以保持 throttle 为默认值 100（或者设置为大于 0 的值），否则拖拽时有可能画面感觉卡顿。
		/// 如果 animation 设为 false 或者 animationDurationUpdate 设为 0，且在数据量不大时，拖拽时画面感觉卡顿，可以把尝试把 throttle 设为 0 来改善。
		/// </summary>
		[JsonProperty("throttle")]
		public double? Throttle { get; set; }

		/// <summary>
		/// 形式为：[rangeModeForStart, rangeModeForEnd]。
		/// 例如 rangeMode: ['value', 'percent']，表示 start 值取绝对数值，end 取百分比。
		/// 每项可选值为：'value', 'percent'
		/// 
		/// 'value' 模式：处于此模式下，坐标轴范围（axis extent）总只会被dataZoom.startValue and dataZoom.endValue 决定，而不管数据是多少，以及不管，axis.min 和 axis.max 怎么设置。
		/// 'percent' 模式：处于此模式下，100 代表 100% 的 [dMin, dMax]。这里 dMin 表示，如果 axis.min 设置了就是 axis.min，否则是 data.extent[0]；dMax 表示，如果 axis.max 设置了就是 axis.max，否则是 data.extent[1]。[dMin, dMax] 乘以 percent 的结果得到坐标轴范围（axis extent）。
		/// 
		/// 默认情况下，rangeMode 总是被自动设定。如果指定了 option.start/option.end 那么就设定为 'percent'，如果指定了 option.startValue/option.endValue 那么就设定为 'value'。以及当用户用不用操作触发视图改变时，rangeMode 也可能会相应得变化（如，通过 toolbox.dataZoom 触发视图改变时，rangeMode 会自动被设置为 value，通过 dataZoom-inside 和 dataZoom-slider 触发视图改变时，会自动被设置为 'percent'）。
		/// 如果我们手动在 option 中设定了 rangeMode，那么它只在 start 和 startValue 都设置了或者 end 和 endValue 都设置了才有意义。所以通常我们没必要在 option 中指定 rangeMode。
		/// 举例一个使用场景：当我们使用动态数据时（即，周期性得通过 setOption 来改变数据），如果 rangeMode 在 'value' 模式，dataZoom 的窗口会一直保持在一个固定的值区间，无论数据怎么改变添加了多少；如果 rangeMode 在 'percent' 模式，窗口会随着数据的添加而改变（假设 axis.min 和 axis.max 没有被设置）。
		/// </summary>
		[JsonProperty("rangeMode")]
		public double[] RangeMode { get; set; }

		/// <summary>
		/// 所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// z相比zlevel优先级更低，而且不会创建新的 Canvas。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// dataZoom-slider组件离容器左侧的距离。
		/// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		/// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// dataZoom-slider组件离容器上侧的距离。
		/// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		/// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// dataZoom-slider组件离容器右侧的距离。
		/// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// dataZoom-slider组件离容器下侧的距离。
		/// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// 默认自适应。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// dataZoom-slider 组件的宽度。竖直布局默认 30，水平布局默认自适应。
		/// 比 left 和 right 优先级高。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		/// dataZoom-slider 组件的高度。水平布局默认 30，竖直布局默认自适应。
		/// 比 top 和 bottom 优先级高。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 是否开启刷选功能。在下图的 brush 区域你可以按住鼠标左键后框选出选中部分。
		/// </summary>
		[JsonProperty("brushSelect")]
		public bool? BrushSelect { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 刷选框样式设置。
		/// </summary>
		[JsonProperty("brushStyle")]
		public HandleStyle0 BrushStyle { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 高亮样式设置。
		/// </summary>
		[JsonProperty("emphasis")]
		public DataZoomSlider_Emphasis Emphasis { get; set; }
	}

	/// <summary>
	/// 数据阴影的样式。
	/// </summary>
	public class DataZoomSlider_DataBackground
	{
		/// <summary>
		/// 阴影的线条样式
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// 阴影的填充样式
		/// </summary>
		[JsonProperty("areaStyle")]
		public ShadowStyle0 AreaStyle { get; set; }
	}

	/// <summary>
	/// 两侧缩放手柄的样式配置。
	/// </summary>
	public class HandleStyle0
	{
		/// <summary>
		/// 图形的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 图形的描边颜色。支持的颜色格式同 color，不支持回调函数。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 描边线宽。为 0 时无描边。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// borderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// borderType: [5, 10],
		/// 
		/// borderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("borderType")]
		public StringOrNumber[] BorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// borderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("borderDashOffset")]
		public double? BorderDashOffset { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于指定线段末端的绘制方式，可以是：
		/// 
		/// 'butt': 线段末端以方形结束。
		/// 'round': 线段末端以圆形结束。
		/// 'square': 线段末端以方形结束，但是增加了一个宽度和线段相同，高度是线段厚度一半的矩形区域。
		/// 
		/// 默认值为 'butt'。 更多详情可以参考 MDN lineCap。
		/// </summary>
		[JsonProperty("borderCap")]
		public string BorderCap { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置2个长度不为0的相连部分（线段，圆弧，曲线）如何连接在一起的属性（长度为0的变形部分，其指定的末端和控制点在同一位置，会被忽略）。
		/// 可以是：
		/// 
		/// 'bevel': 在相连部分的末端填充一个额外的以三角形为底的区域， 每个部分都有各自独立的矩形拐角。
		/// 'round': 通过填充一个额外的，圆心在相连部分末端的扇形，绘制拐角的形状。 圆角的半径是线段的宽度。
		/// 'miter': 通过延伸相连部分的外边缘，使其相交于一点，形成一个额外的菱形区域。这个设置可以通过 
		/// borderMiterLimit
		/// 属性看到效果。
		/// 
		/// 默认值为 'bevel'。 更多详情可以参考 MDN lineJoin。
		/// </summary>
		[JsonProperty("borderJoin")]
		public string BorderJoin { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置斜接面限制比例。只有当 
		/// borderJoin
		///  为 miter 时，
		/// borderMiterLimit
		///  才有效。
		/// 默认值为 10。负数、0、Infinity 和 NaN 均会被忽略。
		/// 更多详情可以参考 MDN miterLimit。
		/// </summary>
		[JsonProperty("borderMiterLimit")]
		public double? BorderMiterLimit { get; set; }

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
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 高亮样式设置。
	/// </summary>
	public class DataZoomSlider_Emphasis
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("handleStyle")]
		public HandleStyle0 HandleStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("moveHandleStyle")]
		public HandleStyle0 MoveHandleStyle { get; set; }
	}
}