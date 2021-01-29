using Proyecto_Documentos.Identidades;
using Proyecto_Documentos.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Documentos.Presentacion.Principal.Documentos
{
    public partial class Consejos1 : System.Web.UI.Page
    {
        DataTable dtb;
        DataTable detalle = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Admins"] = null;
                GridView1.DataBind();
                CargarDetalle();
                Ultimo();
            }

        }
        public void CargarDetalle()
        {
            if (Session["Admins"] == null)
            {
                dtb = new DataTable("Consejo");

                dtb.Columns.Add("id", System.Type.GetType("System.String"));


                dtb.Columns.Add("cedula", System.Type.GetType("System.String"));
                Session["Admins"] = dtb;
                Session["prueba"] = dtb;
            }
            else
            {
                Session["Admins"] = Session["prueba"];
            }


        }
        private void Ultimo()
        {
            Consejo_Logica cnper = new Consejo_Logica();
            List<Consejo> per = cnper.UltimoEmp();
            foreach (Consejo ma in per)
            {
                int codigo = 0;
                codigo = Convert.ToInt32(ma.id);
                codigo = codigo + 1;
                ma.id = codigo;

                TextBox1.Text = ma.id.ToString();
            }
        }
        public int AgregarItem(int numLocal, string cedula)
        {
            int aviso = -1;
            try
            {
                detalle = (DataTable)Session["Admins"];
                detalle.Columns[0].Unique = true;
                DataRow fila = detalle.NewRow();

                fila[0] = numLocal;
                fila[1] = cedula;

                detalle.Rows.Add(fila);
                Session["Admins"] = detalle;
                aviso = 1;
            }
            catch (ConstraintException)
            {

            }

            return aviso;

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)Session["Admins"];
            dt1.Rows[index].Delete();
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            Session["Admins"] = dt1;
        }
        public void guardar()
        {
            if (
              GridView1.Rows.Count < 1
              )
            {
                lblAgregado.Text = "Campos Incompletos";
            }
            else
            {
                Consejo_Logica consejonegocio = new Consejo_Logica();
                Consejo consejo = new Consejo();
                consejo.id = Convert.ToInt32(TextBox1.Text);
                consejonegocio.Insertar(consejo);
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Consejo_Miembros_Logica consejodetalle = new Consejo_Miembros_Logica();
                    Consejo_Miembros feriadetalle = new Consejo_Miembros();
                    feriadetalle.idConsejo = Convert.ToInt32(TextBox1.Text);
                    feriadetalle.idmiembros = Convert.ToInt32(row.Cells[1].Text);
                    consejodetalle.Insertar(feriadetalle);
                }

                lblAgregado.Text = "Consejo Ingresado Correctamente";


            }
        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {

            int aviso = AgregarItem(Convert.ToInt32(DropDownList_Miembros.SelectedValue), DropDownList_Miembros.SelectedItem.Text);
            if (aviso == -1)
            {
                lblAgregado.Text = "Miembro ya en lista";
            }
            else
            {
                lblAgregado.Text = "Miembro Agregado";
            }
            GridView1.DataSource = Session["Admins"];
            GridView1.DataBind();
        }

        protected void btnActa_Click(object sender, EventArgs e)
        {
            guardar();
           // string codigo = TextBox1.Text;
           // Response.Redirect("Actas.aspx?consejo=" + codigo);
        }
    }
}