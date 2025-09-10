using EcommercePerfumes.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommercePerfumes.Admin
{
	public partial class Pedidos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				PedidoNegocio negocio = new PedidoNegocio();
				Session.Add("listaPedidos", negocio.ObtenerTodos());
				gvPedidos.DataSource = Session["listaPedidos"];
				gvPedidos.DataBind();
			}
		}

		protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
		{
			int idSeleccionado = Convert.ToInt32(gvPedidos.SelectedDataKey.Value);
			Response.Redirect($"DetallePedido.aspx?id={idSeleccionado}");
		}

		protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType != DataControlRowType.DataRow) return;

			var lblEstado = (Label)e.Row.FindControl("lblEstado");
			if (lblEstado == null) return;

			// Normalizamos para que el switch no falle por espacios o mayúsculas
			var estadoRaw = lblEstado.Text ?? "";
			var estado = estadoRaw.Trim().ToLowerInvariant();

			// Si usás Bootstrap 5.3+, conviene text-bg-* (sino, podés dejar bg-* + text-*)
			string css = "badge ";

			switch (estado)
			{
				case "pendiente":
					css += "text-bg-warning";        // o "bg-warning text-dark"
					lblEstado.Text = "Pendiente";
					break;
				case "procesando":
					css += "text-bg-info";           // o "bg-info text-dark"
					lblEstado.Text = "Procesando";
					break;
				case "enviado":
					css += "text-bg-primary";        // o "bg-success"
					lblEstado.Text = "Enviado";
					break;
				case "cancelado":
					css += "text-bg-danger";         // o "bg-danger"
					lblEstado.Text = "Cancelado";
					break;
				case "entregado":
					css += "text-bg-success";
					lblEstado.Text = "Entregado";
					break;
				default:
					css += "text-bg-secondary";      // valor por defecto
					break;
			}

			lblEstado.CssClass = css;
		}
	}
}
