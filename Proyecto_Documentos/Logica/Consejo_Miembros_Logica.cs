using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class Consejo_Miembros_Logica
    {

        Consejo_Miembros_Datos detalledatos = new Consejo_Miembros_Datos();
        public string Insertar(Consejo_Miembros detalle)
        {
            return detalledatos.Insertar(detalle);
        }

    }
}