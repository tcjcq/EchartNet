using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     从 v5.3.0 开始支持
	///     自定义地图投影，至少需要提供project, unproject两个方法分别用来计算投影后的坐标以及计算投影前的坐标。
	///     比如墨卡托投影：
	///     series: {
	///     type: 'map',
	///     projection: {
	///     project: (point) => [point[0] / 180 * Math.PI, -Math.log(Math.tan((Math.PI / 2 + point[1] / 180 * Math.PI) / 2))],
	///     unproject: (point) => [point[0] * 180 / Math.PI, 2 * 180 / Math.PI * Math.atan(Math.exp(point[1])) - 90]
	///     }
	///     }
	///     除了我们自己实现投影公式，我们也可以使用 d3-geo 等第三方库提供的现成的投影实现：
	///     const projection = d3.geoConicEqualArea();
	///     // ...
	///     series: {
	///     type: 'map',
	///     projection: {
	///     project: (point) => projection(point),
	///     unproject: (point) => projection.invert(point)
	///     }
	///     }
	///     注：自定义投影只有在使用GeoJSON作为数据源的时候有用。
	/// </summary>
	public class Geo_Projection
	{
		/// <summary>
		///     (coord: [number, number]) => [number, number]
		///     将经纬度坐标投影为其它坐标。
		/// </summary>
		[JsonProperty("project")]
		public string Project { get; set; }

		/// <summary>
		///     (point: [number, number]) => [number, number]
		///     根据投影后坐标计算投影前的经纬度坐标
		/// </summary>
		[JsonProperty("unproject")]
		public string Unproject { get; set; }

		/// <summary>
		///     该属性主要用于适配 d3-geo 中使用的 stream 接口。在引入 stream 后可以同时引入d3-geo 中实现的Antimeridian Clipping以及Adaptive Sampling算法。
		///     const projection = d3.geoProjection((x, y) => ([x, y / 0.75]))
		///     .rotate([-115, 0]);
		///     // ...
		///     series: {
		///     type: 'map',
		///     projection: {
		///     // project 和 unproject 依旧需要配置。
		///     project: (point) => projection(point),
		///     unproject: (point) => projection.invert(point),
		///     // 可以直接使用 d3-geo 提供的 stream 方法。
		///     stream: projection.stream
		///     }
		///     }
		///     该配置并非是必要的。
		/// </summary>
		[JsonProperty("stream")]
		public string Stream { get; set; }
	}
}