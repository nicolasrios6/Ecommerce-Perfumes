<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="EcommercePerfumes.Admin.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de productos</h2>
    <div class="mb-3">
        <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar Producto</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>
    <asp:GridView ID="gvProductos" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Stock" DataField="Stock" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Nombre" />
            <asp:BoundField HeaderText="Genero" DataField="Genero" />
            <asp:BoundField HeaderText="Concentracion" DataField="Concentracion" />
            <asp:BoundField HeaderText="Mililitros" DataField="Mililitros" />
            <asp:BoundField HeaderText="Notas" DataField="Notas" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar" />
        </Columns>
    </asp:GridView>
</asp:Content>
