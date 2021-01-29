<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/Principal/Inicio/Administracion.Master" AutoEventWireup="true" CodeBehind="AsignacionCalificadores.aspx.cs" Inherits="Proyecto_Documentos.Presentacion.Principal.Documentos.AsignacionCalificadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
      <asp:Table runat="server" Height="16px" Width="913px">
        <%--Enacabezado--%>
        <asp:TableRow>
            <asp:TableCell Width="20%"></asp:TableCell>
            <asp:TableCell Width="60%" HorizontalAlign="Center">
                <asp:Label runat="server" Text="Asignación de Calificaodres" Font-Size="X-Large"></asp:Label>
            </asp:TableCell>
            <asp:TableCell Width="20%"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <hr/>
   <asp:Table runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lbControl" Text="" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
        <asp:Table ID="Table1" runat="server" Height="261px" Width="921px" style="margin-bottom: 0px">
            <%--Primera Fila--%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                    <asp:Label runat="server" Text="Encabezado de resolucion"  ForeColor="#333333" Font-Underline="true" Font-Size="15px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="10%" HorizontalAlign="Right">
                    <asp:Label ID="lbFecha" runat="server" Text="Fecha: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="15%">
                    <asp:TextBox ID="txtFecha" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="Calendar1" runat="server" TargetControlID="txtFecha" Format="d '\de' MMMM '\de' yyyy"></ajaxToolkit:CalendarExtender>
                </asp:TableCell>
                <asp:TableCell Width="10%" HorizontalAlign="Right">
                    <asp:Label ID="lbResolucion" runat="server" Text="N° Resolución: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="15%">
                    <asp:TextBox ID="txtNResolucion" runat="server" Width="20%" MaxLength="4" AutoCompleteType="Disabled" onkeypress="ValidaSoloNumeros()" placeholder="0000"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="10%">
                </asp:TableCell>
                <asp:TableCell Width="15%">
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6"></asp:TableCell>
            </asp:TableRow>
            <%--Tabla Datos--%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6" HorizontalAlign="Left">
                    <asp:Label runat="server" Text="Contenido Parrafo" ForeColor="#333333" Font-Underline="true" Font-Size="15px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" Width="10%">
                    <asp:Label runat="server" Text="Sesión: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="15%">
                    <asp:DropDownList ID="ddlSesion" runat="server"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" Width="10%">
                </asp:TableCell>
                <asp:TableCell Width="15%">
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" Width="10%">
                </asp:TableCell>
                <asp:TableCell Width="15%">
                </asp:TableCell>
            </asp:TableRow>
            
            <%--Segunda Fila--%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label runat="server">Fecha Sesión: </asp:Label>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="txtFechaSesion" runat="server" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarSesion" runat="server" TargetControlID="txtFechaSesion" Format="dddd d '\de' MMMM '\de' yyyy"></ajaxToolkit:CalendarExtender>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label runat="server">Fecha Solicitud: </asp:Label>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:TextBox ID="txtFechaMemorando" runat="server" Width="100%" AutoCompleteType="Disabled"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaMemorando" Format="dddd d '\de' MMMM '\de' yyyy"></ajaxToolkit:CalendarExtender>
                </asp:TableCell>
            </asp:TableRow>
            <%--Tercera Fila--%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label runat="server" Text="T. Titulacion: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="4">
                    <asp:TextBox runat="server" ID="txtTema" TextMode="MultiLine" Width="75%"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <%--Cuarta Fila--%>
            <%--Tabla Estudiante--%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6" HorizontalAlign="Left">
                    <asp:Label runat="server" Text="Datos Estudiante" ForeColor="#333333" Font-Underline="true" Font-Size="15px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow >
                <asp:TableCell HorizontalAlign="Right" Width="10%">
                    <asp:Label runat="server" Text="CI Estudiante: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="15%">
                    <asp:TextBox ID="txtcedulaBuscar" runat="server" MaxLength="10" AutoCompleteType="Disabled" onkeypress="ValidaSoloNumeros()"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="10%">
                    <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/Images/estudiante.png" Height="20px" OnClick="btnBuscar_Click"/>
                </asp:TableCell>
                <asp:TableCell Width="15%">
                    <asp:Label runat="server" ID="lbestudiante" ForeColor="Red" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="10%">
                </asp:TableCell>
                <asp:TableCell Width="15%">
                </asp:TableCell>
            </asp:TableRow>
            <%--Segunda Fila--%>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label runat="server" Text="Apellidos"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtApellidos" runat="server" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label runat="server" Text="Nombres:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TxtNombres" runat="server" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell ColumnSpan="6">
                    <asp:TextBox runat="server" ID="txtCarreraEstudiante" visible="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <%--Tabla Firma--%>       
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6" HorizontalAlign="Left">
                    <asp:Label runat="server" Text="Firma" ForeColor="#333333" Font-Underline="true" Font-Size="15px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right" Width="10%">
                    <asp:Label runat="server" Text="Atentamente: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="15%">
                    <asp:TextBox id="txtAtentamente" runat="server" Enabled="false"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right" Width="10%">
                    <asp:Label runat="server" Text="Como: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="15%">
                    <asp:TextBox ID="txtCargoMiembro" runat="server" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell Width="10%">
                </asp:TableCell>
                <asp:TableCell Width="15%">
                </asp:TableCell>
            </asp:TableRow>
            <%--boton--%>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="6"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="5"></asp:TableCell>
                <asp:TableCell HorizontalAlign="Left">
                    <asp:Button id="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" BackColor="#4E5766" BorderColor="#4E667D" BorderStyle="Solid" BorderWidth="1px" ForeColor="#DDE4EC" Height="30px"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
</asp:Content>
