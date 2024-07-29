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
    class RelatorioDigitalViewModel : ObservableObject
    {
		#region VARIAVEIS 
		private string _TagDeBusca;
		private ObservableCollection<RelatorioDigitalCompostoModel>? _relatoriocomposto;

		#endregion
		#region CONSTRUTOR
		public RelatorioDigitalViewModel()
		{
			_TagDeBusca = Preferences.Default.Get("TagClicada", "");
			_relatoriocomposto = new ObservableCollection<RelatorioDigitalCompostoModel>();
			InicializadorDadosFicticios();
		
		}
		#endregion
		#region OBJETOS
		public string TagDeBusca
		{
			get => _TagDeBusca;
			private set => SetProperty(ref _TagDeBusca, value);
		}
		public ObservableCollection<RelatorioDigitalCompostoModel> RelatorioComposto
		{
			get => _relatoriocomposto ??= new ObservableCollection<RelatorioDigitalCompostoModel>();
			set => SetProperty(ref _relatoriocomposto, value);
		}

		#endregion
		#region PROCESSOS  
		public void InicializadorDadosFicticios()
		{
			RelatorioComposto = new ObservableCollection<RelatorioDigitalCompostoModel>
			{
				new RelatorioDigitalCompostoModel
				{
					DataEmissao1 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2023,08,05),
						Nome = "Inspeção da caldeira interna",
						Descricao = "A caldeira interna estava em pessimas condições de uso por isso recomenda-se manutenção com urgencia.",
						Anexos = "https://learn.microsoft.com/dotnet/maui"

					},
					DataEmissao2 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2022,05,05),
						Nome = "Inspeção da caldeira interna",
						Descricao = "A caldeira interna estava em pessimas condições de uso por isso recomenda-se manutenção com urgencia.",
						Anexos = "https://learn.microsoft.com/dotnet/maui"
					},
					DataEmissao3 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2021,09,05),
						Nome = "Inspeção da caldeira interna",
						Descricao = "A caldeira interna estava em pessimas condições de uso por isso recomenda-se manutenção com urgencia.",
						Anexos = "https://learn.microsoft.com/dotnet/maui"
					},
					DataEmissao4 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2020,07,05),
						Nome = "Inspeção da caldeira interna",
						Descricao = "A caldeira interna estava em pessimas condições de uso por isso recomenda-se manutenção com urgencia.",
						Anexos = "https://learn.microsoft.com/dotnet/maui"
					},
					DataEmissao5 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2019,07,05)
					},
					DataEmissao6 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2018,07,05)
					},
					DataEmissao7 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2017,07,05)
					},
					DataEmissao8 = new RelatorioDigitalModel
					{
						Data_Emissao = new DateTime(2016,07,05)
					}
				}
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
