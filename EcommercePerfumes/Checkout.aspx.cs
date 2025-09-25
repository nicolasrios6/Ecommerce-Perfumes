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

			// ✅ VALIDACIÓN DE SELECCIONES
			if (string.IsNullOrEmpty(rblEnvio.SelectedValue))
			{
				Page.Validators.Add(new CustomValidator
				{
					ErrorMessage = "Debes seleccionar un método de envío.",
					IsValid = false
				});
				return;
			}

			if (string.IsNullOrEmpty(rblPago.SelectedValue))
			{
				Page.Validators.Add(new CustomValidator
				{
					ErrorMessage = "Debes seleccionar un método de pago.",
					IsValid = false
				});
				return;
			}

			//Efectivo sólo si Retiro en local está seleccionado
			if (rblPago.SelectedValue == "Efectivo" && rblEnvio.SelectedValue != "Retiro")
			{
				Page.Validators.Add(new CustomValidator
				{
					ErrorMessage = "Si pagás en efectivo, debes seleccionar 'Retiro en el Local' como método de envío.",
					IsValid = false
				});
				return;
				
			}

			bool esTransferencia = rblPago.SelectedValue == "Transferencia";
			if (esTransferencia && !fuComprobante.HasFile)
			{
				lblError.Text = "Debes adjuntar el comprobante de pago para transferencia.";
				lblError.CssClass = "text-danger";
				return;
			}
				// Si hay comprobante, validamos extensión y tamaño (ejemplo: máximo 5MB)
				string comprobanteRutaRelativa = null;
			string comprobanteNombreFisico = null;

			if(esTransferencia && fuComprobante.HasFile)
			{
				int maxBytes = 5 * 1024 * 1024;
				string[] allowedExt = new[] {".jpg", ".jpeg", ".png", ".pdf" };

				string ext = System.IO.Path.GetExtension(fuComprobante.FileName).ToLowerInvariant();
				if(!allowedExt.Contains(ext))
				{
					lblError.Text = "Tipo de archivo no permitido. Sólo JPG, PNG o PDF.";
					lblError.CssClass = "text-danger";
					return;
				}
				if (fuComprobante.PostedFile.ContentLength > maxBytes)
				{
					lblError.Text = "El comprobante supera el tamaño máximo (5 MB).";
					lblError.CssClass = "text-danger";
					return;
				}

				string comprobantesFolder = Server.MapPath("~/Comprobantes/");
				if(!System.IO.Directory.Exists(comprobantesFolder))
					System.IO.Directory.CreateDirectory(comprobantesFolder);

				comprobanteNombreFisico = Guid.NewGuid().ToString() + ext;
				string rutaFisica = System.IO.Path.Combine(comprobantesFolder, comprobanteNombreFisico);
				try
				{
					fuComprobante.SaveAs(rutaFisica);
					comprobanteRutaRelativa = "~/Comprobantes/" + comprobanteNombreFisico;
				}
				catch (Exception ex)
				{
					lblError.Text = "No se pudo guardar el comprobante. Intentá nuevamente.";
					lblError.CssClass = "text-danger";
					// loggear ex
					return;
				}
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
				ComprobanteUrl = comprobanteRutaRelativa,
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
				string htmlDetalle = GenerarHtmlDetalle(carrito, subtotal, envio, total);
				EmailService.EnviarConfirmacionPedido(usuario.Email, pedido.Id, htmlDetalle);

				// Limpiar carrito
				Session["Carrito"] = null;

				// Redirigir a confirmación
				Response.Redirect("~/Confirmacion.aspx", false);
			}
			catch (Exception ex)
			{
				// Si falló la inserción y ya guardamos un comprobante en disco, borrarlo para evitar archivos huérfanos
				if (!string.IsNullOrEmpty(comprobanteNombreFisico))
				{
					try
					{
						string rutaFisica = Server.MapPath("~/Comprobantes/" + comprobanteNombreFisico);
						if (System.IO.File.Exists(rutaFisica))
							System.IO.File.Delete(rutaFisica);
					}
					catch {
						throw new Exception();
					}
				}
				// Mostrar error
				lblError.Text = "Hubo un error al procesar el pedido.";
			}
		}

		protected void rblPago_SelectedIndexChanged(object sender, EventArgs e)
		{
			Panel1.Visible = (rblPago.SelectedValue == "Transferencia");
		}

		private string GenerarHtmlDetalle(List<ItemCarrito> carrito, decimal subtotal, decimal envio, decimal total)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			
			sb.Append("<p>Estos son los detalles de tu pedido:</p>");
			sb.Append("<table style='border-collapse: collapse; width: 100%;'>");
			sb.Append("<tr style='background-color:#f2f2f2;'>");
			sb.Append("<th style='border: 1px solid #ddd; padding: 8px;'>Producto</th>");
			sb.Append("<th style='border: 1px solid #ddd; padding: 8px;'>Cantidad</th>");
			sb.Append("<th style='border: 1px solid #ddd; padding: 8px;'>Precio</th>");
			sb.Append("<th style='border: 1px solid #ddd; padding: 8px;'>Subtotal</th>");
			sb.Append("</tr>");

			foreach (var item in carrito)
			{
				sb.Append("<tr>");
				sb.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{item.Nombre}</td>");
				sb.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>{item.Cantidad}</td>");
				sb.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>${item.Precio:N0}</td>");
				sb.Append($"<td style='border: 1px solid #ddd; padding: 8px;'>${item.Subtotal:N0}</td>");
				sb.Append("</tr>");
			}

			sb.Append("</table>");
			sb.Append("<br/>");
			sb.Append($"<p><strong>Subtotal:</strong> ${subtotal:N0}</p>");
			sb.Append($"<p><strong>Envío:</strong> ${envio:N0}</p>");
			sb.Append($"<p><strong>Total:</strong> ${total:N0}</p>");
			sb.Append("<br/>");
			sb.Append("<p>En breve recibirás otro correo informando la actualización de tu pedido.</p>");

			return sb.ToString();
		}
	}
}