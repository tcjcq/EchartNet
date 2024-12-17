using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace FxEchartHtml
{
	public partial class Form1 : Form
	{
		private Dictionary<string, ClassInfo> _classInfoCache;
		private Dictionary<string, string> _classToFileMap;
		private const string JsonDirectory = ".\\json\\";

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_LoadAsync(object sender, EventArgs e)
		{
			InitializeClassInfoManager(JsonDirectory);
			InitView();
			var prefixes = new[] { "http://localhost:8088/" };
			var server = new SimpleHttpServer(prefixes);
			server.RequestReceived += SimpleHttpServer.CustomRequestHandler;
			SimpleHttpServer.RootPath = "https://echarts.apache.org/examples";
			server.Start();
		}

		/// <summary>
		/// 初始化视图结构，比如加载 TreeView。
		/// </summary>
		private void InitView()
		{
			var option = ParseEchartJs.GetOptinPropTypes();
			if (option == null) return;
			BuildRootTreeViewNodes(treeView1, option);
		}

		/// <summary>
		/// 构建TreeView的根节点列表
		/// </summary>
		private static void BuildRootTreeViewNodes(TreeView treeView, Option options)
		{
			treeView.Nodes.Clear();
			foreach (var opt in options.Children)
			{
				var node = CreateTreeNode(opt, null);
				if (opt.Children != null && opt.Children.Count > 0)
				{
					BuildChildTreeViewNodes(opt, node);
				}
				treeView.Nodes.Add(node);
			}
		}

		/// <summary>
		/// 构建TreeView的子节点
		/// </summary>
		private static void BuildChildTreeViewNodes(OptionItem options, TreeNode parent)
		{
			foreach (var opt in options.Children)
			{
				var node = CreateTreeNode(opt, parent);
				if (opt.Children != null && opt.Children.Count > 0)
				{
					BuildChildTreeViewNodes(opt, node);
				}
				parent.Nodes.Add(node);
			}
		}

		/// <summary>
		/// 创建单个TreeNode节点，根据OptionItem的属性决定显示方式与Tag。
		/// </summary>
		private static TreeNode CreateTreeNode(OptionItem option, TreeNode pre)
		{
			var nodeText = ParseEchartJs.ToPascalCase(option.Prop ?? option.ArrayItemType);
			var node = new TreeNode(nodeText)
			{
				Tag = option.Prop != null ? Path.Combine(JsonDirectory, $"{option.Prop.Replace("<style_name>", "style_name")}.json") : option.Default
			};
			if (option.Prop != null)
			{
				if (pre != null)
				{
					node.Tag = pre.Tag;
				}

				if (option.IsArray)
				{
					node.Text += @"[]";
				}

				return node;
			}

			switch (nodeText)
			{
				case "Inside":
				case "Slider":
					node.Tag = Path.Combine(JsonDirectory, $"DataZoom{nodeText}.json");
					break;
				case "Continuous":
				case "Piecewise":
					node.Tag = Path.Combine(JsonDirectory, $"VisualMap{nodeText}.json");
					break;
			}

			if (pre != null && pre.Text.Contains("Series[]"))
			{
				node.Tag = Path.Combine(JsonDirectory, $"series{nodeText}.json");
			}
			return node;
		}

		/// <summary>
		/// 点击按钮触发解析任务的示例（根据实际业务需要修改）
		/// </summary>
		private async void ToolStripButton1_Click(object sender, EventArgs e)
		{
			toolStripButton3.Enabled = false;
			await ParseEchartJs.RunParseTask();
			toolStripButton3.Enabled = true;
		}

		/// <summary>
		/// 从JSON文件加载ClassInfo对象
		/// </summary>
		private static ClassInfo LoadClassInfoFromJson(string jsonFilePath)
		{
			if (!File.Exists(jsonFilePath)) return null;
			var json = File.ReadAllText(jsonFilePath);
			return JsonConvert.DeserializeObject<ClassInfo>(json);
		}

		/// <summary>
		/// 当选中TreeView节点时，显示对应类/属性信息，并在WebBrowser中以HTML显示。
		/// </summary>
		private ClassInfo _currClassInfo;
		private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			//textBox1.Clear();
			if (!(e.Node.Tag is string filePath)) return;
			if (filePath.Contains("visualMap.json"))
			{
				var a = _classInfoCache["VisualMap"];
				webBrowser1.DocumentText = a.Description;
				textBox1.Text = "";
			}
			if (filePath.Contains("dataZoom.json"))
			{
				var a = _classInfoCache["DataZoom"];
				webBrowser1.DocumentText = a.Description;
				textBox1.Text = "";
			}

			_currClassInfo = null;
			DemoInfo.ShowDemo(webView21, _currClassInfo, this);
			var classInfo = LoadClassInfoFromJson(filePath);
			if (classInfo == null)
			{
				return;
			}
			classInfo = _classInfoCache[classInfo.ClassName];
			_currClassInfo = classInfo;
			DemoInfo.ShowDemo(webView21, _currClassInfo, this);
			DisplayClassInfoAtTopLevel(classInfo);

			if (e.Node.Level == 0 && classInfo.Description == "") webBrowser1.DocumentText = "";
			if (e.Node.Text == @"Slider" || e.Node.Text == @"Inside")
			{
				DisplayClassInfoAtTopLevel(classInfo);
				return;
			}

			DisplayPropertyInfo(e.Node, classInfo);
		}
		private async void DisplayHtmlString(string html)
		{
			if (webView22.CoreWebView2 != null)
			{
				webView22.CoreWebView2.NavigateToString(html);
			}
			else
			{
				await webView22.EnsureCoreWebView2Async();
				webView22.CoreWebView2?.NavigateToString(html);
			}
		}
		/// <summary>
		/// 顶级类信息显示
		/// </summary>
		private void DisplayClassInfoAtTopLevel(ClassInfo classInfo)
		{
			string info = "";
			var a = $"{classInfo.Description.Replace(SimpleHttpServer.RootPath, "http://localhost:8088")}\n";
			DisplayHtmlString(a);
			webBrowser1.DocumentText = a;
			if (classInfo.Example != null)
				foreach (var r in classInfo.Example)
				{
					info += $"\n{r.Title}\n code:\n {r.Code}\n";
				}

			textBox1.Text = info;
		}

		/// <summary>
		/// 显示多层级下的属性信息
		/// </summary>
		private void DisplayPropertyInfo(TreeNode selectedNode, ClassInfo classInfo)
		{
			var currentLevelProperties = classInfo.Properties;
			var pathSegments = selectedNode.FullPath.Split('\\');

			// 从第1层开始（0层是类本身）递进查找属性层级
			for (var level = 1; level <= selectedNode.Level; level++)
			{
				if (level != selectedNode.Level)
				{
					// 未到达最终层，继续深入
					var segName = pathSegments[level].Replace("[]", "");
					foreach (var prop in currentLevelProperties)
					{
						if (ParseEchartJs.ToPascalCase(prop.PropertyName) != segName) continue;
						// 特殊处理 rich，否则尝试从缓存中获取对应类
						var classKey = prop.PropertyName == "rich" ? "Rich0" : prop.PropertyType.Replace("[]", "");
						if (_classInfoCache.TryGetValue(classKey, out var subClassInfo))
						{
							classInfo = subClassInfo;
							currentLevelProperties = subClassInfo.Properties;
						}
						break;
					}
					continue;
				}

				// 到达选中节点层，显示属性信息
				var nodeText = selectedNode.Text.Replace("[]", "");
				foreach (var property in currentLevelProperties)
				{
					if (ParseEchartJs.ToPascalCase(property.PropertyName) != nodeText) continue;
					// 构建文本信息
					var info =
						$"Class Name: <a>{classInfo.NewClassName}</a>\nProperty Name:  <a>{property.PropertyName.Replace("[]", "")}</a>\nProperty Type:  <a>{HttpUtility.HtmlEncode(property.PropertyType)}</a>\n";

					if (!string.IsNullOrEmpty(property.PropertyDescription))
					{
						info += $"Description: <br><br>{property.PropertyDescription.Replace("\n", "<br>").Trim('\r', '\n')}";
					}

					//textBox1.Text = info;
					var htmlContent = BuildHtmlContent(info);
					webBrowser1.DocumentText = htmlContent;
					return;
				}
			}
		}

		/// <summary>
		/// 构建需要在WebBrowser中显示的HTML内容
		/// </summary>
		private string BuildHtmlContent(string info)
		{
			var htmlTemplate = @"
<html>
<head>
<style>
p {
    color: #333333;
    font-size: 14px;
    line-height: 1;
    font-family: 'Microsoft YaHei';
    margin-top:0;
    margin-bottom:0;
}
a {
    color: blue;
    text-decoration: none;
    font-size: 14px;
}
a:hover {
    text-decoration: underline;
    color: #333;
}
pre {
    color: black;
    background-color: #f5f7fa;
    font-size: 14px;
    line-height: 1.5;
    font-family: 'Consolas', 'Courier New', monospace;
    padding: 10px;
    border: 1px solid #ccc;
}
</style>
</head>
<body>
<p>{{CONTENT}}</p>
</body>
</html>";

			var htmlContent = htmlTemplate.Replace("{{CONTENT}}", info.Replace("\n", "<br>"));
			htmlContent = Regex.Replace(htmlContent, @"(<br>)+", "<br>", RegexOptions.IgnoreCase);
			htmlContent = htmlContent.Replace("<br><blockquote><br>", "<blockquote>")
									 .Replace("<br></blockquote><br>", "</blockquote>")
									 .Replace("</p><br></p>", "</p></p>");

			return htmlContent.Trim('\r', '\n');
		}

		/// <summary>
		/// 初始化类信息管理器并一次性加载所有类和子类到缓存
		/// </summary>
		private void InitializeClassInfoManager(string definitionsDirectory)
		{
			_classInfoCache = new Dictionary<string, ClassInfo>(StringComparer.OrdinalIgnoreCase);
			_classToFileMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			if (Directory.Exists(definitionsDirectory))
			{
				var jsonFiles = Directory.GetFiles(definitionsDirectory, "*.json");
				foreach (var file in jsonFiles)
				{
					var className = ParseEchartJs.ToPascalCase(Path.GetFileNameWithoutExtension(file));
					_classToFileMap[className] = file;
				}
			}
			LoadAllClassesIntoCache();
		}

		/// <summary>
		/// 将所有类与子类信息一次性加载并缓存起来
		/// </summary>
		private void LoadAllClassesIntoCache()
		{
			var item = ParseEchartJs.GenerateClassItem();
			foreach (var kvp in _classToFileMap)
			{
				var className = kvp.Key;
				if (_classInfoCache.ContainsKey(className)) continue;
				var classInfo = LoadClassInfoFromJson(kvp.Value);
				if (classInfo == null) continue;
				foreach (var r in item)
				{
					if (classInfo.ClassName != ParseEchartJs.ToPascalCase(r.Key.Replace("-", "_"))) continue;
					classInfo.Description = r.Value.Desc;
					break;
				}
				CacheClassInfo(classInfo);
			}
			if (item == null) return;
			_classInfoCache["VisualMap"] = new ClassInfo()
			{
				Description = item["visualMap"].Desc,
				Example = item["visualMap"].ExampleBaseOptions
			};
			_classInfoCache["DataZoom"] = new ClassInfo()
			{
				Description = item["dataZoom"].Desc,
				Example = item["dataZoom"].ExampleBaseOptions
			};
		}

		/// <summary>
		/// 递归缓存类信息及其子类
		/// </summary>
		private void CacheClassInfo(ClassInfo classInfo)
		{
			if (classInfo == null) return;
			var key = classInfo.NewClassName ?? classInfo.ClassName;
			if (!_classInfoCache.ContainsKey(key))
			{
				_classInfoCache[key] = classInfo;
			}

			if (classInfo.ChildClasses == null) return;
			foreach (var child in classInfo.ChildClasses)
			{
				CacheClassInfo(child);
			}
		}

		private void ToolStripButton3_Click(object sender, EventArgs e)
		{
			_ = HtmlParser.GetDemoJs();
		}

		private void ToolStripButton4_Click(object sender, EventArgs e)
		{
			var f = new Form2();
			f.Show();
		}

		private void ToolStripButton2_Click(object sender, EventArgs e)
		{
			// 正则表达式匹配code:标签之间的代码
			string pattern = @"code:\s*([\s\S]*?)(?=\s*code:|\s*$)";
			var matches = Regex.Matches(textBox1.Text, pattern, RegexOptions.Singleline);

			for (var i = 0; i < matches.Count; i++)
			{
				var match = matches[i];
				var s = match.Groups[1].Value.Trim();
				// 查找最后一个分号的位置，并去除其后的字符
				int lastSemicolonIndex = s.LastIndexOf(";", StringComparison.Ordinal);
				if (lastSemicolonIndex != -1)
				{
					s = s.Substring(0, lastSemicolonIndex + 1); // 去掉最后一个分号后的字符
				}

				DemoInfo.ShowDemo(webView21, s, this);
				if (i < matches.Count - 1)
				{
					MessageBox.Show(@"下一个示例");
				}

			}
		}
	}
}
