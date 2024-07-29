using CommunityToolkit.Mvvm.ComponentModel;
using Cronos.Bases;
using Cronos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.ViewModels
{
	public class EmpresasCadastradasViewModel : ObservableObject
	{
		private ObservableCollection<EmpresasCompostoModel> _dadosEmpresa;

		public EmpresasCadastradasViewModel()
		{
			_dadosEmpresa = new ObservableCollection<EmpresasCompostoModel>();
			DadosFicticios();
		}
		public ObservableCollection<EmpresasCompostoModel> DadosEmpresa
		{
			get => _dadosEmpresa ??= new ObservableCollection<EmpresasCompostoModel>();
			set => SetProperty(ref _dadosEmpresa, value);
		}
		private void DadosFicticios()
		{
			DadosEmpresa = new ObservableCollection<EmpresasCompostoModel>
			{
			    new EmpresasCompostoModel
			    {
				    Empresas = new EmpresasModel 
				    { 
					    Nome = "Empresa A" 
				    },	
			        Unidades = new ObservableCollection<UnidadesModel>
				    {
					    new UnidadesModel 
					    { 
					        Nome = "Unidade 1", 
						    Responsavel = "João Silva", 
						    Email = "joao.silva@empresaA.com" 
					    },
					    new UnidadesModel 
				    	{ 
						   Nome = "Unidade 2", 
						   Responsavel = "Maria Souza", 
						   Email = "maria.souza@empresaA.com" 
					    }
				    },
				    TelFixo = "(11) 1234-5678",
				    TelCelular = "(11) 91234-5678",
				    EnderecoCompleto = "Rua A, 123, São Paulo, SP"
			    },
			new EmpresasCompostoModel
			{
				Empresas = new EmpresasModel { Nome = "Empresa B" },
				Unidades = new ObservableCollection<UnidadesModel>
				{
					new UnidadesModel 
					{ 
						Nome = "Unidade 1", 
						Responsavel = "Carlos Lima", 
						Email = "carlos.lima@empresaB.com" 
					},
					new UnidadesModel 
					{ 
						Nome = "Unidade 2", 
						Responsavel = "Ana Pereira", 
						Email = "ana.pereira@empresaB.com" 
					}
				},
				TelFixo = "(11) 5678-1234",
				TelCelular = "(11) 98765-4321",
				EnderecoCompleto = "Rua B, 456, Rio de Janeiro, RJ"
			}
			};

		}	
	}
}
