using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     线特效的配置，见示例 模拟迁徙 和 北京公交路线
	///     注意： 所有带有尾迹特效的图表需要单独放在一个层，也就是需要单独设置 zlevel，同时建议关闭该层的动画（animation: false）。不然位于同个层的其它系列的图形，和动画的标签也会产生不必要的残影。
	/// </summary>
	public class SeriesLines_Effect
	{
		/// <summary>
		///     是否显示特效。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     特效动画的时间，单位为 s。
		/// </summary>
		[JsonProperty("period")]
		public double? Period { get; set; }

		/// <summary>
		///     特效动画的延时，支持设置成数字或者回调。单位ms
		/// </summary>
		[JsonProperty("delay")]
		public StringOrNumber Delay { get; set; }

		/// <summary>
		///     配置特效图形的移动动画是否是固定速度，单位像素/秒，设置为大于 0 的值后会忽略 period 配置项。
		/// </summary>
		[JsonProperty("constantSpeed")]
		public double? ConstantSpeed { get; set; }

		/// <summary>
		///     特效图形的标记。
		///     ECharts 提供的标记类型包括
		///     'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
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
		///     上面示例中就是使用自定义 path 的 symbol 表现飞机的图形。
		///     Tip: symbol 的角度会随着轨迹的切线变化，如果使用自定义 path 的 symbol，需要保证 path 图形的朝向是朝上的，这样在 symbol 沿着轨迹运动的时候可以保证图形始终朝着运动的方向。
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		///     特效标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示高和宽，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		///     特效标记的颜色，默认取 lineStyle.color。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		///     特效尾迹的长度。取从 0 到 1 的值，数值越大尾迹越长。
		/// </summary>
		[JsonProperty("trailLength")]
		public double? TrailLength { get; set; }

		/// <summary>
		///     是否循环显示特效。
		/// </summary>
		[JsonProperty("loop")]
		public bool? Loop { get; set; }

		/// <summary>
		///     从 v5.4.0 开始支持
		///     当动画到达终点时，是否原路返回。
		/// </summary>
		[JsonProperty("roundTrip")]
		public bool? RoundTrip { get; set; }
	}
}