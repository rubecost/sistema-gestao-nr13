using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
	public class EmpresasCompostoModel
	{
		public EmpresasModel? Empresas { get; set; }
		public ObservableCollection<UnidadesModel>? Unidades { get; set; }
		public string? TelFixo { get; set; }
		public string? TelCelular { get; set; }
		public string? EnderecoCompleto { get; set; }
	}
}
