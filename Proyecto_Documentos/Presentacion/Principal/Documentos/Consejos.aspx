<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Inicio/Administracion.Master" AutoEventWireup="true" CodeBehind="Consejos.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Principal.Documentos.Consejos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td align="center" colspan="2">
                <h1>Consejo</h1>
                   <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Enabled="false"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblAgregado" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Integrante:"></asp:Label>
                <asp:DropDownList ID="DropDownList_Miembros" runat="server" DataSourceID="SqlDataSource1" DataTextField="Descripcion" DataValueField="id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_DocumentosConnectionString %>" SelectCommand="SELECT id, cedula + ' ' + nombre + ' ' + apellido + ' ' + titulo + ' ' + cargo AS Descripcion FROM Miembros"></asp:SqlDataSource>
              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                 <asp:Button ID="btnagregar" runat="server" Text="Agregar" OnClick="btnagregar_Click" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px"/>
                   <hr />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" align="center" colspan="2">
                <label>Lista de Miembros</label>
                <br />
         
                <asp:GridView ID="GridView1" runat="server" AllowPaging="false" AutoGenerateColumns="False" Width="100%" OnRowDeleting="GridView1_RowDeleting"  CellPadding="4" ForeColor="#333333" GridLines="None" Height="100%" EmptyDataText="Sin Miembros">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Acción" />
                        <asp:BoundField DataField="id" HeaderText="id" >

                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="cedula" HeaderText="Miembros" />

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
            <hr />
            <td colspan="2" align="center">

                  <asp:Button ID="btnActa" runat="server" Text="Realizar Acta"  BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px" OnClick="btnActa_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
