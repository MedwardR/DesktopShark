using Ambient.Frontend.WindowsHybrid.Application;

namespace DesktopShark;

internal static class Program
{
	[STAThread]
	public static void Main()
	{
		ApplicationConfiguration.Initialize();

		var app = new AmbientApplication();
		var shark = new Shark();

		app.World.AddNode(shark);
		app.Run();
	}
}
