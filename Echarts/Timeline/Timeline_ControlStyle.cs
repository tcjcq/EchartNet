using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     『控制按钮』的样式。『控制按钮』包括：『播放按钮』、『前进按钮』、『后退按钮』。
	/// </summary>
	public class Timeline_ControlStyle
	{
		/// <summary>
		///     是否显示『控制按钮』。设置为 false 则全不显示。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     是否显示『播放按钮』。
		/// </summary>
		[JsonProperty("showPlayBtn")]
		public bool? ShowPlayBtn { get; set; }

		/// <summary>
		///     是否显示『后退按钮』。
		/// </summary>
		[JsonProperty("showPrevBtn")]
		public bool? ShowPrevBtn { get; set; }

		/// <summary>
		///     是否显示『前进按钮』。
		/// </summary>
		[JsonProperty("showNextBtn")]
		public bool? ShowNextBtn { get; set; }

		/// <summary>
		///     『控制按钮』的尺寸，单位为像素（px）。
		/// </summary>
		[JsonProperty("itemSize")]
		public double? ItemSize { get; set; }

		/// <summary>
		///     『控制按钮』的间隔，单位为像素（px）。
		/// </summary>
		[JsonProperty("itemGap")]
		public double? ItemGap { get; set; }

		/// <summary>
		///     『控制按钮』的位置。
		///     当 timeline.orient 为 'horizontal'时，'left'、'right'有效。
		///     当 timeline.orient 为 'vertical'时，'top'、'bottom'有效。
		/// </summary>
		[JsonProperty("position")]
		public string Position { get; set; }

		/// <summary>
		///     『播放按钮』的『可播放状态』的图形。
		///     可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		///     URL 为图片链接例如：
		///     'image://http://example.website/a/b.png'
		///     URL 为 dataURI 例如：
		///     'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		///     可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从
		///     Adobe Illustrator 等工具编辑导出。
		///     例如：
		///     'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z
		///     M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z
		///     M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z
		///     M27.8,35.8
		///     c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("playIcon")]
		public string PlayIcon { get; set; }

		/// <summary>
		///     『播放按钮』的『可停止状态』的图形。
		///     可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		///     URL 为图片链接例如：
		///     'image://http://example.website/a/b.png'
		///     URL 为 dataURI 例如：
		///     'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		///     可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从
		///     Adobe Illustrator 等工具编辑导出。
		///     例如：
		///     'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z
		///     M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z
		///     M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z
		///     M27.8,35.8
		///     c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("stopIcon")]
		public string StopIcon { get; set; }

		/// <summary>
		///     『后退按钮』的图形
		///     可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		///     URL 为图片链接例如：
		///     'image://http://example.website/a/b.png'
		///     URL 为 dataURI 例如：
		///     'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		///     可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从
		///     Adobe Illustrator 等工具编辑导出。
		///     例如：
		///     'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z
		///     M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z
		///     M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z
		///     M27.8,35.8
		///     c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("prevIcon")]
		public string PrevIcon { get; set; }

		/// <summary>
		///     『前进按钮』的图形
		///     可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		///     URL 为图片链接例如：
		///     'image://http://example.website/a/b.png'
		///     URL 为 dataURI 例如：
		///     'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		///     可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从
		///     Adobe Illustrator 等工具编辑导出。
		///     例如：
		///     'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z
		///     M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z
		///     M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z
		///     M27.8,35.8
		///     c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("nextIcon")]
		public string NextIcon { get; set; }

		/// <summary>
		///     图形的颜色。
		///     支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		///     图形的描边颜色。支持的颜色格式同 color，不支持回调函数。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		///     描边线宽。为 0 时无描边。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		///     描边类型。
		///     可选：
		///     'solid'
		///     'dashed'
		///     'dotted'
		///     自 v5.0.0 开始，也可以是 number 或者 number 数组，用以指定线条的 dash array，配合
		///     borderDashOffset
		///     可实现更灵活的虚线效果。
		///     例如：
		///     {
		///     borderType: [5, 10],
		///     borderDashOffset: 5
		///     }
		/// </summary>
		[JsonProperty("borderType")]
		public StringOrNumber[] BorderType { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     用于设置虚线的偏移量，可搭配
		///     borderType
		///     指定 dash array 实现灵活的虚线效果。
		///     更多详情可以参考 MDN lineDashOffset。
		/// </summary>
		[JsonProperty("borderDashOffset")]
		public double? BorderDashOffset { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     用于指定线段末端的绘制方式，可以是：
		///     'butt': 线段末端以方形结束。
		///     'round': 线段末端以圆形结束。
		///     'square': 线段末端以方形结束，但是增加了一个宽度和线段相同，高度是线段厚度一半的矩形区域。
		///     默认值为 'butt'。 更多详情可以参考 MDN lineCap。
		/// </summary>
		[JsonProperty("borderCap")]
		public string BorderCap { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     用于设置2个长度不为0的相连部分（线段，圆弧，曲线）如何连接在一起的属性（长度为0的变形部分，其指定的末端和控制点在同一位置，会被忽略）。
		///     可以是：
		///     'bevel': 在相连部分的末端填充一个额外的以三角形为底的区域， 每个部分都有各自独立的矩形拐角。
		///     'round': 通过填充一个额外的，圆心在相连部分末端的扇形，绘制拐角的形状。 圆角的半径是线段的宽度。
		///     'miter': 通过延伸相连部分的外边缘，使其相交于一点，形成一个额外的菱形区域。这个设置可以通过
		///     borderMiterLimit
		///     属性看到效果。
		///     默认值为 'bevel'。 更多详情可以参考 MDN lineJoin。
		/// </summary>
		[JsonProperty("borderJoin")]
		public string BorderJoin { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     用于设置斜接面限制比例。只有当
		///     borderJoin
		///     为 miter 时，
		///     borderMiterLimit
		///     才有效。
		///     默认值为 10。负数、0、Infinity 和 NaN 均会被忽略。
		///     更多详情可以参考 MDN miterLimit。
		/// </summary>
		[JsonProperty("borderMiterLimit")]
		public double? BorderMiterLimit { get; set; }

		/// <summary>
		///     图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		///     示例：
		///     {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		///     }
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		///     阴影颜色。支持的格式同color。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		///     阴影水平方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		///     阴影垂直方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		///     图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }
	}
}