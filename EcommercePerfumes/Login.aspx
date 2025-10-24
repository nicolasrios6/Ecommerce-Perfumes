<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EcommercePerfumes.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row p-3">
        <div class="col-10 col-md-12">

            <h2>Iniciar Sesión</h2>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtContrasenia" class="form-label">Contraseña</label>
                <div class="d-flex">
                    <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <button type="button" class="btn" onclick="togglePassword()"><i id="iconoPassword" class="fas fa-eye"></i></button>
                </div>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>
            <div class="d-flex flex-column">
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                <a href="Registro.aspx">¿No tenés cuenta? Registrate!</a>
            </div>
        </div>
    </div>

    <script>
        function togglePassword() {
            var input = document.getElementById("<%= txtContrasenia.ClientID %>");
            var icono = document.getElementById("iconoPassword");
            if (input.type === "password") {
                input.type = "text";
                icono.classList.remove("fa-eye");
                icono.classList.add("fa-eye-slash");
            } else {
                input.type = "password";
                icono.classList.remove("fa-eye-slash");
                icono.classList.add("fa-eye");
            }
        }
    </script>
</asp:Content>
