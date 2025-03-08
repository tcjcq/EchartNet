using Newtonsoft.Json;

namespace Echarts;

/// <summary>
///     关键帧动画配置。支持配置为数组同时使用多个关键帧动画。
///     示例：
///     keyframeAnimation: [{
///     // 呼吸效果的缩放动画
///     duration: 1000,
///     loop: true,
///     keyframes: [{
///     percent: 0.5,
///     easing: 'sinusoidalInOut',
///     scaleX: 0.1,
///     scaleY: 0.1
///     }, {
///     percent: 1,
///     easing: 'sinusoidalInOut',
///     scaleX: 1,
///     scaleY: 1
///     }]
///     }, {
///     // 平移动画
///     duration: 2000,
///     loop: true,
///     keyframes: [{
///     percent: 0,
///     x: 10
///     }, {
///     percent: 1,
///     x: 100
///     }]
///     }]
///     假如一个属性同时被应用了关键帧动画和过渡动画，过渡动画会被忽略。
/// </summary>
public class KeyframeAnimation0
{
	/// <summary>
	///     动画时长，单位 ms
	/// </summary>
	[JsonProperty("duration")]
	public double? Duration { get; set; }

	/// <summary>
	///     动画缓动。不同的缓动效果可以参考 缓动示例。
	/// </summary>
	[JsonProperty("easing")]
	public string Easing { get; set; }

	/// <summary>
	///     动画延迟时长，单位 ms
	/// </summary>
	[JsonProperty("delay")]
	public double? Delay { get; set; }

	/// <summary>
	///     是否循环播放动画。
	/// </summary>
	[JsonProperty("loop")]
	public bool? Loop { get; set; }

	/// <summary>
	///     动画的关键帧。数组中每一项为一个关键帧，格式如下：
	///     interface Keyframe {
	///     // 关键帧位置。0 为第一帧，1 为最后一帧
	///     // 关键帧时间为 percent * duration + delay
	///     percent: number
	///     // 上一个关键帧到这个关键帧运行时的缓动函数。可选
	///     easing?: number
	///     // 其它属性为图形在这个关键帧的属性，例如 x, y, style, shape 等
	///     }
	/// </summary>
	[JsonProperty("keyframes")]
	public double[] Keyframes { get; set; }
}