<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Inicio/Administracion.Master" AutoEventWireup="true" CodeBehind="Miembros.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Administracion.Autentificacion.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 354px;
        }
    </style>
    <style>
        .modalBackround2 {
            background-color: black;
            filter: alpha(opacity=0.9) !important;
            opacity: 0.6 !important;
            z-index: 20;
        }

        .modalPopup2 {
            padding: 20px 0px 24px 10px;
            position: relative;
            width: 450px;
            height: 66px;
            background-color: white;
            border: 1px solid black;
        }
    </style>
    <script>
        function txNombres() {
            if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
                event.returnValue = false;
        }
        function ValidaSoloNumeros() {
            if ((event.keyCode < 48) || (event.keyCode > 57))
                event.returnValue = false;
        }
        function minmax(value, min, max) {
            if (parseInt(value) < min || isNaN(parseInt(value)))
                return min;
            else if (parseInt(value) > max)
                return max;
            else return value;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td align="center" colspan="4">
                <h1>Miembros</h1>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Cedula: "></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox_cedula" runat="server" onkeypress="ValidaSoloNumeros()"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox ID="TextBox_idd" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nombre: "></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox_nombre" runat="server" Width="150px" onkeypress="txNombres()"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Título: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox_titulo" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Apellido: "></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="TextBox_apellido" runat="server" Width="150px" onkeypress="txNombres()"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Cargo: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox_cargo" runat="server" Width="245px" Height="46px" TextMode="MultiLine" onkeypress="txNombres()"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px" OnClick="btnLimpiar_Click" />
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="Unnamed1_Click" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px" />

                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="Unnamed2_Click" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="Unnamed3_Click" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px" />

                <hr />
                <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" DisplayModalPopupID="ModalPopupExtender1" TargetControlID="btnEliminar" ConfirmText="" />
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="btnNo" OkControlID="btnYes" PopupControlID="Panel3" TargetControlID="btnEliminar" BackgroundCssClass="modalBackround2"></ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup2">
                    <div>
                        <center>
                        <h1>¿Esta seguro de guardar?</h1>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnYes" runat="server" Text="Aceptar"  BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px"/>
                                </td>
                                <td>

                                </td>
                                <td>

                                </td>
                                <td>
                                      <asp:Button ID="btnNo" runat="server" Text="Cancelar"  BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px"/>
                                </td>
                            </tr>
                        </table>
                         
                      
                    </center>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Buscar: "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox_buscar" runat="server" placeholder="Ingrese Cedula o Nombre o Apellido" AutoPostBack="true" OnTextChanged="TextBox_buscar_TextChanged"></asp:TextBox>
            </td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <hr />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" DataKeyNames="id" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Width="100%" EmptyDataText="Sin Profesores">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="cedula" HeaderText="cedula" SortExpression="cedula" />
                        <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                        <asp:BoundField DataField="apellido" HeaderText="apellido" SortExpression="apellido" />
                        <asp:BoundField DataField="titulo" HeaderText="titulo" SortExpression="titulo" />
                        <asp:BoundField DataField="cargo" HeaderText="cargo" SortExpression="cargo" />
                    </Columns>
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_DocumentosConnectionString %>" SelectCommand="SELECT * FROM [Miembros]"></asp:SqlDataSource>
                <hr />
            </td>
        </tr>

    </table>

</asp:Content>