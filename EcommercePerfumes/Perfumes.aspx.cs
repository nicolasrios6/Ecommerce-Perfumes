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
			if(!IsPostBack)
			{
				CargarProductos();
			}
		}

		private void CargarProductos()
		{
			ProductoNegocio negocio = new ProductoNegocio();
			List<Producto> lista = new List<Producto>();

			repPerfumes.DataSource = negocio.ObtenerActivos();
			repPerfumes.DataBind();
		}
	}
}