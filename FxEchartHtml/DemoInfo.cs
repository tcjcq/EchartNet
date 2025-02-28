using Microsoft.Web.WebView2.WinForms;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FxEchartHtml
{
	/// <summary>
	/// 表示一个演示示例（Demo）的元信息，如标题、分类、难度、视频时间段、文件路径等。
	/// </summary>
	public class DemoInfo
	{
		/// <summary>
		/// 演示示例的标题（英文）。
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 演示示例所属分类列表。
		/// </summary>
		public List<string> Categories { get; set; } = new List<string>();

		/// <summary>
		/// 演示示例的中文标题（可选）。
		/// </summary>
		public string TitleCn { get; set; }

		/// <summary>
		/// 演示示例的难度等级（可能为1-5或其他范围）。
		/// </summary>
		public int Difficulty { get; set; }

		/// <summary>
		/// 演示示例相关视频的起始时间（秒）。
		/// </summary>
		public int VideoStart { get; set; }

		/// <summary>
		/// 演示示例相关视频的结束时间（秒）。
		/// </summary>
		public int VideoEnd { get; set; }

		/// <summary>
		/// 该示例对应的文件路径。
		/// </summary>
		public string FilePath { get; set; }

		
		/// <summary>
		/// 在 WebView2 控件中展示指定的 ECharts 配置项。
		/// </summary>
		/// <param name="view">WebView2 控件实例。</param>
		/// <param name="optionStrings">ECharts 配置项字符串。</param>
		/// <param name="form">承载 WebView2 的窗体。</param>
		/// <param name="darkmode">是否启用 dark 主题。</param>
		public static void ShowDemo(WebView2 view, string optionStrings, Form form, bool darkmode = false)
		{
			if (view == null || form == null)
			{
				Debug.WriteLine("View 或 Form 为 null，无法显示Demo。");
				return;
			}

			view.Show();
			var basePath = AppDomain.CurrentDomain.BaseDirectory;

			// 读取示例 HTML 模板文件
			var templatePath = Path.Combine(basePath, "html", "demo.html");
			var htmlContent = File.ReadAllText(templatePath);

			// 替换占位符为实际的 ECharts 配置项
			htmlContent = htmlContent.Replace("/*====*/", optionStrings);
			if (darkmode)
			{
				// 替换主题为 dark
				htmlContent = htmlContent.Replace(
					" var myChart = echarts.init(dom, null, {",
					" var myChart = echarts.init(dom, 'dark', {");
			}

			// 将生成的 HTML 写入 demo1.html，用于 WebView2 显示
			var demoPath = Path.Combine(basePath, "html", "demo1.html");
			File.WriteAllText(demoPath, htmlContent);

			// 转换路径为 WebView2 可用的 URL
			var url = $"file:///{HttpUtility.UrlEncode(demoPath.Replace("\\", "/"))}".Replace("%2f", "/");
			_ = InitializeWebViewAsync(url, view, form);
		}

		/// <summary>
		/// 根据当前类信息（ClassInfo）显示其示例的 ECharts 配置项。
		/// 如果不存在示例则隐藏 WebView2。
		/// </summary>
		/// <param name="view">WebView2 控件实例。</param>
		/// <param name="currClassInfo">包含当前类信息和示例代码的对象。</param>
		/// <param name="form">承载 WebView2 的窗体。</param>
		public static void ShowDemo(WebView2 view, ClassInfo currClassInfo, Form form)
		{
			if (view == null || form == null)
			{
				Debug.WriteLine("View 或 Form 为 null，无法显示Demo。");
				return;
			}

			if (currClassInfo?.Example == null || currClassInfo.Example.Count == 0)
			{
				view.Hide();
				return;
			}

			view.Show();
			var optionStrings = currClassInfo.Example[0].Code;
			var basePath = AppDomain.CurrentDomain.BaseDirectory;

			var templatePath = Path.Combine(basePath, "html", "demo.html");
			var htmlContent = File.ReadAllText(templatePath);
			htmlContent = htmlContent.Replace("/*====*/", optionStrings);

			var demoPath = Path.Combine(basePath, "html", "demo1.html");
			File.WriteAllText(demoPath, htmlContent);

			var url = $"file:///{HttpUtility.UrlEncode(demoPath.Replace("\\", "/"))}".Replace("%2f", "/");
			_ = InitializeWebViewAsync(url, view, form);
		}

		/// <summary>
		/// 异步初始化 WebView2 控件并导航到指定 URL。
		/// </summary>
		/// <param name="url">要导航到的 URL。</param>
		/// <param name="view">WebView2 控件实例。</param>
		/// <param name="form">承载 WebView2 的窗体。</param>
		private static async Task InitializeWebViewAsync(string url, WebView2 view, Form form)
		{
			try
			{
				await view.EnsureCoreWebView2Async().ConfigureAwait(false);
				form.Invoke((MethodInvoker)delegate
				{
					view.CoreWebView2.Navigate(url);
				});
			}
			catch (Exception e)
			{
				Debug.WriteLine($"初始化 WebView 失败：{e.Message}");
			}
		}

		/// <summary>
		/// 从指定文件中提取 DemoInfo 信息，包括注释中标注的 title、category、titlecn、difficulty、videostart、videoend 等。
		/// </summary>
		/// <param name="filePath">文件路径。</param>
		/// <returns>提取到的 DemoInfo 对象。</returns>
		public static DemoInfo ExtractDemoInfoFromFile(string filePath)
		{
			var demoInfo = new DemoInfo();
			if (!File.Exists(filePath))
			{
				Debug.WriteLine($"文件不存在：{filePath}");
				return demoInfo;
			}

			string content = File.ReadAllText(filePath);

			// 正则匹配注释块： /* ... */
			string commentPattern = @"/\*([^*]|\*(?!/))*\*/";
			var commentMatch = Regex.Match(content, commentPattern, RegexOptions.Singleline);
			if (!commentMatch.Success)
			{
				Debug.WriteLine("未找到注释块。");
				return demoInfo;
			}

			// 提取注释块内容（去掉 /* 和 */）
			var commentBlock = commentMatch.Value;
			var lines = commentBlock.Substring(2, commentBlock.Length - 4)
									.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

			foreach (var rawLine in lines)
			{
				var line = rawLine.Trim();
				if (string.IsNullOrEmpty(line)) continue;

				// 按第一个冒号分割
				var keyValueParts = line.Split(new[] { ':' }, 2);
				if (keyValueParts.Length == 2)
				{
					var key = keyValueParts[0].Trim().ToLower();
					var value = keyValueParts[1].Trim().Trim(new char[] { '"', '\'' });

					// 根据键赋值
					switch (key)
					{
						case "title":
							demoInfo.Title = value;
							break;
						case "category":
							demoInfo.Categories.AddRange(value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()));
							break;
						case "titlecn":
							demoInfo.TitleCn = value;
							break;
						case "difficulty":
							if (int.TryParse(value, out int difficulty))
								demoInfo.Difficulty = difficulty;
							break;
						case "videostart":
							if (int.TryParse(value, out int videoStart))
								demoInfo.VideoStart = videoStart;
							break;
						case "videoend":
							if (int.TryParse(value, out int videoEnd))
								demoInfo.VideoEnd = videoEnd;
							break;
					}
				}
			}

			demoInfo.FilePath = filePath;
			return demoInfo;
		}

		/// <summary>
		/// 从指定文件夹中提取所有文件的 DemoInfo 信息。
		/// 仅当文件中包含有效信息（标题、分类、标题中文或难度）时才加入列表中。
		/// </summary>
		/// <param name="folderPath">文件夹路径。</param>
		/// <returns>包含 DemoInfo 对象的列表。</returns>
		public static List<DemoInfo> ExtractDemoInfoFromFolder(string folderPath)
		{
			var demoInfoList = new List<DemoInfo>();

			if (!Directory.Exists(folderPath))
			{
				Debug.WriteLine($"文件夹不存在：{folderPath}");
				return demoInfoList;
			}

			// 获取文件夹中所有文件
			var files = Directory.GetFiles(folderPath);
			foreach (var filePath in files)
			{
				var demoInfo = ExtractDemoInfoFromFile(filePath);
				// 若包含有效信息才添加
				bool hasValidInfo = !(string.IsNullOrWhiteSpace(demoInfo.Title)
									&& (demoInfo.Categories == null || demoInfo.Categories.Count <= 0)
									&& string.IsNullOrWhiteSpace(demoInfo.TitleCn)
									&& demoInfo.Difficulty <= 0);
				if (hasValidInfo)
				{
					demoInfoList.Add(demoInfo);
				}
			}

			return demoInfoList;
		}
	}
}
