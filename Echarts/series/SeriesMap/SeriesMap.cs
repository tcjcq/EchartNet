using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     地图。
///     地图主要用于地理区域数据的可视化，配合 visualMap 组件用于展示不同区域的人口分布密度等数据。
///     多个地图类型相同的系列会在同一地图上显示，这时候使用第一个系列的配置项作为地图绘制的配置。
///     Tip: 在 ECharts 3 中不再建议在地图类型的图表使用 markLine 和 markPoint。如果要实现点数据或者线数据的可视化，可以使用在地理坐标系组件上的散点图和线图。
/// </summary>
public class SeriesMap
{
	/// <summary>
	/// </summary>
	[JsonProperty("type")]
	public string Type { get; set; } = "map";

	/// <summary>
	///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	///     系列名称，用于tooltip的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	///     从 v5.2.0 开始支持
	///     从调色盘 option.color 中取色的策略，可取值为：
	///     'series'：按照系列分配调色盘中的颜色，同一系列中的所有数据都是用相同的颜色；
	///     'data'：按照数据项分配调色盘中的颜色，每个数据项都使用不同的颜色。
	/// </summary>
	[JsonProperty("colorBy")]
	public string ColorBy { get; set; }

	/// <summary>
	///     使用 registerMap 注册的地图名称。
	///     geoJSON 引入示例
	///     $.get('map/china_geo.json', function (geoJson) {
	///     echarts.registerMap('china', {geoJSON: geoJson});
	///     var chart = echarts.init(document.getElementById('main'));
	///     chart.setOption({
	///     series: [{
	///     type: 'map',
	///     map: 'china',
	///     ...
	///     }]
	///     });
	///     });
	///     也参见示例 USA Population Estimates。
	///     如上所示，ECharts 可以使用 GeoJSON 格式的数据作为地图的轮廓，你可以获取第三方的 GeoJSON 数据注册到 ECharts 中。例如第三方资源 maps。
	///     SVG 引入示例
	///     $.get('map/topographic_map.svg', function (svg) {
	///     echarts.registerMap('topo', {svg: svg});
	///     var chart = echarts.init(document.getElementById('main'));
	///     chart.setOption({
	///     series: [{
	///     type: 'map',
	///     map: 'topo',
	///     ...
	///     }]
	///     });
	///     });
	///     也参见示例 Beef Cuts。
	///     如上所示，ECharts 也可以使用 SVG 格式的地图。详情参见：SVG 底图。
	/// </summary>
	[JsonProperty("map")]
	public string Map { get; set; }

	/// <summary>
	///     是否开启鼠标缩放和平移漫游。默认不开启。如果只想要开启缩放或者平移，可以设置成 'scale' 或者 'move'。设置成 true 为都开启
	/// </summary>
	[JsonProperty("roam")]
	public StringOrBool Roam { get; set; }

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
	[JsonProperty("projection")]
	public Geo_Projection Projection { get; set; }

	/// <summary>
	///     当前视角的中心点。可以是包含两个 number 类型（表示像素值）或 string 类型（表示相对容器的百分比）的数组。
	///     从 5.3.3 版本开始支持 string 类型。
	///     例如：
	///     center: [115.97, '30%']
	/// </summary>
	[JsonProperty("center")]
	public double[] Center { get; set; }

	/// <summary>
	///     这个参数用于 scale 地图的长宽比，如果设置了projection则无效。
	///     最终的 aspect 的计算方式是：geoBoundingRect.width / geoBoundingRect.height * aspectScale。
	/// </summary>
	[JsonProperty("aspectScale")]
	public double? AspectScale { get; set; }

	/// <summary>
	///     二维数组，定义定位的左上角以及右下角分别所对应的经纬度。例如
	///     // 设置为一张完整经纬度的世界地图
	///     map: 'world',
	///     left: 0, top: 0, right: 0, bottom: 0,
	///     boundingCoords: [
	///     // 定位左上角经纬度
	///     [-180, 90],
	///     // 定位右下角经纬度
	///     [180, -90]
	///     ],
	/// </summary>
	[JsonProperty("boundingCoords")]
	public double[] BoundingCoords { get; set; }

