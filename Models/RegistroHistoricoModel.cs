using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
	public enum TipoAtualizacao
	{
		Criou,
		Atualizou,
		Deletou
	}

	public class RegistroHistoricoModel
	{
		public int ID_Registro_Historico { get; set; }
		public string? Nome_Unidade { get; set; }
		public string? Email_Usuario { get; set; }
		public string? Setor { get; set; }
		public TipoAtualizacao TipoAtualizacao { get; set; }
		public string? Item_Atualizado { get; set; }
		public DateTime Data_Hora { get; set; }
	}
}
