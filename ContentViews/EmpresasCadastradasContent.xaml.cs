namespace Cronos.ContentViews;

public partial class EmpresasCadastradasContent : ContentView
{
	public EmpresasCadastradasContent()
	{
		InitializeComponent();
	}

	private void CriarUnidade_Clicked(object sender, EventArgs e)
	{
		GrdPopupCriarUnidade.IsVisible = !GrdPopupCriarUnidade.IsVisible;
    }

	private void CriarEmpresa_Tapped(object sender, TappedEventArgs e)
	{
		GrdPopupCriarEmpresa.IsVisible = !GrdPopupCriarEmpresa.IsVisible;
	}
	private void IconClosePopups_Tapped(object sender, TappedEventArgs e)
	{
		if (sender is Label label)
		{
			switch (label.ClassId)
			{
				case "IconUnidade":
					GrdPopupCriarUnidade.IsVisible = !GrdPopupCriarUnidade.IsVisible;
					break;
				case "IconEmpresa":
					GrdPopupCriarEmpresa.IsVisible = !GrdPopupCriarEmpresa.IsVisible;
					break;
				default:
					break;
			}
		}
	}
}