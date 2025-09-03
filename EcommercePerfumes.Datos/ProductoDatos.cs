using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Datos
{
	public class ProductoDatos
	{
		public List<Producto> ObtenerTodos()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Producto> lista = new List<Producto>();

			try
			{
				datos.setProcedimiento("Producto_ObtenerTodos");
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Producto producto = new Producto
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Descripcion = datos.Lector["Descripcion"].ToString(),
						Precio = (decimal)datos.Lector["Precio"],
						Stock = (int)datos.Lector["Stock"],
						ImagenUrl = datos.Lector["ImagenUrl"].ToString(),
						Genero = datos.Lector["Genero"].ToString(),
						Concentracion = datos.Lector["Concentracion"].ToString(),
						Mililitros = (int)datos.Lector["Mililitros"],
						Notas = datos.Lector["Notas"].ToString(),
						Activo = (bool)datos.Lector["Activo"],
						Marca = new Marca
						{
							Id = (int)datos.Lector["MarcaId"],
							Nombre = datos.Lector["MarcaNombre"].ToString(),
							Activo = (bool)datos.Lector["MarcaActivo"]
						}
					};

					lista.Add(producto);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener todos los productos.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public Producto ObtenerPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Producto_ObtenerPorId");
				datos.setParametro("@Id", id);
				datos.ejecutarLectura();

				if(datos.Lector.Read())
				{
					Producto producto = new Producto
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Descripcion = datos.Lector["Descripcion"].ToString(),
						Precio = (decimal)datos.Lector["Precio"],
						Stock = (int)datos.Lector["Stock"],
						ImagenUrl = datos.Lector["ImagenUrl"].ToString(),
						MarcaId = (int)datos.Lector["MarcaId"],
						Genero = datos.Lector["Genero"].ToString(),
						Concentracion = datos.Lector["Concentracion"].ToString(),
						Mililitros = (int)datos.Lector["Mililitros"],
						Notas = datos.Lector["Notas"].ToString(),
						Activo = (bool)datos.Lector["Activo"],

						Marca = new Marca
						{
							Id = (int)datos.Lector["MarcaId"],
							Nombre = datos.Lector["MarcaNombre"].ToString(),
							Activo = (bool)datos.Lector["MarcaActivo"]
						}
					};

					return producto;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener el producto por id.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Producto> ObtenerActivos()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Producto> lista = new List<Producto>();
			try
			{
				datos.setProcedimiento("Productos_ObtenerActivos");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Producto producto = new Producto
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Descripcion = datos.Lector["Descripcion"].ToString(),
						Precio = (decimal)datos.Lector["Precio"],
						Stock = (int)datos.Lector["Stock"],
						ImagenUrl = datos.Lector["ImagenUrl"].ToString(),
						Genero = datos.Lector["Genero"].ToString(),
						Concentracion = datos.Lector["Concentracion"].ToString(),
						Mililitros = (int)datos.Lector["Mililitros"],
						Notas = datos.Lector["Notas"].ToString(),
						Activo = (bool)datos.Lector["Activo"],
						Marca = new Marca
						{
							Id = (int)datos.Lector["MarcaId"],
							Nombre = datos.Lector["MarcaNombre"].ToString(),
							Activo = (bool)datos.Lector["MarcaActivo"]
						}
					};
					lista.Add(producto);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los productos activos.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public List<Producto> ObtenerPorMarca(int marcaId)
		{
			AccesoDatos datos = new AccesoDatos();
			List<Producto> lista = new List<Producto>();

			try
			{
				datos.setProcedimiento("Productos_ObtenerPorMarca");
				datos.setParametro("@MarcaId", marcaId);
				datos.ejecutarLectura();

				while(datos.Lector.Read())
				{
					Producto producto = new Producto
					{
						Id = (int)datos.Lector["Id"],
						Nombre = datos.Lector["Nombre"].ToString(),
						Descripcion = datos.Lector["Descripcion"].ToString(),
						Precio = (decimal)datos.Lector["Precio"],
						Stock = (int)datos.Lector["Stock"],
						ImagenUrl = datos.Lector["ImagenUrl"].ToString(),
						Genero = datos.Lector["Genero"].ToString(),
						Concentracion = datos.Lector["Concentracion"].ToString(),
						Mililitros = (int)datos.Lector["Mililitros"],
						Notas = datos.Lector["Notas"].ToString(),
						Activo = (bool)datos.Lector["Activo"],
						Marca = new Marca
						{
							Id = (int)datos.Lector["MarcaId"],
							Nombre = datos.Lector["MarcaNombre"].ToString(),
							Activo = (bool)datos.Lector["MarcaActivo"]
						}
					};

					lista.Add(producto);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los productos por marca.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public void Agregar(Producto producto)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Producto_Crear");
				datos.setParametro("@Nombre", producto.Nombre);
				datos.setParametro("@Descripcion", producto.Descripcion);
				datos.setParametro("@Precio", producto.Precio);
				datos.setParametro("@Stock", producto.Stock);
				datos.setParametro("@ImagenUrl", producto.ImagenUrl);
				datos.setParametro("@MarcaId", producto.MarcaId);
				datos.setParametro("@Genero", producto.Genero);
				datos.setParametro("@Concentracion", producto.Concentracion);
				datos.setParametro("@Mililitros", producto.Mililitros);
				datos.setParametro("@Notas", producto.Notas);
				datos.setParametro("@Activo", producto.Activo);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al agregar producto.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}

		public void Modificar(Producto producto)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Producto_Modificar");
				datos.setParametro("@Id", producto.Id);
				datos.setParametro("@Nombre", producto.Nombre);
				datos.setParametro("@Descripcion", producto.Descripcion);
				datos.setParametro("@Precio", producto.Precio);
				datos.setParametro("@Stock", producto.Stock);
				datos.setParametro("@ImagenUrl", producto.ImagenUrl);
				datos.setParametro("@MarcaId", producto.MarcaId);
				datos.setParametro("@Genero", producto.Genero);
				datos.setParametro("@Concentracion", producto.Concentracion);
				datos.setParametro("@Mililitros", producto.Mililitros);
				datos.setParametro("@Notas", producto.Notas);
				datos.setParametro("@Activo", producto.Activo);

				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al modificar el producto.", ex);
			} finally
			{
				datos.cerrarConexion();
			}
		}
	}
}
