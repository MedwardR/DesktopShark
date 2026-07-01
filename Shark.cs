using System.Numerics;
using Ambient.Backend.Animation;
using Ambient.Backend.Extensions;
using Ambient.Backend.Geometry;
using Ambient.Backend.Management;
using Ambient.Backend.Timing;
using Ambient.Frontend.WindowsHybrid.Assets;
using Ambient.Frontend.WindowsHybrid.Extensions;
using Ambient.Frontend.WindowsHybrid.Graphics;
using Ambient.Frontend.WindowsHybrid.Input;
using Ambient.Frontend.WindowsHybrid.Utilities;

namespace DesktopShark;

internal class Shark : Actor<RasterGraphic>
{
	private readonly MouseDragController _dragController;
	private readonly Cooldown _moveCooldown;

	private Vector2 _destination;

	public Animator<Sprite> Animator { get; }

	public float MoveSpeed { get; set; }
	public bool FollowCursor { get; set; }

	public float MoveInterval
	{
		get => _moveCooldown.IntervalSeconds;
		set => _moveCooldown.IntervalSeconds = value;
	}

	public Shark(AssetSystem assets)
	{
		var slow = new SpriteAnimationTemplate(256, 200, 0.200f);
		var fast = new SpriteAnimationTemplate(256, 200, 0.050f);

		Animator = new()
		{
			{ "idle", assets.Load<Sprite>("shark_idle.png").Animate(slow) },
			{ "swim", assets.Load<Sprite>("shark_swim.png").Animate(slow) },
			{ "drag", assets.Load<Sprite>("shark_drag.png").Animate(fast) },
		};
		Animator.FrameChanged += (s, e) => Graphics.Use(e.Frame.Value);
		Animator.Start();

		MoveSpeed = 100f;
		FollowCursor = false;

		_dragController = new(this);
		_dragController.DraggingEnded += (s, e) => _destination = Transform.Position;
		_dragController.Enable();

		_moveCooldown = new(20f);
		_destination = ScreenInformation.GetMousePosition();

		Nodes.Add(Animator);
		Nodes.Add(_moveCooldown);
	}

	public override void Update(float deltaTime)
	{
		if (_dragController.IsDragging)
		{
			if (_moveCooldown.IsRunning)
			{
				_moveCooldown.Stop();
			}
			Animator.Use("drag");
		}
		else
		{
			KeepDestinationUpdated();
			MoveOrIdle(deltaTime);
		}
	}

	private void KeepDestinationUpdated()
	{
		if (FollowCursor)
		{
			var cursor = ScreenInformation.GetMousePosition();
			var position = Transform.Position;

			var difference = cursor - position;
			float distance = difference.Length();

			if (distance >= 25f)
			{
				_destination = cursor;
			}
			else _destination = position;

			if (_moveCooldown.IsRunning)
			{
				_moveCooldown.Stop();
			}
		}
		else if (_moveCooldown.Tick())
		{
			_moveCooldown.Stop();

			int width = (int)Graphics.Image.RenderSize.Width;
			int height = (int)Graphics.Image.RenderSize.Height;
			var margin = new Size(width, height) / 2;

			var workingAreas = ScreenInformation.GetWorkingAreas();
			int screenIndex = Random.Shared.Next(workingAreas.Length);
			var area = workingAreas[screenIndex];

			area.Inflate(margin * -1);

			int x = Random.Shared.Next(area.Left, area.Right);
			int y = Random.Shared.Next(area.Top, area.Bottom);

			_destination = new(x, y);
		}
	}

	private void MoveOrIdle(float deltaTime)
	{
		if (Transform.Position != _destination)
		{
			Transform.FlipY = _destination.X < Transform.Position.X;

			Transformable.LookTowards(this, _destination);
			Transformable.MoveTowards(this, _destination, MoveSpeed * deltaTime);

			Animator.Use("swim");
		}
		else
		{
			if (!FollowCursor)
			{
				if (!_moveCooldown.IsRunning)
				{
					_moveCooldown.Start();
				}
				Transform.Rotation = Transform.FlipY ? Angle.Pi : Angle.Zero;
			}
			Animator.Use("idle");
		}
	}
}
