<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EcommercePerfumes._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container my-4">
        <a href="Perfumes.aspx">
            <img src="https://perfumeriasublime.com/cdn/shop/collections/Banners_colecciones_Sublime_1800x600_px_13_2048x.png?v=1747933226"
                class="img-fluid w-100 rounded shadow-sm"
                alt="Perfumes destacados" />
        </a>
    </div>

    <div class="container my-5">
    <h3 class="text-center mb-4">Explorá por Categoría</h3>
    <div class="row g-3 text-center">
        <div class="col-md-4">
            <a href="Perfumes.aspx?genero=Hombre" class="text-decoration-none">
                <div class="categoria-card">
                    <img src="Imagenes/perf-hombre.jpg" alt="Hombres">
                    <div class="overlay">
                        <h5>Hombre</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col-md-4">
            <a href="Perfumes.aspx?genero=Mujer" class="text-decoration-none">
                <div class="categoria-card">
                    <img src="Imagenes/perf-mujer.jpg" alt="Mujeres">
                    <div class="overlay">
                        <h5>Mujer</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col-md-4">
            <a href="Perfumes.aspx?genero=Unisex" class="text-decoration-none">
                <div class="categoria-card">
                    <img src="Imagenes/perf-unisex.jpg" alt="Unisex">
                    <div class="overlay">
                        <h5>Unisex</h5>
                    </div>
                </div>
            </a>
        </div>
    </div>
</div>

    <div class="container my-5">
        <h3 class="text-center mb-4">Productos Destacados</h3>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <asp:Repeater ID="repDestacados" runat="server" OnItemCommand="repDestacados_ItemCommand">
                        <ItemTemplate>
                            <div class="col-md-3 mb-4">
                                <div class="card d-flex flex-column text-dark" style="width: 18rem;">
                                    <img src='<%#Eval("ImagenUrl") %>' class="card-img-top m-auto w-50" alt="...">
                                    <div class="card-body d-flex flex-column text-center">
                                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Marca.Nombre") %></p>
                                        <div class="mt-auto">
                                            <p class="card-text">$<%#string.Format("{0:N0}", Eval("Precio")) %></p>
                                            <div class="d-flex justify-content-between">
                                                <asp:Button ID="btnAgregarCarrito" Text="Agregar al carrito" runat="server" CommandName="Agregar"
                                                    CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-sm btn-outline-primary" />
                                                <a href="DetalleProducto.aspx?id=<%#Eval("Id") %>" class="btn btn-sm btn-light">Ver detalle</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <div class="container my-5">
        <div class="row text-center">
            <div class="col-md-4">
                <i class="fa fa-truck fs-1" style="color: #fbfb9a"></i>
                <p>Envíos a todo el país</p>
            </div>
            <div class="col-md-4">
                <i class="fa fa-shield-halved fs-1" style="color: #fbfb9a"></i>
                <p>Productos 100% originales</p>
            </div>
            <div class="col-md-4">
                <i class="fa fa-percent fs-1" style="color: #fbfb9a"></i>
                <p>10% de descuento pagando con transferencia</p>
            </div>
        </div>
    </div>

</asp:Content>
