using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     系列中的数据内容数组。数组项通常为具体的数据项。
///     注意，如果系列没有指定 data，并且 option 有 dataset，那么默认使用第一个 dataset。如果指定了 data，则不会再使用 dataset。
///     可以使用 series.datasetIndex 指定其他的 dataset。
///     通常来说，数据用一个二维数组表示。如下，每一列被称为一个『维度』。
///     series: [{
///     data: [
///     // 维度X   维度Y   其他维度 ...
///     [  3.4,    4.5,   15,   43],
///     [  4.2,    2.3,   20,   91],
///     [  10.8,   9.5,   30,   18],
///     [  7.2,    8.8,   18,   57]
///     ]
///     }]
///     在 直角坐标系 (grid) 中『维度X』和『维度Y』会默认对应于 xAxis 和 yAxis。
///     在 极坐标系 (polar) 中『维度X』和『维度Y』会默认对应于 radiusAxis 和 angleAxis。
///     后面的其他维度是可选的，可以在别处被使用，例如：
///     在 visualMap 中可以将一个或多个维度映射到颜色，大小等多个图形属性上。
///     在 series.symbolSize 中可以使用回调函数，基于某个维度得到 symbolSize 值。
///     使用 tooltip.formatter 或 series.label.formatter 可以把其他维度的值展示出来。
///     特别地，当只有一个轴为类目轴（axis.type 为 'category'）的时候，数据可以简化用一个一维数组表示。例如：
///     xAxis: {
///     data: ['a', 'b', 'm', 'n']
///     },
///     series: [{
///     // 与 xAxis.data 一一对应。
///     data: [23,  44,  55,  19]
///     // 它其实是下面这种形式的简化：
///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
///     }]
///     『值』与 轴类型 的关系：
///     当某维度对应于数值轴（axis.type 为 'value' 或者 'log'）的时候：
///     其值可以为 number（例如 12）。（也可以兼容 string 形式的 number，例如 '12'）
///     当某维度对应于类目轴（axis.type 为 'category'）的时候：
///     其值须为类目的『序数』（从 0 开始）或者类目的『字符串值』。例如：
///     xAxis: {
///     type: 'category',
///     data: ['星期一', '星期二', '星期三', '星期四']
///     },
///     yAxis: {
///     type: 'category',
///     data: ['a', 'b', 'm', 'n', 'p', 'q']
///     },
///     series: [{
///     data: [
///     // xAxis    yAxis
///     [  0,        0,    2  ], // 意思是此点位于 xAxis: '星期一', yAxis: 'a'。
///     [  '星期四',  2,    1  ], // 意思是此点位于 xAxis: '星期四', yAxis: 'm'。
///     [  2,       'p',   2  ], // 意思是此点位于 xAxis: '星期三', yAxis: 'p'。
///     [  3,        3,    5  ]
///     ]
///     }]
///     双类目轴的示例可以参考 Github Punchcard 示例。
///     当某维度对应于时间轴（type 为 'time'）的时候，值可以为：
///     一个时间戳，如 1484141700832，表示 UTC 时间。
///     或者字符串形式的时间描述：
///     ISO 8601 的子集，只包含这些形式（这几种格式，除非指明时区，否则均表示本地时间，与 moment 一致）：
///     部分年月日时间: '2012-03', '2012-03-01', '2012-03-01 05', '2012-03-01 05:06'.
///     使用 'T' 或空格分割: '2012-03-01T12:22:33.123', '2012-03-01 12:22:33.123'.
///     时区设定: '2012-03-01T12:22:33Z', '2012-03-01T12:22:33+8000', '2012-03-01T12:22:33-05:00'.
///     其他的时间字符串，包括（均表示本地时间）:
///     '2012', '2012-3-1', '2012/3/1', '2012/03/01',
///     '2009/6/12 2:00', '2009/6/12 2:05:08', '2009/6/12 2:05:08.123'
///     或者用户自行初始化的 Date 实例：
///     注意，用户自行初始化 Date 实例的时候，浏览器的行为有差异，不同字符串的表示也不同。
///     例如：在 chrome 中，new Date('2012-01-01') 表示 UTC 时间的 2012 年 1 月 1 日，而 new Date('2012-1-1') 和 new Date('2012/01/01')
///     表示本地时间的 2012 年 1 月 1 日。在 safari 中，不支持 new Date('2012-1-1') 这种表示方法。
///     所以，使用 new Date(dataString) 时，可使用第三方库解析（如 moment），或者使用 echarts.time.parse，或者参见 这里。
///     当需要对个别数据进行个性化定义时：
///     数组项可用对象，其中的 value 像表示具体的数值，如：
///     [
///     12,
///     34,
///     {
///     value : 56,
///     //自定义标签样式，仅对该数据项有效
///     label: {},
///     //自定义特殊 itemStyle，仅对该数据项有效
///     itemStyle:{}
///     },
///     10
///     ]
///     // 或
///     [
///     [12, 33],
///     [34, 313],
///     {
///     value: [56, 44],
///     label: {},
///     itemStyle:{}
///     },
///     [10, 33]
///     ]
///     空值：
///     当某数据不存在时（ps：不存在不代表值为 0），可以用 '-' 或者 null 或者 undefined 或者 NaN 表示。
///     例如，无数据在折线图中可表现为该点是断开的，在其它图中可表示为图形不存在。
/// </summary>
public class SeriesPictorialBar_Data
{
	/// <summary>
	///     数据项名称。
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	///     单个数据项的数值。
	/// </summary>
	[JsonProperty("value")]
	public double? Value { get; set; }

