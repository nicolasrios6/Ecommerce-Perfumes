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
	public partial class DetallePedido : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				int id = Convert.ToInt32(Request.QueryString["id"]);
				lblNumeroPedidoTitulo.Text = id.ToString();
				CargarPedido(id);
			}
		}

		private void CargarPedido(int id)
		{
			PedidoNegocio negocio = new PedidoNegocio();
			Pedido pedido = negocio.ObtenerPorId(id);

			lblNumeroPedido.Text = pedido.Id.ToString();
			lblCliente.Text = pedido.NombreUsuario;
			lblFecha.Text = pedido.Fecha.ToString("dd/MM/yyyy");
			lblMetodoEnvio.Text = pedido.MetodoEnvio;
			lblDireccion.Text = pedido.DireccionEnvio;
			lblMetodoPago.Text = pedido.MetodoPago;
			lblObservaciones.Text = pedido.Observaciones;

			lblSubtotal.Text = $"${pedido.Subtotal:N0}";
			lblEnvio.Text = $"${pedido.Envio:N0}";
			lblTotal.Text = $"${pedido.Total:N0}";

			ddlEstado.SelectedValue = pedido.Estado;

			repDetalles.DataSource = pedido.Detalles;
			repDetalles.DataBind();
			gvDetalles.DataSource = pedido.Detalles;
			gvDetalles.DataBind();

			// *** Comprobante ***
			if (!string.IsNullOrEmpty(pedido.ComprobanteUrl))
			{
				pnlComprobante.Visible = true;
				lnkComprobante.NavigateUrl = pedido.ComprobanteUrl;

				// Si es imagen, mostrarla embebida
				if (pedido.ComprobanteUrl.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
					pedido.ComprobanteUrl.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
					pedido.ComprobanteUrl.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
				{
					imgComprobante.Visible = true;
					imgComprobante.ImageUrl = pedido.ComprobanteUrl;
				}
			}
		}

		protected void btnActualizarEstado_Click(object sender, EventArgs e)
        {
			int id = Convert.ToInt32(Request.QueryString["id"]);
			string nuevoEstado = ddlEstado.SelectedValue;
			string seguimiento = ddlEstado.SelectedValue == "Enviado" ? txtTracking.Text.Trim() : null;

			PedidoNegocio negocio = new PedidoNegocio();
			negocio.ActualizarEstado(id, nuevoEstado, seguimiento);
			Pedido pedidoActual = negocio.ObtenerPorId(id);
			UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
			var usuarioActual = usuarioNegocio.BuscarPorId(pedidoActual.UsuarioId);
			EmailService.EnviarCambioEstado(usuarioActual.Email, pedidoActual.Id, pedidoActual.Estado, seguimiento);
			Response.Redirect("Pedidos.aspx", false);
		}

		protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnlTracking.Visible = ddlEstado.SelectedValue == "Enviado";
		}
	}
}