	/// <summary>
	///     当前视角的缩放比例。
	/// </summary>
	[JsonProperty("zoom")]
	public double? Zoom { get; set; }

	/// <summary>
	///     滚轮缩放的极限控制，通过 min 和 max 限制最小和最大的缩放值。
	/// </summary>
	[JsonProperty("scaleLimit")]
	public Geo_ScaleLimit ScaleLimit { get; set; }

	/// <summary>
	///     自定义地区的名称映射，如：
	///     {
	///     'China' : '中国'
	///     }
	/// </summary>
	[JsonProperty("nameMap")]
	public object NameMap { get; set; }

	/// <summary>
	///     从 v4.8.0 开始支持
	///     默认是 'name'，针对 GeoJSON 要素的自定义属性名称，作为主键用于关联数据点和 GeoJSON 地理要素。
	///     例如：
	///     {
	///     nameProperty: 'NAME', // 数据点中的 name：Alabama 会关联到 GeoJSON 中 NAME 属性值为 Alabama
	///     的地理要素{"type":"Feature","id":"01","properties":{"NAME":"Alabama"}, "geometry": { ... }}
	///     data:[
	///     {name: 'Alabama', value: 4822023},
	///     {name: 'Alaska', value: 731449},
	///     ]
	///     }
	/// </summary>
	[JsonProperty("nameProperty")]
	public string NameProperty { get; set; }

	/// <summary>
	///     选中模式，表示是否支持多个选中，默认关闭，支持布尔值和字符串，字符串取值可选'single'表示单选，或者'multiple'表示多选。
	/// </summary>
	[JsonProperty("selectedMode")]
	public StringOrBool SelectedMode { get; set; }

	/// <summary>
	///     图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
	/// </summary>
	[JsonProperty("label")]
	public Label6 Label { get; set; }

	/// <summary>
	///     地图区域的多边形 图形样式。
	/// </summary>
	[JsonProperty("itemStyle")]
	public ItemStyle1 ItemStyle { get; set; }

	/// <summary>
	///     高亮状态下的多边形和标签样式。
	/// </summary>
	[JsonProperty("emphasis")]
	public Select0 Emphasis { get; set; }

	/// <summary>
	///     选中状态下的多边形和标签样式。
	/// </summary>
	[JsonProperty("select")]
	public Select0 Select { get; set; }

	/// <summary>
	///     所有图形的 zlevel 值。
	///     zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的
	///     Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。
	///     zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。
	/// </summary>
	[JsonProperty("zlevel")]
	public double? Zlevel { get; set; }

	/// <summary>
	///     组件的所有图形的z值。控制图形的前后顺序。z值小的图形会被z值大的图形覆盖。
	///     z相比zlevel优先级更低，而且不会创建新的 Canvas。
	/// </summary>
	[JsonProperty("z")]
	public double? Z { get; set; }

	/// <summary>
	///     组件离容器左侧的距离。
	///     left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
	///     如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
	/// </summary>
	[JsonProperty("left")]
	public StringOrNumber Left { get; set; }

	/// <summary>
	///     组件离容器上侧的距离。
	///     top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
	///     如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
	/// </summary>
	[JsonProperty("top")]
	public StringOrNumber Top { get; set; }

	/// <summary>
	///     组件离容器右侧的距离。
	///     right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
	///     默认自适应。
	/// </summary>
	[JsonProperty("right")]
	public StringOrNumber Right { get; set; }

	/// <summary>
	///     组件离容器下侧的距离。
	///     bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
	///     默认自适应。
	/// </summary>
	[JsonProperty("bottom")]
	public StringOrNumber Bottom { get; set; }

