using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     地图区域的设置。
	/// </summary>
	public class Geo3D_Regions
	{
		/// <summary>
		///     所对应的地图区域的名称，例如 '广东'，'浙江'。
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     区域的高度。可以设置不同的高度用来表达数据的大小。当 GeoJSON 为建筑的数据时，也可以通过这个值表示简直的高度。如下图:
		/// </summary>
		[JsonProperty("regionHeight")]
		public double? RegionHeight { get; set; }

		/// <summary>
		///     单个区域的样式设置。
		/// </summary>
		[JsonProperty("itemStyle")]
		public ItemStyle13 ItemStyle { get; set; }

		/// <summary>
		///     单个区域的标签设置。
		/// </summary>
		[JsonProperty("label")]
		public Geo3D_Label Label { get; set; }

		/// <summary>
		///     单个区域的标签和样式的高亮设置。
		/// </summary>
		[JsonProperty("emphasis")]
		public SeriesMap3D_Data_Emphasis Emphasis { get; set; }
	}
}