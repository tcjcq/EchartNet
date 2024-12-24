using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 图例的数据数组。数组项通常为一个字符串，每一项代表一个系列的 name（如果是饼图，也可以是饼图单个数据的 name）。图例组件会自动根据对应系列的图形标记（symbol）来绘制自己的颜色和标记，特殊字符串 ''（空字符串）或者 '\n'（换行字符串）用于图例的换行。
        /// 如果 data 没有被指定，会自动从当前系列中获取。多数系列会取自 series.name 或者 series.encode 的 seriesName 所指定的维度。如 饼图 and 漏斗图 等会取自 series.data 中的 name。
        /// 如果要设置单独一项的样式，也可以把该项写成配置项对象。此时必须使用 name 属性对应表示系列的 name。
        /// 示例
        /// data: [{
        ///     name: '系列1',
        ///     // 强制设置图形为圆。
        ///     icon: 'circle',
        ///     // 设置文本为红色
        ///     textStyle: {
        ///         color: 'red'
        ///     }
        /// }]
    /// </summary>
    public class Legend_Data
    {
        /// <summary>
        /// 图例项的名称，应等于某系列的name值（如果是饼图，也可以是饼图单个数据的 name）。
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 图例项的 icon。
        /// ECharts 提供的标记类型包括
        /// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
        /// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
        /// URL 为图片链接例如：
        /// 'image://http://example.website/a/b.png'
        /// URL 为 dataURI 例如：
        /// 'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
        /// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从 Adobe Illustrator 等工具编辑导出。
        /// 例如：
        /// 'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 图例项的图形样式。其属性的取值为 'inherit' 时，表示继承系列中的属性值。
        /// </summary>
        [JsonProperty("itemStyle")]
        public ItemStyle0 ItemStyle { get; set; }

        /// <summary>
        /// 图例项图形中线的样式，用于诸如折线图图例横线的样式设置。其属性的取值为 'inherit' 时，表示继承系列中的属性值。
        /// </summary>
        [JsonProperty("lineStyle")]
        public LineStyle0 LineStyle { get; set; }

        /// <summary>
        /// 图形旋转角度，类型为 number | 'inherit'。如果为 'inherit'，表示取系列的 symbolRotate。
        /// </summary>
        [JsonProperty("symbolRotate")]
        public StringOrNumber SymbolRotate { get; set; }

        /// <summary>
        /// 图例关闭时的颜色。
        /// </summary>
        [JsonProperty("inactiveColor")]
        public Color InactiveColor { get; set; }

        /// <summary>
        /// 图例关闭时的描边颜色。
        /// </summary>
        [JsonProperty("inactiveBorderColor")]
        public Color InactiveBorderColor { get; set; }

        /// <summary>
        /// 图例关闭时的描边粗细。
        /// 如果为 'auto' 表示：如果系列存在描边，则取 2，如果系列不存在描边，则取 0。
        /// 如果为 'inherit' 表示：始终取系列的描边粗细。
        /// </summary>
        [JsonProperty("inactiveBorderWidth")]
        public StringOrNumber InactiveBorderWidth { get; set; }

        /// <summary>
        /// 图例项的文本样式。
        /// </summary>
        [JsonProperty("textStyle")]
        public Legend_PageTextStyle TextStyle { get; set; }

    }
 }
