using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
    public class UnidadesModel
    {
		public int ID_Unidades { get; set; }
		[Required(ErrorMessage = "O campo nome da unidade é obrigatório.")]
		public string? Nome { get; set; }
		public string? Responsavel { get; set; }
		public string? Email { get; set; }
		public DateTime Data_Criacao { get; set; }
	}
}
