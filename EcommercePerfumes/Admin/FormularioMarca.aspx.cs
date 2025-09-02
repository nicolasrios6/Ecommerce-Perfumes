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
	public partial class FormularioMarca : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Seguridad.VerificarAdmin(this);
			if (!IsPostBack)
			{
				if (Request.QueryString["id"] != null)
				{
					int id = int.Parse(Request.QueryString["id"]);
					CargarMarca(id);
					btnGuardar.Text = "Modificar";
				}
			}
		}

		private void CargarMarca(int id)
		{
			MarcaNegocio negocio = new MarcaNegocio();
			Marca marca = negocio.ObtenerPorId(id);

			if(marca != null)
			{
				txtNombre.Text = marca.Nombre;
				chkActivo.Checked = marca.Activo;
				Session["MarcaId"] = marca.Id;
			}
		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			string nombre = txtNombre.Text.Trim();
			if (string.IsNullOrWhiteSpace(nombre))
			{
				lblError.Text = "El Nombre es obligatorio";
				return;
			}

			MarcaNegocio marcaNegocio = new MarcaNegocio();
			Marca marca = new Marca
			{
				Nombre = nombre,
				Activo = chkActivo.Checked,
			};

			try
			{
				if (Session["MarcaId"] != null)
				{
					marca.Id = (int)Session["MarcaId"];
					marcaNegocio.Modificar(marca);
					Session.Remove("MarcaId");
				}
				else
				{
					marcaNegocio.Agregar(marca.Nombre);
					string returnUrl = Request.QueryString["returnUrl"];

					if (!string.IsNullOrEmpty(returnUrl))
					{
						Response.Redirect(returnUrl, false);
					}
					else
					{
						Response.Redirect("Marcas.aspx", false);
					}
				}

				//Response.Redirect("Marcas.aspx", false);
			}
			catch (Exception ex)
			{

				throw new Exception("Error al guardar la marca.", ex);
			}
		}
	}
}