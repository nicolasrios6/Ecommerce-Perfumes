using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Negocio
{
	public class EmailService
	{
		private static string remitente = "nicolasrios.dev@gmail.com";

		public static void EnviarCambioEstado(string destinatario, int numeroPedido, string estado, string seguimiento = null)
		{
			string asunto = $"Actualización de tu pedido #{numeroPedido}";
			string cuerpo = $"<h3>¡Hola!</h3><p>Tu pedido con número <strong>{numeroPedido}</strong> se encuentra: <strong>{estado}</strong>.</p>";

			if (estado == "Enviado" && !string.IsNullOrEmpty(seguimiento))
			{
				cuerpo += $"<p><strong>Número de seguimiento:</strong> {seguimiento}</p>";
			}

			cuerpo += "<p>Gracias por comprar en nuestra tienda.</p>";

			EnviarEmail(destinatario, asunto, cuerpo);
		}

		public static void EnviarConfirmacionPedido(string destinatario, int numeroPedido, string detallesPedidoHtml)
		{
			string asunto = $"Confirmación de pedido #{numeroPedido}";
			string cuerpo = $"<h3>Gracias por tu compra</h3><p>Tu pedido con número <strong>{numeroPedido}</strong> fue registrado correctamente.</p>";
			cuerpo += detallesPedidoHtml;
			EnviarEmail(destinatario, asunto, cuerpo);
		}

		public static void EnviarEmail(string destinatario, string asunto, string cuerpoHtml)
		{
			using (MailMessage mail = new MailMessage())
			{
				mail.From = new MailAddress(remitente, "Tienda de Perfumes");
				mail.To.Add(destinatario);
				mail.Subject = asunto;
				mail.Body = cuerpoHtml;
				mail.IsBodyHtml = true;

				using (SmtpClient smtp = new SmtpClient())
				{
					//smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
					//smtp.EnableSsl = true;
					smtp.Send(mail);
				}
			}
		}
	}
}
