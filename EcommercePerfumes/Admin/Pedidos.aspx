<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="EcommercePerfumes.Admin.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Pedidos</h2>
    <a href="Dashboard.aspx" class="btn btn-secondary mb-3">Volver</a>

    <asp:Panel runat="server" CssClass="mb-3 p-3 border rounded bg-light">
        <div class="row g-3">
            <div class="col-md-3">
                <label for="txtFechaDesde" class="form-label">Desde</label>
                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="col-md-3">
                <label for="txtFechaHasta" class="form-label">Hasta</label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date" />
            </div>

            <div class="col-md-3">
                <label for="ddlEstado" class="form-label">Estado</label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Todos" Value="" />
                    <asp:ListItem Text="Pendiente" Value="Pendiente" />
                    <asp:ListItem Text="Procesando" Value="Procesando" />
                    <asp:ListItem Text="Enviado" Value="Enviado" />
                    <asp:ListItem Text="Entregado" Value="Entregado" />
                    <asp:ListItem Text="Cancelado" Value="Cancelado" />
                </asp:DropDownList>
            </div>

            <div class="col-md-3 d-flex align-items-end">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary me-2" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
            </div>
        </div>
    </asp:Panel>

    <asp:GridView runat="server" ID="gvPedidos" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged" OnRowDataBound="gvPedidos_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Número" DataField="Id" />
            <asp:BoundField HeaderText="Cliente" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Envío" DataField="Envio" DataFormatString="${0:N0}" HtmlEncode="false" />
            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="${0:N0}" HtmlEncode="false" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Ver más" />
        </Columns>
    </asp:GridView>
</asp:Content>
