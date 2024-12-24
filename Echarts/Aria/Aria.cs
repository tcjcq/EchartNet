using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// W3C 制定了无障碍富互联网应用规范集（WAI-ARIA，the Accessible Rich Internet Applications Suite），致力于使得网页内容和网页应用能够被更多残障人士访问。Apache ECharts 4 遵从这一规范，支持自动根据图表配置项智能生成描述，使得盲人可以在朗读设备的帮助下了解图表内容，让图表可以被更多人群访问。除此之外，Apache ECharts 5 新增支持贴花纹理，作为颜色的辅助表达，进一步用以区分数据。
        /// 默认关闭，需要通过将 aria.enabled 设置为 true 开启。
    /// </summary>
    public class Aria
    {
        /// <summary>
        /// 是否开启无障碍访问。如果不开启，则不会开启 label 或 decal 效果。
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 如果 aria.enabled 设置为 true，label 默认开启。开启后，会根据图表、数据、标题等情况，自动智能生成关于图表的描述，用户也可以通过配置项修改描述。
        /// 例子：
        /// option = {
        ///     aria: {
        ///         // 下面几行可以不写，因为 label.enabled 默认 true
        ///         // label: {
        ///         //     enabled: true
        ///         // },
        ///         enabled: true
        ///     },
        ///     title: {
        ///         text: '某站点用户访问来源',
        ///         x: 'center'
        ///     },
        ///     series: [
        ///         {
        ///             name: '访问来源',
        ///             type: 'pie',
        ///             data: [
        ///                 { value: 335, name: '直接访问' },
        ///                 { value: 310, name: '邮件营销' },
        ///                 { value: 234, name: '联盟广告' },
        ///                 { value: 135, name: '视频广告' },
        ///                 { value: 1548, name: '搜索引擎' }
        ///             ]
        ///         }
        ///     ]
        /// };
        /// 
        /// 
        /// 
        /// 
        /// 生成的图表 DOM 上，会有一个 aria-label 属性，在朗读设备的帮助下，盲人能够了解图表的内容。其值为：
        /// 
        /// 这是一个关于“某站点用户访问来源”的图表。图表类型是饼图，表示访问来源。其数据是——直接访问的数据是335，邮件营销的数据是310，联盟广告的数据是234，视频广告的数据是135，搜索引擎的数据是1548。
        /// 
        /// 生成描述的基本流程为，如果 aria.enabled 设置为 true（非默认）且 aria.label.enabled 设置为 true（默认），则生成无障碍访问描述，否则不生成。如果定义了 aria.label.description，则将其作为图表的完整描述，否则根据模板拼接生成描述。我们提供了默认的生成描述的算法，仅当生成的描述不太合适时，才需要修改这些模板，甚至使用 aria.label.description 完全覆盖。
        /// 使用模板拼接时，先根据是否存在标题 title.text 决定使用 aria.label.general.withTitle 还是 aria.label.general.withoutTitle 作为整体性描述。其中，aria.label.general.withTitle 配置项包括模板变量 '{title}'，将会被替换成图表标题。也就是说，如果 aria.label.general.withTitle 被设置为 '图表的标题是：{title}。'，则如果包含标题 '价格分布图'，这部分的描述为 '图表的标题是：价格分布图。'。
        /// 拼接完标题之后，会依次拼接系列的描述（aria.label.series），和每个系列的数据的描述（aria.label.data）。同样，每个模板都有可能包括模板变量，用以替换实际的值。
        /// 完整的描述生成流程为：
        /// </summary>
        [JsonProperty("label")]
        public Aria_Label Label { get; set; }

        /// <summary>
        /// 为系列数据增加贴花纹理，作为颜色的辅助，帮助区分数据。使用默认贴花图案的方式非常简单，只需要开启即可：
        /// aria: {
        ///     enabled: true,
        ///     decal: {
        ///         show: true
        ///     }
        /// }
        /// 
        /// 
        /// 
        /// 绝大部分支持填充色的系列都支持贴花图案，包括：'line', 'bar', 'pie', 'radar', 'treemap', 'sunburst', 'boxplot', 'sankey', 'funnel', 'gauge', 'pictorialBar', 'themeRiver', 'custom' 等。其中，部分系列默认没有填充色（如 'line', 'radar', 'boxplot'）需要在设置了填充样式 areaStyle 的情况下才生效。
        /// </summary>
        [JsonProperty("decal")]
        public Aria_Decal Decal { get; set; }

    }
 }
