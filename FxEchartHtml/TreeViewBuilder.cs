using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FxEchartHtml
{
	/// <summary>
	/// 用于根据 DemoInfo 列表构建 TreeView 节点结构的工具类。
	/// </summary>
	public class TreeViewBuilder
	{
		/// <summary>
		/// 根据 DemoInfo 列表构建 TreeView，按分类创建根节点，并将对应的 DemoInfo 加入子节点。
		/// </summary>
		/// <param name="demoInfoList">包含演示示例信息的列表。</param>
		/// <param name="treeView">目标 TreeView 控件。</param>
		public static void BuildTreeView(List<DemoInfo> demoInfoList, TreeView treeView)
		{
			if (demoInfoList == null || treeView == null)
			{
				Debug.WriteLine("demoInfoList 或 treeView 为 null，无法构建树形视图。");
				return;
			}

			foreach (var demoInfo in demoInfoList)
			{
				foreach (var category in demoInfo.Categories)
				{
					// 根据分类名称查找是否已存在该分类节点
					var categoryNode = treeView.Nodes.Cast<TreeNode>()
						.FirstOrDefault(node => node.Text.Equals(category, StringComparison.OrdinalIgnoreCase));

					if (categoryNode == null)
					{
						// 未找到分类节点则新建
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
					else
					{
						// 若分类节点已存在但文件路径不同则添加新节点
						if (!categoryNode.Tag.Equals(demoInfo.FilePath))
						{
							var key = string.IsNullOrEmpty(demoInfo.TitleCn) ? demoInfo.Title : demoInfo.TitleCn;
							var titleNode = new TreeNode()
							{
								Tag = demoInfo.FilePath,
								Name = key,
								Text = key
							};

							// 检查是否已存在相同文本的子节点，避免重复添加
							var existingNodes = categoryNode.Nodes.Find(titleNode.Text, true);
							if (existingNodes.Length == 0)
							{
								categoryNode.Nodes.Add(titleNode);
							}
							else
							{
								Debug.WriteLine($"分类 '{category}' 下已存在相同名称的子节点 '{titleNode.Text}'。跳过添加。");
							}
						}
					}
				}
			}

			// 设置 TreeView 的显示属性
			treeView.ShowLines = true;
			treeView.ShowPlusMinus = true;
			treeView.FullRowSelect = true;
		}
	}
}