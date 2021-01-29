using Proyecto_Documentos.Entidades;
using Proyecto_Documentos.Identidades;
using Proyecto_Documentos.Logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xceed.Words.NET;

namespace Proyecto_Documentos.Presentacion.Principal.Documentos
{
    public partial class Homologacion : System.Web.UI.Page
    {
        public ResolucionLogica log = new ResolucionLogica();
        public ConfiguracionLogica conf = new ConfiguracionLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            CargarCarreras();
            TraerPresidenteCAF();
            CargaTiposSesion();
            CargarCoordinadoresCarrera();
            TraerPresidente();
        }
        private void CargarCarreras()
        {
            ddlCarreras.Items.Add("Ingeniería en Electrónica y Comunicaciones");
            ddlCarreras.Items.Add("Ingeniería Industrial en Procesos de Automatización");
            ddlCarreras.Items.Add("Ingeniería en Sistemas Computacionales e Informáticos");
        }

        private void TraerPresidenteCAF()
        {
            Configuracion c = new Configuracion();
            c = conf.TraerPresidenteCAF();
            txtPresidente.Text = c.persona;
        }

        private void CargaTiposSesion()
        {
            ddlSesion.Items.Add("Ordinaria");
            ddlSesion.Items.Add("Extraordinaria");
        }
        private void TraerPresidente()
        {
            Configuracion c = new Configuracion();
            c = conf.TraerPresidente();
            txtAtentamente.Text = c.persona;
            txtCargoMiembro.Text = c.cargo.ToUpper();
        }
        private void CargarCoordinadoresCarrera()
        {
            List<Miembro> miembros = new List<Miembro>();
            Miembros_Logica log = new Miembros_Logica();
            miembros = log.GetCoordinadoresCarrera();
            foreach (var m in miembros)
            {
                string[] titulos = m.titulo.Split(' ');
                if (titulos.Length > 1)
                {
                    string aux = titulos[0] + m.nombre + " " + m.apellido + "," + titulos[1];
                    ddlCoordinadores.Items.Add(aux);
                    ddlCarrerasCoordinador.Items.Add(m.cargo);
                }
                else
                {
                    string aux = titulos[0] + m.nombre + " " + m.apellido;
                    ddlCoordinadores.Items.Add(aux);
                    ddlCarrerasCoordinador.Items.Add(m.cargo);
                }

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposLlenos())
            {
                GenerarWord();
            }
            else
            {
                lbControl.Text = "Llene todos los campos, y verifique el número de la resoción y memorando tenga 4 digitos";

            }
        }

        private void GenerarWord()
        {
            string filename = txtNResolucion.Text + "-P-CD-FISEI-UTA-2020";
            DocX document = DocX.Load(Server.MapPath("~/Plantilla/APROBACION_HOMOLOGACION_DE_ASIGNATURAS.docx"));

            //Definimos la ruta del archivo que ya se creo

            document.Bookmarks["FechaResolucion"].SetText(txtFecha.Text);
            document.Bookmarks["NResolucion"].SetText(txtNResolucion.Text);
            document.Bookmarks["CoordinadorCarrera"].SetText(ddlCoordinadores.SelectedValue);
            document.Bookmarks["CarreraCoordinador"].SetText(ddlCarrerasCoordinador.SelectedValue);

            document.Bookmarks["TipoSesion"].SetText(ddlSesion.SelectedValue);
            document.Bookmarks["FechaSesion"].SetText(txtFechaSesion.Text);
            document.Bookmarks["NAcuerdo"].SetText(txtNMemorando.Text);
            document.Bookmarks["FechaAcuerdo"].SetText(txtFechaMemorando.Text);
            document.Bookmarks["Presidente"].SetText(txtPresidente.Text);
            document.Bookmarks["CarreraHomologar"].SetText(ddlCarreras.SelectedValue);

            document.Bookmarks["Estudiante"].SetText(txtApellidos.Text + " " + TxtNombres.Text);
            document.Bookmarks["EstudianteCI"].SetText(txtCedula.Text);
            document.Bookmarks["EstudianteCarrera"].SetText(txtCarreraEstudiante.Text);
            document.Bookmarks["CarreraHomologarM"].SetText(ddlCarreras.SelectedValue.ToUpper());
            document.Bookmarks["EstudianteM"].SetText(txtApellidos.Text.ToUpper() + " " + TxtNombres.Text.ToUpper());
            document.Bookmarks["EstudianteCI2"].SetText(txtCedula.Text);
            document.Bookmarks["EstudianteCarreraM"].SetText(txtCarreraEstudiante.Text.ToUpper());
            document.Bookmarks["EstudianteM2"].SetText(txtApellidos.Text.ToUpper() + " " + TxtNombres.Text.ToUpper());
            document.Bookmarks["EstudianteCI3"].SetText(txtCedula.Text);
            document.Bookmarks["EstudianteCarreraM2"].SetText(txtCarreraEstudiante.Text.ToUpper());




            document.Bookmarks["Miembro"].SetText(txtAtentamente.Text);
            document.Bookmarks["MiembroCargo"].SetText(txtCargoMiembro.Text + "\n");
            //Llevar el cuerpo
            string cuerpo = document.Bookmarks["Cuerpo1"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo2"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo3"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo4"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo5"].Paragraph.Text + "\n\n";
            //Saco el nombre del archivo
            document.SaveAs(Server.MapPath("~/Plantilla/Auxiliar.docx"));
            GuardarBaseDatos(cuerpo, filename);

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

        private void GuardarBaseDatos(string cuerpo, string filename)
        {
            Resolucion r = new Resolucion();
            r.id = filename;
            r.cuerpo = cuerpo;
            r.idTipo = "1";
            r.estado = "Pendiente";

            if (log.InsertResolucion(r) > 0)
            {
                this.Response.Write("<script language='JavaScript'>window.alert('Ingresado Correctamente')</script>");
            }
            else
            {
                this.Response.Write("<script language='JavaScript'>window.alert('ya existe')</script>");
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Estudiante estudiante = new Estudiante();
            estudiante = Negocio.GetEstudianteporCedula(txtcedulaBuscar.Text);
            txtApellidos.Text = estudiante.Apellidos;
            TxtNombres.Text = estudiante.Nombres;
            txtCedula.Text = estudiante.Cedula;
            txtCarreraEstudiante.Text = estudiante.Carrera;
            if (estudiante.Nombres == null)
            {
                lbControl.Text = "Estudiante no existe";
            }
        }

        private bool CamposLlenos()
        {
            if (txtFecha.Text.Equals("") || txtNResolucion.Text.Length != 4 ||
                txtNMemorando.Text.Length != 4 || txtFechaSesion.Text.Equals("") || txtFechaMemorando.Text.Equals("") ||
                txtApellidos.Text.Equals("") || TxtNombres.Text.Equals("") || txtCargoMiembro.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}