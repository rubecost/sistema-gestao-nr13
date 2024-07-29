using Cronos.ViewModels;

namespace Cronos.ContentViews;

public partial class CriarContaContent : ContentView
{
	private PlanosViewModel viewModel;
	public CriarContaContent()
	{
		InitializeComponent();

		viewModel = new PlanosViewModel();

		BindingContext = viewModel;

		LoadPlans();
	}
	private async void LoadPlans()
	{
		await viewModel.LoadPlansCommand.ExecuteAsync(null);
	}
}