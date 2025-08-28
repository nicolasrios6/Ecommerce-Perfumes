using EcommercePerfumes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace EcommercePerfumes.Negocio
{
	public class Seguridad
	{
		public static bool UsuarioLogueado(HttpSessionState session)
		{
			return session["Usuario"] != null;
		}

		public static bool EsAdmin(HttpSessionState session)
		{
			if (UsuarioLogueado(session))
			{
				var usuario = (Usuario)session["Usuario"];
				return usuario.RolId == 1;
			}
			return false;
		}

		public static void VerificarAdmin(Page page)
		{
			var usuario = (Usuario)HttpContext.Current.Session["Usuario"];
			if (usuario == null || usuario.RolId != 1)
				page.Response.Redirect("~/AccesoDenegado.aspx");
		}

		public static bool EsCliente(HttpSessionState session)
		{
			if (UsuarioLogueado(session))
			{
				var usuario = (Usuario)session["Usuario"];
				return usuario.RolId == 2;
			}
			return false;
		}

		public static void RedirigirSiNoAdmin(Page page)
		{
			if (!EsAdmin(page.Session))
				page.Response.Redirect("~/Default.aspx");
		}

		public static void RedirigirSiNoCliente(Page page)
		{
			if (!EsCliente(page.Session))
				page.Response.Redirect("~/Login.aspx");
		}

		public static void RedirigirSiNoLogueado(Page page)
		{
			if (!UsuarioLogueado(page.Session))
				page.Response.Redirect("~/Login.aspx");
		}
	}
}
