using EcommercePerfumes.Datos;
using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Negocio
{
	public class MarcaNegocio
	{
		public List<Marca> ObtenerTodas()
		{
			MarcaDatos datos = new MarcaDatos();
			try
			{
				return datos.ObtenerTodas();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las marcas.",ex);
			}
		}
		public void Agregar(string nombre)
		{
			MarcaDatos datos = new MarcaDatos();
			try
			{
				datos.Agregar(nombre);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar marca.", ex);
			}
		}

		public Marca ObtenerPorId(int id)
		{
			MarcaDatos datos = new MarcaDatos();
			try
			{
				return datos.ObtenerPorId(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener la marca por id.", ex);
			}
		}

		public List<Marca> ObtenerActivas()
		{
			MarcaDatos datos = new MarcaDatos();
			try
			{
				return datos.ObtenerActivas();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener las marcas activas.", ex);
			}
		}

		public void Modificar(Marca marca)
		{
			MarcaDatos datos = new MarcaDatos();
			try
			{
				datos.Modificar(marca);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar la marca.", ex);
			}
		}
	}
}
