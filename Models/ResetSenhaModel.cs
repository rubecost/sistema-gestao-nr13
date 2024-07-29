using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
    public class ResetSenhaModel
    {
		public int ID_Reset_Senha { get; set; }
		public string? Codigo { get; set; }
		public DateTime Timestamp { get; set; }
		public DateTime Expiracao { get; set; }

	}
}
