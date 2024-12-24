using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 真实感材质相关的配置项，在 shading 为'realistic'时有效。
	/// </summary>
	public class Globe_RealisticMaterial
	{
		/// <summary>
		/// 材质细节的纹理贴图。
		/// </summary>
		[JsonProperty("detailTexture")]
		public string DetailTexture { get; set; }

		/// <summary>
		/// 材质细节纹理的平铺。默认为1，也就是拉伸填满。大于 1 的时候，数字表示纹理平铺重复的次数。
		/// 注： 使用平铺需要 detailTexture 的高宽是 2 的 n 次方。例如 512x512，如果是 200x200 的纹理无法使用平铺。
		/// </summary>
		[JsonProperty("textureTiling")]
		public double? TextureTiling { get; set; }

		/// <summary>
		/// 材质细节纹理的位移。
		/// </summary>
		[JsonProperty("textureOffset")]
		public double? TextureOffset { get; set; }

		/// <summary>
		/// roughness属性用于表示材质的粗糙度，0为完全光滑，1完全粗糙，中间的值则是介于这两者之间。
		/// 下图是 globe 中roughness分别是0.2（光滑）与0.8（粗糙）的效果。
		/// 
		/// 
		/// 当你想要表达更复杂的材质时。你可以直接将 roughness 设置为如下用每个像素存储粗糙度的贴图。
		/// 
		/// 贴图中颜色越白的地方值越大，就越粗糙。你可以从 http://freepbr.com/ 等资源网站获取不同材质的贴图资源，也可以使用其他工具自己生成。
		/// </summary>
		[JsonProperty("roughness")]
		public StringOrNumber Roughness { get; set; }

		/// <summary>
		/// metalness属性用于表示材质是金属还是非金属，0为非金属，1为金属，中间的值则是介于这两者之间。通常设成0和1就能满足大部分场景了。
		/// 下图是 globe 中metalness分别设成1与0的效果区别。
		/// 
		/// 
		/// 跟 roughness 一样 你可以直接将 metalness 设置为金属度贴图。
		/// </summary>
		[JsonProperty("metalness")]
		public StringOrNumber Metalness { get; set; }

		/// <summary>
		/// 粗糙度调整，在使用粗糙度贴图的时候有用。可以对贴图整体的粗糙度进行调整。默认为 0.5，0的时候为完全光滑，1的时候为完全粗糙。
		/// </summary>
		[JsonProperty("roughnessAdjust")]
		public double? RoughnessAdjust { get; set; }

		/// <summary>
		/// 金属度调整，在使用金属度贴图的时候有用。可以对贴图整体的金属度进行调整。默认为 0.5，0的时候为非金属，1的时候为金属。
		/// </summary>
		[JsonProperty("metalnessAdjust")]
		public double? MetalnessAdjust { get; set; }

		/// <summary>
		/// 材质细节的法线贴图。
		/// 使用法线贴图可以在较少的顶点下依然表现出物体表面丰富的明暗细节。
		/// </summary>
		[JsonProperty("normalTexture")]
		public string NormalTexture { get; set; }
	}
}