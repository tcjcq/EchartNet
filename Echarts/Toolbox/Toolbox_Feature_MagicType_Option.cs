using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 各个类型的专有配置项。在切换到某类型的时候会合并相应的配置项。
    /// </summary>
    public class Toolbox_Feature_MagicType_Option
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("line")]
        public object Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bar")]
        public object Bar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("stack")]
        public object Stack { get; set; }

    }
 }
