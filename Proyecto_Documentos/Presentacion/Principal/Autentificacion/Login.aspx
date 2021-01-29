<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Principal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%">
                    <tr>
                        <td align="center">
                      
                            <asp:Login ID="Login1" runat="server" Font-Size="Medium" LoginButtonText="Ingresar" DestinationPageUrl="~/Presentacion/Principal/Inicio/Default_Administracion.aspx" DisplayRememberMe="False">
                                <CheckBoxStyle HorizontalAlign="Left" />
                                <LabelStyle BorderStyle="None" HorizontalAlign="Left" />
                            </asp:Login>
                               
                        </td>
                    </tr>
                </table>
</asp:Content>
