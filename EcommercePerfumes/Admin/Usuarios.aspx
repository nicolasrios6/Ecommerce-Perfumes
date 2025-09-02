<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="EcommercePerfumes.Admin.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Gestión de Usuarios</h2>
    <div class="mb-3">
        <a href="#" class="btn btn-primary">Agregar Usuario</a>
        <a href="Dashboard.aspx" class="btn btn-secondary">Volver</a>
    </div>

    <asp:GridView runat="server" ID="gvUsuarios" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table" OnRowCommand="gvUsuarios_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <%--<asp:LinkButton ID="btnToggleActivo" runat="server" CommandName="ToggleActivo"
                        OnClientClick="return confirm('¿Estás seguro de cambiar el estado del usuario?');"
                        CommandArgument='<%#Eval("Id") %>' Text='<%#(bool)Eval("Activo") ? "Inactivar" : "Activar" %>'
                        CssClass="btn btn-sm btn-warning">
                    </asp:LinkButton>--%>
                    <asp:LinkButton ID="btnMostrarModal" runat="server" CssClass="btn btn-sm btn-warning"
                        OnClientClick='<%# string.Format("mostrarModalConfirmacion({0}, \"{1}\", \"{2}\", {3}); return false;",
                            Eval("Id"), Eval("Nombre"), Eval("Apellido"), Eval("Activo").ToString().ToLower()) %>'
                        Text='<%# (bool)Eval("Activo") ? "Inactivar" : "Activar" %>'>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:HiddenField ID="hdnIdUsuario" runat="server" />
    <div class="modal fade" id="modalConfirmacion" tabindex="-1" aria-labelledby="modalConfirmacionLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitulo">Acción</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                </div>
                <div class="modal-body">
                    ¿Estás seguro que querés <span id="accionTexto">realizar esta acción</span> al usuario <strong id="nombreCompletoUsuario"></strong>?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:LinkButton ID="btnConfirmarInactivar" runat="server" CssClass="btn btn-primary" OnClick="btnConfirmarInactivar_Click">
                    Confirmar
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function mostrarModalConfirmacion(idUsuario, nombre, apellido, activo) {
            document.getElementById('<%= hdnIdUsuario.ClientID%>').value = idUsuario;

            const nombreCompleto = `${nombre} ${apellido}`;
            const accion = activo ? "inactivar" : "activar";
            const accionCapitalizada = accion.charAt(0).toUpperCase() + accion.slice(1);

            document.getElementById("modalTitulo").innerText = accionCapitalizada;
            document.getElementById("accionTexto").innerText = accion;
            document.getElementById("nombreCompletoUsuario").innerText = nombreCompleto;

            var modal = new bootstrap.Modal(document.getElementById('modalConfirmacion'));
            modal.show();
        }
    </script>
</asp:Content>
