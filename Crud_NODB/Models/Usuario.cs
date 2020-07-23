using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_NODB.Models
{
	public class Usuario
	{
		public int UsuarioID { get; set; }
		public string Nome { get; set; }
		public int Idade { get; set; }
		public string Email { get; set; }
	}
}
