using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Services;
using Cronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using System.Collections.ObjectModel;

namespace Cronos.ViewModels
{
	class QrCodeViewModel : ObservableObject
	{
		#region VARIAVEIS 
		private string _TagDeBusca;
		private ObservableCollection<EmpresasModel>? _empresa;
		#endregion
		#region CONSTRUTOR
		public QrCodeViewModel()
		{
			_TagDeBusca = Preferences.Default.Get("TagClicada", "");
			_empresa = [];
		}
		#endregion
		#region OBJETOS
		public ObservableCollection<EmpresasModel> Empresa
		{
			get => _empresa ??= [];
			set => SetProperty(ref _empresa, value);
		}
		public string TagDeBusca
		{
			get => _TagDeBusca;
			private set => SetProperty(ref _TagDeBusca, value);
		}
		#endregion
		#region PROCESSOS               
		private void ObterUrlQrCode()
		{
			Empresa =
		    [
				 new EmpresasModel
				 {
					 Img_QRCode = "https://i.postimg.cc/nrMKWW5f/QrCode.png"
				 }
		    ];
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
