namespace Cronos.ContentViews;

public partial class ConfiguracoesContent : ContentView
{
	public ConfiguracoesContent()
	{
		InitializeComponent();
	}

	private void Pessoal_Tapped(object sender, TappedEventArgs e)
	{
		CoresTxt();
		VisibilidadeFrame();
		TxtPessoal.TextColor = Colors.White;
		FrmPessoal.IsVisible = true;
	}
	private void Empresa_Tapped(object sender, TappedEventArgs e)
	{
		CoresTxt();
		VisibilidadeFrame();
		TxtEmpresa.TextColor = Colors.White;
		FrmEmpresa.IsVisible = true;
	}
	private void Notificacao_Tapped(object sender, TappedEventArgs e)
	{
		CoresTxt();
		VisibilidadeFrame();
		TxtNotificacao.TextColor = Colors.White;
		FrmNotificacao.IsVisible = true;
	}
	private void IconAtualizar_Tapped(object sender, TappedEventArgs e)
	{
		if (sender is Label label)
		{
			switch (label.ClassId)
			{
				case "IconPessoal":
					GrdPopupAtPessoal.IsVisible = !GrdPopupAtPessoal.IsVisible;
					break;
				case "IconEmpresa":
					GrdPopupAtEmpresa.IsVisible = !GrdPopupAtEmpresa.IsVisible;
					break;
				default:
					break;
			}
		}
	}

	private void CoresTxt()
	{
		TxtPessoal.TextColor = Color.FromArgb("8A8A8A");
		TxtEmpresa.TextColor = Color.FromArgb("8A8A8A");
		TxtNotificacao.TextColor = Color.FromArgb("8A8A8A");
	}
	private void VisibilidadeFrame()
	{
		FrmPessoal.IsVisible = false;
		FrmEmpresa.IsVisible = false;
		FrmNotificacao.IsVisible = false;
	}
}