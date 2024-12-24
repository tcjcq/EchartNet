using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 坐标轴指示器配置项。
    /// </summary>
    public class SingleAxis_AxisPointer
    {
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
        public string Type { get; set; }="line";

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

    }
 }
