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
				ProductoNegocio negocio = new ProductoNegocio();
				Session.Add("listaProductos", negocio.ObtenerTodos());
				gvProductos.DataSource = Session["listaProductos"];
				gvProductos.DataBind();
			}
		}

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
			int idSeleccionado = Convert.ToInt32(gvProductos.SelectedDataKey.Value);
			Response.Redirect($"FormularioProducto.aspx?id={idSeleccionado}");
        }
    }
}