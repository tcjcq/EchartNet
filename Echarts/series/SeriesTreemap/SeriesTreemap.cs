using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// Treemap 是一种常见的表达『层级数据』『树状数据』的可视化形式。它主要用面积的方式，便于突出展现出『树』的各层级中重要的节点。
        /// 示例：
        /// 
        /// 
        /// 
        /// 
        /// 视觉映射：
        /// treemap 首先是把数值映射到『面积』这种视觉元素上。
        /// 此外，也支持对数据的其他维度进行视觉映射，例如映射到颜色、颜色明暗度上。
        /// 关于视觉设置，详见 series-treemap.levels。
        /// 下钻（drill down）：
        /// drill down 功能即点击后才展示子层级。
        /// 设置了 leafDepth 后，下钻（drill down）功能开启。
        /// 如下是 drill down 的例子：
        /// 
        /// 
        /// 
        /// 
        /// 注：treemap 的配置项 和 ECharts2 相比有一些变化，一些不太成熟的配置方式不再支持或不再兼容：
        /// 
        /// center/size 方式的定位不再支持，而是统一使用 left/top/bottom/right/width/height 方式定位。
        /// 
        /// breadcrumb 的配置被移动到了 itemStyle/itemStyle.emphasis 外部，和 itemStyle 平级。
        /// 
        /// root 的设置暂时不支持。目前可以使用 zoom 的方式来查看树更下层次的细节，或者使用 leafDepth 开启 "drill down" 功能。
        /// 
        /// label 的配置被移动到了 itemStyle/itemStyle.emphasis 外部，和 itemStyle 平级。
        /// 
        /// itemStyle.childBorderWidth、itemStyle.childBorderColor不再支持（因为这个配置方式只能定义两层的treemap）。统一使用 series-treemap.levels 来进行各层级的定义。
    /// </summary>
    public class SeriesTreemap
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }="treemap";

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
        /// treemap 组件离容器左侧的距离。
        /// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
        /// 如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("left")]
        public StringOrNumber Left { get; set; }

        /// <summary>
        /// treemap 组件离容器上侧的距离。
        /// top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
        /// 如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
        /// </summary>
        [JsonProperty("top")]
        public StringOrNumber Top { get; set; }

        /// <summary>
        /// treemap 组件离容器右侧的距离。
        /// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// 默认自适应。
        /// </summary>
        [JsonProperty("right")]
        public StringOrNumber Right { get; set; }

        /// <summary>
        /// treemap 组件离容器下侧的距离。
        /// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// 默认自适应。
        /// </summary>
        [JsonProperty("bottom")]
        public StringOrNumber Bottom { get; set; }

        /// <summary>
        /// treemap 组件的宽度。
        /// </summary>
        [JsonProperty("width")]
        public StringOrNumber Width { get; set; }

        /// <summary>
        /// treemap 组件的高度。
        /// </summary>
        [JsonProperty("height")]
        public StringOrNumber Height { get; set; }

        /// <summary>
        /// 期望矩形长宽比率。布局计算时会尽量向这个比率靠近。
        /// 默认为黄金比：0.5 * (1 + Math.sqrt(5))。
        /// </summary>
        [JsonProperty("squareRatio")]
        public double? SquareRatio { get; set; }

        /// <summary>
        /// 设置了 leafDepth 后，下钻（drill down）功能开启。drill down 功能即点击后才展示子层级。
        /// leafDepth 表示『展示几层』，层次更深的节点则被隐藏起来。点击则可下钻看到层次更深的节点。
        /// 例如，leafDepth 设置为 1，表示展示一层节点。
        /// 默认没有开启 drill down（即 leafDepth 为 null 或 undefined）。
        /// drill down 的例子：
        /// </summary>
        [JsonProperty("leafDepth")]
        public double? LeafDepth { get; set; }

        /// <summary>
        /// 当节点可以下钻时的提示符。只能是字符。
        /// </summary>
        [JsonProperty("drillDownIcon")]
        public string DrillDownIcon { get; set; }

        /// <summary>
        /// 是否开启拖拽漫游（移动和缩放）。可取值有：
        /// 
        /// false：关闭。
        /// 'scale' 或 'zoom'：只能够缩放。
        /// 'move' 或 'pan'：只能够平移。
        /// true：缩放和平移均可。
        /// </summary>
        [JsonProperty("roam")]
        public StringOrBool Roam { get; set; }

        /// <summary>
        /// 从 v5.5.1 开始支持
        /// 
        /// 滚轮缩放的极限控制，通过 min 和 max 限制最小和最大的缩放值。
        /// </summary>
        [JsonProperty("scaleLimit")]
        public Geo_ScaleLimit ScaleLimit { get; set; }

        /// <summary>
        /// 点击节点后的行为。可取值为：
        /// 
        /// false：节点点击无反应。
        /// 'zoomToNode'：点击节点后缩放到节点。
        /// 'link'：如果节点数据中有 link 点击节点后会进行超链接跳转。
        /// </summary>
        [JsonProperty("nodeClick")]
        public StringOrBool NodeClick { get; set; }

        /// <summary>
        /// 点击某个节点，会自动放大那个节点到合适的比例（节点占可视区域的面积比例），这个配置项就是这个比例。
        /// </summary>
        [JsonProperty("zoomToNodeRatio")]
        public double? ZoomToNodeRatio { get; set; }

        /// <summary>
        /// treemap 中支持对数据其他维度进行视觉映射。
        /// 首先，treemap的数据格式（参见 series-treemap.data）中，每个节点的 value 都可以是数组。数组每项是一个『维度』（dimension）。visualDimension 指定了额外的『视觉映射』使用的是数组的哪一项。默认为第 0 项。
        /// 关于视觉设置，详见 series-treemap.levels。
        /// 
        /// 注：treemap中 visualDimension 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("visualDimension")]
        public double? VisualDimension { get; set; }

        /// <summary>
        /// 当前层级的最小 value 值。如果不设置则自动统计。
        /// 手动指定 visualMin、visualMax ，即手动控制了 visual mapping 的值域（当 colorMappingBy 为 'value' 时有意义）。
        /// </summary>
        [JsonProperty("visualMin")]
        public double? VisualMin { get; set; }

        /// <summary>
        /// 当前层级的最大 value 值。如果不设置则自动统计。
        /// 手动指定 visualMin、visualMax ，即手动控制了 visual mapping 的值域（当 colorMappingBy 为 'value' 时有意义）。
        /// </summary>
        [JsonProperty("visualMax")]
        public double? VisualMax { get; set; }

        /// <summary>
        /// 本系列默认的颜色透明度选取范围。
        /// 数值范围 0 ~ 1
        /// 例如, colorAlpha 可以是 [0.3, 1].
        /// 关于视觉设置，详见 series-treemap.levels。
        /// 
        /// 注：treemap中 colorAlpha 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("colorAlpha")]
        public double[] ColorAlpha { get; set; }

        /// <summary>
        /// 本系列默认的节点的颜色饱和度 选取范围。
        /// 数值范围 0 ~ 1。
        /// 例如, colorSaturation 可以是 [0.3, 1].
        /// 关于视觉设置，详见 series-treemap.levels。
        /// 
        /// 注：treemap中 colorSaturation 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("colorSaturation")]
        public double? ColorSaturation { get; set; }

        /// <summary>
        /// 表示同一层级节点，在颜色列表中（参见 color 属性）选择时，按照什么来选择。可选值：
        /// 
        /// 'value'：
        /// 
        /// 将节点的值（即 series-treemap.data.value）映射到颜色列表中。
        /// 这样得到的颜色，反应了节点值的大小。
        /// 可以使用 visualDimension 属性来设置，用 data 中哪个纬度的值来映射。
        /// 
        /// 'index'：
        /// 
        /// 将节点的 index（序号）映射到颜色列表中。即同一层级中，第一个节点取颜色列表中第一个颜色，第二个节点取第二个。
        /// 这样得到的颜色，便于区分相邻节点。
        /// 
        /// 'id'：
        /// 
        /// 将节点的 id（即 series-treemap.data.id）映射到颜色列表中。id 是用户指定的，这样能够使得，在treemap 通过 setOption 变化数值时，同一 id 映射到同一颜色，保持一致性。参见 例子。
        /// 关于视觉设置，详见 series-treemap.levels。
        /// 
        /// 注：treemap中 colorMappingBy 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("colorMappingBy")]
        public string ColorMappingBy { get; set; }

        /// <summary>
        /// 如果某个节点的矩形的面积，小于这个数值（单位：px平方），这个节点就不显示。
        /// 如果不加这个限制，很小的节点会影响显示效果。
        /// 关于视觉设置，详见 series-treemap.levels。
        /// 
        /// 注：treemap中 visibleMin 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("visibleMin")]
        public double? VisibleMin { get; set; }

        /// <summary>
        /// 如果某个节点的矩形面积，小于这个数值（单位：px平方），则不显示这个节点的子节点。
        /// 这能够在矩形面积不足够大时候，隐藏节点的细节。当用户用鼠标缩放节点时，如果面积大于此阈值，又会显示子节点。
        /// 关于视觉设置，详见 series-treemap.levels。
        /// 
        /// 注：treemap中 childrenVisibleMin 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("childrenVisibleMin")]
        public double? ChildrenVisibleMin { get; set; }

        /// <summary>
        /// label 描述了每个矩形中，文本标签的样式。
        /// 
        /// 注：treemap中 label 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("label")]
        public Label6 Label { get; set; }

        /// <summary>
        /// upperLabel 用于显示矩形的父节点的标签。当 upperLabel.show 为 true 的时候，『显示父节点标签』功能开启。
        /// 同 series-treemap.label 一样，upperLabel 可以存在于 series-treemap 的根节点，或者 series-treemap.level 中，或者 series-treemap.data 的每个数据项中。
        /// series-treemap.label 描述的是，当前节点为叶节点时标签的样式；upperLabel 描述的是，当前节点为非叶节点（即含有子节点）时标签的样式。（此时标签一般会被显示在节点的最上部）
        /// 参见：
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 
        /// 注：treemap中 label 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("upperLabel")]
        public Label1 UpperLabel { get; set; }

        /// <summary>
        /// 注：treemap中 itemStyle 属性可能在多处地方存在：
        /// 
        /// 
        /// 
        /// 于 sereis-treemap 根下，表示本系列全局的统一设置。
        /// 
        /// 
        /// 
        /// 
        /// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
        /// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle8 ItemStyle { get; set; }

        /// <summary>
        /// 高亮状态配置。
        /// </summary>
        [JsonProperty("emphasis")]
        public SeriesTreemap_Emphasis Emphasis { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 淡出状态配置。
        /// </summary>
        [JsonProperty("blur")]
        public SeriesTreemap_Blur Blur { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 选中状态配置。
        /// </summary>
        [JsonProperty("select")]
        public Select6 Select { get; set; }

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
        /// 面包屑，能够显示当前节点的路径。
        /// </summary>
        [JsonProperty("breadcrumb")]
        public SeriesTreemap_Breadcrumb Breadcrumb { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 标签的视觉引导线配置。
        /// </summary>
        [JsonProperty("labelLine")]
        public LabelLine1 LabelLine { get; set; }

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
        /// 多层配置
        /// treemap 中采用『三级配置』：
        /// 『每个节点』->『每个层级』->『每个系列』。
        /// 即我们可以对每个节点进行配置，也可以对树的每个层级进行配置，也可以 series 上设置全局配置。节点上的设置，优先级最高。
        /// 最常用的是『每个层级进行配置』，levels 配置项就是每个层级的配置。例如：
        /// // Notice that in fact the data structure is not "tree", but is "forest".
        /// // 注意，这个数据结构实际不是『树』而是『森林』
        /// data: [
        ///     {
        ///         name: 'nodeA',
        ///         children: [
        ///             {name: 'nodeAA'},
        ///             {name: 'nodeAB'},
        ///         ]
        ///     },
        ///     {
        ///         name: 'nodeB',
        ///         children: [
        ///             {name: 'nodeBA'}
        ///         ]
        ///     }
        /// ],
        /// levels: [
        ///     {...}, // 『森林』的顶层配置。即含有 'nodeA', 'nodeB' 的这层。
        ///     {...}, // 下一层配置，即含有 'nodeAA', 'nodeAB', 'nodeBA' 的这层。
        ///     {...}, // 再下一层配置。
        ///     ...
        /// ]
        /// 
        /// 视觉映射的规则
        /// treemap中首要关注的是如何在视觉上较好得区分『不同层级』、『同层级中不同类别』。这需要合理得设置不同层级的『矩形颜色』、『边界粗细』、『边界颜色』甚至『矩形颜色饱和度』等。
        /// 参见这个例子，最顶层级用颜色区分，分成了『红』『绿』『蓝』等大块。每个颜色块中是下一个层级，使用颜色的饱和度来区分（参见 colorSaturation）。最外层的矩形边界是『白色』，下层级的矩形边界是当前区块颜色加上饱和度处理（参见 borderColorSaturation）。
        /// treemap 是通过这样的规则来支持这种配置的：每个层级计算用户配置的 color、colorSaturation、borderColor、borderColorSaturation等视觉信息（在levels中配置）。如果子节点没有配置，则继承父的配置，否则使用自己的配置）。
        /// 这样，可以做到：父层级配置 color 列表，子层级配置 colorSaturation。父层级的每个节点会从 color 列表中得到一个颜色，子层级的节点会从 colorSaturation 中得到一个值，并且继承父节点得到的颜色，合成得到自己的最终颜色。
        /// 维度与『额外的视觉映射』
        /// 例子：每一个 value 字段是一个 Array，其中每个项对应一个维度（dimension）。
        /// [
        ///     {
        ///         value: [434, 6969, 8382],
        ///         children: [
        ///             {
        ///                 value: [1212, 4943, 5453],
        ///                 id: 'someid-1',
        ///                 name: 'description of this node',
        ///                 children: [...]
        ///             },
        ///             {
        ///                 value: [4545, 192, 439],
        ///                 id: 'someid-2',
        ///                 name: 'description of this node',
        ///                 children: [...]
        ///             },
        ///             ...
        ///         ]
        ///     },
        ///     {
        ///         value: [23, 59, 12],
        ///         children: [...]
        ///     },
        ///     ...
        /// ]
        /// 
        /// treemap 默认把第一个维度（Array 第一项）映射到『面积』上。而如果想表达更多信息，用户可以把其他的某一个维度（series-treemap.visualDimension），映射到其他的『视觉元素』上，比如颜色明暗等。参见例子中，legend选择 Growth时的状态。
        /// 矩形边框（border）/缝隙（gap）设置如何避免混淆
        /// 如果统一用一种颜色设置矩形的缝隙（gap），那么当不同层级的矩形同时展示时可能会出现混淆。
        /// 参见 例子，注意其中红色的区块中的子矩形其实是更深层级，和其他用白色缝隙区分的矩形不是在一个层级。所以，红色区块中矩形的分割线的颜色，我们在 borderColorSaturation 中设置为『加了饱和度变化的红颜色』，以示区别。
        /// borderWidth, gapWidth, borderColor 的解释
        /// </summary>
        [JsonProperty("levels")]
        public SeriesTreemap_Levels[] Levels { get; set; }

        /// <summary>
        /// series-treemap.data 的数据格式是树状的，例如：
        /// [ // 注意，最外层是一个数组，而非从某个根节点开始。
        ///     {
        ///         value: 1212,
        ///         children: [
        ///             {
        ///                 value: 2323,    // value字段的值，对应到面积大小。
        ///                                 // 也可以是数组，如 [2323, 43, 55]，则数组第一项对应到面积大小。
        ///                                 // 数组其他项可以用于额外的视觉映射，详情参见 series-treemap.levels。
        ///                 id: 'someid-1', // id 不是必须设置的。
        ///                                 // 但是如果想使用 API 来改变某个节点，需要用 id 来定位。
        ///                 name: 'description of this node', // 显示在矩形中的描述文字。
        ///                 children: [...],
        ///                 label: {        // 此节点特殊的 label 定义（如果需要的话）。
        ///                     ...         // label的格式参见 series-treemap.label。
        ///                 },
        ///                 itemStyle: {    // 此节点特殊的 itemStyle 定义（如果需要的话）。
        ///                     ...         // label的格式参见 series-treemap.itemStyle。
        ///                 }
        ///             },
        ///             {
        ///                 value: 4545,
        ///                 id: 'someid-2',
        ///                 name: 'description of this node',
        ///                 children: [
        ///                     {
        ///                         value: 5656,
        ///                         id: 'someid-3',
        ///                         name: 'description of this node',
        ///                         children: [...]
        ///                     },
        ///                     ...
        ///                 ]
        ///             }
        ///         ]
        ///     },
        ///     {
        ///         value: [23, 59, 12]
        ///         // 如果没有children，可以不写
        ///     },
        ///     ...
        /// ]
        /// </summary>
        [JsonProperty("data")]
        public SeriesTreemap_Data[] Data { get; set; }

        /// <summary>
        /// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
        /// </summary>
        [JsonProperty("silent")]
        public bool? Silent { get; set; }

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
        /// 本系列特定的 tooltip 设定。
        /// </summary>
        [JsonProperty("tooltip")]
        public Tooltip1 Tooltip { get; set; }

    }
 }
