using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronos.ViewModels
{
	internal class EquipamentoOpcoesViewModel : ObservableObject
	{
		#region VARIAVEIS 
		private bool _LoadingPage = false;
		private string _TagDeBusca;
		#endregion
		#region CONSTRUTOR
		public EquipamentoOpcoesViewModel()
		{
			_TagDeBusca = Preferences.Default.Get("TagClicada", "");
		}
		#endregion
		#region OBJETOS
		public string TagDeBusca
		{
			get => _TagDeBusca;
			private set => SetProperty(ref _TagDeBusca, value);
		}
		public bool LoadingPage
		{
			get => _LoadingPage;
			private set => SetProperty(ref _LoadingPage, value);
		}
		#endregion
		#region PROCESSOS               
		private void OpenLoadingPage() => LoadingPage = true;

		private async Task CloseLoadingPage()
		{
			await Task.Delay(3000);
			LoadingPage = false;
			
		}
		private void AbrirOpcaoClicada(string opcaoClicada)
		{
			WeakReferenceMessenger.Default.Send(new MensageriaService(opcaoClicada));
		}
		#endregion
		#region COMANDOS
		public ICommand Btn_CloseLoadingPage => new AsyncRelayCommand(CloseLoadingPage);
		public ICommand Btn_AbrirOpcaoClicada => new Command<string>(AbrirOpcaoClicada);
		#endregion
	}
}
