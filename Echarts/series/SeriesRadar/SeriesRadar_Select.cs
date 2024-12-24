using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v5.0.0 开始支持
        /// 
        /// 选中状态的配置。开启 selectedMode 后有效。
    /// </summary>
    public class SeriesRadar_Select
    {
        /// <summary>
        /// 从 v5.3.0 开始支持
        /// 
        /// 是否可以被选中。在开启selectedMode的时候有效，可以用于关闭部分数据。
        /// </summary>
        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("itemStyle")]
        public HandleStyle0 ItemStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label")]
        public Label1 Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle1 LineStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("areaStyle")]
        public ShadowStyle0 AreaStyle { get; set; }

    }
 }
