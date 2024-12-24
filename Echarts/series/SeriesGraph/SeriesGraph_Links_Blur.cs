using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v5.0.0 开始支持
        /// 
        /// 该关系边的淡出状态。
    /// </summary>
    public class SeriesGraph_Links_Blur
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
        public Label5 Label { get; set; }

    }
 }
