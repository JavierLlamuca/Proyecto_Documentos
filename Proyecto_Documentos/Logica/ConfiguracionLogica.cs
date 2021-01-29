using Proyecto_Documentos.Datos;
using Proyecto_Documentos.Identidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class ConfiguracionLogica
    {
        public DatosConfiguracion datos;

        public ConfiguracionLogica()
        {
            this.datos = new DatosConfiguracion();
        }

        public Configuracion TraerPresidente() {
            return datos.GetPresidente();
        }

        public Configuracion TraerCoordinadorVinculacion()
        {
            return datos.GetCoordinadorVinculacion();
        }
        public List<Configuracion> TraerPresidentesVinculacion()
        {
            return datos.GetCoordinadoresVinculacion();
        }

        public Configuracion TraerPresidenteTitulacion()
        {
            return datos.GetPresidenteTitulacion();
        }
        public Configuracion TraerPresidenteCAF()
        {
            return datos.GetPresidenteCAF();
        }

        public string ActualizarConfiguracion(Configuracion c, int id) {
            return datos.UpdateConfiguracion(c,id);
        }
    }
}