using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
    public class LogradourosModel
    {
		public int ID_Logradouros { get; set; }
		[Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
		public string? Logradouro { get; set; }
		public string? Numero_Logradouro { get; set; }
		public string? Bairro { get; set; }
		[Required(ErrorMessage = "O campo cidade é obrigatório.")]
		public string? Cidade { get; set; }
		[Required(ErrorMessage = "O campo estado é obrigatório.")]
		public string? Estado { get; set; }
		[Required(ErrorMessage = "O campo CEP é obrigatório.")]
		public string? CEP { get; set; }
		public string? Complemento { get; set; }

	}
}
