using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Entidades
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Telefono { get; set; }
		public string Contrasenia { get; set; }
		public int RolId { get; set; }
		public Rol Rol { get; set; }
		public bool Activo { get; set; }
	}
}
