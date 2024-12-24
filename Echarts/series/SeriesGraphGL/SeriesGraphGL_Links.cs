using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 节点间的关系数据。
        /// 数据格式同 graph.links
    /// </summary>
    public class SeriesGraphGL_Links
    {
        /// <summary>
        /// 边的源节点名称的字符串，也支持使用数字表示源节点的索引。
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// 边的目标节点名称的字符串，也支持使用数字表示源节点的索引。
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }

        /// <summary>
        /// 边的数值。
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }

        /// <summary>
        /// 单条边的样式。
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle6 LineStyle { get; set; }

    }
 }
