using CommunityToolkit.Mvvm.ComponentModel;
using Cronos.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cronos.ViewModels
{
    class ListaNotificacoesViewModels : ObservableObject
    {
        private ObservableCollection<NotificacoesGeraisModel>? _notificacoes;
        public ListaNotificacoesViewModels() 
        {
            _notificacoes = new ObservableCollection<NotificacoesGeraisModel>();
			InicializadorDadosFicticios();

		}
		public ObservableCollection<NotificacoesGeraisModel> Notificacoes
		{
			get => _notificacoes ??= new ObservableCollection<NotificacoesGeraisModel>();
			set => SetProperty(ref _notificacoes, value);
		}
		public void InicializadorDadosFicticios()
		{
			Notificacoes = new ObservableCollection<NotificacoesGeraisModel>
			{
				new NotificacoesGeraisModel
				{
					Data_Criacao = DateTime.Now,
					Tipo = "Promoções",
					Mensagem = "Essa é um exemplo de um texto que pode ser enviado como uma mensagem de promoção de algum plano ou upgrade para um plano melhor, no sistema de inspeções nr-13 idealle onde se pode gerenciar o processo de inspeções de sua industria online remotamente de qualquer lugar de seu desktop conectado a internet."
				},
				new NotificacoesGeraisModel
				{
					Data_Criacao = DateTime.Now,
					Tipo = "Promoções",
					Mensagem = "Essa é um exemplo de um texto que pode ser enviado como uma mensagem de promoção de algum plano ou upgrade para um plano melhor, no sistema de inspeções nr-13 idealle onde se pode gerenciar o processo de inspeções de sua industria online remotamente de qualquer lugar de seu desktop conectado a internet."
				},
			};
		}
	}
}
