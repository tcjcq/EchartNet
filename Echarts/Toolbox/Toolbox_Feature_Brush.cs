using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 选框组件的控制按钮。
        /// 也可以不在这里指定，而是在 brush.toolbox 中指定。
    /// </summary>
    public class Toolbox_Feature_Brush
    {
        /// <summary>
        /// 使用的按钮，取值：
        /// 
        /// 'rect'：开启矩形选框选择功能。
        /// 'polygon'：开启任意形状选框选择功能。
        /// 'lineX'：开启横向选择功能。
        /// 'lineY'：开启纵向选择功能。
        /// 'keep'：切换『单选』和『多选』模式。后者可支持同时画多个选框。前者支持单击清除所有选框。
        /// 'clear'：清空所有选框。
        /// </summary>
        [JsonProperty("type")]
        public double[] Type { get; set; }

        /// <summary>
        /// 每个按钮的 icon path。
        /// </summary>
        [JsonProperty("icon")]
        public Toolbox_Feature_Brush_Icon Icon { get; set; }

        /// <summary>
        /// 标题文本。
        /// </summary>
        [JsonProperty("title")]
        public Toolbox_Feature_Brush_Icon Title { get; set; }

    }
 }
