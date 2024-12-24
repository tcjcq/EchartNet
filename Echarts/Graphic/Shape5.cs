using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 
    /// </summary>
    public class Shape5
    {
        /// <summary>
        /// 开始点的 x 值。
        /// </summary>
        [JsonProperty("x1")]
        public double? X1 { get; set; }

        /// <summary>
        /// 开始点的 y 值。
        /// </summary>
        [JsonProperty("y1")]
        public double? Y1 { get; set; }

        /// <summary>
        /// 结束点的 x 值。
        /// </summary>
        [JsonProperty("x2")]
        public double? X2 { get; set; }

        /// <summary>
        /// 结束点的 y 值。
        /// </summary>
        [JsonProperty("y2")]
        public double? Y2 { get; set; }

        /// <summary>
        /// 线画到百分之多少就不画了。值的范围：[0, 1]。
        /// </summary>
        [JsonProperty("percent")]
        public double? Percent { get; set; }

        /// <summary>
        /// 可以是一个属性名，或者一组属性名。
        /// 被指定的属性，在其指发生变化时，会开启过渡动画。
        /// 只可以指定本 shape 下的属性。
        /// 例如：
        /// {
        ///     type: 'rect',
        ///     shape: {
        ///         // ...
        ///         // 这两个属性会开启过渡动画。
        ///         transition: ['mmm', 'ppp']
        ///     }
        /// }
        /// 
        /// 我们这样可以指定 shape 下所有属性开启过渡动画：
        /// {
        ///     type: 'rect',
        ///     shape: { ... },
        ///     // `shape` 下所有属性开启过渡动画。
        ///     transition: 'shape',
        /// }
        /// </summary>
        [JsonProperty("transition")]
        public ArrayOrSingle Transition { get; set; }

    }
 }
