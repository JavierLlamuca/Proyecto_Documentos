using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class Consejo_Miembros_Datos
    {
        private Conexion conn = new Conexion();
        private SqlCommand cmdOfertaDetalle = new SqlCommand();

        public string Insertar(Consejo_Miembros detalle)
        {
            string rpta = "";
            try
            {
                cmdOfertaDetalle.CommandType = CommandType.Text;
                cmdOfertaDetalle.CommandText = @"INSERT INTO [dbo].[Consejo_Miembros]
           ([idConsejo]
           ,[idmiembros])
     VALUES
           (@idConsejo
           ,@idmiembros)";
                cmdOfertaDetalle.Connection = conn.conectarBD();
                {
                    cmdOfertaDetalle.Parameters.AddWithValue("@idConsejo", detalle.idConsejo);
                    cmdOfertaDetalle.Parameters.AddWithValue("@idmiembros", detalle.idmiembros);
                }
                int registros;
                registros = cmdOfertaDetalle.ExecuteNonQuery();
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