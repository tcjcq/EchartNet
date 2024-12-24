using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 图形样式。
	/// </summary>
	public class ItemStyle4
	{
		/// <summary>
		/// 柱条的颜色。 默认从全局调色盘 option.color 获取颜色。  
		/// 
		/// 支持使用rgb(255,255,255)，rgba(255,255,255,1)，#fff等方式设置为纯色，也支持设置为渐变色和纹理填充，具体见option.color
		/// 
		/// 支持使用回调函数。回调函数格式如下：
		/// (params: Object) => Color
		/// 
		/// 传入的是数据项 seriesIndex, dataIndex, data, value 等各个参数。
		/// </summary>
		[JsonProperty("color")]
		public Color Color { get; set; }

		/// <summary>
		/// 柱条的描边颜色。
		/// </summary>
		[JsonProperty("borderColor")]
		public Color BorderColor { get; set; }

		/// <summary>
		/// 柱条的描边宽度，默认不描边。
		/// </summary>
		[JsonProperty("borderWidth")]
		public double? BorderWidth { get; set; }

		/// <summary>
		/// 柱条的描边类型，默认为实线，支持 'dashed', 'dotted'。
		/// </summary>
		[JsonProperty("borderType")]
		public string BorderType { get; set; }

		/// <summary>
		/// 圆角半径，单位px，支持传入数组分别指定 4 个圆角半径。
		/// 如:
		/// borderRadius: 5, // 统一设置四个角的圆角大小
		/// borderRadius: [5, 5, 0, 0] //（顺时针左上，右上，右下，左下）
		/// </summary>
		[JsonProperty("borderRadius")]
		public ArrayOrSingle BorderRadius { get; set; }

		/// <summary>
		/// 图形阴影的模糊大小。该属性配合 shadowColor,shadowOffsetX, shadowOffsetY 一起设置图形的阴影效果。
		/// 示例：
		/// {
		///     shadowColor: 'rgba(0, 0, 0, 0.5)',
		///     shadowBlur: 10
		/// }
		/// </summary>
		[JsonProperty("shadowBlur")]
		public double? ShadowBlur { get; set; }

		/// <summary>
		/// 阴影颜色。支持的格式同color。
		/// </summary>
		[JsonProperty("shadowColor")]
		public Color ShadowColor { get; set; }

		/// <summary>
		/// 阴影水平方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetX")]
		public double? ShadowOffsetX { get; set; }

		/// <summary>
		/// 阴影垂直方向上的偏移距离。
		/// </summary>
		[JsonProperty("shadowOffsetY")]
		public double? ShadowOffsetY { get; set; }

		/// <summary>
		/// 图形透明度。支持从 0 到 1 的数字，为 0 时不绘制该图形。
		/// </summary>
		[JsonProperty("opacity")]
		public double? Opacity { get; set; }

		/// <summary>
		/// 图形的贴花图案，在 aria.enabled 与 aria.decal.show 都是 true 的情况下才生效。
		/// 如果为 'none' 表示不使用贴花图案。
		/// </summary>
		[JsonProperty("decal")]
		public Decal0 Decal { get; set; }
	}
}