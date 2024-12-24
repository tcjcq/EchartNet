using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// ambientCubemap 会使用纹理作为环境光的光源，会为物体提供漫反射和高光反射。可以通过 diffuseIntensity 和 specularIntensity 分别设置漫反射强度和高光反射强度。
    /// </summary>
    public class Globe_Light_AmbientCubemap
    {
        /// <summary>
        /// 环境光贴图的 url，支持使用.hdr格式的 HDR 图片。可以从 http://www.hdrlabs.com/sibl/archive.html 等网站获取 .hdr 的资源。
        /// 例如：
        /// ambientCubemap: {
        ///     texture: 'pisa.hdr',
        ///     // 解析 hdr 时使用的曝光值
        ///     exposure: 1.0
        /// }
        /// </summary>
        [JsonProperty("texture")]
        public string Texture { get; set; }

        /// <summary>
        /// 漫反射的强度。
        /// </summary>
        [JsonProperty("diffuseIntensity")]
        public double? DiffuseIntensity { get; set; }

        /// <summary>
        /// 高光反射的强度。
        /// </summary>
        [JsonProperty("specularIntensity")]
        public double? SpecularIntensity { get; set; }

    }
 }
