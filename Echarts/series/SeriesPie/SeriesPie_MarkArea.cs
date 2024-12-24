using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
    /// </summary>
    public class SeriesPie_MarkArea
    {
        /// <summary>
        /// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
        /// </summary>
        [JsonProperty("silent")]
        public bool? Silent { get; set; }

        /// <summary>
        /// 标域文本配置。
        /// </summary>
        [JsonProperty("label")]
        public Label1 Label { get; set; }

        /// <summary>
        /// 该标域的样式。
        /// </summary>
        [JsonProperty("itemStyle")]
        public HandleStyle0 ItemStyle { get; set; }

        /// <summary>
        /// 高亮的标域样式
        /// </summary>
        [JsonProperty("emphasis")]
        public Emphasis1 Emphasis { get; set; }

        /// <summary>
        /// 从 v5.0.0 开始支持
        /// 
        /// 淡出的标域样式。淡出的规则跟随所在系列。
        /// </summary>
        [JsonProperty("blur")]
        public Blur2 Blur { get; set; }

        /// <summary>
        /// 标域的数据数组。每个数组项是一个两个项的数组，分别表示标域左上角和右下角的位置，每个项支持通过下面几种方式指定自己的位置
        /// 
        /// 通过 x, y 属性指定相对容器的屏幕坐标，单位像素，支持百分比。
        /// 
        /// 当多个属性同时存在时，优先级按上述的顺序。
        /// data: [
        /// 
        /// [
        ///         {
        ///             name: '两个屏幕坐标之间的标域',
        ///             x: 100,
        ///             y: 100
        ///         }, {
        ///             x: '90%',
        ///             y: '10%'
        ///         }
        ///     ]
        /// ]
        /// </summary>
        [JsonProperty("data")]
        public SeriesPie_MarkArea_Data Data { get; set; }

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

    }
 }
