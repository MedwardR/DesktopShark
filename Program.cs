using System.Diagnostics;
using Ambient.Backend.Assets;
using Ambient.Backend.Diagnostics;
using Ambient.Frontend.WindowsHybrid.Application;
using Ambient.Frontend.WindowsHybrid.Assets;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		ApplicationConfiguration.Initialize();

		var app = new AmbientApplication("Desktop Shark");
		var assets = new AssetSystem("Assets");
		var fonts = new FontSystem(assets);

		var shark = new Shark(assets);
		shark.Transform.Position = ScreenInformation.GetMousePosition();

		var monitor = FrameRateMonitor.StartNew(1.0);
		monitor.Tick += (s, e) => Debug.Print($"FPS: {e.FramesPerSecond}");

		app.FormFactory = new(() =>
		{
			return new MainForm(app, fonts);
		});

		app.World.Nodes.Add(shark);
		app.World.Nodes.Add(monitor);

		app.Run();
	}
}
