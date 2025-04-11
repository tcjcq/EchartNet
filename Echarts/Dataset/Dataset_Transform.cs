using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     参见 数据变换教程
/// </summary>
public class Dataset_Transform
{
	/// <summary>
	/// </summary>
	[JsonProperty("filter")]
	public Dataset_Transform_Filter Filter { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty("sort")]
	public Dataset_Transform_Filter Sort { get; set; }

	/// <summary>
	///     除了上述的内置的数据转换器外，我们也可以使用外部的数据转换器。外部数据转换器能提供或自己定制更丰富的功能。
	///     参见 数据变换教程
	/// </summary>
	[JsonProperty("xxx")]
	public Dataset_Transform_Xxx Xxx { get; set; }
}