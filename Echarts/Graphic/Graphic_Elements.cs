using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 里面是所有图形元素的集合。
	/// 注意：graphic 的标准写法是：
	/// {
	///     graphic: {
	///         elements: [
	///             {type: 'rect', ...}, {type: 'circle', ...}, ...
	///         ]
	///     }
	/// }
	/// 
	/// 但是我们常常可以用简写：
	/// {
	///     graphic: {
	///         type: 'rect',
	///         ...
	///     }
	/// }
	/// 
	/// 或者：
	/// {
	///     graphic: [
	///         {type: 'rect', ...}, {type: 'circle', ...}, ...
	///     ]
	/// }
	/// </summary>
	public class Graphic_Elements
	{
		/// <summary>
		/// group 是唯一的可以有子节点的容器。group 可以用来整体定位一组图形元素。
		/// </summary>
		[JsonProperty("group")]
		public Graphic_Elements_Group Group { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("image")]
		public Graphic_Elements_Image Image { get; set; }

		/// <summary>
		/// 文本块。
		/// </summary>
		[JsonProperty("text")]
		public Graphic_Elements_Text Text { get; set; }

		/// <summary>
		/// 矩形。
		/// </summary>
		[JsonProperty("rect")]
		public Graphic_Elements_Rect Rect { get; set; }

		/// <summary>
		/// 圆。
		/// </summary>
		[JsonProperty("circle")]
		public Graphic_Elements_Circle Circle { get; set; }

		/// <summary>
		/// 圆环。
		/// </summary>
		[JsonProperty("ring")]
		public Graphic_Elements_Ring Ring { get; set; }

		/// <summary>
		/// 扇形。
		/// </summary>
		[JsonProperty("sector")]
		public Graphic_Elements_Sector Sector { get; set; }

		/// <summary>
		/// 圆弧。
		/// </summary>
		[JsonProperty("arc")]
		public Graphic_Elements_Sector Arc { get; set; }

		/// <summary>
		/// 多边形。
		/// </summary>
		[JsonProperty("polygon")]
		public Graphic_Elements_Polygon Polygon { get; set; }

		/// <summary>
		/// 折线。
		/// </summary>
		[JsonProperty("polyline")]
		public Graphic_Elements_Polygon Polyline { get; set; }

		/// <summary>
		/// 直线。
		/// </summary>
		[JsonProperty("line")]
		public Graphic_Elements_Line Line { get; set; }

		/// <summary>
		/// 二次或三次贝塞尔曲线。
		/// </summary>
		[JsonProperty("bezierCurve")]
		public Graphic_Elements_BezierCurve BezierCurve { get; set; }
	}
}