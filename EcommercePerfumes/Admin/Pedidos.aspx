<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="EcommercePerfumes.Admin.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Pedidos</h2>
    <a href="Dashboard.aspx" class="btn btn-secondary mb-3">Volver</a>

    <asp:GridView runat="server" ID="gvPedidos" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged" OnRowDataBound="gvPedidos_RowDataBound"   
     >
        <Columns>
            <asp:BoundField HeaderText="Número" DataField="Id" />
            <asp:BoundField HeaderText="Cliente" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="Estado" DataField="Estado" />--%>
            <asp:BoundField HeaderText="Envío" DataField="Envio" DataFormatString="${0:N0}" HtmlEncode="false" />
            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="${0:N0}" HtmlEncode="false" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Ver más" />
        </Columns>
    </asp:GridView>
</asp:Content>
