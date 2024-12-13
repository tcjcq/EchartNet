using System.Collections.Generic;

namespace FxEchartHtml
{
	/// <summary>
	/// 表示一个类的信息，包括类名、描述、属性列表、子类列表以及示例配置。
	/// </summary>
	public class ClassInfo
	{
		/// <summary>
		/// 类名。
		/// </summary>
		public string ClassName { get; set; }

		/// <summary>
		/// 更新后的新类名（可能用于重构后的名称）。
		/// </summary>
		public string NewClassName { get; set; }

		/// <summary>
		/// 类的描述信息（可用于生成文档或注释）。
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 类的属性列表。
		/// </summary>
		public List<PropertyInfo> Properties { get; set; }

		/// <summary>
		/// 类所包含的子类列表。
		/// </summary>
		public List<ClassInfo> ChildClasses { get; set; }

		/// <summary>
		/// 该类的示例信息（如 ECharts 的配置示例）。
		/// </summary>
		public List<ExampleBaseOption> Example { get; set; }

		/// <summary>
		/// 更新指定类及其子类的类名和属性类型名称。
		/// 此方法通过递归遍历所有子类，对类名和基于旧类名的属性类型进行批量替换，
		/// 同时移除特定的后缀（如 "_<styleName>"）。
		/// </summary>
		/// <param name="classInfo">要更新的类信息对象。</param>
		/// <param name="oldName">旧的类名前缀（或模式）。</param>
		/// <param name="newParentName">新的类名前缀（或模式）。</param>
		public static void UpdateChildClasses(ClassInfo classInfo, string oldName, string newParentName)
		{
			// 如果传入的classInfo为空，则无需处理
			if (classInfo == null) return;

			// 原始类名用于属性类型替换时匹配旧类名称前缀
			var oldClassName = classInfo.ClassName;

			// 更新当前类的类名
			if (!string.IsNullOrEmpty(classInfo.ClassName))
			{
				classInfo.ClassName = classInfo.ClassName
					.Replace(oldName, newParentName)
					.Replace("_<styleName>", "");
			}

			// 更新属性类型名称（如果有属性）
			if (classInfo.Properties != null && classInfo.Properties.Count > 0)
			{
				foreach (var property in classInfo.Properties)
				{
					if (string.IsNullOrEmpty(property?.PropertyType)) continue;
					// 确保该属性类型以旧类名为前缀才进行替换
					if (property.PropertyType.StartsWith(oldClassName))
					{
						property.PropertyType = property.PropertyType
							.Replace(oldName, newParentName)
							.Replace("_<styleName>", "");
					}
				}
			}

			if (classInfo.ChildClasses == null || classInfo.ChildClasses.Count <= 0) return;

			// 递归更新子类（如果有子类）
			foreach (var childClass in classInfo.ChildClasses)
			{
				UpdateChildClasses(childClass, oldName, newParentName);
			}
		}

	}
}
