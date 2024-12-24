using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
    /// <summary>
    /// 图形的贴花图案，在 aria.enabled 与 aria.decal.show 都是 true 的情况下才生效。
        /// 如果为 'none' 表示不使用贴花图案。
    /// </summary>
    public class Decal0
    {
        /// <summary>
        /// 贴花的图案，如果是 string[] 表示循环使用数组中的图案。
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
        [JsonProperty("symbol")]
        public ArrayOrSingle Symbol { get; set; }

        /// <summary>
        /// 取值范围：0 到 1，表示占图案区域的百分比。
        /// </summary>
        [JsonProperty("symbolSize")]
        public double? SymbolSize { get; set; }

        /// <summary>
        /// 是否保持图案的长宽比。
        /// </summary>
        [JsonProperty("symbolKeepAspect")]
        public bool? SymbolKeepAspect { get; set; }

        /// <summary>
        /// 贴花图案的颜色，建议使用半透明色，这样能叠加在系列本身的颜色上。
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// 贴花的背景色，将会覆盖在系列本身颜色之上，贴花图案之下。
        /// </summary>
        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        /// <summary>
        /// 贴花图案的基本模式是在横向和纵向上分别以图案 - 空白 - 图案 - 空白 - 图案 - 空白的形式无限循环。通过设置每个图案和空白的长度，可以实现复杂的图案效果。
        /// dashArrayX 控制了横向的图案模式。当其值为 number 或 number[] 类型时，与 SVG stroke-dasharray 类似。
        /// 
        /// 如果是 number 类型，表示图案和空白分别是这个值。如 5 表示先显示宽度为 5 的图案，然后空 5 像素，再然后显示宽度为 5 的图案……
        /// 
        /// 如果是 number[] 类型，则表示图案和空白依次为数组值的循环。如：[5, 10, 2, 6] 表示图案宽 5 像素，然后空 10 像素，然后图案宽 2 像素，然后空 6 像素，然后图案宽 5 像素……
        /// 
        /// 如果是 (number | number[])[] 类型，表示每行的图案和空白依次为数组值的循环。如：[10, [2, 5]] 表示第一行以图案 10 像素空 10 像素循环，第二行以图案 2 像素空 5 像素循环，第三行以图案 10 像素空 10 像素循环……
        /// 
        /// 
        /// 可以结合以下的例子理解本接口：
        /// </summary>
        [JsonProperty("dashArrayX")]
        public ArrayOrSingle DashArrayX { get; set; }

        /// <summary>
        /// 贴花图案的基本模式是在横向和纵向上分别以图案 - 空白 - 图案 - 空白 - 图案 - 空白的形式无限循环。通过设置每个图案和空白的长度，可以实现复杂的图案效果。
        /// dashArrayY 控制了横向的图案模式。与 SVG stroke-dasharray 类似。
        /// 
        /// 如果是 number 类型，表示图案和空白分别是这个值。如 5 表示先显示高度为 5 的图案，然后空 5 像素，再然后显示高度为 5 的图案……
        /// 
        /// 如果是 number[] 类型，则表示图案和空白依次为数组值的循环。如：[5, 10, 2, 6] 表示图案高 5 像素，然后空 10 像素，然后图案高 2 像素，然后空 6 像素，然后图案高 5 像素……
        /// 
        /// 
        /// 可以结合以下的例子理解本接口：
        /// </summary>
        [JsonProperty("dashArrayY")]
        public ArrayOrSingle DashArrayY { get; set; }

        /// <summary>
        /// 图案的整体旋转角度（弧度制），取值范围从 -Math.PI 到 Math.PI。
        /// </summary>
        [JsonProperty("rotation")]
        public double? Rotation { get; set; }

        /// <summary>
        /// 生成的图案在未重复之前的宽度上限。通常不需要设置该值，当你发现图案在重复的时候出现不连续的接缝时，可以尝试提高该值。
        /// </summary>
        [JsonProperty("maxTileWidth")]
        public double? MaxTileWidth { get; set; }

        /// <summary>
        /// 生成的图案在未重复之前的高度上限。通常不需要设置该值，当你发现图案在重复的时候出现不连续的接缝时，可以尝试提高该值。
        /// </summary>
        [JsonProperty("maxTileHeight")]
        public double? MaxTileHeight { get; set; }

    }
 }
