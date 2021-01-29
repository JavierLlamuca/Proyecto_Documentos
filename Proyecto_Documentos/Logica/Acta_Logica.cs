using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class Acta_Logica
    {
        Acta_Datos actadatos = new Acta_Datos();
        public string Insertar(Acta acta)
        {
            return actadatos.Insertar(acta);
        }
    }
}