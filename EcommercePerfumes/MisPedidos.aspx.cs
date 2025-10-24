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
	public partial class MisPedidos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.RedirigirSiNoLogueado(this);
			if (!IsPostBack)
			{
				var usuario = (Usuario)Session["Usuario"];

				if (usuario == null)
				{
					Response.Redirect("Default.aspx");
				}
				PedidoNegocio negocio = new PedidoNegocio();
				repPedidos.DataSource = negocio.ObtenerPorCliente(usuario.Id);
				repPedidos.DataBind();
				gvMisPedidos.DataSource = negocio.ObtenerPorCliente(usuario.Id);
				gvMisPedidos.DataBind();
			}
		}

		protected void gvMisPedidos_SelectedIndexChanged(object sender, EventArgs e)
		{
			int idPedido = Convert.ToInt32(gvMisPedidos.SelectedDataKey.Value);
			Response.Redirect($"DetallePedidoCliente.aspx?id={idPedido}");
		}

		protected void gvMisPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType != DataControlRowType.DataRow) return;

			var lblEstado = (Label)e.Row.FindControl("lblEstado");
			if (lblEstado == null) return;

			var estadoRaw = lblEstado.Text ?? "";
			var estado = estadoRaw.Trim().ToLowerInvariant();

			string css = "badge ";

			switch (estado)
			{
				case "pendiente":
					css += "text-bg-warning";
					lblEstado.Text = "Pendiente";
					break;
				case "procesando":
					css += "text-bg-info";
					lblEstado.Text = "Procesando";
					break;
				case "enviado":
					css += "text-bg-primary";
					lblEstado.Text = "Enviado";
					break;
				case "cancelado":
					css += "text-bg-danger";
					lblEstado.Text = "Cancelado";
					break;
				case "entregado":
					css += "text-bg-success";
					lblEstado.Text = "Entregado";
					break;
				default:
					css += "text-bg-secondary";
					break;
			}

			lblEstado.CssClass = css;
		}

		protected void repPedidos_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
				return;

			var lblEstado = (Label)e.Item.FindControl("lblEstado");
			if (lblEstado == null) return;

			string estadoRaw = lblEstado.Text ?? "";
			string estado = estadoRaw.Trim().ToLowerInvariant();

			string css = "badge ";

			switch (estado)
			{
				case "pendiente":
					css += "text-bg-warning";
					lblEstado.Text = "Pendiente";
					break;
				case "procesando":
					css += "text-bg-info";
					lblEstado.Text = "Procesando";
					break;
				case "enviado":
					css += "text-bg-primary";
					lblEstado.Text = "Enviado";
					break;
				case "cancelado":
					css += "text-bg-danger";
					lblEstado.Text = "Cancelado";
					break;
				case "entregado":
					css += "text-bg-success";
					lblEstado.Text = "Entregado";
					break;
				default:
					css += "text-bg-secondary";
					lblEstado.Text = estadoRaw;
					break;
			}

			lblEstado.CssClass = css;
		}
	}
}
