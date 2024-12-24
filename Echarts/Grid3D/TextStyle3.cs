using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 
    /// </summary>
    public class TextStyle3
    {
        /// <summary>
        /// 刻度标签文字的颜色，默认取 axisLine.lineStyle.color。支持回调函数，格式如下
        /// (val: string) => Color
        /// 
        /// 参数是标签的文本，返回颜色值，如下示例：
        /// textStyle: {
        ///     color: function (value, index) {
        ///         return value >= 0 ? 'green' : 'red';
        ///     }
        /// }
        /// </summary>
        [JsonProperty("color")]
        public Color Color { get; set; }

        /// <summary>
        /// 文字的描边宽度。
        /// </summary>
        [JsonProperty("borderWidth")]
        public double? BorderWidth { get; set; }

        /// <summary>
        /// 文字的描边颜色。
        /// </summary>
        [JsonProperty("borderColor")]
        public string BorderColor { get; set; }

        /// <summary>
        /// 文字的字体系列。
        /// </summary>
        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        /// <summary>
        /// 文字的字体大小。
        /// </summary>
        [JsonProperty("fontSize")]
        public double? FontSize { get; set; }

        /// <summary>
        /// 文字字体的粗细。
        /// 可选：
        /// 
        /// 'normal'
        /// 'bold'
        /// 'bolder'
        /// 'lighter'
        /// 100 | 200 | 300 | 400...
        /// </summary>
        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

    }
 }
