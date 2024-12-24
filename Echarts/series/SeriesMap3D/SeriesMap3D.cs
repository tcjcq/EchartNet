using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 三维地图
        /// 三维地图主要用于地理区域数据的可视化，配合 visualMap 组件用于展示不同区域的人口分布密度等数据。
        /// 相比于二维的地图，三维地图还能每个区域设置不同的高度，这个高度能够用来展示数据，也能够用来显示建筑数据中建筑的高度。
    /// </summary>
    public class SeriesMap3D
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="map3D";

        /// <summary>
        /// 系列名称，用于 tooltip 的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 地图类型。echarts-gl 中使用的地图类型同 geo 组件相同。
        /// ECharts 提供了两种格式的地图数据，一种是可以直接通过 script 标签引入的 js 文件，引入后会自动注册地图名字和数据。还有一种是 JSON 文件，需要通过 AJAX 异步加载后手动注册。
        /// 下面是两种类型的使用示例：
        ///  JavaScript 引入示例 
        /// <script src="echarts.js"></script>
        /// <script src="map/js/china.js"></script>
        /// <script>
        /// var chart = echarts.init(document.getElementById('main'));
        /// chart.setOption({
        ///     series: [{
        ///         type: 'map',
        ///         map: 'china'
        ///     }]
        /// });
        /// </script>
        /// 
        ///  JSON 引入示例 
        /// $.get('map/json/china.json', function (chinaJson) {
        ///     echarts.registerMap('china', chinaJson);
        ///     var chart = echarts.init(document.getElementById('main'));
        ///     chart.setOption({
        ///         series: [{
        ///             type: 'map',
        ///             map: 'china'
        ///         }]
        ///     });
        /// });
        /// 
        /// ECharts 使用 GeoJSON 格式的数据作为地图的轮廓。除此之外，你也可以通过其它手段获取地图的 GeoJSON 格式的数据注册到 ECharts 中。
        /// </summary>
        [JsonProperty("map")]
        public string Map { get; set; }

        /// <summary>
        /// 三维地图在三维场景中的宽度。配合 viewControl.distance 可以得到最合适的展示尺寸。
        /// 下面是三维地图 中boxWidth, boxHeight, boxDepth, regionHeight的示意图。
        /// </summary>
        [JsonProperty("boxWidth")]
        public double? BoxWidth { get; set; }

        /// <summary>
        /// 三维地图在三维场景中的高度。
        /// 组件高度。这个高度包含三维地图上的柱状图、散点图的高度。
        /// </summary>
        [JsonProperty("boxHeight")]
        public double? BoxHeight { get; set; }

        /// <summary>
        /// 三维地图在三维场景中的深度。
        /// 组件深度默认自动，保证三维组件的显示比例跟输入的 GeoJSON 的比例相同。
        /// </summary>
        [JsonProperty("boxDepth")]
        public double? BoxDepth { get; set; }

        /// <summary>
        /// 三维地图每个区域的高度。这个高度是模型的高度，小于 boxHeight。boxHeight - regionHeight 这一片区域会被用于三维柱状图，散点图等的展示。
        /// </summary>
        [JsonProperty("regionHeight")]
        public double? RegionHeight { get; set; }

        /// <summary>
        /// 环境贴图。支持纯色、渐变色、全景贴图的 url。默认为 'auto'，在配置有 light.ambientCubemap.texture 的时候会使用该纹理作为环境贴图。否则则不显示环境贴图。
        /// 示例：
        /// // 配置为全景贴图
        /// environment: 'asset/starfield.jpg'
        /// // 配置为纯黑色的背景
        /// environment: '#000'
        /// // 配置为垂直渐变的背景
        /// environment: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
        ///   offset: 0, color: '#00aaff' // 天空颜色
        /// }, {
        ///   offset: 0.7, color: '#998866' // 地面颜色
        /// }, {
        ///   offset: 1, color: '#998866' // 地面颜色
        /// }], false)
        /// </summary>
        [JsonProperty("environment")]
        public string Environment { get; set; }

        /// <summary>
        /// 地面可以让整个组件有个“摆放”的地方，从而使整个场景看起来更真实，更有模型感。
        /// groundPlane 下支持设置单独的 realisticMaterial, colorMaterial, lambertMaterial 等材质。如果不设置则默认取组件下的材质参数。
        /// </summary>
        [JsonProperty("groundPlane")]
        public Geo3D_GroundPlane GroundPlane { get; set; }

        /// <summary>
        /// instancing会将 GeoJSON 中所有的 geometry 合并成一个，在 GeoJSON 拥有特别多（上千）的 geometry 时可以有效提升绘制效率。
        /// </summary>
        [JsonProperty("instancing")]
        public bool? Instancing { get; set; }

        /// <summary>
        /// 标签的相关设置。
        /// </summary>
        [JsonProperty("label")]
        public Geo3D_Label Label { get; set; }

        /// <summary>
        /// 三维地图 中三维图形的视觉属性，包括颜色，透明度，描边等。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle13 ItemStyle { get; set; }

        /// <summary>
        /// 鼠标 hover 高亮时图形和标签的样式。
        /// </summary>
        [JsonProperty("emphasis")]
        public SeriesMap3D_Emphasis Emphasis { get; set; }

        /// <summary>
        /// 地图区域的设置。
        /// </summary>
        [JsonProperty("data")]
        public SeriesMap3D_Data[] Data { get; set; }

        /// <summary>
        /// 三维地图中三维图形的着色效果。echarts-gl 中支持下面三种着色方式：
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
        /// 光照相关的设置。在 shading 为 'color' 的时候无效。
        /// 光照的设置会影响到组件以及组件所在坐标系上的所有图表。
        /// 合理的光照设置能够让整个场景的明暗变得更丰富，更有层次。
        /// </summary>
        [JsonProperty("light")]
        public SeriesMap3D_Light Light { get; set; }

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
        [JsonProperty("postEffect")]
        public SeriesMap3D_PostEffect PostEffect { get; set; }

        /// <summary>
        /// 分帧超采样。在开启 postEffect 后，WebGL 默认的 MSAA 会无法使用，所以我们需要自己解决锯齿的问题。
        /// 分帧超采样是用来解决锯齿问题的方法，它在画面静止后会持续分帧对一个像素多次抖动采样，从而达到抗锯齿的效果。而且在这个分帧采样的过程中，echarts-gl 也会对 postEffect 中一些需要采样保证效果的特效，例如 SSAO, 景深，以及阴影进行渐进增强。
        /// 下面是未开启和开启temporalSuperSampling的区别。
        /// </summary>
        [JsonProperty("temporalSuperSampling")]
        public Globe_TemporalSuperSampling TemporalSuperSampling { get; set; }

        /// <summary>
        /// viewControl用于鼠标的旋转，缩放等视角控制。
        /// </summary>
        [JsonProperty("viewControl")]
        public Geo3D_ViewControl ViewControl { get; set; }

        /// <summary>
        /// 组件所在的层。
        /// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
        /// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
        /// 注: echarts-gl 中组件的层需要跟 echarts 中组件的层分开。同一个 zlevel 不能同时用于 WebGL 和 Canvas 的绘制。
        /// </summary>
        [JsonProperty("zlevel")]
        public double? Zlevel { get; set; }

        /// <summary>
        /// 组件的视图离容器左侧的距离。
        /// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
        /// 如果 left 的值为'left', 'center', 'right'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("left")]
        public StringOrNumber Left { get; set; }

        /// <summary>
        /// 组件的视图离容器上侧的距离。
        /// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
        /// 如果 top 的值为'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("top")]
        public StringOrNumber Top { get; set; }

        /// <summary>
        /// 组件的视图离容器右侧的距离。
        /// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// 默认自适应。
        /// </summary>
        [JsonProperty("right")]
        public StringOrNumber Right { get; set; }

        /// <summary>
        /// 组件的视图离容器下侧的距离。
        /// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// 默认自适应。
        /// </summary>
        [JsonProperty("bottom")]
        public StringOrNumber Bottom { get; set; }

        /// <summary>
        /// 组件的视图宽度。
        /// </summary>
        [JsonProperty("width")]
        public StringOrNumber Width { get; set; }

        /// <summary>
        /// 组件的视图高度。
        /// </summary>
        [JsonProperty("height")]
        public StringOrNumber Height { get; set; }

    }
 }
