using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     动态类型切换
///     示例：
///     feature: {
///     magicType: {
///     type: ['line', 'bar', 'stack']
///     }
///     }
/// </summary>
public class Toolbox_Feature_MagicType
{
	/// <summary>
	///     是否显示该工具。
	/// </summary>
	[JsonProperty("show")]
	public bool? Show { get; set; }

	/// <summary>
	///     启用的动态类型，包括'line'（切换为折线图）, 'bar'（切换为柱状图）, 'stack'（切换为堆叠模式）。
	/// </summary>
	[JsonProperty("type")]
	public List<StringOrNumber> Type { get; set; }

	/// <summary>
	///     各个类型的标题文本，可以分别配置。
	/// </summary>
	[JsonProperty("title")]
	public Toolbox_Feature_MagicType_Title Title { get; set; }

	/// <summary>
	///     各个类型的 icon path，可以分别配置。
	/// </summary>
	[JsonProperty("icon")]
	public Toolbox_Feature_MagicType_Icon Icon { get; set; }

	/// <summary>
	///     动态类型切换 icon 样式设置。由于 icon 的文本信息只在 icon hover 时候才显示，所以文字相关的配置项请在 emphasis 下设置。
	/// </summary>
	[JsonProperty("iconStyle")]
	public HandleStyle0 IconStyle { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("emphasis")]
	public Toolbox_Emphasis Emphasis { get; set; }

	/// <summary>
	///     各个类型的专有配置项。在切换到某类型的时候会合并相应的配置项。
	/// </summary>
	[JsonProperty("option")]
	public Toolbox_Feature_MagicType_Option Option { get; set; }

	/// <summary>
	///     各个类型对应的系列的列表。
	/// </summary>
	[JsonProperty("seriesIndex")]
	public Toolbox_Feature_MagicType_SeriesIndex SeriesIndex { get; set; }
}