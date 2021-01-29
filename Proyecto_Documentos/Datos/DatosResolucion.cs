using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class DatosResolucion
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Gestion_DocumentosConnectionString"].ConnectionString; ;
        }


        public int InsertResolucion(Resolucion m)
        {
            int afectadas;
            if (GetIDporResolucion(m.id).Equals("0"))
            {
                string sql = @"INSERT INTO[dbo].[Resoluciones]
                                    ([id]
                                    ,[idTipo]
                                    ,[estado]
                                    ,[cuerpo])
                              VALUES
                                    (@id
                                    ,@idTipo
                                    ,@estado
                                    ,@cuerpo)";

                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", m.id);
                        command.Parameters.AddWithValue("@idTipo", m.idTipo);
                        command.Parameters.AddWithValue("@estado", m.estado);
                        command.Parameters.AddWithValue("@cuerpo", m.cuerpo);

                        connection.Open();
                        afectadas = command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return afectadas;
            }
            else
            {
                return -1;
            }
        }

        public string GetIDporResolucion(string id)
        {
            //si existe devuelve el id y sino, 0
            string ide = "0";
            string sql = "SELECT id  FROM[dbo].[Resoluciones]  where id =  @id";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        ide = reader["id"].ToString();
                    }
                    reader.Close();
                }
            }
            return ide;
        }

        public List<Resolucion> GetResolucionesPorActa(string idActa)
        {
            List<Resolucion> lista = new List<Resolucion>();

            string sql = @"SELECT R.[id] as id, R.[cuerpo] as cuerpo
                           FROM [dbo].[DetalleActa] DA
                           INNER JOIN [dbo].[Resoluciones] R ON DA.[idResolucion] = R.[id]
                           WHERE DA.[idActa] = @idActa
                           Order by R.[id] asc";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idActa",idActa);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Resolucion r = new Resolucion();
                        r.id = reader["id"].ToString();
                        r.cuerpo = reader["cuerpo"].ToString();
                        lista.Add(r);
                    }
                    reader.Close();
                }
            }
            return lista;
        }
    }
    



}
