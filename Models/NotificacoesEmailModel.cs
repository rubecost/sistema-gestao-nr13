using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.Models
{
	public class NotificacoesEmailModel
	{
		public int ID_Notificacoes_Email { get; set; }
		[Required(ErrorMessage = "O campo Tipo da mensagem é obrigatório.")]
		public string? Tipo { get; set; }
		[Required(ErrorMessage = "O campo mensagem é obrigatório.")]
		public string? Mensagem { get; set; }
		public string? Estatus_Notificacao { get; set; }
		public DateTime Data_Envio { get; set; }
		public string Status_Email { get; set; } = "Pendente";
		public int Tentativas_Envio { get; set; } = 0;
	}
}
