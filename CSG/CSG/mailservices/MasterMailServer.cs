using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace CSG.mailservices
{
    public abstract class MasterMailServer
    {
        private SmtpClient smtpClient;
        protected string SenderMail { get; set; }
        protected string Password { get; set; }
        protected string Host { get; set; }
        protected int Port { get; set; }
        protected bool EnableSsl { get; set; }
        private readonly Encoding UTF8 = Encoding.UTF8;
        private readonly bool IsBodyHtml = true;


        protected void InitializeSmtpClient()
        {
            smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(SenderMail, Password),
                Host = Host,
                Port = Port,
                EnableSsl = EnableSsl
            };
        }

        
        public void SendRecoveryMail(string username ,string user,string token,string subject, string to)
        {
            string html =
                "<html>" +
                "<head></head>" +
                "<body style=''>" +
                "<div style='border:solid black 1px;'>" +
                "<div style=''>" +
                "<center><img style='width:15%;'" +
                "src='https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcT4tqmCn2nY6hXvW-Dv1boChHFctGtJ4SE46HeW4O5bVCtLj1AX&usqp=CAU' " +
                "title='logo_top'/><h3>Control de Servicios y Garantías</h3>" +
                "</center>" +
                "</div><br><br>" +
                "<div style='padding:10px;'>" +
                "<label>Señor(a) <b>"+username+"</b></label>" +
                "<br><br>Usted ha solicitado recuperar su cuenta. En este momento se ha " +
                "creado un nuevo token de seguridad. Le recomendamos cambiar la contraseña una vez " +
                "haya ingresado al sistema.<br><br>" +
                "<label style='text-decoration:underline;'>Datos de inicio de sesión:</label><br>" +
                "<b>Usuario: </b>"+user+"<br>" +
                "<b>Token: </b>" + token +
                "</div></div>" +
                "</body></html>";

            MailMessage mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(SenderMail);
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.SubjectEncoding = UTF8;
                mailMessage.IsBodyHtml = IsBodyHtml;
                mailMessage.Body = html;
                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

        public bool SendEmailCotization(string to, string subject, string html)
        {
            MailMessage mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(SenderMail);
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.SubjectEncoding = UTF8;
                mailMessage.IsBodyHtml = IsBodyHtml;
                mailMessage.Body = html;
                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);
                Console.WriteLine("Envio");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
