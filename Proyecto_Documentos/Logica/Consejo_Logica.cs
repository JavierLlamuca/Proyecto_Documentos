using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class Consejo_Logica
    {
        Consejo_Datos consejodatos = new Consejo_Datos();
        public string Insertar(Consejo consejo)
        {
            return consejodatos.Insertar(consejo);
        }
        public List<Consejo> UltimoEmp()
        {
            Consejo_Datos ofertac = new Consejo_Datos();
            return ofertac.UltimoCod();
        }

    }
}