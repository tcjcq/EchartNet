using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     连续型视觉映射组件（visualMapContinuous）
	///     （参考视觉映射组件（visualMap）的介绍）
	///     visualMapContinuous中，可以通过 visualMap.calculable 来显示或隐藏手柄（手柄能拖拽改变值域）。
	/// </summary>
	public class VisualMapContinuous
	{
		/// <summary>
		///     类型为连续型。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "continuous";

		/// <summary>
		///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     指定 visualMapContinuous 组件的允许的最小值。'min' 必须用户指定。[visualMap.min, visualMax.max] 形成了视觉映射的『定义域』。
		/// </summary>
		[JsonProperty("min")]
		public double? Min { get; set; }

		/// <summary>
		///     指定 visualMapContinuous 组件的允许的最大值。'max' 必须用户指定。[visualMap.min, visualMax.max] 形成了视觉映射的『定义域』。
		/// </summary>
		[JsonProperty("max")]
		public double? Max { get; set; }

		/// <summary>
		///     指定手柄对应数值的位置。range 应在 min max 范围内。例如：
		///     chart.setOption({
		///     visualMap: {
		///     min: 0,
		///     max: 100,
		///     // 两个手柄对应的数值是 4 和 15
		///     range: [4, 15],
		///     ...
		///     }
		///     });
		///     setOption 改变 min、max 时 range 的自适应
		///     如果 range 不设置（或设置为 null）
		///     例如：
		///     chart.setOption({visualMap: {min: 10, max: 300}}); // 不设置 range，则 range 默认为 [min, max]，即 [10, 300]。
		///     chart.setOption({visualMap: {min: 0, max: 400}}); // 再次使用 setOption 改变 min、max。
		///     // 此时 range 也自然会更新成改变过后的 [min, max]，即 [0, 400]。
		///     如果 range 被以具体值设置了（例如设置为 [10, 300]）
		///     例如：
		///     chart.setOption({visualMap: {min: 10, max: 300, range: [20, 80]}}); // 设置了 range
		///     chart.setOption({visualMap: {min: 0, max: 400}}); // 再次使用 setOption 改变 min、max。
		///     // 此时 range 不会改变而仍维持本来的数值，仍为 [20, 80]。
		///     chart.setOption({visualMap: {range: null}}); // 再把 range 设为 null。
		///     // 则 range 恢复为 [min, max]，即 [0, 400]，同时也恢复了自动随 min max 而改变的能力。
		///     getOption 得到的 range 总是 Array，不会为 null 或 undefined。
		/// </summary>
		[JsonProperty("range")]
		public double[] Range { get; set; }

		/// <summary>
		///     是否显示拖拽用的手柄（手柄能拖拽调整选中范围）。
		///     （注：为兼容 ECharts2，当 visualMap.type 未指定时，假如设置了 'calculable'，则type自动被设置为'continuous'，无视 visualMap-piecewise.splitNumber
		///     等设置。所以，建议使用者不要不指定 visualMap.type，否则表意不清晰。）
		/// </summary>
		[JsonProperty("calculable")]
		public bool? Calculable { get; set; }

		/// <summary>
		///     拖拽时，是否实时更新。
		///     如果为true则拖拽手柄过程中实时更新图表视图。
		///     如果为false则拖拽结束时，才更新视图。
		/// </summary>
		[JsonProperty("realtime")]
		public bool? Realtime { get; set; }

		/// <summary>
		///     是否反转 visualMap 组件。
		///     当inverse为false时，数据大小的位置规则，和直角坐标系相同，即：
		///     当 visualMap.orient 为'vertical'时，数据上大下小。
		///     当 visualMap.orient 为'horizontal'时，数据右大左小。
		///     当inverse为true时，相反。
		/// </summary>
		[JsonProperty("inverse")]
		public bool? Inverse { get; set; }

		/// <summary>
		///     数据展示的小数精度，默认为0，无小数点。
		/// </summary>
		[JsonProperty("precision")]
		public double? Precision { get; set; }

		/// <summary>
		///     图形的宽度，即长条的宽度。
		/// </summary>
		[JsonProperty("itemWidth")]
		public double? ItemWidth { get; set; }

		/// <summary>
		///     图形的高度，即长条的高度。
		/// </summary>
		[JsonProperty("itemHeight")]
		public double? ItemHeight { get; set; }

		/// <summary>
		///     指定组件中手柄和文字的摆放位置，可选值为：
		///     'auto' 自动决定。
		///     'left' 手柄和label在右，orient 为 horizontal 时有效。
		///     'right' 手柄和label在左，orient 为 horizontal 时有效。
		///     'top' 手柄和label在下，orient 为 vertical 时有效。
		///     'bottom' 手柄和label在上，orient 为 vertical 时有效。
		/// </summary>
		[JsonProperty("align")]
		public string Align { get; set; }

		/// <summary>
		///     两端的文本，如 ['High', 'Low']。参见例子。
		///     text 中的顺序，其实试试就知道。若要看详细的规则，参见 visualMap.inverse。
		/// </summary>
		[JsonProperty("text")]
		public double[] Text { get; set; }

		/// <summary>
		///     两端文字主体之间的距离，单位为px。参见 visualMap-continuous.text
		/// </summary>
		[JsonProperty("textGap")]
		public double? TextGap { get; set; }

		/// <summary>
		///     是否显示 visualMap-continuous 组件。如果设置为 false，不会显示，但是数据映射的功能还存在。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     指定用数据的『哪个维度』，映射到视觉元素上。『数据』即 series.data。
		///     可以把 series.data 理解成一个二维数组，例如：
		///     [
		///     [12, 23, 43],
		///     [12, 23, 43],
		///     [43, 545, 65],
		///     [92, 23, 33]
		///     ]
		///     其中每个列是一个维度，即 dimension。
		///     例如 dimension 为 1 时，取第二列（即 23，23，545，23），映射到视觉元素上。
		///     默认取 data 中最后一个维度。
		/// </summary>
		[JsonProperty("dimension")]
		public double? Dimension { get; set; }

		/// <summary>
		///     指定取哪个系列的数据，即哪个系列的 series.data。
		///     默认取所有系列。
		/// </summary>
		[JsonProperty("seriesIndex")]
		public ArrayOrSingle SeriesIndex { get; set; }

		/// <summary>
		///     打开 hoverLink 功能时，鼠标悬浮到 visualMap 组件上时，鼠标位置对应的数值 在 图表中对应的图形元素，会高亮。
		///     反之，鼠标悬浮到图表中的图形元素上时，在 visualMap 组件的相应位置会有三角提示其所对应的数值。
		/// </summary>
		[JsonProperty("hoverLink")]
		public bool? HoverLink { get; set; }

		/// <summary>
		///     定义 在选中范围中 的视觉元素。（用户可以和 visualMap 组件交互，用鼠标或触摸选择范围）
		///     可选的视觉元素有：
		///     symbol: 图元的图形类别。
		///     symbolSize: 图元的大小。
		///     color: 图元的颜色。
		///     colorAlpha: 图元的颜色的透明度。
		///     opacity: 图元以及其附属物（如文字标签）的透明度。
		///     colorLightness: 颜色的明暗度，参见 HSL。
		///     colorSaturation: 颜色的饱和度，参见 HSL。
		///     colorHue: 颜色的色调，参见 HSL。
		///     inRange 能定义目标系列（参见 visualMap-continuous.seriesIndex）视觉形式，也同时定义了 visualMap-continuous 本身的视觉样式。通俗来讲就是，假如
		///     visualMap-continuous控制的是散点图，那么 inRange 同时定义了散点图的 颜色、尺寸 等，也定义了 visualMap-continuous 本身的 颜色、尺寸 等。这二者能对应上。
		///     定义方式，例如：
		///     visualMap: [
		///     {
		///     ...,
		///     inRange: {
		///     color: ['#121122', 'rgba(3,4,5,0.4)', 'red'],
		///     symbolSize: [30, 100]
		///     }
		///     }
		///     ]
		///     如果想分别定义 visualMap-continuous 本身的视觉样式和 目标系列 的视觉样式，则这样定义：
		///     visualMap: [
		///     {
		///     ...,
		///     // 表示 目标系列 的视觉样式。
		///     target: {
		///     inRange: {
		///     color: ['#121122', 'rgba(3,4,5,0.4)', 'red'],
		///     symbolSize: [60, 200]
		///     }
		///     },
		///     // 表示 visualMap-continuous 本身的视觉样式。
		///     controller: {
		///     inRange: {
		///     symbolSize: [30, 100]
		///     }
		///     }
		///     }
		///     ]
		///     或者这样定义：
		///     visualMap: [
		///     {
		///     ...,
		///     // 表示 目标系列 的视觉样式 和 visualMap-continuous 共有的视觉样式。
		///     inRange: {
		///     color: ['#121122', 'rgba(3,4,5,0.4)', 'red'],
		///     symbolSize: [60, 200]
		///     },
		///     // 表示 visualMap-continuous 本身的视觉样式，会覆盖共有的视觉样式。比如，symbolSize 覆盖成为 [30, 100]，而 color 不变。
		///     controller: {
		///     inRange: {
		///     symbolSize: [30, 100]
		///     }
		///     }
		///     }
		///     ]
		///     ✦ 关于视觉通道 ✦
		///     inRange 中，可以有任意几个的『视觉通道』定义（如 color、symbolSize 等）。这些视觉通道，会被同时采用。
		///     一般来说，建议使用 透明度（opacity） ，而非 颜色透明度（colorAlpha） （他们细微的差异在于，前者能也同时控制图元中的附属物（如 label）的透明度，而后者只能控制图元本身颜色的透明度）。
		///     视觉映射的方式：支持两种方式：线性映射、查表映射。
		///     ✦ 视觉通道 -- 线性映射 ✦
		///     线性映射 表示 series.data 中的每一个值（dataValue）会经过线性映射计算，从 [visualMap.min, visualMap.max] 映射到设定的 [visual value 1, visual
		///     value 2] 区间中的某一个视觉的值（下称 visual value）。
		///     例如，我们设置了 [visualMap.min, visualMap.max] 为 [0, 100]，并且我们有 series.data: [50, 10, 100]。我们想将其映射到范围为 [0.4, 1] 的 opacity
		///     上，从而达到用透明度表达数值大小的目的。那么 visualMap 组件会对 series.data 中的每一个 dataValue 做线性映射计算，得到一个 opacityValue。最终得到的 opacityValues 为
		///     [0.7, 0.44, 1]。
		///     visual 范围也可以反向，例如上例，可以设定 opacity 范围为 [1, 0.4]，则上例得到的 opacityValues 为 [0.7, 0.96, 0.4]。
		///     注意，[visualMap.min, visualMap.max] 须手动设置，不设置则默认取 [0, 100]，而非 series.data 中的 dataMin 和 dataMax。
		///     如何设定为线性映射？以下情况时，会设定为 线性映射：
		///     当 visualMap 为 visualMap-continuous 时，或者
		///     当 visualMap 为 visualMap-piecewise 且 未设置 visualMap-piecewise.categories 时。
		///     视觉通道的值（visual value）：
		///     视觉通道的值一般都以 Array 形式表示，例如：color: ['#333', '#777']。
		///     如果写成 number 或 string，会转成 Array。例如，写成 opacity: 0.4 会转成 opacity: [0.4, 0.4]，color: '#333' 会转成 color: ['#333',
		///     '#333']。
		///     对于
		///     图形大小（symbolSize）、透明度（opacity）、颜色透明度（colorAlpha）、颜色明暗度（colorLightness）、颜色饱和度（colorSaturation）、色调（colorHue）：形如Array
		///     的视觉范围总是表示：[最小数据值对应的视觉值, 最大数据值对应的视觉值]。比如：colorLightness: [0.8, 0.2]，表示 series.data 中，和 visualMap.min 相等的值（如果有的话）映射到
		///     颜色明暗 的 0.8，和 visualMap.max 相等的值（如果有的话）映射到 颜色明暗 的 0.2，中间其他数据值，按照线性计算出映射结果。
		///     对于 颜色（color），使用数组表示例如：['#333', '#78ab23', 'blue']。意思就是以这三个点作为基准，形成一种『渐变』的色带，数据映射到这个色带上。也就是说，与 visualMap.min
		///     相等的值会映射到 '#333'，与 visualMap.max 相等的值会映射到 'blue'。对于 visualMap.min 和 visualMap.max 中间的其他点，以所给定的 '#333', '#78ab23',
		///     'blue' 这三个颜色作为基准点进行分段线性插值，得到映射结果。
		///     对于 图形类别（symbol）：使用数据表示例如：['circle', 'rect', 'diamond']。与 visualMap.min 相等的值会映射到 'circle'，与 visualMap.max 相等的值会映射到
		///     'diamond'。对于 中间的其他点，会根据他们和 visualMap.min 和 visualMap.max 的数值距离，映射到 'circle', 'rect', 'diamond' 中某个值上。
		///     visual value 的取值范围：
		///     透明度（opacity）、颜色透明度（colorAlpha）、颜色明暗度（colorLightness）、颜色饱和度（colorSaturation）、visual value
		///     取值范围是 [0, 1]。
		///     色调（colorHue）：
		///     取值范围是 [0, 360]。
		///     颜色（color）：
		///     颜色可以使用 RGB 表示，比如 'rgb(128, 128, 128)'，如果想要加上 alpha 通道，可以使用 RGBA，比如 'rgba(128, 128, 128, 0.5)'，也可以使用十六进制格式，比如
		///     '#ccc'。
		///     图形类别（symbol）：
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
		///     ✦ 视觉通道 -- 查表映射 ✦
		///     查表映射 表示 series.data 中的所有值（dataValue）是可枚举的，会根据给定的映射表查表得到映射结果。
		///     例如，在 visualMap-piecewise 中，我们设定了 visualMap-piecewise.categories 为 ['Demon Hunter', 'Blademaster', 'Death Knight',
		///     'Warden', 'Paladin']。我们有 series.data: ['Demon Hunter', 'Death Knight', 'Warden', 'Paladin']。然后我们可以定立查表映射规则：color:
		///     {'Warden': 'red', 'Demon Hunter': 'black'}，于是 visualMap 组件会按照表来将 dataValue 映射到 color。
		///     如何设定为查表映射？当 visualMap 为 visualMap-piecewise 且 设置了 visualMap-piecewise.categories 时，会进行查表映射。
		///     视觉通道的值（visual value）：一般使用 Object 或 Array 来表示，例如：
		///     visualMap: {
		///     type: 'piecewise',
		///     // categories 定义了 visualMap-piecewise 组件显示出来的项。
		///     categories: [
		///     'Demon Hunter', 'Blademaster', 'Death Knight', 'Warden', 'Paladin'
		///     ],
		///     inRange: {
		///     // visual value 可以配成 Object：
		///     color: {
		///     'Warden': 'red',
		///     'Demon Hunter': 'black',
		///     '': 'green' // 空字串，表示除了'Warden'、'Demon Hunter'外，都对应到 'green'。
		///     }
		///     // visual value 也可以只配一个单值，表示所有都映射到一个值，如：
		///     color: 'green',
		///     // visual value 也可以配成数组，这个数组须和 categories 数组等长，
		///     // 每个数组项和 categories 数组项一一对应：
		///     color: ['red', 'black', 'green', 'yellow', 'white']
		///     }
		///     }
		///     参见示例
		///     ✦ 修改视觉编码 ✦
		///     如果在图表被渲染后（即已经使用 setOption 设置了初始 option 之后），想修改 visualMap 的各种 视觉编码，按照惯例，再次使用 setOption 即可。例如：
		///     chart.setOption({
		///     visualMap: {
		///     inRange: {color: ['red', 'blue']}
		///     }
		///     });
		///     但请注意：
		///     visualMap option 中的这几个属性，inRange, outOfRange, target, controller，在 setOption 时不支持 merge。否则会带来过于复杂的 merge
		///     逻辑。也就是说，setOption 时，一旦修改了以上几个属性中的一项，其他项也会被清空，而非保留当前状态。所以，设置 visual 值时，请一次性全部设置，而非只设置一部分。
		///     不推荐使用 getOption -> 修改option -> setOption 的方式：
		///     // 不推荐这样做（尽管也能达到和上面的例子相同的结果）：
		///     var option = chart.getOption(); // 获取所有option。
		///     option.visualMap.inRange.color = ['red', 'blue']; // 改动color（我想要改变 color）。
		///     // 如下两处也要进行同步改动，否则可能达不到期望效果。
		///     option.visualMap.target.inRange.color = ['red', 'blue'];
		///     option.visualMap.controller.inRange.color = ['red', 'blue'];
		///     chart.setOption(option); // option设置回 visualMap
		///     注意，inRange 没有指定，则会默认会设置 color: ['#f6efa6', '#d88273', '#bf444c']，如果你不想要这个color，可以
		///     inRange: {color: null} 来去除。
		/// </summary>
		[JsonProperty("inRange")]
		public object InRange { get; set; }

		/// <summary>
		///     定义 在选中范围外 的视觉元素。（用户可以和 visualMap 组件交互，用鼠标或触摸选择范围）
		///     配置参考 visualMap-continuous.inRange
		/// </summary>
		[JsonProperty("outOfRange")]
		public object OutOfRange { get; set; }

		/// <summary>
		///     visualMap 组件中，控制器 的 inRange outOfRange 设置。如果没有这个 controller 设置，控制器 会使用外层的 inRange outOfRange 设置；如果有这个 controller
		///     设置，则会采用这个设置。适用于一些控制器视觉效果需要特殊定制或调整的场景。
		/// </summary>
		[JsonProperty("controller")]
		public VisualMapContinuous_Controller Controller { get; set; }

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
		///     visualMap 组件离容器左侧的距离。
		///     left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		///     如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		///     visualMap 组件离容器上侧的距离。
		///     top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		///     如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		///     visualMap 组件离容器右侧的距离。
		///     right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		///     visualMap 组件离容器下侧的距离。
		///     bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		///     如何放置 visualMap 组件，水平（'horizontal'）或者竖直（'vertical'）。
		/// </summary>
		[JsonProperty("orient")]
		public string Orient { get; set; }

		/// <summary>
		///     visualMap-continuous内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。
		///     使用示例：
		///     // 设置内边距为 5
		///     padding: 5
		///     // 设置上下的内边距为 5，左右的内边距为 10
		///     padding: [5, 10]
		///     // 分别设置四个方向的内边距
		///     padding: [
		///     5,  // 上
		///     10, // 右
		///     5,  // 下
		///     10, // 左
		///     ]
		/// </summary>
		[JsonProperty("padding")]
		public ArrayOrSingle Padding { get; set; }

		/// <summary>
		///     背景色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		///     边框颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		///     边框线宽，单位px。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		///     这个配置项，是为了兼容 ECharts2 而存在，ECharts3 中已经不推荐使用。它的功能已经移到了 visualMap-continuous.inRange 和 visualMap-continuous.outOfRange
		///     中。
		///     如果要使用，则须注意，color属性中的顺序是由数值 大 到 小，但是 visualMap-continuous.inRange 或 visualMap-continuous.outOfRange 中 color
		///     的顺序，总是由数值 小 到 大。二者不一致。
		/// </summary>
		[JsonProperty("color")]
		public double[] Color { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("textStyle")]
		public Legend_PageTextStyle TextStyle { get; set; }

		/// <summary>
		///     标签的格式化工具。
		///     如果为string，表示模板，例如：aaaa{value}。其中 {value} 是当前的范围边界值。
		///     如果为 Function，表示回调函数，形如：
		///     formatter: function (value) {
		///     return 'aaaa' + value; // 范围标签显示内容。
		///     }
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     两端手柄的形状。默认为
		///     'M-11.39,9.77h0a3.5,3.5,0,0,1-3.5,3.5h-22a3.5,3.5,0,0,1-3.5-3.5h0a3.5,3.5,0,0,1,3.5-3.5h22A3.5,3.5,0,0,1-11.39,9.77Z'
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
		[JsonProperty("handleIcon")]
		public string HandleIcon { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     手柄的大小。可以是相对于组件尺寸的百分比大小。
		/// </summary>
		[JsonProperty("handleSize")]
		public StringOrNumber HandleSize { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     手柄的样式配置。
		/// </summary>
		[JsonProperty("handleStyle")]
		public HandleStyle0 HandleStyle { get; set; }

		/// <summary>
		///     指示器的形状，默认为圆形。指示器在鼠标移到组件上，或者在移到系列图形上联动高亮的时候出现。
		///     从 v5.0.0 开始支持
		/// </summary>
		[JsonProperty("indicatorIcon")]
		public string IndicatorIcon { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     指示器的大小。可以是相对于组件尺寸的百分比大小。
		/// </summary>
		[JsonProperty("indicatorSize")]
		public StringOrNumber IndicatorSize { get; set; }

		/// <summary>
		///     指示器样式。
		/// </summary>
		[JsonProperty("indicatorStyle")]
		public HandleStyle0 IndicatorStyle { get; set; }
	}
}