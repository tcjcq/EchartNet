using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 这是坐标轴指示器（axisPointer）的全局公用设置。
	/// 
	/// 
	/// 
	/// 坐标轴指示器是指示坐标轴当前刻度的工具。
	/// 如下例，鼠标悬浮到图上，可以出现标线和刻度文本。
	/// 
	/// 
	/// 
	/// 上例中，使用了 axisPointer.link 来关联不同的坐标系中的 axisPointer。
	/// 坐标轴指示器也有适合触屏的交互方式，如下：
	/// 
	/// 
	/// 
	/// 坐标轴指示器在多轴的场景能起到辅助作用：
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 注意：
	/// 一般来说，axisPointer 的具体配置项会配置在各个轴中（如 xAxis.axisPointer）或者 tooltip 中（如 tooltip.axisPointer）。
	/// 
	/// 
	/// 但是这几个选项只能配置在全局的 axisPointer 中：axisPointer.triggerOn、axisPointer.link。
	/// 
	/// 
	/// 如何显示 axisPointer：
	/// 直角坐标系 grid、极坐标系 polar、单轴坐标系 single 中的每个轴都自己的 axisPointer。
	/// 他们的 axisPointer 默认不显示。有两种方法可以让他们显示：
	/// 
	/// 设置轴上的 axisPointer.show（例如 xAxis.axisPointer.show）为 true，则显示此轴的 axisPointer。
	/// 
	/// 设置 tooltip.trigger 设置为 'axis' 或者 tooltip.axisPointer.type 设置为 'cross'，则此时坐标系会自动选择显示哪个轴的 axisPointer，也可以使用 tooltip.axisPointer.axis 改变这种选择。注意，轴上如果设置了 axisPointer，会覆盖此设置。
	/// 
	/// 
	/// 
	/// 如何显示 axisPointer 的 label：
	/// axisPointer 的 label 默认不显示（也就是默认只显示指示线），除非：
	/// 
	/// 设置轴上的 axisPointer.label.show（例如 xAxis.axisPointer.label.show）为 true，则显示此轴的 axisPointer 的 label。
	/// 
	/// 设置 tooltip.axisPointer.type 为 'cross' 时会自动显示 axisPointer 的 label。
	/// 
	/// 
	/// 
	/// 关于触屏的 axisPointer 的设置
	/// 设置轴上的 axisPointer.handle.show（例如 xAxis.axisPointer.handle.show 为 true 则会显示出此 axisPointer 的拖拽按钮。（polar 坐标系暂不支持此功能）。
	/// 注意：
	/// 如果发现此时 tooltip 效果不良好，可设置 tooltip.triggerOn 为 'none'（于是效果为：手指按住按钮则显示 tooltip，松开按钮则隐藏 tooltip），或者 tooltip.alwaysShowContent 为 true（效果为 tooltip 一直显示）。
	/// 参见例子。
	/// 
	/// 自动吸附到数据（snap）
	/// 对于数值轴、时间轴，如果开启了 snap，则 axisPointer 会自动吸附到最近的点上。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class AxisPointer
	{
		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 默认不显示。但是如果 tooltip.trigger 设置为 'axis' 或者 tooltip.axisPointer.type 设置为 'cross'，则自动显示 axisPointer。坐标系会自动选择显示显示哪个轴的 axisPointer，也可以使用 tooltip.axisPointer.axis 改变这种选择。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 指示器类型。
		/// 可选
		/// 
		/// 'line' 直线指示器
		/// 
		/// 'shadow' 阴影指示器
		/// 
		/// 'none' 无指示器
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "line";

		/// <summary>
		/// 坐标轴指示器是否自动吸附到点上。默认自动判断。
		/// 这个功能在数值轴和时间轴上比较有意义，可以自动寻找细小的数值点。
		/// </summary>
		[JsonProperty("snap")]
		public bool? Snap { get; set; }

		/// <summary>
		/// 坐标轴指示器的 z 值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 坐标轴指示器的文本标签。
		/// </summary>
		[JsonProperty("label")]
		public Label0 Label { get; set; }

		/// <summary>
		/// axisPointer.type 为 'line' 时有效。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		/// axisPointer.type 为 'shadow' 时有效。
		/// </summary>
		[JsonProperty("shadowStyle")]
		public ShadowStyle0 ShadowStyle { get; set; }

		/// <summary>
		/// 从 v5.4.3 开始支持
		/// 
		/// 是否触发系列强调功能。
		/// </summary>
		[JsonProperty("triggerEmphasis")]
		public bool? TriggerEmphasis { get; set; }

		/// <summary>
		/// 是否触发 tooltip。如果不想触发 tooltip 可以关掉。
		/// </summary>
		[JsonProperty("triggerTooltip")]
		public bool? TriggerTooltip { get; set; }

		/// <summary>
		/// 当前的 value。在使用 axisPointer.handle 时，可以设置此值进行初始值设定，从而决定 axisPointer 的初始位置。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		/// 当前的状态，可取值为 'show' 和 'hide'。
		/// </summary>
		[JsonProperty("status")]
		public bool? Status { get; set; }

		/// <summary>
		/// 拖拽手柄，适用于触屏的环境。参见 例子。
		/// </summary>
		[JsonProperty("handle")]
		public XAxis_AxisPointer_Handle Handle { get; set; }

		/// <summary>
		/// 不同轴的 axisPointer 可以进行联动，在这里设置。联动表示轴能同步一起活动。轴依据他们的 axisPointer 当前对应的值来联动。
		/// 联动的效果可以看这两个例子：例子A，例子B。
		/// link 是一个数组，其中每一项表示一个 link group，一个 group 中的坐标轴互相联动。例如：
		/// link: [
		///     {
		///         // 表示所有 xAxisIndex 为 0、3、4 和 yAxisName 为 'someName' 的坐标轴联动。
		///         xAxisIndex: [0, 3, 4],
		///         yAxisName: 'someName'
		///     },
		///     {
		///         // 表示左右 xAxisId 为 'aa'、'cc' 以及所有的 angleAxis 联动。
		///         xAxisId: ['aa', 'cc'],
		///         angleAxis: 'all'
		///     },
		///     ...
		/// ]
		/// 
		/// 如上所示，每个 link group 中可以用这些方式引用坐标轴：
		/// {
		///     // 以下的 'some' 均表示轴的维度，也就是表示 'x', 'y', 'radius', 'angle', 'single'
		///     someAxisIndex: [...], // 可以是一个数组或单值或 'all'
		///     someAxisName: [...],  // 可以是一个数组或单值或 'all'
		///     someAxisId: [...],    // 可以是一个数组或单值或 'all'
		/// }
		/// 
		/// 
		/// 如何联动不同类型（axis.type）的轴？
		/// 如果 axis 的类型不同，比如 axisA type 为 'category'，axisB type 为 'time'，可以在每个 link group 中写转换函数（mapper）来进行值的转换，例如：
		/// link: [{
		///     xAxisIndex: [0, 1],
		///     yAxisName: ['yy'],
		///     mapper: function (sourceVal, sourceAxisInfo, targetAxisInfo) {
		///         if (sourceAxisInfo.axisName === 'yy') {
		///             // from timestamp to '2012-02-05'
		///             return echarts.time.format('yyyy-MM-dd', sourceVal);
		///         }
		///         else if (targetAxisInfo.axisName === 'yy') {
		///             // from '2012-02-05' to date
		///             return echarts.time.parse(dates[sourceVal]);
		///         }
		///         else {
		///             return sourceVal;
		///         }
		///     }
		/// }]
		/// 
		/// mapper 的输入参数：
		/// {number} sourceVal
		/// {Object} sourceAxisInfo 里面包含 {axisDim, axisId, axisName, axisIndex} 等信息
		/// {Object} targetAxisInfo 里面包含 {axisDim, axisId, axisName, axisIndex} 等信息
		/// mapper 的返回值：
		/// {number} 转换结果
		/// </summary>
		[JsonProperty("link")]
		public double[] Link { get; set; }

		/// <summary>
		/// 提示框触发的条件，可选：
		/// 
		/// 'mousemove'
		///   鼠标移动时触发。
		/// 
		/// 'click'
		///   鼠标点击时触发。
		/// 
		/// 'none'
		///   不在 'mousemove' 或 'click' 时触发。
		/// </summary>
		[JsonProperty("triggerOn")]
		public string TriggerOn { get; set; }
	}
}