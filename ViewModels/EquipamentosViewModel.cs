using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Bases;
using Cronos.Models;
using Cronos.Services;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronos.ViewModels
{
	internal class EquipamentosViewModel : ValidatableObservableObject
	{
		#region VARIAVEIS
		private ObservableCollection<EquipamentoCompostoModel>? _equipamentos;
		#endregion

		#region CONSTRUTOR
		public EquipamentosViewModel()
		{
			Equipamentos = new ObservableCollection<EquipamentoCompostoModel>();
			CarregarDadosFicticios();
		}
		#endregion

		#region OBJETOS
		public ObservableCollection<EquipamentoCompostoModel> Equipamentos
		{
			get => _equipamentos ??= new ObservableCollection<EquipamentoCompostoModel>();
			set => SetProperty(ref _equipamentos, value);
		}
		#endregion

		#region PROCESSOS
		private void CarregarDadosFicticios()
		{
			Equipamentos = new ObservableCollection<EquipamentoCompostoModel>
			{
				new EquipamentoCompostoModel
				{
					Equipamento = new EquipamentosModel
					{
						ID_Equipamentos = 1,
						Tag = "TAG1234",
						Localizacao = "Localização A",
						Status_Equipamento = "Operacional"
					},
					UltimaInspecao = new UltimaInspecaoModel
					{
						Data_Ultima_Interna = new DateTime(2023, 1, 15),
						Data_Ultima_Externa = new DateTime(2023, 1, 16)
					},
					ProximasInspecoes = new ProximasInspecoesModel
					{
						Data_Proxima_Interna = new DateTime(2024, 1, 15),
						Data_Proxima_Externa = new DateTime(2024, 1, 16)
					},
					ClassificacaoNR13 = new ClassificacaoNR13Model
					{
						Classe_Fluido = "Classe A",
						Grupo_Potencial_Risco = "Grupo I",
						Categoria = "Categoria 1"
					},
					Projeto = new ProjetoModel
					{
						Volume = "1000L",
						PMTA = "150 PSI",
						Pressao_Teste_Hidrosatico = "200 PSI"
					},
					Operacao = new OperacaoModel
					{
						Fluido = "Água",
						Pressao_Maxima = "120 PSI"
					}
				},

				new EquipamentoCompostoModel
				{
					Equipamento = new EquipamentosModel
					{
						ID_Equipamentos = 1,
						Tag = "TAG00000",
						Localizacao = "Localização A",
						Status_Equipamento = "Operacional"
					},
					UltimaInspecao = new UltimaInspecaoModel
					{
						Data_Ultima_Interna = new DateTime(2023, 1, 15),
						Data_Ultima_Externa = new DateTime(2023, 1, 16)
					},
					ProximasInspecoes = new ProximasInspecoesModel
					{
						Data_Proxima_Interna = new DateTime(2024, 1, 15),
						Data_Proxima_Externa = new DateTime(2024, 1, 16)
					},
					ClassificacaoNR13 = new ClassificacaoNR13Model
					{
						Classe_Fluido = "Classe A",
						Grupo_Potencial_Risco = "Grupo I",
						Categoria = "Categoria 1"
					},
					Projeto = new ProjetoModel
					{
						Volume = "1000L",
						PMTA = "150 PSI",
						Pressao_Teste_Hidrosatico = "200 PSI"
					},
					Operacao = new OperacaoModel
					{
						Fluido = "Água",
						Pressao_Maxima = "120 PSI"
					}
				},
                // Adicione mais equipamentos fictícios conforme necessário
            };
		}
		/*private async Task CarregarEquipamentosAsync()
		{
			var equipamentos = await EquipamentoService.GetEquipamentosAsync();
			Equipamentos = new ObservableCollection<EquipamentosModel>(equipamentos);
		}*/
		
		/*private static async Task ArmazenarTagClicada(string tag)
		{
			string salvarTag = tag.ToString();

			await SecureStorage.SetAsync("tagClicada", salvarTag);
		}*/
		private void AbrirOpcoes(string parameter)
		{
			Preferences.Default.Set("TagClicada", parameter);

			WeakReferenceMessenger.Default.Send(new MensageriaService("Eqp_Opcoes"));
		}
		#endregion

		#region COMANDOS
		//public ICommand CarregarEquipamentosCommand { get; }
		public ICommand Btn_AbrirOpcoes => new Command<string>(AbrirOpcoes);
		#endregion
	}
}
