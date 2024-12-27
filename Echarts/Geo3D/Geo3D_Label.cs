using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     标签的相关设置。
	/// </summary>
	public class Geo3D_Label
	{
		/// <summary>
		///     是否显示标签。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		///     标签距离图形的距离，在三维的散点图中这个距离是屏幕空间的像素值，其它图中这个距离是相对的三维距离。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		///     标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
		///     字符串模板
		///     模板变量有：
		///     {a}：系列名。
		///     {b}：数据名。
		///     {c}：数据值。
		///     示例：
		///     formatter: '{b}: {c}'
		///     回调函数
		///     回调函数格式：
		///     (params: Object|Array) => string
		///     参数 params 是 formatter 需要的单个数据集。格式如下：
		///     {
		///     componentType: 'series',
		///     // 系列类型
		///     seriesType: string,
		///     // 系列在传入的 option.series 中的 index
		///     seriesIndex: number,
		///     // 系列名称
		///     seriesName: string,
		///     // 数据名，类目名
		///     name: string,
		///     // 数据在传入的 data 数组中的 index
		///     dataIndex: number,
		///     // 传入的原始数据项
		///     data: Object,
		///     // 传入的数据值。在多数系列下它和 data 相同。在一些系列下是 data 中的分量（如 map、radar 中）
		///     value: number|Array|Object,
		///     // 坐标轴 encode 映射信息，
		///     // key 为坐标轴（如 'x' 'y' 'radius' 'angle' 等）
		///     // value 必然为数组，不会为 null/undefined，表示 dimension index 。
		///     // 其内容如：
		///     // {
		///     //     x: [2] // dimension index 为 2 的数据映射到 x 轴
		///     //     y: [0] // dimension index 为 0 的数据映射到 y 轴
		///     // }
		///     encode: Object,
		///     // 维度名列表
		///     dimensionNames: Array
		///     <String>
		///         ,
		///         // 数据的维度 index，如 0 或 1 或 2 ...
		///         // 仅在雷达图中使用。
		///         dimensionIndex: number,
		///         // 数据图形的颜色
		///         color: string,
		///         }
		///         注：encode 和 dimensionNames 的使用方式，例如：
		///         如果数据为：
		///         dataset: {
		///         source: [
		///         ['Matcha Latte', 43.3, 85.8, 93.7],
		///         ['Milk Tea', 83.1, 73.4, 55.1],
		///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
		///         ['Walnut Brownie', 72.4, 53.9, 39.1]
		///         ]
		///         }
		///         则可这样得到 y 轴对应的 value：
		///         params.value[params.encode.y[0]]
		///         如果数据为：
		///         dataset: {
		///         dimensions: ['product', '2015', '2016', '2017'],
		///         source: [
		///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
		///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
		///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
		///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
		///         ]
		///         }
		///         则可这样得到 y 轴对应的 value：
		///         params.value[params.dimensionNames[params.encode.y[0]]]
		/// </summary>
		[JsonProperty("formatter")]
		public string Formatter { get; set; }

		/// <summary>
		///     标签的字体样式。
		/// </summary>
		[JsonProperty("textStyle")]
		public TextStyle2 TextStyle { get; set; }
	}
}