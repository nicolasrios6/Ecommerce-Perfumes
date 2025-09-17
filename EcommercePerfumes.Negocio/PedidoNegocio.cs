using EcommercePerfumes.Datos;
using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Negocio
{
	public class PedidoNegocio
	{
		public void Crear(Pedido pedido)
		{
			PedidoDatos datos = new PedidoDatos();
			try
			{
				datos.Crear(pedido);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al crear el pedido.", ex);
			}
		}

		public List<Pedido> ObtenerTodos()
		{
			PedidoDatos datos = new PedidoDatos();
			try
			{
				return datos.ObtenerTodos();
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los pedidos.", ex);
			}
		}

		public List<Pedido> ObtenerPorCliente(int clienteId)
		{
			PedidoDatos datos = new PedidoDatos();

			try
			{
				return datos.ObtenerPorCliente(clienteId);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener los pedidos del usuario.", ex);
			}
		}
		public Pedido ObtenerPorId(int id)
		{
			PedidoDatos datos = new PedidoDatos();
			try
			{
				return datos.ObtenerPorId(id);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener el pedido por id.", ex);
			}
		}

		public void ActualizarEstado(int id, string estado, string numeroSeguimiento)
		{
			PedidoDatos datos = new PedidoDatos();
			try
			{
				datos.ActualizarEstado(id, estado, numeroSeguimiento);
			}
			catch (Exception ex)
			{
				throw new Exception("Error al actualizar el estado del pedido.", ex);
			}
		}
	}
}
