using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 请参见 移动端自适应。
    /// </summary>
    public class Media
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minWidth")]
        public double? MinWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("maxHeight")]
        public double? MaxHeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minAspectRatio")]
        public double? MinAspectRatio { get; set; }

    }
 }
