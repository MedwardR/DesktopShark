using System.Diagnostics;
using Ambient.Backend.Assets;
using Ambient.Backend.Diagnostics;
using Ambient.Frontend.WindowsHybrid.Application;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		Application.EnableVisualStyles();
		ApplicationConfiguration.Initialize();

		var app = new AmbientApplication
		{
			Name = "Desktop Shark",
			Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath),
			FormFactory = new FormFactory<ManagerForm>(),
		};
		var assets = new AssetSystem
		{
			AssetsRoot = "Assets/",
		};
		var shark = new Shark(assets);
		shark.Transform.Position = ScreenInformation.GetMousePosition();

		var monitor = FrameRateMonitor.StartNew(1.0);
		monitor.Tick += (s, e) => Debug.Print($"FPS: {e.FramesPerSecond}");

		app.World.Nodes.Add(shark);
		app.World.Nodes.Add(monitor);

		app.Run();
	}
}
