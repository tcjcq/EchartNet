using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 坐标轴指示线。
    /// </summary>
    public class ZAxis3D_AxisPointer
    {
        /// <summary>
        /// 是否显示坐标轴指示线。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle6 LineStyle { get; set; }

        /// <summary>
        /// 指示线标签。
        /// </summary>
        [JsonProperty("label")]
        public Grid3D_AxisPointer_Label Label { get; set; }

    }
 }
