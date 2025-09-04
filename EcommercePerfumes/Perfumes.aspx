<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfumes.aspx.cs" Inherits="EcommercePerfumes.Perfumes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <h2>Lista de Perfumes</h2>

        <div class="row">
            <div class="col-3">
                <div class="sticky-top" style="top: 80px">
                    <h5>Filtros</h5>

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

                    <!-- Rango de precios -->
                    <h6 class="mt-3">Precio</h6>
                    <asp:RadioButtonList ID="rblPrecio" runat="server" CssClass="list-group" AutoPostBack="true" OnSelectedIndexChanged="filtrosChanged">
                        <asp:ListItem Text="Todos" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Menos de $60.000" Value="1"></asp:ListItem>
                        <asp:ListItem Text="$60.000 - $100.000" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Más de $100.000" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>

                    <asp:Button ID="btnLimpiarFiltros" Text="Limpiar filtros" runat="server"
                        CssClass="btn btn-warning mt-3 " OnClick="btnLimpiarFiltros_Click"    
                    />
                </div>

            </div>

            <div class="col-9">
                <div class="row gap-4">
                    <asp:Repeater runat="server" ID="repPerfumes">
                        <ItemTemplate>
                            <div class="card d-flex flex-column" style="width: 18rem;">
                                <img src='<%#Eval("ImagenUrl") %>' class="card-img-top m-auto w-50" alt="...">
                                <div class="card-body d-flex flex-column text-center">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Marca.Nombre") %></p>
                                    <div class="mt-auto">
                                        <p class="card-text">$<%#string.Format("{0:N0}", Eval("Precio")) %></p>
                                        <div class="d-flex justify-content-between">
                                            <a href="#" class="btn btn-sm btn-outline-primary">Agregar al carrito</a>
                                            <a href="DetalleProducto.aspx?id=<%#Eval("Id") %>" class="btn btn-sm btn-light">Ver detalle</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>


    </main>

</asp:Content>
