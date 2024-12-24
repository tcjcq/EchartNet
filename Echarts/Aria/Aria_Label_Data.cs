using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 数据相关的配置项。
    /// </summary>
    public class Aria_Label_Data
    {
        /// <summary>
        /// 描述中每个系列最多出现的数据个数。
        /// </summary>
        [JsonProperty("maxCount")]
        public double? MaxCount { get; set; }

        /// <summary>
        /// 当数据全部显示时采用的描述。这一配置项不会使得数据全部显示，可以通过将 aria.data.maxCount 设置为 Number.MAX_VALUE 实现全部显示的效果。
        /// </summary>
        [JsonProperty("allData")]
        public string AllData { get; set; }

        /// <summary>
        /// 当只有部分数据显示时采用的描述。其中包括模板变量：
        /// 
        /// {displayCnt}：将被替换为显示的数据个数。
        /// </summary>
        [JsonProperty("partialData")]
        public string PartialData { get; set; }

        /// <summary>
        /// 如果数据有 name 属性，则采用该描述。其中包括模板变量：
        /// 
        /// {name}：将被替换为数据的 name；
        /// {value}：将被替换为数据的值。
        /// </summary>
        [JsonProperty("withName")]
        public string WithName { get; set; }

        /// <summary>
        /// 如果数据没有 name 属性，则采用该描述。其中包括模板变量：
        /// 
        /// {value}：将被替换为数据的值。
        /// </summary>
        [JsonProperty("withoutName")]
        public string WithoutName { get; set; }

        /// <summary>
        /// 数据与数据之间描述的分隔符。
        /// </summary>
        [JsonProperty("separator")]
        public Aria_Label_Data_Separator Separator { get; set; }

    }
 }
