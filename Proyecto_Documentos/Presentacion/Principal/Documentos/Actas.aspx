<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Inicio/Administracion.Master" AutoEventWireup="true" CodeBehind="Actas.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Principal.Documentos.Actas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
          .modalBackround {
            background-color: black;
            filter: alpha(opacity=0.9) !important;
            opacity: 0.6 !important;
            z-index: 20;
        }
          .auto-style8 {
            padding: 20px 0px 24px 10px;
            position: relative;
            width: 450px;
            height: 296px;
            background-color: white;
            border: 1px solid black;
            left: 0px;
            top: 0px;
        }

        .auto-style9 {
            width: 151px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width:100%">
        <tr>
            <td class="auto-style9" >
               
                <asp:Label ID="Label1" runat="server" Text="Nº Acta:"></asp:Label>
                
            </td>
            <td>
                 <asp:TextBox ID="TextBox_Acta" runat="server" MaxLength="3" onkeypress="ValidaSoloNumeros()" placeholder="000"></asp:TextBox>
            </td>
            <td>
                   <asp:Label ID="Label2" runat="server" Text="Nº Consejo:"></asp:Label>
            </td>
            <td>
                 <asp:TextBox ID="TextBox_Consejo" runat="server" Enabled="false"></asp:TextBox>
        
            </td>
        </tr>
                <tr>
            <td class="auto-style9" >
               
                <asp:Label ID="Label3" runat="server" Text="Fecha"></asp:Label>
                
            </td>
            <td>
                 <asp:TextBox ID="txtFecha" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="Calendar1" runat="server" TargetControlID="txtFecha" Format="d/MM/yyyy"></ajaxToolkit:CalendarExtender>
            </td>
            <td>
                   <asp:Label ID="Label4" runat="server" Text="Secretaria de Facultad:"></asp:Label>
            </td>
            <td>
                 <asp:TextBox ID="txtSecretaria" runat="server" placeholder="Ing. Fernando Alonso"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style9" >
               
                <asp:Label ID="Label5" runat="server" Text="Tipo de Sesion:"></asp:Label>
                
            </td>
            <td>
                 <asp:DropDownList  runat="server" ID="ddlSesion"></asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
                 
                
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                  <asp:Button ID="Button_Resoluciones" runat="server" Text="Ver Resoluciones" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px"/>
            </td>
            <td>

            </td>
            <td colspan="2" align="center">
                 <asp:Label ID="lblAgregado" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
              
            </td>
        </tr>
         <tr>
              <td  align="center" colspan="4">
                <label>Lista de Miembros</label>
                <br />
         
                <asp:GridView ID="GridView1" runat="server" AllowPaging="false" AutoGenerateColumns="False" Width="100%" OnRowDeleting="GridView1_RowDeleting"  CellPadding="4" ForeColor="#333333" GridLines="None" Height="100%" EmptyDataText="Sin Resoluciones">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Acción" />
                        <asp:BoundField DataField="idActa" HeaderText="Nº Acta" >

                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="idResolucion" HeaderText="Nº Resolucion" />

                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                   <hr />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                 <asp:Button ID="Button_Generar" runat="server" Text="Generar Acta" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px" OnClick="Button_Generar_Click"/>
            </td>
        </tr>
    </table>
     <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="Panel1" TargetControlID="Button_Resoluciones" BackgroundCssClass="modalBackround"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="auto-style8">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

        

        <table style="width: 100%">

            
            <tr>
                <td align="center">
                      <h1>Resoluciones</h1>
                                     
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Label ID="Label10" runat="server" Text="Codigo Resolucion: "></asp:Label>
                       <asp:TextBox ID="TextBox_BuscarCedula" runat="server" Width="86px" AutoPostBack="True"  OnTextChanged="TextBox_BuscarCedula_TextChanged"></asp:TextBox>
                                     
                </td>
            </tr>
            <tr>
                <td>

                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource_Clientes" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" PageSize="4" AllowSorting="True" Width="100%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" >
                            </asp:BoundField>
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

                    <asp:SqlDataSource ID="SqlDataSource_Clientes" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_DocumentosConnectionString %>" SelectCommand="SELECT [id] FROM [Resoluciones] where estado = 'Pendiente'   Order by [id] asc"></asp:SqlDataSource>


                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Button_Cerrar" runat="server" Text="Cerrar" OnClick="Button_Cerrar_Click"  BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px"/>
                </td>
            </tr>
        </table>

 </ContentTemplate>
          
            <Triggers>
                <asp:PostBackTrigger ControlID="GridView2"/>
            </Triggers>
          
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
