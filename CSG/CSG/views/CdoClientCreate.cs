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
    public partial class CdoClientCreate : Form
    {
        private readonly ClientLog clientLog = new ClientLog();

        public CdoClientCreate()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (!txtId.Text.Equals(""))
            {
                Client client = new Client
                {
                    Client_id = txtId.Text,
                    Client_name = txtName.Text,
                    //Client_lastname1 = txtLastname1.Text,
                    //Client_lastname2 = txtLastname2.Text,
                    Client_address = txtAddress.Text,
                    Client_city = txtCity.Text,
                    Client_department = txtDepartment.Text,
                    Client_tel1 = txtTel1.Text,
                    Client_email = txtEmail.Text
                };
                clientLog.Create(client);
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
