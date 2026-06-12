using Ambient.Backend.IO;
using Ambient.Frontend.WindowsHybrid.Application;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		ApplicationConfiguration.Initialize();

		var app = new AmbientApplication();
		var asys = new AssetSystem()
		{
			AssetsRoot = "Assets/",
		};
		var shark = new Shark(asys);
		shark.Transform.Position = ScreenInformation.GetMousePosition();

		app.World.Nodes.Add(asys);
		app.World.Nodes.Add(shark);
		app.Run();
	}
}
