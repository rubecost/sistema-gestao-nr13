using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cronos.Models
{
	public class TelefonesModel
	{
		public int ID_Telefones { get; set; }
		public string? Tipo { get; set; }
		public string? Numero { get; set; }
	}
}
