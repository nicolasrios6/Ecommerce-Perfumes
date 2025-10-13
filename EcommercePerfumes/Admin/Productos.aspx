<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="EcommercePerfumes.Admin.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de productos</h2>
    <div class="mb-3">
        <a href="FormularioProducto.aspx" class="btn btn-primary">Agregar Producto</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>
    <div class="container-fluid p-0">
        <div class="row align-items-end mb-3 p-3 border rounded bg-light mx-0">
            <div>
                <label for="" class="form-label">Buscar por nombre</label>
                <asp:TextBox runat="server" ID="txtNombreFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtrosChanged" />
            </div>
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
                <asp:Button ID="btnResetFiltros" runat="server" CssClass="btn btn-secondary"
                    Text="Quitar filtros" OnClick="btnResetFiltros_Click" />
            </div>
        </div>

        <asp:Repeater runat="server" ID="repProductosCards">
            <HeaderTemplate>
                <div class="row g-3 justify-content-start">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-12 col-sm-6 col-lg-4 d-flex justify-content-center" >
                    <div class="card shadow-sm w-75 h-100 mb-3">
                        <div class="card-body d-flex flex-column text-center">

                            <!-- Imagen -->
                            <asp:Image ImageUrl='<%# Eval("ImagenUrl") %>' runat="server"
                                CssClass="img-fluid mb-3 mx-auto"
                                Style="max-height: 120px; object-fit: contain;" />

                            <!-- Nombre -->
                            <h5 class="card-title mb-1"><%# Eval("Nombre") %></h5>

                            <!-- Marca y Género -->
                            <p class="text-muted mb-1">
                                <%# Eval("Marca.Nombre") %> - <%# Eval("Genero") %>
                            </p>

                            <!-- Stock -->
                            <span class="badge bg-<%# (Convert.ToInt32(Eval("Stock")) > 0 ? "success" : "danger") %> mb-2 d-inline-block align-self-center">Stock: <%# Eval("Stock") %>
                            </span>

                            <!-- Precio -->
                            <p class="fw-bold mb-3">$<%# string.Format("{0:N0}", Eval("Precio")) %></p>

                            <!-- Botón Modificar -->
                            <a href='<%# "FormularioProducto.aspx?id=" + Eval("Id") %>'
                                class="btn btn-primary btn-sm w-auto mx-auto mt-auto">Modificar
                            </a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
