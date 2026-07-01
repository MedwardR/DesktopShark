using System.Numerics;
using Ambient.Backend.Animation;
using Ambient.Backend.Extensions;
using Ambient.Backend.Geometry;
using Ambient.Backend.Kernel;
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
	private readonly TimeInterval _moveInterval;

	private Vector2 _destination;
	private bool _chasing;

	public Animator<Sprite> Animator { get; }

	public bool FollowCursor { get; set; }
	public bool AllowCursorChomp { get; set; }

	public float MoveSpeed { get; set; }
	public float CursorChompProbability { get; set; }

	public float MoveInterval
	{
		get => _moveInterval.IntervalSeconds;
		set => _moveInterval.IntervalSeconds = value;
	}

	public Shark(AssetSystem assets)
	{
		_dragController = new(this);
		_dragController.DraggingEnded += (s, e) => _destination = Transform.Position;
		_dragController.Enable();

		_moveInterval = new(20f);
		_destination = ScreenInformation.GetMousePosition();
		_chasing = false;

		var slow = new SpriteAnimationTemplate(256, 200, 0.200f);
		var fast = new SpriteAnimationTemplate(256, 200, 0.050f);

		Animator = new()
		{
			{ "idle",  assets.Load("shark_idle.png",  slow) },
			{ "swim",  assets.Load("shark_swim.png",  slow) },
			{ "drag",  assets.Load("shark_drag.png",  fast) },
			{ "chase", assets.Load("shark_chase.png", fast) },
		};
		Animator.FrameChanged += (s, e) => Graphics.Use(e.Frame.Value);
		Animator.Start();

		FollowCursor = false;
		AllowCursorChomp = false;
		MoveSpeed = 100f;
		CursorChompProbability = 0.10f;
	}

	protected override IEnumerable<Node> Compose()
	{
		yield return Animator;
		yield return _dragController;
		yield return _moveInterval;
	}

	protected override void Update(float deltaTime)
	{
		if (_dragController.IsDragging)
		{
			if (_moveInterval.IsRunning)
			{
				_moveInterval.Stop();
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
		if (FollowCursor || _chasing)
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

			if (_moveInterval.IsRunning)
			{
				_moveInterval.Stop();
			}
		}
		else if (_moveInterval.Tick())
		{
			PickNewDestination();
		}
	}

	private void MoveOrIdle(float deltaTime)
	{
		if (Transform.Position != _destination)
		{
			Transform.FlipY = _destination.X < Transform.Position.X;

			Transformable.LookTowards(this, _destination);
			Transformable.MoveTowards(this, _destination, MoveSpeed * deltaTime);

			if (_chasing)
			{
				Animator.Use("chase");
			}
			else Animator.Use("swim");
		}
		else
		{
			if (!FollowCursor)
			{
				if (!_moveInterval.IsRunning)
				{
					_moveInterval.Start();
				}
				Transform.Rotation = Transform.FlipY ? Angle.Pi : Angle.Zero;
			}
			if (_chasing)
			{
				_chasing = false;
			}
			Animator.Use("idle");
		}
	}

	private void PickNewDestination()
	{
		float r = Random.Shared.NextSingle();

		if (r > CursorChompProbability)
		{
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
		else
		{
			_chasing = true;
			_destination = ScreenInformation.GetMousePosition();
		}
		_moveInterval.Stop();
	}
}
