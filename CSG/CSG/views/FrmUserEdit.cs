using CSG.cache;
using CSG.logic;
using CSG.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSG.views
{
    public partial class FrmUserEdit : Form, IMsgMethod
    {
        private readonly UserLog userLog = new UserLog();
        public FrmUserEdit()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = true;
        }

        private void FrmUserEdit_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {        
            //Labels
            lblUsername.Text = UserCache.UserDefinition;
            lblAccount.Text = UserCache.UserAccount;
            lblEmail.Text = UserCache.UserEmail;
            lblRol.Text = UserCache.UserRolDefinition;
            //Textbox
            txtusername.Text = UserCache.UserDefinition;
            txtuser.Text = UserCache.UserAccount;
            txtemail.Text = UserCache.UserEmail;
            //txtpass1.Text = UserCache.UserPass;
            //txtpass2.Text= UserCache.UserPass;
        }

        private void LinkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelEdit.Visible = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = true;
            
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            var rsa = new cryptography.SystemSupportRSA();
            //Validamos que la contraseña actual coincida(OK)

            //validamos que escriba las dos contraseñas
            if (!txtpass1.Text.Equals("") && !txtpass2.Text.Equals(""))
            {
                //Validamos que coincidan las dos contraseñas
                if (txtpass1.Text.Equals(txtpass2.Text))
                {
                    MessageBox.Show("Coinciden");
                    User user = new User()
                    {
                        User_definition = txtusername.Text,
                        User_email = txtemail.Text,
                        User_password = rsa.GetMd5Hash(txtpass1.Text),
                        User_code = UserCache.UserCode
                    };
                    userLog.UserUpdate(user);
                    FrmUserEdit_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("No coinciden las contraseñas");
                }
            }
            else
            {
                MessageBox.Show("Escriba ambas contraseñas");
            }
            

        }

        private void LinkPassChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Abrimos el validador de la contraseña
            PassValidate();
        }

        private void PassValidate()
        {
            CdoPassValidate passValidate = new CdoPassValidate();
            passValidate.msg = this;
            passValidate.ShowDialog();
        }

        public void txtpassActivator()
        {
            Console.WriteLine("Limpiamos y activamos el txtpass1 y 2");
            txtpass1.Enabled = true;
            txtpass2.Enabled = true;
            //txtCurrenPass.Enabled = true;
            txtpass1.Clear();
            txtpass2.Clear();
            txtpass1.Focus();
        }
    }
}
