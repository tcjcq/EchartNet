using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
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
        public string Type { get; set; }="image";

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
 }
