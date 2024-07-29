using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
    public class FuncionalidadesModel
    {
		public int ID_Funcionalidades { get; set; }
		[Required(ErrorMessage = "O campo nome das funcionalidades é obrigatório.")]
		public string? Nome { get; set; }
		public string? Descricao { get; set; }
		public string? Ativa { get; set; }

	}
}
