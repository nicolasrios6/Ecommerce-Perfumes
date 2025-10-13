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
                <p class="">
                    <asp:Label ID="lblDescripcion" runat="server" />
                </p>
                <p class="">
                    <asp:Label ID="lblNotas" runat="server" />
                </p>
                <h4 class="text-primary">$<asp:Label ID="lblPrecio" runat="server" /></h4>



                <p>
                    <strong>Stock disponible:</strong>
                    <asp:Label ID="lblStock" runat="server" />
                </p>
                <div class="d-flex gap-2">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-primary" Enabled="true" OnClick="btnAgregarCarrito_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <a href="Perfumes.aspx" class="btn btn-secondary">Volver</a>
                </div>
            </div>
        </div>

        <!-- Productos relacionados -->
        <hr class="my-5" />
        <h3>Productos relacionados</h3>

        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upRelacionados">
            <ContentTemplate>

                <div class="d-flex flex-row overflow-auto gap-3 pb-3">
                    <asp:Repeater ID="repRelacionados" runat="server" OnItemCommand="repRelacionados_ItemCommand">
                        <ItemTemplate>
                            <div class="card text-dark" style="min-width: 16rem;">
                                <img src='<%#Eval("ImagenUrl") %>' class="card-img-top m-auto w-50" alt="...">
                                <div class="card-body text-center d-flex flex-column">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Marca.Nombre") %></p>
                                    <p class="card-text">$<%# string.Format("{0:N0}", Eval("Precio")) %></p>
                                    <div class="mt-auto d-flex justify-content-between">
                                        <asp:Button ID="btnAgregarCarritoDestacado" Text="Agregar al carrito" runat="server" CommandName="Agregar"
                                            CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-sm btn-outline-primary" />
                                        <a href='DetalleProducto.aspx?id=<%#Eval("Id") %>' class="btn btn-sm btn-light">Ver detalle</a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </main>
</asp:Content>
