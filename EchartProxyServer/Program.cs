using System;

namespace EchartProxyServer
{

	internal static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{

			var prefixes = new[] { "http://localhost:8088/" };
			var server = new SimpleHttpServer(prefixes) { RootPath = "https://echarts.apache.org/examples" };

			server.Start();
			Log("Press Enter to stop the server...");
			Console.ReadLine();
			server.Stop();
		}
		private static void Log(string message)
		{
			Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} - {message}");
		}
	}
}
