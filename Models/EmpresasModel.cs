using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cronos.Models
{
    public class EmpresasModel
	{
		public int ID_Empresas { get; set; }
		[Required(ErrorMessage = "O nome da empresa é obrigatório.")]
		public string? Nome { get; set; }
		[Required(ErrorMessage = "O CNPJ é obrigatório.")]
		public string? CNPJ { get; set; }
		public string? URL_Imagem_Logo_Superior { get; set; }
		public string? URL_Imagem_Logo_Esquerdo { get; set; }
		public string? Img_QRCode { get; set; }
	}
}
