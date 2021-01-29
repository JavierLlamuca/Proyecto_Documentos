using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class Conexion
    {

        private SqlConnection conexion;

        public SqlConnection conectarBD()
        {
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Gestion_DocumentosConnectionString"].ConnectionString);
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            else
            {
                conexion.Open();
            }
            return conexion;
        }
    }
}