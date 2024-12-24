using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// atmosphere用于地球外部大气层相关设置。
    /// </summary>
    public class Globe_Atmosphere
    {
        /// <summary>
        /// 是否显示外部大气层，默认不显示。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 外部大气层相对于默认位置的偏移。
        /// </summary>
        [JsonProperty("offset")]
        public double? Offset { get; set; }

        /// <summary>
        /// 外部大气层的颜色。
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// 外部大气层发光功率。
        /// </summary>
        [JsonProperty("glowPower")]
        public double? GlowPower { get; set; }

        /// <summary>
        /// 外部大气层内发光功率。
        /// </summary>
        [JsonProperty("innerGlowPower")]
        public double? InnerGlowPower { get; set; }

    }
 }
