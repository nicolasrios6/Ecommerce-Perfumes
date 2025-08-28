using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommercePerfumes
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Session["Usuario"] != null)
				{
					Usuario usuario = (Usuario)Session["Usuario"];
					liLogin.Visible = false;
					liRegistro.Visible = false;
					liLogout.Visible = true;
					
				} else
				{
					liLogin.Visible = true;
					liRegistro.Visible = true;
					liLogout.Visible = false;
				}
			}
		}

        protected void btnLogout_Click(object sender, EventArgs e)
        {
			Session.Clear();
			Session.Abandon();
			Response.Redirect("~/Login.aspx");
        }
    }
}