	/// <summary>
	///     该数据项的组 ID。当全局过渡动画功能开启时，setOption 前后拥有相同组 ID 的数据项会进行动画过渡。
	///     若没有指定groupId ，会尝试用series.dataGroupId作为该数据项的组 ID；若series.dataGroupId也没有指定，则会使用数据项的 ID 作为组 ID。
	///     如果你使用了dataset组件来表达数据，推荐使用encode.itemGroupId来指定哪个维度被编码为组 ID。
	/// </summary>
	[JsonProperty("groupId")]
	public string GroupId { get; set; }

	/// <summary>
	///     从 v5.5.0 开始支持
	///     该数据项对应的子数据组 ID，用于实现多层下钻和聚合。
	///     通过groupId已经可以达到数据下钻和聚合的效果，但只支持一层的下钻和聚合。为了实现多层下钻和聚合，我们又引入了childGroupId。
	///     引入childGroupId后，不同option的数据项之间就能形成逻辑上的父子关系，例如：
	///     data: [                        data: [                        data: [
	///     {                              {                              {
	///     name: 'Animals',               name: 'Dogs',                  name: 'Corgi',
	///     value: 3,                      value: 3,                      value: 5,
	///     groupId: 'things',             groupId: 'animals',            groupId: 'dogs'
	///     childGroupId: 'animals'        childGroupId: 'dogs'         },
	///     },                             },                             {
	///     {                              {                                name: 'Bulldog',
	///     name: 'Fruits',                name: 'Cats',                  value: 6,
	///     value: 3,                      value: 4,                      groupId: 'dogs'
	///     groupId: 'things',             groupId: 'animals',          },
	///     childGroupId: 'fruits'         childGroupId: 'cats',        {
	///     },                             },                               name: 'Shiba Inu',
	///     {                              {                                value: 7,
	///     name: 'Cars',                  name: 'Birds',                 groupId: 'dogs'
	///     value: 2,                      value: 3,                    }
	///     groupId: 'things',             groupId: 'animals',        ]
	///     childGroupId: 'cars'           childGroupId: 'birds'
	///     }                              }
	///     ]                              ]
	///     上面 3 组 data 分别来自 3 个 option ，通过groupId和childGroupId，它们之间存在了“父-子-孙”的关系。在setOption时，Apache ECharts
	///     会尝试寻找前后option数据项间的父子关系，若存在父子关系，则会对相关数据项进行下钻或聚合动画的过渡。
	///     没有对应子数据组的数据项不需要指定childGroupId。
	///     如果你使用了dataset组件来表达数据，推荐使用encode.itemChildGroupId来指定哪个维度被编码为子数据组 ID。
	/// </summary>
	[JsonProperty("childGroupId")]
	public string ChildGroupId { get; set; }

