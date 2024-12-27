using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     renderItem 函数的第二个参数。
	/// </summary>
	public class SeriesCustom_RenderItem_Arguments_Api
	{
		/// <summary>
		///     得到给定维度的数据值。
		///     @param {number} dimension 指定的维度（维度从 0 开始计数）。
		///     @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		///     @return {number} 给定维度上的值。
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		///     将数据值映射到坐标系上。
		///     @param {Array.
		///     <number>
		///         } data 数据值。
		///         @return {Array.
		///         <number>
		///             } 画布上的点的坐标，至少包含：[x, y]
		///             对于polar坐标系，还会包含其他信息：
		///             polar: [x, y, radius, angle]
		/// </summary>
		[JsonProperty("coord")]
		public string Coord { get; set; }

		/// <summary>
		///     给定数据范围，映射到坐标系上后的长度。
		///     例如，cartesian2d中，api.size([2, 4]) 返回 [12.4, 55]，表示 x 轴数据范围为 2 映射得到长度是 12.4，y 轴数据范围为 4 时应设得到长度为 55。
		///     在一些坐标系中，如极坐标系（polar）或者有 log 数轴的坐标系，不同点的长度是不同的，所以需要第二个参数，指定获取长度的点。
		///     @param {Array.
		///     <number>
		///         } dataSize 数据范围。
		///         @param {Array.
		///         <number>
		///             } dataItem 获取长度的点。
		///             @return {Array.<number>} 画布上的长度
		/// </summary>
		[JsonProperty("size")]
		public string Size { get; set; }

		/// <summary>
		///     能得到 series.itemStyle 中定义的样式信息和视觉映射得到的样式信息，可直接用于绘制图元。也可以用这种方式覆盖这些样式信息：api.style({fill: 'green', stroke: 'yellow'})。
		///     @param {Object} [extra] 额外指定的样式信息。
		///     @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		///     @return {Object} 直接用于绘制图元的样式信息。
		/// </summary>
		[JsonProperty("style")]
		public string Style { get; set; }

		/// <summary>
		///     能得到 series.itemStyle.emphasis 中定义的样式信息和视觉映射的样式信息，可直接用于绘制图元。也可以用这种方式覆盖这些样式信息：api.style({fill: 'green', stroke:
		///     'yellow'})。
		///     @param {Object} [extra] 额外指定的样式信息。
		///     @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		///     @return {Object} 直接用于绘制图元的样式信息。
		/// </summary>
		[JsonProperty("styleEmphasis")]
		public string StyleEmphasis { get; set; }

		/// <summary>
		///     得到视觉映射的样式信息。比较少被使用。
		///     @param {string} visualType 'color', 'symbol', 'symbolSize', ...
		///     @param {number} [dataIndexInside] 一般不用传，默认就是当前数据项的 dataIndexInside。
		///     @return {string|number} 视觉映射的样式值。
		/// </summary>
		[JsonProperty("visual")]
		public string Visual { get; set; }

		/// <summary>
		///     当需要采用 barLayout 的时候，比如向柱状图上附加些东西，可以用这个方法得到 layout 信息。
		///     参见 例子。
		///     @param {Object} opt
		///     @param {number} opt.count 每个簇有多少个 bar。
		///     @param {number|string} [opt.barWidth] bar 宽度。
		///     可以是绝对值例如 `40` 或者百分数例如 `'60%'`。
		///     百分数基于自动计算出的每一类目的宽度。
		///     @param {number|string} [opt.barMaxWidth] bar 最大宽度。
		///     可以是绝对值例如 `40` 或者百分数例如 `'60%'`。
		///     百分数基于自动计算出的每一类目的宽度。
		///     比 `opt.barWidth` 优先级高。
		///     @param {number|string} [opt.barMinWidth] bar 最小宽度。
		///     可以是绝对值例如 `40` 或者百分数例如 `'60%'`。
		///     百分数基于自动计算出的每一类目的宽度。
		///     比 `opt.barWidth` 优先级高。
		///     @param {number} [opt.barGap] 每个簇的 bar 之间的宽度。
		///     @param {number} [opt.barCategoryGap] 不同簇间的宽度。
		///     @return {Array.
		///     <Object>
		///         } [{
		///         width: number bar 的宽度。
		///         offset: number bar 的偏移量，以bar最左为基准。
		///         offsetCenter: number bar 的偏移量，以bar中心为基准。
		///         }, ...]
		/// </summary>
		[JsonProperty("barLayout")]
		public string BarLayout { get; set; }

		/// <summary>
		///     得到系列的 当前index。注意这个 index 不同于系列定义时的 index。这个 index 是当 legend 组件进行了系列筛选后，剩余的系列排列后的 index。
		///     @return {number}
		/// </summary>
		[JsonProperty("currentSeriesIndices")]
		public string CurrentSeriesIndices { get; set; }

		/// <summary>
		///     得到可以直接进行样式设置的文字信息字符串。
		///     @param {Object} opt
		///     @param {string} [opt.fontStyle]
		///     @param {number} [opt.fontWeight]
		///     @param {number} [opt.fontSize]
		///     @param {string} [opt.fontFamily]
		///     @return {string} font 字符串。
		/// </summary>
		[JsonProperty("font")]
		public string Font { get; set; }

		/// <summary>
		///     @return {number} echarts 容器的宽度。
		/// </summary>
		[JsonProperty("getWidth")]
		public string GetWidth { get; set; }

		/// <summary>
		///     @return {number} echarts 容器的高度。
		/// </summary>
		[JsonProperty("getHeight")]
		public string GetHeight { get; set; }

		/// <summary>
		///     @return {module:zrender} zrender 实例。
		/// </summary>
		[JsonProperty("getZr")]
		public string GetZr { get; set; }

		/// <summary>
		///     @return {number} 得到当前 devicePixelRatio。
		/// </summary>
		[JsonProperty("getDevicePixelRatio")]
		public string GetDevicePixelRatio { get; set; }
	}
}