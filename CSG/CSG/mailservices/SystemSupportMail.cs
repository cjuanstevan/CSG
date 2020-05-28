using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSG.mailservices
{
    class SystemSupportMail : MasterMailServer
    {
        public SystemSupportMail()
        {
            SenderMail = "cprueba369@gmail.com";
            Password = "administrador";
            Host = "smtp.gmail.com";
            Port = 587;
            EnableSsl = true;
            InitializeSmtpClient();
        }
    }
}
