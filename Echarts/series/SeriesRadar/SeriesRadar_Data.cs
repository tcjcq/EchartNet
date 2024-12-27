using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     雷达图的数据是多变量（维度）的，如下示例：
	///     data : [
	///     {
	///     value : [4300, 10000, 28000, 35000, 50000, 19000],
	///     name : '预算分配（Allocated Budget）'
	///     },
	///     {
	///     value : [5000, 14000, 28000, 31000, 42000, 21000],
	///     name : '实际开销（Actual Spending）'
	///     }
	///     ]
	///     其中的value项数组是具体的数据，每个值跟 radar.indicator 一一对应。
	/// </summary>
	public class SeriesRadar_Data
	{
		/// <summary>
		///     数据项名称
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     单个数据项的数值。
		/// </summary>
		[JsonProperty("value")]
		public double? Value { get; set; }

		/// <summary>
		///     该数据项的组 ID。当全局过渡动画功能开启时，setOption 前后拥有相同组 ID 的数据项会进行动画过渡。
		///     若没有指定groupId ，会尝试用series.dataGroupId作为该数据项的组 ID；若series.dataGroupId也没有指定，则会使用数据项的 ID 作为组 ID。
		///     如果你使用了dataset组件来表达数据，推荐使用encode.itemGroupId来指定哪个维度被编码为组 ID。
		/// </summary>
		[JsonProperty("groupId")]
		public string GroupId { get; set; }

		/// <summary>
		///     从 v5.5.0 开始支持
		///     该数据项对应的子数据组 ID，用于实现多层下钻和聚合。
		///     通过groupId已经可以达到数据下钻和聚合的效果，但只支持一层的下钻和聚合。为了实现多层下钻和聚合，我们又引入了childGroupId。
		///     引入childGroupId后，不同option的数据项之间就能形成逻辑上的父子关系，例如：
		///     data: [                        data: [                        data: [
		///     {                              {                              {
		///     name: 'Animals',               name: 'Dogs',                  name: 'Corgi',
		///     value: 3,                      value: 3,                      value: 5,
		///     groupId: 'things',             groupId: 'animals',            groupId: 'dogs'
		///     childGroupId: 'animals'        childGroupId: 'dogs'         },
		///     },                             },                             {
		///     {                              {                                name: 'Bulldog',
		///     name: 'Fruits',                name: 'Cats',                  value: 6,
		///     value: 3,                      value: 4,                      groupId: 'dogs'
		///     groupId: 'things',             groupId: 'animals',          },
		///     childGroupId: 'fruits'         childGroupId: 'cats',        {
		///     },                             },                               name: 'Shiba Inu',
		///     {                              {                                value: 7,
		///     name: 'Cars',                  name: 'Birds',                 groupId: 'dogs'
		///     value: 2,                      value: 3,                    }
		///     groupId: 'things',             groupId: 'animals',        ]
		///     childGroupId: 'cars'           childGroupId: 'birds'
		///     }                              }
		///     ]                              ]
		///     上面 3 组 data 分别来自 3 个 option ，通过groupId和childGroupId，它们之间存在了“父-子-孙”的关系。在setOption时，Apache ECharts
		///     会尝试寻找前后option数据项间的父子关系，若存在父子关系，则会对相关数据项进行下钻或聚合动画的过渡。
		///     没有对应子数据组的数据项不需要指定childGroupId。
		///     如果你使用了dataset组件来表达数据，推荐使用encode.itemChildGroupId来指定哪个维度被编码为子数据组 ID。
		/// </summary>
		[JsonProperty("childGroupId")]
		public string ChildGroupId { get; set; }

		/// <summary>
		///     单个数据标记的图形。
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
		///     单个数据标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
		/// </summary>
		[JsonProperty("symbolSize")]
		public ArrayOrSingle SymbolSize { get; set; }

		/// <summary>
		///     单个数据标记的旋转角度（而非弧度）。正值表示逆时针旋转。注意在 markLine 中当 symbol 为 'arrow' 时会忽略 symbolRotate 强制设置为切线的角度。
		/// </summary>
		[JsonProperty("symbolRotate")]
		public double? SymbolRotate { get; set; }

		/// <summary>
		///     如果 symbol 是 path:// 的形式，是否在缩放时保持该图形的长宽比。
		/// </summary>
		[JsonProperty("symbolKeepAspect")]
		public bool? SymbolKeepAspect { get; set; }

		/// <summary>
		///     单个数据标记相对于原本位置的偏移。默认情况下，标记会居中置放在数据对应的位置，但是如果 symbol 是自定义的矢量路径或者图片，就有可能不希望 symbol 居中。这时候可以使用该配置项配置 symbol
		///     相对于原本居中的偏移，可以是绝对的像素值，也可以是相对的百分比。
		///     例如 [0, '-50%'] 就是把自己向上移动了一半的位置，在 symbol 图形是气泡的时候可以让图形下端的箭头对准数据点。
		/// </summary>
		[JsonProperty("symbolOffset")]
		public double[] SymbolOffset { get; set; }

		/// <summary>
		///     单个拐点文本的样式设置。
		/// </summary>
		[JsonProperty("label")]
		public Label3 Label { get; set; }

		/// <summary>
		///     单个拐点标志的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public HandleStyle0 ItemStyle { get; set; }

		/// <summary>
		///     单项线条样式。
		/// </summary>
		[JsonProperty("lineStyle")]
		public LineStyle1 LineStyle { get; set; }

		/// <summary>
		///     单项区域填充样式。
		/// </summary>
		[JsonProperty("areaStyle")]
		public ShadowStyle0 AreaStyle { get; set; }

		/// <summary>
		///     单个数据项样式的高亮状态。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesRadar_Data_Emphasis Emphasis { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     单个数据项样式的淡出状态。
		/// </summary>
		[JsonProperty("blur")]
		public SeriesRadar_Data_Emphasis Blur { get; set; }

		/// <summary>
		///     从 v5.0.0 开始支持
		///     单个数据项样式的选中状态。
		/// </summary>
		[JsonProperty("select")]
		public SeriesRadar_Data_Select Select { get; set; }

		/// <summary>
		///     本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}
}