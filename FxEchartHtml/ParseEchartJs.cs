using HtmlAgilityPack;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FxEchartHtml
{
	public static class ParseEchartJs
	{
		private static Dictionary<string, Item> _fileStru;
		private static Dictionary<string, ClassInfo> _classInfos;
		private static readonly Dictionary<string, ClassInfo> ClassInfosJj = new Dictionary<string, ClassInfo>();
		private static readonly Dictionary<string, ClassInfo> ClassInfosJj2 = new Dictionary<string, ClassInfo>();
		private static readonly Dictionary<string, ClassInfo> ClassInfosJj3 = new Dictionary<string, ClassInfo>();

		public static async Task RunParseTask()
		{
			try
			{
				// 创建 WebContentFetcher 实例
				var fetcher = new WebContentFetcher();

				var url = "https://echarts.apache.org/zh/documents/option-parts/option.js?bb21d72548";
				var filePath0 = Path.Combine(Environment.CurrentDirectory + "\\js", "option.js");
				await fetcher.SaveLinkContentToFileAsync(url, filePath0);
				var content = File.ReadAllText(filePath0);

				url = "https://echarts.apache.org/zh/documents/option-gl-parts/option-gl.js?bb21d72548";
				filePath0 = Path.Combine(Environment.CurrentDirectory + "\\js", "option-gl.js");
				await fetcher.SaveLinkContentToFileAsync(url, filePath0);


				// 获取网页内容
				var content1 = File.ReadAllText(filePath0);

				url = "https://echarts.apache.org/zh/documents/option-parts/option-outline.js?bb21d72548";
				var filePath1 = Path.Combine(Environment.CurrentDirectory + "\\js", "option-outline.js");
				await fetcher.SaveLinkContentToFileAsync(url, filePath1);

				url = "https://echarts.apache.org/zh/documents/option-gl-parts/option-gl-outline.js?bb21d72548";
				filePath1 = Path.Combine(Environment.CurrentDirectory + "\\js", "option-gl-outline.js");
				await fetcher.SaveLinkContentToFileAsync(url, filePath1);



				var optionType = GetOptinPropTypes();


				// 如果获取成功，提取有效的 JSON 内容
				if (!string.IsNullOrEmpty(content))
				{
					var jsonContent = ExtractJsonContent(content);
					var jsonContent1 = ExtractJsonContent(content1);

					// 如果提取成功，解析并生成新的链接
					if (jsonContent != null)
					{
						// 生成新链接并输出到 Debug 窗口
						var newLinks = fetcher.GenerateNewLinks(jsonContent);
						var newLinks1 = fetcher.GenerateNewLinks(jsonContent1, true);
						foreach (var r in newLinks1)
						{
							newLinks[r.Key] = r.Value;
						}
						foreach (var link in newLinks.Keys)
						{
							var a = optionType.Children.FirstOrDefault(p => p.Prop == link);
							if (!link.Contains("dataZoom-") && !link.Contains("visualMap-") && !link.Contains("series") && !link.Contains("media"))
							{
								if (a == null)
								{
									continue;
								}

								if (!a.IsObject)
								{
									continue;
								}
							}

							Debug.WriteLine($"新的链接为: {newLinks[link]}");
							// 获取生成链接的内容并保存到文件中
							var fileName = ExtractFileName(newLinks[link]);
							if (newLinks1.ContainsKey(link))
							{
								fileName = ExtractFileName(newLinks[link], true);
							}
							var filePath = Path.Combine(Environment.CurrentDirectory + "\\js", fileName);
							await fetcher.SaveLinkContentToFileAsync(newLinks[link], filePath);
						}
					}
				}

				ParseAll();
				FxAll();
				ParseAll_Jj(_classInfos, ClassInfosJj);
				FxAll_jj(ClassInfosJj);
				ParseAll_Jj(ClassInfosJj, ClassInfosJj2);
				FxAll_jj(ClassInfosJj2);
				ParseAll_Jj(ClassInfosJj2, ClassInfosJj3);
				FxAll_jj(ClassInfosJj3);
				ClassInfosJj.Clear();
				ParseAll_Jj(ClassInfosJj3, ClassInfosJj);
				FxAll_jj(ClassInfosJj);

			}
			catch (Exception ex)
			{
				// 显示错误消息
				Debug.WriteLine($"发生错误：{ex.Message}");
			}
		}

		public static void ParseAll()
		{
			var optionType = GetOptinPropTypes();

			foreach (var r in optionType.Children)
			{
				if (r.Prop != null && r.Prop == "globe")
				{
					Debug.WriteLine("");
				}

				if (r.IsObject)
				{

					var filePath = $".\\js\\{r.Prop}.js";

					ParseFile(filePath, r);
					continue;
				}

				if (!r.IsArray) continue;
				if (r.Prop.Contains("series"))
				{
					Debug.Assert(true);
				}

				foreach (var r1 in r.Children)
				{
					if (!r1.IsObject) continue;
					var filePath = $".\\js\\{r.Prop}-{r1.ArrayItemType}.js";

					if (r1.ArrayItemType == null)
					{
						filePath = $".\\js\\{r.Prop}.js";
					}

					ParseFile(filePath, r1);

				}
			}

			OptimizedClassInfo("rich");
			OptimizedClassInfo("lineStyle");
			OptimizedClassInfo("label");
			OptimizedClassInfo("labelLine");
			OptimizedClassInfo("enterAnimation");
			OptimizedClassInfo("leaveAnimation");
			OptimizedClassInfo("updateAnimation");
			OptimizedClassInfo("keyframeAnimation");
			OptimizedClassInfo("textConfig");
			OptimizedClassInfo("decal");
			OptimizedClassInfo("itemStyle");
			OptimizedClassInfo("shape");
			OptimizedClassInfo("style");
			OptimizedClassInfo("emphasis");
			OptimizedClassInfo("blur");
			OptimizedClassInfo("textStyle");
			OptimizedClassInfo("shadowStyle");
			OptimizedClassInfo("labelLayout");
			OptimizedClassInfo("upperLabel");
			OptimizedClassInfo("handleStyle");
			OptimizedClassInfo("iconStyle");
			OptimizedClassInfo("nameTextStyle");
			OptimizedClassInfo("areaStyle");
			OptimizedClassInfo("axisTick");
			OptimizedClassInfo("select");
			OptimizedClassInfo("extra");
			OptimizedClassInfo("edgeLabel");
			OptimizedClassInfo("tooltip");
			OptimizedClassInfo("crossStyle");
			OptimizedClassInfo("markArea");
			OptimizedClassInfo("markLine");
			OptimizedClassInfo("markPoint");

		}

		public static void ParseAll_Jj(Dictionary<string, ClassInfo> classInfos, Dictionary<string, ClassInfo> newClassInfos)
		{
			var optionType = GetOptinPropTypes();

			foreach (var r in optionType.Children)
			{

				if (r.IsObject)
				{

					var filePath = $".\\js\\{r.Prop}.js";

					ParseFile_Jj(filePath, r, classInfos, newClassInfos);
					continue;
				}

				if (!r.IsArray) continue;
				if (r.Prop.Contains("series"))
				{
					Debug.Assert(true);
				}

				foreach (var r1 in r.Children)
				{
					if (!r1.IsObject) continue;
					var filePath = $".\\js\\{r.Prop}-{r1.ArrayItemType}.js";

					if (r1.ArrayItemType == null)
					{
						filePath = $".\\js\\{r.Prop}.js";
					}
					ParseFile_Jj(filePath, r1, classInfos, newClassInfos);
				}
			}
		}

		// 从 URL 中提取文件名的方法
		private static string ExtractFileName(string url, bool is3d = false)
		{
			try
			{
				var uri = new Uri(url);
				var path = uri.AbsolutePath;
				var fileNameWithParams = Path.GetFileName(path);

				// 去掉可能的查询参数部分
				var fileName = fileNameWithParams.Split('?')[0];
				// 去掉前缀 "option."
				if (fileName.StartsWith("option."))
				{
					fileName = fileName.Substring("option.".Length);
				}

				if (is3d)
				{
					fileName = fileName.Replace("option-gl.", "");
				}
				return fileName;
			}
			catch (Exception e)
			{
				Debug.WriteLine($"提取文件名时发生错误: {e.Message}");
				return null;
			}
		}

		/// <summary>
		/// 使用字符串处理的方式提取 window.__EC_DOC_option_* 后面的 JSON 字符串。
		/// </summary>
		/// <param name="content">包含 JSON 数据的字符串</param>
		/// <returns>提取出的 JSON 字符串</returns>
		public static string ExtractJsonContent(string content)
		{
			const string startMarker = "window.__EC_DOC_option";
			var startIndex = content.IndexOf(startMarker, StringComparison.Ordinal);
			if (startIndex == -1) return null;

			startIndex = content.IndexOf('=', startIndex) + 1;
			if (startIndex == 0) return null;
			return content.Substring(startIndex).Trim();
		}


		public static Option GetOptinPropTypes()
		{
			try
			{
				// 文件路径
				var filePath = $"{Environment.CurrentDirectory}\\js\\option-outline.js";

				// 读取文件内容到字符串
				var jsonText = File.ReadAllText(filePath);

				jsonText = ExtractJsonContent(jsonText);
				var ls = JsonConvert.DeserializeObject<Option>(jsonText);

				// 文件路径
				filePath = $"{Environment.CurrentDirectory}\\js\\option-gl-outline.js";

				// 读取文件内容到字符串
				jsonText = File.ReadAllText(filePath);

				jsonText = ExtractJsonContent(jsonText);
				var ls1 = JsonConvert.DeserializeObject<Option>(jsonText);
				foreach (var r in ls1.Children)
				{
					ls.Children.Add(r);
				}
				return ls;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				return null;
			}
		}

		private static string ExtractClassName(string content)
		{
			var pattern = @"window\.__EC_DOC_option_(\w+)\s*=";
			var match = Regex.Match(content, pattern);
			return match.Success ? match.Groups[1].Value : null;
		}

		private static void ParseTreeNode(HtmlNode node, int level)
		{
			var ls = node.SelectNodes(".//div[@class='doc-nav-item']");
			foreach (var treeNodeContent in ls)
			{
				var textSpan = treeNodeContent.SelectSingleNode(".//span[@class='doc-nav-item']/span");
				if (textSpan != null)
				{
					Debug.WriteLine(new string(' ', level * 2) + textSpan.InnerText.Trim());
				}

				var childrenNode =
					treeNodeContent.ParentNode.SelectSingleNode(
						"./following-sibling::div[@class='el-tree-node__children']");
				if (childrenNode != null)
				{
					ParseTreeNode(childrenNode, level + 1);
				}
			}
		}

		public static string ToPascalCase(string input)
		{
			if (input == null)
			{
				return "";
			}

			//input = input.Replace("<style_name>", "");
			if (input == "")
			{
				return "";
			}

			var parts = input.Split('_');
			if (parts[0].StartsWith("0") || parts[0].StartsWith("1"))
			{
				parts[0] = $"D{parts[0]}";
			}

			if (parts[0].StartsWith("$"))
			{
				parts[0] = parts[0].Substring(1);
			}

			for (var i = 0; i < parts.Length; i++)
			{
				if (parts[i] == "")
				{
					continue;
				}

				parts[i] = char.ToUpper(parts[i][0]) + parts[i].Substring(1);
			}

			return System.Web.HttpUtility.HtmlDecode(DecodeUnicodeEntities(string.Join(string.Empty, parts)));
		}

		private static string DecodeUnicodeEntities(string input)
		{
			return Regex.Replace(input, "&#x([0-9A-Fa-f]+);", match =>
			{
				var unicode = int.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
				return char.ConvertFromUtf32(unicode);
			});
		}

		private static string InferType(string property, string className, OptionItem optionItem)
		{
			property = property.Replace("<style.name>", "<style_name>");

			try
			{
				var item = GetItem(property);

				var uiControl = item?.UiControl;
				if (uiControl != null)
				{
					var type = uiControl.ControlType;
					switch (type)
					{
						case "percentvector":
							return "PercentVector"; // 自定义类型
						case "icon":
							return "string[]";
						case "number":
						case "numbr":
							return "double?";
						case "prefix":
							return "double?";
						case "boolean":
							return "bool?";
						case "color":
							return "Color";
						case "vector":
							Debug.WriteLine($"vector:{uiControl.Dimensions}");
							return "StringOrNumber[]";
						case "enum":
							Debug.WriteLine($"enum:{uiControl.Options}");
							return "string";
						case "angle":
							Debug.WriteLine(
								$"angle: step:{uiControl.Step} max:{uiControl.MaxValue} min:{uiControl.MinValue}");
							return "double?";
						case "percent":
							Debug.WriteLine($"percent: default:{uiControl.DefaultValue} step:{uiControl.Step}");
							return "string";
						case "text":
							Debug.WriteLine($"text: Prop:{optionItem.Prop}");
							return "string";
						default:
							Debug.WriteLine($"undefine:{type}");
							return "object";
					}
				}

				// 查找属性名列表中是否存在 '.' 的属性名，以判断是否为对象
				foreach (var propName in _allPropertyNames)
				{
					if (propName == "renderItem.return_bezierCurve.blur.style")
					{
						Debug.Assert(true);
					}

					if ((!propName.Contains('.') && !propName.Contains("-")) || !propName.StartsWith(property + ".") ||
						propName == property) continue;
					if (propName.Contains("-") && !propName.Contains("."))
					{
						return $"{ToPascalCase(property)}Type";
					}


					var propName1 = propName.Replace("-", ".");
					var parts = propName1.Split('.');
					if (parts.Length <= 1) continue;
					var objectName = parts[parts.Length - 2];
					if (objectName == "<style_name>")
					{
						objectName = "Rich";
					}

					return className + "_" + ToPascalCase(objectName);

				}

				var a = Option.FindOptionItemByProp(optionItem, property);
				if (a == null)
				{
					Debug.WriteLine($"{optionItem.Prop}:{property}");
					return "object";
				}

				if (a.Prop != null && a.Prop == "icon")
				{
					Debug.WriteLine($"{Option.InferTypeFromOptionItem(a)}");
				}

				return Option.InferTypeFromOptionItem(a);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return "object";
			}
		}

		private static Item GetItem(string name)
		{
			name = name.Replace("<style_name>", "<style.name>");
			name = name.Replace(".xxx.", ".xxx:xxx.");
			name = name.Replace(".d0.", ".0.").Replace(".d1.", ".1.");
			for (var i = 0; i < _allPropertyNames.Count; i++)
			{
				try
				{
					if (name == _allPropertyNames[i].Replace("<style_name>", "<style.name>"))
					{
						return _fileStru[_fileStru.Keys.ToArray()[i]];
					}
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
					continue;
				}
			}

			return new Item();
		}

		private static string GenerateChildClass(string className, List<string> propertyNames, OptionItem optionItem)
		{
			if (className.Contains("SeriesCustom.RenderItem"))
			{
				Debug.Assert(true);
			}

			className = className.Replace(".", "_").Replace("_<style_name> ", "");
			className = className.Replace(".", "_").Replace("_<style_name>", "");

			{
				var ss = className.Split('_');
				var s = ss.Aggregate("", (current, r) => current + (ToPascalCase(r) + "_"));
				s = s.Trim('_');
				className = s;
			}
			var a1 = className.Split('#');
			if (a1.Length > 1)
			{
				className = $"{a1[0]}_{char.ToUpper(a1[1][0]) + a1[1].Substring(1)}";
			}

			var classContent = $"    public class {className}\n    {{\n";



			foreach (var name1 in propertyNames)
			{
				var name = name1.Replace("#", "_").Replace(".", "_");
				var pp = name.Split('_');
				for (var i = 0; i < pp.Length; i++)
				{
					pp[i] = pp[i].Substring(0, 1).ToLower() + pp[i].Substring(1);
				}

				name = string.Join(".", pp).Replace("return.", "return_");
				if (name == "type" && (className.StartsWith("Series") || className.StartsWith("Inside") ||
									   className.StartsWith("Slider")))
				{
					// 添加注释
					classContent += "        /// <summary>\n";
					classContent += $"        /// type\n";
					classContent += "        /// </summary>\n";

					// 添加 JsonProperty 特性
					classContent += $"        [JsonProperty(\"{name}\")]\n";
					classContent +=
						$"        public string Type {{ get; set; }}=\"{className.Substring(6).ToLower()}\";\n\n";

					continue;
				}

				// 此处使用 item 的属性来生成类内容
				var item = GetItem(name);
				if (item == null)
				{
					if (name.Contains("title"))
					{
						Debug.Assert(true);
					}

					var key1 = _fileStru.Keys.FirstOrDefault(s => s == name);
					var ss1 = name.Split('.');
					var className1 = ToPascalCase(ss1[ss1.Length - 1]);
					if (name1.Contains("#"))
					{
						var ss2 = name1.Split('#');
						var s3 = ss2.Aggregate("", (current, r3) => current + (ToPascalCase(r3) + "_"));
						s3 = s3.Trim('_');
						className1 = s3;
					}

					// 添加注释
					classContent += "        /// <summary>\n";
					classContent += $"        ///{className}_{className1}\n";
					classContent += "        /// </summary>\n";
					// 添加 JsonProperty 特性
					classContent += $"        [JsonProperty(\"{ss1[ss1.Length - 1]}\")]\n";
					if (key1 != null)
					{
						classContent +=
							$"        public {className}_{ToPascalCase(ss1[ss1.Length - 1]).Replace("_<style.name> ", "").Replace("_<style.name>", "")} {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
					}
					else
					{
						if (ss1[ss1.Length - 1] == "show")
						{
							classContent +=
								$"        public bool? {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";

						}
						else
						{
							if (ss1[ss1.Length - 1].StartsWith("on"))
							{
								classContent +=
									$"        public string {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
								continue;
							}

							var str = "";
							for (var i = 0; i < ss1.Length; i++)
							{
								var s = ss1[i];
								str += (ToPascalCase(s) + "_");
							}

							str = str.Replace("_Return", "_Return_");


							str = str.Trim('_').Replace("-", "_").Replace("_<style.name> ", "")
								.Replace("_<style.name>", "");
							var ss2 = className.Split('_')[0].Replace("-", "_");
							if (name1.Contains("feature.") && name1.Contains(".title."))
							{
								classContent +=
									$"        public string {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							}
							else if (name1.Contains("feature.") && name1.Contains(".title"))
							{
								classContent +=
									$"        public string {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							}
							else if (name1.Contains("feature.") && name1.Contains("seriesIndex."))
							{
								classContent +=
									$"        public object {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							}
							else if (name1.Contains("feature.") && name1.Contains("option."))
							{
								classContent +=
									$"        public object {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							}
							else if (name1.Contains("#"))
							{
								classContent +=
									$"        public {className}_{className1} {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							}
							else
								classContent +=
									$"        public {ss2}_{str} {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";

						}

					}

					continue;
				}


				var ss = name.Split('.');
				var pname = ss[ss.Length - 1];
				// 添加注释
				classContent += "        /// <summary>\n";
				classContent += $"        /// {StripHtmlTags(Uri.UnescapeDataString(item.Description))}\n";
				classContent += "        /// </summary>\n";

				// 添加 JsonProperty 特性
				classContent += $"        [JsonProperty(\"{pname}\")]\n";

				// 推断类型并添加属性定义
				var propertyType = InferType(name, className, optionItem);
				propertyType = propertyType.Replace("_Return", "_Return_").Replace("__", "_");
				var parts = name.Split('.');
				classContent +=
					$"        public {propertyType} {ToPascalCase(parts[parts.Length - 1].Replace("-", "_"))} {{ get; set; }}\n\n";
			}

			classContent += "    }\n";
			return classContent;
		}

		// 辅助函数：去除 HTML 标签
		private static string StripHtmlTags(string input)
		{
			var result = Regex.Replace(input, "<.*?>", string.Empty).Trim();
			return System.Web.HttpUtility.HtmlDecode(Regex.Replace(result, "\\n", "\n /// "));
		}

		private static void GenerateChildClasses(OptionItem optionItem, ref string classContent, string rootClassName)
		{
			var parentClassName = rootClassName;
			var childClasses = new Dictionary<string, List<string>>();
			var stack = new Stack<(OptionItem, string)>();

			stack.Push((optionItem, parentClassName));

			while (stack.Count > 0)
			{
				var (currentItem, currentParentClassName) = stack.Pop();
				var currentClassName = currentParentClassName;

				if (currentItem.IsObject || currentItem.IsArray)
				{
					if (currentItem.Prop == null)
					{
						if (currentItem.ArrayItemType != null)
						{
							if (currentItem.ArrayItemType.Contains("custom"))
							{
								Debug.Assert(true);
							}

							if (currentParentClassName == "Series")
							{
								currentClassName = $"{currentParentClassName}{ToPascalCase(currentItem.ArrayItemType)}";
							}
							else if (!currentClassName.Contains("Graphic.Elements"))
								currentClassName =
									$"{currentParentClassName}_{ToPascalCase(currentItem.ArrayItemType)}";
						}

					}
					else
					{
						currentClassName = currentItem.Prop == "<style_name>"
							? $"{currentParentClassName}.{currentItem.Prop}"
							: $"{currentParentClassName}.{ToPascalCase(currentItem.Prop)}";
						if (currentItem.Prop.Contains("return_"))
						{
							currentClassName = $"{currentParentClassName}.{currentItem.Prop}";
							currentClassName = currentClassName.Replace("_", "#");

						}
					}

					currentClassName = currentClassName.Trim('_').Trim('.');
				}

				if (currentClassName == "SeriesCustom.RenderItem")
				{
					Debug.Assert(true);
				}

				if (!childClasses.ContainsKey(currentClassName))
				{
					if (currentItem.Children != null && currentItem.Children[0].Prop == null)
					{
						if (currentItem.Children[0].ArrayItemType != null)
						{

						}
					}
					else if (currentItem.Children != null && currentItem.Children[0].Prop.Contains("<style_name>"))
					{
						stack.Push((currentItem.Children[0], currentClassName));
						continue;
					}

					childClasses[currentClassName] = new List<string>();
				}


				if (currentItem.Children == null || currentItem.Children.Count <= 0) continue;
				foreach (var child in currentItem.Children)
				{
					if (child.Prop == null)
					{
						if (currentClassName == "Graphic.Elements")
						{
							stack.Push((child, $"{currentClassName}_{ToCamelCase(child.ArrayItemType)}"));

						}
						else
							stack.Push((child, $"{currentClassName}_{ToPascalCase(child.ArrayItemType)}"));
					}
					else
					{

						var p = $"{currentClassName.Replace("_", ".")}.{child.Prop}";
						if (child.Prop.Contains("_"))
						{
							p = $"{currentClassName.Replace("_", ".")}.{child.Prop.Replace("_", "#")}";
						}

						if (currentParentClassName.Contains("Graphic.Elements"))
						{

							p = $"{ToCamelCase(currentClassName.Replace("_", "."))}.{child.Prop}";
							//p = p.Replace("graphic.elements", "elements").Replace("_", ".");
						}


						if (currentParentClassName.Contains("SeriesCustom") && currentClassName.Contains("_return_"))
						{
							if (child.Children == null)
							{
								p = $"{currentClassName}.{child.Prop}";
								p = p.Replace("SeriesCustom_RenderItem_", "renderItem.");
							}
							else
							{
								Debug.Assert(true);
								p = $"{currentClassName}.{child.Prop}";
								p = p.Replace("SeriesCustom_RenderItem_", "renderItem.");
							}
						}
						else
						{
							var index = p.IndexOf(".", StringComparison.Ordinal);
							if (currentItem.ArrayItemType != null)
							{
								if (!currentParentClassName.Contains("Graphic.Elements"))
								{
									p = $"{currentClassName}_{child.Prop}";
									index = p.IndexOf("_", StringComparison.Ordinal);
								}
							}

							if (currentClassName.Contains("<"))
							{
								p =
									$"{ToCamelCase(currentClassName.Replace("_", ".").Substring(index + 1))}.{child.Prop}";
								p = p.Replace("<style.name>", "<style_name>");
							}
							else
							{
								p = $"{ToCamelCase(p.Substring(index + 1))}".Replace("#", "_");

							}
						}

						p = p.Replace(".d0.", ".0.").Replace(".d1.", ".1.");
						childClasses[currentClassName].Add(p.Trim('.'));
						if (child.IsObject || child.IsArray)
						{
							stack.Push((child, currentClassName));
						}

					}
				}
			}

			foreach (var childClass in childClasses)
			{

				if (childClass.Key.Contains("<style_name>"))
				{
					classContent += GenerateChildClass(childClass.Key.Replace("_<style_name>", "").Replace("-", "_"),
						childClass.Value, optionItem);
				}
				else
					classContent += GenerateChildClass(childClass.Key.Replace("-", "_"), childClass.Value, optionItem);
			}
		}

		private static string ToCamelCase(string input)
		{
			if (string.IsNullOrEmpty(input)) return "";
			input = input.Replace("<style_name>", "<style.name>");
			var ss = input.Split('.');
			for (var i = 0; i < ss.Length; i++)
			{
				ss[i] = char.ToLower(ss[i][0]) + ss[i].Substring(1);
				ss[i] = ss[i].Replace("<style.name>", "<style_name>");
			}

			return System.Web.HttpUtility.HtmlDecode(DecodeUnicodeEntities(string.Join(".", ss)));
		}


		public static OptionNode ParseOptions(string className, List<string> options)
		{
			var root = new OptionNode(className);

			foreach (var option in options)
			{
				var parts = option.Split('.');
				var currentNode = root;

				foreach (var part in parts)
				{
					if (!currentNode.Children.ContainsKey(part))
					{
						currentNode.Children[part] = new OptionNode(part);
					}

					currentNode = currentNode.Children[part];
				}
			}

			return root;
		}

		public static void PrintOptionTree(OptionNode node, string indent = "")
		{
			Console.WriteLine(indent + node.Name);
			foreach (var child in node.Children.Values)
			{
				PrintOptionTree(child, indent + "  ");
			}
		}

		public static Dictionary<string, List<string>> GenerateClassPropertyDictionary(OptionNode root)
		{
			var classProperties = new Dictionary<string, List<string>>();
			TraverseNodeRecursive(root, classProperties);
			return classProperties;
		}

		private static void TraverseNodeRecursive(OptionNode node, Dictionary<string, List<string>> classProperties,
			string parent = "")
		{
			if (node.Children.Count == 0) return;

			var className = parent == "" ? node.Name : parent;
			if (!classProperties.ContainsKey(className))
			{
				classProperties[className] = new List<string>();
			}

			foreach (var child in node.Children.Values)
			{
				classProperties[className].Add(child.Name);
				TraverseNodeRecursive(child, classProperties, className + ToPascalCase(child.Name));
			}
		}


		// 辅助函数：推断类型，支持根据 uiControl 定义属性类型
		private static List<string> PrepareAllPropertyNames(Dictionary<string, Item> rootObject)
		{
			_allPropertyNames = new List<string>();
			foreach (var prop in rootObject.Keys)
			{
				var prop1 = prop.Replace("-", ".");
				_allPropertyNames.Add(GetLowString(prop1));
			}

			return _allPropertyNames;
		}

		private static List<string> _allPropertyNames;

		public static Dictionary<string, OptionPart> GenerateClassItem()
		{
			Dictionary<string, OptionPart> options = null;
			try
			{
				var filePath0 = Path.Combine(Environment.CurrentDirectory + "\\js", "option.js");
				var content = File.ReadAllText(filePath0);
				var jsonContent = ExtractJsonContent(content);
				// 反序列化 JSON 内容到对象并展示
				options = JsonConvert.DeserializeObject<Dictionary<string, OptionPart>>(jsonContent);

				filePath0 = Path.Combine(Environment.CurrentDirectory + "\\js", "option-gl.js");
				content = File.ReadAllText(filePath0);
				var jsonContent1 = ExtractJsonContent(content);
				var options1 = JsonConvert.DeserializeObject<Dictionary<string, OptionPart>>(jsonContent1);

				foreach (var r in options1)
				{
					options[r.Key] = r.Value;
				}

			}
			catch (Exception e)
			{
				// 处理可能的解析错误
				Debug.WriteLine($"解析错误: {e.Message}");
			}

			return options;
		}

		public static string GetLowString(string keyName)
		{
			var ss = keyName.Split('.');
			for (var i = 0; i < ss.Length; i++)
			{
				if (ss[i] == "")
				{
					continue;
				}

				ss[i] = char.ToLower(ss[i][0]) + ss[i].Substring(1);
			}

			return string.Join(".", ss);
		}

		public static void ParseFile1(string jsonFilePath, OptionItem optionItem)
		{
			// 检查文件是否存在
			if (!File.Exists(jsonFilePath))
			{
				Debug.WriteLine($"文件 {jsonFilePath} 不存在，请检查路径。");
				return;
			}

			var item = GenerateClassItem();

			// 从文件读取内容
			var fileContent = File.ReadAllText(jsonFilePath);

			// 提取类名部分（假设格式类似于 window.__EC_DOC_option_series_sunburst = {）
			var className = ExtractClassName(fileContent);
			if (string.IsNullOrEmpty(className))
			{
				Debug.WriteLine(@"无法解析类名，请检查文件内容格式。");
				return;
			}

			// 提取 JSON 数据部分
			var jsonStartIndex = fileContent.IndexOf("{", StringComparison.Ordinal);
			if (jsonStartIndex == -1)
			{
				Debug.WriteLine(@"无法找到 JSON 数据，请检查文件内容格式。");
				return;
			}

			var json = fileContent.Substring(jsonStartIndex);

			// 将 JSON 映射到自定义类 (FileStru)
			try
			{
				_fileStru = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
			}
			catch (JsonSerializationException ex)
			{
				Debug.WriteLine($"反序列化 JSON 到 FileStru 时出错: {ex.Message}");
				return;
			}

			var desc = item[className.Replace("_", "-")].Desc;
			// 构造类文件内容
			var classContent =
				"using System;\nusing System.Collections.Generic;\nusing Newtonsoft.Json;\n\nnamespace Echarts\n{\n";
			// 添加注释
			classContent += "        /// <summary>\n";
			classContent += $"        /// {StripHtmlTags(Uri.UnescapeDataString(desc))}\n";
			classContent += "        /// </summary>\n";

			_allPropertyNames = PrepareAllPropertyNames(_fileStru);

			// 添加子类定义
			if (className.StartsWith("series"))
			{
				GenerateChildClasses(optionItem, ref classContent, "Series");
			}
			else if (className.StartsWith("toolbox"))
			{
				GenerateChildClasses(optionItem, ref classContent, "");
			}
			else
				GenerateChildClasses(optionItem, ref classContent, "");

			classContent += "    }\n";

			// 将类写入文件
			var outputFilePath = $".\\cs\\{ToPascalCase(className)}.cs";
			File.WriteAllText(outputFilePath, classContent);

			Debug.WriteLine($"C# 类文件已生成: {outputFilePath}");
		}

		public static ClassInfo FxClassInfo()
		{
			var p = "textStyle";
			var ls = new List<string>();
			foreach (var r in _classInfos)
			{
				foreach (var r1 in r.Value.Properties)
				{
					if (r1.PropertyName == p)
					{
						Debug.WriteLine($"{r.Key}.{r1.PropertyName}");
						ls.Add($"{r.Key}_{ToPascalCase(r1.PropertyName)}");
					}
				}
			}

			var sameList = new List<List<string>>();
			var flagList = new List<bool>();
			for (int i = 0; i < ls.Count; i++)
			{
				flagList.Add(false);
			}

			for (var i = 0; i < ls.Count - 1; i++)
			{
				if (flagList[i])
				{
					continue;
				}

				var ls1 = new List<string>();
				var r = _classInfos[ls[i]];
				for (int j = i + 1; j < ls.Count; j++)
				{
					if (flagList[j])
					{
						continue;
					}

					var r1 = _classInfos[ls[j]];
					var flag = true;
					if (r1.Properties.Count != r.Properties.Count)
					{
						continue;
					}

					foreach (var r2 in r.Properties)
					{
						var flag1 = false;
						foreach (var r3 in r1.Properties)
						{
							if (r2.PropertyName == r3.PropertyName)
							{
								flag1 = true;
								break;
							}
						}

						if (!flag1)
						{
							flag = false;
						}

					}

					if (flag)
					{
						if (!flagList[i])
						{
							ls1.Add(r.ClassName);

						}

						if (!flagList[j])
						{
							ls1.Add(r1.ClassName);

						}

						flagList[i] = true;
						flagList[j] = true;
					}
				}

				if (ls1.Count > 0)
				{
					sameList.Add(ls1);
					Debug.WriteLine($"{p}=> same:{ls1.Count} propNum={r.Properties.Count}");
				}
				else
				{
					ls1.Add(r.ClassName);
					sameList.Add(ls1);
					Debug.WriteLine($"{p}=> same:{ls1.Count} propNum={r.Properties.Count}");

				}
			}

			return null;
		}

		public static void OptimizedClassInfo(string propertyNameToFind)
		{
			try
			{
				if (string.IsNullOrEmpty(propertyNameToFind))
				{
					throw new ArgumentException(@"Property name to find cannot be null or empty.",
						nameof(propertyNameToFind));
				}

				var classesWithProperty = new HashSet<string>();
				var classPropertyMaps = new Dictionary<string, ClassInfo>();

				// 收集所有包含特定属性的类，并记录它们的属性
				foreach (var classInfo in _classInfos)
				{
					foreach (var property in classInfo.Value.Properties)
					{
						if (property.PropertyName != propertyNameToFind) continue;
						try
						{
							var key = $"{classInfo.Key}_{ToPascalCase(property.PropertyName)}";

							if (propertyNameToFind == "rich")
							{
								var key1 = $"{key}_<styleName>";
								classPropertyMaps[key] = _classInfos[key1];
								classesWithProperty.Add(key);
							}
							else
							{
								if (_classInfos.TryGetValue(key, out var info))
								{
									classesWithProperty.Add(key);
									classPropertyMaps[key] = info;

								}
							}
						}
						catch (Exception e)
						{
							Debug.WriteLine(e.Message);
						}
					}
				}

				var samePropertyClasses = new Dictionary<string, List<string>>();
				var n = 0;
				var processedClasses = new HashSet<string>();

				foreach (var className in classesWithProperty)
				{
					if (processedClasses.Contains(className))
					{
						continue;
					}

					var currentClassProperties = classPropertyMaps[className].Properties;
					var matchingClasses = new List<string> { className };

					foreach (var otherClassName in classesWithProperty)
					{
						if (processedClasses.Contains(otherClassName) || otherClassName == className)
						{
							continue;
						}

						var otherClassProperties = classPropertyMaps[otherClassName].Properties;
						if (PropertiesMatch(currentClassProperties, otherClassProperties))
						{
							matchingClasses.Add(otherClassName);
						}
					}

					samePropertyClasses.Add(
						matchingClasses.Count == 1
							? $"{matchingClasses[0]}"
							: $"{ToPascalCase(propertyNameToFind)}{n++}", matchingClasses);


					foreach (var matchedClass in matchingClasses)
					{
						processedClasses.Add(matchedClass);
					}
				}

				var classInfos = new List<ClassInfo>();

				foreach (var r in _classInfos)
				{
					var key = r.Key;
					if (r.Key != r.Value.ClassName)
					{
						key = r.Value.ClassName;
					}
					foreach (var r1 in samePropertyClasses)
					{
						for (int i = 0; i < r.Value.Properties.Count; i++)
						{
							var p = r.Value.Properties[i];
							if (p.PropertyName != propertyNameToFind) continue;
							var k1 = $"{r.Key}_{ToPascalCase(propertyNameToFind)}";
							if (!r1.Value.Contains(k1)) continue;
							//Debug.WriteLine($"{r.Value.ClassName}.{p.PropertyName}->{r1.Key}");
							p.PropertyType = r1.Key;
						}

						foreach (var r2 in r1.Value)
						{
							var k2 = r2.Replace(r.Key, key);
							if (r.Key != r2) continue;
							//Debug.WriteLine($"{r.Value.ClassName}->{r1.Key}");
							ClassInfo.UpdateChildClasses(r.Value, r.Value.ClassName, r1.Key);
							break;
						}
					}

					classInfos.Add(r.Value);
				}



			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}

		}

		private static bool PropertiesMatch(List<PropertyInfo> properties1, List<PropertyInfo> properties2)
		{
			// 首先检查两个属性列表的长度是否相等
			if (properties1.Count != properties2.Count)
			{
				return false;
			}
			// 将属性名称转换为集合，以便进行集合比较
			var set1 = properties1.Select(p => (p.PropertyName, p.PropertyType)).ToHashSet();
			var set2 = properties2.Select(p => (p.PropertyName, p.PropertyType)).ToHashSet();

			// 比较两个属性名称集合是否相等
			return set1.SetEquals(set2);
		}

		private static void UpdateClassInfoWithMergedTypes(
			Dictionary<string, List<string>> samePropertyClasses,
			Dictionary<string, ClassInfo> classInfos,
			string propertyNameToFind)
		{
			// 遍历每个类，更新属性类型和子类信息
			foreach (var classInfo in classInfos.Values)
			{
				// 更新属性类型
				foreach (var property in classInfo.Properties)
				{
					if (property.PropertyName != propertyNameToFind) continue;

					foreach (var group in samePropertyClasses)
					{
						// 构造匹配键
						var key = $"{classInfo.ClassName}_{ToPascalCase(property.PropertyName)}";
						if (group.Value.Contains(key))
						{
							// 更新属性类型为新的分组键
							property.PropertyType = group.Key;
							//Debug.WriteLine($"Updated {classInfo.ClassName}.{property.PropertyName} -> {group.Key}");
							break;
						}
					}
				}

				// 更新子类信息
				foreach (var group in samePropertyClasses)
				{
					foreach (var className in group.Value)
					{
						if (classInfo.ClassName == className)
						{
							ClassInfo.UpdateChildClasses(classInfo, classInfo.ClassName, group.Key);
							//Debug.WriteLine($"Updated child class {classInfo.ClassName} -> {group.Key}");
							break;
						}
					}
				}
			}
		}


		public static void ParseFile(string jsonFilePath, OptionItem optionItem)
		{
			if (!File.Exists(jsonFilePath))
			{
				Debug.WriteLine($"文件 {jsonFilePath} 不存在，请检查路径。");
				return;
			}
			else
			{
				Debug.WriteLine(jsonFilePath);
			}

			var fileContent = File.ReadAllText(jsonFilePath);
			var className = ExtractClassName(fileContent).Replace("gl_", "");
			if (string.IsNullOrEmpty(className))
			{
				Debug.WriteLine(@"无法解析类名，请检查文件内容格式。");
				return;
			}

			var jsonStartIndex = fileContent.IndexOf("{", StringComparison.Ordinal);
			if (jsonStartIndex == -1)
			{
				Debug.WriteLine(@"无法找到 JSON 数据，请检查文件内容格式。");
				return;
			}

			var json = fileContent.Substring(jsonStartIndex);
			try
			{
				_fileStru = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
				_allPropertyNames = PrepareAllPropertyNames(_fileStru);
			}
			catch (JsonSerializationException ex)
			{
				Debug.WriteLine($"反序列化 JSON 到 FileStru 时出错: {ex.Message}");
				return;
			}

			var item = GenerateClassItem();

			var example = item[className.Replace("_", "-")].ExampleBaseOptions;

			//_classContent = new StringBuilder();
			//// 构造类文件内容
			//_classContent.Append(
			//	"using System;\nusing System.Collections.Generic;\nusing Newtonsoft.Json;\n\nnamespace Echarts\n{\n");
			//// 添加注释
			//_classContent.Append("        /// <summary>\n");
			//_classContent.Append($"        /// {StripHtmlTags(Uri.UnescapeDataString(desc))}\n");
			//_classContent.Append("        /// </summary>\n");

			var classInfo = GenerateClassInfo(optionItem, className, _fileStru);
			classInfo.Example = example;

			//GenerateClassContent(classInfo);
			//_classContent.Append("}");

			//var outputFilePath = $".\\cs\\{ToPascalCase(classInfo.ClassName)}.cs";
			//var outputFilePath1 = $".\\json\\{ToPascalCase(classInfo.ClassName)}.json";
			//File.WriteAllText(outputFilePath, _classContent.ToString());
			//File.WriteAllText(outputFilePath1, JsonConvert.SerializeObject(classInfo));

			//Debug.WriteLine($"C# 类文件已生成: {outputFilePath}");
		}
		private static readonly List<ClassInfo> AllClassInfos = new List<ClassInfo>();
		public static void ParseFile_Jj(string jsonFilePath, OptionItem optionItem, Dictionary<string, ClassInfo> classInfos, Dictionary<string, ClassInfo> newClassInfos)
		{
			if (!File.Exists(jsonFilePath))
			{
				Debug.WriteLine($"文件 {jsonFilePath} 不存在，请检查路径。");
				return;
			}

			if (jsonFilePath.Contains("globe"))
			{

			}
			Debug.WriteLine(jsonFilePath);
			var fileContent = File.ReadAllText(jsonFilePath);
			var className = ExtractClassName(fileContent).Replace("gl_", "");
			if (string.IsNullOrEmpty(className))
			{
				Debug.WriteLine(@"无法解析类名，请检查文件内容格式。");
				return;
			}

			var jsonStartIndex = fileContent.IndexOf("{", StringComparison.Ordinal);
			if (jsonStartIndex == -1)
			{
				Debug.WriteLine(@"无法找到 JSON 数据，请检查文件内容格式。");
				return;
			}

			var json = fileContent.Substring(jsonStartIndex);
			try
			{
				_fileStru = JsonConvert.DeserializeObject<Dictionary<string, Item>>(json);
				_allPropertyNames = PrepareAllPropertyNames(_fileStru);
			}
			catch (JsonSerializationException ex)
			{
				Debug.WriteLine($"反序列化 JSON 到 FileStru 时出错: {ex.Message}");
				return;
			}

			var item = GenerateClassItem();

			var desc = item[className.Replace("_", "-")].Desc;
			var example = item[className.Replace("_", "-")].ExampleBaseOptions;


			var content = new StringBuilder();
			// 构造类文件内容
			content.Append(
				"using System;\nusing System.Collections.Generic;\nusing Newtonsoft.Json;\n\nnamespace Echarts\n{\n");
			// 添加注释
			content.Append("        /// <summary>\n");
			content.Append($"        /// {StripHtmlTags(Uri.UnescapeDataString(desc))}\n");
			content.Append("        /// </summary>\n");

			var classInfo = GenerateClassInfo2(optionItem, className, _fileStru, classInfos, ref newClassInfos);

			classInfo.Example = example;

			var classContent = GenerateClassContent(classInfo);
			content.Append(classContent);
			content.Append("}");

			var outputFilePath = $".\\cs\\{ToPascalCase(classInfo.ClassName)}.cs";
			var outputFilePath1 = $".\\json\\{ToPascalCase(classInfo.ClassName)}.json";
			File.WriteAllText(outputFilePath, content.ToString());
			File.WriteAllText(outputFilePath1, JsonConvert.SerializeObject(classInfo));
			AllClassInfos.Add(classInfo);
		}

		private static void FxAll()
		{
			var foundPairs = new HashSet<(string, string)>();

			foreach (var rootClass in _classInfos.Values)
			{
				var visitedClasses = new HashSet<string>();
				if (!visitedClasses.Add(rootClass.ClassName)) continue;

				foreach (var otherClass in _classInfos.Values)
				{
					if (otherClass.ClassName == rootClass.ClassName || visitedClasses.Contains(otherClass.ClassName)) continue;

					if (HaveSamePropertiesType(rootClass, otherClass, visitedClasses, _classInfos))
					{
						foundPairs.Add((rootClass.ClassName, otherClass.ClassName));
					}
				}
			}

			MergeSimilarClasses(foundPairs, _classInfos);
		}


		private static void FxAll_jj(Dictionary<string, ClassInfo> classInfos)
		{
			var foundPairs = new HashSet<(string, string)>();

			foreach (var rootClass in classInfos.Values)
			{
				var visitedClasses = new HashSet<string>();
				if (!visitedClasses.Add(rootClass.ClassName)) continue;

				foreach (var otherClass in classInfos.Values)
				{
					if (otherClass.ClassName == rootClass.ClassName || visitedClasses.Contains(otherClass.ClassName)) continue;

					if (HaveSamePropertiesType(rootClass, otherClass, visitedClasses, classInfos))
					{
						foundPairs.Add((rootClass.ClassName, otherClass.ClassName));
					}
				}
			}

			MergeSimilarClasses(foundPairs, classInfos);
		}
		private static void MergeSimilarClasses(HashSet<(string, string)> foundPairs, Dictionary<string, ClassInfo> classInfos)
		{
			var representativeMap = new Dictionary<string, string>(); // 每个类和其代表类的映射关系

			// 初始化每个类的代表为自己
			foreach (var (class1, class2) in foundPairs)
			{
				if (!representativeMap.ContainsKey(class1))
				{
					representativeMap[class1] = class1;
				}
				if (!representativeMap.ContainsKey(class2))
				{
					representativeMap[class2] = class2;
				}
			}

			// 合并类之间的关系
			foreach (var (class1, class2) in foundPairs)
			{
				string rep1 = FindRepresentative(representativeMap, class1);
				string rep2 = FindRepresentative(representativeMap, class2);

				if (rep1 != rep2)
				{
					// 合并：将 rep2 的所有类归并到 rep1
					representativeMap[rep2] = rep1;
				}
			}

			// 生成代表类映射的快照，避免在遍历时修改集合
			var keys = representativeMap.Keys.ToList();

			// 路径压缩，更新所有类的代表类
			foreach (var cls in keys)
			{
				representativeMap[cls] = FindRepresentative(representativeMap, cls);
			}

			// 构造最终的 classMap
			var classMap = new Dictionary<string, List<string>>();
			foreach (var cls in representativeMap.Keys)
			{
				string repCls = representativeMap[cls];
				if (!classMap.ContainsKey(repCls))
				{
					classMap[repCls] = new List<string>();
				}
				classMap[repCls].Add(cls);
			}

			// 输出结果
			Debug.WriteLine($"\n=======\ncount: {classMap.Count}");

			foreach (var entry in classMap)
			{
				Debug.WriteLine($"Key: {entry.Key}, Value: {string.Join(", ", entry.Value.Distinct())}");
				UpdateClassInfoWithMergedTypes(classMap, classInfos, entry.Key);
			}
		}

		// 辅助方法：查找代表类
		private static string FindRepresentative(Dictionary<string, string> representativeMap, string cls)
		{
			if (representativeMap[cls] != cls)
			{
				// 路径压缩：递归查找并直接更新代表类
				representativeMap[cls] = FindRepresentative(representativeMap, representativeMap[cls]);
			}
			return representativeMap[cls];
		}


		private static bool HaveSamePropertiesType(ClassInfo classInfo1, ClassInfo classInfo2, HashSet<string> visited, Dictionary<string, ClassInfo> classInfos = null)
		{
			if (classInfo1 == null)
			{
				return false;
			}
			if (classInfo2 == null)
			{
				return false;
			}


			if (classInfo1.Properties.Count != classInfo2.Properties.Count) return false;

			for (int i = 0; i < classInfo1.Properties.Count; i++)
			{
				try
				{
					var prop1 = classInfo1.Properties[i];
					var prop2 = classInfo2.Properties.FirstOrDefault(p => p.PropertyName == prop1.PropertyName);

					if (prop2 == null) return false;

					if (prop1.PropertyType != prop2.PropertyType)
					{
						// If types are different, check if the types themselves are the same by structure
						if (!HaveSamePropertiesType(FindClassInfo(prop2.PropertyType, visited, classInfos), FindClassInfo(prop1.PropertyType, visited, classInfos), visited, classInfos))
							return false;
					}
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
				}
			}

			return true;
		}

		private static ClassInfo FindClassInfo(string className, HashSet<string> visited = null, Dictionary<string, ClassInfo> classInfos = null)
		{
			// 如果访问过的类集合为空，则创建一个新的HashSet
			if (visited == null)
			{
				visited = new HashSet<string>();
			}

			// 查找类信息，如果找到并且没有访问过，则返回
			var classInfoKey = classInfos.Keys.FirstOrDefault(c => c == className && !visited.Contains(c));
			if (classInfoKey == null) return null;
			var classInfo = classInfos[classInfoKey];
			if (classInfo != null && visited.Add(classInfo.ClassName))
			{
				return classInfo;
			}

			// 如果当前类没有找到或者已经访问过，则递归搜索子类
			foreach (var rootClass in classInfos.Values)
			{
				if (!visited.Add(rootClass.ClassName))
				{
					continue; // 如果已经访问过，则跳过
				}

				// 标记为已访问
				foreach (var childClass in rootClass.ChildClasses)
				{
					// 递归搜索子类
					classInfo = FindClassInfo(className, visited, classInfos);
					if (classInfo != null)
					{
						return classInfo;
					}
				}
			}

			// 如果没有找到，则返回null
			return null;
		}
		private static ClassInfo GenerateClassInfo(OptionItem optionItem, string className,
			Dictionary<string, Item> fileStru)
		{
			var classInfo = new ClassInfo
			{
				ClassName = ToPascalCase(className),
				Description = fileStru.ContainsKey(className.Replace("_", "-"))
					? fileStru[className.Replace("_", "-")].Description
					: string.Empty,
				Properties = new List<PropertyInfo>(),
				ChildClasses = new List<ClassInfo>()
			};

			var stack = new Stack<(OptionItem, ClassInfo)>();
			stack.Push((optionItem, classInfo));

			while (stack.Count > 0)
			{
				var (currentItem, currentClassInfo) = stack.Pop();
				if (currentItem.Children == null) continue;

				foreach (var child in currentItem.Children)
				{
					var propertyName = child.Prop ?? child.ArrayItemType;
					var propertyType = child.Children != null
						? child.Prop != null
							? $"{currentClassInfo.ClassName}_{ToPascalCase(child.Prop)}"
							: $"{currentClassInfo.ClassName}_{ToPascalCase(child.ArrayItemType)}"
						: Option.InferTypeFromOptionItem(child);

					if (!string.IsNullOrEmpty(propertyName))
					{
						var s = $"{currentClassInfo.ClassName}_{propertyName}";
						var index = s.IndexOf("_", StringComparison.Ordinal);
						s = s.Substring(index + 1).Replace("_", ".");
						s = GetLowString(s).Replace("styleName", "style_name");

						var info = new PropertyInfo
						{
							PropertyName = propertyName.Replace(":xxx", ""),
							PropertyType = propertyType.Replace(":xxx", ""),
							PropertyDescription = GetItem(s).Description,
							DefaultValue = child.Default
						};
						if (child.IsArray)
						{
							info.PropertyType = $"{info.PropertyType}[]";
						}
						currentClassInfo.Properties.Add(info);
					}

					//Debug.WriteLine($"{currentClassInfo.ClassName}");
					if (child.IsObject || child.IsArray)
					{
						//propertyType = propertyType.Replace("_<styleName>", "");
						var newinfo = new ClassInfo
						{
							ClassName = propertyType.Replace(":xxx", ""),
							Properties = new List<PropertyInfo>(),
							Description = GetItem(propertyName).Description,
							ChildClasses = new List<ClassInfo>()
						};
						stack.Push((child, newinfo));
						currentClassInfo.ChildClasses.Add(newinfo);
						if (_classInfos == null) _classInfos = new Dictionary<string, ClassInfo>();
						_classInfos[newinfo.ClassName] = newinfo;
					}
				}

			}

			_classInfos[classInfo.ClassName] = classInfo;
			//Debug.WriteLine(JsonConvert.SerializeObject(classInfo));
			return classInfo;
		}

		private static bool CheckClass(string className, Dictionary<string, ClassInfo> classInfos, out ClassInfo classInfo)
		{
			// 检查 _classInfos 字典的键中是否包含给定的类名 className
			if (classInfos.Keys.Contains(className))
			{
				// 如果包含，将对应的 ClassInfo 对象赋值给输出参数 classInfo
				classInfo = classInfos[className];
				// 返回一个布尔值，指示 classInfo 的 ClassName 属性是否与输入的 className 相等
				return classInfo.ClassName == className;
			}

			if (className == "Grid_Tooltip")
			{
				Debug.Assert(true);
			}
			if (_classInfos.Keys.Contains(className))
			{
				// 如果包含，将对应的 ClassInfo 对象赋值给输出参数 classInfo
				classInfo = _classInfos[className];
				// 返回一个布尔值，指示 classInfo 的 ClassName 属性是否与输入的 className 相等
				return classInfo.ClassName == className;
			}
			// 遍历 _classInfos 字典，查找 ClassName 属性与给定类名 className 相等的项
			foreach (var r in _classInfos.Where(r => r.Value.ClassName == className))
			{
				// 如果找到匹配项，将对应的 ClassInfo 对象赋值给输出参数 classInfo
				classInfo = r.Value;
				// 返回 true，表示找到了匹配的类
				return true;
			}

			// 如果没有找到任何匹配的类，将输出参数 classInfo 设置为 null
			classInfo = null;
			// 返回 false，表示没有找到匹配的类
			return false;
		}


		private static ClassInfo GenerateClassInfo2(OptionItem optionItem, string className, Dictionary<string, Item> fileStru, Dictionary<string, ClassInfo> oldClassInfos, ref Dictionary<string, ClassInfo> newClassInfos)
		{
			if (newClassInfos == null)
			{
				newClassInfos = new Dictionary<string, ClassInfo>();
			}
			var classInfo = new ClassInfo
			{
				ClassName = ToPascalCase(className),
				Description = fileStru.ContainsKey(className.Replace("_", "-")) ? fileStru[className.Replace("_", "-")].Description : string.Empty,
				Properties = new List<PropertyInfo>(),
				ChildClasses = new List<ClassInfo>()
			};

			var stack = new Stack<(OptionItem, ClassInfo)>();
			classInfo.NewClassName = classInfo.ClassName;
			stack.Push((optionItem, classInfo));

			while (stack.Count > 0)
			{
				var (currentItem, currentClassInfo) = stack.Pop();
				if (currentItem.Children == null) continue;
				if (currentItem.Children.Count == 1 && currentItem.Prop == "rich")
				{
					currentClassInfo.ClassName = $"{currentClassInfo.ClassName}_{ToPascalCase(currentItem.Children[0].Prop)}";
					currentItem = currentItem.Children[0];
				}
				foreach (var child in currentItem.Children)
				{
					var propertyName = child.Prop ?? child.ArrayItemType;
					var propertyType = child.Children != null
						? child.Prop != null
							? $"{currentClassInfo.ClassName}_{ToPascalCase(child.Prop)}"
							: $"{currentClassInfo.ClassName}_{ToPascalCase(child.ArrayItemType)}"
						: Option.InferTypeFromOptionItem(child);
					propertyType = propertyType.Replace(":xxx", "");
					PropertyInfo info = null;
					if (!string.IsNullOrEmpty(propertyName))
					{
						var s = $"{currentClassInfo.ClassName}_{propertyName}";
						var index = s.IndexOf("_", StringComparison.Ordinal);
						s = s.Substring(index + 1).Replace("_", ".");
						s = GetLowString(s).Replace("styleName", "style_name");
						var item = GetItem(s);
						info = new PropertyInfo
						{
							PropertyName = propertyName.Replace(":xxx", ""),
							PropertyType = propertyType,
							PropertyDescription = item.Description,
							DefaultValue = child.Default
						};
						if (item.UiControl != null && item.UiControl.ControlType == "enum")
						{
							info.EnumString = item.UiControl.Options;
						}
						if (child.IsArray)
						{
							info.PropertyType = $"{info.PropertyType}[]";
						}
						currentClassInfo.Properties.Add(info);
						if (info.PropertyName == "padding")
						{
							info.PropertyType = "ArrayOrSingle";
						}
					}
					if (!child.IsObject && !child.IsArray) continue;

					if (!CheckClass(propertyType, oldClassInfos, out var oldClassInfo))
					{
						if (oldClassInfo == null || info == null) continue;
						info.PropertyType = oldClassInfo.ClassName;
						if (info.PropertyType == "Rich0")
						{
							info.PropertyType = "Dictionary <string,Rich0>";
						}
						var newinfo1 = new ClassInfo()
						{
							ClassName = propertyType,
							NewClassName = oldClassInfo.ClassName.Replace(":xxx", ""),
							Properties = new List<PropertyInfo>(),
							Description = GetItem(propertyName).Description,
							ChildClasses = new List<ClassInfo>()
						};

						if (newClassInfos.Keys.Contains(newinfo1.ClassName))
						{
							continue;
						}

						if (newinfo1.NewClassName != null)
						{
							if (newClassInfos.Keys.Contains(newinfo1.NewClassName))
							{
								continue;
							}
							newClassInfos[newinfo1.NewClassName] = newinfo1;

						}

						currentClassInfo.ChildClasses.Add(newinfo1);
						newClassInfos[newinfo1.ClassName] = newinfo1;
						stack.Push((child, newinfo1));
					}
					else
					{
						var newinfo = new ClassInfo
						{
							ClassName = propertyType,
							NewClassName = propertyType,
							Properties = new List<PropertyInfo>(),
							Description = GetItem(propertyName).Description,
							ChildClasses = new List<ClassInfo>()
						};
						if (!newClassInfos.Keys.Contains(newinfo.NewClassName))
						{
							stack.Push((child, newinfo));
							newClassInfos[newinfo.ClassName] = newinfo;
							currentClassInfo.ChildClasses.Add(newinfo);
						}
						else
						{
							Debug.Assert(true);
						}
					}
				}

				if (currentClassInfo.NewClassName != null)
				{
					currentClassInfo.ClassName = currentClassInfo.NewClassName;

				}
			}
			return classInfo;
		}

		private static string GenerateClassContent(ClassInfo classInfo)
		{
			var classContent = new StringBuilder();

			if (classInfo.ClassName.Contains("_<styleName>") && (classInfo.ChildClasses == null || classInfo.ChildClasses.Count == 0))
			{
				return "";
			}
			classContent.AppendLine("    /// <summary>");
			classContent.AppendLine($"    /// {StripHtmlTags(Uri.UnescapeDataString($"{classInfo.Description}"))}");
			classContent.AppendLine("    /// </summary>");
			classContent.AppendLine($"    public class {classInfo.ClassName.Replace("_<styleName>", "")}");
			classContent.AppendLine("    {");

			foreach (var property in classInfo.Properties)
			{
				//if (property.PropertyName == "padding")
				//{
				//	property.PropertyType = "ArrayOrSingle";
				//}

				classContent.AppendLine("        /// <summary>");
				classContent.AppendLine($"        /// {StripHtmlTags(Uri.UnescapeDataString($"{property.PropertyDescription}"))}");
				classContent.AppendLine("        /// </summary>");
				classContent.AppendLine($"        [JsonProperty(\"{property.PropertyName}\")]");
				classContent.AppendLine($"        public {property.PropertyType.Replace("_<styleName>", "")} {ToPascalCase(property.PropertyName)} {{ get; set; }}");
				classContent.AppendLine();
			}

			classContent.AppendLine("    }");
			if (classInfo.ChildClasses == null || classInfo.ChildClasses.Count == 0)
			{
				return classContent.ToString();
			}

			foreach (var info in classInfo.ChildClasses)
			{
				var content = GenerateClassContent(info);
				if (!string.IsNullOrEmpty(content)) classContent.AppendLine(content);
			}

			return classContent.ToString();
		}
	}
}

public class OptionNode
{
	public string Name { get; set; }
	public Dictionary<string, OptionNode> Children { get; set; } = new Dictionary<string, OptionNode>();

	public OptionNode(string name)
	{
		Name = name;
	}
}
public class OptionPart
{
	public string Desc { get; set; }
	public List<ExampleBaseOption> ExampleBaseOptions { get; set; }
}

public class ExampleBaseOption
{
	public string Code { get; set; }
	public string Name { get; set; }
	public string Title { get; set; }
	public string TitleEn { get; set; }
}

