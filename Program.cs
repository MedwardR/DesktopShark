using System.Diagnostics;
using Ambient.Backend.Management;
using Ambient.Backend.Timing;
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

		app.FormFactory = new(() => new MainForm(app, fonts));

		var shark = new Shark(assets);
		shark.Transform.Position = ScreenInformation.GetMousePosition();
		shark.Graphics.Image.MouseRightButtonUp += (s, e) => app.Manage();

		var monitor = FrameRateMonitor.StartNew(1f);
		monitor.Tick += (s, e) => Debug.Print($"FPS: {e.FramesPerSecond}");

		app.World.Nodes.Add(shark);
		app.World.Nodes.Add(monitor);

		app.Run();
	}
}
