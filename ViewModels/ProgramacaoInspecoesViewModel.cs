using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Models;
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
	class ProgramacaoInspecoesViewModel : ObservableObject
	{
		#region VARIAVEIS 
		private string _TagDeBusca;
		private ObservableCollection<ProximasInspecoesModel>? _proximaInspecao;
		private ObservableCollection<UltimasInspecoesCompostaModel>? _ultimasInspecoes;
		#endregion
		#region CONSTRUTOR
		public ProgramacaoInspecoesViewModel()
		{
			_TagDeBusca = Preferences.Default.Get("TagClicada", "");
			_proximaInspecao = new ObservableCollection<ProximasInspecoesModel>();
			_ultimasInspecoes = new ObservableCollection<UltimasInspecoesCompostaModel>();
			IndicadorPressao();
		}
		#endregion
		#region OBJETOS
		public ObservableCollection<ProximasInspecoesModel> ProximaInspecao
		{
			get => _proximaInspecao ??= new ObservableCollection<ProximasInspecoesModel>();
			set => SetProperty(ref _proximaInspecao, value);
		}
		public ObservableCollection<UltimasInspecoesCompostaModel> UltimasInspecoes
		{
			get => _ultimasInspecoes ??= new ObservableCollection<UltimasInspecoesCompostaModel>();
			set => SetProperty(ref _ultimasInspecoes, value);
		}
		public string TagDeBusca
		{
			get => _TagDeBusca;
			private set => SetProperty(ref _TagDeBusca, value);
		}
		#endregion
		#region PROCESSOS               
		private void IndicadorPressao()
		{
			ProximaInspecao = new ObservableCollection<ProximasInspecoesModel>
			{
				 new ProximasInspecoesModel
				 {
					 Data_Proxima_Interna = DateTime.Now,
					 Data_Proxima_Externa = DateTime.Now,
					 Data_Testes_e_Ensaios = DateTime.Now,
					 Data_Medicao_Espessura = DateTime.Now,
					 Observacao = "Essa é uma observação."
				 },
			};
			UltimasInspecoes = new ObservableCollection<UltimasInspecoesCompostaModel>
			{
				new UltimasInspecoesCompostaModel
				{
					UltimaInspecao = new UltimaInspecaoModel
					{
						Data_Ultima_Interna = DateTime.Now,
						Data_Ultima_Externa = DateTime.Now,
						Data_Medicao_Espessura = DateTime.Now,
						Data_Testes_e_Ensaios = DateTime.Now,
						Numero_Documento_Inspecao = "15vf52626226",
						Observacao = "Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar...."
					},
					 EstimativaVidaResidual = new EstimativaVidaResidualModel
					 {
						 Taxa_Corrosao_Atual = "25",
						 Taxa_Corrosao_Historica = "100",
					 },
					 MaiorTaxaCorrosaoAtual = new MaiorTaxaCorrosaoAtualModel
					 {
						 Data_Maior_Taxa = DateTime.Now
					 },
				},
				new UltimasInspecoesCompostaModel
				{
					UltimaInspecao = new UltimaInspecaoModel
					{
						Data_Ultima_Interna = DateTime.Now,
						Data_Ultima_Externa = DateTime.Now,
						Data_Medicao_Espessura = DateTime.Now,
						Data_Testes_e_Ensaios = DateTime.Now,
						Numero_Documento_Inspecao = "15vf52626226",
						Observacao = "Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação."
					},
					 EstimativaVidaResidual = new EstimativaVidaResidualModel
					 {
						 Taxa_Corrosao_Atual = "25",
						 Taxa_Corrosao_Historica = "100",
					 },
					 MaiorTaxaCorrosaoAtual = new MaiorTaxaCorrosaoAtualModel
					 {
						 Data_Maior_Taxa = DateTime.Now
					 },
				},
				new UltimasInspecoesCompostaModel
				{
					UltimaInspecao = new UltimaInspecaoModel
					{
						Data_Ultima_Interna = DateTime.Now,
						Data_Ultima_Externa = DateTime.Now,
						Data_Medicao_Espessura = DateTime.Now,
						Data_Testes_e_Ensaios = DateTime.Now,
						Numero_Documento_Inspecao = "15vf52626226",
						Observacao = "Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação."
					},
					 EstimativaVidaResidual = new EstimativaVidaResidualModel
					 {
						 Taxa_Corrosao_Atual = "25",
						 Taxa_Corrosao_Historica = "100",
					 },
					 MaiorTaxaCorrosaoAtual = new MaiorTaxaCorrosaoAtualModel
					 {
						 Data_Maior_Taxa = DateTime.Now
					 },
				},
				new UltimasInspecoesCompostaModel
				{
					UltimaInspecao = new UltimaInspecaoModel
					{
						Data_Ultima_Interna = DateTime.Now,
						Data_Ultima_Externa = DateTime.Now,
						Data_Medicao_Espessura = DateTime.Now,
						Data_Testes_e_Ensaios = DateTime.Now,
						Numero_Documento_Inspecao = "15vf52626226",
						Observacao = "Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação.Este é um texto de observação que se pode usar...."
					},
					 EstimativaVidaResidual = new EstimativaVidaResidualModel
					 {
						 Taxa_Corrosao_Atual = "25",
						 Taxa_Corrosao_Historica = "100",
					 },
					 MaiorTaxaCorrosaoAtual = new MaiorTaxaCorrosaoAtualModel
					 {
						 Data_Maior_Taxa = DateTime.Now
					 },
				},
				new UltimasInspecoesCompostaModel
				{
					UltimaInspecao = new UltimaInspecaoModel
					{
						Data_Ultima_Interna = DateTime.Now,
						Data_Ultima_Externa = DateTime.Now,
						Data_Medicao_Espessura = DateTime.Now,
						Data_Testes_e_Ensaios = DateTime.Now,
						Numero_Documento_Inspecao = "15vf52626226",
						Observacao = "Este é um texto de observação que se pode usar para incluir algo ou oque sobre esse informação."
					},
					 EstimativaVidaResidual = new EstimativaVidaResidualModel
					 {
						 Taxa_Corrosao_Atual = "25",
						 Taxa_Corrosao_Historica = "100",
					 },
					 MaiorTaxaCorrosaoAtual = new MaiorTaxaCorrosaoAtualModel
					 {
						 Data_Maior_Taxa = DateTime.Now
					 },
				},
			};
		}

		private void Voltar()
		{
			WeakReferenceMessenger.Default.Send(new MensageriaService("Eqp_Opcoes"));
		}
		#endregion
		#region COMANDOS
		public ICommand Btn_Voltar => new Command(Voltar);
		#endregion
	}
}
