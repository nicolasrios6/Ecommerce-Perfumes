using EcommercePerfumes.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommercePerfumes.Admin
{
	public partial class Marcas : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				MarcaNegocio negocio = new MarcaNegocio();
				Session.Add("listaMarcas", negocio.ObtenerTodas());
				repMarcas.DataSource = Session["listaMarcas"];
				repMarcas.DataBind();
				
			}
		}
    }
}