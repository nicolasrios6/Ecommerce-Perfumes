<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="EcommercePerfumes.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Checkout</h2>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="valSummary" runat="server" CssClass="alert alert-danger"
                DisplayMode="BulletList" ShowSummary="true" />
            <div class="row">
                <%-- Formulario de datos --%>
                <div class="col-7">
                    <!-- DATOS DE CONTACTO -->
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

                    <!-- OPCIONES DE ENVÍO -->
                    <div class="card mb-4">
                        <div class="card-header bg-dark text-white">Método de envío</div>
                        <div class="card-body">
                            <asp:RadioButtonList ID="rblEnvio" runat="server" CssClass="form-check" RepeatDirection="Vertical" OnSelectedIndexChanged="rblEnvio_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Envío a domicilio ($8000)" Value="Envio" />
                                <asp:ListItem Text="Retiro en local (Gratis)" Value="Retiro" />
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <!-- MÉTODO DE PAGO -->
                    <div class="card mb-4">
                        <div class="card-header bg-dark text-white">Método de pago</div>
                        <div class="card-body">
                            <asp:RadioButtonList ID="rblPago" runat="server" CssClass="form-check" RepeatDirection="Vertical" AutoPostBack="true" OnSelectedIndexChanged="rblPago_SelectedIndexChanged">
                                <asp:ListItem Text="Transferencia bancaria" Value="Transferencia" />
                                <asp:ListItem Text="Efectivo" Value="Efectivo" />
                            </asp:RadioButtonList>
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <div class="mb-3">
                                    <h5>Datos para transferencia:</h5>
                                    <p><strong>ALIAS: </strong>NICOLASRIOS.NX</p>
                                    <p><strong>CBU: </strong>123123123123123</p>
                                    <p><strong>Cuenta: </strong>Nicolas Rios - Naranja X</p>
                                    <%--<p>Luego de realizar la transferencia, confirmá la compra con el botón de abajo y envianos el comprobante al siguiente número: <strong>2616295808</strong> indicandonos tu nombre y apellido.</p>--%>
                                </div>

                                <div class="mb-3">
                                    <label>Adjuntar comprobante:</label>
                                    <asp:FileUpload ID="fuComprobante" runat="server" CssClass="form-control w-100" />
                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                    <!-- BOTÓN CONFIRMAR -->
                    <asp:Button ID="btnConfirmarCompra" runat="server" Text="Confirmar compra"
                        CssClass="btn btn-success btn-lg w-100 mb-4" OnClick="btnConfirmarCompra_Click" />
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>

                <%-- Resumen de pedido --%>
                <div class="col-5">
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
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnConfirmarCompra" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
