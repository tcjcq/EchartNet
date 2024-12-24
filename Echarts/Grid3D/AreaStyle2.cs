using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 分隔区域的样式设置。
    /// </summary>
    public class AreaStyle2
    {
        /// <summary>
        /// 分隔区域颜色。分隔区域会按数组中颜色的顺序依次循环设置颜色。默认是一个深浅的间隔色。
        /// </summary>
        [JsonProperty("color")]
        public double[] Color { get; set; }

    }
 }
