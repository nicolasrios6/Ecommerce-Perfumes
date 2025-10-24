<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="EcommercePerfumes.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Checkout</h2>

    <asp:UpdatePanel runat="server" ID="upCheckout">
        <ContentTemplate>
            <asp:ValidationSummary ID="valSummary" runat="server" CssClass="alert alert-danger"
                DisplayMode="BulletList" ShowSummary="true" />
            <div class="row">
                <div class="col-12 col-md-7">
                    <div class="card mb-4">
                        <div class="card-header bg-dark text-white">Datos de contacto</div>
                        <div class="card-body">
                            <div class="mb-3">
                                <label>Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label>Apellido</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                            </div>
                            <div class="mb-3">
                                <label>Teléfono</label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label>Dirección</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="La dirección es obligatoria para envío a domicilio"
                                    ControlToValidate="txtDireccion" CssClass="text-danger" Display="Dynamic" Enabled="false" />
                            </div>
                            <div class="mb-3">
                                <label>Observaciones (opcional)</label>
                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                            </div>
                        </div>
                    </div>

                    <div class="card mb-4">
                        <div class="card-header bg-dark text-white">Método de envío</div>
                        <div class="card-body">
                            <asp:RadioButtonList ID="rblEnvio" runat="server" CssClass="form-check" RepeatDirection="Vertical" OnSelectedIndexChanged="rblEnvio_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Envío a domicilio ($8000)" Value="Envio" />
                                <asp:ListItem Text="Retiro en local (Gratis)" Value="Retiro" />
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="card mb-4">
                        <div class="card-header bg-dark text-white">Método de pago</div>
                        <div class="card-body">
                            <%--OnSelectedIndexChanged="rblPago_SelectedIndexChanged"--%>
                            <asp:RadioButtonList ID="rblPago" runat="server" CssClass="form-check" RepeatDirection="Vertical"  >
                                <asp:ListItem Text="Transferencia bancaria" Value="Transferencia" />
                                <asp:ListItem Text="Efectivo" Value="Efectivo" />
                            </asp:RadioButtonList>
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <div class="mb-3">
                                    <h5>Datos para transferencia:</h5>
                                    <p><strong>ALIAS: </strong>NICOLASRIOS.NX</p>
                                    <p><strong>CBU: </strong>123123123123123</p>
                                    <p><strong>Cuenta: </strong>Nicolas Rios - Naranja X</p>
                                </div>

                                <div class="mb-3">
                                    <label>Adjuntar comprobante:</label>
                                    <asp:FileUpload ID="fuComprobante" runat="server" CssClass="form-control w-100" />
                                    <small id="nombreArchivo" class="text-success d-block mt-1"></small>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>


                </div>

                <div class="col-12 col-md-5">
                    <div class="card">
                        <div class="card-header bg-dark text-white">Resumen del pedido</div>
                        <div class="card-body">
                            <asp:Repeater ID="repResumenCarrito" runat="server">
                                <ItemTemplate>
                                    <div class="d-flex justify-content-between align-items-center mb-2">
                                        <div>
                                            <img class="w-25" src='<%#Eval("ImagenUrl") %>' runat="server" />
                                            <span><%# Eval("Nombre") %> x<%# Eval("Cantidad") %></span>
                                        </div>
                                        <span>$<%# Eval("Subtotal", "{0:N0}") %></span>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <hr />
                            <div class="d-flex justify-content-between">
                                <strong>Subtotal</strong>
                                <asp:Label ID="lblSubtotal" runat="server" Text="$0" />
                            </div>
                            <div class="d-flex justify-content-between">
                                <strong>Envío</strong>
                                <asp:Label ID="lblEnvio" runat="server" Text="$0" />
                            </div>
                            <hr />
                            <div class="d-flex justify-content-between fs-5 fw-bold">
                                <span>Total</span>
                                <asp:Label ID="lblTotal" runat="server" Text="$0" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="text-center text-md-start mt-3">
                    <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar compra"
                        CssClass="btn btn-success btn-lg w-100 mb-4" OnClick="btnConfirmarCompra_Click" />
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnConfirmarCompra" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

            document.addEventListener("change", function (e) {
                if (e.target.id === "<%= rblPago.ClientID %>_0" || e.target.id === "<%= rblPago.ClientID %>_1") {
                    const panel = document.getElementById("<%= Panel1.ClientID %>");
                    panel.style.display = e.target.value === "Transferencia" ? "block" : "none";
                }
            });

        function configurarFileUpload() {
            const fileInput = document.getElementById("<%= fuComprobante.ClientID %>");
            const fileNameLabel = document.getElementById("nombreArchivo");

            if (fileInput && fileNameLabel) {
                fileInput.addEventListener("change", function () {
                    if (fileInput.files.length > 0) {
                        fileNameLabel.textContent = "Archivo seleccionado: " + fileInput.files[0].name;
                    } else {
                        fileNameLabel.textContent = "";
                    }
                });
            }
        }

        // Ejecutar cuando la página se cargue por primera vez
        document.addEventListener("DOMContentLoaded", configurarFileUpload);

        // Ejecutar cada vez que se actualice un UpdatePanel
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(configurarFileUpload);
    </script>
</asp:Content>
