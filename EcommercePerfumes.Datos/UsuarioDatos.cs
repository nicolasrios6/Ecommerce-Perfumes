using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Datos
{
	public class UsuarioDatos
	{
		public void Registrar(Usuario nuevoUsuario)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setProcedimiento("Usuario_Registrar");
				datos.setParametro("@Nombre", nuevoUsuario.Nombre);
				datos.setParametro("@Apellido", nuevoUsuario.Apellido);
				datos.setParametro("@Email", nuevoUsuario.Email);
				datos.setParametro("@Telefono", nuevoUsuario.Telefono);
				datos.setParametro("@Contrasenia", nuevoUsuario.Contrasenia);
				datos.setParametro("@RolId", nuevoUsuario.RolId);
				datos.setParametro("@Activo", nuevoUsuario.Activo);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al registrar usuario.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public Usuario Login(string email, string contrasenia)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT * FROM Usuarios WHERE Email = @Email AND Contrasenia = @Contrasenia");
				datos.setParametro("@Email", email);
				datos.setParametro("@Contrasenia", contrasenia);
				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					Usuario usuario = new Usuario();
					usuario.Id = (int)datos.Lector["Id"];
					usuario.Nombre = datos.Lector["Nombre"].ToString();
					usuario.Apellido = datos.Lector["Apellido"].ToString();
					usuario.Email = datos.Lector["Email"].ToString();
					usuario.Contrasenia = datos.Lector["Contrasenia"].ToString();
					usuario.Telefono = datos.Lector["Telefono"].ToString();
					usuario.RolId = (int)datos.Lector["RolId"];
					usuario.Activo = (bool)datos.Lector["Activo"];

					return usuario;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al intentar iniciar sesión", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public bool BuscarPorEmail(string email)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("SELECT * FROM Usuarios WHERE Email = @Email");
				datos.setParametro("@Email", email);
				datos.ejecutarLectura();

				return datos.Lector.Read();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al buscar usuario por email en la base de datos.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
	}
}
