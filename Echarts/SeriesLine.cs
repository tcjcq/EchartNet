using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 折线/面积图
	/// 折线图是用折线将各个数据点标志连接起来的图表，用于展现数据的变化趋势。可用于直角坐标系和极坐标系上。
	/// Tip: 设置 areaStyle 后可以绘制面积图。
	/// Tip: 配合分段型 visualMap 组件可以将折线/面积图通过不同颜色分区间。如下示例
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class SeriesLine
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

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
		/// 该系列使用的坐标系，可选：
		/// 
		/// 'cartesian2d'
		///   使用二维的直角坐标系（也称笛卡尔坐标系），通过 xAxisIndex, yAxisIndex指定相应的坐标轴组件。
		/// 
		/// 
		/// 
		/// 'polar'
		///   使用极坐标系，通过 polarIndex 指定相应的极坐标组件
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
		/// 标记的图形。
		/// ECharts 提供的标记类型包括
		/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// 如果需要每个数据的图形不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => string
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// 标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// 如果需要每个数据的图形大小不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => number|Array
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// </summary>
		[JsonProperty("symbolSize")]
		public StringOrNumber SymbolSize { get; set; }

		/// <summary>
		/// 标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// 如果需要每个数据的旋转角度不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => number
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// 
		/// 从 4.8.0 开始支持回调函数。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public StringOrNumber SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// 标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 是否显示 symbol, 如果 false 则只有在 tooltip hover 的时候显示。
		/// </summary>
		[JsonProperty("showSymbol")]
		public bool? ShowSymbol { get; set; }

		/// <summary>
		/// 只在主轴为类目轴（axis.type 为 'category'）时有效。
		/// 可选值：
		/// 
		/// 'auto'：默认，如果有足够空间则显示标志图形，否则随主轴标签间隔隐藏策略。
		/// true：显示所有图形。
		/// false：随主轴标签间隔隐藏策略。
		/// </summary>
		[JsonProperty("showAllSymbol")]
		public bool? ShowAllSymbol { get; set; }

		/// <summary>
		/// 是否启用图例 hover 时的联动高亮。
		/// </summary>
		[JsonProperty("legendHoverLink")]
		public bool? LegendHoverLink { get; set; }

		/// <summary>
		/// 数据堆叠，同个类目轴上系列配置相同的 stack 值可以堆叠放置。关于如何定制数值的堆叠方式，参见 stackStrategy。
		/// 注：目前 stack 只支持堆叠于 'value' 和 'log' 类型的类目轴上，不支持 'time' 和 'category' 类型的类目轴。
		/// 下面示例可以通过右上角 toolbox 中的堆叠切换看效果：
		/// </summary>
		[JsonProperty("stack")]
		public string Stack { get; set; }

		/// <summary>
		/// 从 v5.3.3 开始支持
		/// 
		/// 堆积数值的策略，前提是stack属性已被设置。其值可以是：
		/// 
		/// 'samesign' 只在要堆叠的值与当前累积的堆叠值具有相同的正负符号时才堆叠。
		/// 'all' 堆叠所有的值，不管当前或累积的堆叠值的正负符号是什么。
		/// 'positive' 只堆积正值。
		/// 'negative' 只堆叠负值。
		/// </summary>
		[JsonProperty("stackStrategy")]
		public string StackStrategy { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 是否连接空数据。
		/// </summary>
		[JsonProperty("connectNulls")]
		public bool? ConnectNulls { get; set; }

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
		/// 从 v5.2.2 开始支持
		/// 
		/// 线条和区域面积是否触发事件
		/// </summary>
		[JsonProperty("triggerLineEvent")]
		public bool? TriggerLineEvent { get; set; }

		/// <summary>
		/// 是否是阶梯线图。可以设置为 true 显示成阶梯线图，也支持设置成 'start', 'middle', 'end' 分别配置在当前点，当前点与下个点的中间点，下个点拐弯。
		/// 不同的配置效果如下：
		/// </summary>
		[JsonProperty("step")]
		public StringOrBool Step { get; set; }

		/// <summary>
		/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
		/// </summary>
		[JsonProperty("label")]
		public Label6 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 折线端点的标签。
		/// </summary>
		[JsonProperty("endLabel")]
		public SeriesLine_EndLabel EndLabel { get; set; }

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
		/// 折线拐点标志的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 线条样式。
		/// 注： 修改 lineStyle 中的颜色不会影响图例颜色，如果需要图例颜色和折线图颜色一致，需修改 itemStyle.color，线条颜色默认也会取该颜色。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// 区域填充样式。设置后显示成区域面积图。
		/// </summary>
		[JsonProperty("areaStyle")]
		public SeriesLine_AreaStyle AreaStyle { get; set; }

		/// <summary>
		/// 折线图的高亮状态。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesLine_Emphasis Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 折线图的淡出状态。开启 emphasis.focus 后有效。
		/// </summary>
		[JsonProperty("blur")]
		public SeriesLine_Blur Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 折线图的选中状态。开启 selectedMode 后有效。
		/// </summary>
		[JsonProperty("select")]
		public SeriesLine_Select Select { get; set; }

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
		/// 是否平滑曲线显示。
		/// 如果是 boolean 类型，则表示是否开启平滑处理。如果是 number 类型（取值范围 0 到 1），表示平滑程度，越小表示越接近折线段，反之则反。设为 true 时相当于设为 0.5。
		/// 如果需要修改平滑算法，请参考 smoothMonotone。
		/// </summary>
		[JsonProperty("smooth")]
		public NumberOrBool Smooth { get; set; }

		/// <summary>
		/// 折线平滑后是否在一个维度上保持单调性，可以设置成'x', 'y'来指明是在 x 轴或者 y 轴上保持单调性。
		/// 通常在双数值轴上使用。
		/// 下面两张图分别是双数值轴中的折线图smoothMonotone不设置以及设置为'x'的区别。
		/// 
		/// 不设置smoothMonotone:
		/// 
		/// 
		/// 
		/// 设置为 'x':
		/// </summary>
		[JsonProperty("smoothMonotone")]
		public string SmoothMonotone { get; set; }

		/// <summary>
		/// 折线图在数据量远大于像素点时候的降采样策略，开启后可以有效的优化图表的绘制效率，默认关闭，也就是全部绘制不过滤数据点。
		/// 可选：
		/// 
		/// 'lttb' 采用 Largest-Triangle-Three-Bucket 算法，可以最大程度保证采样后线条的趋势，形状和极值。
		/// 'average' 取过滤点的平均值
		/// 'min' 取过滤点的最小值
		/// 'max' 取过滤点的最大值
		/// 'minmax' 取过滤点绝对值的最大极值 (从 v5.5.0 开始支持)
		/// 'sum' 取过滤点的和
		/// </summary>
		[JsonProperty("sampling")]
		public string Sampling { get; set; }

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
		public SeriesLine_Data[] Data { get; set; }

		/// <summary>
		/// 图表标注。
		/// </summary>
		[JsonProperty("markPoint")]
		public SeriesLine_MarkPoint MarkPoint { get; set; }

		/// <summary>
		/// 图表标线。
		/// </summary>
		[JsonProperty("markLine")]
		public SeriesPictorialBar_MarkLine MarkLine { get; set; }

		/// <summary>
		/// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
		/// </summary>
		[JsonProperty("markArea")]
		public SeriesPictorialBar_MarkArea MarkArea { get; set; }

		/// <summary>
		/// 折线图所有图形的 zlevel 值。
		/// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
		/// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 折线图组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
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
	/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	public class Label6
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签的位置。
		/// 
		/// 可以通过内置的语义声明位置：
		///   示例：
		///   position: 'top'
		/// 
		///   支持：top / left / right / bottom / inside / insideLeft / insideRight / insideTop / insideBottom / insideTopLeft / insideBottomLeft / insideTopRight / insideBottomRight
		/// 
		/// 也可以用一个数组表示相对的百分比或者绝对像素值表示标签相对于图形包围盒左上角的位置。
		///   示例：
		///   // 绝对的像素值
		///   position: [10, 10],
		///   // 相对的百分比
		///   position: ['50%', '50%']
		/// 
		/// 
		/// 
		/// 参见：label position。
		/// </summary>
		[JsonProperty("position")]
		public ArrayOrSingle Position { get; set; }

		/// <summary>
		/// 距离图形元素的距离。
		/// 当 position 为字符描述值（如 'top'、'insideRight'）时候有效。
		/// 参见：label position。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 标签旋转。从 -90 度到 90 度。正值是逆时针。
		/// 参见：label rotation。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 是否对文字进行偏移。默认不偏移。例如：[30, 40] 表示文字在横向上偏移 30，纵向上偏移 40。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 用于控制标签之间的最小距离，当启用 labelLayout 时可能会用到。
		/// </summary>
		[JsonProperty("minMargin")]
		public double? MinMargin { get; set; }

		/// <summary>
		/// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		/// 字符串模板
		/// 模板变量有：
		/// 
		/// {a}：系列名。
		/// {b}：数据名。
		/// {c}：数据值。
		/// {@xxx}：数据中名为 'xxx' 的维度的值，如 {@product} 表示名为 'product' 的维度的值。
		/// {@[n]}：数据中维度 n 的值，如 {@[3]} 表示维度 3 的值，从 0 开始计数。
		/// 
		/// 示例：
		/// formatter: '{b}: {@score}'
		/// 
		/// 回调函数
		/// 回调函数格式：
		/// (params: Object|Array) => string
		/// 
		/// 参数 params 是 formatter 需要的单个数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 文字水平对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// 
		/// rich 中如果没有设置 align，则会取父层级的 align。例如：
		/// {
		///     align: right,
		///     rich: {
		///         a: {
		///             // 没有设置 `align`，则 `align` 为 right
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 文字垂直对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'top'
		/// 'middle'
		/// 'bottom'
		/// 
		/// rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
		/// {
		///     verticalAlign: bottom,
		///     rich: {
		///         a: {
		///             // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
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
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线端点的标签。
	/// </summary>
	public class SeriesLine_EndLabel
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 距离图形元素的距离。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 标签旋转。从 -90 度到 90 度。正值是逆时针。
		/// 参见：label rotation。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 是否对文字进行偏移。默认不偏移。例如：[30, 40] 表示文字在横向上偏移 30，纵向上偏移 40。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 用于控制标签之间的最小距离，当启用 labelLayout 时可能会用到。
		/// </summary>
		[JsonProperty("minMargin")]
		public double? MinMargin { get; set; }

		/// <summary>
		/// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		/// 字符串模板
		/// 模板变量有：
		/// 
		/// {a}：系列名。
		/// {b}：数据名。
		/// {c}：数据值。
		/// {@xxx}：数据中名为 'xxx' 的维度的值，如 {@product} 表示名为 'product' 的维度的值。
		/// {@[n]}：数据中维度 n 的值，如 {@[3]} 表示维度 3 的值，从 0 开始计数。
		/// 
		/// 示例：
		/// formatter: '{b}: {@score}'
		/// 
		/// 回调函数
		/// 回调函数格式：
		/// (params: Object|Array) => string
		/// 
		/// 参数 params 是 formatter 需要的单个数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 文字水平对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// 
		/// rich 中如果没有设置 align，则会取父层级的 align。例如：
		/// {
		///     align: right,
		///     rich: {
		///         a: {
		///             // 没有设置 `align`，则 `align` 为 right
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 文字垂直对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'top'
		/// 'middle'
		/// 'bottom'
		/// 
		/// rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
		/// {
		///     verticalAlign: bottom,
		///     rich: {
		///         a: {
		///             // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
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
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }

		/// <summary>
		/// 是否开启标签的数字动画。
		/// </summary>
		[JsonProperty("valueAnimation")]
		public bool? ValueAnimation { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 标签的视觉引导线配置。
	/// </summary>
	public class LabelLine1
	{
		/// <summary>
		/// 是否显示视觉引导线。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 是否显示在图形上方。
		/// </summary>
		[JsonProperty("showAbove")]
		public bool? ShowAbove { get; set; }

		/// <summary>
		/// 视觉引导项第二段的长度。
		/// </summary>
		[JsonProperty("length2")]
		public double? Length2 { get; set; }

		/// <summary>
		/// 是否平滑视觉引导线，默认不平滑，可以设置成 true 平滑显示，也可以设置为 0 到 1 的值，表示平滑程度。
		/// </summary>
		[JsonProperty("smooth")]
		public NumberOrBool Smooth { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 通过调整第二段线的长度，限制引导线两端之间最小的夹角，以防止过小的夹角导致显示不美观。
		/// 可以设置为 0 - 180 度。
		/// </summary>
		[JsonProperty("minTurnAngle")]
		public double? MinTurnAngle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}

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
	public class LabelLayout0
	{
		/// <summary>
		/// 是否隐藏重叠的标签。
		/// 下面示例演示了在关系图中开启该配置后，在缩放时可以实现自动的标签隐藏。
		/// </summary>
		[JsonProperty("hideOverlap")]
		public bool? HideOverlap { get; set; }

		/// <summary>
		/// 在标签重叠的时候是否挪动标签位置以防止重叠。
		/// 目前支持配置为：
		/// 
		/// 'shiftX' 水平方向依次位移，在水平方向对齐时使用
		/// 'shiftY' 垂直方向依次位移，在垂直方向对齐时使用
		/// 
		/// 下面是标签右对齐并配置垂直方向依次位移以防止重叠的示例。
		/// </summary>
		[JsonProperty("moveOverlap")]
		public string MoveOverlap { get; set; }

		/// <summary>
		/// 标签的 x 位置。支持绝对的像素值或者'20%'这样的相对值。
		/// </summary>
		[JsonProperty("x")]
		public StringOrNumber X { get; set; }

		/// <summary>
		/// 标签的 y 位置。支持绝对的像素值或者'20%'这样的相对值。
		/// </summary>
		[JsonProperty("y")]
		public StringOrNumber Y { get; set; }

		/// <summary>
		/// 标签在 x 方向上的像素偏移。可以和x一起使用。
		/// </summary>
		[JsonProperty("dx")]
		public double? Dx { get; set; }

		/// <summary>
		/// 标签在 y 方向上的像素偏移。可以和y一起使用
		/// </summary>
		[JsonProperty("dy")]
		public double? Dy { get; set; }

		/// <summary>
		/// 标签旋转角度。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 标签显示的宽度。可以配合overflow使用控制标签显示在固定宽度内
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 标签显示的高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 标签水平对齐方式。可以设置'left', 'center', 'right'。
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 标签垂直对齐方式。可以设置'top', 'middle', 'bottom'。
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// The text size of the label.
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 标签是否可以允许用户通过拖拽二次调整位置。
		/// </summary>
		[JsonProperty("draggable")]
		public bool? Draggable { get; set; }

		/// <summary>
		/// 标签引导线三个点的位置。格式为：
		/// [[x, y], [x, y], [x, y]]
		/// 
		/// 在饼图中常用来微调已经计算好的引导线，其它情况一般不建议设置。
		/// </summary>
		[JsonProperty("labelLinePoints")]
		public double[] LabelLinePoints { get; set; }
	}

	/// <summary>
	/// 区域填充样式。设置后显示成区域面积图。
	/// </summary>
	public class SeriesLine_AreaStyle
	{
		/// <summary>
		/// 填充的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 图形区域的起始位置。
		/// 默认情况下，图形会从坐标轴轴线到数据间进行填充。如果需要填充的区域是坐标轴最大值到数据间，或者坐标轴最小值到数据间，或者某个数值到数据间则可以通过这个配置项进行设置。
		/// 可选值包括：
		/// 
		/// 'auto' 填充坐标轴轴线到数据间的区域（默认值）
		/// 'start' 填充坐标轴底部（非 inverse 情况是最小值）到数据间的区域
		/// 'end' 填充坐标轴顶部（非 inverse 情况是最大值）到数据间的区域
		/// number 填充指定数值到数据间的区域（从 v5.3.2 开始支持）
		/// </summary>
		[JsonProperty("origin")]
		public StringOrNumber Origin { get; set; }

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
	/// 折线图的高亮状态。
	/// </summary>
	public class SeriesLine_Emphasis
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 是否开启 hover 在拐点标志上的放大效果。从 5.3.2 版本开始支持 number，用以设置高亮放大倍数，默认放大 1.1 倍。
		/// </summary>
		[JsonProperty("scale")]
		public NumberOrBool Scale { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 
		/// 
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// 
		/// 示例：
		/// 下面代码配置了柱状图在高亮一个图形的时候，淡出当前直角坐标系所有其它的系列。
		/// emphasis: {
		///     focus: 'series',
		///     blurScope: 'coordinateSystem'
		/// }
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("areaStyle")]
		public ShadowStyle0 AreaStyle { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("endLabel")]
		public SeriesLine_Select_EndLabel EndLabel { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class SeriesLine_Blur
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("areaStyle")]
		public ShadowStyle0 AreaStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("endLabel")]
		public SeriesLine_Select_EndLabel EndLabel { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线图的选中状态。开启 selectedMode 后有效。
	/// </summary>
	public class SeriesLine_Select
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public XAxis_MinorSplitLine LabelLine { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("areaStyle")]
		public ShadowStyle0 AreaStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("endLabel")]
		public SeriesLine_Select_EndLabel EndLabel { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线端点的标签。
	/// </summary>
	public class SeriesLine_Select_EndLabel
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签旋转。从 -90 度到 90 度。正值是逆时针。
		/// 参见：label rotation。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 是否对文字进行偏移。默认不偏移。例如：[30, 40] 表示文字在横向上偏移 30，纵向上偏移 40。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		/// 字符串模板
		/// 模板变量有：
		/// 
		/// {a}：系列名。
		/// {b}：数据名。
		/// {c}：数据值。
		/// {@xxx}：数据中名为 'xxx' 的维度的值，如 {@product} 表示名为 'product' 的维度的值。
		/// {@[n]}：数据中维度 n 的值，如 {@[3]} 表示维度 3 的值，从 0 开始计数。
		/// 
		/// 示例：
		/// formatter: '{b}: {@score}'
		/// 
		/// 回调函数
		/// 回调函数格式：
		/// (params: Object|Array) => string
		/// 
		/// 参数 params 是 formatter 需要的单个数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 文字水平对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// 
		/// rich 中如果没有设置 align，则会取父层级的 align。例如：
		/// {
		///     align: right,
		///     rich: {
		///         a: {
		///             // 没有设置 `align`，则 `align` 为 right
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 文字垂直对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'top'
		/// 'middle'
		/// 'bottom'
		/// 
		/// rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
		/// {
		///     verticalAlign: bottom,
		///     rich: {
		///         a: {
		///             // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
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
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }
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
	public class SeriesLine_Data
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
		/// 单个数据标记的图形。
		/// ECharts 提供的标记类型包括
		/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// 单个数据标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// 单个数据标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// 单个数据标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 单个拐点文本的样式设置。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标签的视觉引导线配置。
		/// </summary>
		[JsonProperty("labelLine")]
		public LabelLine1 LabelLine { get; set; }

		/// <summary>
		/// 单个拐点标志的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 单个拐点的高亮样式和标签设置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis0 Emphasis { get; set; }

		/// <summary>
		/// 单个拐点的淡出样式和标签设置。
		/// </summary>
		[JsonProperty("blur")]
		public Blur1 Blur { get; set; }

		/// <summary>
		/// 单个拐点的选中样式和标签设置。
		/// </summary>
		[JsonProperty("select")]
		public Emphasis0 Select { get; set; }

		/// <summary>
		/// 本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}

	/// <summary>
	/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	public class Label3
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签的位置。
		/// 
		/// 可以通过内置的语义声明位置：
		///   示例：
		///   position: 'top'
		/// 
		///   支持：top / left / right / bottom / inside / insideLeft / insideRight / insideTop / insideBottom / insideTopLeft / insideBottomLeft / insideTopRight / insideBottomRight
		/// 
		/// 也可以用一个数组表示相对的百分比或者绝对像素值表示标签相对于图形包围盒左上角的位置。
		///   示例：
		///   // 绝对的像素值
		///   position: [10, 10],
		///   // 相对的百分比
		///   position: ['50%', '50%']
		/// 
		/// 
		/// 
		/// 参见：label position。
		/// </summary>
		[JsonProperty("position")]
		public ArrayOrSingle Position { get; set; }

		/// <summary>
		/// 距离图形元素的距离。
		/// 当 position 为字符描述值（如 'top'、'insideRight'）时候有效。
		/// 参见：label position。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 标签旋转。从 -90 度到 90 度。正值是逆时针。
		/// 参见：label rotation。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 是否对文字进行偏移。默认不偏移。例如：[30, 40] 表示文字在横向上偏移 30，纵向上偏移 40。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 用于控制标签之间的最小距离，当启用 labelLayout 时可能会用到。
		/// </summary>
		[JsonProperty("minMargin")]
		public double? MinMargin { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 文字水平对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// 
		/// rich 中如果没有设置 align，则会取父层级的 align。例如：
		/// {
		///     align: right,
		///     rich: {
		///         a: {
		///             // 没有设置 `align`，则 `align` 为 right
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 文字垂直对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'top'
		/// 'middle'
		/// 'bottom'
		/// 
		/// rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
		/// {
		///     verticalAlign: bottom,
		///     rich: {
		///         a: {
		///             // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
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
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }
	}

	/// <summary>
	/// 折线图的高亮状态。
	/// </summary>
	public class Emphasis0
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class Blur1
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label5 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}

	/// <summary>
	/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	public class Label5
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签的位置。
		/// 
		/// 可以通过内置的语义声明位置：
		///   示例：
		///   position: 'top'
		/// 
		///   支持：top / left / right / bottom / inside / insideLeft / insideRight / insideTop / insideBottom / insideTopLeft / insideBottomLeft / insideTopRight / insideBottomRight
		/// 
		/// 也可以用一个数组表示相对的百分比或者绝对像素值表示标签相对于图形包围盒左上角的位置。
		///   示例：
		///   // 绝对的像素值
		///   position: [10, 10],
		///   // 相对的百分比
		///   position: ['50%', '50%']
		/// 
		/// 
		/// 
		/// 参见：label position。
		/// </summary>
		[JsonProperty("position")]
		public ArrayOrSingle Position { get; set; }

		/// <summary>
		/// 距离图形元素的距离。
		/// 当 position 为字符描述值（如 'top'、'insideRight'）时候有效。
		/// 参见：label position。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 标签旋转。从 -90 度到 90 度。正值是逆时针。
		/// 参见：label rotation。
		/// </summary>
		[JsonProperty("rotate")]
		public double? Rotate { get; set; }

		/// <summary>
		/// 是否对文字进行偏移。默认不偏移。例如：[30, 40] 表示文字在横向上偏移 30，纵向上偏移 40。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 文字水平对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'left'
		/// 'center'
		/// 'right'
		/// 
		/// rich 中如果没有设置 align，则会取父层级的 align。例如：
		/// {
		///     align: right,
		///     rich: {
		///         a: {
		///             // 没有设置 `align`，则 `align` 为 right
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		/// 文字垂直对齐方式，默认自动。
		/// 可选：
		/// 
		/// 'top'
		/// 'middle'
		/// 'bottom'
		/// 
		/// rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：
		/// {
		///     verticalAlign: bottom,
		///     rich: {
		///         a: {
		///             // 没有设置 `verticalAlign`，则 `verticalAlign` 为 bottom
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("verticalAlign")]
		public string VerticalAlign { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
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
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }
	}


	/// <summary>
	/// 图表标注。
	/// </summary>
	public class SeriesLine_MarkPoint
	{
		/// <summary>
		/// 标记的图形。
		/// ECharts 提供的标记类型包括
		/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// 如果需要每个数据的图形不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => string
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// 标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// 如果需要每个数据的图形大小不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => number|Array
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// </summary>
		[JsonProperty("symbolSize")]
		public StringOrNumber SymbolSize { get; set; }

		/// <summary>
		/// 标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// 如果需要每个数据的旋转角度不一样，可以设置为如下格式的回调函数：
		/// (value: Array|number, params: Object) => number
		/// 
		/// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
		/// 
		/// 从 4.8.0 开始支持回调函数。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public StringOrNumber SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// 标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 标注的文本。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 标注的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 标注的高亮样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标注的淡出样式。淡出的规则跟随所在系列。
		/// </summary>
		[JsonProperty("blur")]
		public Blur2 Blur { get; set; }

		/// <summary>
		/// 标注的数据数组。每个数组项是一个对象，有下面几种方式指定标注的位置。
		/// 
		/// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
		/// 
		/// 
		/// 用 coord 属性指定数据在相应坐标系上的坐标位置，单个维度支持设置 'min', 'max', 'average'。
		/// 
		/// 直接用 type 属性标注系列中的最大值，最小值。这时候可以使用 valueIndex 或者 valueDim 指定是在哪个维度上的最大值、最小值、平均值。
		/// 
		/// 
		/// 当多个属性同时存在时，优先级按上述的顺序。
		/// 示例：
		/// data: [
		///     {
		///         name: '最大值',
		///         type: 'max'
		///     }, 
		///     {
		///         name: '某个坐标',
		///         coord: [10, 20]
		///     }, {
		///         name: '固定 x 像素位置',
		///         yAxis: 10,
		///         x: '90%'
		///     }, 
		/// 
		///     {
		///         name: '某个屏幕坐标',
		///         x: 100,
		///         y: 100
		///     }
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesLine_MarkPoint_Data[] Data { get; set; }

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
	public class SeriesLine_MarkPoint_Data
	{
		/// <summary>
		/// 标注名称。定义后可在 label formatter 中作为数据名 {b} 模板变量使用。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 特殊的标注类型，用于标注最大值最小值等。
		/// 可选:
		/// 
		/// 'min' 最小值。
		/// 'max' 最大值。
		/// 'average' 平均值。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// 在使用 type 时有效，用于指定在哪个维度上指定最大值最小值，可以是 0（xAxis, radiusAxis），1（yAxis, angleAxis），默认使用第一个数值轴所在的维度。
		/// </summary>
		[JsonProperty("valueIndex")]
		public double? ValueIndex { get; set; }

		/// <summary>
		/// 在使用 type 时有效，用于指定在哪个维度上指定最大值最小值。这可以是维度的直接名称，例如折线图时可以是x、angle等、candlestick 图时可以是open、close等维度名称。
		/// </summary>
		[JsonProperty("valueDim")]
		public string ValueDim { get; set; }

		/// <summary>
		/// 标注的坐标。坐标格式视系列的坐标系而定，可以是直角坐标系上的 x, y，也可以是极坐标系上的 radius, angle。例如 [121, 2323]、['aa', 998]。
		/// 注：对于 axis.type 为 'category' 类型的轴
		/// 
		/// 如果 coord 值为 number，则表示 axis.data 的 index。
		/// 如果 coord 值为 string，则表示 axis.data 中具体的值。注意使用这种方式时，xAxis.data 不能写成 [number, number, ...]，而只能写成 [string, string, ...]，否则不能被 markPoint / markLine 用『具体值』索引到。
		/// 
		/// 例如：
		/// {
		///     xAxis: {
		///         type: 'category',
		///         data: ['5', '6', '9', '13', '19', '33']
		///         // 注意这里不建议写成 [5, 6, 9, 13, 19, 33]，否则不能被 markPoint / markLine 用『具体值』索引到。
		///     },
		///     series: {
		///         type: 'line',
		///         data: [11, 22, 33, 44, 55, 66],
		///         markPoint: { // markLine 也是同理
		///             data: [{
		///                 coord: [5, 33.4], // 其中 5 表示 xAxis.data[5]，即 '33' 这个元素。
		///                 // coord: ['5', 33.4] // 其中 '5' 表示 xAxis.data中的 '5' 这个元素。
		///                                       // 注意，使用这种方式时，xAxis.data 不能写成 [number, number, ...]
		///                                       // 而只能写成 [string, string, ...]
		///             }]
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("coord")]
		public double[] Coord { get; set; }

		/// <summary>
		/// 相对容器的屏幕 x 坐标，单位像素。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 相对容器的屏幕 y 坐标，单位像素。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 标注值，可以不设。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 标记的图形。
		/// ECharts 提供的标记类型包括
		/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// 标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// 标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// 标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 该标注的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }
	}


	/// <summary>
	/// 图表标线。
	/// </summary>
	public class SeriesPictorialBar_MarkLine
	{
		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 标线两端的标记类型，可以是一个数组分别指定两端，也可以是单个统一指定，具体格式见 data.symbol。
		/// </summary>
		[JsonProperty("symbol")]
		public ArrayOrSingle Symbol { get; set; }

		/// <summary>
		/// 标线两端的标记大小，可以是一个数组分别指定两端，也可以是单个统一指定。
		/// 注意： 这里无法像一般的 symbolSize 那样通过数组分别指定高宽。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// 标线两端的标记相对于原本位置的偏移，可以是一个数组分别指定两端，也可以是单个统一指定。如果希望单独指定两端标记的水平/垂直偏移，也可以是一个二维数组，每个元素为单个标记的偏移量，例：
		/// symbolOffset: [
		///     [-10, 20],    // 起始标记偏移
		///     ['50%', 100]  // 结束标记偏移
		/// ]
		/// 
		/// 
		/// 从 v5.1.0 开始支持
		/// </summary>
		[JsonProperty("symbolOffset")]
		public StringOrNumber[] SymbolOffset { get; set; }

		/// <summary>
		/// 标线数值的精度，在显示平均值线的时候有用。
		/// </summary>
		[JsonProperty("precision")]
		public double? Precision { get; set; }

		/// <summary>
		/// 标线的文本。
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }

		/// <summary>
		/// 标线的样式
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// 标线的高亮样式。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis2 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 标线的淡出样式。淡出的规则跟随所在系列。
		/// </summary>
		[JsonProperty("blur")]
		public Blur3 Blur { get; set; }

		/// <summary>
		/// 标线的数据数组。每个数组项可以是一个两个值的数组，分别表示线的起点和终点，每一项是一个对象，有下面几种方式指定起点或终点的位置。
		/// 
		/// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
		/// 
		/// 
		/// 用 coord 属性指定数据在相应坐标系上的坐标位置，单个维度支持设置 'min', 'max', 'average'。
		/// 
		/// 直接用 type 属性标注系列中的最大值，最小值。这时候可以使用 valueIndex 或者 valueDim 指定是在哪个维度上的最大值、最小值、平均值。
		/// 
		/// 如果是笛卡尔坐标系的话，也可以通过只指定 xAxis 或者 yAxis 来实现 X 轴或者 Y 轴为某值的标线，见示例 scatter-weight
		/// 
		/// 
		/// 当多个属性同时存在时，优先级按上述的顺序。
		/// 也可以是直接通过 type 设置该标线的类型，是最大值的线还是平均线。同样的，这时候可以通过使用 valueIndex 指定维度。
		/// data: [
		/// 
		/// {
		///         name: '平均线',
		///         // 支持 'average', 'min', 'max'
		///         type: 'average'
		///     },
		///     {
		///         name: 'Y 轴值为 100 的水平线',
		///         yAxis: 100
		///     },
		///     [
		///         {
		///             // 起点和终点的项会共用一个 name
		///             name: '最小值到最大值',
		///             type: 'min'
		///         },
		///         {
		///             type: 'max'
		///         }
		///     ],
		/// [
		///         {
		///             name: '两个坐标之间的标线',
		///             coord: [10, 20]
		///         },
		///         {
		///             coord: [20, 30]
		///         }
		///     ], [{
		///         // 固定起点的 x 像素位置，用于模拟一条指向最大值的水平线
		///         yAxis: 'max',
		///         x: '90%'
		///     }, {
		///         type: 'max'
		///     }],
		/// [
		///         {
		///             name: '两个屏幕坐标之间的标线',
		///             x: 100,
		///             y: 100
		///         },
		///         {
		///             x: 500,
		///             y: 200
		///         }
		///     ]
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesPictorialBar_MarkLine_Data Data { get; set; }

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
	}

	/// <summary>
	/// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	public class Label4
	{
		/// <summary>
		/// 是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 标签位置，可选：
		/// 
		/// 'start' 线的起始点。
		/// 'middle' 线的中点。
		/// 'end' 线的结束点。
		/// 
		/// 4.7.0 版本起，支持更多标签位置：'start', 'middle', 'end', 'insideStartTop', 'insideStartBottom', 'insideMiddleTop', 'insideMiddleBottom', 'insideEndTop', 'insideEndBottom'。
		/// 其中，'insideMiddleBottom' 等同于 'middle'。具体位置参见下图。
		/// 文字与线的间距可以通过 label.distance 调整。
		/// </summary>
		[JsonProperty("position")]
		public string Position { get; set; }

		/// <summary>
		/// 标签与线之间的间距。如果是数组，第一项为横向间距，第二项为纵向间距。如果是数字，则表示横向纵向使用相同的间距。
		/// </summary>
		[JsonProperty("distance")]
		public ArrayOrSingle Distance { get; set; }

		/// <summary>
		/// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		/// 字符串模板
		/// 字符串模板
		/// 模板变量有：
		/// 
		/// {a}：系列名。
		/// {b}：数据名。
		/// {c}：数据值。
		/// {d}：百分比。
		/// {@xxx}：数据中名为 'xxx' 的维度的值，如 {@product} 表示名为 'product' 的维度的值。
		/// {@[n]}：数据中维度 n 的值，如 {@[3]} 表示维度 3 的值，从 0 开始计数。
		/// 
		/// 示例：
		/// formatter: '{b}: {d}'
		/// 
		/// 回调函数
		/// 回调函数格式：
		/// (params: Object|Array) => string
		/// 
		/// 参数 params 是 formatter 需要的单个数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 文字的颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 文字字体的风格。
		/// 可选：
		/// 
		/// 'normal'
		/// 'italic'
		/// 'oblique'
		/// </summary>
		[JsonProperty("fontStyle")]
		public string FontStyle { get; set; }

		/// <summary>
		/// 文字字体的粗细。
		/// 可选：
		/// 
		/// 'normal'
		/// 'bold'
		/// 'bolder'
		/// 'lighter'
		/// 100 | 200 | 300 | 400...
		/// </summary>
		[JsonProperty("fontWeight")]
		public StringOrNumber FontWeight { get; set; }

		/// <summary>
		/// 文字的字体系列。
		/// 还可以是 'serif' , 'monospace', 'Arial', 'Courier New', 'Microsoft YaHei', ...
		/// </summary>
		[JsonProperty("fontFamily")]
		public string FontFamily { get; set; }

		/// <summary>
		/// 文字的字体大小。
		/// </summary>
		[JsonProperty("fontSize")]
		public double? FontSize { get; set; }

		/// <summary>
		/// 行高。
		/// rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight。例如：
		/// {
		///     lineHeight: 56,
		///     rich: {
		///         a: {
		///             // 没有设置 `lineHeight`，则 `lineHeight` 为 56
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("lineHeight")]
		public double? LineHeight { get; set; }

		/// <summary>
		/// 文字块背景色。
		/// 可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。
		/// 也可以直接使用图片，例如：
		/// backgroundColor: {
		///     image: 'xxx/xxx.png'
		///     // 这里可以是图片的 URL，
		///     // 或者图片的 dataURI，
		///     // 或者 HTMLImageElement 对象，
		///     // 或者 HTMLCanvasElement 对象。
		/// }
		/// 
		/// 当使用图片的时候，可以使用 width 或 height 指定高宽，也可以不指定自适应。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 文字块边框颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 文字块边框宽度。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 文字块边框描边类型。
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
		/// 文字块的圆角。
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 文字块的内边距。例如：
		/// 
		/// padding: [3, 4, 5, 6]：表示 [上, 右, 下, 左] 的边距。
		/// padding: 4：表示 padding: [4, 4, 4, 4]。
		/// padding: [3, 4]：表示 padding: [3, 4, 3, 4]。
		/// 
		/// 注意，文字块的 width 和 height 指定的是内容高宽，不包含 padding。
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 文字块的背景阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 文字块的背景阴影长度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 文字块的背景阴影 X 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 文字块的背景阴影 Y 偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 文本显示宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 文本显示高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 文字本身的描边颜色。
		/// 如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。
		/// </summary>
		[JsonProperty("textBorderColor")]
		public Color TextBorderColor { get; set; }

		/// <summary>
		/// 文字本身的描边宽度。
		/// </summary>
		[JsonProperty("textBorderWidth")]
		public double? TextBorderWidth { get; set; }

		/// <summary>
		/// 文字本身的描边类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// textBorderDashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// textBorderType: [5, 10],
		/// 
		/// textBorderDashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("textBorderType")]
		public StringOrNumber[] TextBorderType { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// textBorderType
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("textBorderDashOffset")]
		public double? TextBorderDashOffset { get; set; }

		/// <summary>
		/// 文字本身的阴影颜色。
		/// </summary>
		[JsonProperty("textShadowColor")]
		public Color TextShadowColor { get; set; }

		/// <summary>
		/// 文字本身的阴影长度。
		/// </summary>
		[JsonProperty("textShadowBlur")]
		public double? TextShadowBlur { get; set; }

		/// <summary>
		/// 文字本身的阴影 X 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetX")]
		public double? TextShadowOffsetX { get; set; }

		/// <summary>
		/// 文字本身的阴影 Y 偏移。
		/// </summary>
		[JsonProperty("textShadowOffsetY")]
		public double? TextShadowOffsetY { get; set; }

		/// <summary>
		/// 文字超出宽度是否截断或者换行。配置width时有效
		/// 
		/// 'truncate' 截断，并在末尾显示ellipsis配置的文本，默认为...
		/// 'break' 换行
		/// 'breakAll' 换行，跟'break'不同的是，在英语等拉丁文中，'breakAll'还会强制单词内换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
		/// 例如：
		/// label: {
		///     // 在文本中，可以对部分文本采用 rich 中定义样式。
		///     // 这里需要在文本中使用标记符号：
		///     // `{styleName|text content text content}` 标记样式名。
		///     // 注意，换行仍是使用 '\n'。
		///     formatter: [
		///         '{a|这段文本采用样式a}',
		///         '{b|这段文本采用样式b}这段用默认样式{x|这段用样式x}'
		///     ].join('\n'),
		/// 
		///     rich: {
		///         a: {
		///             color: 'red',
		///             lineHeight: 10
		///         },
		///         b: {
		///             backgroundColor: {
		///                 image: 'xxx/xxx.jpg'
		///             },
		///             height: 40
		///         },
		///         x: {
		///             fontSize: 18,
		///             fontFamily: 'Microsoft YaHei',
		///             borderColor: '#449933',
		///             borderRadius: 4
		///         },
		///         ...
		///     }
		/// }
		/// 
		/// 详情参见教程：富文本标签
		/// </summary>
		[JsonProperty("rich")]
		public Dictionary<string, Rich0> Rich { get; set; }
	}

	/// <summary>
	/// 线条样式。
	/// 注： 修改 lineStyle 中的颜色不会影响图例颜色，如果需要图例颜色和折线图颜色一致，需修改 itemStyle.color，线条颜色默认也会取该颜色。
	/// </summary>
	public class LineStyle3
	{
		/// <summary>
		/// 线的颜色。
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 线宽。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 线的类型。
		/// 可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// 
		/// 自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合 
		/// dashOffset
		///  可实现更灵活的虚线效果。
		/// 例如：
		/// {
		/// 
		/// type: [5, 10],
		/// 
		/// dashOffset: 5
		/// }
		/// </summary>
		[JsonProperty("type")]
		public StringOrNumber[] Type { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置虚线的偏移量，可搭配 
		/// type
		///  指定 dash array 实现灵活的虚线效果。
		/// 更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("dashOffset")]
		public double? DashOffset { get; set; }

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
		[JsonProperty("cap")]
		public string Cap { get; set; }

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
		/// miterLimit
		/// 属性看到效果。
		/// 
		/// 默认值为 'bevel'。 更多详情可以参考 MDN lineJoin。
		/// </summary>
		[JsonProperty("join")]
		public string Join { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 
		/// 
		/// 用于设置斜接面限制比例。只有当 
		/// join
		///  为 miter 时，
		/// miterLimit
		///  才有效。
		/// 默认值为 10。负数、0、Infinity 和 NaN 均会被忽略。
		/// 更多详情可以参考 MDN miterLimit。
		/// </summary>
		[JsonProperty("miterLimit")]
		public double? MiterLimit { get; set; }

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

		/// <summary>
		/// 边的曲度，支持从 0 到 1 的值，值越大曲度越大。
		/// </summary>
		[JsonProperty("curveness")]
		public double? Curveness { get; set; }
	}

	/// <summary>
	/// 折线图的高亮状态。
	/// </summary>
	public class Emphasis2
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class Blur3
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }
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
	public class SeriesPictorialBar_MarkLine_Data
	{
		/// <summary>
		/// 起点的数据。
		/// </summary>
		[JsonProperty("0")]
		public SeriesLine_MarkLine_Data_D0 D0 { get; set; }

		/// <summary>
		/// 终点的数据。
		/// </summary>
		[JsonProperty("1")]
		public SeriesLine_MarkLine_Data_D0 D1 { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesLine_MarkLine_Data_D0
	{
		/// <summary>
		/// 特殊的标注类型，用于标注最大值最小值等。
		/// 可选:
		/// 
		/// 'min' 最小值。
		/// 'max' 最大值。
		/// 'average' 平均值。
		/// 'median' 中位数。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// 在使用 type 时有效，用于指定在哪个维度上指定最大值最小值，可以是 0（xAxis, radiusAxis），1（yAxis, angleAxis），默认使用第一个数值轴所在的维度。
		/// </summary>
		[JsonProperty("valueIndex")]
		public double? ValueIndex { get; set; }

		/// <summary>
		/// 在使用 type 时有效，用于指定在哪个维度上指定最大值最小值。这可以是维度的直接名称，例如折线图时可以是x、angle等、candlestick 图时可以是open、close等维度名称。
		/// </summary>
		[JsonProperty("valueDim")]
		public string ValueDim { get; set; }

		/// <summary>
		/// 起点或终点的坐标。坐标格式视系列的坐标系而定，可以是直角坐标系上的 x, y，也可以是极坐标系上的 radius, angle。
		/// 注：对于 axis.type 为 'category' 类型的轴
		/// 
		/// 如果 coord 值为 number，则表示 axis.data 的 index。
		/// 如果 coord 值为 string，则表示 axis.data 中具体的值。注意使用这种方式时，xAxis.data 不能写成 [number, number, ...]，而只能写成 [string, string, ...]，否则不能被 markPoint / markLine 用『具体值』索引到。
		/// 
		/// 例如：
		/// {
		///     xAxis: {
		///         type: 'category',
		///         data: ['5', '6', '9', '13', '19', '33']
		///         // 注意这里不建议写成 [5, 6, 9, 13, 19, 33]，否则不能被 markPoint / markLine 用『具体值』索引到。
		///     },
		///     series: {
		///         type: 'line',
		///         data: [11, 22, 33, 44, 55, 66],
		///         markPoint: { // markLine 也是同理
		///             data: [{
		///                 coord: [5, 33.4], // 其中 5 表示 xAxis.data[5]，即 '33' 这个元素。
		///                 // coord: ['5', 33.4] // 其中 '5' 表示 xAxis.data中的 '5' 这个元素。
		///                                       // 注意，使用这种方式时，xAxis.data 不能写成 [number, number, ...]
		///                                       // 而只能写成 [string, string, ...]
		///             }]
		///         }
		///     }
		/// }
		/// </summary>
		[JsonProperty("coord")]
		public double[] Coord { get; set; }

		/// <summary>
		/// 标注名称。定义后可在 label formatter 中作为数据名 {b} 模板变量使用。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 相对容器的屏幕 x 坐标，单位像素。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 相对容器的屏幕 y 坐标，单位像素。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// x 值为给定值的标记线，仅对数据值是一项的设置有效。例如：
		/// data: [{
		///     name: 'X 轴值为 100 的竖直线',
		///     xAxis: 100
		/// }]
		/// 或对于 'time' 类型的 xAxis，可以设置为：
		/// {
		///     name: 'X 轴值为 "2020-01-01" 的竖直线',
		///     xAxis: '2020-01-01'
		/// }]
		/// </summary>
		[JsonProperty("xAxis")]
		public StringOrNumber XAxis { get; set; }

		/// <summary>
		/// Y 值为给定值的标记线，仅对数据值是一项的设置有效。例如：
		/// data: [{
		///     name: 'Y 轴值为 100 的水平线',
		///     yAxis: 100
		/// }]
		/// 或对于 'time' 类型的 yAxis，可以设置为：
		/// {
		///     name: 'Y 轴值为 "2020-01-01" 的水平线',
		///     yAxis: '2020-01-01'
		/// }]
		/// </summary>
		[JsonProperty("yAxis")]
		public StringOrNumber YAxis { get; set; }

		/// <summary>
		/// 标注值，可以不设。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 起点标记的图形。
		/// ECharts 提供的标记类型包括
		/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
		/// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		/// URL 为图片链接例如：
		/// 'image://http://example.website/a/b.png'
		/// URL 为 dataURI 例如：
		/// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		/// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
		/// 例如：
		/// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		/// 起点标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		/// 起点标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		/// 如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		/// 起点标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol 相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		/// 例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		/// 该数据项线的样式，起点和终点项的 lineStyle会合并到一起。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// 该数据项标签的样式，起点和终点项的 label会合并到一起。
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis3 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public Blur4 Blur { get; set; }
	}

	/// <summary>
	/// 折线图的高亮状态。
	/// </summary>
	public class Emphasis3
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class Blur4
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle3 LineStyle { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label4 Label { get; set; }
	}


	/// <summary>
	/// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
	/// </summary>
	public class SeriesPictorialBar_MarkArea
	{
		/// <summary>
		/// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 标域文本配置。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 该标域的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 高亮的标域样式
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 淡出的标域样式。淡出的规则跟随所在系列。
		/// </summary>
		[JsonProperty("blur")]
		public Blur2 Blur { get; set; }

		/// <summary>
		/// 标域的数据数组。每个数组项是一个两个项的数组，分别表示标域左上角和右下角的位置，每个项支持通过下面几种方式指定自己的位置
		/// 
		/// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
		/// 
		/// 
		/// 用 coord 属性指定数据在相应坐标系上的坐标位置，单个维度支持设置 'min', 'max', 'average'。
		/// 
		/// 直接用 type 属性标注系列中的最大值，最小值。这时候可以使用 valueIndex 或者 valueDim 指定是在哪个维度上的最大值、最小值、平均值。
		/// 
		/// 如果是笛卡尔坐标系的话，也可以通过只指定 xAxis 或者 yAxis 来实现 X 轴或者 Y 轴为某值的标域，见示例 scatter-weight
		/// 
		/// 
		/// 当多个属性同时存在时，优先级按上述的顺序。
		/// data: [
		/// 
		/// 
		///     [
		///         {
		///             name: '平均值到最大值',
		///             type: 'average'
		///         },
		///         {
		///             type: 'max'
		///         }
		///     ],
		/// 
		///     [
		///         {
		///             name: '两个坐标之间的标域',
		///             coord: [10, 20]
		///         },
		///         {
		///             coord: [20, 30]
		///         }
		///     ], [
		///         {
		///             name: '60分到80分',
		///             yAxis: 60
		///         },
		///         {
		///             yAxis: 80
		///         }
		///     ], [
		///         {
		///             name: '所有数据范围区间',
		///             coord: ['min', 'min']
		///         },
		///         {
		///             coord: ['max', 'max']
		///         }
		///     ],
		/// [
		///         {
		///             name: '两个屏幕坐标之间的标域',
		///             x: 100,
		///             y: 100
		///         }, {
		///             x: '90%',
		///             y: '10%'
		///         }
		///     ]
		/// ]
		/// </summary>
		[JsonProperty("data")]
		public SeriesPictorialBar_MarkArea_Data Data { get; set; }

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
	}

	/// <summary>
	/// 折线图的高亮状态。
	/// </summary>
	public class Emphasis1
	{
		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// 是否关闭高亮状态。
		/// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。在图形非常多的时候可以关闭以提升交互流畅性。
		/// </summary>
		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}

	/// <summary>
	/// 从 v5.0.0 开始支持
	/// 
	/// 折线图的淡出状态。开启 emphasis.focus 后有效。
	/// </summary>
	public class Blur2
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
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
	public class SeriesPictorialBar_MarkArea_Data
	{
		/// <summary>
		/// 标域左上角的数据
		/// </summary>
		[JsonProperty("0")]
		public SeriesLine_MarkArea_Data_D0 D0 { get; set; }

		/// <summary>
		/// 标域右下角的数据
		/// </summary>
		[JsonProperty("1")]
		public SeriesLine_MarkArea_Data_D0 D1 { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SeriesLine_MarkArea_Data_D0
	{
		/// <summary>
		/// 特殊的标注类型，用于标注最大值最小值等。
		/// 可选:
		/// 
		/// 'min' 最小值。
		/// 'max' 最大值。
		/// 'average' 平均值。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		/// <summary>
		/// 在使用 type 时有效，用于指定在哪个维度上指定最大值最小值，可以是 0（xAxis, radiusAxis），1（yAxis, angleAxis），默认使用第一个数值轴所在的维度。
		/// </summary>
		[JsonProperty("valueIndex")]
		public double? ValueIndex { get; set; }

		/// <summary>
		/// 在使用 type 时有效，用于指定在哪个维度上指定最大值最小值。这可以是维度的直接名称，例如折线图时可以是x、angle等、candlestick 图时可以是open、close等维度名称。
		/// </summary>
		[JsonProperty("valueDim")]
		public string ValueDim { get; set; }

		/// <summary>
		/// 起点或终点的坐标。坐标格式视系列的坐标系而定，可以是直角坐标系上的 x, y，也可以是极坐标系上的 radius, angle。
		/// </summary>
		[JsonProperty("coord")]
		public double[] Coord { get; set; }

		/// <summary>
		/// 标注名称，将会作为文字显示。定义后可在 label formatter 中作为数据名 {b} 模板变量使用。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 相对容器的屏幕 x 坐标，单位像素，支持百分比形式，例如 '20%'。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 相对容器的屏幕 y 坐标，单位像素，支持百分比形式，例如 '20%'。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 标域值，可以不设。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 该数据项区域的样式，起点和终点项的 itemStyle 会合并到一起。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		/// 该数据项标签的样式，起点和终点项的 label 会合并到一起。
		/// </summary>
		[JsonProperty("label")]
		public Label1 Label { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis1 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("blur")]
		public Blur2 Blur { get; set; }
	}


	/// <summary>
	/// 从 v5.2.0 开始支持
	/// 
	/// 全局过渡动画相关的配置。
	/// 全局过渡动画（Universal Transition）提供了任意系列之间进行变形动画的功能。开启该功能后，每次setOption，相同id的系列之间会自动关联进行动画的过渡，更细粒度的关联配置见universalTransition.seriesKey配置。
	/// 通过配置数据项的groupId和childGroupId，还可以实现诸如下钻，聚合等一对多或者多对一的动画。
	/// 可以直接在系列中配置 universalTransition: true 开启该功能。也可以提供一个对象进行更多属性的配置。
	/// </summary>
	public class SeriesLine_UniversalTransition
	{
		/// <summary>
		/// 是否开启全局过渡动画。
		/// </summary>
		[JsonProperty("enabled")]
		public bool? Enabled { get; set; }

		/// <summary>
		/// seriesKey决定了如何关联需要动画的系列，未配置时会默认取系列的id。
		/// 通常该配置为一个字符串，配置为相同seriesKey的系列之间会进行动画的过渡。也可以像下面配置为一个数组：
		/// seriesKey: ['male', 'female']
		/// 
		/// 配置为数组意味着在动画的时候所有数组项指定的系列会合并为当前系列。比如该配置是指id或者seriesKey为'male'和'female'的系列会合并成当前系列。
		/// </summary>
		[JsonProperty("seriesKey")]
		public ArrayOrSingle SeriesKey { get; set; }

		/// <summary>
		/// divideShape决定在一对多或者多对一的动画中，当前系列的图形如何分裂成多个图形。目前支持
		/// 
		/// 'split' 通过一定的算法将分割图形成为多个。
		/// 'clone' 从当前图形克隆得到多个。
		/// 
		/// 为了较好的效果，不同的系列会默认有不同的配置，比如散点图这种图形比较小且复杂的默认采用了'clone'，而柱状图这种更加规则的则默认是'split'。你可以根据你自己的场景需求设置为需要的分裂策略。
		/// </summary>
		[JsonProperty("divideShape")]
		public string DivideShape { get; set; }

		/// <summary>
		/// (index: number, count: number) => number
		/// 
		/// 配置一对多或者多对一的动画中每个图形的动画延时，设置不同的动画延时可以给动画带来一定的趣味性。比如下面代码每个图形通过一个随机的延时造成一种错落的效果：
		/// delay: function (index, count) {
		///     return Math.random() * 1000;
		/// }
		/// </summary>
		[JsonProperty("delay")]
		public string Delay { get; set; }
	}

	/// <summary>
	/// 本系列特定的 tooltip 设定。
	/// </summary>
	public class Tooltip1
	{
		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 提示框浮层的位置，默认不设置时位置会跟随鼠标的位置。
		/// 可选：
		/// 
		/// Array
		///   通过数组表示提示框浮层的位置，支持数字设置绝对位置，百分比设置相对位置。
		///   示例:
		///   // 绝对位置，相对于容器左侧 10px, 上侧 10 px
		///   position: [10, 10]
		///   // 相对位置，放置在容器正中间
		///   position: ['50%', '50%']
		/// 
		/// 
		/// Function
		///   回调函数，格式如下：
		///   (point: Array, params: Object|Array.<Object>, dom: HTMLDomElement, rect: Object, size: Object) => Array
		/// 
		///   参数：
		///   point: 鼠标位置，如 [20, 40]。
		///   params: 同 formatter 的参数相同。
		///   dom: tooltip 的 dom 对象。
		///   rect: 只有鼠标在图形上时有效，是一个用x, y, width, height四个属性表达的图形包围盒。
		///   size: 包括 dom 的尺寸和 echarts 容器的当前尺寸，例如：{contentSize: [width, height], viewSize: [width, height]}。
		///   返回值：
		///   可以是一个表示 tooltip 位置的数组，数组值可以是绝对的像素值，也可以是相  百分比。
		///   也可以是一个对象，如：{left: 10, top: 30}，或者 {right: '20%', bottom: 40}。
		///   如下示例：
		///   position: function (point, params, dom, rect, size) {
		///       // 固定在顶部
		///       return [point[0], '10%'];
		///   }
		/// 
		///   或者：
		///   position: function (pos, params, dom, rect, size) {
		///       // 鼠标在左侧时 tooltip 显示到右侧，鼠标在右侧时 tooltip 显示到左侧。
		///       var obj = {top: 60};
		///       obj[['left', 'right'][+(pos[0] < size.viewSize[0] / 2)]] = 5;
		///       return obj;
		///   }
		/// 
		/// 
		/// 
		/// 
		/// 'inside'
		///   鼠标所在图形的内部中心位置，只在 trigger 为'item'的时候有效。
		/// 
		/// 'top'
		///   鼠标所在图形上侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'left'
		///   鼠标所在图形左侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'right'
		///   鼠标所在图形右侧，只在 trigger 为'item'的时候有效。
		/// 
		/// 'bottom'
		///   鼠标所在图形底侧，只在 trigger 为'item'的时候有效。
		/// </summary>
		[JsonProperty("position")]
		public ArrayOrSingle Position { get; set; }

		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 提示框浮层内容格式器，支持字符串模板和回调函数两种形式。
		/// 1. 字符串模板
		/// 模板变量有 {a}, {b}，{c}，{d}，{e}，分别表示系列名，数据名，数据值等。
		/// 在 trigger 为 'axis' 的时候，会有多个系列的数据，此时可以通过 {a0}, {a1}, {a2} 这种后面加索引的方式表示系列的索引。
		/// 不同图表类型下的 {a}，{b}，{c}，{d} 含义不一样。
		/// 其中变量{a}, {b}, {c}, {d}在不同图表类型下代表数据含义为：
		/// 
		/// 折线（区域）图、柱状（条形）图、K线图 : {a}（系列名称），{b}（类目值），{c}（数值）, {d}（无）
		/// 
		/// 散点图（气泡）图 : {a}（系列名称），{b}（数据名称），{c}（数值数组）, {d}（无）
		/// 
		/// 地图 : {a}（系列名称），{b}（区域名称），{c}（合并数值）, {d}（无）
		/// 
		/// 饼图、仪表盘、漏斗图: {a}（系列名称），{b}（数据项名称），{c}（数值）, {d}（百分比）
		/// 
		/// 
		/// 更多其它图表模板变量的含义可以见相应的图表的 label.formatter 配置项。
		/// 示例：
		/// formatter: '{b0}: {c0}<br />{b1}: {c1}'
		/// 
		/// 2. 回调函数
		/// 回调函数格式：
		/// (params: Object|Array, ticket: string, callback: (ticket: string, html: string)) => string | HTMLElement | HTMLElement[]
		/// 
		/// 支持返回 HTML 字符串或者创建的 DOM 实例。
		/// 第一个参数 params 是 formatter 需要的数据集。格式如下：
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string,
		///     // 饼图/漏斗图的百分比
		///     percent: number,
		///     // 旭日图中当前节点的祖先节点（包括自身）
		///     treePathInfo: Array,
		///     // 树图/矩形树图中当前节点的祖先节点（包括自身）
		///     treeAncestors: Array
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// 
		/// 在 trigger 为 'axis' 的时候，或者 tooltip 被 axisPointer 触发的时候，params 是多个系列的数据数组。其中每项内容格式同上，并且，
		/// {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array<String>,
		///     // 数据的维度 index，如 0 或 1 或 2 ...
		///     // 仅在雷达图中使用。
		///     dimensionIndex: number,
		///     // 数据图形的颜色
		///     color: string
		/// }
		/// 
		/// 注：encode 和 dimensionNames 的使用方式，例如：
		/// 如果数据为：
		/// dataset: {
		///     source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.encode.y[0]]
		/// 
		/// 如果数据为：
		/// dataset: {
		///     dimensions: ['product', '2015', '2016', '2017'],
		///     source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///     ]
		/// }
		/// 
		/// 则可这样得到 y 轴对应的 value：
		/// params.value[params.dimensionNames[params.encode.y[0]]]
		/// 
		/// 第二个参数 ticket 是异步回调标识，配合第三个参数 callback 使用。
		/// 第三个参数 callback 是异步回调，在提示框浮层内容是异步获取的时候，可以通过 callback 传入上述的 ticket 和 html 更新提示框浮层内容。
		/// 示例：
		/// formatter: function (params, ticket, callback) {
		///     $.get('detail?name=' + params.name, function (content) {
		///         callback(ticket, toHTML(content));
		///     });
		///     return 'Loading';
		/// }
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		/// 从 v5.3.0 开始支持
		/// 
		/// tooltip 中数值显示部分的格式化回调函数。
		/// 回调函数格式：
		/// (value: number | string, dataIndex: number) => string
		/// 
		/// 
		/// 自 v5.5.0 版本起提供 dataIndex。
		/// 
		/// 示例：
		/// // 添加 $ 前缀
		/// valueFormatter: (value) => '$' + value.toFixed(2)
		/// </summary>
		[JsonProperty("valueFormatter")]
		public string ValueFormatter { get; set; }

		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 提示框浮层的背景颜色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 提示框浮层的边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 提示框浮层的边框宽。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 
		/// 
		/// 提示框浮层内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。
		/// 使用示例：
		/// // 设置内边距为 5
		/// padding: 5
		/// // 设置上下的内边距为 5，左右的内边距为 10
		/// padding: [5, 10]
		/// // 分别设置四个方向的内边距
		/// padding: [
		///     5,  // 上
		///     10, // 右
		///     5,  // 下
		///     10, // 左
		/// ]
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 提示框浮层的文本样式。
		/// </summary>
		[JsonProperty("textStyle")]
		public Legend_PageTextStyle TextStyle { get; set; }

		/// <summary>
		/// 注意：series.tooltip 仅在 tooltip.trigger 为 'item' 时有效。
		/// 
		/// 额外附加到浮层的 css 样式。如下为浮层添加阴影的示例：
		/// extraCssText: 'box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);'
		/// </summary>
		[JsonProperty("extraCssText")]
		public string ExtraCssText { get; set; }
	}
}