using CSG.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.cryptography;
using System.Security.Cryptography;

namespace CSG.views
{
    public partial class FrmRecoveryAccount : Form
    {
        private readonly UserLog userLog = new UserLog();
        public FrmRecoveryAccount()
        {
            InitializeComponent();
        }

        private void BtnRecoveryAccount_Click(object sender, EventArgs e)
        {
            if (!txtAccount.Text.Equals("USUARIO O CORREO ELECTRÓNICO"))
            {
                if (!txtToken.Text.Equals("TOKEN"))
                {
                    byte[] cipheraccount;
                    byte[] ciphertoken;
                    using (AesManaged myAes = new AesManaged())
                    {
                        var rsa = new cryptography.SystemSupportRSA();
                        // Encrypt the string to an array of bytes.
                        cipheraccount = rsa.EncryptStringToBytes_Aes(txtAccount.Text, myAes.Key, myAes.IV);
                        ciphertoken = rsa.EncryptStringToBytes_Aes(txtToken.Text, myAes.Key, myAes.IV);
                        var request = userLog.UserRecoveryAccount(ciphertoken, cipheraccount, myAes.Key, myAes.IV);
                        string[] result = request.Split(',');
                        if (result[0].Equals("s"))
                        {
                            MsgOk(result[1]);
                        }
                        else
                        {
                            MsgError(result[1]);
                        }

                    }


                   
                    
                }
                else
                {
                    MsgError("Ingrese el token de seguridad");
                }
            }
            else
            {
                MsgError("Ingrese usuario o cuenta de correo electrónico");
            }
        }

        private void TxtAccount_Enter(object sender, EventArgs e)
        {
            if (txtAccount.Text.Equals("USUARIO O CORREO ELECTRÓNICO"))
            {
                txtAccount.Clear();
                txtAccount.ForeColor = Color.LightGray;
            }
        }

        private void TxtAccount_Leave(object sender, EventArgs e)
        {
            if (txtAccount.Text.Equals(""))
            {
                txtAccount.Text = "USUARIO O CORREO ELECTRÓNICO";
                txtAccount.ForeColor = Color.DimGray;
            }
        }

        private void TxtToken_Enter(object sender, EventArgs e)
        {
            if (txtToken.Text.Equals("TOKEN"))
            {
                txtToken.Clear();
                txtToken.ForeColor = Color.LightGray;
            }
        }

        private void TxtToken_Leave(object sender, EventArgs e)
        {
            if (txtToken.Text.Equals(""))
            {
                txtToken.Text = "TOKEN";
                txtToken.ForeColor = Color.DimGray;
            }
        }

        private void MsgOk(string msg)
        {
            lblMessage.Image = Properties.Resources.ok;
            lblMessage.Text = "      " + msg;
            lblMessage.Visible = true;
        }
        private void MsgError(string msg)
        {
            lblMessage.Image = Properties.Resources.error_equis;
            lblMessage.Text = "      " + msg;
            lblMessage.Visible = true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
