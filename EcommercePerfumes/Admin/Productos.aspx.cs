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
			if (!IsPostBack)
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
			repProductosCards.DataSource = Session["listaProductos"];
			repProductosCards.DataBind();
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

		protected void filtrosChanged(object sender, EventArgs e)
		{
			AplicarFiltros();
		}

		private void AplicarFiltros()
		{
			ProductoNegocio negocio = new ProductoNegocio();
			List<Producto> lista = negocio.ObtenerTodos();

			List<Producto> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtNombreFiltro.Text.ToUpper()));
			if (!string.IsNullOrWhiteSpace(txtNombreFiltro.Text))
			{
				lista = lista.Where(x => x.Nombre.ToUpper().Contains(txtNombreFiltro.Text.ToUpper())).ToList();	
			}

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

			repProductosCards.DataSource = lista;
			repProductosCards.DataBind();
		}

		protected void btnResetFiltros_Click(object sender, EventArgs e)
		{
			txtNombreFiltro.Text = "";
			ddlMarcas.SelectedIndex = 0;  
			rblGenero.ClearSelection();
			rblGenero.Items[0].Selected = true; 

			ProductoNegocio negocio = new ProductoNegocio();
			var listaCompleta = negocio.ObtenerTodos();

			Session["listaProductos"] = listaCompleta;
			repProductosCards.DataSource = listaCompleta;
			repProductosCards.DataBind();
		}
	}
}