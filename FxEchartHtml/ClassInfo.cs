using System.Collections.Generic;

namespace FxEchartHtml
{
	public class ClassInfo
	{
		public string ClassName { get; set; }
		public string NewClassName { get; set; }
		public string Description { get; set; }
		public List<PropertyInfo> Properties { get; set; }
		public List<ClassInfo> ChildClasses { get; set; }

		public List<ExampleBaseOption> Example { get; set; }

		public static void UpdateChildClasses(ClassInfo classInfo, string oldName, string newParentName)
		{
			// 检查传入的父类信息是否为空
			if (classInfo == null)
			{
				return;
			}

			var oldClassName = classInfo.ClassName;
			// 更新父类的类名称
			classInfo.ClassName = classInfo.ClassName.Replace(oldName, newParentName).Replace("_<styleName>", "");

			// 递归遍历所有子类并更新它们的类名称和属性类型
			if (classInfo.ChildClasses == null || classInfo.ChildClasses.Count == 0) return;
			// 更新子类的属性类型，属性类型与父类名称相关
			foreach (var property in classInfo.Properties)
			{
				if (property.PropertyType.StartsWith(oldClassName))
				{
					property.PropertyType = property.PropertyType.Replace(oldName, newParentName);
					property.PropertyType = property.PropertyType.Replace("_<styleName>", "");
				}
			}
			foreach (var childClass in classInfo.ChildClasses)
			{
				// 递归更新子类的子类
				UpdateChildClasses(childClass, oldName, newParentName);
			}
		}

	}
}