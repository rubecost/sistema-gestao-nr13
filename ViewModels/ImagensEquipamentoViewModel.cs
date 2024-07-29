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
	class ImagensEquipamentoViewModel : ObservableObject
	{
		#region VARIAVEIS 
		private string _TagDeBusca;
		private ObservableCollection<ImgEquipamentoCompostoModel>? _grupoimagens;
		#endregion
		#region CONSTRUTOR
		public ImagensEquipamentoViewModel()
		{
			_TagDeBusca = Preferences.Default.Get("TagClicada", "");
			_grupoimagens = new ObservableCollection<ImgEquipamentoCompostoModel>();
			InicializadorDadosFicticios();
		}
		#endregion
		#region OBJETOS
		public ObservableCollection<ImgEquipamentoCompostoModel> GrupoImagens
		{
			get => _grupoimagens ??= new ObservableCollection<ImgEquipamentoCompostoModel>();
			set => SetProperty(ref _grupoimagens, value);
		}
		public string TagDeBusca
		{
			get => _TagDeBusca;
			private set => SetProperty(ref _TagDeBusca, value);
		}
		#endregion
		#region PROCESSOS               
		private void InicializadorDadosFicticios()
		{
			GrupoImagens = new ObservableCollection<ImgEquipamentoCompostoModel>
			{
				 new ImgEquipamentoCompostoModel
				 {
					DescricaoImagens = new DescricaoImagensModel
					{
						Descricao = "Esse é um exemplo de descrição que pode ser inserido em uma imagem para identicar ou guardar algum comentario sobre o equipamento",
					},
					ImagensEquipamento = new ImagensEquipamentoModel
					{
						Data_Criacao = DateTime.Now,

						URLs_Imagens = new ObservableCollection<string>
				        {
							"https://blog.kalatec.com.br/wp-content/uploads/2021/01/equipamentos-industriais.jpg",
							"https://respostas.sebrae.com.br/wp-content/uploads/2022/02/vantagem-caldeira-industria-959x615.jpg",
							"https://www.isen.com.br/wp-content/uploads/2021/08/utilidades-industriais-152641-300x277.jpg",
							"https://blog.kalatec.com.br/wp-content/uploads/2021/01/equipamentos-industriais.jpg",
							"https://respostas.sebrae.com.br/wp-content/uploads/2022/02/vantagem-caldeira-industria-959x615.jpg",
							"https://www.isen.com.br/wp-content/uploads/2021/08/utilidades-industriais-152641-300x277.jpg",
							"https://respostas.sebrae.com.br/wp-content/uploads/2022/02/vantagem-caldeira-industria-959x615.jpg"
						}
					},
				 },
				 new ImgEquipamentoCompostoModel
				 {
					DescricaoImagens = new DescricaoImagensModel
					{
						Descricao = "Esse é um exemplo de descrição que pode ser inserido em uma imagem para identicar ou guardar algum comentario sobre o equipamento",
					},
					ImagensEquipamento = new ImagensEquipamentoModel
					{
						Data_Criacao = DateTime.Now,

						URLs_Imagens = new ObservableCollection<string>
						{
							"https://blog.kalatec.com.br/wp-content/uploads/2021/01/equipamentos-industriais.jpg",
							"https://respostas.sebrae.com.br/wp-content/uploads/2022/02/vantagem-caldeira-industria-959x615.jpg",
							"https://www.isen.com.br/wp-content/uploads/2021/08/utilidades-industriais-152641-300x277.jpg",
							"https://blog.kalatec.com.br/wp-content/uploads/2021/01/equipamentos-industriais.jpg",
							"https://respostas.sebrae.com.br/wp-content/uploads/2022/02/vantagem-caldeira-industria-959x615.jpg",
							"https://www.isen.com.br/wp-content/uploads/2021/08/utilidades-industriais-152641-300x277.jpg",
							"https://respostas.sebrae.com.br/wp-content/uploads/2022/02/vantagem-caldeira-industria-959x615.jpg"
						}
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