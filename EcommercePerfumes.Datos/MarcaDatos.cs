using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Datos
{
	public class MarcaDatos
	{
		public List<Marca> ObtenerTodas()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Marca> lista = new List<Marca>();

			try
			{
				datos.setConsulta("SELECT * FROM Marcas");
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Marca marca = new Marca
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(marca);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las marcas.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Marca> ObtenerActivas()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Marca> lista = new List<Marca>();

			try
			{
				datos.setConsulta("SELECT * FROM Marcas WHERE Activo = 1");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Marca categoria = new Marca
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};

					lista.Add(categoria);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las marcas activas.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public void Agregar(string nombre)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta(@"INSERT INTO Marcas (Nombre, Activo) VALUES (@nombre, 1);");
				datos.setParametro("@nombre", nombre);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar marca.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public Marca ObtenerPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setConsulta("SELECT * FROM Marcas WHERE Id = @id");
				datos.setParametro("@id", id);
				datos.ejecutarLectura();

				if(datos.Lector.Read())
				{
					return new Marca
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Activo = (bool)datos.Lector["Activo"]
					};
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener la marca por id.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public void Modificar(Marca marca)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setConsulta("UPDATE Marcas SET Nombre = @nombre, Activo = @activo WHERE Id = @id");
				datos.setParametro("@nombre", marca.Nombre);
				datos.setParametro("@activo", marca.Activo);
				datos.setParametro("@id", marca.Id);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar marca.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}


	}
}
