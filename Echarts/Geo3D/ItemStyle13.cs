using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 三维地理坐标系组件 中三维图形的视觉属性，包括颜色，透明度，描边等。
    /// </summary>
    public class ItemStyle13
    {
        /// <summary>
        /// 图形的颜色。 默认从全局调色盘 option.color 获取颜色 
        /// 除了颜色字符串外，支持使用数组表示的 RGBA 值，例如：
        /// // 纯白色
        /// [1, 1, 1, 1]
        /// 
        /// 使用数组表示的时候，每个通道可以设置大于 1 的值用于表示 HDR 的色值。
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// 图形的不透明度。
        /// </summary>
        [JsonProperty("opacity")]
        public double? Opacity { get; set; }

        /// <summary>
        /// 图形描边的宽度。加上描边后可以更清晰的区分每个区域。如下图：
        /// </summary>
        [JsonProperty("borderWidth")]
        public double? BorderWidth { get; set; }

        /// <summary>
        /// 图形描边的颜色。
        /// </summary>
        [JsonProperty("borderColor")]
        public string BorderColor { get; set; }

    }
 }
