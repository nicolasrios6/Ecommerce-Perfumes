using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Datos
{
	public class PedidoDatos
	{
		public List<Pedido> ObtenerTodos()
		{
			AccesoDatos datos = new AccesoDatos();
			List<Pedido> lista = new List<Pedido>();

			try
			{
				datos.setProcedimiento("Pedido_ObtenerTodos");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Pedido pedido = new Pedido
					{
						Id = (int)datos.Lector["Id"],
						UsuarioId = (int)datos.Lector["UsuarioId"],
						Fecha = (DateTime)datos.Lector["Fecha"],
						Estado = datos.Lector["Estado"].ToString(),
						Subtotal = (decimal)datos.Lector["Subtotal"],
						Envio = (decimal)datos.Lector["ValorEnvio"],
						Total = (decimal)datos.Lector["Total"],
						DireccionEnvio = datos.Lector["DireccionEnvio"].ToString(),
						MetodoEnvio = datos.Lector["MetodoEnvio"].ToString(),
						MetodoPago = datos.Lector["MetodoPago"].ToString(),
						Observaciones = datos.Lector["Observaciones"].ToString(),
						NombreUsuario = datos.Lector["NombreUsuario"].ToString(),
						NumeroSeguimiento = datos.Lector["NumeroSeguimiento"].ToString()
					};

					lista.Add(pedido);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los pedidos.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public Pedido ObtenerPorId(int id)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setProcedimiento("Pedido_ObtenerPorId");
				datos.setParametro("@PedidoId", id);
				datos.ejecutarLectura();

				if (datos.Lector.Read())
				{
					Pedido pedido = new Pedido
					{
						Id = (int)datos.Lector["Id"],
						UsuarioId = (int)datos.Lector["UsuarioId"],
						Fecha = (DateTime)datos.Lector["Fecha"],
						Estado = datos.Lector["Estado"].ToString(),
						Subtotal = (decimal)datos.Lector["Subtotal"],
						Envio = (decimal)datos.Lector["ValorEnvio"],
						Total = (decimal)datos.Lector["Total"],
						DireccionEnvio = datos.Lector["DireccionEnvio"].ToString(),
						MetodoEnvio = datos.Lector["MetodoEnvio"].ToString(),
						MetodoPago = datos.Lector["MetodoPago"].ToString(),
						Observaciones = datos.Lector["Observaciones"].ToString(),
						ComprobanteUrl = datos.Lector["ComprobanteUrl"].ToString(),
						NumeroSeguimiento = datos.Lector["NumeroSeguimiento"].ToString()
					};

					if (datos.Lector["NombreUsuario"] != DBNull.Value)
						pedido.NombreUsuario = datos.Lector["NombreUsuario"].ToString();

					// Segundo resultado: Detalles del pedido
					if (pedido != null && datos.Lector.NextResult())
					{
						while (datos.Lector.Read())
						{
							var detalle = new DetallePedido
							{
								Id = (int)datos.Lector["Id"],
								PedidoId = (int)datos.Lector["PedidoId"],
								ProductoId = (int)datos.Lector["ProductoId"],
								NombreProducto = datos.Lector["NombreProducto"].ToString(),
								Cantidad = (int)datos.Lector["Cantidad"],
								PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"],
								Subtotal = (decimal)datos.Lector["Subtotal"]
							};

							pedido.Detalles.Add(detalle);
						}
					}

					return pedido;
				}
				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener el pedido por id.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
		public List<Pedido> ObtenerPorCliente(int clienteId)
		{
			AccesoDatos datos = new AccesoDatos();
			List<Pedido> lista = new List<Pedido>();

			try
			{
				datos.setProcedimiento("Pedido_ObtenerPorUsuario");
				datos.setParametro("@UsuarioId", clienteId);
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Pedido pedido = new Pedido
					{
						Id = (int)datos.Lector["Id"],
						UsuarioId = (int)datos.Lector["UsuarioId"],
						Fecha = (DateTime)datos.Lector["Fecha"],
						Estado = datos.Lector["Estado"].ToString(),
						Subtotal = (decimal)datos.Lector["Subtotal"],
						Envio = (decimal)datos.Lector["ValorEnvio"],
						Total = (decimal)datos.Lector["Total"],
						DireccionEnvio = datos.Lector["DireccionEnvio"].ToString(),
						MetodoEnvio = datos.Lector["MetodoEnvio"].ToString(),
						MetodoPago = datos.Lector["MetodoPago"].ToString(),
						Observaciones = datos.Lector["Observaciones"].ToString(),
						NombreUsuario = datos.Lector["NombreUsuario"].ToString(),
						NumeroSeguimiento = datos.Lector["NumeroSeguimiento"].ToString()
					};

					lista.Add(pedido);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los pedidos del usuario.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public void Crear(Pedido pedido)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.setProcedimiento("Pedido_Crear");
				datos.setParametro("@UsuarioId", pedido.UsuarioId);
				datos.setParametro("@Fecha", pedido.Fecha);
				datos.setParametro("@Estado", pedido.Estado);
				datos.setParametro("@Subtotal", pedido.Subtotal);
				datos.setParametro("@ValorEnvio", pedido.Envio);
				datos.setParametro("@Total", pedido.Total);
				datos.setParametro("@DireccionEnvio", (object)pedido.DireccionEnvio ?? DBNull.Value);
				datos.setParametro("@MetodoEnvio", pedido.MetodoEnvio);
				datos.setParametro("@MetodoPago", pedido.MetodoPago);
				datos.setParametro("@Observaciones", (object)pedido.Observaciones ?? DBNull.Value);
				datos.setParametro("@ComprobanteUrl", pedido.ComprobanteUrl);

				datos.setParametro("@NuevoId", 0);
				datos.comando.Parameters["@NuevoId"].Direction = System.Data.ParameterDirection.Output;

				datos.ejecutarAccion();

				int nuevoId = Convert.ToInt32(datos.comando.Parameters["@NuevoId"].Value);
				pedido.Id = nuevoId;

				foreach (var detalle in pedido.Detalles)
				{
					AccesoDatos datosDetalle = new AccesoDatos();
					try
					{
						datosDetalle.setProcedimiento("DetallePedido_Crear");
						datosDetalle.setParametro("@PedidoId", nuevoId);
						datosDetalle.setParametro("@ProductoId", detalle.ProductoId);
						datosDetalle.setParametro("@NombreProducto", detalle.NombreProducto);
						datosDetalle.setParametro("@Cantidad", detalle.Cantidad);
						datosDetalle.setParametro("@PrecioUnitario", detalle.PrecioUnitario);

						datosDetalle.ejecutarAccion();
					}
					finally
					{
						datosDetalle.cerrarConexion();
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error al crear el pedido.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}

		public void ActualizarEstado(int id, string estado, string numeroSeguimiento)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setProcedimiento("Pedido_ActualizarEstado");
				datos.setParametro("@Id", id);
				datos.setParametro("@Estado", estado);
				datos.setParametro("@NumeroSeguimiento", string.IsNullOrEmpty(numeroSeguimiento) ? (object)DBNull.Value : numeroSeguimiento);
				datos.ejecutarAccion();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al actualizar el estado del pedido.", ex);
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
	}
}
