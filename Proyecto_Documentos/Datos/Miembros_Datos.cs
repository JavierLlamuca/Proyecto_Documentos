using Proyecto_Documentos.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class Miembros_Datos
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Gestion_DocumentosConnectionString"].ConnectionString; ;
        }
        public List<Miembro> GetMiembros()
        {
            List<Miembro> lista = new List<Miembro>();

            string sql = "SELECT [id] ,[cedula],[nombre],[apellido] ,[titulo] ,[cargo]  FROM[dbo].[Miembros]";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Miembro m = new Miembro();
                        m.id = Convert.ToInt32(reader["id"]);
                        m.cedula = reader["cedula"].ToString();
                        m.titulo = reader["titulo"].ToString();
                        m.nombre = reader["nombre"].ToString();
                        m.apellido = reader["apellido"].ToString();
                        m.cargo = reader["cargo"].ToString();

                        lista.Add(m);
                    }
                    reader.Close();
                }
            }
            return lista;
        }

        public List<Miembro> GetMiembrosActa(int IdConsejo)
        {
            List<Miembro> lista = new List<Miembro>();

            string sql = @"SELECT M.[nombre] as nombre, M.[apellido] as apellido, M.[titulo] as titulo,M.[cargo] as cargo
                                    FROM [dbo].[Consejo_Miembros] CM
                                    INNER JOIN [dbo].[Miembros] M ON CM.[idmiembros] = M.[id]
                                    WHERE CM.[idConsejo] = @idConsejo";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idConsejo", IdConsejo);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Miembro m = new Miembro();
                        m.titulo = reader["titulo"].ToString();
                        m.nombre = reader["nombre"].ToString();
                        m.apellido = reader["apellido"].ToString();
                        m.cargo = reader["cargo"].ToString();
                        lista.Add(m);
                    }
                    reader.Close();
                }
            }
            return lista;
        }
        public int InsertMiembro(Miembro m)
        {
            int afectadas;
            if (GetIDporCedula(m.cedula)==0)
            {
                string sql = "INSERT INTO Miembros ([cedula],[nombre],[apellido],[titulo],[cargo]) " +
                             "VALUES (@cedula,@nombre,@apellido,@titulo,@cargo)";

                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cedula", m.cedula);
                        command.Parameters.AddWithValue("@nombre", m.nombre);
                        command.Parameters.AddWithValue("@apellido", m.apellido);
                        command.Parameters.AddWithValue("@titulo", m.titulo);
                        command.Parameters.AddWithValue("@cargo", m.cargo);

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

        public int UpdateMiembro(Miembro m)
        {
            int afectadas;
            string sql = "UPDATE Miembros SET " +
                "[cedula] = @cedula" +
                ",[nombre] = @nombre" +
                ",[apellido] =@apellido" +
                ",[titulo] = @titulo" +
                ",[cargo] =@cargo " +
                " WHERE id=@id";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", m.id);
                    command.Parameters.AddWithValue("@cedula", m.cedula);
                    command.Parameters.AddWithValue("@nombre", m.nombre);
                    command.Parameters.AddWithValue("@apellido", m.apellido);
                    command.Parameters.AddWithValue("@titulo", m.titulo);
                    command.Parameters.AddWithValue("@cargo", m.cargo);

                    connection.Open();
                    afectadas = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return afectadas;
        }

        public int DeleteMiembro(Miembro m)
        {
            int afectadas;
            string sql = "DELETE FROM Miembros WHERE cedula=@cedula";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@cedula", m.cedula);
                    connection.Open();
                    afectadas = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
                return afectadas;
        }
        public Miembro GetMiembrosById(string id)
        {
            Miembro m = null;
            string sql = "SELECT [cedula],[nombre],[apellido],[titulo],[cargo]  FROM[dbo].[Miembros]  where id =  @MiembroID";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MiembroID", id);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        m = new Miembro();
                        //m.id = Convert.ToInt32(reader["id"]);
                        m.cedula = reader["cedula"].ToString();
                        m.titulo = reader["titulo"].ToString();
                        m.nombre = reader["nombre"].ToString();
                        m.apellido = reader["apellido"].ToString();
                        m.cargo = reader["cargo"].ToString();
                    }
                    reader.Close();
                }
            }
            return m;
        }

        public int GetIDporCedula(string cedula)
        {
            //si existe devuelve el id y sino, 0
            int ide=0;
            string sql = "SELECT id  FROM[dbo].[Miembros]  where cedula =  @cedula";
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        ide = Convert.ToInt32(reader["id"]);
                    }
                    reader.Close();
                }
            }
            return ide;
        }

        public List<Miembro> GetCoordinadoresCarrera()
        {
            List<Miembro> lista = new List<Miembro>();

            string sql = @"SELECT [id] ,[cedula],[nombre],[apellido] ,[titulo] ,[cargo]  FROM[dbo].[Miembros]
                            Where [cargo] Like '%Coordinador%'";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Miembro m = new Miembro();
                        m.id = Convert.ToInt32(reader["id"]);
                        m.cedula = reader["cedula"].ToString();
                        m.titulo = reader["titulo"].ToString();
                        m.nombre = reader["nombre"].ToString();
                        m.apellido = reader["apellido"].ToString();
                        m.cargo = reader["cargo"].ToString();

                        lista.Add(m);
                    }
                    reader.Close();
                }
            }
            return lista;
        }

    }
}