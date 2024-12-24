using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 地球表面层的配置，你可以使用该配置项加入云层，或者对 baseTexture 进行补充绘制出国家的轮廓等等。
    /// </summary>
    public class Globe_Layers
    {
        /// <summary>
        /// 是否显示该层。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 层的类型，可选：
        /// 
        /// 'overlay'
        /// 
        /// 在地表上的覆盖层，可以用来显示云层等。
        /// 
        /// 'blend'
        /// 
        /// 跟 baseTexture 混合。
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="overlay";

        /// <summary>
        /// 层的名字，在用 setOption 设置层属性的时候可以用 name 来标识需要更新的层。
        /// chart.setOption({
        ///     globe: {
        ///         layer: [{
        ///             // 更新 name 为 'cloud' 的层的纹理
        ///             name: 'cloud',
        ///             texture: 'cloud.png'
        ///         }]
        ///     }
        /// });
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 在 type 为 'blend' 时有效。
        /// 可选：
        /// 
        /// albedo 混合到 albedo，受光照的影响。
        /// 
        /// emission 混合到自发光，不受光照影响。
        /// </summary>
        [JsonProperty("blendTo")]
        public string BlendTo { get; set; }

        /// <summary>
        /// 混合的强度。
        /// </summary>
        [JsonProperty("intensity")]
        public double? Intensity { get; set; }

        /// <summary>
        /// 覆盖层的着色效果，同 globe.shading， 支持 'color', 'lambert', 'realistic'
        /// 在 type 为 'overlay' 时有效。
        /// </summary>
        [JsonProperty("shading")]
        public string Shading { get; set; }

        /// <summary>
        /// 覆盖层离地球表面的距离。
        /// 在 type 为 'overlay' 时有效。
        /// </summary>
        [JsonProperty("distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// 层的纹理，支持图片路径的字符串、图片对象或者 Canvas 的对象。
        /// 也支持直接使用 echarts 的实例作为纹理，此时在地球上的鼠标动作会跟纹理上使用的 echarts 实例有联动。
        /// </summary>
        [JsonProperty("texture")]
        public string Texture { get; set; }

    }
 }
