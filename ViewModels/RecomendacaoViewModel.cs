using System;
using Cronos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Services;
using System.Windows.Input;
using Windows.ApplicationModel.UserDataTasks;

namespace Cronos.ViewModels
{
	class RecomendacaoViewModel : ObservableObject
	{
		#region VARIAVEIS 
		private string _TagDeBusca;
		private ObservableCollection<RecomendacoesCompostoModel>? _recomendacoes;
		private bool _IsEntryEnabled;
		private string? _CorTema;
		private Button? _backgroundBtn;
		#endregion
		#region CONSTRUTOR
		public RecomendacaoViewModel()
		{
			_TagDeBusca = Preferences.Default.Get("TagClicada", "");
			_recomendacoes = new ObservableCollection<RecomendacoesCompostoModel>();
			IsEntryEnabled = false;
			InicializadorDadosFicticios();

			CorTemaButtons();
			BackgroundBtn = new Button { BackgroundColor = Color.FromArgb(CorTemaButtons()) };
		}
		#endregion
		#region OBJETOS
		public bool IsEntryEnabled
		{
			get => _IsEntryEnabled;
			set => SetProperty(ref _IsEntryEnabled, value);
		}
		public string TagDeBusca
		{
			get => _TagDeBusca;
			private set => SetProperty(ref _TagDeBusca, value);
		}
		public ObservableCollection<RecomendacoesCompostoModel> Recomendacao
		{
			get => _recomendacoes ??= new ObservableCollection<RecomendacoesCompostoModel>();
			set => SetProperty(ref _recomendacoes, value);
		}
		public string? CorTema
		{
			get => _CorTema ??= string.Empty;
			private set => SetProperty(ref _CorTema, value);
		}
		public Button BackgroundBtn
		{
			get => _backgroundBtn ??= new Button();
			set => SetProperty(ref _backgroundBtn, value);
		}
		#endregion
		#region PROCESSOS  
		public void InicializadorDadosFicticios()
		{
			Recomendacao = new ObservableCollection<RecomendacoesCompostoModel>
			{
				new RecomendacoesCompostoModel
				{
					Recomendacoes = new RecomendacoesModel
					{
						Data_Criacao = DateTime.Now,
						Texto = "1- SUBSTITUIR MANÔMETRO DANIFICADO. O MANÔMETRO NOVO DEVERÁ SER CALIBRADO E SEU CERTIFICADO DE CALIBRAÇÃO ANEXO AO DATA BOOK NR-13; 2- RECUPERAR PINTURA ONDE INDICADO NO RELATÓRIO; 3- LIMPAR CANALETAS; 4- IDENTIFICAR VÁLVULAS DE BLOQUEIO; 5- SOLICITAR À COMGÁS OS CERTIFICADOS DE CALIBRAÇÕES DAS PSV's.",
						Status_Recomendacao = StatusRecomendacao.ParcialmenteAtendida,
						Data_Atualizacao_Status = DateTime.Now,
						Detalhes_Parcial = "4- IDENTIFICAR VÁLVULAS DE BLOQUEIO; \r\n5- SOLICITAR À COMGÁS OS CERTIFICADOS DE CALIBRAÇÕES DAS PSV's."

					},
					Equipamentos = new EquipamentosModel
					{
						Tag = "GN-MC-001-Ba-NI"
					}
				}
			};
			
		}
		private void BtnStatus(string parametro)
		{
			if(parametro == "Atendida")
			{
				IsEntryEnabled = false;
			}
			else if(parametro == "Parcialmente")
			{
				IsEntryEnabled = true;
			}	
		}
		private string CorTemaButtons()
		{
			bool hasKey = Preferences.Default.ContainsKey("KeyBtnColor");

			if (hasKey)
			{
				CorTema = Preferences.Default.Get("KeyBtnColor", "");
			}
			else
			{
				CorTema = "EB9C25";
			}

			return CorTema;
		}
		private void Voltar()
		{
			WeakReferenceMessenger.Default.Send(new MensageriaService("Eqp_Opcoes"));
		}
		#endregion
		#region COMANDOS
		public ICommand Btn_Voltar => new Command(Voltar);
		public ICommand Btn_Status => new Command<string>(BtnStatus);
		#endregion
	}
}
