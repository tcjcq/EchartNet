using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 路径图
        /// 用于带有起点和终点信息的线数据的绘制，主要用于地图上的航线，路线的可视化。
        /// ECharts 2.x 里会用地图上的 markLine 去绘制迁徙效果，在 ECharts 3 里建议使用单独的 lines 类型图表。
    /// </summary>
    public class SeriesLines
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="lines";

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
        /// 从 v5.2.0 开始支持
        /// 
        /// 从调色盘 option.color 中取色的策略，可取值为：
        /// 
        /// 'series'：按照系列分配调色盘中的颜色，同一系列中的所有数据都是用相同的颜色；
        /// 'data'：按照数据项分配调色盘中的颜色，每个数据项都使用不同的颜色。
        /// </summary>
        [JsonProperty("colorBy")]
        public string ColorBy { get; set; }

        /// <summary>
        /// 该系列使用的坐标系，可选：
        /// 
        /// 'cartesian2d'
        ///   使用二维的直角坐标系（也称笛卡尔坐标系），通过 xAxisIndex, yAxisIndex指定相应的坐标轴组件。
        /// 
        /// 
        /// 
        /// 'geo'
        ///   使用地理坐标系，通过 geoIndex 指定相应的地理坐标系组件。
        /// </summary>
        [JsonProperty("coordinateSystem")]
        public string CoordinateSystem { get; set; }

        /// <summary>
        /// 使用的 x 轴的 index，在单个图表实例中存在多个 x 轴的时候有用。
        /// </summary>
        [JsonProperty("xAxisIndex")]
        public double? XAxisIndex { get; set; }

        /// <summary>
        /// 使用的 y 轴的 index，在单个图表实例中存在多个 y轴的时候有用。
        /// </summary>
        [JsonProperty("yAxisIndex")]
        public double? YAxisIndex { get; set; }

        /// <summary>
        /// 使用的地理坐标系的 index，在单个图表实例中存在多个地理坐标系的时候有用。
        /// </summary>
        [JsonProperty("geoIndex")]
        public double? GeoIndex { get; set; }

        /// <summary>
        /// 是否是多段线。
        /// 默认为 false，只能用于绘制只有两个端点的线段，线段可以通过 lineStyle.curveness 配置为曲线。
        /// 如果该配置项为 true，则可以在 data.coords 中设置多于 2 个的顶点用来绘制多段线，在绘制路线轨迹的时候比较有用，见示例 北京公交路线，设置为多段线后 lineStyle.curveness 无效。
        /// </summary>
        [JsonProperty("polyline")]
        public bool? Polyline { get; set; }

        /// <summary>
        /// 线特效的配置，见示例 模拟迁徙 和 北京公交路线
        /// 注意： 所有带有尾迹特效的图表需要单独放在一个层，也就是需要单独设置 zlevel，同时建议关闭该层的动画（animation: false）。不然位于同个层的其它系列的图形，和动画的标签也会产生不必要的残影。
        /// </summary>
        [JsonProperty("effect")]
        public SeriesLines_Effect Effect { get; set; }

        /// <summary>
        /// 是否启用大规模路径图的优化，在数据图形特别多的时候（>=5k）可以开启。
        /// 开启后配合 largeThreshold 在数据量大于指定阈值的时候对绘制进行优化。
        /// 缺点：优化后不能自定义设置单个数据项的样式，不能启用 effect。
        /// </summary>
        [JsonProperty("large")]
        public bool? Large { get; set; }

        /// <summary>
        /// 开启绘制优化的阈值。
        /// </summary>
        [JsonProperty("largeThreshold")]
        public double? LargeThreshold { get; set; }

        /// <summary>
        /// 线两端的标记类型，可以是一个数组分别指定两端，也可以是单个统一指定。
        /// 具体支持的格式可以参考 标线的 symbol
        /// </summary>
        [JsonProperty("symbol")]
        public ArrayOrSingle Symbol { get; set; }

        /// <summary>
        /// 线两端的标记大小，可以是一个数组分别指定两端，也可以是单个统一指定。
        /// 注意： 这里无法像一般的 symbolSize 那样通过数组分别指定高宽。
        /// </summary>
        [JsonProperty("symbolSize")]
        public ArrayOrSingle SymbolSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle3 LineStyle { get; set; }

        /// <summary>
        /// 标签相关配置。在 polyline 设置为 true 时无效。
        /// </summary>
        [JsonProperty("label")]
        public Label13 Label { get; set; }

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
        /// 高亮的线条和标签样式。
        /// </summary>
        [JsonProperty("emphasis")]
        public SeriesLines_Emphasis Emphasis { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 淡出的线条和标签样式。开启 emphasis.focus 后有效。
        /// </summary>
        [JsonProperty("blur")]
        public Blur12 Blur { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 选中的线条和标签样式。开启 selectedMode 后有效。
        /// </summary>
        [JsonProperty("select")]
        public Select10 Select { get; set; }

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
        /// 渐进式渲染时每一帧绘制图形数量，设为 0 时不启用渐进式渲染，支持每个系列单独配置。
        /// 在图中有数千到几千万图形元素的时候，一下子把图形绘制出来，或者交互重绘的时候可能会造成界面的卡顿甚至假死。ECharts 4 开始全流程支持渐进渲染（progressive rendering），渲染的时候会把创建好的图形分到数帧中渲染，每一帧渲染只渲染指定数量的图形。
        /// 该配置项就是用于配置该系列每一帧渲染的图形数，可以根据图表图形复杂度的需要适当调整这个数字使得在不影响交互流畅性的前提下达到绘制速度的最大化。比如在 lines 图或者平行坐标中线宽大于 1 的 polyline 绘制会很慢，这个数字就可以设置小一点，而线宽小于等于 1 的 polyline 绘制非常快，该配置项就可以相对调得比较大。
        /// </summary>
        [JsonProperty("progressive")]
        public double? Progressive { get; set; }

        /// <summary>
        /// 启用渐进式渲染的图形数量阈值，在单个系列的图形数量超过该阈值时启用渐进式渲染。
        /// </summary>
        [JsonProperty("progressiveThreshold")]
        public double? ProgressiveThreshold { get; set; }

        /// <summary>
        /// 该系列所有数据项的组 ID，优先级低于groupId。详见series.data.groupId。
        /// </summary>
        [JsonProperty("dataGroupId")]
        public string DataGroupId { get; set; }

        /// <summary>
        /// 线数据集。
        /// 注： 为了更好点支持多段线的配置，线数据的格式在 3.2.0 做了一定调整，如下：
        /// // 3.2.0 之前
        /// // [{
        /// //    // 起点坐标
        /// //    coord: [120, 66],
        /// //    lineStyle: { }
        /// // }, {
        /// //    // 终点坐标
        /// //    coord: [122, 67]
        /// // }]
        /// 
        /// // 从 3.2.0 起改为如下配置
        /// {
        ///     coords: [
        ///         [120, 66],  // 起点
        ///         [122, 67]   // 终点
        ///         ...         // 如果 polyline 为 true 还可以设置更多的点
        ///     ],
        ///     // 统一的样式设置
        ///     lineStyle: {
        ///     }
        /// }
        /// </summary>
        [JsonProperty("data")]
        public SeriesLines_Data[] Data { get; set; }

        /// <summary>
        /// 图表标注。
        /// </summary>
        [JsonProperty("markPoint")]
        public SeriesLines_MarkPoint MarkPoint { get; set; }

        /// <summary>
        /// 图表标线。
        /// </summary>
        [JsonProperty("markLine")]
        public SeriesPie_MarkLine MarkLine { get; set; }

        /// <summary>
        /// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
        /// </summary>
        [JsonProperty("markArea")]
        public SeriesPie_MarkArea MarkArea { get; set; }

        /// <summary>
        /// 从 v4.4.0 开始支持
        /// 
        /// 是否裁剪超出坐标系部分的图形，具体裁剪效果根据系列决定：
        /// 
        /// 散点图/带有涟漪特效动画的散点（气泡）图：忽略中心点超出坐标系的图形，但是不裁剪单个图形
        /// 柱状图：裁掉完全超出的柱子，但是不会裁剪只超出部分的柱子
        /// 折线图：裁掉所有超出坐标系的折线部分，拐点图形的逻辑按照散点图处理
        /// 路径图：裁掉所有超出坐标系的部分
        /// K 线图：忽略整体都超出坐标系的图形，但是不裁剪单个图形
        /// 象形柱图：裁掉所有超出坐标系的部分（从 v5.5.0 开始支持）
        /// 自定义系列：裁掉所有超出坐标系的部分
        /// 
        /// 除了象形柱图和自定义系列，其它系列的默认值都为 true，及开启裁剪，如果你觉得不想要裁剪的话，可以设置成 false 关闭。
        /// </summary>
        [JsonProperty("clip")]
        public bool? Clip { get; set; }

        /// <summary>
        /// 路径图所有图形的 zlevel 值。
        /// zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
        /// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
        /// </summary>
        [JsonProperty("zlevel")]
        public double? Zlevel { get; set; }

        /// <summary>
        /// 路径图组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
        /// z相比zlevel优先级更低，而且不会创建新的 Canvas。
        /// </summary>
        [JsonProperty("z")]
        public double? Z { get; set; }

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
        /// 从 v5.2.0 开始支持
        /// 
        /// 全局过渡动画相关的配置。
        /// 全局过渡动画（Universal Transition）提供了任意系列之间进行变形动画的功能。开启该功能后，每次setOption，相同id的系列之间会自动关联进行动画的过渡，更细粒度的关联配置见universalTransition.seriesKey配置。
        /// 通过配置数据项的groupId和childGroupId，还可以实现诸如下钻，聚合等一对多或者多对一的动画。
        /// 可以直接在系列中配置 universalTransition: true 开启该功能。也可以提供一个对象进行更多属性的配置。
        /// </summary>
        [JsonProperty("universalTransition")]
        public SeriesLine_UniversalTransition UniversalTransition { get; set; }

        /// <summary>
        /// 本系列特定的 tooltip 设定。
        /// </summary>
        [JsonProperty("tooltip")]
        public Tooltip1 Tooltip { get; set; }

    }
 }
