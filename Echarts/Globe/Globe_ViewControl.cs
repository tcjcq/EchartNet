using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// viewControl用于鼠标的旋转，缩放等视角控制。
	/// </summary>
	public class Globe_ViewControl
	{
		/// <summary>
		/// 投影方式，默认为透视投影'perspective'，也支持设置为正交投影'orthographic'。
		/// </summary>
		[JsonProperty("projection")]
		public string Projection { get; set; }

		/// <summary>
		/// 是否开启视角绕物体的自动旋转查看。
		/// </summary>
		[JsonProperty("autoRotate")]
		public bool? AutoRotate { get; set; }

		/// <summary>
		/// 物体自转的方向。默认是 'cw' 也就是从上往下看是顺时针方向，也可以取 'ccw'，既从上往下看为逆时针方向。
		/// </summary>
		[JsonProperty("autoRotateDirection")]
		public string AutoRotateDirection { get; set; }

		/// <summary>
		/// 物体自转的速度。单位为角度 / 秒，默认为10 ，也就是36秒转一圈。
		/// </summary>
		[JsonProperty("autoRotateSpeed")]
		public double? AutoRotateSpeed { get; set; }

		/// <summary>
		/// 在鼠标静止操作后恢复自动旋转的时间间隔。在开启 autoRotate 后有效。
		/// </summary>
		[JsonProperty("autoRotateAfterStill")]
		public double? AutoRotateAfterStill { get; set; }

		/// <summary>
		/// 鼠标进行旋转，缩放等操作时的迟滞因子，在大于 0 的时候鼠标在停止操作后，视角仍会因为一定的惯性继续运动（旋转和缩放）。
		/// </summary>
		[JsonProperty("damping")]
		public double? Damping { get; set; }

		/// <summary>
		/// 旋转操作的灵敏度，值越大越灵敏。支持使用数组分别设置横向和纵向的旋转灵敏度。
		/// 默认为1。
		/// 设置为0后无法旋转。
		/// // 无法旋转
		/// rotateSensitivity: 0
		/// // 只能横向旋转
		/// rotateSensitivity: [1, 0]
		/// // 只能纵向旋转
		/// rotateSensitivity: [0, 1]
		/// </summary>
		[JsonProperty("rotateSensitivity")]
		public ArrayOrSingle RotateSensitivity { get; set; }

		/// <summary>
		/// 缩放操作的灵敏度，值越大越灵敏。默认为1。
		/// 设置为0后无法缩放。
		/// </summary>
		[JsonProperty("zoomSensitivity")]
		public double? ZoomSensitivity { get; set; }

		/// <summary>
		/// 平移操作的灵敏度，值越大越灵敏。支持使用数组分别设置横向和纵向的平移灵敏度
		/// 默认为1。
		/// 设置为0后无法平移。
		/// </summary>
		[JsonProperty("panSensitivity")]
		public double? PanSensitivity { get; set; }

		/// <summary>
		/// 平移操作使用的鼠标按键，支持：
		/// 
		/// 'left' 鼠标左键（默认）
		/// 
		/// 'middle' 鼠标中键
		/// 
		/// 'right' 鼠标右键
		/// 
		/// 
		/// 注意：如果设置为鼠标右键则会阻止默认的右键菜单。
		/// </summary>
		[JsonProperty("panMouseButton")]
		public string PanMouseButton { get; set; }

		/// <summary>
		/// 旋转操作使用的鼠标按键，支持：
		/// 
		/// 'left' 鼠标左键
		/// 
		/// 'middle' 鼠标中键（默认）
		/// 
		/// 'right' 鼠标右键
		/// 
		/// 
		/// 注意：如果设置为鼠标右键则会阻止默认的右键菜单。
		/// </summary>
		[JsonProperty("rotateMouseButton")]
		public string RotateMouseButton { get; set; }

		/// <summary>
		/// 默认视角距离主体的距离，对于 globe 来说是距离地球表面的距离，对于 grid3D 和 geo3D 等其它组件来说是距离中心原点的距离。在 projection 为'perspective'的时候有效。
		/// </summary>
		[JsonProperty("distance")]
		public double? Distance { get; set; }

		/// <summary>
		/// 视角通过鼠标控制能拉近到主体的最小距离。在 projection 为'perspective'的时候有效。
		/// </summary>
		[JsonProperty("minDistance")]
		public double? MinDistance { get; set; }

		/// <summary>
		/// 视角通过鼠标控制能拉远到主体的最大距离。在 projection 为'perspective'的时候有效。
		/// </summary>
		[JsonProperty("maxDistance")]
		public double? MaxDistance { get; set; }

		/// <summary>
		/// 正交投影的大小。在 projection 为'orthographic'的时候有效。
		/// </summary>
		[JsonProperty("orthographicSize")]
		public double? OrthographicSize { get; set; }

		/// <summary>
		/// 正交投影缩放的最大值。在 projection 为'orthographic'的时候有效。
		/// </summary>
		[JsonProperty("maxOrthographicSize")]
		public double? MaxOrthographicSize { get; set; }

		/// <summary>
		/// 正交投影缩放的最小值。在 projection 为'orthographic'的时候有效。
		/// </summary>
		[JsonProperty("minOrthographicSize")]
		public double? MinOrthographicSize { get; set; }

		/// <summary>
		/// 视角绕 x 轴，即上下旋转的角度。配合 beta 可以控制视角的方向。
		/// 如下示意图：
		/// </summary>
		[JsonProperty("alpha")]
		public double? Alpha { get; set; }

		/// <summary>
		/// 视角绕 y 轴，即左右旋转的角度。
		/// </summary>
		[JsonProperty("beta")]
		public double? Beta { get; set; }

		/// <summary>
		/// 视角中心点，旋转也会围绕这个中心点旋转，默认为[0,0,0]。
		/// </summary>
		[JsonProperty("center")]
		public double[] Center { get; set; }

		/// <summary>
		/// 上下旋转的最小 alpha 值。即视角能旋转到达最上面的角度。
		/// </summary>
		[JsonProperty("minAlpha")]
		public double? MinAlpha { get; set; }

		/// <summary>
		/// 上下旋转的最大 alpha 值。即视角能旋转到达最下面的角度。
		/// </summary>
		[JsonProperty("maxAlpha")]
		public double? MaxAlpha { get; set; }

		/// <summary>
		/// 左右旋转的最小 beta 值。即视角能旋转到达最左的角度。
		/// </summary>
		[JsonProperty("minBeta")]
		public object MinBeta { get; set; }

		/// <summary>
		/// 左右旋转的最大 beta 值。即视角能旋转到达最右的角度。
		/// </summary>
		[JsonProperty("maxBeta")]
		public object MaxBeta { get; set; }

		/// <summary>
		/// 是否开启动画。
		/// </summary>
		[JsonProperty("animation")]
		public bool? Animation { get; set; }

		/// <summary>
		/// 过渡动画的时长。
		/// </summary>
		[JsonProperty("animationDurationUpdate")]
		public double? AnimationDurationUpdate { get; set; }

		/// <summary>
		/// 过渡动画的缓动效果。
		/// </summary>
		[JsonProperty("animationEasingUpdate")]
		public string AnimationEasingUpdate { get; set; }

		/// <summary>
		/// 定位目标的经纬度坐标。设置后会忽略 alpha 和 beta。
		/// viewControl: {
		///     // 定位到北京
		///     targetCoord: [116.46, 39.92]
		/// }
		/// </summary>
		[JsonProperty("targetCoord")]
		public double[] TargetCoord { get; set; }
	}
}