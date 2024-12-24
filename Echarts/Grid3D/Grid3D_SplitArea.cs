using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 坐标轴在 grid3D 的平面上的分隔区域。
    /// </summary>
    public class Grid3D_SplitArea
    {
        /// <summary>
        /// 是否显示分隔区域。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 坐标轴分隔区域的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
        /// 默认会自动计算interval以保证较好的展示效果。
        /// 可以设置成 0 强制显示所有标签。
        /// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示『隔两个标签显示一个标签』，以此类推。
        /// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
        /// (index:number, value: string) => boolean
        /// 
        /// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
        /// </summary>
        [JsonProperty("interval")]
        public StringOrNumber Interval { get; set; }

        /// <summary>
        /// 分隔区域的样式设置。
        /// </summary>
        [JsonProperty("areaStyle")]
        public AreaStyle2 AreaStyle { get; set; }

    }
 }
