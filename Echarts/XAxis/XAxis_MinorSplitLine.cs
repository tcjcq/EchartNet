using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v4.6.0 开始支持
        /// 
        /// 坐标轴在 grid 区域中的次分隔线。次分割线会对齐次刻度线 minorTick
    /// </summary>
    public class XAxis_MinorSplitLine
    {
        /// <summary>
        /// 是否显示次分隔线。默认不显示。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle1 LineStyle { get; set; }

    }
 }
