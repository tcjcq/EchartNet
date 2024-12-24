using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 坐标轴指示器配置项。
        /// tooltip.axisPointer 是配置坐标轴指示器的快捷方式。实际上坐标轴指示器的全部功能，都可以通过轴上的 axisPointer 配置项完成（例如 xAxis.axisPointer 或 angleAxis.axisPointer）。但是使用 tooltip.axisPointer 在简单场景下会更方便一些。
        /// 
        /// 注意： tooltip.axisPointer 中诸配置项的优先级低于轴上的 axisPointer 的配置项。
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
    public class Grid_Tooltip_AxisPointer
    {
        /// <summary>
        /// 指示器类型。
        /// 可选
        /// 
        /// 'line' 直线指示器
        /// 
        /// 'shadow' 阴影指示器
        /// 
        /// 'none' 无指示器
        /// 
        /// 'cross' 十字准星指示器。其实是种简写，表示启用两个正交的轴的 axisPointer。
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="line";

        /// <summary>
        /// 指示器的坐标轴。
        /// 默认情况，坐标系会自动选择显示哪个轴的 axisPointer（默认取类目轴或者时间轴）。
        /// 可以是 'x', 'y', 'radius', 'angle'。
        /// </summary>
        [JsonProperty("axis")]
        public string Axis { get; set; }

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
        /// axisPointer.type 为 'cross' 时有效。
        /// </summary>
        [JsonProperty("crossStyle")]
        public LineStyle1 CrossStyle { get; set; }

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
 }
