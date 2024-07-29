using Cronos.ContentViews;
using Cronos.Services;
using Cronos.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Collections.ObjectModel;

namespace Cronos.Views;

public partial class MainPage : ContentPage
{
	private bool _isLoading = true;
	private bool _isPageOpening = false; // Variável de bloqueio
	private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1); // Gerenciador de acesso assíncrono
	private readonly MainPageViewModel viewModel;
	
	public MainPage()
	{
		InitializeComponent();

		viewModel = new MainPageViewModel();

		BindingContext = viewModel;

		ContentArea.Content = new DashboardContent();

		WeakReferenceMessenger.Default.Register<MensageriaService>(this, (r, m) =>
		{
			var tappedEventArgs = new TappedEventArgs(null);

			var label = new Label { ClassId = m.Value };

			AbrirPage_Tapped(label, tappedEventArgs);
		});
	}
	private async Task LoadingEfeito()
	{
		// Tentar entrar na seção crítica
		if (_isPageOpening)
		{
			return;
		}

		// Bloquear o método para outras execuções
		_isPageOpening = true;
		await _semaphore.WaitAsync();

		try
		{
			// Iniciar o efeito de loading
			_isLoading = true;
			var loadingTask = EfeitoLoading();

			await Task.Delay(2000);

			// Concluir o efeito de loading
			_isLoading = false;
			await loadingTask;
		}
		finally
		{
			// Liberar o acesso e desbloquear o método
			_semaphore.Release();
			_isPageOpening = false;
		}
	}


	private async void AbrirPage_Tapped(object sender, TappedEventArgs e)
	{
		// Tentar entrar na seção crítica
		if (_isPageOpening)
		{
			return;
		}
		
		// Bloquear o método para outras execuções
		_isPageOpening = true;

		_isLoading = true;

		var loadingTask = EfeitoLoading();

		if (sender is Label label)
		{
			// Resetar ícones e cores
			ResetAllIcons();

			switch (label.ClassId)
			{
				case "BtnPage1":
					AtualizarIcones(Bxvlinha1, TxtIcon1);
					break;
				case "BtnPage2":
					AtualizarIcones(Bxvlinha2, TxtIcon2);
					break;
				case "BtnPage3":
					AtualizarIcones(Bxvlinha3, TxtIcon3);
					break;
				case "BtnPage4":
					AtualizarIcones(Bxvlinha4, TxtIcon4);
					break;
				case "BtnPage5":
					AtualizarIcones(Bxvlinha5, TxtIcon5);
					break;
				case "BtnPage6":
					AtualizarIcones(Bxvlinha6, TxtIcon6);
					break;
				case "BtnPage7":
					AtualizarIcones(Bxvlinha7, TxtIcon7);
					break;
				case "BtnPage8":
					AtualizarIcones(Bxvlinha8, TxtIcon8);
					break;
				default:
					break;
			}
		}

		await Task.Delay(2000);

		await _semaphore.WaitAsync();

		try
		{
			if (sender is Label label1)
			{
				switch (label1.ClassId)
				{
					case "BtnPage1":
						AtualizarConteudo(new DashboardContent());
						break;
					case "BtnPage2":
						AtualizarConteudo(new EquipamentosContent());
						break;
					case "BtnPage3":
						AtualizarConteudo(new RegistrarInfoEquipamentoContent());
						break;
					case "BtnPage4":
						AtualizarConteudo(new RegistroHistoricoContent());
						break;
					case "BtnPage5":
						AtualizarConteudo(new CriarContaContent());
						break;
					case "BtnPage6":
						AtualizarConteudo(new EmpresasCadastradasContent());
						break;
					case "BtnPage7":
						AtualizarConteudo(new ConfiguracoesContent());
						break;
					case "BtnPage8":
						AtualizarConteudo(new AjudaContent());
						break;
					case "BtnPage9":
						ContentArea.Content = new ListaNotificacoesContent();
						viewModel.PopupNotificacaoVisivel = !viewModel.PopupNotificacaoVisivel;
						break;
					case "Eqp_Opcoes":
						AtualizarConteudo(new EquipamentoOpcoesContent());
						break;
					case "Eqp_Imagens":
						AtualizarConteudo(new ImagensEquipamentoContent());
						break;
					case "Eqp_Instrumentos":
						AtualizarConteudo(new InstrumentosSegurancaContent());
						break;
					case "Eqp_Programacao":
						AtualizarConteudo(new ProgramacaoInspecoesContent());
						break;
					case "Eqp_Relatorio":
						AtualizarConteudo(new RelatorioDigitalContent());
						break;
					case "Eqp_Recomendacao":
						AtualizarConteudo(new RecomendacaoContent());
						break;
					case "Eqp_QrCode":
						AtualizarConteudo(new QrCodeContent());
						break;
					default:
						break;
				}
			}

			// Concluir o efeito de loading
			_isLoading = false;
			await loadingTask;
		}
		finally
		{
			// Liberar o acesso e desbloquear o método
			_semaphore.Release();
			_isPageOpening = false;
		}
	}

	// Método para atualizar o conteúdo da área de conteúdo
	private void AtualizarConteudo(ContentView contentView)
	{
		ContentArea.Content = contentView;
	}

	// Método para atualizar os ícones verticais e suas cores
	private void AtualizarIcones(BoxView bxvlinha, Label txtIcon)
	{
		bxvlinha.IsVisible = true;
		txtIcon.TextColor = Colors.White;
	}

	// Método para resetar todos os ícones e suas cores
	private void ResetAllIcons()
	{
		var allBoxViews = new[] { Bxvlinha1, Bxvlinha2, Bxvlinha3, Bxvlinha4, Bxvlinha5, Bxvlinha6, Bxvlinha7, Bxvlinha8 };
		var allTxtIcons = new[] { TxtIcon1, TxtIcon2, TxtIcon3, TxtIcon4, TxtIcon5, TxtIcon6, TxtIcon7, TxtIcon8 };
		var defaultColor = Color.FromArgb("8A8A8A");

		// Resetar visibilidade de todas as BoxViews
		foreach (var boxView in allBoxViews)
		{
			boxView.IsVisible = false;
		}

		// Resetar a cor de todos os ícones de texto
		foreach (var txtIcon in allTxtIcons)
		{
			txtIcon.TextColor = defaultColor;
		}
	}
	private async Task EfeitoLoading()
	{
		GridLoading.IsVisible = true;

		while (_isLoading)
		{
			await ImgLoading.FadeTo(1, 1000, Easing.Linear);
			await ImgLoading.FadeTo(0, 1000, Easing.Linear);
		}

		GridLoading.IsVisible = false;
	}
}