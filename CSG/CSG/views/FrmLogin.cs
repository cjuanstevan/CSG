using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CSG.logic;
using CSG.cryptography;
using System.Security.Cryptography;

namespace CSG.views
{
    public partial class FrmLogin : Form
    {
        //Create a UnicodeEncoder to convert between byte array and string.
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        private readonly UserLog userLog = new UserLog();
        public FrmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text.Equals("USUARIO"))
            {
                txtuser.Clear();
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void Txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text.Equals(""))
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void Txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text.Equals("CONTRASEÑA"))
            {
                txtpass.Clear();
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void Txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text.Equals(""))
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text!="USUARIO")
            {
                if (txtpass.Text!="CONTRASEÑA")
                {
                    // Create a new instance of the AesManaged
                    // class.  This generates a new key and initialization
                    // vector (IV).
                    using (AesManaged myAes = new AesManaged())
                    {
                        var rsa = new cryptography.SystemSupportRSA();

                        // Encrypt the string to an array of bytes.
                        byte[] user_encrypted = rsa.EncryptStringToBytes_Aes(txtuser.Text, myAes.Key, myAes.IV);
                        byte[] pass_encrypted = rsa.EncryptStringToBytes_Aes(txtpass.Text, myAes.Key, myAes.IV);

                        //Iniciamos sesión
                        if (userLog.UserLogin(user_encrypted,pass_encrypted,myAes.Key,myAes.IV))
                        {
                            FrmDashboard dashboard = new FrmDashboard();
                            dashboard.Show();
                            dashboard.FormClosed += Logout;
                            this.Hide();
                        }
                        else
                        {
                            MsgError("Usuario y/o contraseña incorrectos");
                        }
                    }
                }
                else
                {
                    MsgError("Digite contraseña");
                    //txtpass.Focus();
                }
            }
            else
            {
                MsgError("Digite usuario");
                //txtuser.Focus();
            }
        }

        private void MsgError(string msg)
        {
            lblErrorMessage.Text = "      " + msg;
            lblErrorMessage.Visible = true;
        }

        private void Logout(object sender,FormClosedEventArgs e)
        {
            Console.WriteLine("Evento: " + e.CloseReason);
            txtuser.Clear();
            txtpass.Clear();
            lblErrorMessage.Visible = false;
            this.Show();
            txtuser.Focus();
            txtpass.UseSystemPasswordChar = false;
            txtpass.ForeColor = Color.DimGray;
            txtpass.Text = "CONTRASEÑA";
        }

        private void Linkrecoveryaccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRecoveryAccount recoveryAccount = new FrmRecoveryAccount();
            recoveryAccount.ShowDialog();
        }
    }
}
