using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 
    /// </summary>
    public class Shape3
    {
        /// <summary>
        /// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的横坐标值。
        /// </summary>
        [JsonProperty("cx")]
        public double? Cx { get; set; }

        /// <summary>
        /// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
        /// </summary>
        [JsonProperty("cy")]
        public double? Cy { get; set; }

        /// <summary>
        /// 外半径。
        /// </summary>
        [JsonProperty("r")]
        public double? R { get; set; }

        /// <summary>
        /// 内半径。
        /// </summary>
        [JsonProperty("r0")]
        public double? R0 { get; set; }

        /// <summary>
        /// 开始弧度。
        /// </summary>
        [JsonProperty("startAngle")]
        public double? StartAngle { get; set; }

        /// <summary>
        /// 结束弧度。
        /// </summary>
        [JsonProperty("endAngle")]
        public double? EndAngle { get; set; }

        /// <summary>
        /// 是否顺时针。
        /// </summary>
        [JsonProperty("clockwise")]
        public bool? Clockwise { get; set; }

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
