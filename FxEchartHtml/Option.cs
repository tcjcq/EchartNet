using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FxEchartHtml
{
	/// <summary>
	/// 表示 ECharts 配置中的选项集合（根对象或子对象）。
	/// 包含一个或多个子项（OptionItem）。
	/// </summary>
	public class Option
	{
		/// <summary>
		/// 当前 Option 下的子项集合。
		/// </summary>
		public List<OptionItem> Children { get; set; }

		/// <summary>
		/// 在指定的 OptionItem 中，根据一个用点号分隔的属性名路径（如 "AAA.BBB.CCC"），递归查找对应的子项。
		/// </summary>
		/// <param name="option">要查找的起点 OptionItem。</param>
		/// <param name="prop">要查找的属性路径，如 "series.data"</param>
		/// <returns>若找到对应的子项则返回该 OptionItem，否则返回 null。</returns>
		public static OptionItem FindOptionItemByProp(OptionItem option, string prop)
		{
			if (option?.Children == null) return null;

			// 将 "elements." 前缀替换为 "elements_" 以规避关键字冲突
			prop = prop.Replace("elements.", "elements_");

			var propParts = prop.Split('.');
			OptionItem currentItem = null;
			var currentChildren = option.Children;

			foreach (var part in propParts)
			{
				// 首先在当前层级中查找名称匹配的子项
				currentItem = currentChildren?.FirstOrDefault(item => item.Prop == part);
				if (currentItem != null)
				{
					currentChildren = currentItem.Children;
				}
				else
				{
					// 若未找到，则尝试在子项的子集结构中查找与 part 匹配的 ArrayItemType
					if (!prop.Contains("elements_") || currentChildren == null)
						return null;

					// 检查当前层级的所有子项，尝试匹配 part 中包含的 arrayItemType
					bool found = false;
					foreach (var child in currentChildren)
					{
						currentItem = child.Children?.FirstOrDefault(item => part.Contains(item.ArrayItemType));
						if (currentItem != null)
						{
							found = true;
							break;
						}
					}

					if (!found) return null;
					currentChildren = currentItem.Children;
				}
			}

			return currentItem;
		}

		/// <summary>
		/// 从给定的 OptionItem 中推断该属性应对应的 C# 类型。
		/// 推断逻辑基于 OptionItem 的类型信息、是否为数组、默认值类型等。
		/// </summary>
		/// <param name="optionItem">要推断类型的 OptionItem。</param>
		/// <returns>推断得到的 C# 类型字符串。</returns>
		public static string InferTypeFromOptionItem(OptionItem optionItem)
		{
			// 若为空或声明为对象类型，则返回 "object"
			if (optionItem == null || optionItem.IsObject) return "object";

			// 若是数组类型，根据 ArrayItemType 确定集合类型
			if (optionItem.IsArray)
			{
				return optionItem.ArrayItemType != null ? $"List<{optionItem.ArrayItemType}>" : "List<object>";
			}

			// 若有特定 Type 信息则根据其内容推断
			if (optionItem.Type != null)
			{
				var typeStr = optionItem.Type.ToString().ToLower();
				switch (typeStr)
				{
					case "string":
					case "function":
					case "*":
						return "string";
					case "number":
					case "numbr":
					case "prefix":
						return "double?";
					case "int":
						return "int?";
					case "bool":
					case "boolean":
						return "bool?";
					case "color":
						return "Color";
					case "array":
						return "double[]";
				}
				// 对复杂类型调用专门的处理方法
				return HandleComplexType(optionItem, typeStr);
			}

			// 若未指定 Type，则根据默认值类型推断
			return InferTypeFromDefault(optionItem);
		}

		#region 私有辅助方法

		/// <summary>
		/// 处理复杂或混合类型（如 "string|number"、"array|string" 等）的推断逻辑。
		/// </summary>
		/// <param name="optionItem">当前 OptionItem。</param>
		/// <param name="type">已转为小写的类型描述字符串。</param>
		/// <returns>基于复杂类型组合规则返回合适的 C# 类型。</returns>
		private static string HandleComplexType(OptionItem optionItem, string type)
		{
			// 同时包含 "string" 和 "number"
			if (type.Contains("string") && type.Contains("number"))
			{
				// 若还包含 "array"
				return type.Contains("array") ? "StringOrNumber[]" : "StringOrNumber";
			}
			if (type.Contains("function") && type.Contains("number"))
			{
				return "StringOrNumber";
			}

			// "array" 同时与 "boolean" 或 "string" 或 "number" 搭配均返回 "ArrayOrSingle"
			if (type.Contains("array") && type.Contains("boolean")
				|| type.Contains("array") && type.Contains("string")
				|| type.Contains("array") && type.Contains("number"))
			{
				return "ArrayOrSingle";
			}

			// "string" 搭配 "function"、"html"、"echartsinstance" 均返回 "string"
			if (type.Contains("string") && (type.Contains("function") || type.Contains("html") || type.Contains("echartsinstance")))
			{
				return "string";
			}

			if (type.Contains("function") && type.Contains("color"))
			{
				return "Color";
			}

			if (type.Contains("boolean") && type.Contains("number"))
			{
				return "NumberOrBool";
			}

			// "string" 与 "boolean" 搭配：
			// 若还包含 "array" 则返回 "StringOrBool[]"
			// 否则返回 "StringOrBool"
			if (type.Contains("string") && type.Contains("boolean"))
			{
				return type.Contains("array") ? "StringOrBool[]" : "StringOrBool";
			}

			// 特殊属性：backgroundColor
			if (type.Contains("string") && type.Contains("object") && optionItem.Prop.Contains("backgroundColor"))
			{
				return "Color";
			}

			// string+object 默认返回string
			if (type.Contains("string") && type.Contains("object"))
			{
				return "string";
			}

			// 特殊属性名处理
			if (optionItem.Prop.Contains("controlStyle"))
			{
				return "Timeline_ControlStyle";
			}

			if (optionItem.Prop.Contains("checkpointStyle"))
			{
				return "Timeline_CheckpointStyle";
			}

			// 特殊情况处理
			if (type == "" && optionItem.Prop == "position")
			{
				return "string";
			}

			if (type == "date")
			{
				return "string";
			}

			// 未匹配到特定情况输出调试信息
			if (type != "object")
			{
				Debug.WriteLine(type);
			}

			// 若含有 "tooltip" 关键字，则返回 "Tooltip"，否则返回 "object"
			return optionItem.Prop.Contains("tooltip") ? "Tooltip" : "object";
		}


		/// <summary>
		/// 当没有明确的 Type 信息时，根据默认值类型推断 C# 类型。
		/// </summary>
		/// <param name="optionItem">当前 OptionItem。</param>
		/// <returns>推断得到的 C# 类型字符串。</returns>
		private static string InferTypeFromDefault(OptionItem optionItem)
		{
			if (optionItem.Default == null) return "object";

			// 根据 Default 的实际类型决定返回类型
			switch (optionItem.Default.GetType().Name)
			{
				case "Int64":
				case "Int32":
					return "double?";
				case "Double":
					return "double?";
				case "String":
					return "string";
				case "Boolean":
					return "bool?";
				default:
					return "object";
			}
		}

		#endregion
	}

	/// <summary>
	/// 表示 ECharts 配置项的单个属性信息，包括类型、默认值、子属性列表等。
	/// </summary>
	public class OptionItem
	{
		/// <summary>
		/// 属性类型信息（来自解析配置文档或 JSON 数据）。
		/// </summary>
		public object Type { get; set; }

		/// <summary>
		/// 标识此属性是否为对象类型。
		/// </summary>
		public bool IsObject { get; set; }

		/// <summary>
		/// 属性名称。
		/// </summary>
		public string Prop { get; set; }

		/// <summary>
		/// 属性的默认值。
		/// </summary>
		public object Default { get; set; }

		/// <summary>
		/// 标识此属性是否为数组类型。
		/// </summary>
		public bool IsArray { get; set; }

		/// <summary>
		/// 若为数组类型，该项表示数组内元素的类型。
		/// </summary>
		public string ArrayItemType { get; set; }

		/// <summary>
		/// 子项列表，用于描述嵌套的 ECharts 配置结构。
		/// </summary>
		public List<OptionItem> Children { get; set; }
	}
}
