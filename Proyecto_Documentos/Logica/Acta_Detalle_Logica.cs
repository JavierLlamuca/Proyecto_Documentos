using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class Acta_Detalle_Logica
    {
        Acta_Detalle_Datos detalledatos = new Acta_Detalle_Datos();
        public string Insertar(Acta_Detalle detalle)
        {
            return detalledatos.Insertar(detalle);
        }
    }
}