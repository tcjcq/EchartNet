using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v4.7.0 开始支持
        /// 
        /// 每一个柱条的背景样式。需要将 showBackground 设置为 true 时才有效。
    /// </summary>
    public class SeriesBar_BackgroundStyle
    {
        /// <summary>
        /// 柱条的颜色。 
        /// 
        /// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// 柱条的描边颜色。
        /// </summary>
        [JsonProperty("borderColor")]
        public Color BorderColor { get; set; }

        /// <summary>
        /// 柱条的描边宽度，默认不描边。
        /// </summary>
        [JsonProperty("borderWidth")]
        public double? BorderWidth { get; set; }

        /// <summary>
        /// 柱条的描边类型，默认为实线，支持 'dashed', 'dotted'。
        /// </summary>
        [JsonProperty("borderType")]
        public string BorderType { get; set; }

        /// <summary>
        /// 圆角半径，单位px，支持传入数组分别指定 4 个圆角半径。
        /// 如:
        /// borderRadius: 5, // 统一设置四个角的圆角大小
        /// borderRadius: [5, 5, 0, 0] //（顺时针左上，右上，右下，左下）
        /// </summary>
        [JsonProperty("borderRadius")]
        public ArrayOrSingle BorderRadius { get; set; }

        /// <summary>
        /// 图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
        /// 示例：
        /// {
        ///     shadowColor: 'rgba(0, 0, 0, 0.5)',
        ///     shadowBlur: 10
        /// }
        /// </summary>
        [JsonProperty("shadowBlur")]
        public double? ShadowBlur { get; set; }

        /// <summary>
        /// 阴影颜色。支持的格式同color。
        /// </summary>
        [JsonProperty("shadowColor")]
        public Color ShadowColor { get; set; }

        /// <summary>
        /// 阴影水平方向上的偏移距离。
        /// </summary>
        [JsonProperty("shadowOffsetX")]
        public double? ShadowOffsetX { get; set; }

        /// <summary>
        /// 阴影垂直方向上的偏移距离。
        /// </summary>
        [JsonProperty("shadowOffsetY")]
        public double? ShadowOffsetY { get; set; }

        /// <summary>
        /// 图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
        /// </summary>
        [JsonProperty("opacity")]
        public double? Opacity { get; set; }

    }
 }
