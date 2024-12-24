using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 曲面的参数方程。在data没被设置的时候，可以通过 parametricEquation 去声明参数参数方程。在 parametric 为true时有效。
        /// 参数方程是 x、y、 z 关于参数 u、v 的方程。
        /// 下面的参数方程就是绘制前面图中类似一个金属零件的参数曲面的：
        /// var aa = 0.4;
        /// var r = 1 - aa * aa;
        /// var w = sqrt(r);
        /// ...
        /// parametricEquation: {
        ///     u: {
        ///         min: -13.2,
        ///         max: 13.2,
        ///         step: 0.5
        ///     },
        ///     v: {
        ///         min: -37.4,
        ///         max: 37.4,
        ///         step: 0.5
        ///     },
        ///     x: function (u, v) {
        ///         var denom = aa * (pow(w * cosh(aa * u), 2) + aa * pow(sin(w * v), 2))
        ///         return -u + (2 * r * cosh(aa * u) * sinh(aa * u) / denom);
        ///     },
        ///     y: function (u, v) {
        ///         var denom = aa * (pow(w * cosh(aa * u), 2) + aa * pow(sin(w * v), 2))
        ///         return 2 * w * cosh(aa * u) * (-(w * cos(v) * cos(w * v)) - (sin(v) * sin(w * v))) / denom;
        ///     },
        ///     z: function (u, v) {
        ///         var denom = aa * (pow(w * cosh(aa * u), 2) + aa * pow(sin(w * v), 2))
        ///         return  2 * w * cosh(aa * u) * (-(w * sin(v) * cos(w * v)) + (cos(v) * sin(w * v))) / denom
        ///     }
        /// }
    /// </summary>
    public class SeriesSurface_ParametricEquation
    {
        /// <summary>
        /// 自变量 u。
        /// </summary>
        [JsonProperty("u")]
        public SeriesSurface_ParametricEquation_U U { get; set; }

        /// <summary>
        /// 自变量 v。
        /// </summary>
        [JsonProperty("v")]
        public SeriesSurface_ParametricEquation_U V { get; set; }

        /// <summary>
        /// x 为关于 u, v 的函数。
        /// (u: number, v: number) => number
        /// </summary>
        [JsonProperty("x")]
        public string X { get; set; }

        /// <summary>
        /// x 为关于 u, v 的函数。
        /// (u: number, v: number) => number
        /// </summary>
        [JsonProperty("y")]
        public string Y { get; set; }

        /// <summary>
        /// x 为关于 u, v 的函数。
        /// (u: number, v: number) => number
        /// </summary>
        [JsonProperty("z")]
        public string Z { get; set; }

    }
 }
