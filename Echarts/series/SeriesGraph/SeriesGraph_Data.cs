using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     关系图的节点数据列表。
	///     data: [{
	///     name: '1',
	///     x: 10,
	///     y: 10,
	///     value: 10
	///     }, {
	///     name: '2',
	///     x: 100,
	///     y: 100,
	///     value: 20,
	///     symbolSize: 20,
	///     itemStyle: {
	///     color: 'red'
	///     }
	///     }]
	///     注意: 节点的name不能重复。
	/// </summary>
	public class SeriesGraph_Data
	{
		/// <summary>
		///     数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     节点的初始 x 值。在不指定的时候需要指明layout属性选择布局方式。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		///     节点的初始 y 值。在不指定的时候需要指明layout属性选择布局方式。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		///     节点在力引导布局中是否固定。
		/// </summary>
		[JsonProperty("fixed")]
		public bool? Fixed { get; set; }

		/// <summary>
		///     数据项值。
		/// </summary>
		[JsonProperty("value")]
		public ArrayOrSingle Value { get; set; }

		/// <summary>
		///     数据项所在类目的 index。
		/// </summary>
		[JsonProperty("category")]
		public double? Category { get; set; }

		/// <summary>
		///     该类目节点标记的图形。
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
		/// </summary>
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		/// <summary>
		///     该类目节点标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		///     该类目节点标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		///     如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		///     该类目节点标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol
		///     相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		///     例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		///     该节点的样式。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		///     该节点标签的样式。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		///     该节点的高亮状态。
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis0 Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     该节点的淡出状态。
		/// </summary>
		[JsonProperty("blur")]
		public Blur1 Blur { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     该节点的选中状态。
		/// </summary>
		[JsonProperty("select")]
		public Emphasis0 Select { get; set; }

		/// <summary>
		///     本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}
}