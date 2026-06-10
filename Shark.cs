using System.Windows.Input;
using Ambient.Backend.Contracts;
using Ambient.Backend.Features;
using Ambient.Backend.Kernel;
using Ambient.Frontend.WindowsHybrid.Graphics;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal class Shark : Node, ITransformable
{
	public LinearTransform Transform { get; }
	public RasterGraphic Graphics { get; }

	public Shark()
	{
		Transform = new();
		Graphics = new(Transform);
	}

	public override void Update(float deltaTime)
	{
		Transform.Position = ScreenInformation.GetMousePosition();
	}
}
