using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.cache;

namespace CSG.views
{
    public partial class CdoPassValidate : Form
    {
        public IMsgMethod msg { get; set; }
        public CdoPassValidate()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
            var rsa = new cryptography.SystemSupportRSA();
            Console.WriteLine(rsa.GetMd5Hash(txtPassValidate.Text) + "=" + UserCache.UserPass);
            if (rsa.GetMd5Hash(txtPassValidate.Text).Equals(UserCache.UserPass))
            {
                //Permitimos editar contraseña
                msg.txtpassActivator();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        protected string PassTranfer()
        {
            return "";
        }
    }
}
