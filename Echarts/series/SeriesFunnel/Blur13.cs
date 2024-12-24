using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v5.0.0 开始支持
        /// 
        /// 淡出时的图形样式和标签样式。开启 emphasis.focus 后有效
    /// </summary>
    public class Blur13
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label")]
        public Label14 Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("labelLine")]
        public XAxis_MinorSplitLine LabelLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("itemStyle")]
        public HandleStyle0 ItemStyle { get; set; }

    }
 }
