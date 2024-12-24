using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 地面可以让整个组件有个“摆放”的地方，从而使整个场景看起来更真实，更有模型感。
        /// groundPlane 下支持设置单独的 realisticMaterial, colorMaterial, lambertMaterial 等材质。如果不设置则默认取组件下的材质参数。
    /// </summary>
    public class Geo3D_GroundPlane
    {
        /// <summary>
        /// 是否显示地面。
        /// </summary>
        [JsonProperty("show")]
        public bool? Show { get; set; }

        /// <summary>
        /// 地面颜色。
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

    }
 }
