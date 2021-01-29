<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Inicio/Administracion.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Administracion.Autentificacion.Roles" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">



    <style type="text/css">
        .auto-style2 {
            width: 162px;
        }

        .auto-style3 {
            width: 526px;
        }
        
    </style>



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td colspan="3" align="center">
                <h1>Lista de Estudiantes</h1>
                         <hr />
            </td>

        </tr>
       
        <tr>

            <td align="left" class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Seleccionar Archivo Excel: "></asp:Label>


            </td>
            <td align="left" class="auto-style3">
                <asp:FileUpload ID="FileUploadExcel" runat="server" />
            </td>
            <td align="left">
                <asp:Button ID="ButtonImportarExcel" runat="server" OnClick="ButtonImportarExcel_Click" Text="Importar Datos"  BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px" />
            </td>
        </tr>

        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Buscar: "></asp:Label>

            </td>
            <td colspan="2">
                <asp:TextBox ID="TextBoxBuscar" runat="server" placeholder="BUSCAR (CEDULA NOMBRE O APELLIDO)" AutoPostBack="true" Width="300px" OnTextChanged="TextBoxBuscar_TextChanged1"></asp:TextBox>
           
                </td>
           
        </tr>

        <tr>
            <td colspan="3">
                <asp:Label ID="LabelMensaje" runat="server" Text="Label" Font-Bold="True" Font-Size="Small" ForeColor="#CC0000" Visible="False"></asp:Label>
                       
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                 <hr />
                <asp:GridView ID="GridViewEstudiantes" runat="server" CellPadding="4" OnRowDataBound="GridViewEstudiantes_RowDataBound" Width="98%" AllowPaging="True" OnPageIndexChanging="GridViewEstudiantes_PageIndexChanging" EmptyDataText="Sin Estudiantes" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
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
                         <hr />
            </td>
        </tr>
    </table>




    <script type="text/javascript">
        function RefreshUpdateDiv() {
            __doPostBack('<%= TextBoxBuscar.ClientID %>', '');
            document.getElementById('TextBoxBuscar').focus();

        };

        function comprueba() {
            return confirm("Confirme el postback");
        };




    </script>


</asp:Content>