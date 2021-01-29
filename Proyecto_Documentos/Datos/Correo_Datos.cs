using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace Proyecto_Documentos.Datos
{
    public class Correo_Datos
    {

        public int enviarCorreo(string emisor, string mensaje, string asunto, string destinatario, string ruta)
        {
            int respuesta = -1;
            MailMessage correos = new MailMessage();
            SmtpClient envios = new SmtpClient();
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                if (ruta.Equals("") == false)
                {
                    if (File.Exists(ruta))
                    {
                        Attachment data = new Attachment(
                                            ruta);

                        correos.Attachments.Add(data);
                        correos.From = new MailAddress(emisor);
                        envios.Credentials = new NetworkCredential(emisor, "nd1sL4y0hgIQNKaZ");

                        //Datos importantes no modificables para tener acceso a las cuentas

                        envios.Host = "smtp-relay.sendinblue.com";
                        envios.Port = 587;
                        envios.EnableSsl = true;

                        envios.Send(correos);
                        data.Dispose();
                        
                        
                    }
                  
                }
                return respuesta = 1;

            }
            catch (Exception ex)
            {
                return respuesta = 0;
            }
        }
    }
}