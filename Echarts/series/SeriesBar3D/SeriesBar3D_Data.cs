using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     三维柱状图数据数组。数组每一项为一个数据。通常这个数据是用数组存储数据的每个属性/维度。例如下面：
	///     data: [
	///     [[12, 14, 10], [34, 50, 15], [56, 30, 20], [10, 15, 12], [23, 10, 14]]
	///     ]
	///     对于数组中的每一项：
	///     在 grid3D 中，每一项的前三个值分别是x, y, z。
	///     在 geo3D 以及 globe 中，每一项的前两个值分别是经纬度 lng, lat，第三个值表示数值大小，例如人口的多少。这个值会被映射到 minHeight ~ maxHeight 的范围。
	///     除了默认给坐标系使用的三个值，每一项还可以加入任意多个值，用于给 visualMap 组件映射到颜色等其它图形属性。
	///     有些时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	///     [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值
	///     value: [12, 14, 10]
	///     }, {
	///     name: '数据2',
	///     value: [34, 50, 15]
	///     }]
	///     需要对个别内容指定进行个性化定义时：
	///     [{
	///     name: '数据1',
	///     value: [12, 14, 10]
	///     }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : [34, 50, 15],
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	///     }]
	/// </summary>
	public class SeriesBar3D_Data
	{
		/// <summary>
		///     数据项名称。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     数据项值。
		/// </summary>
		[JsonProperty("value")]
		public double[] Value { get; set; }

		/// <summary>
		///     单个数据项的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle12 ItemStyle { get; set; }

		/// <summary>
		///     单个数据项的标签设置。
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		///     单个数据项高亮状态的标签和样式配置。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesBar3D_Data_Emphasis Emphasis { get; set; }
	}
}