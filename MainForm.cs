using Ambient.Backend.Kernel;
using Ambient.Frontend.WindowsHybrid.Application;
using Ambient.Frontend.WindowsHybrid.Assets;

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

		FramesPerSecond.Value = (decimal)_world.FramesPerSecond;
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		_fonts.Load("disgusting_behavior.ttf");
		_fonts.Load("aquifer.ttf");

		_fonts.ApplyTo(this);
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
		_world.FramesPerSecond = (double)FramesPerSecond.Value;
	}
}
