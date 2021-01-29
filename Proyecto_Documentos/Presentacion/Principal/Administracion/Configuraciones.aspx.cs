using Proyecto_Documentos.Identidades;
using Proyecto_Documentos.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Documentos.Presentacion.Principal.Autentificacion
{
    public partial class Configuraciones : System.Web.UI.Page
    {
        ConfiguracionLogica conf = new ConfiguracionLogica();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[rowIndex];
            txtID.Text = row.Cells[1].Text;
            txtCargo.Text = Server.HtmlDecode(row.Cells[2].Text);
            txtPersona.Text = Server.HtmlDecode(row.Cells[3].Text);
            btnActulaizar.Enabled = true;
        }

        protected void btnActulaizar_Click(object sender, EventArgs e)
        {
            Actualizar();      
        }

        private void Actualizar()
        {
            if (txtCargo.Text.Equals("") || txtPersona.Text.Equals(""))
            {
                txtMensaje.Text = "Llene los campos";
            }
            else {
                Configuracion c = new Configuracion();
                c.cargo = txtCargo.Text;
                c.persona = txtPersona.Text;
                int id = Convert.ToInt32(txtID.Text);
                btnActulaizar.Enabled = false;
                txtMensaje.Text = conf.ActualizarConfiguracion(c,id);
                txtCargo.Text = "";
                txtID.Text = "";
                txtPersona.Text = "";
                GridView1.DataBind();
            }
            
        }
    }
}