	/// <summary>
	///     layoutCenter 和 layoutSize 提供了除了 left/right/top/bottom/width/height 之外的布局手段。
	///     在使用 left/right/top/bottom/width/height 的时候，可能很难在保持地图高宽比的情况下把地图放在某个盒形区域的正中间，并且保证不超出盒形的范围。此时可以通过 layoutCenter
	///     属性定义地图中心在屏幕中的位置，layoutSize 定义地图的大小。如下示例
	///     layoutCenter: ['30%', '30%'],
	///     // 如果宽高比大于 1 则宽度为 100，如果小于 1 则高度为 100，保证了不超过 100x100 的区域
	///     layoutSize: 100
	///     设置这两个值后 left/right/top/bottom/width/height 无效。
	/// </summary>
	[JsonProperty("layoutCenter")]
	public double[] LayoutCenter { get; set; }

	/// <summary>
	///     地图的大小，见 layoutCenter。支持相对于屏幕宽高的百分比或者绝对的像素大小。
	/// </summary>
	[JsonProperty("layoutSize")]
	public StringOrNumber LayoutSize { get; set; }

	/// <summary>
	///     默认情况下，map series 会自己生成内部专用的 geo 组件。但是也可以用这个 geoIndex 指定一个 geo 组件。这样的话，map 和 其他 series（例如散点图）就可以共享一个 geo 组件了。并且，geo
	///     组件的颜色也可以被这个 map series 控制，从而用 visualMap 来更改。
	///     当设定了 geoIndex 后，series-map.map 属性，以及 series-map.itemStyle 等样式配置不再起作用，而是采用 geo 中的相应属性。
	/// </summary>
	[JsonProperty("geoIndex")]
	public double? GeoIndex { get; set; }

	/// <summary>
	///     多个拥有相同地图类型的系列会使用同一个地图展现，如果多个系列都在同一个区域有值，ECharts 会对这些值统计得到一个数据。这个配置项就是用于配置统计的方式，目前有：
	///     'sum'   取和。
	///     'average' 取平均值。
	///     'max'   取最大值。
	///     'min'   取最小值。
	/// </summary>
	[JsonProperty("mapValueCalculation")]
	public string MapValueCalculation { get; set; }

	/// <summary>
	///     在图例相应区域显示图例的颜色标识（系列标识的小圆点），存在 legend 组件时生效。
	/// </summary>
	[JsonProperty("showLegendSymbol")]
	public bool? ShowLegendSymbol { get; set; }

	/// <summary>
	///     当使用 dataset 时，seriesLayoutBy 指定了 dataset 中用行还是列对应到系列上，也就是说，系列“排布”到 dataset 的行还是列上。可取值：
	///     'column'：默认，dataset 的列对应于系列，从而 dataset 中每一列是一个维度（dimension）。
	///     'row'：dataset 的行对应于系列，从而 dataset 中每一行是一个维度（dimension）。
	///     参见这个 示例
	/// </summary>
	[JsonProperty("seriesLayoutBy")]
	public string SeriesLayoutBy { get; set; }

	/// <summary>
	///     如果 series.data 没有指定，并且 dataset 存在，那么就会使用 dataset。datasetIndex 指定本系列使用哪个 dataset。
	/// </summary>
	[JsonProperty("datasetIndex")]
	public double? DatasetIndex { get; set; }

