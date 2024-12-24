using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 各个类型对应的系列的列表。
    /// </summary>
    public class Toolbox_Feature_MagicType_SeriesIndex
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("line")]
        public double[] Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bar")]
        public double[] Bar { get; set; }

    }
 }
