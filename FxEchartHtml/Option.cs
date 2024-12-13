using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FxEchartHtml
{
	public class Option
	{
		public List<OptionItem> Children { get; set; }

		/// <summary>
		/// 在 Option 的 Children 中查找对应 Prop 值的 OptionItem，支持嵌套查找。
		/// </summary>
		/// <param name="option">Option 对象</param>
		/// <param name="prop">要查找的属性名，形式为 AAA.BBB.CCC</param>
		/// <returns>找到的 OptionItem 或 null</returns>
		public static OptionItem FindOptionItemByProp(OptionItem option, string prop)
		{
			if (option?.Children == null) return null;

			prop = prop.Replace("elements.", "elements_"); // 替换属性前缀，避免与关键字冲突
			var propParts = prop.Split('.');
			OptionItem currentItem = null;
			var currentChildren = option.Children;

			foreach (var part in propParts)
			{
				// 逐层查找对应的子项
				currentItem = currentChildren?.FirstOrDefault(item => item.Prop == part);
				if (currentItem != null)
				{
					currentChildren = currentItem.Children;
				}
				else
				{
					// 如果找不到当前属性，检查是否为嵌套结构
					if (!prop.Contains("elements_") || currentChildren == null)
						return null;

					foreach (var child in currentChildren)
					{
						currentItem = child.Children?.FirstOrDefault(item => part.Contains(item.ArrayItemType));
						if (currentItem != null) break;
					}

					if (currentItem == null) return null;
					currentChildren = currentItem.Children;
				}
			}

			return currentItem;
		}

		/// <summary>
		/// 推断属性类型的方法，从 OptionItem 中获取属性类型。
		/// </summary>
		/// <param name="optionItem">OptionItem 对象</param>
		/// <returns>推断出的属性类型</returns>
		public static string InferTypeFromOptionItem(OptionItem optionItem)
		{
			// 如果 optionItem 为 null 或为对象类型，返回 "object"
			if (optionItem == null || optionItem.IsObject) return "object";

			// 判断是否为数组类型
			if (optionItem.IsArray)
				return optionItem.ArrayItemType != null ? $"List<{optionItem.ArrayItemType}>" : "List<object>";

			// 处理普通类型
			if (optionItem.Type == null) return InferTypeFromDefault(optionItem);

			var type = optionItem.Type.ToString().ToLower();
			switch (type)
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
			return HandleComplexType(optionItem, type);
		}

		/// <summary>
		/// 处理复杂类型的推断逻辑。
		/// </summary>
		private static string HandleComplexType(OptionItem optionItem, string type)
		{
			if (type.Contains("string") && type.Contains("number"))
				return type.Contains("array") ? "StringOrNumber[]" : "StringOrNumber";
			if (type.Contains("array") && type.Contains("boolean"))
				return "ArrayOrSingle";
			if (type.Contains("array") && type.Contains("string"))
				return "ArrayOrSingle";
			if (type.Contains("function") && type.Contains("string"))
				return "string";
			if (type.Contains("html") && type.Contains("string"))
				return "string";
			if (type.Contains("echartsinstance") && type.Contains("string"))
				return "string";
			if (type.Contains("function") && type.Contains("number"))
				return "StringOrNumber";
			if (type.Contains("function") && type.Contains("color"))
				return "Color";
			if (type.Contains("array") && type.Contains("number"))
				return "ArrayOrSingle";
			if (type.Contains("boolean") && type.Contains("number"))
				return "NumberOrBool";
			if (type.Contains("string") && type.Contains("boolean"))
				return type.Contains("array") ? "StringOrBool[]" : "StringOrBool";
			if (type.Contains("string") && type.Contains("object") && optionItem.Prop.Contains("backgroundColor"))
				return "Color";
			if (type.Contains("string") && type.Contains("object"))
				return "string";

			if (optionItem.Prop.Contains("controlStyle"))
			{
				return "Timeline_ControlStyle";
			}
			if (optionItem.Prop.Contains("checkpointStyle"))
			{
				return "Timeline_CheckpointStyle";
			}

			if (type == "" && optionItem.Prop == "position")
			{
				return "string";
			}
			if (type == "date")
			{
				return "string";
			}
			if (type != "object")
			{
				Debug.WriteLine(type);

			}
			return optionItem.Prop.Contains("tooltip") ? "Tooltip" : "object";
		}

		/// <summary>
		/// 从默认值推断属性类型。
		/// </summary>
		private static string InferTypeFromDefault(OptionItem optionItem)
		{
			if (optionItem.Default == null) return "object";

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
	}

	public class OptionItem
	{
		public object Type { get; set; } // 属性的类型
		public bool IsObject { get; set; } // 是否为对象类型
		public string Prop { get; set; } // 属性名称
		public object Default { get; set; } // 属性的默认值
		public bool IsArray { get; set; } // 是否为数组类型
		public string ArrayItemType { get; set; } // 数组项的类型
		public List<OptionItem> Children { get; set; } // 子项列表
	}
}
