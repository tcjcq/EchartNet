using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 颜色纠正和调整。类似 Photoshop 中的 Color Adjustments。
	/// 下图同个场景调整为冷色系和暖色系的区别。
	/// </summary>
	public class Globe_PostEffect_ColorCorrection
	{
		/// <summary>
		/// 是否开启颜色纠正。
		/// </summary>
		[JsonProperty("enable")]
		public bool? Enable { get; set; }

		/// <summary>
		/// 颜色查找表，推荐使用。
		/// 颜色查找表是一张像下面这样的纹理图片。
		/// 
		/// 这张是基础的查找表图片，你可以直接拿来使用，为了方便将场景色调调整你想要的效果，你可以将场景截图后在 Photoshop 等图像处理软件中调整颜色到想要的效果，然后将相同的调整应用到上面这张查找表的图片上。
		/// 比如调成冷色调后，查找表的纹理图片就会成为下面这样：
		/// 
		/// 然后那这张纹理图片就作为该配置项的值，就可以得到相同的在 Photoshop 里调整好的效果了。
		/// 当然如果你只是想得到一张截图，完全可以不这样操作，但是如果你想在可以实时交互的作品中能方便的调整到理想的色调，这个就非常有用了。
		/// </summary>
		[JsonProperty("lookupTexture")]
		public string LookupTexture { get; set; }

		/// <summary>
		/// 画面的曝光。
		/// </summary>
		[JsonProperty("exposure")]
		public double? Exposure { get; set; }

		/// <summary>
		/// 画面的亮度。
		/// </summary>
		[JsonProperty("brightness")]
		public double? Brightness { get; set; }

		/// <summary>
		/// 画面的对比度。
		/// </summary>
		[JsonProperty("contrast")]
		public double? Contrast { get; set; }

		/// <summary>
		/// 画面的饱和度。
		/// </summary>
		[JsonProperty("saturation")]
		public double? Saturation { get; set; }
	}
}