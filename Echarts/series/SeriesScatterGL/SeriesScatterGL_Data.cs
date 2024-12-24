using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 散点图的数据集。
        /// 数据格式同 scatter.data
    /// </summary>
    public class SeriesScatterGL_Data
    {
        /// <summary>
        /// 数据项名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 数据项值
        /// </summary>
        [JsonProperty("value")]
        public ArrayOrSingle Value { get; set; }

        /// <summary>
        /// 单个数据图形的样式。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle13 ItemStyle { get; set; }

    }
 }
