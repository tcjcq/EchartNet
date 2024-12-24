using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 后处理特效的相关配置。后处理特效可以为画面添加高光、景深、环境光遮蔽（SSAO）、调色等效果。可以让整个画面更富有质感。
        /// 下面分别是关闭和开启 postEffect 的区别。
        /// 
        ///     
        ///     
        /// 
        /// 
        /// 注意在开启 postEffect 的时候默认会开启 temporalSuperSampling 在画面静止后持续对画面增强，包括抗锯齿、景深、SSAO、阴影等。
    /// </summary>
    public class SeriesMap3D_PostEffect
    {
        /// <summary>
        /// 是否开启后处理特效。默认关闭。
        /// </summary>
        [JsonProperty("enable")]
        public bool? Enable { get; set; }

        /// <summary>
        /// 高光特效。高光特效用来表现很“亮”的颜色，因为传统的 RGB 只能表现0 - 255范围的颜色，所以对于超出这个范围特别“亮”的颜色，会通过这种高光溢出的特效去表现。如下图：
        /// </summary>
        [JsonProperty("bloom")]
        public Globe_PostEffect_Bloom Bloom { get; set; }

        /// <summary>
        /// 景深效果。景深效果是模拟摄像机的光学成像效果，在对焦的区域相对清晰，离对焦的区域越远则会逐渐模糊。
        /// 景深效果可以让观察者集中注意力到对焦的区域，而且让画面的镜头感更强，大景深还能塑造出微距的模型效果。
        /// 下面分别是关闭和开启景深的区别。
        /// </summary>
        [JsonProperty("depthOfField")]
        public Globe_PostEffect_DepthOfField DepthOfField { get; set; }

        /// <summary>
        /// 屏幕空间的环境光遮蔽效果。环境光遮蔽效果可以让拐角处、洞、缝隙等大部分光无法到达的区域变暗，是传统的阴影贴图的补充，可以让整个场景更加自然，有层次。
        /// 下面是无 SSAO 和有 SSAO 的效果对比：
        /// </summary>
        [JsonProperty("screenSpaceAmbientOcclusion")]
        public object ScreenSpaceAmbientOcclusion { get; set; }

        /// <summary>
        /// 同 screenSpaceAmbientOcclusion
        /// </summary>
        [JsonProperty("SSAO")]
        public Globe_PostEffect_SSAO SSAO { get; set; }

        /// <summary>
        /// 颜色纠正和调整。类似 Photoshop 中的 Color Adjustments。
        /// 下图同个场景调整为冷色系和暖色系的区别。
        /// </summary>
        [JsonProperty("colorCorrection")]
        public Globe_PostEffect_ColorCorrection ColorCorrection { get; set; }

        /// <summary>
        /// 在开启 postEffect 后，WebGL 默认的 MSAA (Multi Sampling Anti Aliasing) 会无法使用。这时候通过 FXAA (Fast Approximate Anti-Aliasing) 可以廉价方便的解决抗锯齿的问题，FXAA 会对一些场景的边缘部分进行模糊从而解决锯齿的问题，这在一些场景上效果还不错，但是在 echarts-gl 中，需要保证很多文字和线条边缘的锐利清晰，因此 FXAA 并不是那么适用。这时候我们可以通过设置更高的devicePixelRatio来使用超采样，如下所示：
        /// var chart = echarts.init(dom, null, {
        ///     devicePixelRatio: 2
        /// })
        /// 
        /// 但是设置更高的devicePixelRatio 对电脑性能有很高的要求，所以更多时候我们建议使用 echarts-gl 中的 temporalSuperSampling，在画面静止后会持续分帧对一个像素多次抖动采样，从而达到超采样抗锯齿的效果。
        /// </summary>
        [JsonProperty("FXAA")]
        public Globe_TemporalSuperSampling FXAA { get; set; }

    }
 }
