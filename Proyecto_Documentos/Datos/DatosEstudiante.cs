using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto_Documentos.Entidades;

namespace Proyecto_Documentos.Datos
{
    public class DatosEstudiante
    {
        static string conexiont = ConfigurationManager.ConnectionStrings["Gestion_DocumentosConnectionString"].ConnectionString;


        public static Estudiante GetEstudianteporCedula(string cedula)
        {
            Estudiante e = new Estudiante();
            string sql = @"SELECT [cedula]
                                 ,[apellidos]
                                 ,[nombres]
                                 ,[carrera]
                             FROM [Estudiantes]
                             where[cedula] = @cedula";
            using (SqlConnection connection = new SqlConnection(conexiont))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        e.Cedula = reader["cedula"].ToString();
                        e.Apellidos = reader["apellidos"].ToString();
                        e.Nombres = reader["nombres"].ToString();
                        e.Carrera = reader["carrera"].ToString();
                    }
                    reader.Close();
                }
            }
            return e;
        }

        public static List<Estudiante> DevolverListaEstudianteDatos()
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            SqlConnection conexion = new SqlConnection(conexiont);
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = @"SELECT    [cedula]
                                          ,[apellidos]
                                          ,[nombres]                                          
                                          ,[genero]
                                          ,[estadoCivil]
                                          ,[discapacidad]
                                          ,[etnia]
                                          ,[telefono]
                                          ,[celular]
                                          ,[correo]
                                          ,[correoUta]
                                          ,[fechaNacimiento]
                                          ,[direccionParroquia]
                                          ,[direccionBarrio]
                                          ,[direccionCalleP]
                                          ,[direccionCalleS]
                                          ,[direccionNumeroCasa]
                                          ,[matricula]
                                          ,[folio]
                                          ,[factura]
                                          ,[valor]
                                          ,[canton]
                                          ,[provincia]
                                          ,[carrera]
                                      FROM [dbo].[Estudiantes]";
            cmd.CommandType = CommandType.Text;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Estudiante estudiante = new Estudiante();
                    //estudiante.ID = Convert.ToInt32(dr["id"]);
                    estudiante.Cedula = dr["cedula"].ToString();
                    estudiante.Apellidos = dr["apellidos"].ToString();
                    estudiante.Nombres = dr["nombres"].ToString();
                    estudiante.Genero = dr["genero"].ToString();
                    estudiante.EstadoCivil = dr["estadoCivil"].ToString();
                    estudiante.Discapacidad = dr["discapacidad"].ToString();
                    estudiante.Etnia = dr["etnia"].ToString();
                    estudiante.Telefono = dr["telefono"].ToString();
                    estudiante.Celular = dr["celular"].ToString();
                    estudiante.Correo = dr["correo"].ToString();
                    estudiante.CorreoUta = dr["correoUta"].ToString();
                    estudiante.FechaNacimiento = dr["fechaNacimiento"].ToString();
                    estudiante.Parroquia = dr["direccionParroquia"].ToString();
                    estudiante.Barrio = dr["direccionBarrio"].ToString();
                    estudiante.CallePrincipal = dr["direccionCalleP"].ToString();
                    estudiante.CalleSecundaria = dr["direccionCalleS"].ToString();
                    estudiante.NumeroCasa = dr["direccionNumeroCasa"].ToString();
                    estudiante.Matricula = dr["matricula"].ToString();
                    estudiante.Folio = dr["folio"].ToString();
                    estudiante.Factura = dr["factura"].ToString();
                    estudiante.Valor = Convert.ToDouble(dr["valor"].ToString());
                    estudiante.Canton = dr["canton"].ToString();
                    estudiante.Provincia = dr["provincia"].ToString();
                    estudiante.Carrera = dr["carrera"].ToString();
                    listaEstudiantes.Add(estudiante);

                }
            }
            conexion.Close();
            return listaEstudiantes;
        }
        public static Estudiante GuardarEstudianteDatos2(Estudiante estudiante)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(conexiont);
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = @"INSERT INTO [Estudiantes]                                                              
                                                               ([cedula]
                                                               ,[apellidos]
                                                               ,[nombres]
                                                               ,[genero]
                                                               ,[estadoCivil]
                                                               ,[discapacidad]
                                                               ,[etnia]
                                                               ,[telefono]
                                                               ,[celular]
                                                               ,[correo]
                                                               ,[correoUta]
                                                               ,[fechaNacimiento]
                                                               ,[direccionParroquia]
                                                               ,[direccionBarrio]
                                                               ,[direccionCalleP]
                                                               ,[direccionCalleS]
                                                               ,[direccionNumeroCasa]
                                                               ,[matricula]
                                                               ,[folio]
                                                               ,[factura]
                                                               ,[valor]
                                                               ,[canton]
                                                               ,[provincia]
                                                               ,[carrera])
                                             VALUES(@cedula,@apellidos, @nombres, @genero,@estadoCivil,@discapacidad, @etnia, @telefono, @celular,@correo, @correoUta,@fechaNacimiento, @direccionParroquia,@direccionBarrio, @direccionCalleP,
                                                    @direccionCalleS, @direccionNumeroCasa, @matricula, @folio, @factura, @valor, @canton, @provincia, @carrera);";

                cmd.Parameters.AddWithValue("@cedula", estudiante.Cedula);
                cmd.Parameters.AddWithValue("@apellidos", estudiante.Apellidos);
                cmd.Parameters.AddWithValue("@nombres", estudiante.Nombres);
                cmd.Parameters.AddWithValue("@genero", estudiante.Genero);
                cmd.Parameters.AddWithValue("@estadoCivil", estudiante.EstadoCivil);
                cmd.Parameters.AddWithValue("@discapacidad", estudiante.Discapacidad);
                cmd.Parameters.AddWithValue("@etnia", estudiante.Etnia);
                cmd.Parameters.AddWithValue("@telefono", estudiante.Telefono);
                cmd.Parameters.AddWithValue("@celular", estudiante.Celular);
                cmd.Parameters.AddWithValue("@correo", estudiante.Correo);
                cmd.Parameters.AddWithValue("@correoUta", estudiante.CorreoUta);
                cmd.Parameters.AddWithValue("@fechaNacimiento", estudiante.FechaNacimiento);
                cmd.Parameters.AddWithValue("@direccionParroquia", estudiante.Parroquia);
                cmd.Parameters.AddWithValue("@direccionBarrio", estudiante.Barrio);
                cmd.Parameters.AddWithValue("@direccionCalleP", estudiante.CallePrincipal);
                cmd.Parameters.AddWithValue("@direccionCalleS", estudiante.CalleSecundaria);
                cmd.Parameters.AddWithValue("@direccionNumeroCasa", estudiante.NumeroCasa);
                cmd.Parameters.AddWithValue("@matricula", estudiante.Matricula);
                cmd.Parameters.AddWithValue("@folio", estudiante.Folio);
                cmd.Parameters.AddWithValue("@factura", estudiante.Factura);
                cmd.Parameters.AddWithValue("@valor", estudiante.Valor);
                cmd.Parameters.AddWithValue("@canton", estudiante.Canton);
                cmd.Parameters.AddWithValue("@provincia", estudiante.Provincia);
                cmd.Parameters.AddWithValue("@carrera", estudiante.Carrera);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteScalar();
                conexion.Close();
                return estudiante;


            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                estudiante = ActualizarEstudianteDatos(estudiante);
                return estudiante;
            }


        }
        public static Estudiante ActualizarEstudianteDatos(Estudiante estudiante)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(conexiont);
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = @"UPDATE [Estudiantes]
                                          SET [apellidos] = @apellidos
                                             ,[nombres] = @nombres
                                             ,[genero] = @genero
                                             ,[estadoCivil] = @civil
                                             ,[discapacidad] = @discapacidad
                                             ,[etnia] = @etnia
                                             ,[telefono] = @telefono
                                             ,[celular]= @celular
                                             ,[correo] = @correo
                                             ,[correoUta] = @correouta
                                             ,[fechaNacimiento] = @fecha
                                             ,[direccionParroquia] = @parroquia
                                             ,[direccionBarrio] = @barrio
                                             ,[direccionCalleP] = @principal
                                             ,[direccionCalleS] = @secundaria
                                             ,[direccionNumeroCasa] = @casa
                                             ,[matricula] = @matricula
                                             ,[folio] = @folio
                                             ,[factura] = @factura
                                             ,[valor] = @valor
                                             ,[canton] = @canton
                                             ,[provincia] = @provincia 
                                             ,[carrera]  = @carrera                                             
                                        WHERE cedula = @cedula";
                cmd.Parameters.AddWithValue("@apellidos", estudiante.Apellidos);
                cmd.Parameters.AddWithValue("@nombres", estudiante.Nombres);
                cmd.Parameters.AddWithValue("@genero", estudiante.Genero);
                cmd.Parameters.AddWithValue("@civil", estudiante.EstadoCivil);
                cmd.Parameters.AddWithValue("@discapacidad", estudiante.Discapacidad);
                cmd.Parameters.AddWithValue("@etnia", estudiante.Etnia);
                cmd.Parameters.AddWithValue("@telefono", estudiante.Telefono);
                cmd.Parameters.AddWithValue("@celular", estudiante.Celular);
                cmd.Parameters.AddWithValue("@correo", estudiante.Correo);
                cmd.Parameters.AddWithValue("@correouta", estudiante.CorreoUta);
                cmd.Parameters.AddWithValue("@fecha", estudiante.FechaNacimiento);
                cmd.Parameters.AddWithValue("@parroquia", estudiante.Parroquia);
                cmd.Parameters.AddWithValue("@barrio", estudiante.Barrio);
                cmd.Parameters.AddWithValue("@principal", estudiante.CallePrincipal);
                cmd.Parameters.AddWithValue("@secundaria", estudiante.CalleSecundaria);
                cmd.Parameters.AddWithValue("@casa", estudiante.NumeroCasa);
                cmd.Parameters.AddWithValue("@matricula", estudiante.Matricula);
                cmd.Parameters.AddWithValue("@folio", estudiante.Folio);
                cmd.Parameters.AddWithValue("@factura", estudiante.Factura);
                cmd.Parameters.AddWithValue("@valor", estudiante.Valor);
                cmd.Parameters.AddWithValue("@canton", estudiante.Canton);
                cmd.Parameters.AddWithValue("@provincia", estudiante.Provincia);
                cmd.Parameters.AddWithValue("@carrera", estudiante.Carrera);
                cmd.Parameters.AddWithValue("@cedula", estudiante.Cedula);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteScalar();
                conexion.Close();
                return estudiante;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
        }

        public static List<Estudiante> DevolverListaEstudianteDatosBuscar(string cadena)
        {
            List<Estudiante> listaEstudiantes = new List<Estudiante>();
            SqlConnection conexion = new SqlConnection(conexiont);
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = @"SELECT [cedula],
                                       [apellidos],
                                       [nombres],
                                       [genero],
                                       [correo],
                                       [correoUta],
                                       [matricula],
                                       [folio],
                                       [carrera]
                                       FROM [Estudiantes]
                                       WHERE [cedula] LIKE '%" + cadena + "%' OR [nombres] LIKE '%" + cadena + "%' OR [apellidos] LIKE '%" + cadena + "%'";
            cmd.CommandType = CommandType.Text;
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Estudiante estudiante = new Estudiante();
                    estudiante.Cedula = dr["cedula"].ToString();
                    estudiante.Apellidos = dr["apellidos"].ToString();
                    estudiante.Nombres = dr["nombres"].ToString();
                    estudiante.Genero = dr["genero"].ToString();
                    estudiante.Correo = dr["correo"].ToString();
                    estudiante.CorreoUta = dr["correoUta"].ToString();
                    estudiante.Matricula = dr["matricula"].ToString();
                    estudiante.Folio = dr["folio"].ToString();
                    estudiante.Carrera = dr["carrera"].ToString();
                    listaEstudiantes.Add(estudiante);

                }
            }
            conexion.Close();
            return listaEstudiantes;
        }


    }
}