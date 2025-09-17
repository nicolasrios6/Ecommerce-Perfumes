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
	public partial class DetallePedidoCliente : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
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
			lblEstado.Text = pedido.Estado;

			lblSubtotal.Text = $"${pedido.Subtotal:N0}";
			lblEnvio.Text = $"${pedido.Envio:N0}";
			lblTotal.Text = $"${pedido.Total:N0}";

			gvDetalles.DataSource = pedido.Detalles;
			gvDetalles.DataBind();

			// *** Comprobante ***
			if (!string.IsNullOrEmpty(pedido.ComprobanteUrl))
			{
				pnlComprobante.Visible = true;
				lnkComprobante.NavigateUrl = pedido.ComprobanteUrl;
			}
		}
	}
}