using Ambient.Backend.Animation;
using Ambient.Backend.Assets;
using Ambient.Backend.Extensions;
using Ambient.Backend.Geometry;
using Ambient.Frontend.WindowsHybrid.Assets;
using Ambient.Frontend.WindowsHybrid.Extensions;
using Ambient.Frontend.WindowsHybrid.Graphics;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal class Shark : Visual<RasterGraphic>
{
	public Animator<Sprite> Animator { get; }

	public float MoveSpeed { get; set; }

	public bool FollowCursor { get; set; }

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
		if (FollowCursor)
		{
			var cursor = ScreenInformation.GetMousePosition();
			var difference = cursor - Transform.Position;

			if (difference.Length() >= 25f)
			{
				Transform.FlipY = cursor.X < Transform.Position.X;

				Transformable.LookTowards(this, cursor);
				Transformable.MoveTowards(this, cursor, MoveSpeed * deltaTime);

				Animator.Use("swim");
			}
			else Animator.Use("idle");
		}
		else
		{
			Transform.Rotation = Transform.FlipY ? Angle.Pi : Angle.Zero;
			Animator.Use("idle");
		}
	}
}
