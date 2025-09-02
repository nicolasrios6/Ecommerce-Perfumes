<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfumes.aspx.cs" Inherits="EcommercePerfumes.Perfumes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <h2>Lista de Perfumes</h2>

        <div class="row">
            <div class="col-3">
                <div class="sticky-top" style="top: 80px">
                    <h5>Filtros</h5>
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
                                            <a href="#" class="btn btn-sm btn-light">Ver detalle</a>
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
