<%@ Page Title="Marcas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="EcommercePerfumes.Admin.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-md-start">Gestión de Marcas</h2>
    <div class="mb-3 text-center text-md-start">
        <a href="FormularioMarca.aspx" class="btn btn-primary">Agregar Marca</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>
    <div class="row">

    <asp:Repeater runat="server" ID="repMarcas">
        <ItemTemplate>
            <div class="col-12 col-md-4 g-3 d-flex justify-content-center">

            <div class="card w-75">
                <div class="card-body text-center">
                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                    <p class="card-text"
                        style='<%# (bool)Eval("Activo") ? "color:green;": "color:red;" %>'>
                        <%# (bool)Eval("Activo") ? "Activa" : "Inactiva" %>
                    </p>
                    <a href='<%#"FormularioMarca.aspx?id=" + Eval("Id") %>' class="btn btn-primary">Modificar</a>
                </div>
            </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>

</asp:Content>
