using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 从 v5.2.0 开始支持
        /// 
        /// 全局过渡动画相关的配置。
        /// 全局过渡动画（Universal Transition）提供了任意系列之间进行变形动画的功能。开启该功能后，每次setOption，相同id的系列之间会自动关联进行动画的过渡，更细粒度的关联配置见universalTransition.seriesKey配置。
        /// 通过配置数据项的groupId和childGroupId，还可以实现诸如下钻，聚合等一对多或者多对一的动画。
        /// 可以直接在系列中配置 universalTransition: true 开启该功能。也可以提供一个对象进行更多属性的配置。
    /// </summary>
    public class SeriesLine_UniversalTransition
    {
        /// <summary>
        /// 是否开启全局过渡动画。
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        /// <summary>
        /// seriesKey决定了如何关联需要动画的系列，未配置时会默认取系列的id。
        /// 通常该配置为一个字符串，配置为相同seriesKey的系列之间会进行动画的过渡。也可以像下面配置为一个数组：
        /// seriesKey: ['male', 'female']
        /// 
        /// 配置为数组意味着在动画的时候所有数组项指定的系列会合并为当前系列。比如该配置是指id或者seriesKey为'male'和'female'的系列会合并成当前系列。
        /// </summary>
        [JsonProperty("seriesKey")]
        public ArrayOrSingle SeriesKey { get; set; }

        /// <summary>
        /// divideShape决定在一对多或者多对一的动画中，当前系列的图形如何分裂成多个图形。目前支持
        /// 
        /// 'split' 通过一定的算法将分割图形成为多个。
        /// 'clone' 从当前图形克隆得到多个。
        /// 
        /// 为了较好的效果，不同的系列会默认有不同的配置，比如散点图这种图形比较小且复杂的默认采用了'clone'，而柱状图这种更加规则的则默认是'split'。你可以根据你自己的场景需求设置为需要的分裂策略。
        /// </summary>
        [JsonProperty("divideShape")]
        public string DivideShape { get; set; }

        /// <summary>
        /// (index: number, count: number) => number
        /// 
        /// 配置一对多或者多对一的动画中每个图形的动画延时，设置不同的动画延时可以给动画带来一定的趣味性。比如下面代码每个图形通过一个随机的延时造成一种错落的效果：
        /// delay: function (index, count) {
        ///     return Math.random() * 1000;
        /// }
        /// </summary>
        [JsonProperty("delay")]
        public string Delay { get; set; }

    }
 }
