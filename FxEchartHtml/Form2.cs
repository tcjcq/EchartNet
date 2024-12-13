using System;
using System.IO;
using System.Windows.Forms;

namespace FxEchartHtml
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void InitView()
		{
			var ls = DemoInfo.ExtractDemoInfoFromFolder(".\\example");
			TreeViewBuilder.BuildTreeView(ls, treeView1);
		}

		private void AddTooltipHandler(TreeView treeView)
		{
			treeView.ShowNodeToolTips = false;
			treeView.NodeMouseHover += (sender, e) =>
			{
				if (!(e.Node?.Tag is string tag)) return;
				toolTip1.AutomaticDelay = 500;
				toolTip1.Show(tag, treeView1);
			};
		}
		private void Form2_Load(object sender, EventArgs e)
		{
			AddTooltipHandler(treeView1);
			InitView();
		}

		private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var s = File.ReadAllText(e.Node.Tag.ToString());
			richTextBox1.Text = s;
			if (e.Node.Tag.ToString().Contains("gl_gpu"))
			{
				DemoInfo.ShowDemo(webView21, s, this, true);

			}
			else
			{
				DemoInfo.ShowDemo(webView21, s, this);

			}
		}

		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			DemoInfo.ShowDemo(webView21, richTextBox1.Text, this);
		}
	}
}
