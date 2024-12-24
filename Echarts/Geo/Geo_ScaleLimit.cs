using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 滚轮缩放的极限控制，通过 min 和 max 限制最小和最大的缩放值。
    /// </summary>
    public class Geo_ScaleLimit
    {
        /// <summary>
        /// 最小的缩放值
        /// </summary>
        [JsonProperty("min")]
        public double? Min { get; set; }

        /// <summary>
        /// 最大的缩放值
        /// </summary>
        [JsonProperty("max")]
        public double? Max { get; set; }

    }
 }
