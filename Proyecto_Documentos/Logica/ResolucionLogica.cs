using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class ResolucionLogica
    {
        public DatosResolucion datos;

        public ResolucionLogica()
        {
            this.datos = new DatosResolucion();
        }

        public int InsertResolucion(Resolucion m)
        {
            return datos.InsertResolucion(m);
        }
        public List<Resolucion> GetResolucionPorActa(string idActa) {
            return datos.GetResolucionesPorActa(idActa);
        }
    }
}