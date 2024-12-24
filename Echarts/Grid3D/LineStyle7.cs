using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 
    /// </summary>
    public class LineStyle7
    {
        /// <summary>
        /// 刻度线的颜色，默认取 axisLine.lineStyle.color。
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// 线条的不透明度。
        /// </summary>
        [JsonProperty("opacity")]
        public double? Opacity { get; set; }

        /// <summary>
        /// 线条的宽度。
        /// </summary>
        [JsonProperty("width")]
        public double? Width { get; set; }

    }
 }
