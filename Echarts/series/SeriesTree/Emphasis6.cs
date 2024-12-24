using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 节点高亮状态的配置。
    /// </summary>
    public class Emphasis6
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
        /// 该节点的样式。
        /// </summary>
        [JsonProperty("itemStyle")]
        public HandleStyle0 ItemStyle { get; set; }

        /// <summary>
        /// 定义树图边的样式。
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle4 LineStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label")]
        public Label5 Label { get; set; }

    }
 }
