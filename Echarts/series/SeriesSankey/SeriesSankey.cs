using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 桑基图 
        /// 是一种特殊的流图（可以看作是有向无环图）。 它主要用来表示原材料、能量等如何从最初形式经过中间过程的加工或转化达到最终状态。
        /// 示例：
        /// 
        /// 
        /// 
        /// 
        /// 可视编码：
        /// 桑基图将原数据中的每个node编码成一个小矩形，不同的节点尽量用不同的颜色展示，小矩形旁边的label编码的是节点的名称。
        /// 此外，图中每两个小矩形之间的边编码的是原数据中的link，边的粗细编码的是link中的value。
        /// 
        /// 排序：
        /// 如果想指定每层节点的顺序是按照 data 中的顺序排列的。可以设置 layoutIterations 为 0。
    /// </summary>
    public class SeriesSankey
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="sankey";

        /// <summary>
        /// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 系列名称，用于tooltip的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 所有图形的 zlevel 值。
        /// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
        /// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
        /// </summary>
        [JsonProperty("zlevel")]
        public double? Zlevel { get; set; }

        /// <summary>
        /// 组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
        /// z相比zlevel优先级更低，而且不会创建新的 Canvas。
        /// </summary>
        [JsonProperty("z")]
        public double? Z { get; set; }

        /// <summary>
        /// sankey组件离容器左侧的距离。
        /// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
        /// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("left")]
        public StringOrNumber Left { get; set; }

        /// <summary>
        /// sankey组件离容器上侧的距离。
        /// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
        /// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("top")]
        public StringOrNumber Top { get; set; }

        /// <summary>
        /// sankey组件离容器右侧的距离。
        /// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// </summary>
        [JsonProperty("right")]
        public StringOrNumber Right { get; set; }

        /// <summary>
        /// sankey组件离容器下侧的距离。
        /// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// </summary>
        [JsonProperty("bottom")]
        public StringOrNumber Bottom { get; set; }

        /// <summary>
        /// sankey组件的宽度。
        /// </summary>
        [JsonProperty("width")]
        public StringOrNumber Width { get; set; }

        /// <summary>
        /// sankey组件的高度。
        /// </summary>
        [JsonProperty("height")]
        public StringOrNumber Height { get; set; }

        /// <summary>
        /// 桑基图中每个矩形节点的宽度。
        /// </summary>
        [JsonProperty("nodeWidth")]
        public double? NodeWidth { get; set; }

        /// <summary>
        /// 桑基图中每一列任意两个矩形节点之间的间隔。
        /// </summary>
        [JsonProperty("nodeGap")]
        public double? NodeGap { get; set; }

        /// <summary>
        /// 桑基图中节点的对齐方式，默认是双端对齐，可以设置为左对齐或右对齐，对应的值分别是：
        /// 
        /// justify: 节点双端对齐。
        /// left: 节点左对齐。
        /// right: 节点右对齐。
        /// </summary>
        [JsonProperty("nodeAlign")]
        public string NodeAlign { get; set; }

        /// <summary>
        /// 布局的迭代次数，目的是不断迭代优化图中节点和边的位置，以减少节点和边之间的相互遮盖，默认值是 32。如果希望图中节点的顺序是按照原始 data 中的顺序排列的，可设该值为 0。
        /// </summary>
        [JsonProperty("layoutIterations")]
        public double? LayoutIterations { get; set; }

        /// <summary>
        /// 桑基图中节点的布局方向，可以是水平的从左往右，也可以是垂直的从上往下，对应的参数值分别是 horizontal, vertical。
        /// </summary>
        [JsonProperty("orient")]
        public string Orient { get; set; }

        /// <summary>
        /// 控制节点拖拽的交互，默认开启。开启后，用户可以将图中任意节点拖拽到任意位置。若想关闭此交互，只需将值设为 false 就行了。
        /// </summary>
        [JsonProperty("draggable")]
        public bool? Draggable { get; set; }

        /// <summary>
        /// 从 v5.4.1 开始支持
        /// 
        /// 关系边文本标签的样式。
        /// </summary>
        [JsonProperty("edgeLabel")]
        public EdgeLabel1 EdgeLabel { get; set; }

        /// <summary>
        /// 桑基图每一层的设置。可以逐层设置，如下：
        /// levels: [{
        ///     depth: 0,
        ///     itemStyle: {
        ///         color: '#fbb4ae'
        ///     },
        ///     lineStyle: {
        ///         color: 'source',
        ///         opacity: 0.6
        ///     }
        /// }, {
        ///     depth: 1,
        ///     itemStyle: {
        ///         color: '#b3cde3'
        ///     },
        ///     lineStyle: {
        ///         color: 'source',
        ///         opacity: 0.6
        ///     }
        /// }]
        /// 
        /// 也可以只设置某一层：
        /// levels: [{
        ///     depth: 3,
        ///     itemStyle: {
        ///         color: '#fbb4ae'
        ///     },
        ///     lineStyle: {
        ///         color: 'source',
        ///         opacity: 0.6
        ///     }
        /// }]
        /// </summary>
        [JsonProperty("levels")]
        public SeriesSankey_Levels[] Levels { get; set; }

        /// <summary>
        /// label 描述了每个矩形节点中文本标签的样式。
        /// </summary>
        [JsonProperty("label")]
        public Label6 Label { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 标签的统一布局配置。
        /// 该配置项是在每个系列默认的标签布局基础上，统一调整标签的(x, y)位置，标签对齐等属性以实现想要的标签布局效果。
        /// 该配置项也可以是一个有如下参数的回调函数
        /// // 标签对应数据的 dataIndex
        /// dataIndex: number
        /// // 标签对应的数据类型，只在关系图中会有 node 和 edge 数据类型的区分
        /// dataType?: string
        /// // 标签对应的系列的 index
        /// seriesIndex: number
        /// // 标签显示的文本
        /// text: string
        /// // 默认的标签的包围盒，由系列默认的标签布局决定
        /// labelRect: {x: number, y: number, width: number, height: number}
        /// // 默认的标签水平对齐
        /// align: 'left' | 'center' | 'right'
        /// // 默认的标签垂直对齐
        /// verticalAlign: 'top' | 'middle' | 'bottom'
        /// // 标签所对应的数据图形的包围盒，可用于定位标签位置
        /// rect: {x: number, y: number, width: number, height: number}
        /// // 默认引导线的位置，目前只有饼图(pie)和漏斗图(funnel)有默认标签位置
        /// // 如果没有该值则为 null
        /// labelLinePoints?: number[][]
        /// 
        /// 示例：
        /// 将标签显示在图形右侧 10px 的位置，并且垂直居中：
        /// labelLayout(params) {
        ///     return {
        ///         x: params.rect.x + 10,
        ///         y: params.rect.y + params.rect.height / 2,
        ///         verticalAlign: 'middle',
        ///         align: 'left'
        ///     }
        /// }
        /// 
        /// 根据图形的包围盒尺寸决定文本尺寸
        /// 
        /// labelLayout(params) {
        ///     return {
        ///         fontSize: Math.max(params.rect.width / 10, 5)
        ///     };
        /// }
        /// </summary>
        [JsonProperty("labelLayout")]
        public LabelLayout0 LabelLayout { get; set; }

        /// <summary>
        /// 桑基图节点矩形的样式。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle11 ItemStyle { get; set; }

        /// <summary>
        /// 桑基图边的样式
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle5 LineStyle { get; set; }

        /// <summary>
        /// 桑基图的高亮状态。
        /// </summary>
        [JsonProperty("emphasis")]
        public SeriesSankey_Emphasis Emphasis { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 桑基图的淡出状态。开启 emphasis.focus 后有效。
        /// </summary>
        [JsonProperty("blur")]
        public SeriesSankey_Blur Blur { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 桑基图的选中状态。开启 selectedMode 后有效。
        /// </summary>
        [JsonProperty("select")]
        public SeriesSankey_Select Select { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 
        /// 
        /// 选中模式的配置，表示是否支持多个选中，默认关闭，支持布尔值和字符串，字符串取值可选'single'，'multiple'，'series' 分别表示单选，多选以及选择整个系列。
        /// 
        /// 从 v5.3.0 开始支持 'series'。
        /// </summary>
        [JsonProperty("selectedMode")]
        public StringOrBool SelectedMode { get; set; }

        /// <summary>
        /// 桑基图节点数据列表。
        /// data: [{
        ///     name: 'node1',
        ///     // This attribute decides the layer of the current node.
        ///     depth: 0
        /// }, {
        ///     name: 'node2',
        ///     depth: 1
        /// }]
        /// 
        /// 注意: 节点的name不能重复。
        /// </summary>
        [JsonProperty("data")]
        public SeriesSankey_Data[] Data { get; set; }

        /// <summary>
        /// 同 data
        /// </summary>
        [JsonProperty("nodes")]
        public double[] Nodes { get; set; }

        /// <summary>
        /// 节点间的边。注意: 桑基图理论上只支持有向无环图（DAG, Directed Acyclic Graph），所以请确保输入的边是无环的. 示例：
        /// links: [{
        ///     source: 'n1',
        ///     target: 'n2'
        /// }, {
        ///     source: 'n2',
        ///     target: 'n3'
        /// }]
        /// </summary>
        [JsonProperty("links")]
        public SeriesSankey_Links[] Links { get; set; }

        /// <summary>
        /// 同 links
        /// </summary>
        [JsonProperty("edges")]
        public double[] Edges { get; set; }

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
        /// 是否开启动画的阈值，当单个系列显示的图形数量大于这个阈值时会关闭动画。
        /// </summary>
        [JsonProperty("animationThreshold")]
        public double? AnimationThreshold { get; set; }

        /// <summary>
        /// 初始动画的时长，支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的初始动画效果：
        /// animationDuration: function (idx) {
        ///     // 越往后的数据时长越大
        ///     return idx * 100;
        /// }
        /// </summary>
        [JsonProperty("animationDuration")]
        public StringOrNumber AnimationDuration { get; set; }

        /// <summary>
        /// 初始动画的缓动效果。不同的缓动效果可以参考 缓动示例。
        /// </summary>
        [JsonProperty("animationEasing")]
        public string AnimationEasing { get; set; }

        /// <summary>
        /// 初始动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的初始动画效果。
        /// 如下示例：
        /// animationDelay: function (idx) {
        ///     // 越往后的数据延迟越大
        ///     return idx * 100;
        /// }
        /// 
        /// 也可以看该示例
        /// </summary>
        [JsonProperty("animationDelay")]
        public StringOrNumber AnimationDelay { get; set; }

        /// <summary>
        /// 数据更新动画的时长。
        /// 支持回调函数，可以通过每个数据返回不同的时长实现更戏剧的更新动画效果：
        /// animationDurationUpdate: function (idx) {
        ///     // 越往后的数据时长越大
        ///     return idx * 100;
        /// }
        /// </summary>
        [JsonProperty("animationDurationUpdate")]
        public StringOrNumber AnimationDurationUpdate { get; set; }

        /// <summary>
        /// 数据更新动画的缓动效果。
        /// </summary>
        [JsonProperty("animationEasingUpdate")]
        public string AnimationEasingUpdate { get; set; }

        /// <summary>
        /// 数据更新动画的延迟，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的更新动画效果。
        /// 如下示例：
        /// animationDelayUpdate: function (idx) {
        ///     // 越往后的数据延迟越大
        ///     return idx * 100;
        /// }
        /// 
        /// 也可以看该示例
        /// </summary>
        [JsonProperty("animationDelayUpdate")]
        public StringOrNumber AnimationDelayUpdate { get; set; }

        /// <summary>
        /// 本系列特定的 tooltip 设定。
        /// </summary>
        [JsonProperty("tooltip")]
        public Tooltip1 Tooltip { get; set; }

    }
 }