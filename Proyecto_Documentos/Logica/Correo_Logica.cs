using Proyecto_Documentos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Documentos.Logica
{
    public class Correo_Logica
    {
        Correo_Datos correo = new Correo_Datos();
        public int enviarCorreo(string emisor, string mensaje, string asunto, string destinatario, string ruta)
        {
            return correo.enviarCorreo(emisor, mensaje, asunto, destinatario, ruta);
        }
    }
}