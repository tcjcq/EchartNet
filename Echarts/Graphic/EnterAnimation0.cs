using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 入场动画配置。
    /// </summary>
    public class EnterAnimation0
    {
        /// <summary>
        /// 动画时长，单位 ms
        /// </summary>
        [JsonProperty("duration")]
        public double? Duration { get; set; }

        /// <summary>
        /// 动画缓动。不同的缓动效果可以参考 缓动示例。
        /// </summary>
        [JsonProperty("easing")]
        public string Easing { get; set; }

        /// <summary>
        /// 动画延迟时长，单位 ms
        /// </summary>
        [JsonProperty("delay")]
        public double? Delay { get; set; }

    }
 }
