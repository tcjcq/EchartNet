using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 分隔线样式。
    /// </summary>
    public class SeriesGauge_SplitLine
    {
        /// <summary>
        /// 是否显示分隔线。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 分隔线线长。支持相对半径的百分比。
        /// </summary>
        [JsonProperty("length")]
        public StringOrNumber Length { get; set; }

        /// <summary>
        /// 从 v5.0 开始支持
        /// 
        /// 
        /// 
        /// 分隔线与轴线的距离。
        /// </summary>
        [JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle1 LineStyle { get; set; }

    }
 }
