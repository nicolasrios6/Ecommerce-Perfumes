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
	public partial class DetalleProducto : System.Web.UI.Page
	{
		public Producto ProductoActual { get; set; }
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Page.MaintainScrollPositionOnPostBack = true;
			if (!IsPostBack)
			{
				if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idProducto))
				{
					
					CargarProducto(idProducto);
					CargarRelacionados(idProducto);
				}
				else
				{
					Response.Redirect("Perfumes.aspx");
				}
			}
		}

		private void CargarProducto(int id)
		{
			ProductoNegocio negocio = new ProductoNegocio();
			Producto producto = negocio.ObtenerPorId(id);

			if (producto == null)
			{
				Response.Redirect("Perfumes.aspx");
				return;
			}

			ProductoActual = producto;
			ViewState["ProductoId"] = producto.Id;
			imgProducto.ImageUrl = producto.ImagenUrl;
			lblNombre.Text = producto.Nombre;
			lblPrecio.Text = producto.Precio.ToString("N0");
			lblDescripcion.Text = producto.Descripcion;
			lblNotas.Text = producto.Notas;
			lblMarca.Text = producto.MarcaNombre;
			lblGenero.Text = producto.Genero;
			lblMililitros.Text = producto.Mililitros.ToString();
			lblConcentracion.Text = producto.Concentracion;
			if (producto.Stock >= 1 && producto.Stock < 5)
			{
				lblStock.Text = "Quedan pocas unidades";
			}
			else if (producto.Stock >= 5)
			{
				lblStock.Text = "En stock";
			}
			else
			{
				lblStock.Text = "Sin stock";
				btnAgregarCarrito.Enabled = false;
			}
		}

		private void CargarRelacionados(int idProducto)
		{
			ProductoNegocio negocio = new ProductoNegocio();

			// Trae el producto actual
			Producto actual = negocio.ObtenerPorId(idProducto);

			// Ejemplo: relacionados por misma marca (excluyendo el actual)
			List<Producto> relacionados = negocio.ObtenerActivos()
												 .Where(p => p.Genero == actual.Genero && p.Id != actual.Id)
												 .Take(5)
												 .ToList();

			repRelacionados.DataSource = relacionados;
			repRelacionados.DataBind();
		}

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
			if (ViewState["ProductoId"] == null)
				return;

			int idProducto = (int)ViewState["ProductoId"];
			ProductoNegocio negocio = new ProductoNegocio();
			Producto producto = negocio.ObtenerPorId(idProducto);

			if(producto == null)
			{
				return;
			}

			List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();

			ItemCarrito existente = carrito.Find(x => x.ProductoId == producto.Id);
			if (existente != null)
			{
				// Controlamos que no supere el stock
				if (existente.Cantidad < producto.Stock)
					existente.Cantidad++;
				else
					existente.Cantidad = producto.Stock; // tope en stock
			}
			else
			{
				carrito.Add(new ItemCarrito
				{
					ProductoId = producto.Id,
					Nombre = producto.Nombre,
					ImagenUrl = producto.ImagenUrl,
					Precio = producto.Precio,
					StockDisponible = producto.Stock,
					Cantidad = 1
				});
			}

			Session["Carrito"] = carrito;
			((SiteMaster)Master).CargarCarrito();
			((SiteMaster)Master).ActualizarUpdatePanel();
			((SiteMaster)Master).ActualizarUpdatePanelCarrito();
		}

		protected void repRelacionados_ItemCommand(object source, RepeaterCommandEventArgs e)
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