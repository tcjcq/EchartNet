using HtmlAgilityPack;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace FxEchartHtml
{
	public class HtmlParser
	{
		/// <summary>
		/// 解析HTML文件并输出指定元素的信息。
		/// </summary>
		/// <param name="filePath">HTML文件的路径</param>
		/// <param name="query">XPath查询字符串，用于选择需要解析的元素</param>
		public static void ParseHtmlFile(string filePath, string query)
		{
			// 检查文件是否存在
			if (!File.Exists(filePath))
			{
				Debug.WriteLine("The file does not exist.");
				return;
			}

			// 读取HTML文件内容
			string htmlContent = File.ReadAllText(filePath);

			// 使用Html Agility Pack解析HTML
			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(htmlContent);

			// 使用XPath查询HTML元素
			//var nodes = doc.DocumentNode.SelectNodes(query);
			var nodes = doc.DocumentNode.SelectNodes("//div[@class='example-langs']");
			if (nodes != null)
			{
				Debug.WriteLine("Found elements:");
				foreach (var node in nodes)
				{
					Debug.WriteLine("Element found:");
					Debug.WriteLine($"- Inner HTML: {node.InnerHtml}");
					Debug.WriteLine($"- Outer HTML: {node.OuterHtml}");
					Debug.WriteLine("- Attributes:");
					foreach (var attribute in node.Attributes)
					{
						Console.WriteLine($"  {attribute.Name} = {attribute.Value}");
					}
					Console.WriteLine();
				}
			}
			else
			{
				Console.WriteLine("No elements found matching the query.");
			}
		}

		/// <summary>
		/// 解析HTML文件并提取所有class为"js"且文本为"JS"的<a>标签的href属性。
		/// </summary>
		/// <param name="filePath">HTML文件的路径</param>
		/// <returns>一个包含所有匹配的<a>标签href属性的列表</returns>
		public static List<string> ExtractJsLinks(string filePath)
		{
			// 检查文件是否存在
			if (!File.Exists(filePath))
			{
				Console.WriteLine("The file does not exist.");
				return new List<string>();
			}

			// 读取HTML文件内容
			string htmlContent = File.ReadAllText(filePath);

			// 使用Html Agility Pack解析HTML
			var doc = new HtmlDocument();
			doc.LoadHtml(htmlContent);

			// 使用XPath查询class为"js"且文本为"JS"的<a>标签
			var nodes = doc.DocumentNode.SelectNodes("//a[@class='js' and text()='JS']");

			// 存储提取的href属性
			var jsLinks = new List<string>();

			if (nodes != null)
			{
				foreach (var node in nodes)
				{
					// 获取href属性
					var hrefValue = node.GetAttributeValue("href", string.Empty);
					jsLinks.Add(hrefValue);
				}
			}

			return jsLinks;
		}

		private static int n = 1;
		public static async Task GetJson(string url)
		{
			var u1 = url.Split('=')[1];
			url = $"https://echarts.apache.org/examples/examples/js/{u1}.js?_v_1731142123267";
			if (u1.Contains(";gl"))
			{
				url = $"https://echarts.apache.org/examples/examples/js/gl/{u1.Replace(";gl", "")}.js?_v_1731142123267";

			}
			var a = new WebContentFetcher();
			var content = await a.GetWebContentAsync(url);
			if (content != null)
			{
				var fn = $".\\example\\{u1.Replace("-", "_").Replace(";gl", "")}.js";
				if (File.Exists(fn))
				{
					Debug.WriteLine($"{fn} exist");
					fn = $".\\example\\{u1.Replace("-", "_").Replace(";gl", "")}{n++}.js";
				}
				Debug.WriteLine($"{u1} Ok");
				File.WriteAllText(fn, content);
			}
		}
		public static Task GetDemoJs()
		{
			// 指定HTML文件的路径和XPath查询
			string filePath = ".\\html\\example.html";
			//string query = "/html/body[@class='pace-done ']/div[@id='main']/div[@class='page-main']/div[@id='ec-example-main']/div[@id='example-explore']/div[@id='explore-container']/div[@class='example-list-panel']/div";

			// 调用方法
			var ls = ExtractJsLinks(filePath);
			//ParseHtmlFile(filePath, query);
			n = 1;
			foreach (var r in ls)
			{
				_ = GetJson(r.Replace("&amp", ""));
			}

			return Task.CompletedTask;
		}
	}
}