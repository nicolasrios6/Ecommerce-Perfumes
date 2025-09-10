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
	public partial class Checkout : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.RedirigirSiNoLogueado(Page);
			if (!IsPostBack)
			{
				List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();
				repResumenCarrito.DataSource = carrito;
				repResumenCarrito.DataBind();

				ActualizarResumen();

				Usuario usuario = Session["Usuario"] as Usuario;
				if (usuario != null)
				{
					txtNombre.Text = usuario.Nombre;
					txtApellido.Text = usuario.Apellido;
					txtEmail.Text = usuario.Email;
					txtTelefono.Text = usuario.Telefono;
				}

			}
			Panel1.Visible = (rblPago.SelectedValue == "Transferencia");
		}

		private void ActualizarResumen()
		{
			List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();

			decimal subtotal = carrito.Sum(i => i.Subtotal);
			decimal envio = rblEnvio.SelectedValue == "Envio" ? 8000 : 0;
			decimal total = subtotal + envio;

			lblSubtotal.Text = $"${subtotal.ToString("N0")}";
			lblEnvio.Text = $"${envio.ToString("N0")}";
			lblTotal.Text = $"${total.ToString("N0")}";
		}

		protected void rblEnvio_SelectedIndexChanged(object sender, EventArgs e)
		{
			rfvDireccion.Enabled = (rblEnvio.SelectedValue == "Envio");
			ActualizarResumen();
		}

		protected void btnConfirmarCompra_Click(object sender, EventArgs e)
		{
			Usuario usuario = Session["Usuario"] as Usuario;
			if (usuario == null)
			{
				// Redirigir o mostrar error
				Response.Redirect("~/Login.aspx");
				return;
			}

			List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito>;
			if (carrito == null || !carrito.Any())
			{
				// Mostrar mensaje de carrito vacío
				return;
			}

			decimal subtotal = carrito.Sum(i => i.Subtotal);
			decimal envio = rblEnvio.SelectedValue == "Envio" ? 8000 : 0;
			decimal total = subtotal + envio;

			Pedido pedido = new Pedido
			{
				UsuarioId = usuario.Id,
				Fecha = DateTime.Now,
				Estado = "Pendiente",
				Subtotal = subtotal,
				Envio = envio,
				Total = total,
				DireccionEnvio = rblEnvio.SelectedValue == "Envio" ? txtDireccion.Text.Trim() : null,
				MetodoEnvio = rblEnvio.SelectedValue,
				MetodoPago = rblPago.SelectedValue,
				Observaciones = txtObservaciones.Text.Trim(),
				Detalles = carrito.Select(item => new DetallePedido
				{
					ProductoId = item.ProductoId,
					NombreProducto = item.Nombre,
					Cantidad = item.Cantidad,
					PrecioUnitario = item.Precio,
					Subtotal = item.Subtotal
				}).ToList()
			};

			// Guardar en la base
			PedidoNegocio negocio= new PedidoNegocio();
			try
			{
				negocio.Crear(pedido);

				ProductoNegocio productoNegocio = new ProductoNegocio();
				foreach(var item in carrito)
				{
					productoNegocio.DescontarStock(item.ProductoId, item.Cantidad);
				}

				// Limpiar carrito
				Session["Carrito"] = null;

				// Redirigir a confirmación
				Response.Redirect("~/Confirmacion.aspx", false);
			}
			catch (Exception ex)
			{
				// Mostrar error
				lblError.Text = "Hubo un error al procesar el pedido.";
			}
		}

		protected void rblPago_SelectedIndexChanged(object sender, EventArgs e)
		{
			Panel1.Visible = (rblPago.SelectedValue == "Transferencia");
		}
	}
}