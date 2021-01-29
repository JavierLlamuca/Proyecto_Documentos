using Proyecto_Documentos.Logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Documentos.Presentacion.Principal.Documentos
{
    public partial class Correos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void enviar()
        {
            Correo_Logica correo = new Correo_Logica();
          
            string filename = Path.GetFileName(FileUpload_Adjuntar.FileName);
            FileUpload_Adjuntar.SaveAs(Server.MapPath("~/") + filename);
            
            string path = Server.MapPath("~/") + filename;


            correo.enviarCorreo(TextBox_De.Text, TextBox_Cuerpo.Text, TextBox_Asunto.Text, TextBox_Para.Text, path);

        }

        protected void Button_Enviar_Click(object sender, EventArgs e)
        {
            if (TextBox_Asunto.Text.Equals("") || string.IsNullOrWhiteSpace(TextBox_Cuerpo.Text)|| TextBox_De.Text.Equals("") ||
                TextBox_Para.Text.Equals("") || !FileUpload_Adjuntar.HasFile)
            {
                lbControl.Text = "Llene los campos por favor";
            }
            else {
                enviar();
                lbControl.Text = "Correo Enviado con Exito";
            }
            
        }

        
    }
}