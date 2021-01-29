using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Entidades
{
    public class Miembro
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string titulo { get; set; }
        public string cargo { get; set; }

    }
}