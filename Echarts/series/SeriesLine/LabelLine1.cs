using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
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
 }