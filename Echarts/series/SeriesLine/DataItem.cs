using System;
using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     数据项（支持数值/数组/对象形式）
///     完整覆盖ECharts官方文档定义的7种数据形态：
///     1. number  2. string  3. Date  4. [number, number]
///     5. [string, number]  6. [Date, number]  7. 对象结构
/// </summary>
[JsonConverter(typeof(DataItemConverter))]
public class DataItem
{
	/// <summary>
	///     核心数据值（支持6种类型）
	///     - 单值：number/string/DateTime
	///     - 数组：object[]
	///     - 空值：null/NaN/"-"
	/// </summary>
	public object Value { get; set; }

	/// <summary>
	///     数据项名称
	/// </summary>
	[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
	public string Name { get; set; }

	/// <summary>
	///     数据分组ID（动画过渡用）
	/// </summary>
	[JsonProperty("groupId", NullValueHandling = NullValueHandling.Ignore)]
	public string GroupId { get; set; }

	/// <summary>
	///     子数据组ID（v5.5.0+）
	/// </summary>
	[JsonProperty("childGroupId", NullValueHandling = NullValueHandling.Ignore)]
	public string ChildGroupId { get; set; }

	/// <summary>
	///     标签样式
	/// </summary>
	[JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
	public object Label { get; set; }

	/// <summary>
	///     数据项样式
	/// </summary>
	[JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
	public HandleStyle0 ItemStyle { get; set; }

	/// <summary>
	///     判断是否需要对象包装
	/// </summary>
	public bool NeedObjectWrap()
	{
		return !string.IsNullOrEmpty(Name) ||
		       !string.IsNullOrEmpty(GroupId) ||
		       !string.IsNullOrEmpty(ChildGroupId) ||
		       Label != null ||
		       ItemStyle != null;
	}

	public bool HasExtendedProperties()
	{
		return !string.IsNullOrEmpty(Name) ||
		       Label != null ||
		       ItemStyle != null;
	}

	#region 隐式转换

	public static implicit operator DataItem(int val)
	{
		return new DataItem { Value = val };
	}

	public static implicit operator DataItem(double val)
	{
		return new DataItem { Value = val };
	}

	public static implicit operator DataItem(string val)
	{
		return new DataItem { Value = val };
	}

	public static implicit operator DataItem(DateTime val)
	{
		return new DataItem { Value = val };
	}

	public static implicit operator DataItem(object[] arr)
	{
		return new DataItem { Value = arr };
	}

	#endregion
}