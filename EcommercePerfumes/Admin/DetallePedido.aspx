<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="EcommercePerfumes.Admin.DetallePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pedido N°
        <asp:Label ID="lblNumeroPedidoTitulo" runat="server" /></h2>
    <a href="Pedidos.aspx" class="btn btn-secondary mb-3">Volver</a>

    <asp:Panel ID="pnlInfoPedido" CssClass="mb-4 border p-3 rounded bg-light" runat="server">
        <h3>Información del Pedido</h3>
        <p>
            <strong>Número:</strong>
            <asp:Label ID="lblNumeroPedido" runat="server" />
        </p>
        <p>
            <strong>Cliente:</strong>
            <asp:Label ID="lblCliente" runat="server" />
        </p>
        <p>
            <strong>Fecha:</strong>
            <asp:Label ID="lblFecha" runat="server" />
        </p>
        <p>
            <strong>Método de Envío:</strong>
            <asp:Label ID="lblMetodoEnvio" runat="server" />
        </p>
        <p>
            <strong>Dirección de Envío:</strong>
            <asp:Label ID="lblDireccion" runat="server" />
        </p>
        <p>
            <strong>Método de Pago:</strong>
            <asp:Label ID="lblMetodoPago" runat="server" />
        </p>
        <p>
            <strong>Observaciones:</strong>
            <asp:Label ID="lblObservaciones" runat="server" />
        </p>
    </asp:Panel>

    <asp:Panel ID="pnlComprobante" runat="server" CssClass="mb-4 border p-3 rounded bg-white" Visible="false">
        <h4>Comprobante de Pago</h4>
        <asp:HyperLink ID="lnkComprobante" runat="server" Target="_blank" CssClass="btn btn-outline-primary">
        Ver Comprobante
        </asp:HyperLink>
        <br />
        <br />
        <asp:Image ID="imgComprobante" runat="server" CssClass="img-fluid border rounded" Visible="false" />
    </asp:Panel>

    <asp:Panel ID="pnlDetalles" runat="server" CssClass="mb-4 p-3">
        <h4>Productos</h4>
        <asp:GridView ID="gvDetalles" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField HeaderText="Producto" DataField="NombreProducto" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnitario" DataFormatString="${0:N0}" HtmlEncode="false" />
                <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" DataFormatString="${0:N0}" HtmlEncode="false" />
            </Columns>
        </asp:GridView>

        <!-- Totales -->
        <div class="mt-3">
            <strong>Subtotal:</strong>
            <asp:Label ID="lblSubtotal" runat="server" />
            <br />
            <strong>Envío:</strong>
            <asp:Label ID="lblEnvio" runat="server" />
            <br />
            <strong>Total:</strong>
            <asp:Label ID="lblTotal" runat="server" />
        </div>
    </asp:Panel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>


            <asp:Panel ID="pnlEstado" runat="server" CssClass="border p-3 bg-white rounded">
                <h4>Estado del Pedido</h4>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control w-25 mb-3" AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                    <asp:ListItem Text="Pendiente" Value="Pendiente" />
                    <asp:ListItem Text="Procesando" Value="Procesando" />
                    <asp:ListItem Text="Enviado" Value="Enviado" />
                    <asp:ListItem Text="Entregado" Value="Entregado" />
                    <asp:ListItem Text="Cancelado" Value="Cancelado" />
                </asp:DropDownList>

                <asp:Panel ID="pnlTracking" runat="server" Visible="false" CssClass="mb-3">
                    <label>Número de seguimiento:</label>
                    <asp:TextBox ID="txtTracking" runat="server" CssClass="form-control w-50" />
                </asp:Panel>

                <asp:Button ID="btnActualizarEstado" runat="server" Text="Actualizar Estado" CssClass="btn btn-primary" OnClick="btnActualizarEstado_Click" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
