using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class Consejo_Datos
    {
        private SqlCommand cmdConsejo = new SqlCommand();
        private Conexion conn = new Conexion();
        public string Insertar(Consejo consejo)
        {
            string rpta = "";
            int registros;
            try
            {
                string sql = @"INSERT INTO [dbo].[Consejo]
                                ([id])
                                VALUES
                                (@id)";
                cmdConsejo.CommandType = CommandType.Text;
                cmdConsejo.CommandText = sql;
                cmdConsejo.Connection = conn.conectarBD();
                {
                    cmdConsejo.Parameters.AddWithValue("@id", consejo.id);
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

        public string contador;
        public List<Consejo> UltimoCod()
        {
            SqlCommand sqlcmd = new SqlCommand("select count(id),max (id) from Consejo", conn.conectarBD());
            sqlcmd.CommandType = CommandType.Text;

            SqlDataReader PaTable = sqlcmd.ExecuteReader();
            List<Consejo> Coleccion = new List<Consejo>();
            while (PaTable.Read())
            {
                this.contador = Convert.ToString(PaTable.GetInt32(0));
                if (contador == "0")
                {
                    Coleccion.Add(new Consejo(PaTable.GetInt32(0)));

                }
                else
                {
                    Coleccion.Add(new Consejo(PaTable.GetInt32(1)));

                }
            }
            return Coleccion;
        }
    }
}