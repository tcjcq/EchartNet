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


namespace FxEchartHtml
{
	public class DemoInfo
	{
		public string Title { get; set; }
		public List<string> Categories { get; set; } = new List<string>();
		public string TitleCn { get; set; }
		public int Difficulty { get; set; }
		public int VideoStart { get; set; }
		public int VideoEnd { get; set; }
		public string FilePath { get; set; } // 文件路径属性


		public static void ShowDemo(WebView2 view, string optionStrings, Form form, bool darkmode = false)
		{
			view.Show();
			var path = AppDomain.CurrentDomain.BaseDirectory;
			var s = File.ReadAllText($"{path}\\html\\demo.html");
			s = s.Replace("/*====*/", optionStrings);
			if (darkmode)
			{
				s = s.Replace(" var myChart = echarts.init(dom, null, {", " var myChart = echarts.init(dom, 'dark', {");

			}
			var path1 = $"{path}\\html\\demo1.html";
			File.WriteAllText($"{path1}", s);

			var url = $"file:///{HttpUtility.UrlEncode($"{path1.Replace("\\", "/")}")}".Replace("%2f", "/");
			_ = InitializeWebViewAsync(url, view, form);
		}

		public static void ShowDemo(WebView2 view, ClassInfo currClassInfo, Form form)
		{
			if (currClassInfo?.Example == null || currClassInfo.Example.Count == 0)
			{
				view.Hide();
				return;
			}
			view.Show();
			var optionStrings = currClassInfo.Example[0].Code;
			var path = AppDomain.CurrentDomain.BaseDirectory;
			var s = File.ReadAllText($"{path}\\html\\demo.html");
			s = s.Replace("/*====*/", optionStrings);

			var path1 = $"{path}\\html\\demo1.html";
			File.WriteAllText($"{path1}", s);

			var url = $"file:///{HttpUtility.UrlEncode($"{path1.Replace("\\", "/")}")}".Replace("%2f", "/");
			_ = InitializeWebViewAsync(url, view, form);

		}
		private static async Task InitializeWebViewAsync(string url, WebView2 view, Form form)
		{
			try
			{
				await view.EnsureCoreWebView2Async().ConfigureAwait(false);
				form.Invoke((MethodInvoker)delegate { view.CoreWebView2.Navigate(url); });
				//webView21.ZoomFactor = 0.5;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
		}
		public static DemoInfo ExtractDemoInfoFromFile(string filePath)
		{
			var demoInfo = new DemoInfo();
			string content = File.ReadAllText(filePath);

			// 提取注释部分
			string commentPattern = @"/\*([^*]|\*(?!/))*\*/";
			var commentMatch = Regex.Match(content, commentPattern, RegexOptions.Singleline);
			if (!commentMatch.Success)
			{
				Debug.WriteLine("No comment block found.");
				return demoInfo;
			}

			// 获取注释块内容并按行分割
			var commentBlock = commentMatch.Value;
			var lines = commentBlock.Substring(2, commentBlock.Length - 4).Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

			foreach (var r in lines)
			{
				// 去除行首和行尾的空白字符
				var line = r.Trim();

				// 解析键值对
				var keyValueParts = line.Split(new[] { ':' }, 2);
				if (keyValueParts.Length == 2)
				{
					var key = keyValueParts[0].Trim().ToLower();
					var value = keyValueParts[1].Trim().Trim(new char[] { '"', '\'' });

					// 根据键名赋值
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
		// 静态方法，用于从文件夹中获取全部文件的信息
		public static List<DemoInfo> ExtractDemoInfoFromFolder(string folderPath)
		{
			var demoInfoList = new List<DemoInfo>();

			// 获取文件夹中所有文件
			var files = Directory.GetFiles(folderPath);
			foreach (var filePath in files)
			{
				var demoInfo = ExtractDemoInfoFromFile(filePath);
				if (!string.IsNullOrWhiteSpace(demoInfo.Title) ||
					demoInfo.Categories != null ||
					!string.IsNullOrWhiteSpace(demoInfo.TitleCn) ||
					demoInfo.Difficulty > 0)
				{
					demoInfoList.Add(demoInfo);
				}
			}

			return demoInfoList;
		}
	}

	public class TreeViewBuilder
	{
		public static void BuildTreeView(List<DemoInfo> demoInfoList, TreeView treeView)
		{

			foreach (var demoInfo in demoInfoList)
			{
				foreach (var category in demoInfo.Categories)
				{
					if (category == "visualMap")
					{
						Debug.WriteLine("");
					}
					TreeNode categoryNode = treeView.Nodes.Cast<TreeNode>()
						.FirstOrDefault(node => node.Text == category);

					if (categoryNode == null)
					{
						categoryNode = new TreeNode(category)
						{
							Tag = demoInfo.FilePath,
							Name = category,
							Text = category
						};

						var key = string.IsNullOrEmpty(demoInfo.TitleCn) ? demoInfo.Title : demoInfo.TitleCn;

						var node = new TreeNode()
						{
							Tag = demoInfo.FilePath,
							Name = key,
							Text = key
						};
						categoryNode.Nodes.Add(node);
						treeView.Nodes.Add(categoryNode);
					}
					else if (!categoryNode.Tag.Equals(demoInfo.FilePath))
					{
						var key = string.IsNullOrEmpty(demoInfo.TitleCn) ? demoInfo.Title : demoInfo.TitleCn;
						var titleNode = new TreeNode()
						{
							Tag = demoInfo.FilePath,
							Name = key,
							Text = key
						};
						var a = categoryNode.Nodes.Find(titleNode.Text, true);
						if (a.Length == 0)
						{
							categoryNode.Nodes.Add(titleNode);

						}
						else
						{
							Debug.WriteLine("");
						}
					}
				}
			}

			treeView.ShowLines = true;
			treeView.ShowPlusMinus = true;
			treeView.FullRowSelect = true;

			return;
		}
	}
}