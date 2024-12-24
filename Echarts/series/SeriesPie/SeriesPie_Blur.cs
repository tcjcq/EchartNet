using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v5.0.0 开始支持
        /// 
        /// 淡出状态的扇区和标签样式。开启 emphasis.focus 后有效。
    /// </summary>
    public class SeriesPie_Blur
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label")]
        public Label7 Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("labelLine")]
        public XAxis_MinorSplitLine LabelLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle5 ItemStyle { get; set; }

    }
 }