	/// <summary>
	///     该系列所有数据项的组 ID，优先级低于groupId。详见series.data.groupId。
	/// </summary>
	[JsonProperty("dataGroupId")]
	public string DataGroupId { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的统一布局配置。
	///     该配置项是在每个系列默认的标签布局基础上，统一调整标签的(x, y)位置，标签对齐等属性以实现想要的标签布局效果。
	///     该配置项也可以是一个有如下参数的回调函数
	///     // 标签对应数据的 dataIndex
	///     dataIndex: number
	///     // 标签对应的数据类型，只在关系图中会有 node 和 edge 数据类型的区分
	///     dataType?: string
	///     // 标签对应的系列的 index
	///     seriesIndex: number
	///     // 标签显示的文本
	///     text: string
	///     // 默认的标签的包围盒，由系列默认的标签布局决定
	///     labelRect: {x: number, y: number, width: number, height: number}
	///     // 默认的标签水平对齐
	///     align: 'left' | 'center' | 'right'
	///     // 默认的标签垂直对齐
	///     verticalAlign: 'top' | 'middle' | 'bottom'
	///     // 标签所对应的数据图形的包围盒，可用于定位标签位置
	///     rect: {x: number, y: number, width: number, height: number}
	///     // 默认引导线的位置，目前只有饼图(pie)和漏斗图(funnel)有默认标签位置
	///     // 如果没有该值则为 null
	///     labelLinePoints?: number[][]
	///     示例：
	///     将标签显示在图形右侧 10px 的位置，并且垂直居中：
	///     labelLayout(params) {
	///     return {
	///     x: params.rect.x + 10,
	///     y: params.rect.y + params.rect.height / 2,
	///     verticalAlign: 'middle',
	///     align: 'left'
	///     }
	///     }
	///     根据图形的包围盒尺寸决定文本尺寸
	///     labelLayout(params) {
	///     return {
	///     fontSize: Math.max(params.rect.width / 10, 5)
	///     };
	///     }
	/// </summary>
	[JsonProperty("labelLayout")]
	public LabelLayout0 LabelLayout { get; set; }

	/// <summary>
	///     从 v5.0.0 开始支持
	///     标签的视觉引导线配置。
	/// </summary>
	[JsonProperty("labelLine")]
	public LabelLine1 LabelLine { get; set; }

	/// <summary>
	///     地图系列中的数据内容数组。数组项可以为单个数值，如：
	///     [12, 34, 56, 10, 23]
	///     如果需要在数据中加入其它维度给 visualMap 组件用来映射到颜色等其它图形属性。每个数据项也可以是数组，如：
	///     [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]
	///     这时候可以将每项数组中的第二个值指定给 visualMap 组件。
	///     更多时候我们需要指定每个数据项的名称，这时候需要每个项为一个对象：
	///     [{
	///     // 数据项的名称
	///     name: '数据1',
	///     // 数据项值8
	///     value: 10
	///     }, {
	///     name: '数据2',
	///     value: 20
	///     }]
	///     需要对个别内容指定进行个性化定义时：
	///     [{
	///     name: '数据1',
	///     value: 10
	///     }, {
	///     // 数据项名称
	///     name: '数据2',
	///     value : 56,
	///     //自定义特殊 tooltip，仅对该数据项有效
	///     tooltip:{},
	///     //自定义特殊itemStyle，仅对该item有效
	///     itemStyle:{}
	///     }]
	/// </summary>
	[JsonProperty("data")]
	public SeriesMap_Data[] Data { get; set; }

	/// <summary>
	///     图表标注。
	/// </summary>
	[JsonProperty("markPoint")]
	public SeriesMap_MarkPoint MarkPoint { get; set; }

	/// <summary>
	///     图表标线。
	/// </summary>
	[JsonProperty("markLine")]
	public SeriesMap_MarkLine MarkLine { get; set; }

	/// <summary>
	///     图表标域，常用于标记图表中某个范围的数据，例如标出某段时间投放了广告。
	/// </summary>
	[JsonProperty("markArea")]
	public SeriesMap_MarkArea MarkArea { get; set; }

	/// <summary>
	///     图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
	/// </summary>
	[JsonProperty("silent")]
	public bool? Silent { get; set; }

	/// <summary>
	///     从 v5.2.0 开始支持
	///     全局过渡动画相关的配置。
	///     全局过渡动画（Universal
	///     Transition）提供了任意系列之间进行变形动画的功能。开启该功能后，每次setOption，相同id的系列之间会自动关联进行动画的过渡，更细粒度的关联配置见universalTransition.seriesKey配置。
	///     通过配置数据项的groupId和childGroupId，还可以实现诸如下钻，聚合等一对多或者多对一的动画。
	///     可以直接在系列中配置 universalTransition: true 开启该功能。也可以提供一个对象进行更多属性的配置。
	/// </summary>
	[JsonProperty("universalTransition")]
	public SeriesLine_UniversalTransition UniversalTransition { get; set; }

	/// <summary>
	///     本系列特定的 tooltip 设定。
	/// </summary>
	[JsonProperty("tooltip")]
	public Tooltip1 Tooltip { get; set; }
}