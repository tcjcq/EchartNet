using Newtonsoft.Json;

using RestSharp;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace FxEchartHtml
{
	public class WebContentFetcher
	{
		private readonly RestClient _client = new RestClient();

		// 初始化 RestClient

		// 获取网页内容的方法
		public async Task<string> GetWebContentAsync(string url)
		{
			try
			{
				// 创建请求
				var request = new RestRequest(url, Method.Get);

				// 执行请求并获取响应
				var response = await _client.ExecuteAsync(request);

				// 检查响应状态
				if (response.IsSuccessful)
				{
					// 获取内容为字符串
					return response.Content;
				}
				else
				{
					// 输出错误信息
					Debug.WriteLine($"请求错误: {url} {response.StatusDescription}");
					return null;
				}
			}
			catch (Exception e)
			{
				// 处理其他错误
				Debug.WriteLine($"发生错误: {e.Message}");
				return null;
			}
		}


		// 解析 JSON 内容并生成新的链接
		public Dictionary<string, string> GenerateNewLinks(string content, bool is3d = false)
		{
			var newLinks = new Dictionary<string, string>();
			try
			{
				// 反序列化 JSON 内容到对象并展示
				var options = JsonConvert.DeserializeObject<Dictionary<string, OptionPart>>(content);


				// 遍历 JSON 中的顶级键
				foreach (var property in options.Keys)
				{
					// 获取键名
					var key = property;

					// 生成新的链接
					var newUrl = $"https://echarts.apache.org/zh/documents/option-parts/option.{key}.js";
					var newUrl1 = $"https://echarts.apache.org/zh/documents/option-gl-parts/option-gl.{key}.js";
					if (is3d)
					{
						newUrl = newUrl1;
					}
					newLinks.Add(key, newUrl);
				}
			}
			catch (Exception e)
			{
				// 处理可能的解析错误
				Debug.WriteLine($"解析错误: {e.Message}");
			}

			return newLinks;
		}

		// 获取链接内容并保存到本地文件
		public async Task SaveLinkContentToFileAsync(string url, string filePath)
		{
			try
			{
				if (File.Exists(filePath))
				{
					Debug.WriteLine($"文件已存在: {filePath}");
					return;
				}
				// 获取链接内容
				var content = await GetWebContentAsync(url);
				if (content != null)
				{
					// 保存内容到指定文件
					File.WriteAllText(filePath, content);
					Debug.WriteLine($"文件已保存到: {filePath}");
				}
				else
				{
					Debug.WriteLine($"未能成功获取 {url} 的内容");
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine($"保存文件时发生错误: {e.Message}");
			}
		}
	}
}