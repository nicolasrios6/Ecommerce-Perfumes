using EcommercePerfumes.Datos;
using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Negocio
{
	public class UsuarioNegocio
	{
		public bool Registrar(Usuario nuevoUsuario)
		{
			UsuarioDatos datos = new UsuarioDatos();

			if(datos.BuscarPorEmail(nuevoUsuario.Email))
			{
				return false;
			}

			datos.Registrar(nuevoUsuario);
			return true;
		}

		public Usuario Login(string email, string contrasenia)
		{
			UsuarioDatos datos = new UsuarioDatos();
			Usuario usuario = datos.Login(email, contrasenia);

			if(usuario != null && usuario.Activo)
			{
				return usuario;
			}

			return null;
		}
	}
}
