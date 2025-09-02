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
	public partial class Usuarios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if(!IsPostBack)
			{
				CargarUsuarios();
			}
		}

		private void CargarUsuarios()
		{
			UsuarioNegocio negocio = new UsuarioNegocio();
			gvUsuarios.DataSource = negocio.ObtenerClientes();
			gvUsuarios.DataBind();
		}

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
			if (e.CommandName == "ToggleActivo")
			{
				int idUsuario = Convert.ToInt32(e.CommandArgument);
				UsuarioNegocio negocio = new UsuarioNegocio();

				Usuario usuario = negocio.BuscarPorId(idUsuario);
				if (usuario != null)
				{
					bool nuevoEstado = !usuario.Activo;
					negocio.ActualizarEstado(idUsuario, nuevoEstado);
					//CargarUsuarios();
					Response.Redirect(Request.RawUrl, false);
					Context.ApplicationInstance.CompleteRequest();
				}
			}
		}

		protected void btnConfirmarInactivar_Click(object sender, EventArgs e)
		{
			int idUsuario = int.Parse(hdnIdUsuario.Value);

			UsuarioNegocio negocio = new UsuarioNegocio();
			Usuario usuario = negocio.BuscarPorId(idUsuario);

			if (usuario != null)
			{
				bool estadoNuevo = !usuario.Activo;
				negocio.ActualizarEstado(idUsuario, estadoNuevo);
				Response.Redirect(Request.RawUrl);
			}
		}
	}
}