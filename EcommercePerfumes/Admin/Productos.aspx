<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="EcommercePerfumes.Admin.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de productos</h2>
    <div class="mb-3">
        <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar Producto</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>
    <div class="container-fluid p-0">
        <div class="row align-items-end mb-3 p-3 border rounded bg-light mx-0">
            <div class="col-md-3">
                <label for="ddlMarcas" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarcas" runat="server" CssClass="form-select" AutoPostBack="true"
                    OnSelectedIndexChanged="filtrosChanged">
                </asp:DropDownList>
            </div>

            <div class="col-md-6">
                <label class="form-label d-block">Género</label>
                <asp:RadioButtonList ID="rblGenero" runat="server" RepeatDirection="Horizontal"
                    CssClass="form-check-inline"
                    AutoPostBack="true" OnSelectedIndexChanged="filtrosChanged">
                    <asp:ListItem Text="Todos" Value="" Selected="True" />
                    <asp:ListItem Text="Hombre" Value="Hombre" />
                    <asp:ListItem Text="Mujer" Value="Mujer" />
                    <asp:ListItem Text="Unisex" Value="Unisex" />
                </asp:RadioButtonList>
            </div>

            <div class="col-md-3 text-md-end">
                <asp:Button ID="btnResetFiltros" runat="server" CssClass="btn btn-outline-secondary"
                    Text="Quitar filtros" OnClick="btnResetFiltros_Click" />
            </div>
        </div>

        <asp:GridView ID="gvProductos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="${0:N0}" />
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
    </div>
</asp:Content>
