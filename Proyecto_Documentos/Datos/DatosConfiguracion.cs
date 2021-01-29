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
    public class DatosConfiguracion
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Gestion_DocumentosConnectionString"].ConnectionString;
        }

        public Configuracion GetPresidente()
        {
            Configuracion c = new Configuracion();
            
            string sql = @"SELECT [cargo]
                                  ,[persona]
                              FROM [dbo].[Configuraciones]
                              WHERE[id] =  @id";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", 2);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        c.cargo = reader["cargo"].ToString();
                        c.persona = reader["persona"].ToString();

                    }
                    reader.Close();
                }
            }
            return c;
        }

        public Configuracion GetPresidenteCAF()
        {
            Configuracion c = new Configuracion();

            string sql = @"SELECT [cargo]
                                  ,[persona]
                              FROM [dbo].[Configuraciones]
                              WHERE[area] =  @id";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", 5);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        c.cargo = reader["cargo"].ToString();
                        c.persona = reader["persona"].ToString();
                    }
                    reader.Close();
                }
            }
            return c;
        }

        public Configuracion GetCoordinadorVinculacion()
        {
            Configuracion c = new Configuracion();

            string sql = @"SELECT [cargo]
                                  ,[persona]
                              FROM [dbo].[Configuraciones]
                              WHERE[id] =  @id";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", 3);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        c.cargo = reader["cargo"].ToString();
                        c.persona = reader["persona"].ToString();
                    }
                    reader.Close();
                }
            }
            return c;
        }

        public List<Configuracion> GetCoordinadoresVinculacion()
        {
            List<Configuracion> lista = new List<Configuracion>();

            string sql = @"SELECT [cargo]
                                 ,[persona]
                             FROM [dbo].[Configuraciones]
                             where[area] = @area";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@area", 3);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Configuracion m = new Configuracion();
                        m.cargo = reader["cargo"].ToString();
                        m.persona = reader["persona"].ToString();
                        lista.Add(m);
                    }
                    reader.Close();
                }
            }
            return lista;
        }

        public Configuracion GetPresidenteTitulacion()
        {
            Configuracion c = new Configuracion();

            string sql = @"SELECT [cargo]
                                  ,[persona]
                              FROM [dbo].[Configuraciones]
                              WHERE[area] =  @id";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", 4);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        c.cargo = reader["cargo"].ToString();
                        c.persona = reader["persona"].ToString();
                    }
                    reader.Close();
                }
            }
            return c;
        }

        public string UpdateConfiguracion(Configuracion c, int id)
        {
            string rpta = "";
            int afectadas;
            string sql = @"UPDATE[Configuraciones]
                                 SET [cargo] = @cargo
                                  ,[persona] = @persona
                             WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@cargo", c.cargo);
                    command.Parameters.AddWithValue("@persona", c.persona);

                    connection.Open();
                    afectadas = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            if (afectadas == 1)
            {
                rpta = "Actualizado Correctamente";
            }
            else
            {
                rpta = "Error al Insertar";
            }
            return rpta;
        }
    }
}