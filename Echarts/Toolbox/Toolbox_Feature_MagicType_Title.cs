using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 各个类型的标题文本，可以分别配置。
    /// </summary>
    public class Toolbox_Feature_MagicType_Title
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("line")]
        public string Line { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bar")]
        public string Bar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("stack")]
        public string Stack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tiled")]
        public string Tiled { get; set; }

    }
 }
