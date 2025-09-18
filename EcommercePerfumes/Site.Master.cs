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
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ActualizarCarritoCount();

				if (Session["Usuario"] != null)
				{
					Usuario usuario = (Usuario)Session["Usuario"];
					liLogin.Visible = false;
					liRegistro.Visible = false;
					liLogout.Visible = true;
					if (Seguridad.EsCliente(Page.Session))
					{
						liMisPedidos.Visible = true;
						liPanelAdmin.Visible = false;
					} else
					{
						liMisPedidos.Visible = false;
						liPanelAdmin.Visible = true;
					}
					
				} else
				{
					liLogin.Visible = true;
					liRegistro.Visible = true;
					liLogout.Visible = false;
					liMisPedidos.Visible = false;
					liPanelAdmin.Visible = false;
				}

				CargarCarrito();
			}
		}

        protected void btnLogout_Click(object sender, EventArgs e)
        {
			Session.Clear();
			Session.Abandon();
			Response.Redirect("~/Login.aspx");
        }

		public void CargarCarrito()
		{
			List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito>;

			if (carrito != null && carrito.Count > 0)
			{
				int cantidadTotal = carrito.Sum(x => x.Cantidad);

				repCarrito.DataSource = carrito;
				repCarrito.DataBind();

				pnlCarritoVacio.Visible = false;
				pnlResumenCarrito.Visible = true;

				lblTotal.Text = carrito.Sum(x => x.Precio * x.Cantidad).ToString("N0");
			}
			else
			{

				repCarrito.DataSource = null;
				repCarrito.DataBind();

				pnlCarritoVacio.Visible = true;
				pnlResumenCarrito.Visible = false;
			}

			ActualizarCarritoCount();
		}

		protected void repCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();
			int productoId = Convert.ToInt32(e.CommandArgument);

			ItemCarrito item = carrito.FirstOrDefault(x => x.ProductoId == productoId);

			if (item != null)
			{
				switch (e.CommandName)
				{
					case "Sumar":
						if(item.Cantidad < item.StockDisponible)
							item.Cantidad++;
						break;

					case "Restar":
						if (item.Cantidad > 1)
							item.Cantidad--;
						else
							carrito.Remove(item);
						break;

					case "Eliminar":
						carrito.Remove(item);
						break;
				}
			}

			Session["Carrito"] = carrito;
			CargarCarrito();
			ActualizarCarritoCount();
			ActualizarUpdatePanel();
			ActualizarUpdatePanelCarrito();
		}

		public void ActualizarUpdatePanel()
		{
			UpdatePanel1.Update();
		}
		public void ActualizarUpdatePanelCarrito()
		{
			upCarrito.Update();
		}

		protected void repCarrito_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				var itemCarrito = (ItemCarrito)e.Item.DataItem;

				// Buscar el botón sumar
				LinkButton btnSumar = (LinkButton)e.Item.FindControl("btnSumar");

				if (btnSumar != null)
				{
					// Si la cantidad en el carrito ya es igual al stock disponible -> deshabilitar
					if (itemCarrito.Cantidad >= itemCarrito.StockDisponible)
					{
						btnSumar.Enabled = false;
						btnSumar.CssClass = "btn btn-sm btn-outline-secondary disabled";
					}
				}
			}
		}

		public void ActualizarCarritoCount()
		{
			List<ItemCarrito> carrito = Session["Carrito"] as List<ItemCarrito> ?? new List<ItemCarrito>();
			int totalProductos = carrito.Sum(item => item.Cantidad);

			lblCarritoCount.Text = totalProductos > 0 ? totalProductos.ToString() : "";

			lblCarritoCount.Parent.Visible = totalProductos > 0;
		}
	}
}