	/// <summary>
	///     图形类型。
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
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbol: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbol: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbol: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbol")]
	public string Symbol { get; set; }

	/// <summary>
	///     图形的大小。
	///     可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10，也可以设置成诸如 10 这样单一的数字，表示 [10, 10]。
	///     可以设置成绝对值（如 10），也可以设置成百分比（如 '120%'、['55%', 23]）。
	///     当设置为百分比时，图形的大小是基于 基准柱 的尺寸计算出来的。
	///     例如，当基准柱基于 x 轴（即柱子是纵向的），symbolSize 设置为 ['30%', '50%']，那么最终图形的尺寸是：
	///     宽度：基准柱的宽度 * 30%。
	///     高度：
	///     如果 symbolRepeat 为 false：基准柱的高度 * 50%。
	///     如果 symbolRepeat 为 true：基准柱的宽度 * 50%。
	///     基准柱基于 y 轴（即柱子是横向的）的情况类似对调可得出。
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolSize: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolSize: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolSize: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolSize")]
	public ArrayOrSingle SymbolSize { get; set; }

	/// <summary>
	///     图形的定位位置。可取值：
	///     'start'：图形边缘与柱子开始的地方内切。
	///     'end'：图形边缘与柱子结束的地方内切。
	///     'center'：图形在柱子里居中。
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolPosition: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolPosition: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolPosition: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolPosition")]
	public string SymbolPosition { get; set; }

	/// <summary>
	///     图形相对于原本位置的偏移。symbolOffset 是图形定位中最后计算的一个步骤，可以对图形计算出来的位置进行微调。
	///     可以设置成绝对值（如 10），也可以设置成百分比（如 '120%'、['55%', 23]）。
	///     当设置为百分比时，表示相对于自身尺寸 symbolSize 的百分比。
	///     例如 [0, '-50%'] 就是把图形向上移动了自身尺寸的一半的位置。
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolOffset: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolOffset: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolOffset: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolOffset")]
	public double[] SymbolOffset { get; set; }

	/// <summary>
	///     图形的旋转角度。
	///     注意，symbolRotate 并不会影响图形的定位（哪怕超出基准柱的边界），而只是单纯得绕自身中心旋转。
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolRotate: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolRotate: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolRotate: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolRotate")]
	public double? SymbolRotate { get; set; }

	/// <summary>
	///     指定图形元素是否重复。值可为：
	///     false/null/undefined：不重复，即每个数据值用一个图形元素表示。
	///     true：使图形元素重复，即每个数据值用一组重复的图形元素表示。重复的次数依据 data 计算得到。
	///     a number：使图形元素重复，即每个数据值用一组重复的图形元素表示。重复的次数是给定的定值。
	///     'fixed'：使图形元素重复，即每个数据值用一组重复的图形元素表示。重复的次数依据 symbolBoundingData 计算得到，即与 data 无关。这在此图形被用于做背景时有用。
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolRepeat: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolRepeat: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolRepeat: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolRepeat")]
	public StringOrNumber SymbolRepeat { get; set; }

	/// <summary>
	///     指定图形元素重复时，绘制的顺序。这个属性在两种情况下有用处：
	///     当 symbolMargin 设置为负值时，重复的图形会互相覆盖，这是可以使用 symbolRepeatDirection 来指定覆盖顺序。
	///     当 animationDelay 或 animationDelayUpdate 被使用时，symbolRepeatDirection 指定了 index 顺序。
	///     这个属性的值可以是：'start' 或 'end'。
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolRepeatDirection: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolRepeatDirection: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolRepeatDirection: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolRepeatDirection")]
	public string SymbolRepeatDirection { get; set; }

