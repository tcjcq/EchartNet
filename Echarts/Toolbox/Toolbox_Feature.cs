using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	/// 各工具配置项。
	/// 除了各个内置的工具按钮外，还可以自定义工具按钮。
	/// 注意，自定义的工具名字，只能以 my 开头，例如下例中的 myTool1，myTool2：
	/// {
	///     toolbox: {
	///         feature: {
	///             myTool1: {
	///                 show: true,
	///                 title: '自定义扩展方法1',
	///                 icon: 'path://M432.45,595.444c0,2.177-4.661,6.82-11.305,6.82c-6.475,0-11.306-4.567-11.306-6.82s4.852-6.812,11.306-6.812C427.841,588.632,432.452,593.191,432.45,595.444L432.45,595.444z M421.155,589.876c-3.009,0-5.448,2.495-5.448,5.572s2.439,5.572,5.448,5.572c3.01,0,5.449-2.495,5.449-5.572C426.604,592.371,424.165,589.876,421.155,589.876L421.155,589.876z M421.146,591.891c-1.916,0-3.47,1.589-3.47,3.549c0,1.959,1.554,3.548,3.47,3.548s3.469-1.589,3.469-3.548C424.614,593.479,423.062,591.891,421.146,591.891L421.146,591.891zM421.146,591.891',
	///                 onclick: function (){
	///                     alert('myToolHandler1')
	///                 }
	///             },
	///             myTool2: {
	///                 show: true,
	///                 title: '自定义扩展方法',
	///                 icon: 'image://https://echarts.apache.org/zh/images/favicon.png',
	///                 onclick: function (){
	///                     alert('myToolHandler2')
	///                 }
	///             }
	///         }
	///     }
	/// }
	/// </summary>
	public class Toolbox_Feature
	{
		/// <summary>
		/// 保存为图片。
		/// </summary>
		[JsonProperty("saveAsImage")]
		public Toolbox_Feature_SaveAsImage SaveAsImage { get; set; }

		/// <summary>
		/// 配置项还原。
		/// </summary>
		[JsonProperty("restore")]
		public Toolbox_Feature_Restore Restore { get; set; }

		/// <summary>
		/// 数据视图工具，可以展现当前图表所用的数据，编辑后可以动态更新。
		/// </summary>
		[JsonProperty("dataView")]
		public Toolbox_Feature_DataView DataView { get; set; }

		/// <summary>
		/// 数据区域缩放。目前只支持直角坐标系的缩放。
		/// </summary>
		[JsonProperty("dataZoom")]
		public Toolbox_Feature_DataZoom DataZoom { get; set; }

		/// <summary>
		/// 动态类型切换
		/// 示例：
		/// feature: {
		///     magicType: {
		///         type: ['line', 'bar', 'stack']
		///     }
		/// }
		/// </summary>
		[JsonProperty("magicType")]
		public Toolbox_Feature_MagicType MagicType { get; set; }

		/// <summary>
		/// 选框组件的控制按钮。
		/// 也可以不在这里指定，而是在 brush.toolbox 中指定。
		/// </summary>
		[JsonProperty("brush")]
		public Toolbox_Feature_Brush Brush { get; set; }
	}
}