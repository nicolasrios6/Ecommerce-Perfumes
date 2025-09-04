<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="EcommercePerfumes.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <div class="row">
            <div class="col-md-5">
                <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid rounded shadow-sm" />
            </div>

            <div class="col-md-7 mt-4">
                <h2>
                    <asp:Label ID="lblNombre" runat="server" />
                    -
                    <asp:Label ID="lblMililitros" runat="server" />ML</h2>
                <p>
                    <asp:Label ID="lblMarca" runat="server" CssClass="fs-4" />
                </p>
                <p class="pb-0">
                    <asp:Label ID="lblGenero" runat="server" />
                    -
                    <asp:Label ID="lblConcentracion" runat="server" />
                </p>
                <p class="text-muted">
                    <asp:Label ID="lblDescripcion" runat="server" />
                </p>
                <p class="text-muted">
                    <asp:Label ID="lblNotas" runat="server" />
                </p>
                <h4 class="text-primary">$<asp:Label ID="lblPrecio" runat="server" /></h4>



                <p>
                    <strong>Stock disponible:</strong>
                    <asp:Label ID="lblStock" runat="server" />
                </p>

                <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-primary" Enabled="true" />
            </div>
        </div>

        <!-- Productos relacionados -->
        <hr class="my-5" />
        <h3>Productos relacionados</h3>

        <div class="d-flex flex-row overflow-auto gap-3 pb-3">
            <asp:Repeater ID="repRelacionados" runat="server">
                <ItemTemplate>
                    <div class="card" style="min-width: 16rem;">
                        <img src='<%#Eval("ImagenUrl") %>' class="card-img-top m-auto w-50" alt="...">
                        <div class="card-body text-center d-flex flex-column">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Marca.Nombre") %></p>
                            <p class="card-text">$<%# string.Format("{0:N0}", Eval("Precio")) %></p>
                            <div class="mt-auto d-flex justify-content-between">
                                <a href="#" class="btn btn-sm btn-outline-primary">Agregar</a>
                                <a href='DetalleProducto.aspx?id=<%#Eval("Id") %>' class="btn btn-sm btn-light">Ver detalle</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </main>
</asp:Content>
