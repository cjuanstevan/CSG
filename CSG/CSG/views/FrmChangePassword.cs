using CSG.cache;
using CSG.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSG.views
{
    public partial class FrmChangePassword : Form
    {
        private readonly UserLog userLog = new UserLog();
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (!txtpass.Text.Equals("CONTRASEÑA"))
            {
                if (!txtpassconf.Text.Equals("CONFIRME LA CONTRASEÑA"))
                {
                    //Comparamos que coincidan
                    Console.WriteLine("CHANGEPASSWORD/Contraseña: '" + txtpass.Text + "' | Length: " + txtpass.TextLength);
                    Console.WriteLine("CHANGEPASSWORD/CContraseña: '" + txtpassconf.Text + "' | Length: " + txtpassconf.TextLength);
                    if (IsEqualsPass())
                    {
                        // Create a new instance of the AesManaged
                        // class.  This generates a new key and initialization
                        // vector (IV).
                        using (AesManaged myAes = new AesManaged())
                        {
                            var rsa = new cryptography.SystemSupportRSA();
                            // Encrypt the string to an array of bytes.
                            byte[] cipherpass = rsa.EncryptStringToBytes_Aes(txtpass.Text, myAes.Key, myAes.IV);
                            byte[] ciphercode = rsa.EncryptStringToBytes_Aes(UserCache.UserCode, myAes.Key, myAes.IV);
                            userLog.UserUpdatePass(cipherpass, ciphercode, myAes.Key, myAes.IV);
                            UserCache.UserPass = rsa.GetMd5Hash(txtpass.Text);
                            Console.WriteLine("CHANGEPASSWORD/Actualizar a " + txtpass + "=" + UserCache.UserPass);
                            this.Close();
                        }
                    }
                    else
                    {
                        MsgError("No coinciden las contraseñas");
                    }
                }
                else
                {
                    MsgError("Ingrese la confirmación de la nueva contraseña");
                }
                
            }
            else
            {
                MsgError("Ingrese la nueva contraseña");
            }
            
        }
        //revisar e4sta validacion que no compara bien los txt
        private bool IsEqualsPass()
        {
            if (txtpass.Text==txtpassconf.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        private void MsgError(string msg)
        {
            lblErrorMessage.Text = "      " + msg;
            lblErrorMessage.Visible = true;
        }

        private void Txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text.Equals("CONTRASEÑA"))
            {
                txtpass.Clear();
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void Txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text.Equals(""))
            {
                txtpass.UseSystemPasswordChar = false;
                txtpass.Text = "CONTRASEÑA";
            }
        }

        private void Txtpassconf_Enter(object sender, EventArgs e)
        {
            if (txtpassconf.Text.Equals("CONFIRME LA CONTRASEÑA"))
            {
                txtpassconf.Clear();
                txtpassconf.UseSystemPasswordChar = true;
            }
        }

        private void Txtpassconf_Leave(object sender, EventArgs e)
        {
            if (txtpassconf.Text.Equals(""))
            {
                txtpassconf.UseSystemPasswordChar = false;
                txtpassconf.Text = "CONFIRME LA CONTRASEÑA";
            }
        }
    }
}
