using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mail;

namespace MSI.Catastros.Web.Helpers
{
    public class MailHelpers
    {
        public void   SendMail()
        {
            string remitenteCorreo = WebConfigurationManager.AppSettings["AdminUser"];
            string destinatarioCorreo = WebConfigurationManager.AppSettings["DestinatarioCreacionLote"];
            string destinatarioCorreoGAT = WebConfigurationManager.AppSettings["DestinatarioCreacionLote2"];
            


            string titulo = "SISTEMA DE MSISIC - CATASTRO";
            string mensaje = "Buen día. Se le informa que se ha registrado un nuevo LOTE CATASTRAL, Se le hace de  conocimiento para que pueda registrar sus parametria correspondientes en el Sistema de MSISAT. Saludos";


            var correo = new System.Net.Mail.MailMessage();
            correo.Subject = titulo;
            correo.To.Add(destinatarioCorreo);
            correo.To.Add(destinatarioCorreoGAT);
            correo.From = new MailAddress(remitenteCorreo,"MSISIC",Encoding.UTF8);
            correo.Body = mensaje;
            correo.IsBodyHtml = true;
            correo.BodyEncoding = Encoding.UTF8;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            var smtp = new SmtpClient();
            var ipSmtp = ConfigurationManager.AppSettings["SMTPName"];
            smtp.Host = ipSmtp;
            smtp.Send(correo);

        }
        public static byte[] CombinarArchivosPDF(IEnumerable<MemoryStream> streamArchivos)
        {
            using (var finalStream = new MemoryStream())
            {
                var copia = new PdfCopyFields(finalStream);

                foreach (MemoryStream ms in streamArchivos)
                {
                    ms.Position = 0;
                    copia.AddDocument(new PdfReader(ms));
                    ms.Close();
                    ms.Dispose();
                }
                try
                {
                    copia.Close();
                    return finalStream.ToArray();
                }
                catch (System.OutOfMemoryException e)
                {
                    throw new Exception(e.Message);
                }
                
            }
        }
    }
}