using Ambient.Backend.Animation;
using Ambient.Backend.Contracts;
using Ambient.Backend.Extensions;
using Ambient.Backend.Geometry;
using Ambient.Backend.IO;
using Ambient.Backend.Kernel;
using Ambient.Frontend.WindowsHybrid.Graphics;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal class Shark : Node, ITransformable
{
	public LinearTransform Transform { get; }
	public RasterGraphic Graphics { get; }
	public Animator<Sprite> Animator { get; }

	public float MoveSpeed { get; set; }

	public Shark(AssetSystem assets)
	{
		Transform = new();
		Graphics = new(Transform);

		var png = assets.LoadAsset<Sprite>("shark_swim_spritesheet.png");
		var spritesheet = png.Split(256, 200);
		var frames = new KeyFrame<Sprite>[spritesheet.Length];

		for (int index = 0; index < spritesheet.Length; index++)
		{
			var sprite = spritesheet[index];
			frames[index] = new(sprite, 0.2f);
		}
		Animator = new(frames);

		Animator.FrameChanged += (s, e) => Graphics.Image.Source = e.Frame.Value.Source;
		Animator.Start();

		MoveSpeed = 0f;
		Nodes.Add(Animator);
	}

	public override void Update(float deltaTime)
	{
		var cursor = ScreenInformation.GetMousePosition();

		Transformable.MoveTowards(this, cursor, MoveSpeed * deltaTime);
		Transformable.PointTowards(this, cursor);

		if (Transform.Position != cursor)
		{
			Transform.FlipY = cursor.X < Transform.Position.X;
		}
	}
}
