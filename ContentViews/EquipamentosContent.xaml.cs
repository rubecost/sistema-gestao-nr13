using System.Reflection.Metadata;

namespace Cronos.ContentViews;

public partial class EquipamentosContent : ContentView
{
	public EquipamentosContent()
	{
		InitializeComponent();

	}

	private void OnPointerEntered(object sender, PointerEventArgs e)
	{	
		if(sender is Grid grd)
		{
			grd.BackgroundColor = Color.FromArgb("8A8A8A");
		}
	}
	private void OnPointerExited(object sender, PointerEventArgs e)
	{
		if (sender is Grid grd)
		{
			grd.BackgroundColor = Colors.Transparent;
		}
	}
}