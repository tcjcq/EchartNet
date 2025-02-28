using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     类目数据，在类目轴（type: 'category'）中有效。
	///     如果没有设置 type，但是设置了 axis.data，则认为 type 是 'category'。
	///     如果设置了 type 是 'category'，但没有设置 axis.data，则 axis.data 的内容会自动从 series.data 中获取，这会比较方便。不过注意，axis.data 指明的是 'category'
	///     轴的取值范围。如果不指定而是从 series.data 中获取，那么只能获取到 series.data 中出现的值。比如说，假如 series.data 为空时，就什么也获取不到。
	///     示例：
	///     // 所有类目名称列表
	///     data: ['周一', '周二', '周三', '周四', '周五', '周六', '周日']
	///     // 每一项也可以是具体的配置项，此时取配置项中的 `value` 为类目名
	///     data: [{
	///     value: '周一',
	///     // 突出周一
	///     textStyle: {
	///     fontSize: 20,
	///     color: 'red'
	///     }
	///     }, '周二', '周三', '周四', '周五', '周六', '周日']
	/// </summary>
	[JsonConverter(typeof(AxisDataConverter<XAxis_Data>))]
	public class XAxis_Data
	{
		/// <summary>
		///     单个类目名称。
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		///     类目标签的文字样式。
		/// </summary>
		[JsonProperty("textStyle")]
		public NameTextStyle0 TextStyle { get; set; }
	}
}