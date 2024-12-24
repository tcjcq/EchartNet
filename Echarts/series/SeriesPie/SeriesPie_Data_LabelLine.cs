using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 
    /// </summary>
    public class SeriesPie_Data_LabelLine
    {
        /// <summary>
        /// 是否显示视觉引导线。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 视觉引导线第一段的长度。
        /// </summary>
        [JsonProperty("length")]
        public double? Length { get; set; }

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
        /// 
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle1 LineStyle { get; set; }

    }
 }
