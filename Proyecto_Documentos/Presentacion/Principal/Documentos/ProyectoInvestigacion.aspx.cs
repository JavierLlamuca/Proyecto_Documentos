﻿using Proyecto_Documentos.Entidades;
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
    public partial class ProyectoInvestigacion : System.Web.UI.Page
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
            TraerPresidenteVinculacion();
            CargaTiposSesion();
            CargarCoordinadoresCarrera();
            TraerPresidente();
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
        private void TraerPresidenteVinculacion()
        {
            Configuracion c = new Configuracion();
            c = conf.TraerPresidenteTitulacion();
            txtPresidente.Text = c.persona;
            txtDocente.Text = c.persona;
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

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

            Estudiante estudiante = new Estudiante();
            estudiante = Negocio.GetEstudianteporCedula(txtcedulaBuscar.Text);
            txtApellidos.Text = estudiante.Apellidos;
            TxtNombres.Text = estudiante.Nombres;
            txtCarreraEstudiante.Text = estudiante.Carrera;
            if (estudiante.Nombres == null)
            {
                lbControl.Text = "Estudiante no existe";
            }
        }

        private bool CamposLlenos()
        {
            if (txtFecha.Text.Equals("") || txtNResolucion.Text.Length != 4 ||
               txtDocente.Text.Equals("") || txtNMemorando.Text.Length != 4 ||
               txtFechaSesion.Text.Equals("") || txtFechaMemorando.Text.Equals("") ||
               txtAtentamente.Text.Equals("") || txtPresidente.Text.Equals("") ||
               txtApellidos.Text.Equals("") || TxtNombres.Text.Equals("") || txtCargoMiembro.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void GenerarWord()
        {
            string filename = txtNResolucion.Text + "-P-CD-FISEI-UTA-2020";
            DocX document = DocX.Load(Server.MapPath("~/Plantilla/APROBACIÓN_MODALIDAD_PROYECTO_DE_INVESTIGACIÓN.docx"));

            //Definimos la ruta del archivo que ya se creo

            document.Bookmarks["FechaResolucion"].SetText(txtFecha.Text);
            document.Bookmarks["NResolucion"].SetText(txtNResolucion.Text);
            document.Bookmarks["PresidenteTitulacion"].SetText(txtDocente.Text + "\n");
            document.Bookmarks["TipoSesion"].SetText(ddlSesion.SelectedValue);
            document.Bookmarks["FechaSesion"].SetText(txtFechaSesion.Text);
            document.Bookmarks["NAcuerdo"].SetText(txtNMemorando.Text);
            document.Bookmarks["FechaAcuerdo"].SetText(txtFechaMemorando.Text);
            document.Bookmarks["PresidenteTitulacion2"].SetText(txtPresidente.Text);
            document.Bookmarks["Estudiante"].SetText(txtApellidos.Text + " " + TxtNombres.Text);
            document.Bookmarks["EstudianteCarrera"].SetText(txtCarreraEstudiante.Text);
            document.Bookmarks["EstudianteM2"].SetText(txtApellidos.Text + " " + TxtNombres.Text);
            document.Bookmarks["EstudianteCarreraM"].SetText(txtCarreraEstudiante.Text.ToUpper());
            document.Bookmarks["EstudianteM3"].SetText(txtApellidos.Text + " " + TxtNombres.Text);

            document.Bookmarks["Miembro"].SetText(txtAtentamente.Text);
            document.Bookmarks["MiembroCargo"].SetText(txtCargoMiembro.Text + "\n");
            //Letras pequeñas documento
            document.Bookmarks["CoordinadorCarrera"].SetText(ddlCoordinadores.SelectedValue);
            document.Bookmarks["Carrera2"].SetText(ddlCarrerasCoordinador.SelectedValue);
            //Llevar el cuerpo
            string cuerpo = document.Bookmarks["Cuerpo1"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo2"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo3"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Cuerpo4"].Paragraph.Text + "\n\n";
            cuerpo = cuerpo + document.Bookmarks["Lista1"].Paragraph.Text + "\n";
            cuerpo = cuerpo + document.Bookmarks["Lista2"].Paragraph.Text + "\n";
            cuerpo = cuerpo + document.Bookmarks["Lista3"].Paragraph.Text + "\n";
            cuerpo = cuerpo + document.Bookmarks["Lista4"].Paragraph.Text + "\n";
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
    }
}