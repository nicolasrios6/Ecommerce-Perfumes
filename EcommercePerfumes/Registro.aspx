<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="EcommercePerfumes.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-6">

            <h2>Registro de usuario</h2>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtContrasenia" class="form-label">Contraseña</label>
                <div class="d-flex">
                    <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <button type="button" class="btn" onclick="togglePassword()"><i class="fas fa-eye"></i></button>
                </div>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnRegistro" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistro_Click" />
            </div>
            <div class="d-flex flex-column">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                <a href="Login.aspx">¿Ya tenes cuenta? Inicia Sesión!</a>
            </div>
        </div>
    </div>

    <script>
        function togglePassword() {
            var input = document.getElementById("<%= txtContrasenia.ClientID %>");
            if (input.type === "password") {
                input.type = "text";
            } else {
                input.type = "password";
            }
        }
    </script>
</asp:Content>
