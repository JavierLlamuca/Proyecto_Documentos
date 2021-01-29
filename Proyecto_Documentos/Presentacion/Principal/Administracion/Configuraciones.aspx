<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Inicio/Administracion.Master" AutoEventWireup="true" CodeBehind="Configuraciones.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Principal.Autentificacion.Configuraciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server" Width="100%">
        <asp:TableRow >
            <asp:TableCell HorizontalAlign="Center">
                <asp:Label runat="server" Text="Configuraciones" Font-Size="14"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <hr />
    <asp:Table runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell Width="6%"></asp:TableCell>
            <asp:TableCell Width="24%">
                 <asp:TextBox runat="server" ID="txtID" Visible="false"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="6%">
            </asp:TableCell>
            <asp:TableCell Width="64%">
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="6%">
                <asp:Label runat="server" Text="Persona"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="24%">
                 <asp:TextBox runat="server" ID="txtPersona"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell Width="6%">
                <asp:Label runat="server" Text="Cargo"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="64%">
                 <asp:TextBox runat="server" ID="txtCargo" Width="60%"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="6%">
                <asp:Button ID="btnActulaizar" Text="Actualizar" runat="server" OnClick="btnActulaizar_Click" Enabled="false" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px"/>
            </asp:TableCell>
            <asp:TableCell Width="24%">
            </asp:TableCell>
            <asp:TableCell Width="6%">
            </asp:TableCell>
            <asp:TableCell Width="64%">
                <asp:Label runat="server" ID="txtMensaje" Text="" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" Width="100%">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
            <asp:BoundField DataField="cargo" HeaderText="cargo" SortExpression="cargo" />
            <asp:BoundField DataField="persona" HeaderText="persona" SortExpression="persona" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Gestion_DocumentosConnectionString %>" SelectCommand="SELECT [id], [cargo], [persona] FROM [Configuraciones]"></asp:SqlDataSource>
</asp:Content>
