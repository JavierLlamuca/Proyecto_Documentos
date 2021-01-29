using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_Documentos.Logica;
using Proyecto_Documentos.Entidades;
using System.IO;
using System.Drawing;
using ClosedXML.Excel;
using SpreadsheetLight;

namespace Proyecto_Documentos.Presentacion.Administracion.Autentificacion
{
    public partial class Roles : System.Web.UI.Page
    {

        Estudiante estudiante = new Estudiante();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewEstudiantes.DataBind();
                cargarEstudiantes();
            }


        }

        private void cargarEstudiantes()
        {
            GridViewEstudiantes.DataSource = Negocio.DevolverListaEstudiantesNegocio();

            GridViewEstudiantes.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void importarDatos()
        {
            using (XLWorkbook libro = new XLWorkbook(FileUploadExcel.PostedFile.InputStream))
            {
                IXLWorksheet sheet = libro.Worksheet(1);
                System.Data.DataTable tabla = new System.Data.DataTable();
                bool primeraFila = true;
                foreach (IXLRow row in sheet.Rows())
                {
                    if (primeraFila)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            tabla.Columns.Add(cell.Value.ToString());

                        }
                        primeraFila = false;
                    }
                    else
                    {
                        tabla.Rows.Add();
                        int i = 0;
                        foreach (IXLCell cell in row.Cells())
                        {
                            tabla.Rows[tabla.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                    GridViewEstudiantes.DataSource = tabla;
                    GridViewEstudiantes.DataBind();
                }

            }



        }

        protected void GridViewEstudiantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[19].Visible = false;
                e.Row.Cells[20].Visible = false;
                e.Row.Cells[21].Visible = false;
                e.Row.Cells[22].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[19].Visible = false;
                e.Row.Cells[20].Visible = false;
                e.Row.Cells[21].Visible = false;
                e.Row.Cells[22].Visible = false;
            }

        }


        private void guardarEstudiante2()
        {
            string filename = Path.GetFileName(FileUploadExcel.FileName);
            FileUploadExcel.SaveAs(Server.MapPath("~/") + filename);
            string path = Server.MapPath("~/") + filename;
            SLDocument s1 = new SLDocument(path);

            int fila = 2;
            while (!string.IsNullOrEmpty(s1.GetCellValueAsString(fila, 1)))
            {
                estudiante.Cedula = s1.GetCellValueAsString(fila, 1);
                estudiante.Apellidos = s1.GetCellValueAsString(fila, 2);
                estudiante.Nombres = s1.GetCellValueAsString(fila, 3);
                estudiante.Genero = s1.GetCellValueAsString(fila, 4);
                estudiante.EstadoCivil = s1.GetCellValueAsString(fila, 5);
                estudiante.Discapacidad = s1.GetCellValueAsString(fila, 6);
                estudiante.Etnia = s1.GetCellValueAsString(fila, 7);
                estudiante.Telefono = s1.GetCellValueAsString(fila, 8);
                estudiante.Celular = s1.GetCellValueAsString(fila, 9);
                estudiante.Correo = s1.GetCellValueAsString(fila, 10);
                estudiante.CorreoUta = s1.GetCellValueAsString(fila, 11);
                estudiante.FechaNacimiento = s1.GetCellValueAsString(fila, 12);
                estudiante.Parroquia = s1.GetCellValueAsString(fila, 13);
                estudiante.Barrio = s1.GetCellValueAsString(fila, 14);
                estudiante.CallePrincipal = s1.GetCellValueAsString(fila, 15);
                estudiante.CalleSecundaria = s1.GetCellValueAsString(fila, 16);
                estudiante.NumeroCasa = s1.GetCellValueAsString(fila, 17);
                estudiante.Matricula = s1.GetCellValueAsString(fila, 18);
                estudiante.Folio = s1.GetCellValueAsString(fila, 19);
                estudiante.Factura = s1.GetCellValueAsString(fila, 20);
                estudiante.Valor = s1.GetCellValueAsDouble(fila, 21);
                estudiante.Canton = s1.GetCellValueAsString(fila, 22);
                estudiante.Provincia = s1.GetCellValueAsString(fila, 23);
                estudiante.Carrera = s1.GetCellValueAsString(fila, 24);
                estudiante = Negocio.GuardarEstudianteNegocio2(estudiante);
                fila++;
            }
            if (estudiante != null)
            {
                LabelMensaje.Visible = true;
                LabelMensaje.Text = "Se insertó Correctamente ";

            }
            else
            {
                LabelMensaje.Visible = true;
                LabelMensaje.Text = "Error el estudiante ya existe";
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //verificamos que el control está renderizado
        }

        protected void ButtonImportarExcel_Click(object sender, EventArgs e)
        {
            if (FileUploadExcel.HasFile)
            {
                try
                {
                    guardarEstudiante2();
                    importarDatos();
                }
                catch (Exception)
                {
                    //null;
                }
            }
            else
            {
                LabelMensaje.Visible = true;
                LabelMensaje.Text = "Debe escoger un archivo";
            }



        }

        protected void GridViewEstudiantes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEstudiantes.PageIndex = e.NewPageIndex;
            GridViewEstudiantes.DataSource = Negocio.DevolverListaEstudiantesNegocio();
            GridViewEstudiantes.DataBind();
        }

        protected void TextBoxBuscar_TextChanged1(object sender, EventArgs e)
        {
            GridViewEstudiantes.DataSource = Negocio.DevolverListaEstudiantesBuscarNegocio(TextBoxBuscar.Text);
            GridViewEstudiantes.DataBind();
        }
    }
}