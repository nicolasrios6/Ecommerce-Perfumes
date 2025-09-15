using EcommercePerfumes.Entidades;
using EcommercePerfumes.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommercePerfumes
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				CargarDestacados();
			}
		}

		private void CargarDestacados()
		{
			ProductoNegocio negocio = new ProductoNegocio();
			var productos = negocio.ObtenerDestacados(4); // Muestra 4 productos

			repDestacados.DataSource = productos;
			repDestacados.DataBind();
		}

		protected void repDestacados_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "Agregar")
			{
				int productoId = Convert.ToInt32(e.CommandArgument);
				ProductoNegocio negocio = new ProductoNegocio();
				Producto producto = negocio.ObtenerPorId(productoId);

				if (producto == null)
				{
					return;
				}

				List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();

				ItemCarrito existente = carrito.Find(x => x.ProductoId == productoId);
				if (existente != null)
				{
					if (existente.Cantidad < existente.StockDisponible)
						existente.Cantidad++;
				}
				else
				{
					ItemCarrito nuevoItem = new ItemCarrito
					{
						ProductoId = productoId,
						Nombre = producto.Nombre,
						ImagenUrl = producto.ImagenUrl,
						Precio = producto.Precio,
						StockDisponible = producto.Stock,
						Cantidad = 1
					};
					carrito.Add(nuevoItem);
				}
				Session["Carrito"] = carrito;
				((SiteMaster)Master).CargarCarrito();
				((SiteMaster)Master).ActualizarUpdatePanel();
			}
		}
	}
}