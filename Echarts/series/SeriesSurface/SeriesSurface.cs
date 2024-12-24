using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 曲面图。支持通过 parametric 绘制参数曲面。
        /// 下图就是一个配置成金属材质的类似一个金属零件的参数曲面。
    /// </summary>
    public class SeriesSurface
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="surface";

        /// <summary>
        /// 系列名称，用于 tooltip 的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 该系列使用的坐标系，可选：
        /// 
        /// 'cartesian3D'
        ///   使用三维笛卡尔坐标系，通过 grid3DIndex 指定相应的三维笛卡尔坐标系组件。
        /// </summary>
        [JsonProperty("coordinateSystem")]
        public string CoordinateSystem { get; set; }

        /// <summary>
        /// 使用的 grid3D 组件的索引。默认使用第一个 grid3D 组件。
        /// </summary>
        [JsonProperty("grid3DIndex")]
        public double? Grid3DIndex { get; set; }

        /// <summary>
        /// 是否为参数曲面。
        /// </summary>
        [JsonProperty("parametric")]
        public bool? Parametric { get; set; }

        /// <summary>
        /// 曲面图的网格线。
        /// </summary>
        [JsonProperty("wireframe")]
        public SeriesSurface_Wireframe Wireframe { get; set; }

        /// <summary>
        /// 曲面的函数表达式。如果需要展示的是函数曲面，可以不设置 data，通过 equation 去声明函数表达式。例如通过下面这个函数可以模拟波纹效果。
        /// equation: {
        ///     x: {
        ///         step: 0.1,
        ///         min: -3,
        ///         max: 3,
        ///     },
        ///     y: {
        ///         step: 0.1,
        ///         min: -3,
        ///         max: 3,
        ///     },
        ///     z: function (x, y) {
        ///         return Math.sin(x * x + y * y) * x / 3.14
        ///     }
        /// }
        /// </summary>
        [JsonProperty("equation")]
        public SeriesSurface_Equation Equation { get; set; }

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
        [JsonProperty("parametricEquation")]
        public SeriesSurface_ParametricEquation ParametricEquation { get; set; }

        /// <summary>
        /// 曲面的颜色、不透明度等样式。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle12 ItemStyle { get; set; }

        /// <summary>
        /// 曲面图的数据数组。
        /// 数据是线性存储的数组，包含X 顶点数xY 顶点数个数据。一个 5 x 5 的曲面共有 25 个顶点，数据在数组中的索引如下
        /// 
        /// 上图使用的数据：
        /// data: [
        ///     [-1,-1,0],[-0.5,-1,0],[0,-1,0],[0.5,-1,0],[1,-1,0],
        ///     [-1,-0.5,0],[-0.5,-0.5,1],[0,-0.5,0],[0.5,-0.5,-1],[1,-0.5,0],
        ///     [-1,0,0],[-0.5,0,0],[0,0,0],[0.5,0,0],[1,0,0],
        ///     [-1,0.5,0],[-0.5,0.5,-1],[0,0.5,0],[0.5,0.5,1],[1,0.5,0],
        ///     [-1,1,0],[-0.5,1,0],[0,1,0],[0.5,1,0],[1,1,0]
        /// ]
        /// 
        /// 每一项分别为 x, y, z。
        /// 对于参数方程来说，每一项需要存储五个数据，分别是 x, y, z 和参数 u, v。而数据的索引按照u, v 的顺序。例如下面的数据：
        /// data: [
        ///     // v 为 0，u 从 -3.14 到 3.13
        ///     [0,0,1,-3.14,0],[0,0,1,-1.57,0],[0,0,1,0,0],[0,0,1,1.57,0],[0,0,1,3.14,0],
        ///     // v 为 1.57，u 从 -3.14 到 3.13
        ///     [0,-1,0,-3.14,1.57],[-1,0,0,-1.57,1.57],[0,1,0,0,1.57],[1,0,0,1.57,1.57],[0,-1,0,3.14,1.57],
        ///     // v 为 3.14，u 从 -3.14 到 3.13
        ///     [0,0,-1,-3.14,3.14],[0,0,-1,-1.57,3.14],[0,0,-1,0,3.14],[0,0,-1,1.57,3.14],[0,0,-1,3.14,3.14]]
        /// ]
        /// 
        /// 有些时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
        /// [{
        ///     // 数据项的名称
        ///     name: '数据1',
        ///     // 数据项值
        ///     value: [12, 14, 10]
        /// }, {
        ///     name: '数据2',
        ///     value: [34, 50, 15]
        /// }]
        /// 
        /// 需要对个别内容指定进行个性化定义时：
        /// [{
        ///     name: '数据1',
        ///     value: [12, 14, 10]
        /// }, {
        ///     // 数据项名称
        ///     name: '数据2',
        ///     value : [34, 50, 15],
        ///     //自定义特殊itemStyle，仅对该item有效
        ///     itemStyle:{}
        /// }]
        /// </summary>
        [JsonProperty("data")]
        public SeriesSurface_Data[] Data { get; set; }

        /// <summary>
        /// 曲面图中三维图形的着色效果。echarts-gl 中支持下面三种着色方式：
        /// 
        /// 'color'
        /// 只显示颜色，不受光照等其它因素的影响。
        /// 
        /// 'lambert'
        /// 通过经典的 lambert 着色表现光照带来的明暗。
        /// 
        /// 'realistic'
        /// 真实感渲染，配合 light.ambientCubemap 和 postEffect 使用可以让展示的画面效果和质感有质的提升。ECharts GL 中使用了基于物理的渲染（PBR） 来表现真实感材质。
        /// </summary>
        [JsonProperty("shading")]
        public string Shading { get; set; }

        /// <summary>
        /// 真实感材质相关的配置项，在 shading 为'realistic'时有效。
        /// </summary>
        [JsonProperty("realisticMaterial")]
        public Globe_RealisticMaterial RealisticMaterial { get; set; }

        /// <summary>
        /// lambert 材质相关的配置项，在 shading 为'lambert'时有效。
        /// </summary>
        [JsonProperty("lambertMaterial")]
        public Globe_LambertMaterial LambertMaterial { get; set; }

        /// <summary>
        /// color 材质相关的配置项，在 shading 为'color'时有效。
        /// </summary>
        [JsonProperty("colorMaterial")]
        public Globe_LambertMaterial ColorMaterial { get; set; }

        /// <summary>
        /// 组件所在的层。
        /// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
        /// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
        /// 注: echarts-gl 中组件的层需要跟 echarts 中组件的层分开。同一个 zlevel 不能同时用于 WebGL 和 Canvas 的绘制。
        /// </summary>
        [JsonProperty("zlevel")]
        public double? Zlevel { get; set; }

        /// <summary>
        /// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
        /// </summary>
        [JsonProperty("silent")]
        public bool? Silent { get; set; }

        /// <summary>
        /// 是否开启动画。
        /// </summary>
        [JsonProperty("animation")]
        public bool? Animation { get; set; }

        /// <summary>
        /// 过渡动画的时长。
        /// </summary>
        [JsonProperty("animationDurationUpdate")]
        public double? AnimationDurationUpdate { get; set; }

        /// <summary>
        /// 过渡动画的缓动效果。
        /// </summary>
        [JsonProperty("animationEasingUpdate")]
        public string AnimationEasingUpdate { get; set; }

    }
 }
