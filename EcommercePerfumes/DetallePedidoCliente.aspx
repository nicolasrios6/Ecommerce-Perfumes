<%@ Page Title="Detalle Pedido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePedidoCliente.aspx.cs" Inherits="EcommercePerfumes.DetallePedidoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pedido N°
        <asp:Label ID="lblNumeroPedidoTitulo" runat="server" /></h2>
    <a href="MisPedidos.aspx" class="btn btn-secondary mb-3">Volver</a>

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
        <p>
            <strong>Estado del pedido:</strong>
            <asp:Label ID="lblEstado" runat="server" />
        </p>
    </asp:Panel>

    <asp:Panel ID="pnlComprobante" runat="server" CssClass="mb-4 border p-3 rounded bg-white" Visible="false">
    <h4>Comprobante de Pago</h4>
    <asp:HyperLink ID="lnkComprobante" runat="server" Target="_blank" CssClass="btn btn-outline-primary">
        Ver Comprobante
    </asp:HyperLink>
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
</asp:Content>
