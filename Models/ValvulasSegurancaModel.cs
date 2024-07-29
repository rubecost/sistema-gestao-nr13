using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
    public class ValvulasSegurancaModel
    {
		public int ID_Valvulas_Seguranca { get; set; }
		public string? Identificacao_Tag { get; set; }
		public string? Pressao_Abertura { get; set; }
		public string? Bitola { get; set; }
		public string? DCBI { get; set; }
		public DateTime Ultima_Calibracao { get; set;  }
		public string? Numero_Certificado { get; set; }
	}
}
