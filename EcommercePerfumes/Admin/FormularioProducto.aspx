<%@ Page Title="Formulario de Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="EcommercePerfumes.Admin.FormularioProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="ps-3">Formulario Producto</h2>

    <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger w-50 d-block" EnableViewState="false" />

    <div class="row p-3">
        <div class="col-12 col-md-6">
            <div class="form-group mb-3">
                <label class="form-label" for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtDescripcion">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtNombre">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtStock">Stock</label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="ddlMarca">Marca</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:LinkButton ID="btnNuevaMarca" CssClass="btn btn-link p-0" Text="Agregar Marca" runat="server" OnClick="btnNuevaMarca_Click" />
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtGenero">Género</label>
                <asp:TextBox ID="txtGenero" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtConcentracion">Concentración</label>
                <asp:TextBox ID="txtConcentracion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtMililitros">Mililitros</label>
                <asp:TextBox ID="txtMililitros" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="form-label" for="txtNotas">Notas</label>
                <asp:TextBox ID="txtNotas" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" Text="Activo" />
            </div>

        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-group mb-3">
                        <label class="form-label" for="txtImagenUrl">Url de Imágen</label>
                        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged"></asp:TextBox>
                    </div>
                    <asp:Image ID="imgProducto" runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="mt-3">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <a href="Productos.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>
