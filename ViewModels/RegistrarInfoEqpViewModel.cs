using CommunityToolkit.Mvvm.ComponentModel;
using Cronos.Models;
using Cronos.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cronos.Bases;

namespace Cronos.ViewModels
{
	internal class RegistrarInfoEqpViewModel : ValidatableObservableObject
	{
		#region VARIAVEIS
		private ObservableCollection<SetorModel> _setores;
		private SetorModel _selectedSetor;
		private SetorModel _selectedGlobalSetor;
		private bool _ExpandAccordSetores = false;

		private string? _CorTema;
		private Button? _backgroundBtn;
		#endregion

		#region CONSTRUTOR
		public RegistrarInfoEqpViewModel()
		{	
			_selectedSetor = new SetorModel();
			_setores = new ObservableCollection<SetorModel>();
			_selectedGlobalSetor = _selectedSetor;

			CorTemaButtons();
			BackgroundBtn = new Button { BackgroundColor = Color.FromArgb(CorTemaButtons()) };
		}
		#endregion

		#region OBJETOS
		public ObservableCollection<SetorModel> Setores
		{
			get => _setores;
			set => SetProperty(ref _setores, value);
		}

		public SetorModel SelectedSetor
		{
			get => _selectedSetor;
			set => SetProperty(ref _selectedSetor, value);
		}
		
		public SetorModel SelectedGlobalSetor
		{
			get => _selectedGlobalSetor;
			set => SetProperty(ref _selectedGlobalSetor, value);
		}
		public bool ExpandAccordSetores
		{
			get => _ExpandAccordSetores;
			set => SetProperty(ref _ExpandAccordSetores, value);
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
		private void SelectSetor(SetorModel Setor)
		{
			if (Setor != null)
			{
				Setores.Remove(Setor);
				Setores.Insert(0, Setor);
				SelectedSetor = Setor;
				SelectedGlobalSetor = Setor; // Atualiza a variável global com o Setoro selecionado
				ExpandAccordSetores = false;
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
		#endregion

		#region COMANDOS
		public IRelayCommand<SetorModel> SelectSetorCommand => new RelayCommand<SetorModel>(SelectSetor);
		#endregion
	}
}
