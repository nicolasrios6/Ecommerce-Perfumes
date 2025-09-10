<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="EcommercePerfumes.MisPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Mis pedidos</h2>

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
</asp:Content>
