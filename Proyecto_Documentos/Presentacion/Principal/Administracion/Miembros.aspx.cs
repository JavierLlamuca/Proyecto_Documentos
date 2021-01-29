using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Entidades;
using Proyecto_Documentos.Logica;

namespace Proyecto_Documentos.Presentacion.Administracion.Autentificacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public Miembros_Logica log = new Miembros_Logica();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnInsertar.Enabled = false;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
            TextBox_apellido.Enabled = false;
            TextBox_nombre.Enabled = false;
            TextBox_cedula.Enabled = false;
            TextBox_titulo.Enabled = false;
            TextBox_cargo.Enabled = false;
            TextBox_idd.Enabled = false;
        }
        public void limpiar()
        {
            TextBox_apellido.Text = "";
            TextBox_nombre.Text = "";
            TextBox_cedula.Text = "";
            TextBox_titulo.Text = "";
            TextBox_cargo.Text = "";
            TextBox_idd.Text = "";
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

            if (TextBox_cedula.Text != "" && TextBox_nombre.Text != "" && TextBox_apellido.Text != "" && TextBox_cargo.Text != "" && TextBox_titulo.Text != "")
            {
                Miembro m = new Miembro
                {
                    cedula = TextBox_cedula.Text,
                    nombre = TextBox_nombre.Text,
                    apellido = TextBox_apellido.Text,
                    titulo = TextBox_titulo.Text,
                    cargo = TextBox_cargo.Text
                };
                //
                if (log.InsertMiembro(m) > 0)
                {
                    limpiar();
                    Label1.Text = "Se ingreso el miembro con exito";
                    GridView1.DataBind();
                    btnEliminar.Enabled = false;
                    btnActualizar.Enabled = false;
                    btnInsertar.Enabled = false;
                    btnNuevo.Enabled = true;
                }
                else
                {
                    Label1.Text = "Ya se encuentra un miembro con la misma CI";
                    limpiar();
                }
            }
            else
            {
                Label1.Text = "Datos Incompletos";
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Miembro m = new Miembro
            {
                id = Convert.ToInt32(TextBox_idd.Text),
                cedula = TextBox_cedula.Text,
                nombre = TextBox_nombre.Text,
                apellido = TextBox_apellido.Text,
                titulo = TextBox_titulo.Text,
                cargo = TextBox_cargo.Text
            };
            if (log.UpdateMiembro(m) > 0)
            {
                Label1.Text = "Registro Actualizado correctamente";
                limpiar();
                GridView1.DataBind();
            }
            else
            {
                Label1.Text = "Error al actualizar el registro";
            }
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Miembro m = new Miembro
            {
                cedula = TextBox_cedula.Text,
                nombre = TextBox_nombre.Text,
                apellido = TextBox_apellido.Text,
                titulo = TextBox_titulo.Text,
                cargo = TextBox_cargo.Text
            };
            int x = log.DeleteMiembro(m);
            if (x == 1)
            {
                Label1.Text = "Registro Eliminado correctamente";
                GridView1.DataBind();
                limpiar();
            }
            else
            {
                if (x != 1)
                {
                    Label1.Text = "No puede eliminar el registro seleccionado";
                }
            }
        }

        //public int idauxiliar;
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[rowIndex];
            TextBox_idd.Text = row.Cells[1].Text;
            TextBox_cedula.Text = row.Cells[2].Text;
            TextBox_nombre.Text = Server.HtmlDecode(row.Cells[3].Text);
            TextBox_apellido.Text = Server.HtmlDecode(row.Cells[4].Text);
            TextBox_titulo.Text = Server.HtmlDecode(row.Cells[5].Text);
            TextBox_cargo.Text = Server.HtmlDecode(row.Cells[6].Text);
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnInsertar.Enabled = false;
            btnNuevo.Enabled = true;
            TextBox_apellido.Enabled = true;
            TextBox_nombre.Enabled = true;
            TextBox_cedula.Enabled = true;
            TextBox_titulo.Enabled = true;
            TextBox_cargo.Enabled = true;
            //idauxiliar = Convert.ToInt32(row.Cells[1].Text);

        }

        protected void TextBox_buscar_TextChanged(object sender, EventArgs e)
        {
            busca();
        }
        public void busca()
        {
            SqlDataSource1.SelectCommand = @"SELECT [id]
                     ,[cedula]
      ,[nombre]
      ,[apellido]
      ,[titulo]
      ,[cargo] FROM [Miembros] WHERE cedula LIKE '%" + TextBox_buscar.Text + "%' or nombre LIKE '%" + TextBox_buscar.Text + "%' or apellido LIKE '%" + TextBox_buscar.Text + "%'";
            SqlDataSource1.DataBind();


        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            TextBox_apellido.Enabled = true;
            TextBox_nombre.Enabled = true;
            TextBox_cedula.Enabled = true;
            TextBox_titulo.Enabled = true;
            TextBox_cargo.Enabled = true;
            btnInsertar.Enabled = true;
            btnNuevo.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }
    }
}