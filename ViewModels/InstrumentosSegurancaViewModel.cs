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
    class InstrumentosSegurancaViewModel : ObservableObject
	{
		#region VARIAVEIS 
		private string _TagDeBusca;
		private ObservableCollection<IndicadoresPressaoModel>? _indicadores;
		#endregion
		#region CONSTRUTOR
		public InstrumentosSegurancaViewModel()
		{	
			_TagDeBusca = Preferences.Default.Get("TagClicada", "");
			_indicadores = new ObservableCollection<IndicadoresPressaoModel>();
			IndicadorPressao();
		}
		#endregion
		#region OBJETOS
		public ObservableCollection<IndicadoresPressaoModel> Indicadores
		{
			get => _indicadores ??= new ObservableCollection<IndicadoresPressaoModel>();
			set => SetProperty(ref _indicadores, value);
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
			Indicadores = new ObservableCollection<IndicadoresPressaoModel>
			{
				 new IndicadoresPressaoModel
				 {
					 Identificacao_Tag = "Sem identificação - Localizado na linha 10",
					 Numero_Certificado = "Não Encontrada",
					 Ultima_Calibracao = DateTime.Now,
				 },
				  new IndicadoresPressaoModel
				 {
					 Identificacao_Tag = "Sem identificação - Localizado na linha 10",
					 Numero_Certificado = "Não Encontrada",
					 Ultima_Calibracao = DateTime.Now,
				 },
				   new IndicadoresPressaoModel
				 {
					 Identificacao_Tag = "Sem identificação - Localizado na linha 10",
					 Numero_Certificado = "Não Encontrada",
					 Ultima_Calibracao = DateTime.Now,
				 },
					new IndicadoresPressaoModel
				 {
					 Identificacao_Tag = "Sem identificação - Localizado na linha 10",
					 Numero_Certificado = "Não Encontrada",
					 Ultima_Calibracao = DateTime.Now,
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
