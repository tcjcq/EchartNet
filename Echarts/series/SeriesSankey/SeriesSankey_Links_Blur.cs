using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v5.0.0 开始支持
    /// </summary>
    public class SeriesSankey_Links_Blur
    {
        /// <summary>
        /// 从 v5.4.1 开始支持
        /// 
        /// 关系边文本标签的样式。
        /// </summary>
        [JsonProperty("edgeLabel")]
        public EdgeLabel1 EdgeLabel { get; set; }

        /// <summary>
        /// 关系边的线条样式。
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle5 LineStyle { get; set; }

    }
 }
