using Ambient.Backend.Contracts;
using Ambient.Backend.Extensions;
using Ambient.Backend.Features;
using Ambient.Backend.IO;
using Ambient.Backend.Kernel;
using Ambient.Frontend.WindowsHybrid.Graphics;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal class Shark : Node, ITransformable
{
	public LinearTransform Transform { get; }
	public RasterGraphic Graphics { get; }
	public float MoveSpeed { get; set; }

	public Shark(AssetSystem asys)
	{
		var sprite = asys.LoadAsset<Sprite>("shark.png");

		Transform = new();
		Graphics = new(sprite, Transform);
		MoveSpeed = 50f;
	}

	public override void Update(float deltaTime)
	{
		var cursor = ScreenInformation.GetMousePosition();

		this.MoveTowards(cursor, MoveSpeed * deltaTime);
		this.PointTowards(cursor);

		Transform.FlipX = cursor.X < Transform.Position.X;
	}
}
