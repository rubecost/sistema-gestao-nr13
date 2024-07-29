using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Bases;
using Cronos.Models;
using Cronos.Services;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronos.ViewModels
{
	internal class RegistroHistoricoViewModel : ValidatableObservableObject
	{
		#region VARIAVEIS
		private ObservableCollection<RegistroHistoricoModel>? _registros;
		#endregion

		#region CONSTRUTOR
		public RegistroHistoricoViewModel()
		{
			Registros = [];
			CarregarregistrosDeExemplo();
		}
		#endregion
		#region OBJETOS
		public ObservableCollection<RegistroHistoricoModel> Registros
		{
			get => _registros ??= [];
			set => SetProperty(ref _registros, value);
		}
		#endregion
		#region PROCESSOS
		private void CarregarregistrosDeExemplo()
		{
			Registros =
			[
				new RegistroHistoricoModel
				{
					Email_Usuario = "julio@idealle.com.br",
					Nome_Unidade = "Unidade Idealle jaçanam 3",
					Setor = "Manutenção Preventiva",
					TipoAtualizacao = TipoAtualizacao.Criou,
					Item_Atualizado = "Registrar Informações sobre Equipamento",
					Data_Hora = DateTime.Now,
				},
				new RegistroHistoricoModel
				{
					Email_Usuario = "julio@idealle.com.br",
					Nome_Unidade = "Unidade Idealle jaçanam 3",
					Setor = "Manutenção Preventiva",
					TipoAtualizacao = TipoAtualizacao.Criou,
					Item_Atualizado = "Registrar Informações sobre Equipamento",
					Data_Hora = DateTime.Now,
				},
				new RegistroHistoricoModel
				{
					Email_Usuario = "julio@idealle.com.br",
					Nome_Unidade = "Unidade Idealle jaçanam 3",
					Setor = "Manutenção Preventiva",
					TipoAtualizacao = TipoAtualizacao.Criou,
					Item_Atualizado = "Registrar Informações sobre Equipamento",
					Data_Hora = DateTime.Now,
				},
			];
		}

		//CarregarRegistrosCommand = new AsyncRelayCommand(CarregarRegistrosAsync);

		private async Task CarregarRegistrosAsync()
		{
			var registros = await RegistroHistoricoService.GetRegistroHistoricoAsync();
			registros = new ObservableCollection<RegistroHistoricoModel>(registros);
		}
		private void NavegarResultados()
		{
		    WeakReferenceMessenger.Default.Send(new MensageriaService("OnEfeitoLoading"));
		}
		#endregion

		#region COMANDOS
		//public ICommand CarregarRegistrosCommand { get; }
		public ICommand Btn_NavegarResultados => new Command(NavegarResultados);
		#endregion
	}
}