	/// <summary>
	///     图形的两边间隔（『两边』是指其数值轴方向的两边）。可以是绝对数值（如 20），或者百分比值（如 '-30%'），表示相对于自身尺寸 symbolSize 的百分比。只有当 symbolRepeat 被使用时有意义。
	///     可以是正值，表示间隔大；也可以是负数。当 symbolRepeat 被使用时，负数时能使图形重叠。
	///     可以在其值结尾处加一个 "!"，如 "30%!" 或 25!，表示第一个图形的开始和最后一个图形结尾留白，不紧贴边界。默认会紧贴边界。
	///     注意：
	///     当 symbolRepeat 为 true/'fixed' 的时候：
	///     这里设置的 symbolMargin 只是个参考值，真正最后的图形间隔，是根据 symbolRepeat、symbolMargin、symbolBoundingData 综合计算得到。
	///     当 symbolRepeat 为一个固定数值的时候：
	///     这里设置的 symbolMargin 无效。
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolMargin: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolMargin: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolMargin: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolMargin")]
	public StringOrNumber SymbolMargin { get; set; }

	/// <summary>
	///     是否剪裁图形。
	///     false/null/undefined：图形本身表示数值大小。
	///     true：图形被剪裁后剩余的部分表示数值大小。
	///     symbolClip 常在这种场景下使用：同时表达『总值』和『当前数值』。在这种场景下，可以使用两个系列，一个系列是完整的图形，当做『背景』来表达总数值，另一个系列是使用 symbolClip 进行剪裁过的图形，表达当前数值。
	///     例子：
	///     在这个例子中：
	///     『背景系列』和『当前值系列』使用相同的 symbolBoundingData，使得绘制出的图形的大小是一样的。
	///     『当前值系列』设置了比『背景系列』更高的 z，使得其覆盖在『背景系列』上。
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolClip: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolClip: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolClip: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolClip")]
	public bool? SymbolClip { get; set; }

	/// <summary>
	///     这个属性是『指定图形界限的值』。它指定了一个 data，这个 data 映射在坐标系上的位置，是图形绘制的界限。也就是说，如果设置了 symbolBoundingData，图形的尺寸则由 symbolBoundingData
	///     决定。
	///     当柱子是水平的，symbolBoundingData 对应到 x 轴上，当柱子是竖直的，symbolBoundingData 对应到 y 轴上。
	///     规则：
	///     没有使用 symbolRepeat 时：
	///     symbolBoundingData 缺省情况下和『参考柱』的尺寸一样。图形的尺寸由零点和 symbolBoundingData 决定。举例，当柱子是竖直的，柱子对应的 data 为 24，symbolSize 设置为 [30,
	///     '50%']，symbolBoundingData 设置为 124，那么最终图形的高度为 124 * 50% = 62。如果 symbolBoundingData 不设置，那么最终图形的高度为 24 * 50% = 12。
	///     使用了 symbolRepeat 时：
	///     symbolBoundingData 缺省情况取当前坐标系所显示出的最值。symbolBoundingData 定义了一个 bounding，重复的图形在这个 bounding 中，依据 symbolMargin 和
	///     symbolRepeat 和 symbolSize 进行排布。这几个变量决定了图形的间隔大小。
	///     在这些场景中，你可能会需要设置 symbolBoundingData：
	///     使用了 symbolCilp 时：
	///     使用一个系列表达『总值』，另一个系列表达『当前值』的时候，需要两个系列画出的图形一样大。那么就把两个系列的 symbolBoundingData 设为一样大。
	///     例子：
	///     使用了 symbolRepeat 时：
	///     如果需要不同柱子中的图形的间隔保持一致，那么可以把 symbolBoundingData 设为一致的数值。当然，不设置 symbolBoundingData 也是可以的，因为其缺省值就是一个定值（坐标系所显示出的最值）。
	///     例子：
	///     symbolBoundingData 可以是一个数组，例如 [-40, 60]，表示同时指定了正值的 symbolBoundingData 和负值的 symbolBoundingData。
	///     参见例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolBoundingData: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolBoundingData: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolBoundingData: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolBoundingData")]
	public ArrayOrSingle SymbolBoundingData { get; set; }

