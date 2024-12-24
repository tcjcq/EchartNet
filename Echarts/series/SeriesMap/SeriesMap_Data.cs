using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 地图系列中的数据内容数组。数组项可以为单个数值，如：
        /// [12, 34, 56, 10, 23]
        /// 
        /// 如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
        /// [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
        /// 
        /// 这时候可以将每项数组中的第二个值指定给 visualMap 组件。
        /// 更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
        /// [{
        ///     // 数据项的名称
        ///     name: '数据1',
        ///     // 数据项值8
        ///     value: 10
        /// }, {
        ///     name: '数据2',
        ///     value: 20
        /// }]
        /// 
        /// 需要对个别内容指定进行个性化定义时：
        /// [{
        ///     name: '数据1',
        ///     value: 10
        /// }, {
        ///     // 数据项名称
        ///     name: '数据2',
        ///     value : 56,
        ///     //自定义特殊 tooltip，仅对该数据项有效
        ///     tooltip:{},
        ///     //自定义特殊itemStyle，仅对该item有效
        ///     itemStyle:{}
        /// }]
    /// </summary>
    public class SeriesMap_Data
    {
        /// <summary>
        /// 数据所对应的地图区域的名称，例如 '广东'，'浙江'。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 该区域的数据值。
        /// </summary>
        [JsonProperty("value")]
        public double? Value { get; set; }

        /// <summary>
        /// 该数据项的组 ID。当全局过渡动画功能开启时，setOption 前后拥有相同组 ID 的数据项会进行动画过渡。
        /// 若没有指定groupId ，会尝试用series.dataGroupId作为该数据项的组 ID；若series.dataGroupId也没有指定，则会使用数据项的 ID 作为组 ID。
        /// 如果你使用了dataset组件来表达数据，推荐使用encode.itemGroupId来指定哪个维度被编码为组 ID。
        /// </summary>
        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// 从 v5.5.0 开始支持
        /// 
        /// 该数据项对应的子数据组 ID，用于实现多层下钻和聚合。
        /// 
        /// 
        /// 
        /// 通过groupId已经可以达到数据下钻和聚合的效果，但只支持一层的下钻和聚合。为了实现多层下钻和聚合，我们又引入了childGroupId。
        /// 引入childGroupId后，不同option的数据项之间就能形成逻辑上的父子关系，例如：
        /// data: [                        data: [                        data: [
        ///   {                              {                              {
        ///     name: 'Animals',               name: 'Dogs',                  name: 'Corgi',
        ///     value: 3,                      value: 3,                      value: 5,
        ///     groupId: 'things',             groupId: 'animals',            groupId: 'dogs'
        ///     childGroupId: 'animals'        childGroupId: 'dogs'         },
        ///   },                             },                             {
        ///   {                              {                                name: 'Bulldog',
        ///     name: 'Fruits',                name: 'Cats',                  value: 6,
        ///     value: 3,                      value: 4,                      groupId: 'dogs'
        ///     groupId: 'things',             groupId: 'animals',          },
        ///     childGroupId: 'fruits'         childGroupId: 'cats',        {
        ///   },                             },                               name: 'Shiba Inu',
        ///   {                              {                                value: 7,
        ///     name: 'Cars',                  name: 'Birds',                 groupId: 'dogs'
        ///     value: 2,                      value: 3,                    }
        ///     groupId: 'things',             groupId: 'animals',        ]
        ///     childGroupId: 'cars'           childGroupId: 'birds'
        ///   }                              }
        /// ]                              ]
        /// 
        /// 上面 3 组 data 分别来自 3 个 option ，通过groupId和childGroupId，它们之间存在了“父-子-孙”的关系。在setOption时，Apache ECharts 会尝试寻找前后option数据项间的父子关系，若存在父子关系，则会对相关数据项进行下钻或聚合动画的过渡。
        /// 没有对应子数据组的数据项不需要指定childGroupId。
        /// 如果你使用了dataset组件来表达数据，推荐使用encode.itemChildGroupId来指定哪个维度被编码为子数据组 ID。
        /// </summary>
        [JsonProperty("childGroupId")]
        public string ChildGroupId { get; set; }

        /// <summary>
        /// 该区域是否选中。
        /// </summary>
        [JsonProperty("selected")]
        public bool? Selected { get; set; }

        /// <summary>
        /// 该数据所在区域的多边形样式设置
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle1 ItemStyle { get; set; }

        /// <summary>
        /// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
        /// </summary>
        [JsonProperty("label")]
        public SeriesMap_Data_Label Label { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 标签的视觉引导线配置。
        /// </summary>
        [JsonProperty("labelLine")]
        public LabelLine1 LabelLine { get; set; }

        /// <summary>
        /// 该数据所在区域的多边形高亮状态
        /// </summary>
        [JsonProperty("emphasis")]
        public SeriesMap_Data_Emphasis Emphasis { get; set; }

        /// <summary>
        /// 该数据所在区域的多边形选中状态
        /// </summary>
        [JsonProperty("select")]
        public SeriesMap_Data_Emphasis Select { get; set; }

        /// <summary>
        /// 本系列每个数据项中特定的 tooltip 设定。
        /// </summary>
        [JsonProperty("tooltip")]
        public Tooltip1 Tooltip { get; set; }

    }
 }
