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
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string email = txtEmail.Text.Trim();
			string contrasenia = txtContrasenia.Text.Trim();

			UsuarioNegocio negocio = new UsuarioNegocio();
			Usuario usuario = negocio.Login(email, contrasenia);
			string returnUrl = Request.QueryString["ReturnUrl"];
			if (usuario != null)
			{
				Session["Usuario"] = usuario;
				if(Seguridad.EsAdmin(Session))
				{
					Response.Redirect("Admin/Dashboard.aspx");
				}
				else if (!string.IsNullOrEmpty(returnUrl))
				{
					Response.Redirect(returnUrl);
				}
				else
				{
					Response.Redirect("Default.aspx");
				}
			}
			else
			{
				lblMensaje.Text = "Email o contraseña incorrectos.";
			}
		}
	}
}