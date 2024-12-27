using Newtonsoft.Json;

namespace Echarts
{
	/// <summary>
	///     数据视图工具，可以展现当前图表所用的数据，编辑后可以动态更新。
	/// </summary>
	public class Toolbox_Feature_DataView
	{
		/// <summary>
		///     是否显示该工具。
		/// </summary>
		[JsonProperty("show")]
		public bool? Show { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		///     可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
		///     URL 为图片链接例如：
		///     'image://http://example.website/a/b.png'
		///     URL 为 dataURI 例如：
		///     'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7'
		///     可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。路径图形会自适应调整为合适的大小。路径的格式参见 SVG PathData。可以从
		///     Adobe Illustrator 等工具编辑导出。
		///     例如：
		///     'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z
		///     M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z
		///     M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z
		///     M27.8,35.8
		///     c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		///     数据视图 icon 样式设置。由于 icon 的文本信息只在 icon hover 时候才显示，所以文字相关的配置项请在 emphasis 下设置。
		/// </summary>
		[JsonProperty("iconStyle")]
		public HandleStyle0 IconStyle { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty("emphasis")]
		public Toolbox_Emphasis Emphasis { get; set; }

		/// <summary>
		///     是否不可编辑（只读）。
		/// </summary>
		[JsonProperty("readOnly")]
		public bool? ReadOnly { get; set; }

		/// <summary>
		///     (option:Object) => HTMLDomElement|string
		///     自定义 dataView 展现函数，用以取代默认的 textarea 使用更丰富的数据编辑。可以返回 dom 对象或者 html 字符串。
		///     如下示例使用表格展现数据值：
		///     optionToContent: function(opt) {
		///     var axisData = opt.xAxis[0].data;
		///     var series = opt.series;
		///     var table = '
		///     <table style="width:100%;text-align:center">
		///         <tbody>
		///             <tr>
		///                 '
		///                 + '<td>时间</td>'
		///                 + '<td>' + series[0].name + '</td>'
		///                 + '<td>' + series[1].name + '</td>'
		///                 + '
		///             </tr>
		///             ';
		///             for (var i = 0, l = axisData.length; i
		///             < l; i++) {
		///                 table +='
		///             <tr>
		///                 '
		///                 + '<td>' + axisData[i] + '</td>'
		///                 + '<td>' + series[0].data[i] + '</td>'
		///                 + '<td>' + series[1].data[i] + '</td>'
		///                 + '
		///             </tr>
		///             ';
		///             }
		///             table += '
		///         </tbody>
		///     </table>
		///     ';
		///     return table;
		///     }
		/// </summary>
		[JsonProperty("optionToContent")]
		public string OptionToContent { get; set; }

		/// <summary>
		///     (container:HTMLDomElement, option:Object) => Object
		///     在使用 optionToContent 的情况下，如果支持数据编辑后的刷新，需要自行通过该函数实现组装 option 的逻辑。
		/// </summary>
		[JsonProperty("contentToOption")]
		public string ContentToOption { get; set; }

		/// <summary>
		///     数据视图上有三个话术，默认是['数据视图', '关闭', '刷新']。
		/// </summary>
		[JsonProperty("lang")]
		public double[] Lang { get; set; }

		/// <summary>
		///     数据视图浮层背景色。
		/// </summary>
		[JsonProperty("backgroundColor")]
		public string BackgroundColor { get; set; }

		/// <summary>
		///     数据视图浮层文本输入区背景色。
		/// </summary>
		[JsonProperty("textareaColor")]
		public string TextareaColor { get; set; }

		/// <summary>
		///     数据视图浮层文本输入区边框颜色。
		/// </summary>
		[JsonProperty("textareaBorderColor")]
		public string TextareaBorderColor { get; set; }

		/// <summary>
		///     文本颜色。
		/// </summary>
		[JsonProperty("textColor")]
		public string TextColor { get; set; }

		/// <summary>
		///     按钮颜色。
		/// </summary>
		[JsonProperty("buttonColor")]
		public string ButtonColor { get; set; }

		/// <summary>
		///     按钮文本颜色。
		/// </summary>
		[JsonProperty("buttonTextColor")]
		public string ButtonTextColor { get; set; }
	}
}