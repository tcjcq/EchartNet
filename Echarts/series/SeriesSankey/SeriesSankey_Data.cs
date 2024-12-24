using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
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
    public class SeriesSankey_Data
    {
        /// <summary>
        /// 节点的名称。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 节点的值，可用来指定节点的纵向高度或横向的宽度。
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }

        /// <summary>
        /// 节点所在的层，取值从 0 开始。
        /// </summary>
        [JsonProperty("depth")]
        public double? Depth { get; set; }

        /// <summary>
        /// 该节点的样式。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle11 ItemStyle { get; set; }

        /// <summary>
        /// 该节点标签的样式。
        /// </summary>
        [JsonProperty("label")]
        public Label3 Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("emphasis")]
        public SeriesSankey_Data_Emphasis Emphasis { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// </summary>
        [JsonProperty("blur")]
        public SeriesSankey_Data_Blur Blur { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// </summary>
        [JsonProperty("select")]
        public SeriesSankey_Data_Emphasis Select { get; set; }

        /// <summary>
        /// 本系列每个数据项中特定的 tooltip 设定。
        /// </summary>
        [JsonProperty("tooltip")]
        public Tooltip1 Tooltip { get; set; }

    }
 }
