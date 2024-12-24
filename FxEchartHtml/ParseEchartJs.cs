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
		private static Dictionary<string, EChartConfigItem> _currFileStru;
		private static List<string> _currFilePropertyNames;

		private static Dictionary<string, ClassInfo>[] _infos = new Dictionary<string, ClassInfo>[4];

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
						foreach (var r in newLinks1) newLinks[r.Key] = r.Value;
						foreach (var link in newLinks.Keys)
						{
							var a = optionType.Children.FirstOrDefault(p => p.Prop == link);
							if (!link.Contains("dataZoom-") && !link.Contains("visualMap-") && !link.Contains("series") && !link.Contains("media"))
							{
								if (a == null) continue;

								if (!a.IsObject) continue;
							}
							Debug.WriteLine($"新的链接为: {newLinks[link]}");
							// 获取生成链接的内容并保存到文件中
							var fileName = ExtractFileName(newLinks[link]);
							if (newLinks1.ContainsKey(link)) fileName = ExtractFileName(newLinks[link], true);
							var filePath = Path.Combine(Environment.CurrentDirectory + "\\js", fileName);
							await fetcher.SaveLinkContentToFileAsync(newLinks[link], filePath);
						}
					}
				}

				var scanCount = 4;
				_infos = new Dictionary<string, ClassInfo>[scanCount];
				_infos[0] = new Dictionary<string, ClassInfo>();
				ParseAllJsFile(_infos[0]);
				MergeSimilarClasses(_infos[0]);
				for (int i = 1; i < scanCount; i++)
				{
					_infos[i] = new Dictionary<string, ClassInfo>();
					ParseAllOptionClasses(_infos[i - 1], _infos[i]);
					MergeSimilarClasses(_infos[i]);
				}

			}
			catch (Exception ex)
			{
				// 显示错误消息
				Debug.WriteLine($"发生错误：{ex.Message}");
			}
		}

		/// <summary>
		/// 解析所有 JavaScript 文件，加载和处理指定目录中的选项配置文件。
		/// </summary>
		/// <remarks>
		/// 此方法通过读取指定目录下的 JavaScript 文件内容，提取其中的配置信息，
		/// 并将这些配置信息转换为类信息对象以供后续操作使用。
		/// </remarks>
		public static void ParseAllJsFile(Dictionary<string, ClassInfo> classInfos)
		{
			// 获取选项属性类型
			var optionType = GetOptinPropTypes();

			// 定义JavaScript文件的基础目录
			const string jsBaseDir = ".\\js\\";

			// 遍历选项类型的每个子项
			foreach (var child in optionType.Children)
			{
				// 如果子项是一个对象，解析其对应的JavaScript文件
				if (child.IsObject)
				{
					var filePath = Path.Combine(jsBaseDir, $"{child.Prop}.js");
					ParseClasses(filePath, child, classInfos);
					continue; // 继续处理下一个子项
				}

				// 如果子项不是数组，跳过本次循环
				if (!child.IsArray) continue;

				// 遍历数组中的每个子项
				foreach (var subChild in child.Children)
				{
					// 仅处理对象类型的子项
					if (!subChild.IsObject) continue;

					// 根据 ArrayItemType 确定文件名
					var fileName = subChild.ArrayItemType != null
						? $"{child.Prop}-{subChild.ArrayItemType}.js"
						: $"{child.Prop}.js";

					var filePath = Path.Combine(jsBaseDir, fileName);
					ParseClasses(filePath, subChild, classInfos);
				}
			}

			// 需要优化的类名列表
			var classesToOptimize = new[]
			{
				"rich", "lineStyle", "label", "labelLine", "enterAnimation",
				"leaveAnimation", "updateAnimation", "keyframeAnimation", "textConfig",
				"decal", "itemStyle", "shape", "style", "emphasis", "blur",
				"textStyle", "shadowStyle", "labelLayout", "upperLabel",
				"handleStyle", "iconStyle", "nameTextStyle", "areaStyle",
				"axisTick", "select", "extra", "edgeLabel", "tooltip",
				"crossStyle", "markArea", "markLine", "markPoint"
			};

			// 对每个指定的类进行优化
			foreach (var className in classesToOptimize) OptimizedClassInfo(className, classInfos);
		}

		public static void ParseAllOptionClasses(Dictionary<string, ClassInfo> classInfos,
			Dictionary<string, ClassInfo> newClassInfos)
		{
			// 验证参数是否为 null
			if (classInfos == null) throw new ArgumentNullException(nameof(classInfos), @"classInfos 字典不能为 null。");

			if (newClassInfos == null)
				throw new ArgumentNullException(nameof(newClassInfos), @"newClassInfos 字典不能为 null。");

			// 获取选项属性类型
			var optionType = GetOptinPropTypes();
			if (optionType?.Children == null)
			{
				Debug.WriteLine("optionType 或其 Children 为空，请检查 GetOptinPropTypes 的实现。");
				return;
			}

			// 定义JavaScript文件的基础目录
			const string jsBaseDir = ".\\js\\";
			const string csBaseDir = ".\\cs\\";

			try
			{
				// 遍历选项类型的每个子项
				foreach (var child in optionType.Children)
				{

					if (child.IsObject)
					{
						// 构建文件路径，例如 ".\js\propName.js"
						var filePath = Path.Combine(jsBaseDir, $"{child.Prop}.js");
						if (filePath.Contains("graphic"))
						{
							Debug.WriteLine("");
						}
						var rootPath = Path.Combine(csBaseDir, $"{ToPascalCase(child.Prop)}");
						// 解析文件并更新 classInfos 和 newClassInfos 字典
						GenerateClassFiles(filePath, child, classInfos, newClassInfos, rootPath, true);
						continue; // 继续处理下一个子项
					}

					if (!child.IsArray)
						continue; // 如果子项不是数组，跳过本次循环

					// 遍历数组中的每个子项
					foreach (var subChild in child.Children)
					{
						if (!subChild.IsObject)
							continue; // 仅处理对象类型的子项

						// 根据 ArrayItemType 确定文件名，例如 "propName-itemType.js" 或 "propName.js"
						var fileName = subChild.ArrayItemType != null
							? $"{child.Prop}-{subChild.ArrayItemType}.js"
							: $"{child.Prop}.js";

						var filePath = Path.Combine(jsBaseDir, fileName);
						var rootPath = Path.Combine(csBaseDir, $"{child.Prop}");

						// 解析文件并更新 classInfos 和 newClassInfos 字典
						GenerateClassFiles(filePath, subChild, classInfos, newClassInfos, rootPath, true);
					}
				}
			}
			catch (Exception ex)
			{
				// 捕获并记录所有未处理的异常
				Debug.WriteLine($"在 ParseAllOptionClasses 方法中发生异常: {ex.Message}");
				// 根据需要，可以重新抛出异常或进行其他处理
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
				if (fileName.StartsWith("option.")) fileName = fileName.Substring("option.".Length);

				if (is3d) fileName = fileName.Replace("option-gl.", "");
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


		/// <summary>
		/// 获取选项属性类型，通过读取并合并多个 JSON 文件中的内容，返回合并后的 Option 对象。
		/// </summary>
		/// <returns>
		/// 返回一个合并后的 <see cref="Option"/> 对象。如果在读取或解析文件时发生异常，则返回 <c>null</c>。
		/// </returns>
		public static Option GetOptinPropTypes()
		{
			try
			{
				// 定义要读取的 JSON 文件列表
				var jsonFiles = new List<string>
				{
					"option-outline.js",
					"option-gl-outline.js"
				};

				// 定义 JavaScript 文件的基础目录
				var jsBaseDir = Path.Combine(Environment.CurrentDirectory, "js");

				// 初始化一个 Option 对象用于合并所有 JSON 文件的内容
				Option combinedOption = null;

				foreach (var fileName in jsonFiles)
				{
					// 构建完整的文件路径
					var filePath = Path.Combine(jsBaseDir, fileName);

					// 检查文件是否存在
					if (!File.Exists(filePath))
					{
						Debug.WriteLine($"文件 {filePath} 不存在，请检查路径。");
						continue; // 跳过不存在的文件，继续处理下一个文件
					}

					// 读取文件内容
					string jsonText;
					try
					{
						jsonText = File.ReadAllText(filePath);
					}
					catch (IOException ioEx)
					{
						Debug.WriteLine($"读取文件 {filePath} 时出错: {ioEx.Message}");
						continue;
					}

					jsonText = ExtractJsonContent(jsonText);
					if (string.IsNullOrEmpty(jsonText))
					{
						Debug.WriteLine($"文件 {filePath} 中未找到有效的 JSON 内容。");
						continue;
					}

					// 反序列化 JSON 内容为 Option 对象
					Option currentOption;
					try
					{
						currentOption = JsonConvert.DeserializeObject<Option>(jsonText);
						if (currentOption == null)
						{
							Debug.WriteLine($"反序列化文件 {filePath} 后得到的 Option 对象为空。");
							continue;
						}
					}
					catch (JsonSerializationException jsonEx)
					{
						Debug.WriteLine($"反序列化文件 {filePath} 时出错: {jsonEx.Message}");
						continue;
					}

					// 如果是第一个有效的 Option 对象，直接赋值给 combinedOption
					if (combinedOption == null)
					{
						combinedOption = currentOption;
					}
					else
					{
						// 合并当前 Option 对象的 Children 到 combinedOption 中
						if (currentOption.Children != null)
							foreach (var child in currentOption.Children)
								combinedOption.Children.Add(child);
						else
							Debug.WriteLine($"文件 {filePath} 中的 Children 为 null。");
					}
				}

				// 检查是否成功合并了至少一个 Option 对象
				if (combinedOption == null)
				{
					Debug.WriteLine("未能成功读取和合并任何有效的 Option JSON 文件。");
					return null;
				}

				return combinedOption;
			}
			catch (Exception ex)
			{
				// 捕获所有未处理的异常，并记录错误信息
				Debug.WriteLine($"在 GetOptinPropTypes 方法中发生异常: {ex.Message}");
				return null;
			}
		}

		private static string ExtractClassName(string content)
		{
			var pattern = @"window\.__EC_DOC_option_(\w+)\s*=";
			var match = Regex.Match(content, pattern);
			return match.Success ? match.Groups[1].Value : null;
		}

		public static string ToPascalCase(string input)
		{
			if (input == null) return "";

			if (input == "") return "";

			var parts = input.Split('_');
			if (parts[0].StartsWith("0") || parts[0].StartsWith("1")) parts[0] = $"D{parts[0]}";

			if (parts[0].StartsWith("$")) parts[0] = parts[0].Substring(1);

			for (var i = 0; i < parts.Length; i++)
			{
				if (parts[i] == "") continue;

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
				foreach (var propName in _currFilePropertyNames)
				{
					if (propName == "renderItem.return_bezierCurve.blur.style") Debug.Assert(true);

					if ((!propName.Contains('.') && !propName.Contains("-")) || !propName.StartsWith(property + ".") ||
						propName == property) continue;
					if (propName.Contains("-") && !propName.Contains(".")) return $"{ToPascalCase(property)}Type";


					var propName1 = propName.Replace("-", ".");
					var parts = propName1.Split('.');
					if (parts.Length <= 1) continue;
					var objectName = parts[parts.Length - 2];
					if (objectName == "<style_name>") objectName = "Rich";

					return className + "_" + ToPascalCase(objectName);
				}

				var a = Option.FindOptionItemByProp(optionItem, property);
				if (a == null)
				{
					Debug.WriteLine($"{optionItem.Prop}:{property}");
					return "object";
				}

				if (a.Prop != null && a.Prop == "icon") Debug.WriteLine($"{Option.InferTypeFromOptionItem(a)}");

				return Option.InferTypeFromOptionItem(a);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return "object";
			}
		}

		private static EChartConfigItem GetItem(string name)
		{
			name = name.Replace("<style_name>", "<style.name>");
			name = name.Replace(".xxx.", ".xxx:xxx.");
			name = name.Replace(".d0.", ".0.").Replace(".d1.", ".1.");
			for (var i = 0; i < _currFilePropertyNames.Count; i++)
				try
				{
					if (name == _currFilePropertyNames[i].Replace("<style_name>", "<style.name>"))
						return _currFileStru[_currFileStru.Keys.ToArray()[i]];
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
				}

			return new EChartConfigItem();
		}

		private static string GenerateChildClass(string className, List<string> propertyNames, OptionItem optionItem)
		{
			if (className.Contains("SeriesCustom.RenderItem")) Debug.Assert(true);

			className = className.Replace(".", "_").Replace("_<style_name> ", "");
			className = className.Replace(".", "_").Replace("_<style_name>", "");

			{
				var ss = className.Split('_');
				var s = ss.Aggregate("", (current, r) => current + ToPascalCase(r) + "_");
				s = s.Trim('_');
				className = s;
			}
			var a1 = className.Split('#');
			if (a1.Length > 1) className = $"{a1[0]}_{char.ToUpper(a1[1][0]) + a1[1].Substring(1)}";

			var classContent = $"    public class {className}\n    {{\n";


			foreach (var name1 in propertyNames)
			{
				var name = name1.Replace("#", "_").Replace(".", "_");
				var pp = name.Split('_');
				for (var i = 0; i < pp.Length; i++) pp[i] = pp[i].Substring(0, 1).ToLower() + pp[i].Substring(1);

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
					if (name.Contains("title")) Debug.Assert(true);

					var key1 = _currFileStru.Keys.FirstOrDefault(s => s == name);
					var ss1 = name.Split('.');
					var className1 = ToPascalCase(ss1[ss1.Length - 1]);
					if (name1.Contains("#"))
					{
						var ss2 = name1.Split('#');
						var s3 = ss2.Aggregate("", (current, r3) => current + ToPascalCase(r3) + "_");
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
								str += ToPascalCase(s) + "_";
							}

							str = str.Replace("_Return", "_Return_");


							str = str.Trim('_').Replace("-", "_").Replace("_<style.name> ", "")
								.Replace("_<style.name>", "");
							var ss2 = className.Split('_')[0].Replace("-", "_");
							if (name1.Contains("feature.") && name1.Contains(".title."))
								classContent +=
									$"        public string {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							else if (name1.Contains("feature.") && name1.Contains(".title"))
								classContent +=
									$"        public string {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							else if (name1.Contains("feature.") && name1.Contains("seriesIndex."))
								classContent +=
									$"        public object {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							else if (name1.Contains("feature.") && name1.Contains("option."))
								classContent +=
									$"        public object {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
							else if (name1.Contains("#"))
								classContent +=
									$"        public {className}_{className1} {ToPascalCase(ss1[ss1.Length - 1])} {{ get; set; }}\n\n";
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
			return System.Web.HttpUtility.HtmlDecode(Regex.Replace(result, "\\n", "\n        /// "));
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
							if (currentItem.ArrayItemType.Contains("custom")) Debug.Assert(true);

							if (currentParentClassName == "Series")
								currentClassName = $"{currentParentClassName}{ToPascalCase(currentItem.ArrayItemType)}";
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

				if (currentClassName == "SeriesCustom.RenderItem") Debug.Assert(true);

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
					if (child.Prop == null)
					{
						if (currentClassName == "Graphic.Elements")
							stack.Push((child, $"{currentClassName}_{ToCamelCase(child.ArrayItemType)}"));
						else
							stack.Push((child, $"{currentClassName}_{ToPascalCase(child.ArrayItemType)}"));
					}
					else
					{
						var p = $"{currentClassName.Replace("_", ".")}.{child.Prop}";
						if (child.Prop.Contains("_"))
							p = $"{currentClassName.Replace("_", ".")}.{child.Prop.Replace("_", "#")}";

						if (currentParentClassName.Contains("Graphic.Elements"))
							p = $"{ToCamelCase(currentClassName.Replace("_", "."))}.{child.Prop}";

						//p = p.Replace("graphic.elements", "elements").Replace("_", ".");
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
								if (!currentParentClassName.Contains("Graphic.Elements"))
								{
									p = $"{currentClassName}_{child.Prop}";
									index = p.IndexOf("_", StringComparison.Ordinal);
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
						if (child.IsObject || child.IsArray) stack.Push((child, currentClassName));
					}
			}

			foreach (var childClass in childClasses)
				if (childClass.Key.Contains("<style_name>"))
					classContent += GenerateChildClass(childClass.Key.Replace("_<style_name>", "").Replace("-", "_"),
						childClass.Value, optionItem);
				else
					classContent += GenerateChildClass(childClass.Key.Replace("-", "_"), childClass.Value, optionItem);
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
					if (!currentNode.Children.ContainsKey(part)) currentNode.Children[part] = new OptionNode(part);

					currentNode = currentNode.Children[part];
				}
			}

			return root;
		}

		public static void PrintOptionTree(OptionNode node, string indent = "")
		{
			Console.WriteLine(indent + node.Name);
			foreach (var child in node.Children.Values) PrintOptionTree(child, indent + "  ");
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
			if (!classProperties.ContainsKey(className)) classProperties[className] = new List<string>();

			foreach (var child in node.Children.Values)
			{
				classProperties[className].Add(child.Name);
				TraverseNodeRecursive(child, classProperties, className + ToPascalCase(child.Name));
			}
		}


		// 辅助函数：推断类型，支持根据 uiControl 定义属性类型
		private static List<string> PrepareAllPropertyNames(Dictionary<string, EChartConfigItem> rootObject)
		{
			var allPropertyNames = new List<string>();
			foreach (var prop in rootObject.Keys)
			{
				var prop1 = prop.Replace("-", ".");
				allPropertyNames.Add(GetLowString(prop1));
			}

			return allPropertyNames;
		}


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

				foreach (var r in options1) options[r.Key] = r.Value;
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
			var newList = (from r in ss where r != "" select char.ToLower(r[0]) + r.Substring(1)).ToList();
			return string.Join(".", newList);
		}

		/// <summary>
		/// 对指定属性名称进行优化处理，将具有相同属性结构的类进行分组与更新。
		/// 此方法会对 classInfos 中的类进行分析，将包含给定属性（propertyNameToFind）的类根据属性结构进行分组，
		/// 然后更新这些类的属性类型以及子类信息。
		/// </summary>
		/// <param name="propertyNameToFind">要查找并优化处理的属性名称。</param>
		/// <param name="classInfos"></param>
		public static void OptimizedClassInfo(string propertyNameToFind, Dictionary<string, ClassInfo> classInfos)
		{
			try
			{
				if (string.IsNullOrEmpty(propertyNameToFind))
					throw new ArgumentException(@"Property name to find cannot be null or empty.",
						nameof(propertyNameToFind));

				var classesWithProperty = new HashSet<string>();
				var classPropertyMaps = new Dictionary<string, ClassInfo>();

				// 收集所有包含特定属性的类，并记录它们的属性
				foreach (var classInfo in classInfos)
					foreach (var property in classInfo.Value.Properties)
					{
						if (property.PropertyName != propertyNameToFind) continue;
						try
						{
							var key = $"{classInfo.Key}_{ToPascalCase(property.PropertyName)}";

							if (propertyNameToFind == "rich")
							{
								var key1 = $"{key}_<styleName>";
								classPropertyMaps[key] = classInfos[key1];
								classesWithProperty.Add(key);
							}
							else
							{
								if (classInfos.TryGetValue(key, out var info))
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

				var samePropertyClasses = new Dictionary<string, List<string>>();
				var n = 0;
				var processedClasses = new HashSet<string>();

				foreach (var className in classesWithProperty)
				{
					if (processedClasses.Contains(className)) continue;

					var currentClassProperties = classPropertyMaps[className].Properties;
					var matchingClasses = new List<string> { className };

					foreach (var otherClassName in classesWithProperty)
					{
						if (processedClasses.Contains(otherClassName) || otherClassName == className) continue;

						var otherClassProperties = classPropertyMaps[otherClassName].Properties;
						if (PropertiesMatch(currentClassProperties, otherClassProperties))
							matchingClasses.Add(otherClassName);
					}

					samePropertyClasses.Add(
						matchingClasses.Count == 1
							? $"{matchingClasses[0]}"
							: $"{ToPascalCase(propertyNameToFind)}{n++}", matchingClasses);
					foreach (var matchedClass in matchingClasses) processedClasses.Add(matchedClass);
				}

				foreach (var r in classInfos)
				{
					var key = r.Key;
					if (r.Key != r.Value.ClassName) key = r.Value.ClassName;
					foreach (var r1 in samePropertyClasses)
					{
						foreach (var p in r.Value.Properties)
						{
							if (p.PropertyName != propertyNameToFind) continue;
							var k1 = $"{r.Key}_{ToPascalCase(propertyNameToFind)}";
							if (!r1.Value.Contains(k1)) continue;
							p.PropertyType = r1.Key;
						}

						foreach (var r2 in r1.Value)
						{
							var k2 = r2.Replace(r.Key, key);
							if (r.Key != r2) continue;
							ClassInfo.UpdateChildClasses(r.Value, r.Value.ClassName, r1.Key);
							break;
						}
					}
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
			if (properties1.Count != properties2.Count) return false;
			// 将属性名称转换为集合，以便进行集合比较
			var set1 = properties1.Select(p => (p.PropertyName, p.PropertyType)).ToHashSet();
			var set2 = properties2.Select(p => (p.PropertyName, p.PropertyType)).ToHashSet();

			// 比较两个属性名称集合是否相等
			return set1.SetEquals(set2);
		}

		/// <summary>
		/// 根据相同属性类的信息，对给定类集合中的属性类型和子类信息进行更新。
		/// 此方法通过对比 <paramref name="samePropertyClasses"/> 中的分组信息，将匹配的属性类型更新为新的类型名，
		/// 并递归更新相关类的信息。
		/// </summary>
		/// <param name="samePropertyClasses">
		/// 字典结构，键为合并后的类型名，值为该类型名所对应的一组类名字符串列表。
		/// 例如：{"NewTypeName": ["SomeClassName", "AnotherClassName"]}。
		/// </param>
		/// <param name="classInfos">
		/// 当前项目中所有类信息的字典结构，键为类名，值为对应的 <see cref="ClassInfo"/> 对象。
		/// </param>
		/// <param name="propertyNameToFind">要匹配和更新的属性名称。</param>
		private static void UpdateClassInfoWithMergedTypes(
			Dictionary<string, List<string>> samePropertyClasses,
			Dictionary<string, ClassInfo> classInfos,
			string propertyNameToFind)
		{
			// 遍历所有类信息对象
			foreach (var classInfo in classInfos.Values)
			{
				// 更新类的属性类型
				foreach (var property in classInfo.Properties)
				{
					// 仅处理匹配指定属性名的属性
					if (property.PropertyName != propertyNameToFind) continue;

					// 遍历合并后的类型分组，将符合条件的属性类型更新为新的类型名
					foreach (var group in samePropertyClasses)
					{
						// 根据当前类名和属性名构造键，用于检查此属性是否属于该分组
						var key = $"{classInfo.ClassName}_{ToPascalCase(property.PropertyName)}";

						// 如果该分组包含此键，则更新该属性的类型
						if (group.Value.Contains(key))
						{
							property.PropertyType = group.Key;
							break; // 找到匹配分组即退出内层循环
						}
					}
				}

				// 更新子类信息
				foreach (var group in samePropertyClasses)
					// 如果当前类的类名包含在某个分组中，则使用该分组键更新子类信息
					foreach (var className in group.Value)
						if (classInfo.ClassName == className)
						{
							// 将当前类及其子类中对应旧名称的内容替换为分组键
							ClassInfo.UpdateChildClasses(classInfo, classInfo.ClassName, group.Key);
							break; // 已更新完成，退出循环
						}
			}
		}

		/// <summary>
		/// 解析指定的 JSON 文件，并生成对应的类信息。
		/// </summary>	
		/// <param name="jsonFilePath">JSON 文件的完整路径。</param>
		/// <param name="optionItem">选项项，用于生成类信息。</param>
		public static void ParseClasses(string jsonFilePath, OptionItem optionItem, Dictionary<string, ClassInfo> classInfos)
		{
			// 检查指定的 JSON 文件是否存在
			if (!File.Exists(jsonFilePath))
			{
				Debug.WriteLine($"文件 {jsonFilePath} 不存在，请检查路径。");
				return;
			}
			if (jsonFilePath.Contains("geo.js"))
			{
				Debug.WriteLine("");
			}
			Debug.WriteLine($"正在解析文件: {jsonFilePath}");

			string fileContent;
			try
			{
				// 读取文件内容
				fileContent = File.ReadAllText(jsonFilePath);
			}
			catch (IOException ioEx)
			{
				Debug.WriteLine($"读取文件 {jsonFilePath} 时出错: {ioEx.Message}");
				return;
			}

			// 提取类名并移除前缀 "gl_"
			var className = ExtractClassName(fileContent)?.Replace("gl_", "");
			if (string.IsNullOrEmpty(className))
			{
				Debug.WriteLine("无法解析类名，请检查文件内容格式。");
				return;
			}

			// 查找 JSON 数据的起始位置
			var jsonStartIndex = fileContent.IndexOf("{", StringComparison.Ordinal);
			if (jsonStartIndex == -1)
			{
				Debug.WriteLine("无法找到 JSON 数据，请检查文件内容格式。");
				return;
			}
			// 提取 JSON 字符串
			var json = fileContent.Substring(jsonStartIndex);

			try
			{
				// 反序列化 JSON 为字典结构
				_currFileStru = JsonConvert.DeserializeObject<Dictionary<string, EChartConfigItem>>(json);
				if (_currFileStru == null)
				{
					Debug.WriteLine("反序列化后的文件结构为空，请检查 JSON 格式。");
					return;
				}

				// 准备所有属性名称
				_currFilePropertyNames = PrepareAllPropertyNames(_currFileStru);
				if (_currFilePropertyNames == null || !_currFilePropertyNames.Any())
				{
					Debug.WriteLine("准备属性名称时出错或属性列表为空。");
					return;
				}
			}
			catch (JsonSerializationException ex)
			{
				Debug.WriteLine($"反序列化 JSON 到 fileStru 时出错: {ex.Message}");
				return;
			}

			// 生成类项
			var optionItems = GenerateClassItem();
			if (optionItems == null || !optionItems.ContainsKey(className.Replace("_", "-")))
			{
				Debug.WriteLine($"生成的类项中不包含类名: {className}");
				return;
			}

			// 获取示例基础选项
			var example = optionItems[className.Replace("_", "-")].ExampleBaseOptions;
			if (example == null)
			{
				Debug.WriteLine($"类 {className} 的示例基础选项为空。");
				//return;
			}

			// 生成类信息
			var classInfo = GenerateClassInfo(optionItem, className, classInfos);
			if (classInfo == null)
			{
				Debug.WriteLine($"生成类信息时出错，类名: {className}");
				return;
			}

			// 设置示例	
			classInfo.Example = example;

		}

		public static void GenerateClassFiles(string jsonFilePath, OptionItem optionItem,
			Dictionary<string, ClassInfo> classInfos, Dictionary<string, ClassInfo> newClassInfos, string rootDirectory, bool separateChildClasses = false)
		{
			if (!File.Exists(jsonFilePath))
			{
				Debug.WriteLine($"文件 {jsonFilePath} 不存在，请检查路径。");
				return;
			}

			Debug.WriteLine($"正在解析文件: {jsonFilePath}");

			string fileContent;
			try
			{
				fileContent = File.ReadAllText(jsonFilePath);
			}
			catch (IOException ioEx)
			{
				Debug.WriteLine($"读取文件 {jsonFilePath} 时出错: {ioEx.Message}");
				return;
			}

			var className = ExtractClassName(fileContent)?.Replace("gl_", "");
			if (string.IsNullOrEmpty(className))
			{
				Debug.WriteLine("无法解析类名，请检查文件内容格式。");
				return;
			}

			var jsonStartIndex = fileContent.IndexOf("{", StringComparison.Ordinal);
			if (jsonStartIndex == -1)
			{
				Debug.WriteLine("无法找到 JSON 数据，请检查文件内容格式。");
				return;
			}

			var json = fileContent.Substring(jsonStartIndex);

			try
			{
				_currFileStru = JsonConvert.DeserializeObject<Dictionary<string, EChartConfigItem>>(json);
				if (_currFileStru == null)
				{
					Debug.WriteLine("反序列化后的文件结构为空，请检查 JSON 格式。");
					return;
				}

				_currFilePropertyNames = PrepareAllPropertyNames(_currFileStru);
				if (_currFilePropertyNames == null || !_currFilePropertyNames.Any())
				{
					Debug.WriteLine("准备属性名称时出错或属性列表为空。");
					return;
				}
			}
			catch (JsonSerializationException ex)
			{
				Debug.WriteLine($"反序列化 JSON 到 fileStru 时出错: {ex.Message}");
				return;
			}

			var item = GenerateClassItem();
			if (item == null || !item.ContainsKey(className.Replace("_", "-")))
			{
				Debug.WriteLine($"生成的类项中不包含类名: {className}");
				return;
			}

			var desc = item[className.Replace("_", "-")].Desc;
			var example = item[className.Replace("_", "-")].ExampleBaseOptions;

			var classInfo = GenerateClassInfo2(optionItem, className, _currFileStru, classInfos, ref newClassInfos);
			if (classInfo == null)
			{
				Debug.WriteLine($"生成类信息时出错，类名: {className}");
				return;
			}
			// 构造类文件内容
			var content = new StringBuilder();
			content.Append(
				"using System;\nusing System.Collections.Generic;\nusing Newtonsoft.Json;\n\nnamespace Echarts\n{\n");

			// 添加类的注释
			content.Append("        /// <summary>\n");
			content.Append($"        /// {StripHtmlTags(Uri.UnescapeDataString(desc))}\n");
			content.Append("        /// </summary>\n");

			classInfo.Example = example;

			if (!separateChildClasses)
			{

				var classContent = GenerateClassContent(classInfo);
				content.Append(classContent);

				var outputDir = Path.Combine(rootDirectory, "cs");
				Directory.CreateDirectory(outputDir);

				var outputFilePath = Path.Combine(outputDir, $"{ToPascalCase(classInfo.ClassName)}.cs");
				try
				{
					File.WriteAllText(outputFilePath, content.ToString());
					Debug.WriteLine($"类文件已生成: {outputFilePath}");
				}
				catch (IOException ioEx)
				{
					Debug.WriteLine($"写入类文件时出错: {ioEx.Message}");
				}
			}
			else
			{
				classInfo.Description = desc;
				var dic = GenerateClassContentMore(classInfo);
				var outputDir = rootDirectory;
				Directory.CreateDirectory(outputDir);
				if (rootDirectory.Contains("series"))
				{
					outputDir = Path.Combine(outputDir, $"{classInfo.ClassName}");
					Directory.CreateDirectory(outputDir);
				}
				foreach (var r in dic)
				{
					var outputFilePath = Path.Combine(outputDir, $"{r.Key}.cs");
					try
					{
						File.WriteAllText(outputFilePath, r.Value);
						Debug.WriteLine($"类文件已生成: {outputFilePath}");
					}
					catch (IOException ioEx)
					{
						Debug.WriteLine($"写入类文件时出错: {ioEx.Message}");
					}
				}
			}


		}


		/// <summary>
		/// 查找具有相同属性类型的类，并将其合并。
		/// 在所有类中查找匹配项，若类对存在相同的属性结构，则将这些类合并。
		/// </summary>
		/// <param name="classInfos">所有类信息的字典，键为类名，值为对应的 ClassInfo。</param>
		private static void MergeSimilarClasses(Dictionary<string, ClassInfo> classInfos)
		{
			// foundPairs 用于存储找到的类对（如 (ClassA, ClassB)）
			var foundPairs = new HashSet<(string, string)>();

			// 遍历每个类，尝试与其他类比较是否有相同属性类型结构
			foreach (var rootClass in classInfos.Values)
			{
				// visitedClasses 用于标记当前 rootClass 流程中已经访问过的类，避免重复处理
				var visitedClasses = new HashSet<string>();

				// 尝试将当前类加入 visitedClasses，如果失败表示重复则跳过
				if (!visitedClasses.Add(rootClass.ClassName)) continue;

				// 与其他类比较
				foreach (var otherClass in classInfos.Values)
				{
					// 同名或已访问过则跳过
					if (otherClass.ClassName == rootClass.ClassName || visitedClasses.Contains(otherClass.ClassName)) continue;

					// 判断两个类是否有相同的属性类型结构
					if (HaveSamePropertiesType(rootClass, otherClass, visitedClasses, classInfos))
						foundPairs.Add((rootClass.ClassName, otherClass.ClassName));
				}
			}

			// 对找到的类对进行合并
			MergeSimilarClassesCore(foundPairs, classInfos);
		}

		/// <summary>
		/// 将找到的相似类（foundPairs）进行合并处理，根据代表类映射进行最终的类映射并更新类信息。
		/// </summary>
		/// <param name="foundPairs">包含已识别出的相似类对的集合。</param>
		/// <param name="classInfos">所有类信息字典。</param>
		private static void MergeSimilarClassesCore(HashSet<(string, string)> foundPairs,
			Dictionary<string, ClassInfo> classInfos)
		{
			var representativeMap = new Dictionary<string, string>(); // 每个类和其代表类的映射关系

			// 初始化每个类的代表为自己
			foreach (var (class1, class2) in foundPairs)
			{
				if (!representativeMap.ContainsKey(class1)) representativeMap[class1] = class1;
				if (!representativeMap.ContainsKey(class2)) representativeMap[class2] = class2;
			}

			// 合并类之间的关系
			foreach (var (class1, class2) in foundPairs)
			{
				var rep1 = FindRepresentative(representativeMap, class1);
				var rep2 = FindRepresentative(representativeMap, class2);

				if (rep1 != rep2)
					// 合并：将 rep2 的所有类归并到 rep1
					representativeMap[rep2] = rep1;
			}

			// 生成代表类映射的快照，避免在遍历时修改集合
			var keys = representativeMap.Keys.ToList();

			// 路径压缩，更新所有类的代表类
			foreach (var cls in keys) representativeMap[cls] = FindRepresentative(representativeMap, cls);

			// 构造最终的 classMap
			var classMap = new Dictionary<string, List<string>>();
			foreach (var cls in representativeMap.Keys)
			{
				var repCls = representativeMap[cls];
				if (!classMap.ContainsKey(repCls)) classMap[repCls] = new List<string>();
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

		/// <summary>
		/// 查找给定类的最终代表类并进行路径压缩。
		/// </summary>
		/// <param name="representativeMap">映射关系字典，键为类名，值为其代表类。</param>
		/// <param name="cls">要查找的类名。</param>
		/// <returns>最终的代表类名。</returns>		
		private static string FindRepresentative(Dictionary<string, string> representativeMap, string cls)
		{
			if (representativeMap[cls] != cls)
				// 路径压缩：递归查找并直接更新代表类
				representativeMap[cls] = FindRepresentative(representativeMap, representativeMap[cls]);
			return representativeMap[cls];
		}

		/// <summary>
		/// 判断两个类是否具有相同的属性类型结构。
		/// 若属性数量或类型结构不相同则返回false。
		/// 同时在比较中可能会递归查找子类信息。
		/// </summary>
		/// <param name="classInfo1">第一个类信息。</param>
		/// <param name="classInfo2">第二个类信息。</param>
		/// <param name="visited">已访问过的类名集合，防止递归循环。</param>
		/// <param name="classInfos">类信息字典，用于递归查找类。</param>
		/// <returns>如果两个类具有相同的属性结构，则返回true，否则返回false。</returns>
		private static bool HaveSamePropertiesType(ClassInfo classInfo1, ClassInfo classInfo2, HashSet<string> visited,
			Dictionary<string, ClassInfo> classInfos = null)
		{
			if (classInfo1 == null) return false;
			if (classInfo2 == null) return false;
			if (classInfo1.Properties.Count != classInfo2.Properties.Count) return false;

			// 比较每个属性
			for (var i = 0; i < classInfo1.Properties.Count; i++)
				try
				{
					var prop1 = classInfo1.Properties[i];
					var prop2 = classInfo2.Properties.FirstOrDefault(p => p.PropertyName == prop1.PropertyName);

					if (prop2 == null) return false;

					if (prop1.PropertyType == prop2.PropertyType) continue;

					// 若类型不同，则需要进一步检查类型对应的类结构是否相同
					var ci2 = FindClassInfo(prop2.PropertyType, visited, classInfos);
					var ci1 = FindClassInfo(prop1.PropertyType, visited, classInfos);

					// 递归比较属性对应的类结构
					if (!HaveSamePropertiesType(ci1, ci2, visited, classInfos))
						return false;
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
				}

			return true;
		}

		/// <summary>
		/// 根据类名在 classInfos 中查找对应的 ClassInfo 对象。
		/// 若未找到则递归在子类中查找。
		/// </summary>
		/// <param name="className">要查找的类名。</param>
		/// <param name="visited">已访问过的类名集合，用于防止递归死循环。</param>
		/// <param name="classInfos">类信息字典。</param>
		/// <returns>找到的 ClassInfo 对象，若找不到则返回 null。</returns>
		private static ClassInfo FindClassInfo(string className, HashSet<string> visited = null,
			Dictionary<string, ClassInfo> classInfos = null)
		{
			// 如果访问过的类集合为空，则创建一个新的HashSet
			if (visited == null) visited = new HashSet<string>();

			// 查找类信息，如果找到并且没有访问过，则返回
			var classInfoKey = classInfos.Keys.FirstOrDefault(c => c == className && !visited.Contains(c));
			if (classInfoKey == null) return null;
			var classInfo = classInfos[classInfoKey];
			if (classInfo != null && visited.Add(classInfo.ClassName)) return classInfo;

			// 如果当前类没有找到或者已经访问过，则递归搜索子类
			foreach (var rootClass in classInfos.Values)
			{
				if (!visited.Add(rootClass.ClassName)) continue; // 如果已经访问过，则跳过

				// 标记为已访问
				foreach (var childClass in rootClass.ChildClasses)
				{
					// 递归搜索子类
					classInfo = FindClassInfo(className, visited, classInfos);
					if (classInfo != null) return classInfo;
				}
			}

			// 如果没有找到，则返回null
			return null;
		}

		/// <summary>
		/// 根据给定的 OptionItem 创建相应的 ClassInfo 对象，并递归生成其子类信息。
		/// </summary>
		/// <param name="optionItem">需要处理的 OptionItem。</param>
		/// <param name="className">类名。</param>
		/// <param name="classInfos"></param>
		/// <returns>生成的 ClassInfo 对象。</returns>
		private static ClassInfo GenerateClassInfo(OptionItem optionItem, string className,
			Dictionary<string, ClassInfo> classInfos)
		{
			var classInfo = new ClassInfo
			{
				ClassName = ToPascalCase(className),
				Description = _currFileStru.ContainsKey(className.Replace("_", "-"))
					? _currFileStru[className.Replace("_", "-")].Description
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
						if (child.IsArray) info.PropertyType = $"{info.PropertyType}[]";
						currentClassInfo.Properties.Add(info);
					}

					if (child.IsObject || child.IsArray)
					{
						var newinfo = new ClassInfo
						{
							ClassName = propertyType.Replace(":xxx", ""),
							Properties = new List<PropertyInfo>(),
							Description = GetItem(propertyName).Description,
							ChildClasses = new List<ClassInfo>()
						};
						stack.Push((child, newinfo));
						currentClassInfo.ChildClasses.Add(newinfo);
						if (classInfos == null) classInfos = new Dictionary<string, ClassInfo>();
						classInfos[newinfo.ClassName] = newinfo;
					}
				}
			}

			classInfos[classInfo.ClassName] = classInfo;
			return classInfo;
		}

		/// <summary>
		/// 在 classInfos 中检查给定类名是否存在，并返回对应的 ClassInfo。
		/// </summary>
		/// <param name="className">要检查的类名。</param>
		/// <param name="classInfos">类信息字典。</param>
		/// <param name="classInfo">输出参数，当找到匹配类时返回对应的 ClassInfo。</param>
		/// <returns>如果找到匹配的类信息且名称匹配则返回 true，否则返回 false。</returns>
		private static bool CheckClass(string className, Dictionary<string, ClassInfo> classInfos,
			out ClassInfo classInfo)
		{
			// 检查 _classInfos 字典的键中是否包含给定的类名 className
			if (classInfos.Keys.Contains(className))
			{
				// 如果包含，将对应的 ClassInfo 对象赋值给输出参数 classInfo
				classInfo = classInfos[className];
				// 返回一个布尔值，指示 classInfo 的 ClassName 属性是否与输入的 className 相等
				return classInfo.ClassName == className;
			}

			if (_infos[0].Keys.Contains(className))
			{
				// 如果包含，将对应的 ClassInfo 对象赋值给输出参数 classInfo
				classInfo = _infos[0][className];
				// 返回一个布尔值，指示 classInfo 的 ClassName 属性是否与输入的 className 相等
				return classInfo.ClassName == className;
			}

			// 遍历 _classInfos 字典，查找 ClassName 属性与给定类名 className 相等的项
			foreach (var r in _infos[0].Where(r => r.Value.ClassName == className))
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

		private static ClassInfo GenerateClassInfo2(OptionItem optionItem, string className,
			Dictionary<string, EChartConfigItem> fileStru, Dictionary<string, ClassInfo> oldClassInfos,
			ref Dictionary<string, ClassInfo> newClassInfos)
		{

			if (newClassInfos == null) newClassInfos = new Dictionary<string, ClassInfo>();
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
			classInfo.NewClassName = classInfo.ClassName;
			stack.Push((optionItem, classInfo));

			while (stack.Count > 0)
			{
				var (currentItem, currentClassInfo) = stack.Pop();
				if (currentItem.Children == null) continue;
				if (currentItem.Children.Count == 1 && currentItem.Prop == "rich")
				{
					currentClassInfo.ClassName =
						$"{currentClassInfo.ClassName}_{ToPascalCase(currentItem.Children[0].Prop)}";
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
							info.EnumString = item.UiControl.Options;
						if (child.IsArray) info.PropertyType = $"{info.PropertyType}[]";
						currentClassInfo.Properties.Add(info);
						if (info.PropertyName == "padding") info.PropertyType = "ArrayOrSingle";
					}

					if (!child.IsObject && !child.IsArray) continue;

					if (!CheckClass(propertyType, oldClassInfos, out var oldClassInfo))
					{
						if (oldClassInfo == null || info == null) continue;
						info.PropertyType = oldClassInfo.ClassName;
						if (info.PropertyType == "Rich0") info.PropertyType = "Dictionary <string,Rich0>";

						var s = $"{currentClassInfo.ClassName}_{propertyName}";
						var index = s.IndexOf("_", StringComparison.Ordinal);
						s = s.Substring(index + 1).Replace("_", ".");
						s = GetLowString(s).Replace("styleName", "style_name");
						s = s.Replace("styleName", "style_name");

						var newinfo1 = new ClassInfo()
						{
							ClassName = propertyType,
							NewClassName = oldClassInfo.ClassName.Replace(":xxx", ""),
							Properties = new List<PropertyInfo>(),
							Description = GetItem(s).Description,
							ChildClasses = new List<ClassInfo>()
						};
						if (newinfo1.Description == null)
						{
							foreach (var r in currentClassInfo.Properties)
							{
								if (r.PropertyType == newinfo1.ClassName)
								{
									newinfo1.Description = r.PropertyDescription;
								}
								else if (r.PropertyType == newinfo1.NewClassName)
								{
									var a = ToCamelCase(newinfo1.ClassName).ToLower();
									a = a.Replace("graphic_elements_", "elements-");
									if (fileStru.TryGetValue(a, out var b))
									{
										Debug.WriteLine($"{newinfo1.ClassName}=>{b.Description}");
										newinfo1.Description = b.Description;
									}
									else
									{
										Debug.WriteLine($"{newinfo1.ClassName}");
										newinfo1.Description = r.PropertyDescription;

									}

								}
							}
						}

						if (newClassInfos.Keys.Contains(newinfo1.ClassName)) continue;

						if (newinfo1.NewClassName != null)
						{
							if (newClassInfos.Keys.Contains(newinfo1.NewClassName)) continue;
							newClassInfos[newinfo1.NewClassName] = newinfo1;
						}

						currentClassInfo.ChildClasses.Add(newinfo1);
						newClassInfos[newinfo1.ClassName] = newinfo1;
						stack.Push((child, newinfo1));
					}
					else
					{

						var s = $"{currentClassInfo.ClassName}_{propertyName}";
						var index = s.IndexOf("_", StringComparison.Ordinal);
						s = s.Substring(index + 1).Replace("_", ".");
						s = GetLowString(s).Replace("styleName", "style_name");
						s = s.Replace("styleName", "style_name");
						var newinfo = new ClassInfo
						{
							ClassName = propertyType,
							NewClassName = propertyType,
							Properties = new List<PropertyInfo>(),
							Description = GetItem(s).Description,
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
							//Debug.Assert(true);
						}
					}
				}

				if (currentClassInfo.NewClassName != null) currentClassInfo.ClassName = currentClassInfo.NewClassName;
			}

			return classInfo;
		}

		private static string GenerateClassContent(ClassInfo classInfo)
		{
			var classContent = new StringBuilder();

			if (classInfo.ClassName.Contains("_<styleName>") && (classInfo.ChildClasses == null || classInfo.ChildClasses.Count == 0)) return "";
			classContent.AppendLine("    /// <summary>");
			classContent.AppendLine($"    /// {StripHtmlTags(Uri.UnescapeDataString($"{classInfo.Description}"))}");
			classContent.AppendLine("    /// </summary>");
			classContent.AppendLine($"    public class {classInfo.ClassName.Replace("_<styleName>", "")}");
			classContent.AppendLine("    {");

			foreach (var property in classInfo.Properties)
			{
				classContent.AppendLine("        /// <summary>");
				classContent.AppendLine(
					$"        /// {StripHtmlTags(Uri.UnescapeDataString($"{property.PropertyDescription}"))}");
				classContent.AppendLine("        /// </summary>");
				classContent.AppendLine($"        [JsonProperty(\"{property.PropertyName}\")]");
				if (property.PropertyName == "type")
				{
					if (property.DefaultValue != null && property.PropertyType == "string")
					{
						classContent.AppendLine(
							$"        public {property.PropertyType.Replace("_<styleName>", "")} {ToPascalCase(property.PropertyName)} {{ get; set; }}=\"{property.DefaultValue.ToString().Trim('\'')}\";");
					}
					else
					{
						classContent.AppendLine(
							$"        public {property.PropertyType.Replace("_<styleName>", "")} {ToPascalCase(property.PropertyName)} {{ get; set; }}");
					}

				}
				else
				{
					classContent.AppendLine(
						$"        public {property.PropertyType.Replace("_<styleName>", "")} {ToPascalCase(property.PropertyName)} {{ get; set; }}");

				}
				classContent.AppendLine();
			}

			classContent.AppendLine("    }");
			if (classInfo.ChildClasses == null || classInfo.ChildClasses.Count == 0) return classContent.ToString();

			foreach (var info in classInfo.ChildClasses)
			{
				var content = GenerateClassContent(info);
				if (!string.IsNullOrEmpty(content)) classContent.AppendLine(content);
			}

			return classContent.ToString();
		}
		private static Dictionary<string, string> GenerateClassContentMore(ClassInfo classInfo, Dictionary<string, string> dic = null)
		{
			var classContent = new StringBuilder();


			classContent.Append("using System;\nusing System.Collections.Generic;\nusing Newtonsoft.Json;\n\nnamespace Echarts\n{\n");
			classContent.AppendLine("    /// <summary>");
			classContent.AppendLine($"    /// {StripHtmlTags(Uri.UnescapeDataString($"{classInfo.Description}"))}");
			classContent.AppendLine("    /// </summary>");
			if (dic == null)
			{
				dic = new Dictionary<string, string>();
			}
			if (classInfo.ClassName.Contains("_<styleName>") && (classInfo.ChildClasses == null || classInfo.ChildClasses.Count == 0)) return dic;
			classContent.AppendLine($"    public class {classInfo.ClassName.Replace("_<styleName>", "")}");
			classContent.AppendLine("    {");

			foreach (var property in classInfo.Properties)
			{
				classContent.AppendLine("        /// <summary>");
				classContent.AppendLine(
					$"        /// {StripHtmlTags(Uri.UnescapeDataString($"{property.PropertyDescription}"))}");
				classContent.AppendLine("        /// </summary>");
				classContent.AppendLine($"        [JsonProperty(\"{property.PropertyName}\")]");
				if (property.PropertyName == "type")
				{
					if (property.DefaultValue != null && property.PropertyType == "string")
					{
						classContent.AppendLine(
							$"        public {property.PropertyType.Replace("_<styleName>", "")} {ToPascalCase(property.PropertyName)} {{ get; set; }}=\"{property.DefaultValue.ToString().Trim('\'')}\";");
					}
					else
					{
						classContent.AppendLine(
							$"        public {property.PropertyType.Replace("_<styleName>", "")} {ToPascalCase(property.PropertyName)} {{ get; set; }}");
					}

				}
				else
				{
					classContent.AppendLine(
						$"        public {property.PropertyType.Replace("_<styleName>", "")} {ToPascalCase(property.PropertyName)} {{ get; set; }}");

				}
				classContent.AppendLine();
			}

			classContent.AppendLine("    }");
			classContent.AppendLine(" }");
			dic.Add(classInfo.ClassName, classContent.ToString());
			if (classInfo.ChildClasses == null || classInfo.ChildClasses.Count == 0) return dic;
			foreach (var info in classInfo.ChildClasses)
			{
				if (classInfo.ClassName.Contains("Series"))
				{
					Debug.WriteLine("");
				}
				_ = GenerateClassContentMore(info, dic);
			}

			return dic;
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