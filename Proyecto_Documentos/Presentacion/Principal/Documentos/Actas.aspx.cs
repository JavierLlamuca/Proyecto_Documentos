using Proyecto_Documentos.Entidades;
using Proyecto_Documentos.Identidades;
using Proyecto_Documentos.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Words.NET;

namespace Proyecto_Documentos.Presentacion.Principal.Documentos
{
    public partial class Actas : System.Web.UI.Page
    {
        Miembros_Logica m = new Miembros_Logica();
        ResolucionLogica res = new ResolucionLogica();
        ConfiguracionLogica conf = new ConfiguracionLogica();


        DataTable dtb;
        DataTable detalle = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Adminss"] = null;
                GridView1.DataBind();
                CargarDetalle();
                if (Request.QueryString["consejo"] == null) return;
                TextBox_Consejo.Text = Request.QueryString["consejo"].ToString();
                CargaTiposSesion();
            }

        }

        private void CargaTiposSesion()
        {
            ddlSesion.Items.Add("Ordinaria");
            ddlSesion.Items.Add("Extraordinaria");
        }
        public void CargarDetalle()
        {
            if (Session["Adminss"] == null)
            {
                dtb = new DataTable("Resoluciones");

                dtb.Columns.Add("idActa", System.Type.GetType("System.String"));
                dtb.Columns.Add("idResolucion", System.Type.GetType("System.String"));
                Session["Adminss"] = dtb;
                Session["prueba"] = dtb;
            }
            else
            {
                Session["Adminss"] = Session["prueba"];
            }


        }

        public int AgregarItem(string idActa, string idResolucion)
        {
            int aviso = -1;
            try
            {
                detalle = (DataTable)Session["Adminss"];
                detalle.Columns[1].Unique = true;
                DataRow fila = detalle.NewRow();

                fila[0] = idActa;
                fila[1] = idResolucion;

                detalle.Rows.Add(fila);
                Session["Adminss"] = detalle;
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
            dt1 = (DataTable)Session["Adminss"];
            dt1.Rows[index].Delete();
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            Session["Adminss"] = dt1;
        }

        public void guardar()
        {
            if (TextBox_Acta.Text == "" ||
              GridView1.Rows.Count < 1
              )
            {
                lblAgregado.Text = "Campos Incompletos";
            }
            else
            {
                Acta_Logica actalogica = new Acta_Logica();
                Acta acta = new Acta();
                acta.id = TextBox_Acta.Text;
                acta.idConsejo = Convert.ToInt32(TextBox_Consejo.Text);
                actalogica.Insertar(acta);
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Acta_Detalle_Logica consejodetalle = new Acta_Detalle_Logica();
                    Acta_Detalle feriadetalle = new Acta_Detalle();
                    feriadetalle.idActa = TextBox_Acta.Text;
                    feriadetalle.idResolucion = row.Cells[2].Text;
                    consejodetalle.Insertar(feriadetalle);
                }

                lblAgregado.Text = "Consejo Ingresado Correctamente";
            }
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (TextBox_Acta.Text != "")
            {
                int aviso = AgregarItem(TextBox_Acta.Text, GridView2.SelectedRow.Cells[1].Text);
                if (aviso == -1)
                {
                    lblAgregado.Text = "Resolución ya en Lista";
                }
                else
                {
                    lblAgregado.Text = "Resolución Agregada";
                }
                GridView1.DataSource = Session["adminss"];
                GridView1.DataBind();
            }
            else
            {
                lblAgregado.Text = "Campo incompleto";
            }


        }
        protected void TextBox_BuscarCedula_TextChanged(object sender, EventArgs e)
        {
            SqlDataSource_Clientes.SelectCommand = "SELECT [id] FROM [Resoluciones] WHERE id LIKE '%" + TextBox_BuscarCedula.Text + "%'";
            SqlDataSource_Clientes.DataBind();
        }
        protected void Button_Cerrar_Click(object sender, EventArgs e)
        {
            mpe.Hide();
        }

        protected void Button_Generar_Click(object sender, EventArgs e)
        {
            guardar();
            CrearWord();
        }

        private void CrearWord()
        {
            List<Miembro> miembrosActa = new List<Miembro>();
            miembrosActa = m.GetMiembrosActa(Convert.ToInt32(TextBox_Consejo.Text));
            string consejo = "";
            Configuracion c = new Configuracion();
            c = conf.TraerPresidente();
            string preside = c.persona;
            string presideComo = c.cargo.ToUpper();
            
            //
            foreach (var miembro in miembrosActa)
            {
                string[] titulos = miembro.titulo.Split(' ');
                if (titulos.Length > 1)
                {
                    string aux = titulos[0] + miembro.nombre + " " + miembro.apellido + "," + titulos[1] + " " + miembro.cargo + ", ";
                    consejo = consejo + aux;
                }
                else
                {
                    string aux = titulos[0] + miembro.nombre + " " + miembro.apellido +" "+miembro.cargo+", ";
                    consejo = consejo + aux;
                }

            }
            //

            List<Resolucion> resoluciones = new List<Resolucion>();
            resoluciones = res.GetResolucionPorActa(TextBox_Acta.Text);
            string cuerpo = "";
            foreach (var resolucion in resoluciones)
            {
                cuerpo = cuerpo + "Resolución "+resolucion.id + "\n\n";
                cuerpo = cuerpo + resolucion.cuerpo+"\n\n\n";
            }

            string filename = "ACTA-"+TextBox_Acta.Text+"_2020";
            DocX document = DocX.Load(Server.MapPath("~/Plantilla/ACTA.docx"));
            //Definimos la ruta del archivo que ya se creo

            document.Bookmarks["Asistentes"].SetText(consejo);
            document.Bookmarks["Cuerpo"].Paragraph.InsertText(cuerpo);
            document.Bookmarks["ActaN"].SetText(TextBox_Acta.Text);
            document.Bookmarks["FechaN"].SetText(txtFecha.Text);
            document.Bookmarks["Preside"].SetText(preside);
            document.Bookmarks["Abogada"].SetText(txtSecretaria.Text);
            document.Bookmarks["Miembro"].SetText(preside);
            document.Bookmarks["Secretaria"].SetText(txtSecretaria.Text);
            document.Bookmarks["Secretaria2"].SetText(txtSecretaria.Text);
            document.Bookmarks["CargoMiembro"].SetText(presideComo);
            document.Bookmarks["TipoSesion"].SetText(ddlSesion.SelectedValue);
            document.Bookmarks["TipoSesion1"].SetText(ddlSesion.SelectedValue.ToUpper());
            document.Bookmarks["Acta"].SetText(TextBox_Acta.Text);
            document.Bookmarks["Fecha"].SetText(txtFecha.Text);


            //Saco el nombre del archivo
            document.SaveAs(Server.MapPath("~/Plantilla/Auxiliar.docx"));

            ///
            using (FileStream fileStream = File.OpenRead(Server.MapPath("~/Plantilla/Auxiliar.docx")))
            {
                MemoryStream memStream = new MemoryStream();
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename + ".docx");
                Response.BinaryWrite(memStream.ToArray());
                Response.Flush();
                Response.Write("<script type='text/javascript'> setTimeout('location.reload(true); ', 0);</script>");
                Response.Close();
                Response.End();
            }
        }
    }
}