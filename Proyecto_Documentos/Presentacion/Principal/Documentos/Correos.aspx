<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Inicio/Administracion.Master" AutoEventWireup="true" CodeBehind="Correos.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Principal.Documentos.Correos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 60px;
        }
        .auto-style2 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%">
         <tr>
            <td class="auto-style1">
                
            </td>
                <td >
                <asp:Label ID="lbControl" runat="server" Text=""  Font-Bold="True" Font-Size="Small" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Text="De: "></asp:Label>
            </td>
               <td>
                   <asp:TextBox ID="TextBox_De" runat="server" Height="16px" Width="250px" Enabled="False" TextMode="Email" Text="juanitocaisapanta@gmail.com"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td class="auto-style1">
               <asp:Label ID="Label2" runat="server" Text="Para: " ></asp:Label>
            </td>
               <td>
                   <asp:TextBox ID="TextBox_Para" runat="server" Height="16px" Width="250px" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td class="auto-style1">
                 <asp:Label ID="Label3" runat="server" Text="Asunto: "></asp:Label>
            </td>
               <td>
                   <asp:TextBox ID="TextBox_Asunto" runat="server" Height="16px" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
             <td class="auto-style1">
                 <asp:Label ID="Label4" runat="server" Text="Adjuntar"></asp:Label>
            </td>
               <td>
                   <asp:FileUpload ID="FileUpload_Adjuntar" runat="server" Height="100%" Width="100%"/>
            </td>
        </tr>
        <tr>
             <td colspan="2" >
                 <asp:TextBox ID="TextBox_Cuerpo" runat="server" TextMode="MultiLine" Height="100%" Width="100%"></asp:TextBox>
            </td>
              
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button_Enviar" runat="server" Text="enviar" OnClick="Button_Enviar_Click" />
            </td>
            
        </tr>
    </table>
</asp:Content>