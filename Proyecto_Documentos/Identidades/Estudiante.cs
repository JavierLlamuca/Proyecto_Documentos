using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Entidades
{
    public  class Estudiante
    {
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string EstadoCivil { get; set; }
        public string Discapacidad { get; set; }
        public string Etnia { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string CorreoUta { get; set; }
        public string FechaNacimiento { get; set; }
        public string Parroquia { get; set; }
        public string Barrio { get; set; }
        public string CallePrincipal { get; set; }
        public string CalleSecundaria { get; set; }
        public string NumeroCasa { get; set; }
        public string Matricula { get; set; }
        public string Folio { get; set; }
        public string Factura { get; set; }
        public double Valor { get; set; }
        public string Canton { get; set; }
        public string Provincia { get; set; }
        public string Carrera { get; set; }

    }
}