using Ambient.Backend.Kernel;
using Ambient.Frontend.WindowsHybrid.Application;

namespace DesktopShark;

public partial class MainForm : Form
{
	protected readonly AmbientApplication _application;
	protected readonly World _world;
	protected readonly FontSystem _fonts;

	public MainForm(AmbientApplication app, FontSystem fonts)
	{
		InitializeComponent();

		_application = app;
		_world = app.World;
		_fonts = fonts;
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		_fonts.Load("disgusting_behavior.ttf");
		_fonts.Load("aquifer.ttf");

		_fonts.ApplyTo(this);
	}

	private void MainForm_VisibleChanged(object sender, EventArgs e)
	{
		if (Visible)
		{
			var shark = _world.Singleton<Shark>();

			FollowCursor.Checked = shark.FollowCursor;
			EnableCursorChomping.Checked = shark.AllowCursorChomp;
			MoveInterval.Value = (decimal)shark.MoveInterval;
			MoveSpeed.Value = (decimal)shark.MoveSpeed;
			ChompChance.Value = (decimal)shark.CursorChompProbability * 100;

			AlwaysOnTop.Checked = _application.Viewport.Window.Topmost;
			FramesPerSecond.Value = (decimal)_world.FramesPerSecond;
		}
	}

	private void ApplyButton_Click(object sender, EventArgs e)
	{
		Save();
	}

	private void OkButton_Click(object sender, EventArgs e)
	{
		Save();
		Close();
	}

	private void Save()
	{
		var shark = _world.Singleton<Shark>();

		shark.FollowCursor = FollowCursor.Checked;
		shark.AllowCursorChomp = EnableCursorChomping.Checked;
		shark.MoveInterval = (float)MoveInterval.Value;
		shark.MoveSpeed = (float)MoveSpeed.Value;
		shark.CursorChompProbability = (float)ChompChance.Value / 100f;

		_application.Viewport.Window.Topmost = AlwaysOnTop.Checked;
		_world.FramesPerSecond = (double)FramesPerSecond.Value;
	}
}
