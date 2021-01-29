using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Identidades
{
    public class Consejo
    {
        public int id { get; set; }
        public Consejo()
        {

        }
        public Consejo(int ccodigo)
        {
            id = ccodigo;
        }
    }
}