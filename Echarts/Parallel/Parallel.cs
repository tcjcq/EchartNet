using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     平行坐标系介绍
	///     平行坐标系（Parallel Coordinates） 是一种常用的可视化高维数据的图表。
	///     例如 series-parallel.data 中有如下数据：
	///     [
	///     [1,  55,  9,   56,  0.46,  18,  6,  '良'],
	///     [2,  25,  11,  21,  0.65,  34,  9,  '优'],
	///     [3,  56,  7,   63,  0.3,   14,  5,  '良'],
	///     [4,  33,  7,   29,  0.33,  16,  6,  '优'],
	///     { // 数据项也可以是 Object，从而里面能含有对线条的特殊设置。
	///     value: [5,  42,  24,  44,  0.76,  40,  16, '优']
	///     lineStyle: {...},
	///     }
	///     ...
	///     ]
	///     数据中，每一行是一个『数据项』，每一列属于一个『维度』。（例如上面数据每一列的含义分别是：『日期』,『AQI指数』, 『PM2.5』, 『PM10』, 『一氧化碳值』, 『二氧化氮值』, 『二氧化硫值』）。
	///     平行坐标系适用于对这种多维数据进行可视化分析。每一个维度（每一列）对应一个坐标轴，每一个『数据项』是一条线，贯穿多个坐标轴。在坐标轴上，可以进行数据选取等操作。如下：
	///     配置方式概要
	///     『平行坐标系』的 option 基本配置如下例：
	///     option = {
	///     parallelAxis: [                     // 这是一个个『坐标轴』的定义
	///     {dim: 0, name: schema[0].text}, // 每个『坐标轴』有个 'dim' 属性，表示坐标轴的维度号。
	///     {dim: 1, name: schema[1].text},
	///     {dim: 2, name: schema[2].text},
	///     {dim: 3, name: schema[3].text},
	///     {dim: 4, name: schema[4].text},
	///     {dim: 5, name: schema[5].text},
	///     {dim: 6, name: schema[6].text},
	///     {dim: 7, name: schema[7].text,
	///     type: 'category',           // 坐标轴也可以支持类别型数据
	///     data: ['优', '良', '轻度污染', '中度污染', '重度污染', '严重污染']
	///     }
	///     ],
	///     parallel: {                         // 这是『坐标系』的定义
	///     left: '5%',                     // 平行坐标系的位置设置
	///     right: '13%',
	///     bottom: '10%',
	///     top: '20%',
	///     parallelAxisDefault: {          // 『坐标轴』的公有属性可以配置在这里避免重复书写
	///     type: 'value',
	///     nameLocation: 'end',
	///     nameGap: 20
	///     }
	///     },
	///     series: [                           // 这里三个系列共用一个平行坐标系
	///     {
	///     name: '北京',
	///     type: 'parallel',           // 这个系列类型是 'parallel'
	///     data: [
	///     [1,  55,  9,   56,  0.46,  18,  6,  '良'],
	///     [2,  25,  11,  21,  0.65,  34,  9,  '优'],
	///     ...
	///     ]
	///     },
	///     {
	///     name: '上海',
	///     type: 'parallel',
	///     data: [
	///     [3,  56,  7,   63,  0.3,   14,  5,  '良'],
	///     [4,  33,  7,   29,  0.33,  16,  6,  '优'],
	///     ...
	///     ]
	///     },
	///     {
	///     name: '广州',
	///     type: 'parallel',
	///     data: [
	///     [4,  33,  7,   29,  0.33,  16,  6,  '优'],
	///     [5,  42,  24,  44,  0.76,  40,  16, '优'],
	///     ...
	///     ]
	///     }
	///     ]
	///     };
	///     需要涉及到三个组件：parallel、parallelAxis、series-parallel
	///     parallel
	///     这个配置项是平行坐标系的『坐标系』本身。一个系列（series）或多个系列（如上图中的『北京』、『上海』、『广州』分别各是一个系列）可以共用这个『坐标系』。
	///     和其他坐标系一样，坐标系也可以创建多个。
	///     位置设置，也是放在这里进行。
	///     parallelAxis
	///     这个是『坐标系』中的坐标轴的配置。自然，需要有多个坐标轴。
	///     其中有 parallelAxis.parallelIndex 属性，指定这个『坐标轴』在哪个『坐标系』中。默认使用第一个『坐标系』。
	///     series-parallel
	///     这个是『系列』的定义。系列被画到『坐标系』上。
	///     其中有 series-parallel.parallelIndex 属性，指定使用哪个『坐标系』。默认使用第一个『坐标系』。
	///     配置注意和最佳实践
	///     配置多个 parallelAxis 时，有些值一样的属性，如果书写多遍则比较繁琐，那么可以放置在 parallel.parallelAxisDefault
	///     里。在坐标轴初始化前，parallel.parallelAxisDefault 里的配置项，会分别融合进 parallelAxis，形成最终的坐标轴的配置。
	///     如果数据量很大并且发生卡顿
	///     建议把 series-parallel.lineStyle.width 设为 0.5（或更小），
	///     可能显著改善性能。
	///     高维数据的显示
	///     维度比较多时，比如有 50+ 的维度，那么就会有 50+ 个轴。那么可能会页面显示不下。
	///     可以通过 parallel.axisExpandable 来改善显示效果。
	/// </summary>
	public class Parallel
	{
		/// <summary>
		///     组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

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
		///     parallel 组件离容器左侧的距离。
		///     left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
		///     如果 left 的值为 'left', 'center', 'right'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		///     parallel 组件离容器上侧的距离。
		///     top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
		///     如果 top 的值为 'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		///     parallel 组件离容器右侧的距离。
		///     right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		///     parallel 组件离容器下侧的距离。
		///     bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		///     parallel 组件的宽度。默认自适应。
		/// </summary>
		[JsonProperty("width")]
		public StringOrNumber Width { get; set; }

		/// <summary>
		///     parallel 组件的高度。默认自适应。
		/// </summary>
		[JsonProperty("height")]
		public StringOrNumber Height { get; set; }

		/// <summary>
		///     布局方式，可选值为：
		///     'horizontal'：水平排布各个坐标轴。
		///     'vertical'：竖直排布各个坐标轴。
		/// </summary>
		[JsonProperty("layout")]
		public string Layout { get; set; }

		/// <summary>
		///     维度比较多时，比如有 50+ 的维度，那么就会有 50+ 个轴。那么可能会页面显示不下。
		///     可以通过 parallel.axisExpandable 来改善显示效果。
		///     是否允许点击展开折叠 axis。
		/// </summary>
		[JsonProperty("axisExpandable")]
		public bool? AxisExpandable { get; set; }

		/// <summary>
		///     初始时，以哪个轴为中心展开，这里给出轴的 index。没有默认值，需要手动指定。
		///     参见 parallel.axisExpandable
		/// </summary>
		[JsonProperty("axisExpandCenter")]
		public double? AxisExpandCenter { get; set; }

		/// <summary>
		///     初始时，有多少个轴会处于展开状态。建议根据你的维度个数而手动指定。
		///     参见 parallel.axisExpandCenter
		///     参见 parallel.axisExpandable
		/// </summary>
		[JsonProperty("axisExpandCount")]
		public double? AxisExpandCount { get; set; }

		/// <summary>
		///     在展开状态，轴的间距是多少，单位为像素。
		///     参见 parallel.axisExpandable
		/// </summary>
		[JsonProperty("axisExpandWidth")]
		public double? AxisExpandWidth { get; set; }

		/// <summary>
		///     可取值：
		///     'click'：鼠标点击的时候 expand。
		///     'mousemove'：鼠标悬浮的时候 expand。
		/// </summary>
		[JsonProperty("axisExpandTriggerOn")]
		public string AxisExpandTriggerOn { get; set; }

		/// <summary>
		///     配置多个 parallelAxis 时，有些值一样的属性，如果书写多遍则比较繁琐，那么可以放置在 parallel.parallelAxisDefault
		///     里。在坐标轴初始化前，parallel.parallelAxisDefault 里的配置项，会分别融合进 parallelAxis，形成最终的坐标轴的配置。
		///     参见示例
		/// </summary>
		[JsonProperty("parallelAxisDefault")]
		public Parallel_ParallelAxisDefault ParallelAxisDefault { get; set; }
	}
}