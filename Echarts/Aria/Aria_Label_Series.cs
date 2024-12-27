using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     系列相关的配置项。
	/// </summary>
	public class Aria_Label_Series
	{
		/// <summary>
		///     描述中最多出现的系列个数。
		/// </summary>
		[JsonProperty("maxCount")]
		public double? MaxCount { get; set; }

		/// <summary>
		///     当图表只包含一个系列时，采用的描述。
		/// </summary>
		[JsonProperty("single")]
		public Aria_Label_Series_Single Single { get; set; }

		/// <summary>
		///     当图表只包含多个系列时，采用的描述。
		/// </summary>
		[JsonProperty("multiple")]
		public Aria_Label_Series_Multiple Multiple { get; set; }
	}
}