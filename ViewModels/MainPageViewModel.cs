using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Bases;
using Cronos.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronos.ViewModels
{
	internal class MainPageViewModel : ValidatableObservableObject
	{
		#region VARIAVEIS 
		private ObservableCollection<string> _notificacoes;
		private bool _popupNotificacaoVisivel;
		#endregion

		#region CONSTRUTOR
		public MainPageViewModel()
		{
			_notificacoes = new ObservableCollection<string>();
			CarregarNotificacoes();
		}
		#endregion

		#region OBJETOS
		public ObservableCollection<string> Notificacoes
		{
			get => _notificacoes;
			private set => SetProperty(ref _notificacoes, value);
		}

		public bool PopupNotificacaoVisivel
		{
			get => _popupNotificacaoVisivel;
			set => SetProperty(ref _popupNotificacaoVisivel, value);
		}
		#endregion

		#region PROCESSOS
		private async void CarregarNotificacoes()
		{
			// Simulação de carregamento de notificações da API
			await Task.Delay(1000); // Substitua com sua chamada real à API
			Notificacoes.Add("Nova inspeção agendada para 10/07/2024.");
			Notificacoes.Add("Equipamento X necessita de manutenção.");
			Notificacoes.Add("Atualização de política de segurança.");
			Notificacoes.Add("Atualização de política de segurança.");
			Notificacoes.Add("Atualização de política de segurança.");
			Notificacoes.Add("Atualização de política de segurança.");
		}

		private void AlternarPopupNotificacao()
		{
			PopupNotificacaoVisivel = !PopupNotificacaoVisivel;
		}
		private void AbrirPages(string nomepage)
		{
			WeakReferenceMessenger.Default.Send(new MensageriaService(nomepage));
		}
		#endregion
		#region COMANDOS
		public ICommand Btn_TogglePopupNotificacao => new RelayCommand(AlternarPopupNotificacao);
		public ICommand Btn_AbrirPages => new Command<string>(AbrirPages);
		#endregion
	}
}