	/// <summary>
	///     可以使用图片作为图形的 pattern。
	///     var textureImg = new Image();
	///     textureImg.src = 'data:image/jpeg;base64,...'; // dataURI
	///     // 或者
	///     // textureImg.src = 'http://example.website/xx.png'; // URL
	///     ...
	///     itemStyle: {
	///     color: {
	///     image: textureImg,
	///     repeat: 'repeat'
	///     }
	///     }
	///     这时候，symbolPatternSize 指定了 pattern 的缩放尺寸。比如 symbolPatternSize 为 400 时表示图片显示为 400px * 400px 的尺寸。
	///     例子：
	///     此属性可以被设置在系列的 根部，表示对此系列中所有数据都生效；也可以被设置在 data 中的 每个数据项中，表示只对此数据项生效。
	///     例如：
	///     series: [{
	///     symbolPatternSize: ... // 对 data 中所有数据项生效。
	///     data: [23, 56]
	///     }]
	///     或者
	///     series: [{
	///     data: [{
	///     value: 23
	///     symbolPatternSize: ... // 只对此数据项生效
	///     }, {
	///     value: 56
	///     symbolPatternSize: ... // 只对此数据项生效
	///     }]
	///     }]
	/// </summary>
	[JsonProperty("symbolPatternSize")]
	public double? SymbolPatternSize { get; set; }

	/// <summary>
	///     指定图形元素间的覆盖关系。数值越大，越在层叠的上方。
	/// </summary>
	[JsonProperty("z")]
	public double? Z { get; set; }

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
	///     动画开始之前的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
	///     如下示例：
	///     animationDelay: function (dataIndex, params) {
	///     return params.index * 30;
	///     }
	///     或者反向：
	///     animationDelay: function (dataIndex, params) {
	///     return (params.count - 1 - params.index) * 30;
	///     }
	///     例子：
	/// </summary>
	[JsonProperty("animationDelay")]
	public StringOrNumber AnimationDelay { get; set; }

	/// <summary>
	///     数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
	///     如下示例：
	///     animationDelay: function (dataIndex, params) {
	///     return params.index * 30;
	///     }
	///     或者反向：
	///     animationDelay: function (dataIndex, params) {
	///     return (params.count - 1 - params.index) * 30;
	///     }
	///     例子：
	/// </summary>
	[JsonProperty("animationDelayUpdate")]
	public StringOrNumber AnimationDelayUpdate { get; set; }

	/// <summary>
	///     单个柱条文本的样式设置。
	/// </summary>
	[JsonProperty("label")]
	public Label3 Label { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的视觉引导线配置。
	/// </summary>
	[JsonProperty("labelLine")]
	public LabelLine1 LabelLine { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle0 ItemStyle { get; set; }

	/// <summary>
	///     单个数据的高亮状态配置。
	/// </summary>
	[JsonProperty("emphasis")]
	public SeriesPictorialBar_Data_Emphasis Emphasis { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     单个数据的淡出状态配置。
	/// </summary>
	[JsonProperty("blur")]
	public Blur5 Blur { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     单个数据的选中状态配置。
	/// </summary>
	[JsonProperty("select")]
	public SeriesBar_Data_Emphasis Select { get; set; }

	/// <summary>
	///     本系列每个数据项中特定的 tooltip 设定。
	/// </summary>
	[JsonProperty("tooltip")]
	public Tooltip1 Tooltip { get; set; }
}