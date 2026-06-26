using Ambient.Frontend.WindowsHybrid.Application;
using Ambient.Frontend.WindowsHybrid.Assets;
using Ambient.Frontend.WindowsHybrid.Extensions;

namespace DesktopShark;

public partial class MainForm : Form
{
	protected readonly AmbientApplication _application;
	protected readonly FontSystem _fonts;

	public MainForm(AmbientApplication app, FontSystem fonts)
	{
		_application = app;
		_fonts = fonts;

		InitializeComponent();
		InitializeTypeface();
	}

	private void InitializeTypeface()
	{
		var fonts = new Dictionary<string, FontFamily>
		{
			{ "Disgusting Behavior", _fonts.Load("disgusting_behavior.ttf") },
		};
		var controls = Ancestry.Collect(this);

		foreach (var c in controls)
		{
			var f = c.Font;

			if (!string.IsNullOrWhiteSpace(f.OriginalFontName))
			{
				if (fonts.TryGetValue(f.OriginalFontName, out var family))
				{
					float emSize = f.Size;
					var style = f.Style;
					var unit = f.Unit;
					byte gdiCharSet = f.GdiCharSet;
					bool gdiVerticalFont = f.GdiVerticalFont;

					c.Font = new(family, emSize, style, unit, gdiCharSet, gdiVerticalFont);
				}
			}
		}
	}
}
