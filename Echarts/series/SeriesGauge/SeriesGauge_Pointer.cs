using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 仪表盘指针。
	/// </summary>
	public class SeriesGauge_Pointer
	{
		/// <summary>
		/// 是否显示指针。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// 从 v5.2.0 开始支持
		/// 
		/// 
		/// 
		/// 指针是否显示在标题和仪表盘详情上方。
		/// </summary>
		[JsonProperty("showAbove")]
		public bool? ShowAbove { get; set; }

		/// <summary>
		/// 从 v5.0 开始支持
		/// 
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
		/// 从 v5.0 开始支持
		/// 
		/// 
		/// 
		/// 相对于仪表盘中心的偏移位置，数组第一项是水平方向的偏移，第二项是垂直方向的偏移。可以是绝对的数值，也可以是相对于仪表盘半径的百分比。
		/// </summary>
		[JsonProperty("offsetCenter")]
		public double[] OffsetCenter { get; set; }

		/// <summary>
		/// 指针长度，可以是绝对数值，也可以是相对于半径的半分比。
		/// </summary>
		[JsonProperty("length")]
		public StringOrNumber Length { get; set; }

		/// <summary>
		/// 指针宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 从 v5.0 开始支持
		/// 
		/// 
		/// 
		/// 如果图标是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("keepAspect")]
		public bool? KeepAspect { get; set; }

		/// <summary>
		/// 指针样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }
	}
}