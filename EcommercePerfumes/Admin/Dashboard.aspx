<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EcommercePerfumes.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h2>Panel de admin.</h2>
    <a href="Productos.aspx" class="btn btn-primary">Gestionar Productos</a>
    <a href="Marcas.aspx" class="btn btn-primary">Gestionar Marcas</a>
    <a href="Pedidos.aspx" class="btn btn-primary">Gestionar Pedidos</a>
    <a href="Usuarios.aspx" class="btn btn-primary">Gestionar Usuarios</a>--%>

    <h2 class="mb-4">Panel de Administración</h2>

    <div class="row text-center mb-4">
        <div class="col-md-3">
            <div class="bg-light p-3 rounded shadow-sm">
                <h4 id="cantidadProductos" runat="server"></h4>
                <small>Productos</small>
            </div>
        </div>
        <div class="col-md-3">
            <div class="bg-light p-3 rounded shadow-sm">
                <h4 id="cantidadMarcas" runat="server"></h4>
                <small>Marcas</small>
            </div>
        </div>
        <div class="col-md-3">
            <div class="bg-light p-3 rounded shadow-sm">
                <h4 id="cantidadPedidos" runat="server"></h4>
                <small>Pedidos pendientes</small>
            </div>
        </div>
        <div class="col-md-3">
            <div class="bg-light p-3 rounded shadow-sm">
                <h4 id="cantidadUsuarios" runat="server"></h4>
                <small>Usuarios</small>
            </div>
        </div>
    </div>

    <div class="row g-4">
        <div class="col-md-3">
            <div class="card shadow-sm h-100">
                <div class="card-body d-flex flex-column justify-content-between">
                    <h5 class="card-title"><i class="fas fa-box"></i> Productos</h5>
                    <p class="card-text text-muted">Administra el catálogo de productos, agrega o modifica perfumes.</p>
                    <a href="Productos.aspx" class="btn btn-primary mt-2">Gestionar</a>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card shadow-sm h-100">
                <div class="card-body d-flex flex-column justify-content-between">
                    <h5 class="card-title"><i class="fas fa-tags"></i> Marcas</h5>
                    <p class="card-text text-muted">Gestiona las marcas disponibles para los productos.</p>
                    <a href="Marcas.aspx" class="btn btn-primary mt-2">Gestionar</a>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card shadow-sm h-100">
                <div class="card-body d-flex flex-column justify-content-between">
                    <h5 class="card-title"><i class="fas fa-shopping-cart"></i> Pedidos</h5>
                    <p class="card-text text-muted">Revisa y gestiona los pedidos realizados por los clientes.</p>
                    <a href="Pedidos.aspx" class="btn btn-primary mt-2">Gestionar</a>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card shadow-sm h-100">
                <div class="card-body d-flex flex-column justify-content-between">
                    <h5 class="card-title"><i class="fas fa-users"></i> Usuarios</h5>
                    <p class="card-text text-muted">Administra las cuentas de clientes.</p>
                    <a href="Usuarios.aspx" class="btn btn-primary mt-2">Gestionar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
