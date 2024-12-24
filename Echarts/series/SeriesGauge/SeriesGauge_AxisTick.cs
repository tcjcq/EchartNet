using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 刻度样式。
    /// </summary>
    public class SeriesGauge_AxisTick
    {
        /// <summary>
        /// 是否显示刻度。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 分隔线之间分割的刻度数。
        /// </summary>
        [JsonProperty("splitNumber")]
        public double? SplitNumber { get; set; }

        /// <summary>
        /// 刻度线长。支持相对半径的百分比。
        /// </summary>
        [JsonProperty("length")]
        public StringOrNumber Length { get; set; }

        /// <summary>
        /// 从 v5.0 开始支持
        /// 
        /// 
        /// 
        /// 刻度线与轴线的距离。
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
