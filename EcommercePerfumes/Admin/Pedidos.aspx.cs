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
	public partial class Pedidos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				PedidoNegocio negocio = new PedidoNegocio();
				Session.Add("listaPedidos", negocio.ObtenerTodos());
				repPedidos.DataSource = Session["listaPedidos"];
				repPedidos.DataBind();
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

		protected void btnFiltrar_Click(object sender, EventArgs e)
		{
			List<Pedido> pedidos = Session["listaPedidos"] as List<Pedido> ?? new List<Pedido>();

			// Filtro por fecha
			DateTime? fechaDesde = string.IsNullOrEmpty(txtFechaDesde.Text) ? (DateTime?)null : DateTime.Parse(txtFechaDesde.Text);
			DateTime? fechaHasta = string.IsNullOrEmpty(txtFechaHasta.Text) ? (DateTime?)null : DateTime.Parse(txtFechaHasta.Text);

			if (fechaHasta.HasValue)
				fechaHasta = fechaHasta.Value.Date.AddDays(1).AddTicks(-1); // incluye todo el día

			// Filtro por estado
			string estadoSeleccionado = ddlEstado.SelectedValue;

			var filtrados = pedidos.Where(p =>
				(!fechaDesde.HasValue || p.Fecha >= fechaDesde.Value) &&
				(!fechaHasta.HasValue || p.Fecha <= fechaHasta.Value) &&
				(string.IsNullOrEmpty(estadoSeleccionado) || p.Estado.Equals(estadoSeleccionado, StringComparison.OrdinalIgnoreCase))
			).ToList();

			repPedidos.DataSource = filtrados;
			repPedidos.DataBind();
			gvPedidos.DataSource = filtrados;
			gvPedidos.DataBind();
		}

		protected void btnLimpiar_Click(object sender, EventArgs e)
		{
			txtFechaDesde.Text = string.Empty;
			txtFechaHasta.Text = string.Empty;
			ddlEstado.SelectedIndex = 0;

			repPedidos.DataSource = Session["listaPedidos"];
			repPedidos.DataBind();
			gvPedidos.DataSource = Session["listaPedidos"];
			gvPedidos.DataBind();
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
					lblEstado.Text = estadoRaw; // mantiene el texto original
					break;
			}

			lblEstado.CssClass = css;
		}
	}
}
