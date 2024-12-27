using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// </summary>
	public class TextConfig0
	{
		/// <summary>
		///     Position of textContent.
		///     'left'
		///     'right'
		///     'top'
		///     'bottom'
		///     'inside'
		///     'insideLeft'
		///     'insideRight'
		///     'insideTop'
		///     'insideBottom'
		///     'insideTopLeft'
		///     'insideTopRight'
		///     'insideBottomLeft'
		///     'insideBottomRight'
		///     or like [12, 33]
		///     or like ['50%', '50%']
		/// </summary>
		[JsonProperty("position")]
		public string Position { get; set; }

		/// <summary>
		///     textContent 的旋转弧度。
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		///     textContent 根据此矩形来布局位置。
		///     默认是节点的包围盒。
		///     {
		///     x: number
		///     y: number
		///     width: number
		///     height: number
		///     }
		/// </summary>
		[JsonProperty("layoutRect")]
		public object LayoutRect { get; set; }

		/// <summary>
		///     textContent 的偏移。
		///     offset 和 position 的区别是，offset 是旋转（rotation）后计算。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		///     origin 相对于节点的包围盒。
		///     可以是百分数。
		///     如果指定为 'center'，则定位在包围盒中心。
		///     只有当 position and rotation 都设置时，生效。
		///     如 [12, 33]
		///     或如 ['50%', '50%']
		///     'center'
		/// </summary>
		[JsonProperty("origin")]
		public string Origin { get; set; }

		/// <summary>
		///     距离 layoutRect 的距离。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		///     如果 true 的话，会采用节点的 transform。
		/// </summary>
		[JsonProperty("local")]
		public bool? Local { get; set; }

		/// <summary>
		///     insideFill 可以是一个颜色字符串，或者空着。
		///     如果 textContent 是 "inside"，它的 fill 会按这个优先级来选取：
		///     textContent.style.fill > textConfig.insideFill > "auto-calculated-fill"
		///     在绝大多数场景下，"auto-calculated-fill" 是白色。
		/// </summary>
		[JsonProperty("insideFill")]
		public string InsideFill { get; set; }

		/// <summary>
		///     insideStroke 可以是一个颜色字符串，或者空着。
		///     如果 textContent 是 "inside"，它的 stroke 会按这个优先级来选取：
		///     textContent.style.stroke > textConfig.insideStroke > "auto-calculated-stroke"
		///     "auto-calculated-stroke" 的规则是：
		///     如果
		///     (A) fill 在 style 中被指定（无论是在 textContent.style 还是 textContent.style.rich 里）
		///     或者 (B) 需要画文字的背景（无论是定义在 textContent.style 还是 textContent.style.rich 里）
		///     "auto-calculated-stroke" 都会为 null。
		///     否则
		///     "auto-calculated-stroke" 会和节点的 fill 相同，如果 fill 没有的话则为 null。
		/// </summary>
		[JsonProperty("insideStroke")]
		public string InsideStroke { get; set; }

		/// <summary>
		///     outsideFill 可以是一个颜色字符串，或者空着。
		///     如果 textContent 是 "inside"，它的 fill 会按这个优先级来选取：
		///     textContent.style.fill > textConfig.outsideFill > #000
		/// </summary>
		[JsonProperty("outsideFill")]
		public string OutsideFill { get; set; }

		/// <summary>
		///     outsideStroke 可以是一个颜色字符串，或者空着。
		///     如果 textContent 不是 "inside"，它的 stroke 会按这个优先级来选取：
		///     textContent.style.stroke > textConfig.outsideStroke > "auto-calculated-stroke"
		///     "auto-calculated-stroke" 的规则是：
		///     如果
		///     (A) fill 在 style 中被指定（无论是在 textContent.style 还是 textContent.style.rich 里）
		///     或者 (B) 需要画文字的背景（无论是定义在 textContent.style 还是 textContent.style.rich 里）
		///     "auto-calculated-stroke" 都会为 null。
		///     否则
		///     "auto-calculated-stroke" 会为一个近似于白色的颜色，来区别于背景。
		/// </summary>
		[JsonProperty("outsideStroke")]
		public string OutsideStroke { get; set; }

		/// <summary>
		///     如果确定文本是在节点中的话，则此可设置为 true，避免 echarts 额外猜测。
		/// </summary>
		[JsonProperty("inside")]
		public bool? Inside { get; set; }
	}
}