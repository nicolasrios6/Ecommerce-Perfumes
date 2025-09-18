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
	public partial class Perfumes : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Page.MaintainScrollPositionOnPostBack = true;
			if (!IsPostBack)
			{
				CargarMarcas();
				CargarProductos();

				// ✅ Detectar si viene con querystring "genero"
				if (Request.QueryString["genero"] != null)
				{
					string genero = Request.QueryString["genero"];

					// Marcar el RadioButtonList en base al género recibido
					if (rblGenero.Items.FindByValue(genero) != null)
					{
						rblGenero.ClearSelection();
						rblGenero.Items.FindByValue(genero).Selected = true;
					}
				}

				AplicarFiltros(); // ✅ Aplica los filtros con el género ya seleccionado
			}
		}

		private void CargarProductos()
		{
			ProductoNegocio negocio = new ProductoNegocio();
			List<Producto> lista = new List<Producto>();

			repPerfumes.DataSource = negocio.ObtenerActivos();
			repPerfumes.DataBind();
		}

		private void CargarMarcas()
		{
			MarcaNegocio negocio = new MarcaNegocio();
			ddlMarcas.DataSource = negocio.ObtenerActivas();
			ddlMarcas.DataTextField = "Nombre";
			ddlMarcas.DataValueField = "Id";
			ddlMarcas.DataBind();

			ddlMarcas.Items.Insert(0, new ListItem("Todas", "0"));
		}

		protected void filtrosChanged(object sender, EventArgs e)
		{
			AplicarFiltros();
		}

		private void AplicarFiltros()
		{
			ProductoNegocio negocio = new ProductoNegocio();
			List<Producto> lista = negocio.ObtenerActivos();

			if (ddlMarcas.SelectedValue != "" && ddlMarcas.SelectedValue != "0")
			{
				int idMarca = int.Parse(ddlMarcas.SelectedValue);
				lista = lista.Where(p => p.Marca.Id == idMarca).ToList();
			}

			if (!string.IsNullOrEmpty(rblGenero.SelectedValue))
			{
				string genero = rblGenero.SelectedValue;
				lista = lista.Where(p => p.Genero == genero).ToList();
			}

			// Filtro por Rango de Precios
			if (!string.IsNullOrEmpty(rblPrecio.SelectedValue))
			{
				switch (rblPrecio.SelectedValue)
				{
					case "1": // Menos de 10k
						lista = lista.Where(p => p.Precio < 60000).ToList();
						break;
					case "2": // 10k - 20k
						lista = lista.Where(p => p.Precio >= 60000 && p.Precio <= 100000).ToList();
						break;
					case "3": // Más de 20k
						lista = lista.Where(p => p.Precio > 100000).ToList();
						break;
				}
			}

			repPerfumes.DataSource = lista;
			repPerfumes.DataBind();
		}

		protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
		{
			ddlMarcas.SelectedIndex = 0;

			rblGenero.ClearSelection();
			rblGenero.Items[0].Selected = true;

			rblPrecio.ClearSelection();
			rblPrecio.Items[0].Selected = true;

			CargarProductos();
		}

		protected void repPerfumes_ItemCommand(object source, RepeaterCommandEventArgs e)
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
				if(existente != null)
				{
					if(existente.Cantidad < existente.StockDisponible)
						existente.Cantidad++;
				} else
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
				((SiteMaster)Master).ActualizarCarritoCount();
				((SiteMaster)Master).ActualizarUpdatePanelCarrito();
			}
		}
	}
}