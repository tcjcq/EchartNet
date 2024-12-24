using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 
	/// </summary>
	public class SeriesCustom_RenderItem_ReturnPath
	{
		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } = "path";

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("x")]
		public double? X { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("y")]
		public double? Y { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("rotation")]
		public double? Rotation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleX")]
		public double? ScaleX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("scaleY")]
		public double? ScaleY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originX")]
		public double? OriginX { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("originY")]
		public double? OriginY { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("transition")]
		public ArrayOrSingle Transition { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterFrom")]
		public object EnterFrom { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveTo")]
		public object LeaveTo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("enterAnimation")]
		public EnterAnimation0 EnterAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("updateAnimation")]
		public EnterAnimation0 UpdateAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("leaveAnimation")]
		public EnterAnimation0 LeaveAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("keyframeAnimation")]
		public KeyframeAnimation0 KeyframeAnimation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("morph")]
		public bool? Morph { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("z2")]
		public double? Z2 { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("info")]
		public string Info { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("silent")]
		public bool? Silent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("invisible")]
		public bool? Invisible { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("ignore")]
		public bool? Ignore { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textContent")]
		public object TextContent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("textConfig")]
		public TextConfig0 TextConfig { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("during")]
		public string During { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("extra")]
		public Extra0 Extra { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("shape")]
		public SeriesCustom_RenderItem_ReturnPath_Shape Shape { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("style")]
		public Style2 Style { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("focus")]
		public string Focus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blurScope")]
		public string BlurScope { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasisDisabled")]
		public bool? EmphasisDisabled { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("emphasis")]
		public Emphasis10 Emphasis { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("blur")]
		public Emphasis10 Blur { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("select")]
		public Emphasis10 Select { get; set; }
	}
}