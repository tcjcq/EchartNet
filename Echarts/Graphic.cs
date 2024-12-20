using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// graphic 是原生图形元素组件。可以支持的图形元素包括：
	/// image,
	/// text,
	/// circle,
	/// sector,
	/// ring,
	/// polygon,
	/// polyline,
	/// rect,
	/// line,
	/// bezierCurve,
	/// arc,
	/// group,
	/// 下面示例中，使用图形元素做了水印，和文本块：
	/// 
	/// 
	/// 
	/// 下面示例中，使用隐藏的图形元素实现了拖拽：
	/// 
	/// 
	/// 
	/// 
	/// graphic 设置介绍
	/// 只配一个图形元素时的简写方法：
	/// myChart.setOption({
	///     ...,
	///     graphic: {
	///         type: 'image',
	///         ...
	///     }
	/// });
	/// 
	/// 配多个图形元素：
	/// myChart.setOption({
	///     ...,
	///     graphic: [
	///         { // 一个图形元素，类型是 image。
	///             type: 'image',
	///             ...
	///         },
	///         { // 一个图形元素，类型是 text，指定了 id。
	///             type: 'text',
	///             id: 'text1',
	///             ...
	///         },
	///         { // 一个图形元素，类型是 group，可以嵌套子节点。
	///             type: 'group',
	///             children: [
	///                 {
	///                     type: 'rect',
	///                     id: 'rect1',
	///                     ...
	///                 },
	///                 {
	///                     type: 'image',
	///                     ...
	///                 },
	///                 ...
	///             ]
	///         }
	///         ...
	///     ]
	/// });
	/// 
	/// 
	/// 使用 setOption 来删除或更换（替代）已有的图形元素：
	/// myChart.setOption({
	///     ...,
	///     graphic: [
	///         { // 删除上例中定义的 'text1' 元素。
	///             id: 'text1',
	///             $action: 'remove',
	///             ...
	///         },
	///         { // 将上例中定义的 'rect1' 元素换成 circle。
	///           // 注意尽管 'rect1' 在一个 group 中，但这里并不需要顾忌层级，用id指定就可以了。
	///             id: 'rect1',
	///             $action: 'replace',
	///             type: 'circle',
	///             ...
	///         }
	///     ]
	/// });
	/// 
	/// 注意，如果没有指定 id，第二次 setOption 时会按照元素在 option 中出现的顺序和已有的图形元素进行匹配。这有时会产生不易理解的效果。
	/// 所以，一般来说，更新 elements 时推荐使用 id 进行准确的指定，而非省略 id。
	/// 图形元素设置介绍
	/// 介绍每个图形元素的配置。不同类型的图形元素的设置有这些共性：
	/// {
	///     // id 用于在更新图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
	///     id: 'xxx',
	/// 
	///     // 这个字段在第一次设置时不能忽略，取值见上方『支持的图形元素』。
	///     type: 'image',
	/// 
	///     // 下面的各个属性如果不需要设置都可以忽略，忽略则取默认值。
	/// 
	///     // 指定本次 setOption 对此图形元素进行的操作。默认是 'merge'，还可以 'replace' 或 'remove'。
	///     $action: 'replace',
	/// 
	///     // 这是四个相对于父元素的定位属性，每个属性可取『像素值』或者『百分比』或者 'center'/'middle'。
	///     left: 10,
	///     // right: 10,
	///     top: 'center',
	///     // bottom: '10%',
	/// 
	///     shape: {
	///         // 定位、形状相关的设置，如 x, y, cx, cy, width, height, r, points 等。
	///         // 注意，如果设置了 left/right/top/bottom，这里的定位用的 x/y/cx/cy 会失效。
	///     },
	/// 
	///     style: {
	///         // 样式相关的设置，如 fill, stroke, lineWidth, shadowBlur 等。
	///     },
	/// 
	///     // 表示 z 高度，从而指定了图形元素的覆盖关系。
	///     z: 10,
	///     // 表示不响应事件。
	///     silent: true,
	///     // 表示节点不显示
	///     invisible: false,
	///     // 设置是否整体限制在父节点范围内。可选值：'raw', 'all'。
	///     bouding: 'raw',
	///     // 是否可以被拖拽。
	///     draggable: false,
	///     // 事件的监听器，还可以是 onmousemove, ondrag 等。支持的事件参见下。
	///     onclick: function () {...}
	/// }
	/// 
	/// 图形元素的事件
	/// 支持这些事件配置：
	/// onclick, onmouseover, onmouseout, onmousemove, onmousewheel, onmousedown, onmouseup, ondrag, ondragstart, ondragend, ondragenter, ondragleave, ondragover, ondrop。
	/// 图形元素的层级关系
	/// 只有 group 元素可以有子节点，从而以该 group 元素为根的元素树可以共同定位（共同移动）。
	/// 图形元素的基本形状设置
	/// 每个图形元素本身有自己的图形基本的位置和尺寸设置，例如：
	/// {
	///     type: 'rect',
	///     shape: {
	///         x: 10,
	///         y: 10,
	///         width: 100,
	///         height: 200
	///     }
	/// },
	/// {
	///     type: 'circle',
	///     shape: {
	///         cx: 20,
	///         cy: 30,
	///         r: 100
	///     }
	/// },
	/// {
	///     type: 'image',
	///     style: {
	///         image: 'http://example.website/a.png',
	///         x: 100,
	///         y: 200,
	///         width: 230,
	///         height: 400
	///     }
	/// },
	/// {
	///     type: 'text',
	///     style: {
	///         text: 'This text',
	///         x: 100,
	///         y: 200
	///     }
	/// 
	/// }
	/// 
	/// 图形元素的定位和 transfrom
	/// 除此以外，可以以 transform 的方式对图形进行平移、旋转、缩放，
	/// 参见：position、rotation、scale、origin。
	/// {
	///     type: 'rect',
	///     position: [100, 200], // 平移，默认值为 [0, 0]。
	///     scale: [2, 4], // 缩放，默认值为 [1, 1]。表示缩放的倍数。
	///     rotation: Math.PI / 4, // 旋转，默认值为 0。表示旋转的弧度值。正值表示逆时针旋转。
	///     origin: [10, 20], // 旋转和缩放的中心点，默认值为 [0, 0]。
	///     shape: {
	///         // ...
	///     }
	/// }
	/// 
	/// 每个图形元素在父节点的坐标系中进行 transform，也就是说父子节点的 transform 能『叠加』。
	/// 每个图形元素进行 transform 顺序是：
	/// 
	/// 平移 [-el.origin[0], -el.origin[1]]。
	/// 根据 el.scale 缩放。
	/// 根据 el.rotation 旋转。
	/// 根据 el.origin 平移。
	/// 根据 el.position 平移。
	/// 
	/// 也就是说先缩放旋转后平移，这样平移不会影响缩放旋转的 origin。
	/// 图形元素相对定位
	/// 以上两者是基本的绝对定位，除此之外，在实际应用中，容器尺寸常常是不确定甚至动态变化的，所以需要提供相对定位的机制。graphic 组件使用 left / right / top / bottom / width / height 提供了相对定位的机制。
	/// 例如：
	/// { // 将图片定位到最下方的中间：
	///     type: 'image',
	///     left: 'center', // 水平定位到中间
	///     bottom: '10%',  // 定位到距离下边界 10% 处
	///     style: {
	///         image: 'http://example.website/a.png',
	///         width: 45,
	///         height: 45
	///     }
	/// },
	/// { // 将旋转过的 group 整体定位右下角：
	///     type: 'group',
	///     right: 0,  // 定位到右下角
	///     bottom: 0, // 定位到右下角
	///     rotation: Math.PI / 4,
	///     children: [
	///         {
	///             type: 'rect',
	///             left: 'center', // 相对父元素居中
	///             top: 'middle',  // 相对父元素居中
	///             shape: {
	///                 width: 190,
	///                 height: 90
	///             },
	///             style: {
	///                 fill: '#fff',
	///                 stroke: '#999',
	///                 lineWidth: 2,
	///                 shadowBlur: 8,
	///                 shadowOffsetX: 3,
	///                 shadowOffsetY: 3,
	///                 shadowColor: 'rgba(0,0,0,0.3)'
	///             }
	///         },
	///         {
	///             type: 'text',
	///             left: 'center', // 相对父元素居中
	///             top: 'middle',  // 相对父元素居中
	///             style: {
	///                 fill: '#777',
	///                 text: [
	///                     'This is text',
	///                     '这是一段文字',
	///                     'Print some text'
	///                 ].join('\n'),
	///                 font: '14px Microsoft YaHei'
	///             }
	///         }
	///     ]
	/// }
	/// 
	/// 注意，可以用 bounding 来设置是否整体限制在父节点范围内。
	/// </summary>
	/// <summary>
	/// 
	/// </summary>
	public class Graphic
	{
		/// <summary>
		/// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 里面是所有图形元素的集合。
		/// 注意：graphic 的标准写法是：
		/// {
		///     graphic: {
		///         elements: [
		///             {type: 'rect', ...}, {type: 'circle', ...}, ...
		///         ]
		///     }
		/// }
		/// 
		/// 但是我们常常可以用简写：
		/// {
		///     graphic: {
		///         type: 'rect',
		///         ...
		///     }
		/// }
		/// 
		/// 或者：
		/// {
		///     graphic: [
		///         {type: 'rect', ...}, {type: 'circle', ...}, ...
		///     ]
		/// }
		/// </summary>
		[JsonProperty("elements")]
		public Graphic_Elements[] Elements { get; set; }
	}

	/// <summary>
	/// 里面是所有图形元素的集合。
	/// 注意：graphic 的标准写法是：
	/// {
	///     graphic: {
	///         elements: [
	///             {type: 'rect', ...}, {type: 'circle', ...}, ...
	///         ]
	///     }
	/// }
	/// 
	/// 但是我们常常可以用简写：
	/// {
	///     graphic: {
	///         type: 'rect',
	///         ...
	///     }
	/// }
	/// 
	/// 或者：
	/// {
	///     graphic: [
	///         {type: 'rect', ...}, {type: 'circle', ...}, ...
	///     ]
	/// }
	/// </summary>
	public class Graphic_Elements
	{
		/// <summary>
		/// group 是唯一的可以有子节点的容器。group 可以用来整体定位一组图形元素。
		/// </summary>
		[JsonProperty("group")]
		public Graphic_Elements_Group Group { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("image")]
		public Graphic_Elements_Image Image { get; set; }

		/// <summary>
		/// 文本块。
		/// </summary>
		[JsonProperty("text")]
		public Graphic_Elements_Text Text { get; set; }

		/// <summary>
		/// 矩形。
		/// </summary>
		[JsonProperty("rect")]
		public Graphic_Elements_Rect Rect { get; set; }

		/// <summary>
		/// 圆。
		/// </summary>
		[JsonProperty("circle")]
		public Graphic_Elements_Circle Circle { get; set; }

		/// <summary>
		/// 圆环。
		/// </summary>
		[JsonProperty("ring")]
		public Graphic_Elements_Ring Ring { get; set; }

		/// <summary>
		/// 扇形。
		/// </summary>
		[JsonProperty("sector")]
		public Graphic_Elements_Sector Sector { get; set; }

		/// <summary>
		/// 圆弧。
		/// </summary>
		[JsonProperty("arc")]
		public Graphic_Elements_Sector Arc { get; set; }

		/// <summary>
		/// 多边形。
		/// </summary>
		[JsonProperty("polygon")]
		public Graphic_Elements_Polygon Polygon { get; set; }

		/// <summary>
		/// 折线。
		/// </summary>
		[JsonProperty("polyline")]
		public Graphic_Elements_Polygon Polyline { get; set; }

		/// <summary>
		/// 直线。
		/// </summary>
		[JsonProperty("line")]
		public Graphic_Elements_Line Line { get; set; }

		/// <summary>
		/// 二次或三次贝塞尔曲线。
		/// </summary>
		[JsonProperty("bezierCurve")]
		public Graphic_Elements_BezierCurve BezierCurve { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Group
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "group";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 用于描述此 group 的宽。
		/// 这个宽只用于给子节点定位。
		/// 即便当宽度为零的时候，子节点也可以使用 left: 'center' 相对于父节点水平居中。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 用于描述此 group 的高。
		/// 这个高只用于给子节点定位。
		/// 即便当高度为零的时候，子节点也可以使用 top: 'middle' 相对于父节点垂直居中。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 在 自定义系列 中，当 diffChildrenByName: true 时，对于 renderItem 返回值中的每一个 group，会根据其 children 中每个图形元素的 name 属性进行 "diff"。在这里，"diff" 的意思是，重绘的时候，在已存在的图形元素和新的图形元素之间建立对应关系（依据 name 是否相同），从如果数据有更新，能够形成的过渡动画。
		/// 但是注意，这会有性能开销。如果数据量较大，不要开启这个功能。
		/// </summary>
		[JsonProperty("diffChildrenByName")]
		public bool? DiffChildrenByName { get; set; }

		/// <summary>
		/// 子节点列表，其中项都是一个图形元素定义。
		/// </summary>
		[JsonProperty("children")]
		public double[] Children { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Image
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "image";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style0 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Style0
	{
		/// <summary>
		/// 图片的内容，可以是图片的 URL，也可以是 dataURI.
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 图形元素的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 图形元素的高度。
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 填充色。
		/// </summary>
		[JsonProperty("fill")]
		public string Fill { get; set; }

		/// <summary>
		/// 线条颜色。
		/// </summary>
		[JsonProperty("stroke")]
		public string Stroke { get; set; }

		/// <summary>
		/// 线条宽度。
		/// </summary>
		[JsonProperty("lineWidth")]
		public double? LineWidth { get; set; }

		/// <summary>
		/// 线条样式。可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// number 或 number 数组。详见 MDN。
		/// </summary>
		[JsonProperty("lineDash")]
		public StringOrNumber[] LineDash { get; set; }

		/// <summary>
		/// 用于设置虚线的偏移量。详见 MDN。
		/// </summary>
		[JsonProperty("lineDashOffset")]
		public double? LineDashOffset { get; set; }

		/// <summary>
		/// 用于指定线段末端的绘制方式。详见 MDN。
		/// </summary>
		[JsonProperty("lineCap")]
		public string LineCap { get; set; }

		/// <summary>
		/// 设置线条转折点的样式。详见 MDN。
		/// </summary>
		[JsonProperty("lineJoin")]
		public string LineJoin { get; set; }

		/// <summary>
		/// 设置斜接面限制比例的属性。详见 MDN。
		/// </summary>
		[JsonProperty("miterLimit")]
		public double? MiterLimit { get; set; }

		/// <summary>
		/// 阴影宽度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影 X 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影 Y 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public double? ShadowColor { get; set; }

		/// <summary>
		/// 不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 style 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     style: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 style 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     style: { ... },
		///     // `style` 下所有属性开启过渡动画。
		///     transition: 'style',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Text
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "text";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style1 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Style1
	{
		/// <summary>
		/// 文本块文字。可以使用 \n 来换行。
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 字体大小、字体类型、粗细、字体样式。格式参见 css font。
		/// 例如：
		/// // size | family
		/// font: '2em "STHeiti", sans-serif'
		/// 
		/// // style | weight | size | family
		/// font: 'italic bolder 16px cursive'
		/// 
		/// // weight | size | family
		/// font: 'bolder 2em "Microsoft YaHei", sans-serif'
		/// </summary>
		[JsonProperty("font")]
		public string Font { get; set; }

		/// <summary>
		/// 水平对齐方式，取值：'left', 'center', 'right'。
		/// 如果为 'left'，表示文本最左端在 x 值上。如果为 'right'，表示文本最右端在 x 值上。
		/// </summary>
		[JsonProperty("textAlign")]
		public string TextAlign { get; set; }

		/// <summary>
		/// 文本限制宽度，用于提供 overflow 的参考。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 当文本内容超出 width 时的文本显示策略，取值：'break', 'breakAll', 'truncate', 'none'。
		/// 
		/// 'break': 尽可能保证完整的单词不被截断(类似 CSS 中的 word-break: break-word;)
		/// 'breakAll': 可在任意字符间断行
		/// 'truncate': 截断文本屏显示 '...'，可以使用 ellipsis 来自定义省略号的显示
		/// 'none': 不换行
		/// </summary>
		[JsonProperty("overflow")]
		public string Overflow { get; set; }

		/// <summary>
		/// 当 overflow 设置为 'truncate' 时生效，默认为 ...。
		/// </summary>
		[JsonProperty("ellipsis")]
		public string Ellipsis { get; set; }

		/// <summary>
		/// 垂直对齐方式，取值：'top', 'middle', 'bottom'。
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("textVerticalAlign")]
		public string TextVerticalAlign { get; set; }

		/// <summary>
		/// 填充色。
		/// </summary>
		[JsonProperty("fill")]
		public string Fill { get; set; }

		/// <summary>
		/// 线条颜色。
		/// </summary>
		[JsonProperty("stroke")]
		public string Stroke { get; set; }

		/// <summary>
		/// 线条宽度。
		/// </summary>
		[JsonProperty("lineWidth")]
		public double? LineWidth { get; set; }

		/// <summary>
		/// 线条样式。可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// number 或 number 数组。详见 MDN。
		/// </summary>
		[JsonProperty("lineDash")]
		public StringOrNumber[] LineDash { get; set; }

		/// <summary>
		/// 用于设置虚线的偏移量。详见 MDN。
		/// </summary>
		[JsonProperty("lineDashOffset")]
		public double? LineDashOffset { get; set; }

		/// <summary>
		/// 用于指定线段末端的绘制方式。详见 MDN。
		/// </summary>
		[JsonProperty("lineCap")]
		public string LineCap { get; set; }

		/// <summary>
		/// 设置线条转折点的样式。详见 MDN。
		/// </summary>
		[JsonProperty("lineJoin")]
		public string LineJoin { get; set; }

		/// <summary>
		/// 设置斜接面限制比例的属性。详见 MDN。
		/// </summary>
		[JsonProperty("miterLimit")]
		public double? MiterLimit { get; set; }

		/// <summary>
		/// 阴影宽度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影 X 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影 Y 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public double? ShadowColor { get; set; }

		/// <summary>
		/// 不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 style 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     style: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 style 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     style: { ... },
		///     // `style` 下所有属性开启过渡动画。
		///     transition: 'style',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Rect
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "rect";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape0 Shape { get; set; }

		/// <summary>
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Shape0
	{
		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 图形元素的左上角在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 图形元素的宽度。
		/// </summary>
		[JsonProperty("width")]
		public double? Width { get; set; }

		/// <summary>
		/// 图形元素的高度。
		/// </summary>
		[JsonProperty("height")]
		public double? Height { get; set; }

		/// <summary>
		/// 可以用于设置圆角矩形。r: [r1, r2, r3, r4]，
		/// 左上、右上、右下、左下角的半径依次为r1、r2、r3、r4。
		/// 可以缩写，例如：
		/// 
		/// r 缩写为 1         相当于 [1, 1, 1, 1]
		/// r 缩写为 [1]       相当于 [1, 1, 1, 1]
		/// r 缩写为 [1, 2]    相当于 [1, 2, 1, 2]
		/// r 缩写为 [1, 2, 3]1 相当于[1, 2, 3, 2]`
		/// </summary>
		[JsonProperty("r")]
		public double[] R { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 shape 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     shape: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 shape 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Circle
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "circle";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape1 Shape { get; set; }

		/// <summary>
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Shape1
	{
		/// <summary>
		/// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("cx")]
		public double? Cx { get; set; }

		/// <summary>
		/// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("cy")]
		public double? Cy { get; set; }

		/// <summary>
		/// 外半径。
		/// </summary>
		[JsonProperty("r")]
		public double? R { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 shape 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     shape: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 shape 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Ring
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "ring";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape2 Shape { get; set; }

		/// <summary>
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Shape2
	{
		/// <summary>
		/// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("cx")]
		public double? Cx { get; set; }

		/// <summary>
		/// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("cy")]
		public double? Cy { get; set; }

		/// <summary>
		/// 外半径。
		/// </summary>
		[JsonProperty("r")]
		public double? R { get; set; }

		/// <summary>
		/// 内半径。
		/// </summary>
		[JsonProperty("r0")]
		public double? R0 { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 shape 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     shape: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 shape 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Sector
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "sector";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape3 Shape { get; set; }

		/// <summary>
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Shape3
	{
		/// <summary>
		/// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的横坐标值。
		/// </summary>
		[JsonProperty("cx")]
		public double? Cx { get; set; }

		/// <summary>
		/// 图形元素的中心在父节点坐标系（以父节点左上角为原点）中的纵坐标值。
		/// </summary>
		[JsonProperty("cy")]
		public double? Cy { get; set; }

		/// <summary>
		/// 外半径。
		/// </summary>
		[JsonProperty("r")]
		public double? R { get; set; }

		/// <summary>
		/// 内半径。
		/// </summary>
		[JsonProperty("r0")]
		public double? R0 { get; set; }

		/// <summary>
		/// 开始弧度。
		/// </summary>
		[JsonProperty("startAngle")]
		public double? StartAngle { get; set; }

		/// <summary>
		/// 结束弧度。
		/// </summary>
		[JsonProperty("endAngle")]
		public double? EndAngle { get; set; }

		/// <summary>
		/// 是否顺时针。
		/// </summary>
		[JsonProperty("clockwise")]
		public bool? Clockwise { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 shape 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     shape: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 shape 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Polygon
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "polygon";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape4 Shape { get; set; }

		/// <summary>
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Shape4
	{
		/// <summary>
		/// 点列表，用于定义形状，如 [[22, 44], [44, 55], [11, 44], ...]
		/// </summary>
		[JsonProperty("points")]
		public double[] Points { get; set; }

		/// <summary>
		/// 是否平滑曲线。
		/// 
		/// 如果为 number：表示贝塞尔 (bezier) 差值平滑，smooth 指定了平滑等级，范围 [0, 1]。
		/// 如果为 'spline'：表示 Catmull-Rom spline 差值平滑。
		/// </summary>
		[JsonProperty("smooth")]
		public StringOrNumber Smooth { get; set; }

		/// <summary>
		/// 是否将平滑曲线约束在包围盒中。smooth 为 number（bezier）时生效。
		/// </summary>
		[JsonProperty("smoothConstraint")]
		public bool? SmoothConstraint { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 shape 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     shape: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 shape 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_Line
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "line";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape5 Shape { get; set; }

		/// <summary>
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Shape5
	{
		/// <summary>
		/// 开始点的 x 值。
		/// </summary>
		[JsonProperty("x1")]
		public double? X1 { get; set; }

		/// <summary>
		/// 开始点的 y 值。
		/// </summary>
		[JsonProperty("y1")]
		public double? Y1 { get; set; }

		/// <summary>
		/// 结束点的 x 值。
		/// </summary>
		[JsonProperty("x2")]
		public double? X2 { get; set; }

		/// <summary>
		/// 结束点的 y 值。
		/// </summary>
		[JsonProperty("y2")]
		public double? Y2 { get; set; }

		/// <summary>
		/// 线画到百分之多少就不画了。值的范围：[0, 1]。
		/// </summary>
		[JsonProperty("percent")]
		public double? Percent { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 shape 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     shape: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 shape 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}


	/// <summary>
	/// 
	/// </summary>
	public class Graphic_Elements_BezierCurve
	{
		/// <summary>
		/// 用 setOption 首次设定图形元素时必须指定。
		/// 可取值：
		/// image,
		/// text,
		/// circle,
		/// sector,
		/// ring,
		/// polygon,
		/// polyline,
		/// rect,
		/// line,
		/// bezierCurve,
		/// arc,
		/// group,
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "bezierCurve";

		/// <summary>
		/// id 用于在更新或删除图形元素时指定更新哪个图形元素，如果不需要用可以忽略。
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// setOption 时指定本次对该图形元素的操作行为。
		/// 可取值：
		/// 
		/// 'merge'：如果已有元素，则新的配置项和已有的设定进行 merge。如果没有则新建。
		/// 'replace'：如果已有元素，删除之，新建元素替代之。
		/// 'remove'：删除元素。
		/// </summary>
		[JsonProperty("$action")]
		public string Action { get; set; }

		/// <summary>
		/// 元素的 x 像素位置。
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 元素的 y 像素位置。
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 元素的旋转
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 元素在 x 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 元素在 y 方向上的缩放。
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 x 像素位置。
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 元素旋转和缩放原点的 y 像素位置。
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 可以通过'all'指定所有属性都开启过渡动画，也可以指定单个或一组属性。
		/// Transform 相关的属性：'x'、 'y'、'scaleX'、'scaleY'、'rotation'、'originX'、'originY'。例如：
		/// {
		///     type: 'rect',
		///     x: 100,
		///     y: 200,
		///     transition: ['x', 'y']
		/// }
		/// 
		/// 还可以是这三个属性 'shape'、'style'、'extra'。表示这三个属性中所有的子属性都开启过渡动画。例如：
		/// {
		///     type: 'rect',
		///     shape: { // ... },
		///     // 表示 shape 中所有属性都开启过渡动画。
		///     transition: 'shape',
		/// }
		/// 
		/// 在自定义系列中，当 transition 没有指定时，'x' 和 'y' 会默认开启过渡动画。如果想禁用这种默认，可设定为空数组：transition: []
		/// transition 效果参考 例子。
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 配置图形的入场属性用于入场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     enterFrom: {
		///         // 淡入
		///         style: { opacity: 0 },
		///         // 从左飞入
		///         x: 0
		///     }
		/// }
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 配置图形的退场属性用于退场动画。例如：
		/// {
		///     type: 'circle',
		///     x: 100,
		///     leaveTo: {
		///         // 淡出
		///         style: { opacity: 0 },
		///         // 向右飞出
		///         x: 200
		///     }
		/// }
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 入场动画配置。
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 更新属性的动画配置。
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 退场动画配置。
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
		/// 示例：
		/// keyframeAnimation: [{
		///     // 呼吸效果的缩放动画
		///     duration: 1000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0.5,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 0.1,
		///         scaleY: 0.1
		///     }, {
		///         percent: 1,
		///         easing: 'sinusoidalInOut',
		///         scaleX: 1,
		///         scaleY: 1
		///     }]
		/// }, {
		///     // 平移动画
		///     duration: 2000,
		///     loop: true,
		///     keyframes: [{
		///         percent: 0,
		///         x: 10
		///     }, {
		///         percent: 1,
		///         x: 100
		///     }]
		/// }]
		/// 
		/// 
		/// 假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("left")]
		public StringOrNumber Left { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的高和此百分比计算出最终值。
		/// 'center'：表示自动居中。
		/// 
		/// left 和 right 只有一个可以生效。
		/// 如果指定 left 或 right，则 shape 里的 x、cx 等定位属性不再生效。
		/// </summary>
		[JsonProperty("right")]
		public StringOrNumber Right { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("top")]
		public StringOrNumber Top { get; set; }

		/// <summary>
		/// 描述怎么根据父元素进行定位。
		/// 『父元素』是指：如果是顶层元素，父元素是 echarts 图表容器。如果是 group 的子元素，父元素就是 group 元素。
		/// 值的类型可以是：
		/// 
		/// number：表示像素值。
		/// 百分比值：如 '33%'，用父元素的宽和此百分比计算出最终值。
		/// 'middle'：表示自动居中。
		/// 
		/// top 和 bottom 只有一个可以生效。
		/// 如果指定 top 或 bottom，则 shape 里的 y、cy 等定位属性不再生效。
		/// </summary>
		[JsonProperty("bottom")]
		public StringOrNumber Bottom { get; set; }

		/// <summary>
		/// 决定此图形元素在定位时，对自身的包围盒计算方式。
		/// 参见例子：
		/// 
		/// 
		/// 
		/// 可取值：
		/// 
		/// 'all'：（默认）
		///   表示用自身以及子节点整体的经过 transform 后的包围盒进行定位。
		///   这种方式易于使整体都限制在父元素范围中。
		/// 
		/// 'raw'：
		///   表示仅仅用自身（不包括子节点）的没经过 transform 的包围盒进行定位。
		///   这种方式易于内容超出父元素范围的定位方式。
		/// </summary>
		[JsonProperty("bounding")]
		public string Bounding { get; set; }

		/// <summary>
		/// z 方向的高度，决定层叠关系。
		/// </summary>
		[JsonProperty("z")]
		public double? Z { get; set; }

		/// <summary>
		/// 决定此元素绘制在哪个 canvas 层中。注意，越多 canvas 层会占用越多资源。
		/// </summary>
		[JsonProperty("zlevel")]
		public double? Zlevel { get; set; }

		/// <summary>
		/// 用户定义的任意数据，可以在 event listener 中访问，如：
		/// chart.on('click', function (params) {
		///     console.log(params.info);
		/// });
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 是否不响应鼠标以及触摸事件。
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 节点是否可见。
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 节点是否完全被忽略（既不渲染，也不响应事件）。
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 这是一个文本定义，附着在一个节点上，会依据 textConfig 配置，相对于节点布局。
		/// 里面的属性同于 text。
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 在动画的每一帧里，用户可以使用 during 回调来设定节点的各种属性。
		/// (duringAPI: CustomDuringAPI) => void
		/// 
		/// interface CustomDuringAPI {
		///     // 设置 transform 属性值。
		///     // transform 属性参见 `TransformProp`。
		///     setTransform(key: TransformProp, val: unknown): void;
		///     // 获得当前动画帧的 transform 属性值。
		///     getTransform(key: TransformProp): unknown;
		///     // 设置 shape 属性值。
		///     // shape 属性形如：`{ type: 'rect', shape: { xxxProp: xxxValue } }`。
		///     setShape(key: string, val: unknown): void;
		///     // 获得当前动画帧的 shape 属性值。
		///     getShape(key: string): unknown;
		///     // 设置 style 属性值。
		///     // style 属性形如：`{ type: 'rect', style: { xxxProp: xxxValue } }`。
		///     setStyle(key: string, val: unknown): void;
		///     // 获得当前动画帧的 style 属性值。
		///     getStyle(key: string): unknown;
		///     // 设置 extra 属性值。
		///     // extra 属性形如：`{ type: 'rect', extra: { xxxProp: xxxValue } }`。
		///     setExtra(key: string, val: unknown): void;
		///     // 获得当前动画帧的 extra 属性值。
		///     getExtra(key: string): unknown;
		/// }
		/// 
		/// type TransformProp =
		///     'x' | 'y' | 'scaleX' | 'scaleY' | 'originX' | 'originY' | 'rotation';
		/// 
		/// 在绝大多数场景下，用户不需要这个 during 回调。因为，假如属性被设定到 transition 中后，echarts 会自动对它进行插值，并且基于这些插值形成动画。但是，如果这些插值形成的动画不满足用户需求，那么用户可以使用 during 回调来定制他们。
		/// 例如，如果用户使用 polygon 画图形，图形的形状会由 shape.points 来定义，形如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...]
		///     },
		///     // ...
		/// }
		/// 
		/// 如果用户指定了 transition 如：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: [[12, 33], [15, 36], [19, 39], ...],
		///     },
		///     transition: 'shape'
		///     // ...
		/// }
		/// 
		/// 尽管这些 points 会被 echarts 自动插值，但是这样形成的动画里，这些点会直线走向目标位置。假如用户需求是，这些点要按照某种特定的路径（如弧线、螺旋）来移动，则这就不满足了。所以在这种情况下，可以使用 during 回调如下：
		/// {
		///     type: 'polygon',
		///     shape: {
		///         points: calculatePoints(initialDegree),
		///         transition: 'points'
		///     },
		///     extra: {
		///         degree: nextDegree
		///     },
		///     // 让 echarts 对 `extra.degree` 进行插值，然后基于
		///     // `extra.degree` 来计算动画中每一帧时的 polygon 形状。
		///     transition: 'extra',
		///     during: function (duringAPI) {
		///         var currentDegree = duringAPI.getExtra('degree');
		///         duringAPI.setShape(calculatePoints(currentDegree));
		///     }
		///     // ...
		/// }
		/// 
		/// 也参见这个 例子。
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 鼠标悬浮时在图形元素上时鼠标的样式是什么。同 CSS 的 cursor。
		/// </summary>
		[JsonProperty("cursor")]
		public string Cursor { get; set; }

		/// <summary>
		/// 图形元素是否可以被拖拽。
		/// 设置为 true/false 以启用/禁用拖拽，也可以设置为 'horizontal'/'vertical' 限制只允许水平或垂直方向拖拽。
		/// </summary>
		[JsonProperty("draggable")]
		public StringOrBool Draggable { get; set; }

		/// <summary>
		/// 是否渐进式渲染。当图形元素过多时才使用。
		/// </summary>
		[JsonProperty("progressive")]
		public bool? Progressive { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public Shape6 Shape { get; set; }

		/// <summary>
		/// 注：关于图形元素中更多的样式设置（例如 富文本标签），参见 zrender/graphic/Displayable 中的 style 相关属性。
		/// 注意，这里图形元素的样式属性名称直接源于 zrender，和 echarts label、echarts itemStyle 等处同样含义的样式属性名称或有不同。例如，有如下对应：
		/// 
		/// itemStyle.color => style.fill
		/// itemStyle.borderColor => style.stroke
		/// label.color => style.textFill
		/// label.textBorderColor => style.textStroke
		/// ...
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果。支持如下配置：
		/// 
		/// 'none' 不淡出其它图形，默认使用该配置。
		/// 'self' 只聚焦（不淡出）当前高亮的数据的图形。
		/// 'series' 聚焦当前高亮的数据所在的系列的所有图形。
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 从 v5.0.0 开始支持
		/// 
		/// 在开启focus的时候，可以通过blurScope配置淡出的范围。支持如下配置
		/// 
		/// 'coordinateSystem' 淡出范围为坐标系，默认使用该配置。
		/// 'series' 淡出范围为系列。
		/// 'global' 淡出范围为全局。
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onclick")]
		public string Onclick { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseover")]
		public string Onmouseover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseout")]
		public string Onmouseout { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousemove")]
		public string Onmousemove { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousewheel")]
		public string Onmousewheel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmousedown")]
		public string Onmousedown { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("onmouseup")]
		public string Onmouseup { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrag")]
		public string Ondrag { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragstart")]
		public string Ondragstart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragend")]
		public string Ondragend { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragenter")]
		public string Ondragenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragleave")]
		public string Ondragleave { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondragover")]
		public string Ondragover { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ondrop")]
		public string Ondrop { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class EnterAnimation0
	{
		/// <summary>
		/// 动画时长，单位 ms
		/// </summary>
		[JsonProperty("duration")]
		public double? Duration { get; set; }

		/// <summary>
		/// 动画缓动。不同的缓动效果可以参考 缓动示例。
		/// </summary>
		[JsonProperty("easing")]
		public string Easing { get; set; }

		/// <summary>
		/// 动画延迟时长，单位 ms
		/// </summary>
		[JsonProperty("delay")]
		public double? Delay { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class KeyframeAnimation0
	{
		/// <summary>
		/// 动画时长，单位 ms
		/// </summary>
		[JsonProperty("duration")]
		public double? Duration { get; set; }

		/// <summary>
		/// 动画缓动。不同的缓动效果可以参考 缓动示例。
		/// </summary>
		[JsonProperty("easing")]
		public string Easing { get; set; }

		/// <summary>
		/// 动画延迟时长，单位 ms
		/// </summary>
		[JsonProperty("delay")]
		public double? Delay { get; set; }

		/// <summary>
		/// 是否循环播放动画。
		/// </summary>
		[JsonProperty("loop")]
		public bool? Loop { get; set; }

		/// <summary>
		/// 动画的关键帧。数组中每一项为一个关键帧，格式如下：
		/// interface Keyframe {
		///     // 关键帧位置。0 为第一帧，1 为最后一帧
		///     // 关键帧时间为 percent * duration + delay
		///     percent: number
		///     // 上一个关键帧到这个关键帧运行时的缓动函数。可选
		///     easing?: number
		/// 
		///     // 其它属性为图形在这个关键帧的属性，例如 x, y, style, shape 等
		/// }
		/// </summary>
		[JsonProperty("keyframes")]
		public double[] Keyframes { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class TextConfig0
	{
		/// <summary>
		/// Position of textContent.
		/// 
		/// 'left'
		/// 'right'
		/// 'top'
		/// 'bottom'
		/// 'inside'
		/// 'insideLeft'
		/// 'insideRight'
		/// 'insideTop'
		/// 'insideBottom'
		/// 'insideTopLeft'
		/// 'insideTopRight'
		/// 'insideBottomLeft'
		/// 'insideBottomRight'
		/// or like [12, 33]
		/// or like ['50%', '50%']
		/// </summary>
		[JsonProperty("position")]
		public string Position { get; set; }

		/// <summary>
		/// textContent 的旋转弧度。
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// textContent 根据此矩形来布局位置。
		/// 默认是节点的包围盒。
		/// {
		///     x: number
		///     y: number
		///     width: number
		///     height: number
		/// }
		/// </summary>
		[JsonProperty("layoutRect")]
		public object LayoutRect { get; set; }

		/// <summary>
		/// textContent 的偏移。
		/// offset 和 position 的区别是，offset 是旋转（rotation）后计算。
		/// </summary>
		[JsonProperty("offset")]
		public double[] Offset { get; set; }

		/// <summary>
		/// origin 相对于节点的包围盒。
		/// 可以是百分数。
		/// 如果指定为 'center'，则定位在包围盒中心。
		/// 只有当 position and rotation 都设置时，生效。
		/// 
		/// 如 [12, 33]
		/// 或如 ['50%', '50%']
		/// 'center'
		/// </summary>
		[JsonProperty("origin")]
		public string Origin { get; set; }

		/// <summary>
		/// 距离 layoutRect 的距离。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 如果 true 的话，会采用节点的 transform。
		/// </summary>
		[JsonProperty("local")]
		public bool? Local { get; set; }

		/// <summary>
		/// insideFill 可以是一个颜色字符串，或者空着。
		/// 如果 textContent 是 "inside"，它的 fill 会按这个优先级来选取：
		/// textContent.style.fill > textConfig.insideFill > "auto-calculated-fill"
		/// 在绝大多数场景下，"auto-calculated-fill" 是白色。
		/// </summary>
		[JsonProperty("insideFill")]
		public string InsideFill { get; set; }

		/// <summary>
		/// insideStroke 可以是一个颜色字符串，或者空着。
		/// 如果 textContent 是 "inside"，它的 stroke 会按这个优先级来选取：
		/// textContent.style.stroke > textConfig.insideStroke > "auto-calculated-stroke"
		/// "auto-calculated-stroke" 的规则是：
		/// 
		/// 如果
		/// (A) fill 在 style 中被指定（无论是在 textContent.style 还是 textContent.style.rich 里）
		/// 或者 (B) 需要画文字的背景（无论是定义在 textContent.style 还是 textContent.style.rich 里）
		/// "auto-calculated-stroke" 都会为 null。
		/// 
		/// 
		/// 否则
		/// "auto-calculated-stroke" 会和节点的 fill 相同，如果 fill 没有的话则为 null。
		/// </summary>
		[JsonProperty("insideStroke")]
		public string InsideStroke { get; set; }

		/// <summary>
		/// outsideFill 可以是一个颜色字符串，或者空着。
		/// 如果 textContent 是 "inside"，它的 fill 会按这个优先级来选取：
		/// textContent.style.fill > textConfig.outsideFill > #000
		/// </summary>
		[JsonProperty("outsideFill")]
		public string OutsideFill { get; set; }

		/// <summary>
		/// outsideStroke 可以是一个颜色字符串，或者空着。
		/// 如果 textContent 不是 "inside"，它的 stroke 会按这个优先级来选取：
		/// textContent.style.stroke > textConfig.outsideStroke > "auto-calculated-stroke"
		/// "auto-calculated-stroke" 的规则是：
		/// 
		/// 如果
		/// (A) fill 在 style 中被指定（无论是在 textContent.style 还是 textContent.style.rich 里）
		/// 或者 (B) 需要画文字的背景（无论是定义在 textContent.style 还是 textContent.style.rich 里）
		/// "auto-calculated-stroke" 都会为 null。
		/// 
		/// 
		/// 否则
		/// "auto-calculated-stroke" 会为一个近似于白色的颜色，来区别于背景。
		/// </summary>
		[JsonProperty("outsideStroke")]
		public string OutsideStroke { get; set; }

		/// <summary>
		/// 如果确定文本是在节点中的话，则此可设置为 true，避免 echarts 额外猜测。
		/// </summary>
		[JsonProperty("inside")]
		public bool? Inside { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Shape6
	{
		/// <summary>
		/// 开始点的 x 值。
		/// </summary>
		[JsonProperty("x1")]
		public double? X1 { get; set; }

		/// <summary>
		/// 开始点的 y 值。
		/// </summary>
		[JsonProperty("y1")]
		public double? Y1 { get; set; }

		/// <summary>
		/// 结束点的 x 值。
		/// </summary>
		[JsonProperty("x2")]
		public double? X2 { get; set; }

		/// <summary>
		/// 结束点的 y 值。
		/// </summary>
		[JsonProperty("y2")]
		public double? Y2 { get; set; }

		/// <summary>
		/// 控制点 x 值。
		/// </summary>
		[JsonProperty("cpx1")]
		public double? Cpx1 { get; set; }

		/// <summary>
		/// 控制点 y 值。
		/// </summary>
		[JsonProperty("cpy1")]
		public double? Cpy1 { get; set; }

		/// <summary>
		/// 第二个控制点 x 值。如果设置则开启三阶贝塞尔曲线。
		/// </summary>
		[JsonProperty("cpx2")]
		public double? Cpx2 { get; set; }

		/// <summary>
		/// 第二个控制点 y 值。如果设置则开启三阶贝塞尔曲线。
		/// </summary>
		[JsonProperty("cpy2")]
		public double? Cpy2 { get; set; }

		/// <summary>
		/// 画到百分之多少就不画了。值的范围：[0, 1]。
		/// </summary>
		[JsonProperty("percent")]
		public double? Percent { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 shape 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     shape: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 shape 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     shape: { ... },
		///     // `shape` 下所有属性开启过渡动画。
		///     transition: 'shape',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class Style2
	{
		/// <summary>
		/// 填充色。
		/// </summary>
		[JsonProperty("fill")]
		public string Fill { get; set; }

		/// <summary>
		/// 线条颜色。
		/// </summary>
		[JsonProperty("stroke")]
		public string Stroke { get; set; }

		/// <summary>
		/// 线条宽度。
		/// </summary>
		[JsonProperty("lineWidth")]
		public double? LineWidth { get; set; }

		/// <summary>
		/// 线条样式。可选：
		/// 
		/// 'solid'
		/// 'dashed'
		/// 'dotted'
		/// number 或 number 数组。详见 MDN。
		/// </summary>
		[JsonProperty("lineDash")]
		public StringOrNumber[] LineDash { get; set; }

		/// <summary>
		/// 用于设置虚线的偏移量。详见 MDN。
		/// </summary>
		[JsonProperty("lineDashOffset")]
		public double? LineDashOffset { get; set; }

		/// <summary>
		/// 用于指定线段末端的绘制方式。详见 MDN。
		/// </summary>
		[JsonProperty("lineCap")]
		public string LineCap { get; set; }

		/// <summary>
		/// 设置线条转折点的样式。详见 MDN。
		/// </summary>
		[JsonProperty("lineJoin")]
		public string LineJoin { get; set; }

		/// <summary>
		/// 设置斜接面限制比例的属性。详见 MDN。
		/// </summary>
		[JsonProperty("miterLimit")]
		public double? MiterLimit { get; set; }

		/// <summary>
		/// 阴影宽度。
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影 X 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影 Y 方向偏移。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 阴影颜色。
		/// </summary>
		[JsonProperty("shadowColor")]
		public double? ShadowColor { get; set; }

		/// <summary>
		/// 不透明度。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 可以是一个属性名，或者一组属性名。
		/// 被指定的属性，在其指发生变化时，会开启过渡动画。
		/// 只可以指定本 style 下的属性。
		/// 例如：
		/// {
		///     type: 'rect',
		///     style: {
		///         // ...
		///         // 这两个属性会开启过渡动画。
		///         transition: ['mmm', 'ppp']
		///     }
		/// }
		/// 
		/// 我们这样可以指定 style 下所有属性开启过渡动画：
		/// {
		///     type: 'rect',
		///     style: { ... },
		///     // `style` 下所有属性开启过渡动画。
		///     transition: 'style',
		/// }
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }
	}
}