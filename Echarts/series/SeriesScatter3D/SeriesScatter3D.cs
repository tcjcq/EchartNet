using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 三维散点/气泡图。可以用于三维直角坐标系 grid3D，三维地理坐标系 geo3D，地球 globe，通过大小，颜色等属性展示数据。
        /// 下图示一个三维的 simplex noise 用气泡图绘制出来的例子。
    /// </summary>
    public class SeriesScatter3D
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="scatter3D";

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
        /// 
        /// 
        /// 
        /// 'geo3D'
        ///   使用三维地理坐标系，通过 geo3DIndex 指定相应的三维地理坐标系组件
        /// 
        /// 
        /// 
        /// 'globe'
        ///   使用地球坐标系，通过 globeIndex 指定相应的地球坐标系组件
        /// </summary>
        [JsonProperty("coordinateSystem")]
        public string CoordinateSystem { get; set; }

        /// <summary>
        /// 使用的 grid3D 组件的索引。默认使用第一个 grid3D 组件。
        /// </summary>
        [JsonProperty("grid3DIndex")]
        public double? Grid3DIndex { get; set; }

        /// <summary>
        /// 坐标轴使用的 geo3D 组件的索引。默认使用第一个 geo3D 组件。
        /// </summary>
        [JsonProperty("geo3DIndex")]
        public double? Geo3DIndex { get; set; }

        /// <summary>
        /// 坐标轴使用的 globe 组件的索引。默认使用第一个 globe 组件。
        /// </summary>
        [JsonProperty("globeIndex")]
        public double? GlobeIndex { get; set; }

        /// <summary>
        /// 散点的形状。默认为圆形。
        /// ECharts 提供的标记类型包括 
        /// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
        /// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适（如果是 symbol 的话就是 symbolSize）的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// 标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
        /// 如果需要每个数据的图形大小不一样，可以设置为如下格式的回调函数：
        /// (value: Array|number, params: Object) => number|Array
        /// 
        /// 其中第一个参数 value 为 data 中的数据值。第二个参数params 是其它的数据项参数。
        /// </summary>
        [JsonProperty("symbolSize")]
        public StringOrNumber SymbolSize { get; set; }

        /// <summary>
        /// 散点图颜色描边等样式。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle13 ItemStyle { get; set; }

        /// <summary>
        /// 标签样式
        /// </summary>
        [JsonProperty("label")]
        public SeriesScatter3D_Label Label { get; set; }

        /// <summary>
        /// 图形和标签高亮的样式。
        /// </summary>
        [JsonProperty("emphasis")]
        public SeriesScatter3D_Emphasis Emphasis { get; set; }

        /// <summary>
        /// 三维散点图数据数组。数组每一项为一个数据。通常这个数据用一个数组存储数据的每个属性/维度。例如：
        /// data: [
        ///     [[12, 14, 10], [34, 50, 15], [56, 30, 20], [10, 15, 12], [23, 10, 14]]
        /// ]
        /// 
        /// 对于数组中的每一项：
        /// 
        /// 在 grid3D 中，每一项的前三个值分别是x, y, z。
        /// 在 geo3D 以及 globe 中，每一项的前两个值分别是经纬度 lng, lat。
        /// 
        /// 除了默认给坐标系使用的值，每一项还可以加入任意多个值，用于给 visualMap 组件映射到颜色等其它图形属性。
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
        public double[] Data { get; set; }

        /// <summary>
        /// 混合模式，目前支持'source-over'，'lighter'，默认使用的'source-over'是通过 alpha 混合，而'lighter'是叠加模式，该模式可以让数据集中的区域因为叠加而产生高亮的效果。
        /// </summary>
        [JsonProperty("blendMode")]
        public string BlendMode { get; set; }

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
