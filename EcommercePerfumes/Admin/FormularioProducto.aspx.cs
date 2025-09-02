using EcommercePerfumes.Entidades;
using EcommercePerfumes.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommercePerfumes.Admin
{
	public partial class FormularioProducto : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		
		{
			Seguridad.VerificarAdmin(this);
			if(!IsPostBack)
			{
				CargarMarcas();

				if (Request.QueryString["id"] != null)
				{
					int id = int.Parse(Request.QueryString["id"]);
					Session["ProductoId"] = id;
					CargarProducto(id);
				}

				if (Session["ProductoEnCarga"] != null)
				{
					Producto producto = (Producto)Session["ProductoEnCarga"];
					txtNombre.Text = producto.Nombre;
					txtDescripcion.Text = producto.Descripcion;
					txtPrecio.Text = producto.Precio.ToString("0");
					txtStock.Text = producto.Stock.ToString();
					txtGenero.Text = producto.Genero;
					txtConcentracion.Text = producto.Concentracion;
					txtMililitros.Text = producto.Mililitros.ToString();
					txtNotas.Text = producto.Notas;
					chkActivo.Checked = producto.Activo;
					txtImagenUrl.Text = producto.ImagenUrl;
					imgProducto.ImageUrl = producto.ImagenUrl;

					ddlMarca.SelectedValue = producto.MarcaId.ToString();

				}
			}
		}

		private void CargarProducto(int id)
		{
			ProductoNegocio negocio = new ProductoNegocio();
			Producto producto = negocio.ObtenerPorId(id);

			if(producto != null)
			{
				txtNombre.Text = producto.Nombre;
				txtDescripcion.Text = producto.Descripcion;
				txtPrecio.Text = producto.Precio.ToString("0");
				txtStock.Text = producto.Stock.ToString();
				txtGenero.Text = producto.Genero;
				txtConcentracion.Text = producto.Concentracion;
				txtMililitros.Text = producto.Mililitros.ToString();
				txtNotas.Text = producto.Notas;
				chkActivo.Checked = producto.Activo;
				txtImagenUrl.Text = producto.ImagenUrl;
				imgProducto.ImageUrl = producto.ImagenUrl;

				ddlMarca.SelectedValue = producto.MarcaId.ToString();
			}
			
		}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
			try
			{
				if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
				{
					return;
				}

				Producto producto = new Producto
				{
					Nombre = txtNombre.Text.Trim(),
					Descripcion = txtDescripcion.Text.Trim(),
					Precio = decimal.Parse(txtPrecio.Text),
					Stock = int.Parse(txtStock.Text),
					MarcaId = int.Parse(ddlMarca.SelectedValue),
					Genero = txtGenero.Text.Trim(),
					Concentracion = txtConcentracion.Text.Trim(),
					Mililitros = int.Parse(txtMililitros.Text),
					Notas = txtNotas.Text.Trim(),
					ImagenUrl = txtImagenUrl.Text.Trim(),
					Activo = chkActivo.Checked,
				};

				ProductoNegocio negocio = new ProductoNegocio();

				if (Session["ProductoId"] != null)
				{
					producto.Id = (int)Session["ProductoId"];
					negocio.Modificar(producto);
					Session.Remove("ProductoId");
				}
				else
				{
					producto.Activo = true;
					negocio.Agregar(producto);
					Session.Remove("ProductoEnCarga");
				}

				Response.Redirect("Productos.aspx", false);
			}
			catch (Exception ex)
			{
				lblError.Text = "Error al guardar el producto.";
				throw new Exception("Error al guardar el producto.", ex);
			}
		}

		private void CargarMarcas()
		{
			MarcaNegocio negocio = new MarcaNegocio();
			ddlMarca.DataSource = negocio.ObtenerActivas();
			ddlMarca.DataTextField = "Nombre";
			ddlMarca.DataValueField = "Id";
			ddlMarca.DataBind();
		}
		protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
		{
			imgProducto.ImageUrl = txtImagenUrl.Text;
		}

		private void GuardarDatosEnSession()
		{
			Producto producto = new Producto();
			producto.Nombre = txtNombre.Text;
			producto.Descripcion = txtDescripcion.Text;
			if (!string.IsNullOrWhiteSpace(txtPrecio.Text))
				producto.Precio = decimal.Parse(txtPrecio.Text);
			if (!string.IsNullOrWhiteSpace(txtStock.Text))
				producto.Stock = int.Parse(txtStock.Text);
			producto.MarcaId = int.Parse(ddlMarca.SelectedValue);
			producto.Genero = txtGenero.Text;
			producto.Concentracion = txtConcentracion.Text;
			if (!string.IsNullOrWhiteSpace(txtMililitros.Text))
				producto.Mililitros = int.Parse(txtMililitros.Text);
			producto.Notas = txtNotas.Text;
			producto.Activo = chkActivo.Checked;
			producto.ImagenUrl = txtImagenUrl.Text;

			Session["ProductoEnCarga"] = producto;
		}

		protected void btnNuevaMarca_Click(object sender, EventArgs e)
		{
			GuardarDatosEnSession();
			Response.Redirect("FormularioMarca.aspx?returnUrl=FormularioProducto.aspx");
		}
	}
}