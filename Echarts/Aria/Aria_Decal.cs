using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 为系列数据增加贴花纹理，作为颜色的辅助，帮助区分数据。使用默认贴花图案的方式非常简单，只需要开启即可：
        /// aria: {
        ///     enabled: true,
        ///     decal: {
        ///         show: true
        ///     }
        /// }
        /// 
        /// 
        /// 
        /// 绝大部分支持填充色的系列都支持贴花图案，包括：'line', 'bar', 'pie', 'radar', 'treemap', 'sunburst', 'boxplot', 'sankey', 'funnel', 'gauge', 'pictorialBar', 'themeRiver', 'custom' 等。其中，部分系列默认没有填充色（如 'line', 'radar', 'boxplot'）需要在设置了填充样式 areaStyle 的情况下才生效。
    /// </summary>
    public class Aria_Decal
    {
        /// <summary>
        /// 是否显示贴花图案，默认不显示。如果要显示贴花，需要保证 aria.enabled 与 aria.decal.show 都是 true。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 贴花图案的样式。如果是 Object 类型，表示为所有数据采用同样的样式，如果是数组，则数组的每一项各为一种样式，数据将会依次循环取数组中的样式。
        /// </summary>
        [JsonProperty("decals")]
        public Decal0 Decals { get; set; }

    }
 }
