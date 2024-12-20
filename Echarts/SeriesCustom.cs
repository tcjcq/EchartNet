using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 自定义系列
	/// 自定义系列可以自定义系列中的图形元素渲染。从而能扩展出不同的图表。
	/// 同时，echarts 会统一管理图形的创建删除、动画、与其他组件（如 dataZoom、visualMap）的联动，使开发者不必纠结这些细节。
	/// 例如，下面的例子使用 custom series 扩展出了 x-range 图：
	/// 
	/// 
	/// 
	/// 更多的例子参见：custom examples
	/// 这里是个教程
	/// 开发者自定义渲染逻辑（renderItem 函数）
	/// custom 系列需要开发者自己提供图形渲染的逻辑。这个渲染逻辑一般命名为 renderItem。例如：
	/// var option = {
	///     ...,
	///     series: [{
	///         type: 'custom',
	///         renderItem: function (params, api) {
	///             var categoryIndex = api.value(0);
	///             var start = api.coord([api.value(1), categoryIndex]);
	///             var end = api.coord([api.value(2), categoryIndex]);
	///             var height = api.size([0, 1])[1] * 0.6;
	/// 
	///             var rectShape = echarts.graphic.clipRectByRect({
	///                 x: start[0],
	///                 y: start[1] - height / 2,
	///                 width: end[0] - start[0],
	///                 height: height
	///             }, {
	///                 x: params.coordSys.x,
	///                 y: params.coordSys.y,
	///                 width: params.coordSys.width,
	///                 height: params.coordSys.height
	///             });
	/// 
	///             return rectShape && {
	///                 type: 'rect',
	///                 shape: rectShape,
	///                 style: api.style()
	///             };
	///         },
	///         data: data
	///     }]
	/// }
	/// 
	/// 对于 data 中的每个数据项（为方便描述，这里称为 dataItem)，会调用此 renderItem 函数。
	/// renderItem 函数提供了两个参数：
	/// 
	/// params：包含了当前数据信息和坐标系的信息。
	/// api：是一些开发者可调用的方法集合。
	/// 
	/// renderItem 函数须返回根据此 dataItem 绘制出的图形元素的定义信息，参见 renderItem.return。
	/// 一般来说，renderItem 函数的主要逻辑，是将 dataItem 里的值映射到坐标系上的图形元素。这一般需要用到 renderItem.arguments.api 中的两个函数：
	/// 
	/// api.value(...)，意思是取出 dataItem 中的数值。例如 api.value(0) 表示取出当前 dataItem 中第一个维度的数值。
	/// api.coord(...)，意思是进行坐标转换计算。例如 var point = api.coord([api.value(0), api.value(1)]) 表示 dataItem 中的数值转换成坐标系上的点。
	/// 
	/// 有时候还需要用到 api.size(...) 函数，表示得到坐标系上一段数值范围对应的长度。
	/// 返回值中样式的设置可以使用 api.style(...) 函数，他能得到 series.itemStyle 中定义的样式信息，以及视觉映射的样式信息。也可以用这种方式覆盖这些样式信息：api.style({fill: 'green', stroke: 'yellow'})。
	/// 维度的映射（encode 和 dimensions 属性）
	/// custom 系列往往需要定义 series.encode，主要用于指明 data 的哪些维度映射到哪些数轴上。从而，echarts 能根据这些维度的值的范围，画出合适的数轴刻度。
	/// 同时，encode.tooltip 和 encode.label 也可以被指定，指明默认的 tooltip 和 label 显示什么内容。series.dimensions 也可以被指定，指明显示在 tooltip 中的维度名称，或者维度的类型。
	/// 例如：
	/// series: {
	///     type: 'custom',
	///     renderItem: function () {
	///         ...
	///     },
	///     encode: {
	///         x: [2, 4, 3],
	///         y: 1,
	///         label: 0,
	///         tooltip: [2, 4, 3]
	///     }
	/// }
	/// 
	/// 与 dataZoom 组件的结合
	/// 与 dataZoom 结合使用的时候，常常使用会设置 dataZoom.filterMode 为 'weakFilter'，从而让 dataItem 部分超出坐标系边界的时候，不会整体被过滤掉。
	/// 关于 dataIndex 和 dataIndexInside 的区别
	/// 
	/// dataIndex 指的 dataItem 在原始数据中的 index。
	/// dataIndexInside 指的是 dataItem 在当前数据窗口（参见 dataZoom）中的 index。
	/// 
	/// renderItem.arguments.api 中使用的参数都是 dataIndexInside 而非 dataIndex，因为从 dataIndex 转换成 dataIndexInside 需要时间开销。
	/// Event listener
	/// chart.setOption({
	///     // ...
	///     series: {
	///         type: 'custom',
	///         renderItem: function () {
	///             // ...
	///             return {
	///                 type: 'group',
	///                 children: [{
	///                     type: 'circle'
	///                     // ...
	///                 }, {
	///                     type: 'circle',
	///                     name: 'aaa',
	///                     // 用户指定的信息，可以在 event handler 访问到。
	///                     info: 12345,
	///                     // ...
	///                 }]
	///             };
	///         }
	///     }
	/// });
	/// chart.on('click', {element: 'aaa'}, function (params) {
	///     // 当 name 为 'aaa' 的图形元素被点击时，此回调被触发。
	///     console.log(params.info);
	/// });
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "custom";

		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 系列名称，用于tooltip的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 从 v5.2.0 开始支持
		/// 
		/// 从调色盘 option.color 中取色的策略，可取值为：
		/// 
		/// 'series'：按照系列分配调色盘中的颜色，同一系列中的所有数据都是用相同的颜色；
		/// 'data'：按照数据项分配调色盘中的颜色，每个数据项都使用不同的颜色。
		/// </summary>
		[JsonProperty("colorBy")]
		public string ColorBy { get; set; }

		/// <summary>
		/// 是否启用图例 hover 时的联动高亮。
		/// </summary>
		[JsonProperty("legendHoverLink")]
		public bool? LegendHoverLink { get; set; }

		/// <summary>
		/// 该系列使用的坐标系，可选：
		/// 
		/// null 或者 'none'
		///   无坐标系。
		/// 
		/// 
		/// 
		/// 'cartesian2d'
		///   使用二维的直角坐标系（也称笛卡尔坐标系），通过 xAxisIndex, yAxisIndex指定相应的坐标轴组件。
		/// 
		/// 
		/// 
		/// 'polar'
		///   使用极坐标系，通过 polarIndex 指定相应的极坐标组件
		/// 
		/// 
		/// 
		/// 'geo'
		///   使用地理坐标系，通过 geoIndex 指定相应的地理坐标系组件。
		/// 
		/// 
		/// 
		/// 'calendar'
		///   使用日历坐标系，通过 calendarIndex 指定相应的日历坐标系组件。
		/// 
		/// 
		/// 
		/// 'none'
		///   不使用坐标系。
		/// </summary>
		[JsonProperty("coordinateSystem")]
		public string CoordinateSystem { get; set; }

		/// <summary>
		/// 使用的 x 轴的 index，在单个图表实例中存在多个 x 轴的时候有用。
		/// </summary>
		[JsonProperty("xAxisIndex")]
		public double? XAxisIndex { get; set; }

		/// <summary>
		/// 使用的 y 轴的 index，在单个图表实例中存在多个 y轴的时候有用。
		/// </summary>
		[JsonProperty("yAxisIndex")]
		public double? YAxisIndex { get; set; }

		/// <summary>
		/// 使用的极坐标系的 index，在单个图表实例中存在多个极坐标系的时候有用。
		/// </summary>
		[JsonProperty("polarIndex")]
		public double? PolarIndex { get; set; }

		/// <summary>
		/// 使用的地理坐标系的 index，在单个图表实例中存在多个地理坐标系的时候有用。
		/// </summary>
		[JsonProperty("geoIndex")]
		public double? GeoIndex { get; set; }

		/// <summary>
		/// 使用的日历坐标系的 index，在单个图表实例中存在多个日历坐标系的时候有用。
		/// </summary>
		[JsonProperty("calendarIndex")]
		public double? CalendarIndex { get; set; }

		/// <summary>
		/// custom 系列需要开发者自己提供图形渲染的逻辑。这个渲染逻辑一般命名为 renderItem。例如：
		/// var option = {
		///     ...,
		///     series: [{
		///         type: 'custom',
		///         renderItem: function (params, api) {
		///             var categoryIndex = api.value(0);
		///             var start = api.coord([api.value(1), categoryIndex]);
		///             var end = api.coord([api.value(2), categoryIndex]);
		///             var height = api.size([0, 1])[1] * 0.6;
		/// 
		///             var rectShape = echarts.graphic.clipRectByRect({
		///                 x: start[0],
		///                 y: start[1] - height / 2,
		///                 width: end[0] - start[0],
		///                 height: height
		///             }, {
		///                 x: params.coordSys.x,
		///                 y: params.coordSys.y,
		///                 width: params.coordSys.width,
		///                 height: params.coordSys.height
		///             });
		/// 
		///             return rectShape && {
		///                 type: 'rect',
		///                 shape: rectShape,
		///                 style: api.style()
		///             };
		///         },
		///         data: data
		///     }]
		/// }
		/// 
		/// 对于 data 中的每个数据项（为方便描述，这里称为 dataItem)，会调用此 renderItem 函数。
		/// renderItem 函数提供了两个参数：
		/// 
		/// params：包含了当前数据信息和坐标系的信息。
		/// api：是一些开发者可调用的方法集合。
		/// 
		/// renderItem 函数须返回根据此 dataItem 绘制出的图形元素的定义信息，参见 renderItem.return。
		/// 一般来说，renderItem 函数的主要逻辑，是将 dataItem 里的值映射到坐标系上的图形元素。这一般需要用到 renderItem.arguments.api 中的两个函数：
		/// 
		/// api.value(...)，意思是取出 dataItem 中的数值。例如 api.value(0) 表示取出当前 dataItem 中第一个维度的数值。
		/// api.coord(...)，意思是进行坐标转换计算。例如 var point = api.coord([api.value(0), api.value(1)]) 表示 dataItem 中的数值转换成坐标系上的点。
		/// 
		/// 有时候还需要用到 api.size(...) 函数，表示得到坐标系上一段数值范围对应的长度。
		/// 返回值中样式的设置可以使用 api.style(...) 函数，他能得到 series.itemStyle 中定义的样式信息，以及视觉映射的样式信息。也可以用这种方式覆盖这些样式信息：api.style({fill: 'green', stroke: 'yellow'})。
		/// </summary>
		[JsonProperty("renderItem")]
		public SeriesCustom_RenderItem RenderItem { get; set; }

		/// <summary>
		/// 图形样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public LabelLine1 LabelLine { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的统一布局配置。
		/// 该配置项是在每个系列默认的标签布局基础上，统一调整标签的(x, y)位置，标签对齐等属性以实现想要的标签布局效果。
		/// 该配置项也可以是一个有如下参数的回调函数
		/// // 标签对应数据的 dataIndex
		/// dataIndex: number
		/// // 标签对应的数据类型，只在关系图中会有 node 和 edge 数据类型的区分
		/// dataType?: string
		/// // 标签对应的系列的 index
		/// seriesIndex: number
		/// // 标签显示的文本
		/// text: string
		/// // 默认的标签的包围盒，由系列默认的标签布局决定
		/// labelRect: {x: number, y: number, width: number, height: number}
		/// // 默认的标签水平对齐
		/// align: 'left' | 'center' | 'right'
		/// // 默认的标签垂直对齐
		/// verticalAlign: 'top' | 'middle' | 'bottom'
		/// // 标签所对应的数据图形的包围盒，可用于定位标签位置
		/// rect: {x: number, y: number, width: number, height: number}
		/// // 默认引导线的位置，目前只有饼图(pie)和漏斗图(funnel)有默认标签位置
		/// // 如果没有该值则为 null
		/// labelLinePoints?: number[][]
		/// 
		/// 示例：
		/// 将标签显示在图形右侧 10px 的位置，并且垂直居中：
		/// labelLayout(params) {
		///     return {
		///         x: params.rect.x + 10,
		///         y: params.rect.y + params.rect.height / 2,
		///         verticalAlign: 'middle',
		///         align: 'left'
		///     }
		/// }
		/// 
		/// 根据图形的包围盒尺寸决定文本尺寸
		/// 
		/// labelLayout(params) {
		///     return {
		///         fontSize: Math.max(params.rect.width / 10, 5)
		///     };
		/// }
		/// </summary>
		[JsonProperty("labelLayout")]
		public LabelLayout0 LabelLayout { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 选中模式的配置，表示是否支持多个选中，默认关闭，支持布尔值和字符串，字符串取值可选'single'，'multiple'，'series' 分别表示单选，多选以及选择整个系列。
		/// 
		/// 从 v5.3.0 开始支持 'series'。
		/// </summary>
		[JsonProperty("selectedMode")]
		public StringOrBool SelectedMode { get; set; }

		/// <summary>
		/// 使用 dimensions 定义 series.data 或者 dataset.source 的每个维度的信息。
		/// 注意：如果使用了 dataset，那么可以在 dataset.dimensions 中定义 dimension ，或者在 dataset.source 的第一行/列中给出 dimension 名称。于是就不用在这里指定 dimension。但如果在这里指定了 dimensions，那么优先使用这里的。
		/// 例如：
		/// option = {
		///     dataset: {
		///         source: [
		///             // 有了上面 dimensions 定义后，下面这五个维度的名称分别为：
		///             // 'date', 'open', 'close', 'highest', 'lowest'
		///             [12, 44, 55, 66, 2],
		///             [23, 6, 16, 23, 1],
		///             ...
		///         ]
		///     },
		///     series: {
		///         type: 'xxx',
		///         // 定义了每个维度的名称。这个名称会被显示到默认的 tooltip 中。
		///         dimensions: ['date', 'open', 'close', 'highest', 'lowest']
		///     }
		/// }
		/// 
		/// series: {
		///     type: 'xxx',
		///     dimensions: [
		///         null,                // 如果此维度不想给出定义，则使用 null 即可
		///         {type: 'ordinal'},   // 只定义此维度的类型。
		///                              // 'ordinal' 表示离散型，一般文本使用这种类型。
		///                              // 如果类型没有被定义，会自动猜测类型。
		///         {name: 'good', type: 'number'},
		///         'bad'                // 等同于 {name: 'bad'}
		///     ]
		/// }
		/// 
		/// dimensions 数组中的每一项可以是：
		/// 
		/// string，如 'someName'，等同于 {name: 'someName'}
		/// Object，属性可以有：
		/// name: string。
		/// type: string，支持
		/// number，默认，表示普通数据。
		/// ordinal，对于类目、文本这些 string 类型的数据，如果需要能在数轴上使用，须是 'ordinal' 类型。ECharts 默认会自动判断这个类型。但是自动判断也是不可能很完备的，所以使用者也可以手动强制指定。
		/// float，即 Float64Array。
		/// int，即 Int32Array。
		/// time，表示时间类型。设置成 'time' 则能支持自动解析数据成时间戳（timestamp），比如该维度的数据是 '2017-05-10'，会自动被解析。时间类型的支持参见 data。
		/// 
		/// 
		/// displayName: 一般用于 tooltip 中维度名的展示。string 如果没有指定，默认使用 name 来展示。
		/// 
		/// 
		/// 
		/// 值得一提的是，当定义了 dimensions 后，默认 tooltip 中对个维度的显示，会变为『竖排』，从而方便显示每个维度的名称。如果没有定义 dimensions，则默认 tooltip 会横排显示，且只显示数值没有维度名称可显示。
		/// </summary>
		[JsonProperty("dimensions")]
		public double[] Dimensions { get; set; }

		/// <summary>
		/// 可以定义 data 的哪个维度被编码成什么。比如：
		/// option = {
		///     dataset: {
		///         source: [
		///             // 每一列称为一个『维度』。
		///             // 这里分别是维度 0、1、2、3、4。
		///             [12, 44, 55, 66, 2],
		///             [23, 6, 16, 23, 1],
		///             ...
		///         ]
		///     },
		///     series: {
		///         type: 'xxx',
		///         encode: {
		///             x: [3, 1, 5],      // 表示维度 3、1、5 映射到 x 轴。
		///             y: 2,              // 表示维度 2 映射到 y 轴。
		///             tooltip: [3, 2, 4] // 表示维度 3、2、4 会在 tooltip 中显示。
		///         }
		///     }
		/// }
		/// 
		/// 当使用 dimensions 给维度定义名称后，encode 中可直接引用名称，例如：
		/// series: {
		///     type: 'xxx',
		///     dimensions: ['date', 'open', 'close', 'highest', 'lowest'],
		///     encode: {
		///         x: 'date',
		///         y: ['open', 'close', 'highest', 'lowest']
		///     }
		/// }
		/// 
		/// encode 声明的基本结构如下，其中冒号左边是坐标系、标签等特定名称，如 'x', 'y', 'tooltip' 等，冒号右边是数据中的维度名（string 格式）或者维度的序号（number 格式，从 0 开始计数），可以指定一个或多个维度（使用数组）。通常情况下，下面各种信息不需要所有的都写，按需写即可。
		/// 下面是 encode 支持的属性：
		/// // 在任何坐标系和系列中，都支持：
		/// encode: {
		///     // 使用 “名为 product 的维度” 和 “名为 score 的维度” 的值在 tooltip 中显示
		///     tooltip: ['product', 'score']
		///     // 使用第一个维度和第三个维度的维度名连起来作为系列名。（有时候名字比较长，这可以避免在 series.name 重复输入这些名字）
		///     seriesName: [1, 3],
		///     // 表示使用第二个维度中的值作为 id。这在使用 setOption 动态更新数据时有用处，可以使新老数据用 id 对应起来，从而能够产生合适的数据更新动画。
		///     itemId: 2,
		///     // 指定数据项的名称使用第三个维度在饼图等图表中有用，可以使这个名字显示在图例（legend）中。
		///     itemName: 3,
		///     // 指定数据项的组 ID (groupId)。当全局过渡动画功能开启时，setOption 前后拥有相同 groupId 的数据项会进行动画过渡。
		///     itemGroupId: 4,
		///     // 指定数据项对应的子数据组 ID (childGroupId)，用于实现多层下钻和聚合。详见 childGroupId。
		///     // 从 v5.5.0 开始支持
		///     itemChildGroupId: 5
		/// }
		/// 
		/// // 直角坐标系（grid/cartesian）特有的属性：
		/// encode: {
		///     // 把 “维度1”、“维度5”、“名为 score 的维度” 映射到 X 轴：
		///     x: [1, 5, 'score'],
		///     // 把“维度0”映射到 Y 轴。
		///     y: 0
		/// }
		/// 
		/// // 单轴（singleAxis）特有的属性：
		/// encode: {
		///     single: 3
		/// }
		/// 
		/// // 极坐标系（polar）特有的属性：
		/// encode: {
		///     radius: 3,
		///     angle: 2
		/// }
		/// 
		/// // 地理坐标系（geo）特有的属性：
		/// encode: {
		///     lng: 3,
		///     lat: 2
		/// }
		/// 
		/// // 对于一些没有坐标系的图表，例如饼图、漏斗图等，可以是：
		/// encode: {
		///     value: 3
		/// }
		/// 
		/// 这是个更丰富的 encode 的示例：
		/// 特殊地，在 自定义系列（custom series） 中，encode 中轴可以不指定或设置为 null/undefined，从而使系列免于受这个轴控制，也就是说，轴的范围（extent）不会受此系列数值的影响，轴被 dataZoom 控制时也不会过滤掉这个系列：
		/// var option = {
		///     xAxis: {},
		///     yAxis: {},
		///     dataZoom: [{
		///         xAxisIndex: 0
		///     }, {
		///         yAxisIndex: 0
		///     }],
		///     series: {
		///         type: 'custom',
		///         renderItem: function (params, api) {
		///             return {
		///                 type: 'circle',
		///                 shape: {
		///                     cx: 100, // x 位置永远为 100
		///                     cy: api.coord([0, api.value(0)])[1],
		///                     r: 30
		///                 },
		///                 style: {
		///                     fill: 'blue'
		///                 }
		///             };
		///         },
		///         encode: {
		///             // 这样这个系列就不会被 x 轴以及 x
		///             // 轴上的 dataZoom 控制了。
		///             x: -1,
		///             y: 1
		///         },
		///         data: [ ... ]
		///     }
		/// };
		/// </summary>
		[JsonProperty("encode")]
		public object Encode { get; set; }

		/// <summary>
		/// 当使用 dataset 时，seriesLayoutBy 指定了 dataset 中用行还是列对应到系列上，也就是说，系列“排布”到 dataset 的行还是列上。可取值：
		/// 
		/// 'column'：默认，dataset 的列对应于系列，从而 dataset 中每一列是一个维度（dimension）。
		/// 'row'：dataset 的行对应于系列，从而 dataset 中每一行是一个维度（dimension）。
		/// 
		/// 参见这个 示例
		/// </summary>
		[JsonProperty("seriesLayoutBy")]
		public string SeriesLayoutBy { get; set; }

		/// <summary>
		/// 如果 series.data 没有指定，并且 dataset 存在，那么就会使用 dataset。datasetIndex 指定本系列使用哪个 dataset。
		/// </summary>
		[JsonProperty("datasetIndex")]
		public double? DatasetIndex { get; set; }

		/// <summary>
		/// 该系列所有数据项的组 ID，优先级低于groupId。详见series.data.groupId。
		/// </summary>
		[JsonProperty("dataGroupId")]
		public string DataGroupId { get; set; }

		/// <summary>
		/// 系列中的数据内容数组。数组项通常为具体的数据项。
		/// 注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
		/// 可以使用 series.datasetIndex 指定其他的 dataset。
		/// 通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
		/// series: [{
		///     data: [
		///         // 维度X   维度Y   其他维度 ...
		///         [  3.4,    4.5,   15,   43],
		///         [  4.2,    2.3,   20,   91],
		///         [  10.8,   9.5,   30,   18],
		///         [  7.2,    8.8,   18,   57]
		///     ]
		/// }]
		/// 
		/// 
		/// 在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
		/// 在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
		/// 后面的其他维度是可选的，可以在别处被使用，例如：
		/// 在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
		/// 在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
		/// 使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
		/// 
		/// 
		/// 
		/// 特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
		/// xAxis: {
		///     data: ['a', 'b', 'm', 'n']
		/// },
		/// series: [{
		///     // 与 xAxis.data 一一对应。
		///     data: [23,  44,  55,  19]
		///     // 它其实是下面这种形式的简化：
		///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
		/// }]
		/// 
		/// 『值』与 轴类型 的关系：
		/// 
		/// 当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
		///   其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
		/// 
		/// 当某维度对应于类目轴（axis.type 为 'category'）的时候：
		///   其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
		///   xAxis: {
		///       type: 'category',
		///       data: ['星期一', '星期二', '星期三', '星期四']
		///   },
		///   yAxis: {
		///       type: 'category',
		///       data: ['a', 'b', 'm', 'n', 'p', 'q']
		///   },
		///   series: [{
		///       data: [
		///           // xAxis    yAxis
		///           [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
		///           [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
		///           [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
		///           [  3,        3,    5  ]
		///       ]
		///   }]
		/// 
		///   双类目轴的示例可以参考 Github Punchcard 示例。
		/// 
		/// 当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
		/// 
		/// 一个时间戳，如 1484141700832，表示 UTC 时间。
		/// 或者字符串形式的时间描述：
		/// ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
		/// 部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
		/// 使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
		/// 时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
		/// 
		/// 
		/// 其他的时间字符串，包括（均表示本地时间）:
		/// '2012', '2012-3-1', '2012/3/1', '2012/03/01',
		/// '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
		/// 
		/// 
		/// 或者用户自行初始化的 Date 实例：
		/// 注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
		/// 例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01') 表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
		/// 所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 当需要对个别数据进行个性化定义时：
		/// 数组项可用对象，其中的 value 像表示具体的数值，如：
		/// [
		///     12,
		///     34,
		///     {
		///         value : 56,
		///         //自定义标签样式，仅对该数据项有效
		///         label: {},
		///         //自定义特殊 itemStyle，仅对该数据项有效
		///         itemStyle:{}
		///     },
		///     10
		/// ]
		/// // 或
		/// [
		///     [12, 33],
		///     [34, 313],
		///     {
		///         value: [56, 44],
		///         label: {},
		///         itemStyle:{}
		///     },
		///     [10, 33]
		/// ]
		/// 
		/// 空值：
		/// 当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
		/// 例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
		/// </summary>
		[JsonProperty("data")]
		public SeriesCustom_Data[] Data { get; set; }

		/// <summary>
		/// 从 v4.4.0 开始支持
		/// 
		/// 是否裁剪超出坐标系部分的图形，具体裁剪效果根据系列决定：
		/// 
		/// 散点图/带有涟漪特效动画的散点（气泡）图：忽略中心点超出坐标系的图形，但是不裁剪单个图形
		/// 柱状图：裁掉完全超出的柱子，但是不会裁剪只超出部分的柱子
		/// 折线图：裁掉所有超出坐标系的折线部分，拐点图形的逻辑按照散点图处理
		/// 路径图：裁掉所有超出坐标系的部分
		/// K 线图：忽略整体都超出坐标系的图形，但是不裁剪单个图形
		/// 象形柱图：裁掉所有超出坐标系的部分（从 v5.5.0 开始支持）
		/// 自定义系列：裁掉所有超出坐标系的部分
		/// 
		/// 除了象形柱图和自定义系列，其它系列的默认值都为 true，及开启裁剪，如果你觉得不想要裁剪的话，可以设置成 false 关闭。
		/// </summary>
		[JsonProperty("clip")]
		public bool? Clip { get; set; }

		/// <summary>
		/// 自定义图所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 自定义图组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// z相比zlevel优先级更低，而且不会创建新的 Canvas。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 是否开启动画。
		/// </summary>
		[JsonProperty("animation")]
		public bool? Animation { get; set; }

		/// <summary>
		/// 是否开启动画的阈值，当单个系列显示的图形数量大于这个阈值时会关闭动画。
		/// </summary>
		[JsonProperty("animationThreshold")]
		public double? AnimationThreshold { get; set; }

		/// <summary>
		/// 初始动画的时长，支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的初始动画效果：
		/// animationDuration: function (idx) {
		///     // 越往后的数据时长越大
		///     return idx * 100;
		/// }
		/// </summary>
		[JsonProperty("animationDuration")]
		public StringOrNumber AnimationDuration { get; set; }

		/// <summary>
		/// 初始动画的缓动效果。不同的缓动效果可以参考 缓动示例。
		/// </summary>
		[JsonProperty("animationEasing")]
		public string AnimationEasing { get; set; }

		/// <summary>
		/// 初始动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的初始动画效果。
		/// 如下示例：
		/// animationDelay: function (idx) {
		///     // 越往后的数据延迟越大
		///     return idx * 100;
		/// }
		/// 
		/// 也可以看该示例
		/// </summary>
		[JsonProperty("animationDelay")]
		public StringOrNumber AnimationDelay { get; set; }

		/// <summary>
		/// 数据更新动画的时长。
		/// 支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的更新动画效果：
		/// animationDurationUpdate: function (idx) {
		///     // 越往后的数据时长越大
		///     return idx * 100;
		/// }
		/// </summary>
		[JsonProperty("animationDurationUpdate")]
		public StringOrNumber AnimationDurationUpdate { get; set; }

		/// <summary>
		/// 数据更新动画的缓动效果。
		/// </summary>
		[JsonProperty("animationEasingUpdate")]
		public string AnimationEasingUpdate { get; set; }

		/// <summary>
		/// 数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
		/// 如下示例：
		/// animationDelayUpdate: function (idx) {
		///     // 越往后的数据延迟越大
		///     return idx * 100;
		/// }
		/// 
		/// 也可以看该示例
		/// </summary>
		[JsonProperty("animationDelayUpdate")]
		public StringOrNumber AnimationDelayUpdate { get; set; }

		/// <summary>
		/// 从 v5.2.0 开始支持
		/// 
		/// 全局过渡动画相关的配置。
		/// 全局过渡动画（Universal Transition）提供了任意系列之间进行变形动画的功能。开启该功能后，每次setOption，相同id的系列之间会自动关联进行动画的过渡，更细粒度的关联配置见universalTransition.seriesKey配置。
		/// 通过配置数据项的groupId和childGroupId，还可以实现诸如下钻，聚合等一对多或者多对一的动画。
		/// 可以直接在系列中配置 universalTransition: true 开启该功能。也可以提供一个对象进行更多属性的配置。
		/// </summary>
		[JsonProperty("universalTransition")]
		public SeriesLine_UniversalTransition UniversalTransition { get; set; }

		/// <summary>
		/// 本系列特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// custom 系列需要开发者自己提供图形渲染的逻辑。这个渲染逻辑一般命名为 renderItem。例如：
	/// var option = {
	///     ...,
	///     series: [{
	///         type: 'custom',
	///         renderItem: function (params, api) {
	///             var categoryIndex = api.value(0);
	///             var start = api.coord([api.value(1), categoryIndex]);
	///             var end = api.coord([api.value(2), categoryIndex]);
	///             var height = api.size([0, 1])[1] * 0.6;
	/// 
	///             var rectShape = echarts.graphic.clipRectByRect({
	///                 x: start[0],
	///                 y: start[1] - height / 2,
	///                 width: end[0] - start[0],
	///                 height: height
	///             }, {
	///                 x: params.coordSys.x,
	///                 y: params.coordSys.y,
	///                 width: params.coordSys.width,
	///                 height: params.coordSys.height
	///             });
	/// 
	///             return rectShape && {
	///                 type: 'rect',
	///                 shape: rectShape,
	///                 style: api.style()
	///             };
	///         },
	///         data: data
	///     }]
	/// }
	/// 
	/// 对于 data 中的每个数据项（为方便描述，这里称为 dataItem)，会调用此 renderItem 函数。
	/// renderItem 函数提供了两个参数：
	/// 
	/// params：包含了当前数据信息和坐标系的信息。
	/// api：是一些开发者可调用的方法集合。
	/// 
	/// renderItem 函数须返回根据此 dataItem 绘制出的图形元素的定义信息，参见 renderItem.return。
	/// 一般来说，renderItem 函数的主要逻辑，是将 dataItem 里的值映射到坐标系上的图形元素。这一般需要用到 renderItem.arguments.api 中的两个函数：
	/// 
	/// api.value(...)，意思是取出 dataItem 中的数值。例如 api.value(0) 表示取出当前 dataItem 中第一个维度的数值。
	/// api.coord(...)，意思是进行坐标转换计算。例如 var point = api.coord([api.value(0), api.value(1)]) 表示 dataItem 中的数值转换成坐标系上的点。
	/// 
	/// 有时候还需要用到 api.size(...) 函数，表示得到坐标系上一段数值范围对应的长度。
	/// 返回值中样式的设置可以使用 api.style(...) 函数，他能得到 series.itemStyle 中定义的样式信息，以及视觉映射的样式信息。也可以用这种方式覆盖这些样式信息：api.style({fill: 'green', stroke: 'yellow'})。
	/// </summary>
	public class SeriesCustom_RenderItem
	{
		/// <summary>
		/// renderItem 函数的参数。
		/// </summary>
		[JsonProperty("arguments")]
		public SeriesCustom_RenderItem_Arguments Arguments { get; set; }

		/// <summary>
		/// 图形元素。每个图形元素是一个 object。详细信息参见：graphic。（width\height\top\bottom 不支持）
		/// 如果什么都不渲染，可以不返回任何东西。
		/// 例如：
		/// // 单独一个矩形
		/// {
		///     type: 'rect',
		///     shape: {
		///         x: x, y: y, width: width, height: height
		///     },
		///     style: api.style()
		/// }
		/// 
		/// // 一组图形元素
		/// {
		///     type: 'group',
		///     // 如果 diffChildrenByName 设为 true，则会使用 child.name 进行 diff，
		///     // 从而能有更好的过度动画，但是降低性能。缺省为 false。
		///     // diffChildrenByName: true,
		///     children: [{
		///         type: 'circle',
		///         shape: {
		///             cx: cx, cy: cy, r: r
		///         },
		///         style: api.style()
		///     }, {
		///         type: 'line',
		///         shape: {
		///             x1: x1, y1: y1, x2: x2, y2: y2
		///         },
		///         style: api.style()
		///     }]
		/// }
		/// </summary>
		[JsonProperty("return")]
		public object Return { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_group")]
		public SeriesCustom_RenderItem_ReturnGroup ReturnGroup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_path")]
		public SeriesCustom_RenderItem_ReturnPath ReturnPath { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_image")]
		public SeriesCustom_RenderItem_ReturnImage ReturnImage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_text")]
		public SeriesCustom_RenderItem_ReturnText ReturnText { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_rect")]
		public SeriesCustom_RenderItem_ReturnRect ReturnRect { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_circle")]
		public SeriesCustom_RenderItem_ReturnCircle ReturnCircle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_ring")]
		public SeriesCustom_RenderItem_ReturnRing ReturnRing { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_sector")]
		public SeriesCustom_RenderItem_ReturnSector ReturnSector { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_arc")]
		public SeriesCustom_RenderItem_ReturnSector ReturnArc { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_polygon")]
		public SeriesCustom_RenderItem_ReturnPolygon ReturnPolygon { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_polyline")]
		public SeriesCustom_RenderItem_ReturnPolygon ReturnPolyline { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_line")]
		public SeriesCustom_RenderItem_ReturnLine ReturnLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("return_bezierCurve")]
		public SeriesCustom_RenderItem_ReturnBezierCurve ReturnBezierCurve { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_Arguments
	{
		/// <summary>
		/// renderItem 函数的第一个参数，含有：
		/// {
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
		///         type: 'cartesian2d',
		///         x: // {number} grid rect 的 x
		///         y: // {number} grid rect 的 y
		///         width: // {number} grid rect 的 width
		///         height: // {number} grid rect 的 height
		///     },
		///     coordSys: {
		///         type: 'calendar',
		///         x: // {number} calendar rect 的 x
		///         y: // {number} calendar rect 的 y
		///         width: // {number} calendar rect 的 width
		///         height: // {number} calendar rect 的 height
		///         cellWidth: // {number} calendar cellWidth
		///         cellHeight: // {number} calendar cellHeight
		///         rangeInfo: {
		///             start: // calendar 日期开端
		///             end: // calendar 日期结尾
		///             weeks: // calendar 周数
		///             dayCount: // calendar 日数
		///         }
		///     },
		///     coordSys: {
		///         type: 'geo',
		///         x: // {number} geo rect 的 x
		///         y: // {number} geo rect 的 y
		///         width: // {number} geo rect 的 width
		///         height: // {number} geo rect 的 height
		///         zoom: // {number} 缩放的比率。如果没有缩放，则值为 1。例如 0.5 表示缩小了一半。
		///     },
		///     coordSys: {
		///         type: 'polar',
		///         cx: // {number} polar 的中心坐标
		///         cy: // {number} polar 的中心坐标
		///         r: // {number} polar 的外半径
		///         r0: // {number} polar 的内半径
		///     },
		///     coordSys: {
		///         type: 'singleAxis',
		///         x: // {number} singleAxis rect 的 x
		///         y: // {number} singleAxis rect 的 y
		///         width: // {number} singleAxis rect 的 width
		///         height: // {number} singleAxis rect 的 height
		///     }
		/// }
		/// 
		/// 其中，关于 dataIndex 和 dataIndexInside 的区别：
		/// 
		/// dataIndex 指的 dataItem 在原始数据中的 index。
		/// dataIndexInside 指的是 dataItem 在当前数据窗口（参见 dataZoom）中的 index。
		/// 
		/// renderItem.arguments.api 中使用的参数都是 dataIndexInside 而非 dataIndex，因为从 dataIndex 转换成 dataIndexInside 需要时间开销。
		/// </summary>
		[JsonProperty("params")]
		public object Params { get; set; }

		/// <summary>
		/// renderItem 函数的第二个参数。
		/// </summary>
		[JsonProperty("api")]
		public SeriesCustom_RenderItem_Arguments_Api Api { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_Arguments_Api
	{
		/// <summary>
		/// 得到给定维度的数据值。
		/// @param {number} dimension 指定的维度（维度从 0 开始计数）。
		/// @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		/// @return {number} 给定维度上的值。
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// 将数据值映射到坐标系上。
		/// @param {Array.<number>} data 数据值。
		/// @return {Array.<number>} 画布上的点的坐标，至少包含：[x, y]
		///         对于polar坐标系，还会包含其他信息：
		///         polar: [x, y, radius, angle]
		/// </summary>
		[JsonProperty("coord")]
		public string Coord { get; set; }

		/// <summary>
		/// 给定数据范围，映射到坐标系上后的长度。
		/// 例如，cartesian2d中，api.size([2, 4]) 返回 [12.4, 55]，表示 x 轴数据范围为 2 映射得到长度是 12.4，y 轴数据范围为 4 时应设得到长度为 55。
		/// 在一些坐标系中，如极坐标系（polar）或者有 log 数轴的坐标系，不同点的长度是不同的，所以需要第二个参数，指定获取长度的点。
		/// @param {Array.<number>} dataSize 数据范围。
		/// @param {Array.<number>} dataItem 获取长度的点。
		/// @return {Array.<number>} 画布上的长度
		/// </summary>
		[JsonProperty("size")]
		public string Size { get; set; }

		/// <summary>
		/// 能得到 series.itemStyle 中定义的样式信息和视觉映射得到的样式信息，可直接用于绘制图元。也可以用这种方式覆盖这些样式信息：api.style({fill: 'green', stroke: 'yellow'})。
		/// @param {Object} [extra] 额外指定的样式信息。
		/// @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		/// @return {Object} 直接用于绘制图元的样式信息。
		/// </summary>
		[JsonProperty("style")]
		public string Style { get; set; }

		/// <summary>
		/// 能得到 series.itemStyle.emphasis 中定义的样式信息和视觉映射的样式信息，可直接用于绘制图元。也可以用这种方式覆盖这些样式信息：api.style({fill: 'green', stroke: 'yellow'})。
		/// @param {Object} [extra] 额外指定的样式信息。
		/// @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		/// @return {Object} 直接用于绘制图元的样式信息。
		/// </summary>
		[JsonProperty("styleEmphasis")]
		public string StyleEmphasis { get; set; }

		/// <summary>
		/// 得到视觉映射的样式信息。比较少被使用。
		/// @param {string} visualType 'color', 'symbol', 'symbolSize', ...
		/// @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		/// @return {string|number} 视觉映射的样式值。
		/// </summary>
		[JsonProperty("visual")]
		public string Visual { get; set; }

		/// <summary>
		/// 当需要采用 barLayout 的时候，比如向柱状图上附加些东西，可以用这个方法得到 layout 信息。
		/// 参见 例子。
		/// @param {Object} opt
		/// @param {number} opt.count 每个簇有多少个 bar。
		/// @param {number|string} [opt.barWidth] bar 宽度。
		///         可以是绝对值例如 `40` 或者百分数例如 `'60%'`。
		///         百分数基于自动计算出的每一类目的宽度。
		/// @param {number|string} [opt.barMaxWidth] bar 最大宽度。
		///         可以是绝对值例如 `40` 或者百分数例如 `'60%'`。
		///         百分数基于自动计算出的每一类目的宽度。
		///         比 `opt.barWidth` 优先级高。
		/// @param {number|string} [opt.barMinWidth] bar 最小宽度。
		///         可以是绝对值例如 `40` 或者百分数例如 `'60%'`。
		///         百分数基于自动计算出的每一类目的宽度。
		///         比 `opt.barWidth` 优先级高。
		/// @param {number} [opt.barGap] 每个簇的 bar 之间的宽度。
		/// @param {number} [opt.barCategoryGap] 不同簇间的宽度。
		/// @return {Array.<Object>} [{
		///         width: number bar 的宽度。
		///         offset: number bar 的偏移量，以bar最左为基准。
		///         offsetCenter: number bar 的偏移量，以bar中心为基准。
		///     }, ...]
		/// </summary>
		[JsonProperty("barLayout")]
		public string BarLayout { get; set; }

		/// <summary>
		/// 得到系列的 当前index。注意这个 index 不同于系列定义时的 index。这个 index 是当 legend 组件进行了系列筛选后，剩余的系列排列后的 index。
		/// @return {number}
		/// </summary>
		[JsonProperty("currentSeriesIndices")]
		public string CurrentSeriesIndices { get; set; }

		/// <summary>
		/// 得到可以直接进行样式设置的文字信息字符串。
		/// @param {Object} opt
		/// @param {string} [opt.fontStyle]
		/// @param {number} [opt.fontWeight]
		/// @param {number} [opt.fontSize]
		/// @param {string} [opt.fontFamily]
		/// @return {string} font 字符串。
		/// </summary>
		[JsonProperty("font")]
		public string Font { get; set; }

		/// <summary>
		/// @return {number} echarts 容器的宽度。
		/// </summary>
		[JsonProperty("getWidth")]
		public string GetWidth { get; set; }

		/// <summary>
		/// @return {number} echarts 容器的高度。
		/// </summary>
		[JsonProperty("getHeight")]
		public string GetHeight { get; set; }

		/// <summary>
		/// @return {module:zrender} zrender 实例。
		/// </summary>
		[JsonProperty("getZr")]
		public string GetZr { get; set; }

		/// <summary>
		/// @return {number} 得到当前 devicePixelRatio。
		/// </summary>
		[JsonProperty("getDevicePixelRatio")]
		public string GetDevicePixelRatio { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnGroup
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "group";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("diffChildrenByName")]
		public bool? DiffChildrenByName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("children")]
		public double[] Children { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnPath
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "path";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public SeriesCustom_RenderItem_ReturnPath_Shape Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnPath_Shape
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("pathData")]
		public string PathData { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("d")]
		public string D { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("layout")]
		public string Layout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnImage
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "image";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style0 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnText
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "text";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style1 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnRect
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "rect";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape0 Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnCircle
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "circle";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape1 Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnRing
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "ring";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape2 Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnSector
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "sector";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape3 Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnPolygon
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "polygon";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape4 Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnLine
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "line";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape5 Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnBezierCurve
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "bezierCurve";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape6 Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Extra0
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Emphasis10
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public object Style { get; set; }
	}


	/// <summary>
	/// 系列中的数据内容数组。数组项通常为具体的数据项。
	/// 注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
	/// 可以使用 series.datasetIndex 指定其他的 dataset。
	/// 通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
	/// series: [{
	///     data: [
	///         // 维度X   维度Y   其他维度 ...
	///         [  3.4,    4.5,   15,   43],
	///         [  4.2,    2.3,   20,   91],
	///         [  10.8,   9.5,   30,   18],
	///         [  7.2,    8.8,   18,   57]
	///     ]
	/// }]
	/// 
	/// 
	/// 在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
	/// 在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
	/// 后面的其他维度是可选的，可以在别处被使用，例如：
	/// 在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
	/// 在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
	/// 使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
	/// 
	/// 
	/// 
	/// 特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
	/// xAxis: {
	///     data: ['a', 'b', 'm', 'n']
	/// },
	/// series: [{
	///     // 与 xAxis.data 一一对应。
	///     data: [23,  44,  55,  19]
	///     // 它其实是下面这种形式的简化：
	///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
	/// }]
	/// 
	/// 『值』与 轴类型 的关系：
	/// 
	/// 当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
	///   其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
	/// 
	/// 当某维度对应于类目轴（axis.type 为 'category'）的时候：
	///   其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
	///   xAxis: {
	///       type: 'category',
	///       data: ['星期一', '星期二', '星期三', '星期四']
	///   },
	///   yAxis: {
	///       type: 'category',
	///       data: ['a', 'b', 'm', 'n', 'p', 'q']
	///   },
	///   series: [{
	///       data: [
	///           // xAxis    yAxis
	///           [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
	///           [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
	///           [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
	///           [  3,        3,    5  ]
	///       ]
	///   }]
	/// 
	///   双类目轴的示例可以参考 Github Punchcard 示例。
	/// 
	/// 当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
	/// 
	/// 一个时间戳，如 1484141700832，表示 UTC 时间。
	/// 或者字符串形式的时间描述：
	/// ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
	/// 部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
	/// 使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
	/// 时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
	/// 
	/// 
	/// 其他的时间字符串，包括（均表示本地时间）:
	/// '2012', '2012-3-1', '2012/3/1', '2012/03/01',
	/// '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
	/// 
	/// 
	/// 或者用户自行初始化的 Date 实例：
	/// 注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
	/// 例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01') 表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
	/// 所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 当需要对个别数据进行个性化定义时：
	/// 数组项可用对象，其中的 value 像表示具体的数值，如：
	/// [
	///     12,
	///     34,
	///     {
	///         value : 56,
	///         //自定义标签样式，仅对该数据项有效
	///         label: {},
	///         //自定义特殊 itemStyle，仅对该数据项有效
	///         itemStyle:{}
	///     },
	///     10
	/// ]
	/// // 或
	/// [
	///     [12, 33],
	///     [34, 313],
	///     {
	///         value: [56, 44],
	///         label: {},
	///         itemStyle:{}
	///     },
	///     [10, 33]
	/// ]
	/// 
	/// 空值：
	/// 当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
	/// 例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
	/// </summary>
	public class SeriesCustom_Data
	{
		/// <summary>
		/// 数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 单个数据项的数值。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 该数据项的组 ID。当全局过渡动画功能开启时，setOption 前后拥有相同组 ID 的数据项会进行动画过渡。
		/// 若没有指定groupId ，会尝试用series.dataGroupId作为该数据项的组 ID；若series.dataGroupId也没有指定，则会使用数据项的 ID 作为组 ID。
		/// 如果你使用了dataset组件来表达数据，推荐使用encode.itemGroupId来指定哪个维度被编码为组 ID。
		/// </summary>
		[JsonProperty("groupId")]
		public string GroupId { get; set; }

		/// <summary>
		/// 从 v5.5.0 开始支持
		/// 
		/// 该数据项对应的子数据组 ID，用于实现多层下钻和聚合。
		/// 
		/// 
		/// 
		/// 通过groupId已经可以达到数据下钻和聚合的效果，但只支持一层的下钻和聚合。为了实现多层下钻和聚合，我们又引入了childGroupId。
		/// 引入childGroupId后，不同option的数据项之间就能形成逻辑上的父子关系，例如：
		/// data: [                        data: [                        data: [
		///   {                              {                              {
		///     name: 'Animals',               name: 'Dogs',                  name: 'Corgi',
		///     value: 3,                      value: 3,                      value: 5,
		///     groupId: 'things',             groupId: 'animals',            groupId: 'dogs'
		///     childGroupId: 'animals'        childGroupId: 'dogs'         },
		///   },                             },                             {
		///   {                              {                                name: 'Bulldog',
		///     name: 'Fruits',                name: 'Cats',                  value: 6,
		///     value: 3,                      value: 4,                      groupId: 'dogs'
		///     groupId: 'things',             groupId: 'animals',          },
		///     childGroupId: 'fruits'         childGroupId: 'cats',        {
		///   },                             },                               name: 'Shiba Inu',
		///   {                              {                                value: 7,
		///     name: 'Cars',                  name: 'Birds',                 groupId: 'dogs'
		///     value: 2,                      value: 3,                    }
		///     groupId: 'things',             groupId: 'animals',        ]
		///     childGroupId: 'cars'           childGroupId: 'birds'
		///   }                              }
		/// ]                              ]
		/// 
		/// 上面 3 组 data 分别来自 3 个 option ，通过groupId和childGroupId，它们之间存在了“父-子-孙”的关系。在setOption时，Apache ECharts 会尝试寻找前后option数据项间的父子关系，若存在父子关系，则会对相关数据项进行下钻或聚合动画的过渡。
		/// 没有对应子数据组的数据项不需要指定childGroupId。
		/// 如果你使用了dataset组件来表达数据，推荐使用encode.itemChildGroupId来指定哪个维度被编码为子数据组 ID。
		/// </summary>
		[JsonProperty("childGroupId")]
		public string ChildGroupId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Blur10 Emphasis { get; set; }

		/// <summary>
		/// 本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}
}