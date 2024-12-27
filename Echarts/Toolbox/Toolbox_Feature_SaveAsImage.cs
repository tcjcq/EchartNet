using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     保存为图片。
	/// </summary>
	public class Toolbox_Feature_SaveAsImage
	{
		/// <summary>
		///     保存的图片格式。
		///     如果 renderer 的类型在 初始化图表 时被设为 'canvas'（默认），则支持 'png'（默认）和 'jpg'；
		///     如果 renderer 的类型在 初始化图表 时被设为 'svg'，则 type 只支持 'svg'（'svg' 格式的图片从 v4.8.0 开始支持）。
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "png";

		/// <summary>
		///     保存的文件名称，默认使用 title.text 作为名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     保存的图片背景色，默认使用 backgroundColor，如果backgroundColor不存在的话会取白色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public Color BackgroundColor { get; set; }

		/// <summary>
		///     如果图表使用了 echarts.connect 对多个图表进行联动，则在导出图片时会导出这些联动的图表。该配置项决定了图表与图表之间间隙处的填充色。
		/// </summary>
		[JsonProperty("connectedBackgroundColor")]
		public Color ConnectedBackgroundColor { get; set; }

		/// <summary>
		///     保存为图片时忽略的组件列表，默认忽略工具栏。
		/// </summary>
		[JsonProperty("excludeComponents")]
		public double[] ExcludeComponents { get; set; }

		/// <summary>
		///     是否显示该工具。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
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
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		///     保存为图片 icon 样式设置。由于 icon 的文本信息只在 icon hover 时候才显示，所以文字相关的配置项请在 emphasis 下设置。
		/// </summary>
		[JsonProperty("iconStyle")]
		public HandleStyle0 IconStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("emphasis")]
		public Toolbox_Emphasis Emphasis { get; set; }

		/// <summary>
		///     保存图片的分辨率比例，默认跟容器相同大小，如果需要保存更高分辨率的，可以设置为大于 1 的值，例如 2。
		/// </summary>
		[JsonProperty("pixelRatio")]
		public double? PixelRatio { get; set; }
	}
}