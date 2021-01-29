<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Administracion.Formulario_web1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:Table runat="server" Height="350px" Width="935px">
    <asp:TableRow>
        <asp:TableCell width="100%" HorizontalAlign="center">
            <asp:image runat="server" ImageUrl="https://2.bp.blogspot.com/_sofFCaqBxwM/TDeaA1kViSI/AAAAAAAAAAc/RvclUSb35fs/w1200-h630-p-k-no-nu/SELLO+FISEI2008.jpg" Width="300px"/>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="center">
            <asp:Label runat="server" Text="Bienvenido al Gestor de Archivos de la FISEI" Font-Size="30px" ForeColor="Black" Font-Bold="true"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</asp:Content>
