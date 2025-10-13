<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="EcommercePerfumes.Admin.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ps-2">Gestión de Pedidos</h2>
    <a href="Dashboard.aspx" class="btn btn-secondary ms-2 mb-3">Volver</a>

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

    <div class="row d-md-none">
        <asp:Repeater runat="server" ID="repPedidos" OnItemDataBound="repPedidos_ItemDataBound">
            <ItemTemplate>
                <div class="col-12 col-md-4 g-3 d-flex justify-content-center">
                    <div class="card w-75">
                        <div class="card-body text-center d-flex flex-column">
                            <h5 class="card-title">#<%#Eval("Id") %></h5>
                            <h5><%#Eval("NombreUsuario") %></h5>
                            <p>$<%#string.Format("{0:N0}", Eval("Total")) %></p>
                            <p class="text-center">
                                <asp:Label ID="lblEstado" runat="server" CssClass="badge d-inline-block px-3 py-1" Text='<%#Eval("Estado") %>'></asp:Label>
                            </p>
                            <a href='<%#"DetallePedido.aspx?id=" + Eval("Id") %>' class="btn btn-sm btn-primary m-auto">Ver más</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="d-none d-md-block">

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
    </div>
</asp:Content>
