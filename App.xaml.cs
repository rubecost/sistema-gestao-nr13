using Cronos.Services;
using Cronos.ViewModels;
using Cronos.ContentViews;
using Microsoft.Extensions.DependencyInjection;

namespace Cronos
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
		}

		protected override Window CreateWindow(IActivationState activationState)
		{
			Window window = base.CreateWindow(activationState);

			// Adiciona o event handler ao evento Activated do window
			window.Activated += Window_Activated;

			return window;
		}

		private void Window_Activated(object sender, EventArgs e)
		{
			const int DefaultWidth = 1240;
			const int DefaultHeight = 720;

			if (sender is Window window)
			{
				window.Title = "Cronos";

				// Define o tamanho de abertura da tela
				window.Width = DefaultWidth;
				window.Height = DefaultHeight;

				// Define o tamanho mínimo da tela
				window.MinimumWidth = 720;
				window.MinimumHeight = 480;

				// Aguarda um tempo para completar a tarefa de redimensionamento da janela
				window.Dispatcher.Dispatch(() => { });

				var disp = DeviceDisplay.Current.MainDisplayInfo;

				// Abre a tela no centro da tela
				window.X = (disp.Width / disp.Density - window.Width) / 2;
				window.Y = (disp.Height / disp.Density - window.Height) / 2;
			}
		}


	}
}
