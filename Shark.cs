using Ambient.Backend.Animation;
using Ambient.Backend.Assets;
using Ambient.Backend.Extensions;
using Ambient.Frontend.WindowsHybrid.Extensions;
using Ambient.Frontend.WindowsHybrid.Graphics;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal class Shark : Visual<RasterGraphic>
{
	public Animator<Sprite> Animator { get; }

	public float MoveSpeed { get; set; }

	public Shark(AssetSystem assets)
	{
		var template = new SpriteAnimationTemplate(256, 200, 0.2f);

		Animator = new()
		{
			{ "idle", assets.Load<Sprite>("shark_idle.png").Animate(template) },
			{ "swim", assets.Load<Sprite>("shark_swim.png").Animate(template) },
		};
		Animator.FrameChanged += (s, e) => Graphics.Use(e.Frame.Value);
		Animator.Start();

		MoveSpeed = 100f;
		Nodes.Add(Animator);
	}

	public override void Update(float deltaTime)
	{
		var cursor = ScreenInformation.GetMousePosition();

		var difference = cursor - Transform.Position;
		float distance = MoveSpeed * deltaTime;

		if (difference.Length() >= distance * 10)
		{
			Transformable.MoveTowards(this, cursor, distance);
			Transformable.PointTowards(this, cursor);

			Transform.FlipY = cursor.X < Transform.Position.X;

			Animator.Use("swim");
		}
		else Animator.Use("idle");
	}
}
