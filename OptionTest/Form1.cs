using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Echarts;
using Newtonsoft.Json;

namespace OptionTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		public EChartOption JsonTest(string optionStrings)
		{
			optionStrings = ExtractOptionJson(optionStrings);
			var option = JsonConvert.DeserializeObject<EChartOption>(optionStrings);
			return option;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DeserializeDataJson();
			DeserializeMarkLineJson();
		}


		/// <summary>
		///     从字符串中提取 option 后面的 JSON 数据。
		/// </summary>
		/// <param name="input">包含 option 和 JSON 数据的字符串。</param>
		/// <returns>提取的 JSON 字符串，如果没有找到则返回 null。</returns>
		public static string ExtractOptionJson(string input)
		{
			try
			{
				// 使用正则表达式匹配 option 后面的 JSON 数据
				var pattern = @"option\s*=\s*(\{.+?\});";
				var match = Regex.Match(input, pattern, RegexOptions.Singleline);

				if (match.Success)
					// 提取 JSON 数据
					return match.Groups[1].Value;
				return input;
			}
			catch
			{
				return input;
			}
		}


		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			try
			{
				var setting = new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					Formatting = Formatting.Indented
				};
				textBox2.Text = JsonConvert.SerializeObject(JsonTest(textBox1.Text), setting);
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		public void DeserializeMarkLineJson()
		{
			// 定义 JSON 数据
			var json = @"
        {
            ""symbol"": [""none"", ""none""],
            ""label"": { ""show"": false },
            ""data"": [
                { ""xAxis"": 1 },
                { ""xAxis"": 3 },
                { ""xAxis"": 5 },
                { ""xAxis"": 7 }
            ]
        }";

			// 反序列化 JSON 数据
			var a = JsonConvert.DeserializeObject<SeriesPictorialBar_MarkLine>(json);
		}

		public void DeserializeDataJson()
		{
			// 定义 JSON 数据
			var json = @"
        {
          
      type: 'line',
      smooth: 0.6,
      symbol: 'none', 
      data: [
        ['2019-10-10', 200],
        ['2019-10-11', 560],
        ['2019-10-12', 750],
        ['2019-10-13', 580],
        ['2019-10-14', 250],
        ['2019-10-15', 300],
        ['2019-10-16', 450],
        ['2019-10-17', 300],
        ['2019-10-18', 100]
      ]

        }";

			// 反序列化 JSON 数据
			var markLine = JsonConvert.DeserializeObject<SeriesLine>(json);
			Debug.WriteLine(JsonConvert.SerializeObject(markLine));

			var invalidJson = @"{
            title: {
                text: 'Rainfall and Flow Relationship',
                left: 'center'
            }
        }";

			try
			{
				// 尝试反序列化为动态对象
				dynamic result = JsonConvert.DeserializeObject(invalidJson);

				// 输出结果
				Console.WriteLine("解析成功！");
				Console.WriteLine($"Title Text: {result.title.text}");
				Console.WriteLine($"Title Left: {result.title.left}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"解析失败：{ex.Message}");
			}
		}
	}
}