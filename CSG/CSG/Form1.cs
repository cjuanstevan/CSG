using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.model;
using CSG.logic;

namespace CSG
{
    public partial class Form1 : Form
    {
        private readonly ClientLog clientLog = new ClientLog();
        public Form1()
        {
            InitializeComponent();
        }

        private void TxtId_Leave(object sender, EventArgs e)
        {
            if (!txtId.Text.Equals(""))
            {
                bool response = clientLog.Read_once_exist(txtId.Text);
                if (response)
                {
                    DialogResult dr = MessageBox.Show("El cliente que intenta crear ya existe. ¿Desea cargar la información en el formulario?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //Consultamos el cliente con el Id como parametro.
                        Client client = clientLog.Read_once(txtId.Text);
                        //Desactivamos los campos ineditables.
                        txtId.Enabled = false;
                        //Cambiamos el tipo de accion del boton
                        btnCreate.Text = "Guardar";
                        //Llenamos los campos.
                        txtId.Text = client.Client_id;
                        txtName.Text = client.Client_name;
                        txtLastname1.Text = client.Client_lastname1;
                        txtLastname2.Text = client.Client_lastname2;
                        txtAddress.Text = client.Client_address;
                        txtLocation.Text = client.Client_location;
                        txtCity.Text = client.Client_city;
                        txtDepartment.Text = client.Client_department;
                        txtTel1.Text = client.Client_tel1;
                        txtTel2.Text = client.Client_tel2;
                        txtEmail.Text = client.Client_email;
                    }
                }
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Equals(""))
            {
                MessageBox.Show("El Id es obligatorio");
                txtId.Focus();
            }
            else
            {
                //validamos el tipo de accion del boton
                if (btnCreate.Text.Equals("Crear"))
                {
                    Client client = new Client(txtId.Text, txtName.Text, txtLastname1.Text, txtLastname2.Text,
                    txtAddress.Text, txtLocation.Text, txtCity.Text, txtDepartment.Text, txtTel1.Text, txtTel2.Text, txtEmail.Text);
                    clientLog.Create(client);
                }
                else if (btnCreate.Text.Equals("Guardar"))
                {
                    MessageBox.Show("Guardamos");
                    //Ejecutamos el Update
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servicio_Tecnico servicio_Tecnico = new Servicio_Tecnico();
            servicio_Tecnico.Show();
        }
    }
}
