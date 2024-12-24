using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// K 线图的图形样式。
    /// </summary>
    public class ItemStyle9
    {
        /// <summary>
        /// 阳线 图形的颜色。
        /// 
        /// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// 阴线 图形的颜色。
        /// 
        /// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
        /// </summary>
        [JsonProperty("color0")]
        public Color Color0 { get; set; }

        /// <summary>
        /// 阳线 图形的描边颜色。
        /// 
        /// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
        /// </summary>
        [JsonProperty("borderColor")]
        public Color BorderColor { get; set; }

        /// <summary>
        /// 阴线 图形的描边颜色。
        /// 
        /// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
        /// </summary>
        [JsonProperty("borderColor0")]
        public Color BorderColor0 { get; set; }

        /// <summary>
        /// 从 v5.4.1 开始支持
        /// 
        /// 十字星（开盘价等于收盘价）的描边颜色。
        /// 
        /// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
        /// </summary>
        [JsonProperty("borderColorDoji")]
        public Color BorderColorDoji { get; set; }

        /// <summary>
        /// candlestick 描边线宽。为 0 时无描边。
        /// </summary>
        [JsonProperty("borderWidth")]
        public double? BorderWidth { get; set; }

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
