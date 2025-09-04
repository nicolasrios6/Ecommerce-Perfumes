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
			imgProducto.ImageUrl = producto.ImagenUrl;
			lblNombre.Text = producto.Nombre;
			lblPrecio.Text = producto.Precio.ToString("N0");
			lblDescripcion.Text = producto.Descripcion;
			lblNotas.Text = producto.Notas;
			lblMarca.Text = producto.MarcaNombre;
			lblGenero.Text = producto.Genero;
			lblMililitros.Text = producto.Mililitros.ToString();
			lblConcentracion.Text = producto.Concentracion;
			if (producto.Stock >= 2 && producto.Stock < 5)
			{
				lblStock.Text = "Quedan pocas unidades";
			}
			else if (producto.Stock > 5)
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
	}
}