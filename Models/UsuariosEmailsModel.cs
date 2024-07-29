using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cronos.Models
{
    public class UsuariosEmailsModel
    {
		public int ID_Usuarios_Emails { get; set; }
		[Required(ErrorMessage = "O campo nome responsável é obrigatório.")]
		public string? Nome_Responsavel { get; set; }
		[Required(ErrorMessage = "O campo e-mail é obrigatório.")]
		public string? Email { get; set; }
		public string? Tipo { get; set; }
	}
}
