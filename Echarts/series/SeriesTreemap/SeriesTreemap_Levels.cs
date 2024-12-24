using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 多层配置
	/// treemap 中采用『三级配置』：
	/// 『每个节点』->『每个层级』->『每个系列』。
	/// 即我们可以对每个节点进行配置，也可以对树的每个层级进行配置，也可以 series 上设置全局配置。节点上的设置，优先级最高。
	/// 最常用的是『每个层级进行配置』，levels 配置项就是每个层级的配置。例如：
	/// // Notice that in fact the data structure is not "tree", but is "forest".
	/// // 注意，这个数据结构实际不是『树』而是『森林』
	/// data: [
	///     {
	///         name: 'nodeA',
	///         children: [
	///             {name: 'nodeAA'},
	///             {name: 'nodeAB'},
	///         ]
	///     },
	///     {
	///         name: 'nodeB',
	///         children: [
	///             {name: 'nodeBA'}
	///         ]
	///     }
	/// ],
	/// levels: [
	///     {...}, // 『森林』的顶层配置。即含有 'nodeA', 'nodeB' 的这层。
	///     {...}, // 下一层配置，即含有 'nodeAA', 'nodeAB', 'nodeBA' 的这层。
	///     {...}, // 再下一层配置。
	///     ...
	/// ]
	/// 
	/// 视觉映射的规则
	/// treemap中首要关注的是如何在视觉上较好得区分『不同层级』、『同层级中不同类别』。这需要合理得设置不同层级的『矩形颜色』、『边界粗细』、『边界颜色』甚至『矩形颜色饱和度』等。
	/// 参见这个例子，最顶层级用颜色区分，分成了『红』『绿』『蓝』等大块。每个颜色块中是下一个层级，使用颜色的饱和度来区分（参见 colorSaturation）。最外层的矩形边界是『白色』，下层级的矩形边界是当前区块颜色加上饱和度处理（参见 borderColorSaturation）。
	/// treemap 是通过这样的规则来支持这种配置的：每个层级计算用户配置的 color、colorSaturation、borderColor、borderColorSaturation等视觉信息（在levels中配置）。如果子节点没有配置，则继承父的配置，否则使用自己的配置）。
	/// 这样，可以做到：父层级配置 color 列表，子层级配置 colorSaturation。父层级的每个节点会从 color 列表中得到一个颜色，子层级的节点会从 colorSaturation 中得到一个值，并且继承父节点得到的颜色，合成得到自己的最终颜色。
	/// 维度与『额外的视觉映射』
	/// 例子：每一个 value 字段是一个 Array，其中每个项对应一个维度（dimension）。
	/// [
	///     {
	///         value: [434, 6969, 8382],
	///         children: [
	///             {
	///                 value: [1212, 4943, 5453],
	///                 id: 'someid-1',
	///                 name: 'description of this node',
	///                 children: [...]
	///             },
	///             {
	///                 value: [4545, 192, 439],
	///                 id: 'someid-2',
	///                 name: 'description of this node',
	///                 children: [...]
	///             },
	///             ...
	///         ]
	///     },
	///     {
	///         value: [23, 59, 12],
	///         children: [...]
	///     },
	///     ...
	/// ]
	/// 
	/// treemap 默认把第一个维度（Array 第一项）映射到『面积』上。而如果想表达更多信息，用户可以把其他的某一个维度（series-treemap.visualDimension），映射到其他的『视觉元素』上，比如颜色明暗等。参见例子中，legend选择 Growth时的状态。
	/// 矩形边框（border）/缝隙（gap）设置如何避免混淆
	/// 如果统一用一种颜色设置矩形的缝隙（gap），那么当不同层级的矩形同时展示时可能会出现混淆。
	/// 参见 例子，注意其中红色的区块中的子矩形其实是更深层级，和其他用白色缝隙区分的矩形不是在一个层级。所以，红色区块中矩形的分割线的颜色，我们在 borderColorSaturation 中设置为『加了饱和度变化的红颜色』，以示区别。
	/// borderWidth, gapWidth, borderColor 的解释
	/// </summary>
	public class SeriesTreemap_Levels
	{
		/// <summary>
		/// treemap 中支持对数据其他维度进行视觉映射。
		/// 首先，treemap的数据格式（参见 series-treemap.data）中，每个节点的 value 都可以是数组。数组每项是一个『维度』（dimension）。visualDimension 指定了额外的『视觉映射』使用的是数组的哪一项。默认为第 0 项。
		/// 关于视觉设置，详见 series-treemap.levels。
		/// 
		/// 注：treemap中 visualDimension 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("visualDimension")]
		public double? VisualDimension { get; set; }

		/// <summary>
		/// 当前层级的最小 value 值。如果不设置则自动统计。
		/// 手动指定 visualMin、visualMax ，即手动控制了 visual mapping 的值域（当 colorMappingBy 为 'value' 时有意义）。
		/// </summary>
		[JsonProperty("visualMin")]
		public double? VisualMin { get; set; }

		/// <summary>
		/// 当前层级的最大 value 值。如果不设置则自动统计。
		/// 手动指定 visualMin、visualMax ，即手动控制了 visual mapping 的值域（当 colorMappingBy 为 'value' 时有意义）。
		/// </summary>
		[JsonProperty("visualMax")]
		public double? VisualMax { get; set; }

		/// <summary>
		/// 表示同一层级的节点的 颜色 选取列表（选择规则见 colorMappingBy）。默认为空时，选取系统color列表。
		/// 关于视觉设置，详见 series-treemap.levels。
		/// 
		/// 注：treemap中 color 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("color")]
		public double[] Color { get; set; }

		/// <summary>
		/// 表示同一层级的节点的颜色透明度选取范围。
		/// 数值范围 0 ~ 1
		/// 例如, colorAlpha 可以是 [0.3, 1].
		/// 关于视觉设置，详见 series-treemap.levels。
		/// 
		/// 注：treemap中 colorAlpha 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("colorAlpha")]
		public double[] ColorAlpha { get; set; }

		/// <summary>
		/// 表示同一层级的节点的颜色饱和度 选取范围。
		/// 数值范围 0 ~ 1。
		/// 例如, colorSaturation 可以是 [0.3, 1].
		/// 关于视觉设置，详见 series-treemap.levels。
		/// 
		/// 注：treemap中 colorSaturation 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("colorSaturation")]
		public double? ColorSaturation { get; set; }

		/// <summary>
		/// 表示同一层级节点，在颜色列表中（参见 color 属性）选择时，按照什么来选择。可选值：
		/// 
		/// 'value'：
		/// 
		/// 将节点的值（即 series-treemap.data.value）映射到颜色列表中。
		/// 这样得到的颜色，反应了节点值的大小。
		/// 可以使用 visualDimension 属性来设置，用 data 中哪个纬度的值来映射。
		/// 
		/// 'index'：
		/// 
		/// 将节点的 index（序号）映射到颜色列表中。即同一层级中，第一个节点取颜色列表中第一个颜色，第二个节点取第二个。
		/// 这样得到的颜色，便于区分相邻节点。
		/// 
		/// 'id'：
		/// 
		/// 将节点的 id（即 series-treemap.data.id）映射到颜色列表中。id 是用户指定的，这样能够使得，在treemap 通过 setOption 变化数值时，同一 id 映射到同一颜色，保持一致性。参见 例子。
		/// 关于视觉设置，详见 series-treemap.levels。
		/// 
		/// 注：treemap中 colorMappingBy 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("colorMappingBy")]
		public string ColorMappingBy { get; set; }

		/// <summary>
		/// 如果某个节点的矩形的面积，小于这个数值（单位：px平方），这个节点就不显示。
		/// 如果不加这个限制，很小的节点会影响显示效果。
		/// 关于视觉设置，详见 series-treemap.levels。
		/// 
		/// 注：treemap中 visibleMin 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("visibleMin")]
		public double? VisibleMin { get; set; }

		/// <summary>
		/// 如果某个节点的矩形面积，小于这个数值（单位：px平方），则不显示这个节点的子节点。
		/// 这能够在矩形面积不足够大时候，隐藏节点的细节。当用户用鼠标缩放节点时，如果面积大于此阈值，又会显示子节点。
		/// 关于视觉设置，详见 series-treemap.levels。
		/// 
		/// 注：treemap中 childrenVisibleMin 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("childrenVisibleMin")]
		public double? ChildrenVisibleMin { get; set; }

		/// <summary>
		/// label 描述了每个矩形中，文本标签的样式。
		/// 
		/// 注：treemap中 label 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("label")]
		public Label6 Label { get; set; }

		/// <summary>
		/// upperLabel 用于显示矩形的父节点的标签。当 upperLabel.show 为 true 的时候，『显示父节点标签』功能开启。
		/// 同 series-treemap.label 一样，upperLabel 可以存在于 series-treemap 的根节点，或者 series-treemap.level 中，或者 series-treemap.data 的每个数据项中。
		/// series-treemap.label 描述的是，当前节点为叶节点时标签的样式；upperLabel 描述的是，当前节点为非叶节点（即含有子节点）时标签的样式。（此时标签一般会被显示在节点的最上部）
		/// 参见：
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 
		/// 注：treemap中 label 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("upperLabel")]
		public Label1 UpperLabel { get; set; }

		/// <summary>
		/// 注：treemap中 itemStyle 属性可能在多处地方存在：
		/// 
		/// 
		/// 
		/// 于 sereis-treemap 根下，表示本系列全局的统一设置。
		/// 
		/// 
		/// 
		/// 
		/// 于 series-treemap.levels 的每个数组元素中，表示树每个层级的统一设置。
		/// 于 series-treemap.data 的每个节点中，表示每个节点的特定设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle8 ItemStyle { get; set; }

		/// <summary>
		/// 高亮状态配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public Select6 Emphasis { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 淡出状态配置。
		/// </summary>
		[JsonProperty("blur")]
		public SeriesTreemap_Blur Blur { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 选中状态配置。
		/// </summary>
		[JsonProperty("select")]
		public Select6 Select { get; set; }
	}
}