using Newtonsoft.Json;

using System.Collections.Generic;

namespace FxEchartHtml
{
	/// <summary>
	/// 表示百分比向量数据类型，用于定义单个值或数组的组合。
	/// </summary>
	[JsonConverter(typeof(PercentVectorConverter))]
	public class PercentVector
	{
		/// <summary>
		/// 单个值，可以是 number 或 string。
		/// </summary>
		public string SingleValue { get; set; }

		/// <summary>
		/// 数组形式，第一项是内半径，第二项是外半径。
		/// </summary>
		public List<string> ArrayValues { get; set; }

		/// <summary>
		/// 是否是单个值。
		/// </summary>
		public bool IsSingleValue => SingleValue != null;

		/// <summary>
		/// 是否是数组值。
		/// </summary>
		public bool IsArrayValues => ArrayValues != null;
	}
}