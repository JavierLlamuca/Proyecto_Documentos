using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto_Documentos.Entidades;
using Proyecto_Documentos.Datos;
using System.Data;

namespace Proyecto_Documentos.Logica
{
    public class Negocio
    {
        public static List<Estudiante> DevolverListaEstudiantesNegocio()
        {
            return DatosEstudiante.DevolverListaEstudianteDatos();
        }

        public static List<Estudiante> DevolverListaEstudiantesBuscarNegocio(string cadena)
        {
            return DatosEstudiante.DevolverListaEstudianteDatosBuscar(cadena);
        }



        public static Estudiante GuardarEstudianteNegocio2(Estudiante estudiante)
        {
            //Logica de negocio 
            if (estudiante.Cedula != " ")
            {

                return DatosEstudiante.GuardarEstudianteDatos2(estudiante);
            }
            else
            {

                return null;
            }


        }

        public static Estudiante GetEstudianteporCedula(string cedula) {
            return DatosEstudiante.GetEstudianteporCedula(cedula);
        }
    }
}