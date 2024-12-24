using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// series-sunburst.data 的数据格式是树状的，例如：
        /// [{
        ///     name: 'parent1',
        ///     value: 10,          // 可以不写父元素的 value，则为子元素之和；
        ///                         // 如果写了，并且大于子元素之和，可以用来表示还有其他子元素未显示
        ///     children: [{
        ///         value: 5,
        ///         name: 'child1',
        ///         children: [{
        ///             value: 2,
        ///             name: 'grandchild1',
        ///             itemStyle: {
        ///                 // 每个数据可以有自己的样式，覆盖 series.itemStyle 和 level.itemStyle
        ///             },
        ///             label: {
        ///                 // 标签样式，同上
        ///             }
        ///         }]
        ///     }, {
        ///         value: 3,
        ///         name: 'child2'
        ///     }],
        ///     itemStyle: {
        ///         // parent1 的图形样式，不会被后代继承
        ///     },
        ///     label: {
        ///         // parent1 的标签样式，不会被后代继承
        ///     }
        /// }, {
        ///     name: 'parent2',
        ///     value: 4
        /// }]
    /// </summary>
    public class SeriesSunburst_Data
    {
        /// <summary>
        /// 数据值，如果包含 children，则可以不写 value 值。这时，将使用子元素的 value 之和作为父元素的 value。如果 value 大于子元素之和，可以用来表示还有其他子元素未显示。
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }

        /// <summary>
        /// 显示在扇形块中的描述文字。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 点击此节点可跳转的超链接。须 series-sunburst.nodeClick 值为 'link' 时才生效。
        /// 参见 series-sunburst.data.target。
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// 意义同 HTML <a> 标签中的 target，参见 series-sunburst.data.link。可选值为：'blank' 或 'self'。
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }

        /// <summary>
        /// label 描述了每个扇形块中，文本标签的样式。
        /// 优先级：series.data.label > series.levels.label > series.label。
        /// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
        /// </summary>
        [JsonProperty("label")]
        public Label9 Label { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 标签的视觉引导线配置。
        /// </summary>
        [JsonProperty("labelLine")]
        public LabelLine1 LabelLine { get; set; }

        /// <summary>
        /// 旭日图扇形块的样式。
        /// 可以在 series.itemStyle 定义所有扇形块的样式，也可以在 series.levels.itemStyle 定义每一层扇形块的样式，还可以在 series.data.itemStyle 定义每个扇形块单独的样式，这三者的优先级从低到高。也就是说，如果定义了 series.data.itemStyle，将会覆盖 series.itemStyle 和 series.levels.itemStyle。
        /// 优先级：series.data.itemStyle > series.levels.itemStyle > series.itemStyle。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle6 ItemStyle { get; set; }

        /// <summary>
        /// 高亮状态配置。
        /// </summary>
        [JsonProperty("emphasis")]
        public Blur9 Emphasis { get; set; }

        /// <summary>
        /// 淡出状态配置。
        /// </summary>
        [JsonProperty("blur")]
        public Blur9 Blur { get; set; }

        /// <summary>
        /// 选中状态配置。
        /// </summary>
        [JsonProperty("select")]
        public Blur9 Select { get; set; }

        /// <summary>
        /// 子节点，递归定义，格式同 series-sunburst.data。
        /// </summary>
        [JsonProperty("children")]
        public double[] Children { get; set; }

        /// <summary>
        /// 本系列每个数据项中特定的 tooltip 设定。
        /// </summary>
        [JsonProperty("tooltip")]
        public Tooltip1 Tooltip { get; set; }

    }
 }
