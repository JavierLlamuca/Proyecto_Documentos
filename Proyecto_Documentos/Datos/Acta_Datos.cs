using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class Acta_Datos
    {
        private SqlCommand cmdConsejo = new SqlCommand();
        private Conexion conn = new Conexion();
        public string Insertar(Acta acta)
        {
            string rpta = "";
            int registros;
            try
            {
                string sql = @"INSERT INTO [dbo].[Actas]
           ([id]
           ,[idconsejo])
     VALUES
           (@id
           ,@idconsejo)";
                cmdConsejo.CommandType = CommandType.Text;
                cmdConsejo.CommandText = sql;
                cmdConsejo.Connection = conn.conectarBD();
                {
                    cmdConsejo.Parameters.AddWithValue("@id", acta.id);
                    cmdConsejo.Parameters.AddWithValue("@idconsejo", acta.idConsejo);
                }
                registros = cmdConsejo.ExecuteNonQuery();

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