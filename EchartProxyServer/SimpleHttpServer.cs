using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EchartProxyServer
{
	public class SimpleHttpServer
	{
		private readonly HttpListener _listener;
		// 定义一个事件来处理请求
		public event EventHandler<HttpListenerContext> RequestReceived;

		public string RootPath { get; set; } = "https://echarts.apache.org/examples";
		private readonly string _cacheDirectory = "cache";
		public SimpleHttpServer(string[] prefixes)
		{

			_listener = new HttpListener();
			foreach (var prefix in prefixes)
			{
				_listener.Prefixes.Add(prefix);
			}

		}
		public void Start()
		{
			_listener.Start();
			Console.WriteLine("Simple HTTP Server started.");

			Task.Run(() =>
			{
				while (_listener.IsListening)
				{
					try
					{
						var context = _listener.GetContext();
						CustomRequestHandler(context);
					}
					catch (HttpListenerException e)
					{
						Console.WriteLine($"Listener error: {e.Message}");
					}
					catch (Exception e)
					{
						Console.WriteLine($"Error: {e.Message}");
					}
				}
			});
		}

		public void CustomRequestHandler(HttpListenerContext context)
		{
			try
			{
				var request = context.Request;
				var response = context.Response;
				string relativePath = request.Url.AbsolutePath.TrimStart('/');
				string cacheFilePath = Path.Combine(_cacheDirectory, relativePath.Replace('/', '_'));

				if (File.Exists(cacheFilePath))
				{
					// Serve the cached file
					byte[] cachedContent = File.ReadAllBytes(cacheFilePath);
					response.ContentLength64 = cachedContent.Length;
					response.OutputStream.Write(cachedContent, 0, cachedContent.Length);
					response.Close();
					Console.WriteLine("Served from cache: " + cacheFilePath);
					return;
				}

				// Build the target URL to forward the request
				var targetUrl = RootPath + request.Url.AbsolutePath;
				if (!string.IsNullOrEmpty(request.Url.Query))
				{
					targetUrl += request.Url.Query;
				}

				// Create a web request to the target URL
				var webRequest = (HttpWebRequest)WebRequest.Create(targetUrl);
				webRequest.Method = request.HttpMethod;

				// Copy headers from the incoming request to the outgoing request
				foreach (var header in request.Headers.AllKeys)
				{
					if (!WebHeaderCollection.IsRestricted(header))
					{
						webRequest.Headers[header] = request.Headers[header];
					}
				}

				// Forward the response from the target server back to the client
				using (var targetResponse = (HttpWebResponse)webRequest.GetResponse())
				using (var targetResponseStream = targetResponse.GetResponseStream())
				{
					response.StatusCode = (int)targetResponse.StatusCode;

					foreach (var header in targetResponse.Headers.AllKeys)
					{
						if (!header.Equals("Content-Length", StringComparison.OrdinalIgnoreCase))
						{
							response.Headers[header] = targetResponse.Headers[header];
						}
					}

					// Add Access-Control-Allow-Origin header for CORS handling
					response.Headers["Access-Control-Allow-Origin"] = "*";

					using (var memoryStream = new MemoryStream())
					{
						var buffer = new byte[4096];
						int bytesRead;
						while ((bytesRead = targetResponseStream.Read(buffer, 0, buffer.Length)) > 0)
						{
							memoryStream.Write(buffer, 0, bytesRead);
							response.OutputStream.Write(buffer, 0, bytesRead);
						}

						// Save the content to the cache
						Directory.CreateDirectory(Path.GetDirectoryName(cacheFilePath));
						File.WriteAllBytes(cacheFilePath, memoryStream.ToArray());
						Console.WriteLine("Saved to cache: " + cacheFilePath);
					}
				}

				response.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in custom handler: {ex.Message}");
				var errorResponse = Encoding.UTF8.GetBytes("<html><body><h1>Internal Server Error</h1></body></html>");
				context.Response.StatusCode = 500;
				context.Response.OutputStream.Write(errorResponse, 0, errorResponse.Length);
				context.Response.Close();
			}
		}
		private void DefaultRequestHandler(HttpListenerContext context)
		{
			var responseString = "<html><head><title>Default Response</title></head><body>Hello from default handler!</body></html>";
			var buffer = Encoding.UTF8.GetBytes(responseString);
			context.Response.ContentLength64 = buffer.Length;
			context.Response.OutputStream.Write(buffer, 0, buffer.Length);
			context.Response.Close();
			Debug.WriteLine("Default request handled!");
		}
		public void Stop()
		{
			_listener.Stop();
			_listener.Close();
		}
	}
}