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
    public partial class Vinculacion : System.Web.UI.Page
    {
        public ResolucionLogica log = new ResolucionLogica();
        public ConfiguracionLogica conf = new ConfiguracionLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CargarComboSesion();
                CargarComboCarreras();
                TraerDatos();
            }
        }

        private void TraerDatos()
        {
            TraerPresidente();
            TraerCoordinadorVinculacion();
            TraerPresidentesVinculacion();
        }

        private void TraerPresidentesVinculacion()
        {
            List<Configuracion> lista = new List<Configuracion>();
            lista = conf.TraerPresidentesVinculacion();
            foreach (Configuracion item in lista)
            {
                ddlPresidentesVinculacion.Items.Add(item.persona);
            }

        }

        private void TraerCoordinadorVinculacion()
        {
            Configuracion c = new Configuracion();
            c = conf.TraerCoordinadorVinculacion();
            txtDocente.Text = c.persona;
        }

        private void TraerPresidente()
        {
            Configuracion c = new Configuracion();
            c = conf.TraerPresidente();
            txtAtentamente.Text = c.persona;
            txtCargoMiembro.Text = c.cargo.ToUpper();
        }


        private void CargarComboSesion()
        {
            ddlSesion.Items.Add("Ordinaria");
            ddlSesion.Items.Add("Extraordinaria");
        }

        private void CargarComboCarreras()
        {
            ddlCarreras.Items.Add("Ingeniería en Electrónica y Comunicaciones");
            ddlCarreras.Items.Add("Ingeniería Industrial en Procesos de Automatización");
            ddlCarreras.Items.Add("Ingeniería en Sistemas Computacionales e Informáticos");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposLlenos())
            {
                //Tomo los datos para guardarlos
                GenerarWord();              
            }
            else {
                lbControl.Text = "Llene todos los campos, y verifique el número de la resoción y memorando tenga 4 digitos";
            }

        }


        private void GenerarWord()
        {
            string filename = txtNResolucion.Text+"-P-CD-FISEI-UTA-2020";
            DocX document = DocX.Load(Server.MapPath("~/Plantilla/APROBACION_CARTAS_DE_COMPROMISO.docx"));

            //Definimos la ruta del archivo que ya se creo

            document.Bookmarks["Fecha"].SetText(txtFecha.Text);
            document.Bookmarks["Resolucion"].SetText(txtNResolucion.Text);
            document.Bookmarks["Coordinador_Vinculacion"].SetText(txtDocente.Text+"\n");
            document.Bookmarks["Tipo_Sesion"].SetText(ddlSesion.SelectedValue);
            document.Bookmarks["Fecha_Sesion"].SetText(txtFechaSesion.Text);
            document.Bookmarks["Memorando"].SetText(txtNMemorando.Text);
            document.Bookmarks["Fecha_Memorando"].SetText(txtFechaMemorando.Text);
            document.Bookmarks["Suscribe"].SetText(ddlPresidentesVinculacion.SelectedValue);
            document.Bookmarks["Carrera"].SetText(ddlCarreras.SelectedValue);
            document.Bookmarks["Realizadas_Con"].SetText(txtSuscritoCon.Text);
            document.Bookmarks["Cargo_Con"].SetText(txtCargoSuscritoCon.Text);
            document.Bookmarks["CI_Estudiante"].SetText(txtCedula.Text);
            document.Bookmarks["Nombre_Estudiante"].SetText(txtApellidos.Text+" "+ TxtNombres.Text);
            document.Bookmarks["Firma"].SetText(txtAtentamente.Text);
            document.Bookmarks["Miembro"].SetText(txtCargoMiembro.Text+"\n");
            //Parrafo en Mayusculas
            document.Bookmarks["Realizadas_ConM"].SetText(txtSuscritoCon.Text.ToUpper());
            document.Bookmarks["Cargo_ConM"].SetText(txtCargoSuscritoCon.Text.ToUpper());
            document.Bookmarks["CI_EstudianteM"].SetText(txtCedula.Text);
            document.Bookmarks["Nombre_EstudianteM"].SetText(txtApellidos.Text.ToUpper() + " " + TxtNombres.Text.ToUpper());
            //Letras pequeñas documento
            document.Bookmarks["Suscribe1"].SetText(ddlPresidentesVinculacion.SelectedValue);
            document.Bookmarks["Carrera1"].SetText(ddlCarreras.SelectedValue);
            //Llevar el cuerpo
            string cuerpo = document.Bookmarks["Cuerpo1"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo2"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo3"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo4"].Paragraph.Text + "\n\n";
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

        private void GuardarBaseDatos(string cuerpo,string filename)
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

        private bool CamposLlenos()
        {
            
            if (txtFecha.Text.Equals("") || txtNResolucion.Text.Length != 4 ||
                txtDocente.Text.Equals("") || txtNMemorando.Text.Length != 4 ||
                txtFechaSesion.Text.Equals("") || txtFechaMemorando.Text.Equals("") || txtSuscritoCon.Text.Equals("") ||
                txtCargoSuscritoCon.Text.Equals("") && txtCedula.Text.Equals("") ||
                txtApellidos.Text.Equals("") || TxtNombres.Text.Equals("") || txtCargoMiembro.Text.Equals(""))
            {
                return false;
            }
            else {
                return true;
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Estudiante estudiante = new Estudiante();
            estudiante = Negocio.GetEstudianteporCedula(txtcedulaBuscar.Text);
            txtApellidos.Text = estudiante.Apellidos;
            TxtNombres.Text = estudiante.Nombres;
            txtCedula.Text = estudiante.Cedula;
            if (estudiante.Nombres == null)
            {
                lbControl.Text = "Estudiante no existe";
            }
        }
    }
}