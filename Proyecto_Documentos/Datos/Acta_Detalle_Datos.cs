using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class Acta_Detalle_Datos
    {
        private Conexion conn = new Conexion();
        private SqlCommand cmdActaDetalle = new SqlCommand();

        public string Insertar(Acta_Detalle detalle)
        {
            string rpta = "";
            try
            {
                cmdActaDetalle.CommandType = CommandType.Text;
                cmdActaDetalle.CommandText = @"INSERT INTO [dbo].[DetalleActa]
           ([idActa]
           ,[idResolucion])
     VALUES
           (@idActa
           ,@idResolucion)";
                cmdActaDetalle.Connection = conn.conectarBD();
                {
                    cmdActaDetalle.Parameters.AddWithValue("@idActa", detalle.idActa);
                    cmdActaDetalle.Parameters.AddWithValue("@idResolucion", detalle.idResolucion);
                }
                int registros;
                registros = cmdActaDetalle.ExecuteNonQuery();
                if (registros == 1)
                {
                    rpta = "OK";
                }
                else
                {
                    rpta = "Error al Insertar";
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.Message);
            }
            return rpta;
        }
    }
}