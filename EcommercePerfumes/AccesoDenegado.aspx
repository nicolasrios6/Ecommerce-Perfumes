<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccesoDenegado.aspx.cs" Inherits="EcommercePerfumes.AccesoDenegado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-danger">Acceso denegado</h2>
        <p class="mt-3">No tenés permiso para acceder a esta sección.</p>
        <a href="Default.aspx" class="btn btn-primary mt-3">Ir al inicio</a>
    </div>
</asp:Content>
