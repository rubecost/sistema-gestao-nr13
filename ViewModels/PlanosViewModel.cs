using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Cronos.Bases;
using Cronos.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Cronos.ViewModels
{
	public partial class PlanosViewModel : ValidatableObservableObject
	{
		#region VARIAVEIS
		private PlanosModel _selectedPlan;
		private PlanosModel _selectedGlobalPlan;
		private bool _ExpandAccordPlanos = false;
		#endregion

		#region CONSTRUTOR
		public PlanosViewModel() 
		{
			_selectedPlan = new PlanosModel();
			_selectedGlobalPlan = _selectedPlan;
		}
		#endregion

		#region OBJETOS
		public PlanosModel SelectedPlan
		{
			get => _selectedPlan;
			set => SetProperty(ref _selectedPlan, value);
		}
		public PlanosModel SelectedGlobalPlan
		{
			get => _selectedGlobalPlan;
			set => SetProperty(ref _selectedGlobalPlan, value);
		}
		public bool ExpandAccordPlanos
		{
			get => _ExpandAccordPlanos;
			set => SetProperty(ref _ExpandAccordPlanos, value);
		}
		public ObservableCollection<PlanosModel> Plans { get; } = new ObservableCollection<PlanosModel>();
		#endregion

		#region PROCESSOS
		[RelayCommand]
		public void SalvarPlano()
		{
			// Se a propriedade 'Nome' não for válida, a validação irá falhar e exibir o alerta
			if (ValidateProperty(_selectedPlan.Nome, nameof(_selectedPlan.Nome)))
			{
				// Código para salvar o plano na API
			}
		}
		private void SelectPlan(PlanosModel plan)
		{
			if (plan != null)
			{
				Plans.Remove(plan);
				Plans.Insert(0, plan);
				SelectedPlan = plan;
				SelectedGlobalPlan = plan; // Atualiza a variável global com o plano selecionado
				ExpandAccordPlanos = false;
			}
		}

		public async Task LoadPlansAsync()
		{
			
			using var httpClient = new HttpClient();
			var response = await httpClient.GetStringAsync("https://localhost:7037/api/Plano/nomes");
			var planNames = System.Text.Json.JsonSerializer.Deserialize<List<string>>(response);

			Plans.Clear();

			if (planNames != null)
			{
				foreach (var nome in planNames)
				{
					Plans.Add(new PlanosModel { Nome = nome });
				}
				if (Plans.Count > 0)
				{
					SelectedPlan = Plans[0];
					SelectedGlobalPlan = Plans[0]; // Define o primeiro plano como o global inicialmente
				}
			}
		}
		#endregion

		#region COMANDOS
		public IRelayCommand<PlanosModel> SelectPlanCommand => new RelayCommand<PlanosModel>(SelectPlan);
		public IAsyncRelayCommand LoadPlansCommand => new AsyncRelayCommand(LoadPlansAsync);
		#endregion
	}
}
