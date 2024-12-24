using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 单轴。可以被应用到散点图中展现一维数据，如下示例
    /// </summary>
    public class SingleAxis
    {
        /// <summary>
        /// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

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
        /// single组件离容器左侧的距离。
        /// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
        /// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("left")]
        public StringOrNumber Left { get; set; }

        /// <summary>
        /// single组件离容器上侧的距离。
        /// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
        /// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("top")]
        public StringOrNumber Top { get; set; }

        /// <summary>
        /// single组件离容器右侧的距离。
        /// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// </summary>
        [JsonProperty("right")]
        public StringOrNumber Right { get; set; }

        /// <summary>
        /// single组件离容器下侧的距离。
        /// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// </summary>
        [JsonProperty("bottom")]
        public StringOrNumber Bottom { get; set; }

        /// <summary>
        /// single组件的宽度。默认自适应。
        /// </summary>
        [JsonProperty("width")]
        public StringOrNumber Width { get; set; }

        /// <summary>
        /// single组件的高度。默认自适应。
        /// </summary>
        [JsonProperty("height")]
        public StringOrNumber Height { get; set; }

        /// <summary>
        /// 轴的朝向，默认水平朝向，可以设置成 'vertical' 垂直朝向。
        /// </summary>
        [JsonProperty("orient")]
        public string Orient { get; set; }

        /// <summary>
        /// 坐标轴类型。
        /// 可选：
        /// 
        /// 'value'
        ///   数值轴，适用于连续数据。
        /// 
        /// 'category'
        ///   类目轴，适用于离散的类目数据。为该类型时类目数据可自动从 series.data 或 dataset.source 中取，或者可通过 singleAxis.data 设置类目数据。
        /// 
        /// 'time'
        ///   时间轴，适用于连续的时序数据，与数值轴相比时间轴带有时间的格式化，在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
        /// 
        /// 'log'
        ///   对数轴。适用于对数数据。对数轴下的堆积柱状图或堆积折线图可能带来很大的视觉误差，并且在一定情况下可能存在非预期效果，应避免使用。
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="value";

        /// <summary>
        /// 坐标轴名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 坐标轴名称显示位置。
        /// 可选：
        /// 
        /// 'start'
        /// 'middle' 或者 'center'
        /// 'end'
        /// </summary>
        [JsonProperty("nameLocation")]
        public string NameLocation { get; set; }

        /// <summary>
        /// 坐标轴名称的文字样式。
        /// </summary>
        [JsonProperty("nameTextStyle")]
        public NameTextStyle0 NameTextStyle { get; set; }

        /// <summary>
        /// 坐标轴名称与轴线之间的距离。
        /// </summary>
        [JsonProperty("nameGap")]
        public double? NameGap { get; set; }

        /// <summary>
        /// 坐标轴名字旋转，角度值。
        /// </summary>
        [JsonProperty("nameRotate")]
        public double? NameRotate { get; set; }

        /// <summary>
        /// 坐标轴名字的截断。
        /// </summary>
        [JsonProperty("nameTruncate")]
        public XAxis_NameTruncate NameTruncate { get; set; }

        /// <summary>
        /// 是否是反向坐标轴。
        /// </summary>
        [JsonProperty("inverse")]
        public bool? Inverse { get; set; }

        /// <summary>
        /// 坐标轴两边留白策略，类目轴和非类目轴的设置和表现不一样。
        /// 类目轴中 boundaryGap 可以配置为 true 和 false。默认为 true，这时候刻度只是作为分隔线，标签和数据点都会在两个刻度之间的带(band)中间。
        /// 非类目轴，包括时间，数值，对数轴，boundaryGap是一个两个值的数组，分别表示数据最小值和最大值的延伸范围，可以直接设置数值或者相对的百分比，在设置 min 和 max 后无效。
        /// 示例：
        /// boundaryGap: ['20%', '20%']
        /// </summary>
        [JsonProperty("boundaryGap")]
        public ArrayOrSingle BoundaryGap { get; set; }

        /// <summary>
        /// 坐标轴刻度最小值。
        /// 可以设置成特殊值 'dataMin'，此时取数据在该轴上的最小值作为最小刻度。
        /// 不设置时会自动计算最小值保证坐标轴刻度的均匀分布。
        /// 在类目轴中，也可以设置为类目的序数（如类目轴 data: ['类A', '类B', '类C'] 中，序数 2 表示 '类C'。也可以设置为负数，如 -3）。
        /// 当设置成 function 形式时，可以根据计算得出的数据最大最小值设定坐标轴的最小值。如：
        /// min: function (value) {
        ///     return value.min - 20;
        /// }
        /// 
        /// 其中 value 是一个包含 min 和 max 的对象，分别表示数据的最大最小值，这个函数可返回坐标轴的最小值，也可返回 null/undefined 来表示“自动计算最小值”（返回 null/undefined 从 v4.8.0 开始支持）。
        /// </summary>
        [JsonProperty("min")]
        public StringOrNumber Min { get; set; }

        /// <summary>
        /// 坐标轴刻度最大值。
        /// 可以设置成特殊值 'dataMax'，此时取数据在该轴上的最大值作为最大刻度。
        /// 不设置时会自动计算最大值保证坐标轴刻度的均匀分布。
        /// 在类目轴中，也可以设置为类目的序数（如类目轴 data: ['类A', '类B', '类C'] 中，序数 2 表示 '类C'。也可以设置为负数，如 -3）。
        /// 当设置成 function 形式时，可以根据计算得出的数据最大最小值设定坐标轴的最小值。如：
        /// max: function (value) {
        ///     return value.max - 20;
        /// }
        /// 
        /// 其中 value 是一个包含 min 和 max 的对象，分别表示数据的最大最小值，这个函数可返回坐标轴的最大值，也可返回 null/undefined 来表示“自动计算最大值”（返回 null/undefined 从 v4.8.0 开始支持）。
        /// </summary>
        [JsonProperty("max")]
        public StringOrNumber Max { get; set; }

        /// <summary>
        /// 只在数值轴中（type: 'value'）有效。
        /// 是否是脱离 0 值比例。设置成 true 后坐标刻度不会强制包含零刻度。在双数值轴的散点图中比较有用。
        /// 在设置 min 和 max 之后该配置项无效。
        /// </summary>
        [JsonProperty("scale")]
        public bool? Scale { get; set; }

        /// <summary>
        /// 坐标轴的分割段数，需要注意的是这个分割段数只是个预估值，最后实际显示的段数会在这个基础上根据分割后坐标轴刻度显示的易读程度作调整。
        /// 在类目轴中无效。
        /// </summary>
        [JsonProperty("splitNumber")]
        public double? SplitNumber { get; set; }

        /// <summary>
        /// 自动计算的坐标轴最小间隔大小。
        /// 例如可以设置成1保证坐标轴分割刻度显示成整数。
        /// {
        ///     minInterval: 1
        /// }
        /// 
        /// 只在数值轴或时间轴中（type: 'value' 或 'time'）有效。
        /// </summary>
        [JsonProperty("minInterval")]
        public double? MinInterval { get; set; }

        /// <summary>
        /// 自动计算的坐标轴最大间隔大小。
        /// 例如，在时间轴（（type: 'time'））可以设置成 3600 * 24 * 1000 保证坐标轴分割刻度最大为一天。
        /// {
        ///     maxInterval: 3600 * 24 * 1000
        /// }
        /// 
        /// 只在数值轴或时间轴中（type: 'value' 或 'time'）有效。
        /// </summary>
        [JsonProperty("maxInterval")]
        public double? MaxInterval { get; set; }

        /// <summary>
        /// 强制设置坐标轴分割间隔。
        /// 因为 splitNumber 是预估的值，实际根据策略计算出来的刻度可能无法达到想要的效果，这时候可以使用 interval 配合 min、max 强制设定刻度划分，一般不建议使用。
        /// 无法在类目轴中使用。在时间轴（type: 'time'）中需要传时间戳，在对数轴（type: 'log'）中需要传指数值。
        /// </summary>
        [JsonProperty("interval")]
        public double? Interval { get; set; }

        /// <summary>
        /// 对数轴的底数，只在对数轴中（type: 'log'）有效。
        /// </summary>
        [JsonProperty("logBase")]
        public double? LogBase { get; set; }

        /// <summary>
        /// 从 v5.5.1 开始支持
        /// 
        /// 用于指定轴的起始值。
        /// </summary>
        [JsonProperty("startValue")]
        public double? StartValue { get; set; }

        /// <summary>
        /// 坐标轴是否是静态无法交互。
        /// </summary>
        [JsonProperty("silent")]
        public bool? Silent { get; set; }

        /// <summary>
        /// 坐标轴的标签是否响应和触发鼠标事件，默认不响应。
        /// 事件参数如下：
        /// {
        ///     // 组件类型，xAxis, yAxis, radiusAxis, angleAxis
        ///     // 对应组件类型都会有一个属性表示组件的 index，例如 xAxis 就是 xAxisIndex
        ///     componentType: string,
        ///     // 未格式化过的刻度值, 点击刻度标签有效
        ///     value: '',
        ///     // 坐标轴名称, 点击坐标轴名称有效
        ///     name: ''
        /// }
        /// </summary>
        [JsonProperty("triggerEvent")]
        public bool? TriggerEvent { get; set; }

        /// <summary>
        /// 坐标轴轴线相关设置。
        /// </summary>
        [JsonProperty("axisLine")]
        public RadiusAxis_AxisLine AxisLine { get; set; }

        /// <summary>
        /// 坐标轴刻度相关设置。
        /// </summary>
        [JsonProperty("axisTick")]
        public AxisTick0 AxisTick { get; set; }

        /// <summary>
        /// 从 v4.6.0 开始支持
        /// 
        /// 坐标轴次刻度线相关设置。
        /// 注意：次刻度线无法在类目轴（type: 'category'）中使用。
        /// 示例：
        /// 1) 函数绘图中使用次刻度线
        /// 
        /// 
        /// 
        /// 2) 在对数轴中使用次刻度线
        /// </summary>
        [JsonProperty("minorTick")]
        public XAxis_MinorTick MinorTick { get; set; }

        /// <summary>
        /// 坐标轴刻度标签的相关设置。
        /// </summary>
        [JsonProperty("axisLabel")]
        public RadiusAxis_AxisLabel AxisLabel { get; set; }

        /// <summary>
        /// 坐标轴在 grid 区域中的分隔线。
        /// </summary>
        [JsonProperty("splitLine")]
        public XAxis_SplitLine SplitLine { get; set; }

        /// <summary>
        /// 从 v4.6.0 开始支持
        /// 
        /// 坐标轴在 grid 区域中的次分隔线。次分割线会对齐次刻度线 minorTick
        /// </summary>
        [JsonProperty("minorSplitLine")]
        public XAxis_MinorSplitLine MinorSplitLine { get; set; }

        /// <summary>
        /// 坐标轴在 grid 区域中的分隔区域，默认不显示。
        /// </summary>
        [JsonProperty("splitArea")]
        public XAxis_SplitArea SplitArea { get; set; }

        /// <summary>
        /// 类目数据，在类目轴（type: 'category'）中有效。
        /// 如果没有设置 type，但是设置了 axis.data，则认为 type 是 'category'。
        /// 如果设置了 type 是 'category'，但没有设置 axis.data，则 axis.data 的内容会自动从 series.data 中获取，这会比较方便。不过注意，axis.data 指明的是 'category' 轴的取值范围。如果不指定而是从 series.data 中获取，那么只能获取到 series.data 中出现的值。比如说，假如 series.data 为空时，就什么也获取不到。
        /// 示例：
        /// // 所有类目名称列表
        /// data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
        /// // 每一项也可以是具体的配置项，此时取配置项中的 `value` 为类目名
        /// data: [{
        ///     value: '周一',
        ///     // 突出周一
        ///     textStyle: {
        ///         fontSize: 20,
        ///         color: 'red'
        ///     }
        /// }, '周二', '周三', '周四', '周五', '周六', '周日']
        /// </summary>
        [JsonProperty("data")]
        public XAxis_Data Data { get; set; }

        /// <summary>
        /// 坐标轴指示器配置项。
        /// </summary>
        [JsonProperty("axisPointer")]
        public SingleAxis_AxisPointer AxisPointer { get; set; }

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
        /// 本坐标系特定的 tooltip 设定。
        /// 提示框组件的通用介绍：
        /// 提示框组件可以设置在多种地方：
        /// 
        /// 可以设置在全局，即 tooltip
        /// 
        /// 可以设置在坐标系中，即 grid.tooltip、polar.tooltip、single.tooltip
        /// 
        /// 可以设置在系列中，即 series.tooltip
        /// 
        /// 可以设置在系列的每个数据项中，即 series.data.tooltip
        /// </summary>
        [JsonProperty("tooltip")]
        public SingleAxis_Tooltip Tooltip { get; set; }

    }
 }
