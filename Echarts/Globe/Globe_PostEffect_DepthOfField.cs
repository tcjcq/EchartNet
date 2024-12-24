using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 景深效果。景深效果是模拟摄像机的光学成像效果，在对焦的区域相对清晰，离对焦的区域越远则会逐渐模糊。
        /// 景深效果可以让观察者集中注意力到对焦的区域，而且让画面的镜头感更强，大景深还能塑造出微距的模型效果。
        /// 下面分别是关闭和开启景深的区别。
    /// </summary>
    public class Globe_PostEffect_DepthOfField
    {
        /// <summary>
        /// 是否开启景深。
        /// </summary>
        [JsonProperty("enable")]
        public bool? Enable { get; set; }

        /// <summary>
        /// 初始的焦距，用户可以点击区域自动聚焦。
        /// </summary>
        [JsonProperty("focalDistance")]
        public bool? FocalDistance { get; set; }

        /// <summary>
        /// 完全聚焦的区域范围，在此范围内的物体时完全清晰的，不会有模糊
        /// </summary>
        [JsonProperty("focalRange")]
        public bool? FocalRange { get; set; }

        /// <summary>
        /// 镜头的F值，值越小景深越浅。
        /// </summary>
        [JsonProperty("fstop")]
        public double? Fstop { get; set; }

        /// <summary>
        /// 焦外的模糊半径
        /// 不同模糊半径的区别：
        /// </summary>
        [JsonProperty("blurRadius")]
        public double? BlurRadius { get; set; }

    }
 }
