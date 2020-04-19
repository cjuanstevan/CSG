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


namespace CSG.views
{
    public partial class FrmClient : Form
    {
        private readonly ClientLog clientLog = new ClientLog();
        public FrmClient()
        {
            InitializeComponent();
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            DgvClient.DataSource = clientLog.ReadAll();
            DgvClient.Columns[0].HeaderText = "Identidad";
            DgvClient.Columns[1].HeaderText = "Nombres";
            DgvClient.Columns[2].HeaderText = "P. apellido";
            DgvClient.Columns[3].HeaderText = "S. apellido";
            DgvClient.Columns[4].HeaderText = "Dirección";
            DgvClient.Columns[5].HeaderText = "Barrio";
            DgvClient.Columns[6].HeaderText = "Ciudad";
            DgvClient.Columns[7].HeaderText = "Departamento";
            DgvClient.Columns[8].HeaderText = "Teléfono 1";
            DgvClient.Columns[9].HeaderText = "Teléfono 2";
            DgvClient.Columns[10].HeaderText = "Correo";
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            BtnReadAll_Click(sender, e);
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
                    CleanFields();
                    clientLog.Create(client);
                    BtnReadAll_Click(sender, e);
                }
                else if (btnCreate.Text.Equals("Guardar"))
                {
                    //Guardamos
                    Client client = new Client(txtId.Text, txtName.Text, txtLastname1.Text, txtLastname2.Text,
                     txtAddress.Text, txtLocation.Text, txtCity.Text, txtDepartment.Text, txtTel1.Text, txtTel2.Text, txtEmail.Text);
                    CleanFields();
                    clientLog.Update(client);
                    BtnReadAll_Click(sender, e);
                    //cambiamos botones
                    btnCreate.Text = "Crear";
                    BtnDelete.Enabled = false;
                }

            }
        }
        //métodos locales
        private void CleanFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtLastname1.Clear();
            txtLastname2.Clear();
            txtAddress.Clear();
            txtLocation.Clear();
            txtCity.Clear();
            txtDepartment.Clear();
            txtTel1.Clear();
            txtTel2.Clear();
            txtEmail.Clear();
            txtId.Focus();
            txtId.ReadOnly = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                DialogResult dr = MessageBox.Show("¿Desea eliminar el cliente " + txtId.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Eliminamos
                    clientLog.Delete(txtId.Text);
                    //habilita botones
                    BtnDelete.Enabled = false;
                    btnCreate.Text = "Crear";
                    //Limpiamos campos
                    CleanFields();
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.ReadOnly = true;
            btnCreate.Text = "Guardar";
            BtnDelete.Enabled = true;
            txtId.Text = DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = DgvClient.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastname1.Text = DgvClient.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtLastname2.Text = DgvClient.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAddress.Text = DgvClient.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtLocation.Text = DgvClient.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCity.Text = DgvClient.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDepartment.Text = DgvClient.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTel1.Text = DgvClient.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtTel2.Text = DgvClient.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtEmail.Text = DgvClient.Rows[e.RowIndex].Cells[10].Value.ToString();
            //Console.WriteLine("COLUMN: " + e.ColumnIndex);
            //MessageBox.Show("Id: " + DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
