<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="EcommercePerfumes.Admin.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Marcas</h2>
    <div class="mb-3">
        <a href="FormularioMarca.aspx" class="btn btn-primary">Agregar Marca</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>
    <asp:GridView ID="gvMarcas" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" runat="server" OnSelectedIndexChanged="gvMarcas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar"/>
        </Columns>
    </asp:GridView>
</asp:Content>
