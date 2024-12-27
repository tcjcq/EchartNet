using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     lambert 材质相关的配置项，在 shading 为'lambert'时有效。
	/// </summary>
	public class Globe_LambertMaterial
	{
		/// <summary>
		///     材质细节的纹理贴图。
		/// </summary>
		[JsonProperty("detailTexture")]
		public string DetailTexture { get; set; }

		/// <summary>
		///     材质细节纹理的平铺。默认为1，也就是拉伸填满。大于 1 的时候，数字表示纹理平铺重复的次数。
		///     注： 使用平铺需要 detailTexture 的高宽是 2 的 n 次方。例如 512x512，如果是 200x200 的纹理无法使用平铺。
		/// </summary>
		[JsonProperty("textureTiling")]
		public double? TextureTiling { get; set; }

		/// <summary>
		///     材质细节纹理的位移。
		/// </summary>
		[JsonProperty("textureOffset")]
		public double? TextureOffset { get; set; }
	}
}