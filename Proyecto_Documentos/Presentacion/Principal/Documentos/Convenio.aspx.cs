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
    public partial class Convenio : System.Web.UI.Page
    {
        public ResolucionLogica log = new ResolucionLogica();
        public ConfiguracionLogica conf = new ConfiguracionLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                cargarDatos();
            }
        }

        private void cargarDatos()
        {
            TraerCoordinadorVinculacion();
            TraerPresidente();
            CargarTiposSesion();
            CargarCarreras();
        }

        private void CargarCarreras()
        {
            ddlCarreras.Items.Add("Ingeniería en Electrónica y Comunicaciones");
            ddlCarreras.Items.Add("Ingeniería Industrial en Procesos de Automatización");
            ddlCarreras.Items.Add("Ingeniería en Sistemas Computacionales e Informáticos");
        }

        private void CargarTiposSesion()
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

        private void TraerCoordinadorVinculacion()
        {
            Configuracion c = new Configuracion();
            c = conf.TraerCoordinadorVinculacion();
            txtDocente.Text = c.persona;
            TxtSuscritoPor.Text = c.persona;
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (CamposLlenos())
            {
                //Tomo los datos para guardarlos
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
            DocX document = DocX.Load(Server.MapPath("~/Plantilla/APROBACION_CONVENIO.docx"));
            //Definimos la ruta del archivo que ya se creo

            document.Bookmarks["FechaResolucion"].SetText(txtFecha.Text);
            document.Bookmarks["NResolucion"].SetText(txtNResolucion.Text);
            document.Bookmarks["Coordinador"].SetText(txtDocente.Text + "\n");
            document.Bookmarks["TipoSesion"].SetText(ddlSesion.SelectedValue);
            document.Bookmarks["FechaSesion"].SetText(txtFechaSesion.Text);
            document.Bookmarks["NMemorando"].SetText(txtNMemorando.Text);
            document.Bookmarks["FechaMemorando"].SetText(txtFechaMemorando.Text);
            document.Bookmarks["Coordinador2"].SetText(TxtSuscritoPor.Text);
            document.Bookmarks["Carrera"].SetText(ddlCarreras.SelectedValue);
            document.Bookmarks["ConvenioCon"].SetText(txtSuscritoCon.Text);
            document.Bookmarks["CargoCon"].SetText(txtCargoSuscritoCon.Text);
            document.Bookmarks["Empresa"].SetText(txtEmpresa.Text);
            document.Bookmarks["Miembro"].SetText(txtAtentamente.Text);
            document.Bookmarks["MiembroCargo"].SetText(txtCargoMiembro.Text + "\n");
            //Parrafo en Mayusculas
            document.Bookmarks["CarreraM"].SetText(ddlCarreras.SelectedValue.ToUpper());
            document.Bookmarks["EmpresaM"].SetText(txtEmpresa.Text.ToUpper());
            document.Bookmarks["ConvenioConM"].SetText(txtSuscritoCon.Text.ToUpper());
            document.Bookmarks["CargoConM"].SetText(txtCargoSuscritoCon.Text.ToUpper());
            document.Bookmarks["EmpresaM2"].SetText(txtEmpresa.Text.ToUpper());

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

        private bool CamposLlenos()
        {
            if (txtFecha.Text.Equals("") || txtNResolucion.Text.Length != 4 ||
                txtDocente.Text.Equals("") || txtNMemorando.Text.Length != 4 ||
                txtFechaSesion.Text.Equals("") || txtFechaMemorando.Text.Equals("") || txtSuscritoCon.Text.Equals("") ||
                txtCargoSuscritoCon.Text.Equals("") || txtCargoMiembro.Text.Equals(""))
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