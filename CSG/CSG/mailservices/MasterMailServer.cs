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

        
        public void SendRecoveryMail(string subject, string body, string to)
        {
            MailMessage mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(SenderMail);
                mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.SubjectEncoding = UTF8;
                mailMessage.IsBodyHtml = IsBodyHtml;
                mailMessage.Body = body;
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
    }
}
