using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// series-treemap.data 的数据格式是树状的，例如：
	/// [ // 注意，最外层是一个数组，而非从某个根节点开始。
	///     {
	///         value: 1212,
	///         children: [
	///             {
	///                 value: 2323,    // value字段的值，对应到面积大小。
	///                                 // 也可以是数组，如 [2323, 43, 55]，则数组第一项对应到面积大小。
	///                                 // 数组其他项可以用于额外的视觉映射，详情参见 series-treemap.levels。
	///                 id: 'someid-1', // id 不是必须设置的。
	///                                 // 但是如果想使用 API 来改变某个节点，需要用 id 来定位。
	///                 name: 'description of this node', // 显示在矩形中的描述文字。
	///                 children: [...],
	///                 label: {        // 此节点特殊的 label 定义（如果需要的话）。
	///                     ...         // label的格式参见 series-treemap.label。
	///                 },
	///                 itemStyle: {    // 此节点特殊的 itemStyle 定义（如果需要的话）。
	///                     ...         // label的格式参见 series-treemap.itemStyle。
	///                 }
	///             },
	///             {
	///                 value: 4545,
	///                 id: 'someid-2',
	///                 name: 'description of this node',
	///                 children: [
	///                     {
	///                         value: 5656,
	///                         id: 'someid-3',
	///                         name: 'description of this node',
	///                         children: [...]
	///                     },
	///                     ...
	///                 ]
	///             }
	///         ]
	///     },
	///     {
	///         value: [23, 59, 12]
	///         // 如果没有children，可以不写
	///     },
	///     ...
	/// ]
	/// </summary>
	public class SeriesTreemap_Data
	{
		/// <summary>
		/// 每个树节点的值，对应到面积大小。可以是number，也可以是数组，如 [2323, 43, 55]，则数组第一项对应到面积大小。
		/// </summary>
		[JsonProperty("value")]
		public ArrayOrSingle Value { get; set; }

		/// <summary>
		/// 每个树节点的id。id 不是必须设置的。但是如果想使用 API 来改变某个节点，需要用 id 来定位。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 显示在矩形中的描述文字。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

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

		/// <summary>
		/// 点击此节点可跳转的超链接。须 series-treemap.nodeClick 值为 'link' 时才生效。
		/// 参见 series-treemap.data.target。
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		/// <summary>
		/// 意义同 html <a> 标签中的 target，参见 series-treemap.data.link。可选值为：'blank' 或 'self'。
		/// </summary>
		[JsonProperty("target")]
		public string Target { get; set; }

		/// <summary>
		/// 子节点，递归定义，格式同 series-treemap.data。
		/// </summary>
		[JsonProperty("children")]
		public double[] Children { get; set; }

		/// <summary>
		/// 本系列每个数据项中特定的 tooltip 设定。
		/// </summary>
		[JsonProperty("tooltip")]
		public Tooltip1 Tooltip { get; set; }
	}
}