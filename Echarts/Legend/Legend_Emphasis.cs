using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 
    /// </summary>
    public class Legend_Emphasis
    {
        /// <summary>
        /// 从 v4.4.0 开始支持
        /// </summary>
        [JsonProperty("selectorLabel")]
        public Legend_SelectorLabel SelectorLabel { get; set; }

    }
 }
