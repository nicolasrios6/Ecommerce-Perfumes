<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioMarca.aspx.cs" Inherits="EcommercePerfumes.Admin.FormularioMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ps-3">Formulario Marca</h2>

    <div class="row p-3">
        <div class="col-6">
            <div class="form-group mb-3">
                <label class="form-label" for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" EnableViewState="false" />
                <asp:RequiredFieldValidator
                    ID="rfvNombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="El Nombre es obligatorio."
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
            <div class="form-group mb-3">
                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" Text="Activo" />
            </div>
            <div class="d-flex">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary me-2" OnClick="btnGuardar_Click" />
                <a href="Marcas.aspx" class="btn btn-secondary">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
