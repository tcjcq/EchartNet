using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     环形布局相关配置
	/// </summary>
	public class SeriesGraph_Circular
	{
		/// <summary>
		///     是否旋转标签，默认不旋转
		/// </summary>
		[JsonProperty("rotateLabel")]
		public bool? RotateLabel { get; set; }
	}
}