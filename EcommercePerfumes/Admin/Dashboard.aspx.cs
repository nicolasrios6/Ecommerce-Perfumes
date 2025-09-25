using EcommercePerfumes.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommercePerfumes.Admin
{
	public partial class Dashboard : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			CantidadProductos();
			CantidadMarcas();
			CantidadPedidos();
			CantidadUsuarios();
		}

		public void CantidadProductos()
		{
			ProductoNegocio negocio = new ProductoNegocio();

			try
			{
				var cantProductos = 0;
				cantProductos = negocio.ObtenerTodos().Count();

				cantidadProductos.InnerText = cantProductos.ToString();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void CantidadMarcas()
		{
			MarcaNegocio negocio = new MarcaNegocio();

			try
			{
				var cantMarcas = 0;
				cantMarcas = negocio.ObtenerTodas().Count();

				cantidadMarcas.InnerText = cantMarcas.ToString();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void CantidadPedidos()
		{
			PedidoNegocio negocio = new PedidoNegocio();

			try
			{
				var cantPedidos = 0;
				cantPedidos = negocio.ObtenerTodos().Where(p => p.Estado == "Pendiente").Count();

				cantidadPedidos.InnerText = cantPedidos.ToString();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public void CantidadUsuarios()
		{
			UsuarioNegocio negocio = new UsuarioNegocio();

			try
			{
				var cantUsuarios = 0;
				cantUsuarios = negocio.ObtenerClientes().Count();

				cantidadUsuarios.InnerText = cantUsuarios.ToString();
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}