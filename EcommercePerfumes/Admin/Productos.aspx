<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="EcommercePerfumes.Admin.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de productos</h2>
    <div class="mb-3">
        <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar Producto</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>

    <div class="mb-3">
        <!-- Marca -->
        <h6 class="mt-3">Marca</h6>
        <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="filtrosChanged"></asp:DropDownList>

        <!-- Género -->
        <h6 class="mt-3">Género</h6>
        <asp:RadioButtonList ID="rblGenero" runat="server" CssClass="list-group" AutoPostBack="true" OnSelectedIndexChanged="filtrosChanged">
            <asp:ListItem Text="Todos" Value="" Selected="True" />
            <asp:ListItem Text="Hombre" Value="Hombre"></asp:ListItem>
            <asp:ListItem Text="Mujer" Value="Mujer"></asp:ListItem>
            <asp:ListItem Text="Unisex" Value="Unisex"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <asp:GridView ID="gvProductos" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
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
