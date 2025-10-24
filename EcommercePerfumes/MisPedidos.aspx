<%@ Page Title="Mis Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="EcommercePerfumes.MisPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mis pedidos</h2>

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
                        <a href='<%#"DetallePedidoCliente.aspx?id=" + Eval("Id") %>' class="btn btn-sm btn-primary m-auto">Ver más</a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

    <div class="d-none d-md-block">

    <asp:GridView runat="server" ID="gvMisPedidos" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="gvMisPedidos_SelectedIndexChanged" OnRowDataBound="gvMisPedidos_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Número" DataField="Id" />
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Envío" DataField="Envio" DataFormatString="${0:N0}" HtmlEncode="false" />
            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="${0:N0}" HtmlEncode="false"/>
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Ver más" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
