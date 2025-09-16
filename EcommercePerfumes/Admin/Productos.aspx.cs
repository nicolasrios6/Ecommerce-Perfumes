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
	public partial class Productos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if(!IsPostBack)
			{
				CargarMarcas();
				CargarProductos();

				AplicarFiltros();
			}
		}

		private void CargarProductos()
		{
			ProductoNegocio negocio = new ProductoNegocio();
			Session.Add("listaProductos", negocio.ObtenerTodos());
			gvProductos.DataSource = Session["listaProductos"];
			gvProductos.DataBind();
		}

		private void CargarMarcas()
		{
			MarcaNegocio negocio = new MarcaNegocio();
			ddlMarcas.DataSource = negocio.ObtenerTodas();
			ddlMarcas.DataTextField = "Nombre";
			ddlMarcas.DataValueField = "Id";
			ddlMarcas.DataBind();

			ddlMarcas.Items.Insert(0, new ListItem("Todas", "0"));
		}

		protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
			int idSeleccionado = Convert.ToInt32(gvProductos.SelectedDataKey.Value);
			Response.Redirect($"FormularioProducto.aspx?id={idSeleccionado}");
        }

		protected void filtrosChanged(object sender, EventArgs e)
		{
			AplicarFiltros();
		}

		private void AplicarFiltros()
		{
			ProductoNegocio negocio = new ProductoNegocio();
			List<Producto> lista = negocio.ObtenerTodos();

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

			gvProductos.DataSource = lista;
			gvProductos.DataBind();
		}
    }
}