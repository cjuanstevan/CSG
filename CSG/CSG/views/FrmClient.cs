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
        private readonly DepartmentLog departmentLog = new DepartmentLog();
        private readonly MunicipalityLog municipalityLog = new MunicipalityLog();
        public FrmClient()
        {
            InitializeComponent();
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            DgvClient.DataSource = clientLog.ReadAll();
            CreateHeaders();
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            txtId.Focus();
            //BtnReadAll_Click(sender, e);
            cboTypeClient.SelectedIndex = 0;
            //gpNatural.Visible = false;
            LoadCboDpts();
        }
        private void LoadCboDpts()
        {
            List<string> dpts = departmentLog.Read_all_names();
            foreach (var d in dpts)
            {
                cboDptoJ.Items.Add(d);
                cboDptoN.Items.Add(d);
            }

            
        }

        private void MsgWarning(string msg)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "        " + msg;
        }
        private bool DataValidateJuridic()
        {
            if (txtNit.Text.Equals(""))
            {
                MsgWarning("Ingrese NIT");
                txtNit.Focus();
                return false;
            }
            if (txtRut.Text.Equals(""))
            {
                MsgWarning("Ingrese RUT");
                txtRut.Focus();
                return false;
            }
            if (txtTradename.Text.Equals(""))
            {
                MsgWarning("Ingrese el nombre comercial");
                txtTradename.Focus();
                return false;
            }
            if (cboLestruct.Text.Equals(""))
            {
                MsgWarning("Seleccione la estructura jurídica");
                cboLestruct.Focus();
                return false;
            }
            if (txtRlegal.Text.Equals(""))
            {
                MsgWarning("Ingrese el nombre del representante legal");
                txtRlegal.Focus();
                return false;
            }
            if (txtAdmin.Text.Equals(""))
            {
                MsgWarning("Ingrese el nombre del administrador");
                txtAdmin.Focus();
                return false;
            }
            if (txtTel1.Text.Equals(""))
            {
                MsgWarning("Ingrese el número telefónico del administrador");
                txtTel1.Focus();
                return false;
            }
            if (cboDptoJ.Text.Equals(""))
            {
                MsgWarning("Seleccione el departamento");
                cboDptoJ.Focus();
                return false;
            }
            if (cboCityJ.Text.Equals(""))
            {
                MsgWarning("Seleccione la ciudad o municipio");
                cboCityJ.Focus();
                return false;
            }
            if (txtAddresJ.Text.Equals(""))
            {
                MsgWarning("Ingrese la dirección");
                txtAddresJ.Focus();
                return false;
            }
            if (txtEmailJ.Text.Equals(""))
            {
                MsgWarning("Ingrese el correo electrónico");
                txtEmailJ.Focus();
                return false;
            }
            return true;
        }

        private bool DataValidateNatural()
        {
            if (txtId.Text.Equals(""))
            {
                MsgWarning("Ingrese el número de identificación");
                txtId.Focus();
                return false;
            }
            if (txtName.Text.Equals(""))
            {
                MsgWarning("Ingrese el nombre");
                txtName.Focus();
                return false;
            }
            if (txtLastname1.Text.Equals(""))
            {
                MsgWarning("Ingrese el primero apellido");
                txtLastname1.Focus();
                return false;
            }
            if (txtLastname2.Text.Equals(""))
            {
                MsgWarning("Ingrese el segundo apellido");
                txtLastname2.Focus();
                return false;
            }
            if (cboDptoN.Text.Equals(""))
            {
                MsgWarning("Seleccione el departamento");
                cboDptoN.Focus();
                return false;
            }
            if (cboCityN.Text.Equals(""))
            {
                MsgWarning("Seleccione la ciudad o municipio");
                cboCityN.Focus();
                return false;
            }
            if (txtAddresN.Text.Equals(""))
            {
                MsgWarning("Ingrese la dirección de domicilio");
                txtAddresN.Focus();
                return false;
            }
            if (txtTel.Text.Equals(""))
            {
                MsgWarning("Ingrese el número telefónico");
                txtTel.Focus();
                return false;
            }
            if (txtEmailN.Text.Equals(""))
            {
                MsgWarning("Ingrese el correo electrónico");
                txtEmailN.Focus();
                return false;
            }
            return true;
        }
        private void IbtnCreate_Click(object sender, EventArgs e)
        {
            
            //validamos el tipo de accion del boton
            if (IbtnCreate.Text.Equals("Crear"))
            {
                //Client client = new Client(txtId.Text, txtName.Text, txtLastname1.Text, txtLastname2.Text,
                //txtAddress.Text, txtLocation.Text, txtCity.Text, txtDepartment.Text, txtTel1.Text, txtTel2.Text, txtEmail.Text);
                //CleanFields();
                //clientLog.Create(client);
                //BtnReadAll_Click(sender, e);
                //Si tipo empresa
                if (cboTypeClient.SelectedIndex.Equals(0))
                {
                    //validamos los datos de Empresa
                    if (DataValidateJuridic())
                    {
                        //creamos el objeto
                        Client client = new Client(txtNit.Text, txtTradename.Text, txtAddresJ.Text, txtLocationJ.Text,
                            cboCityJ.Text, cboDptoJ.Text, txtTel1.Text, txtTel2.Text, txtEmailJ.Text,
                            txtRut.Text, txtRlegal.Text, txtAdmin.Text, txtWebsite.Text, txtPostal.Text,
                            txtFax.Text, cboLestruct.Text, 'j');
                        CleanFields();
                        clientLog.Create(client);
                        BtnReadAll_Click(sender, e);
                    }
                }
                //Si tipo natural
                else if (cboTypeClient.SelectedIndex.Equals(1))
                {
                    if (DataValidateNatural())
                    {
                        //creamos objeto
                        Client client = new Client(txtId.Text, txtName.Text, txtLastname1.Text, txtLastname2.Text,
                            txtAddresN.Text, "predeterminado", cboCityN.Text, cboDptoN.Text, txtTel.Text,
                            txtEmailN.Text, 'n');
                        CleanFields();
                        clientLog.Create(client);
                        BtnReadAll_Click(sender, e);
                    }
                }
            }



            //if (txtId.Text.Equals(""))
            //{
            //    MessageBox.Show("El Id es obligatorio");
            //    txtId.Focus();
            //}
            //else
            //{
            //    //validamos el tipo de accion del boton
            //    if (IbtnCreate.Text.Equals("Crear"))
            //    {
            //        //Client client = new Client(txtId.Text, txtName.Text, txtLastname1.Text, txtLastname2.Text,
            //        //txtAddress.Text, txtLocation.Text, txtCity.Text, txtDepartment.Text, txtTel1.Text, txtTel2.Text, txtEmail.Text);
            //        //CleanFields();
            //        //clientLog.Create(client);
            //        //BtnReadAll_Click(sender, e);
            //    }
            //    else if (IbtnCreate.Text.Equals("Guardar"))
            //    {
            //        ////Guardamos
            //        //Client client = new Client(txtId.Text, txtName.Text, txtLastname1.Text, txtLastname2.Text,
            //        // txtAddress.Text, txtLocation.Text, txtCity.Text, txtDepartment.Text, txtTel1.Text, txtTel2.Text, txtEmail.Text);
            //        //CleanFields();
            //        //clientLog.Update(client);
            //        //BtnReadAll_Click(sender, e);
            //        ////cambiamos botones
            //        //btnCreate.Text = "Crear";
            //        //BtnDelete.Enabled = false;
            //    }

            //}
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
                        IbtnCreate.Text = "Guardar";
                        //Llenamos los campos.
                        txtId.Text = client.Client_id;
                        txtName.Text = client.Client_name;
                        txtLastname1.Text = client.Client_lastname1;
                        txtLastname2.Text = client.Client_lastname2;
                        //txtAddress.Text = client.Client_address;
                        txtLocationJ.Text = client.Client_location;
                        txtAddresN.Text = client.Client_city;
                        //txtDepartment.Text = client.Client_department;
                        txtTel.Text = client.Client_tel1;
                        txtTel1.Text = client.Client_tel2;
                        txtEmailN.Text = client.Client_email;
                    }
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
            //txtAddress.Clear();
            txtLocationJ.Clear();
            txtAddresN.Clear();
            //txtDepartment.Clear();
            txtTel.Clear();
            txtTel1.Clear();
            txtEmailN.Clear();
            txtId.Focus();
            txtId.ReadOnly = false;
        }

        

        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.ReadOnly = true;
                IbtnCreate.Text = "Guardar";
                IbtnDelete.Enabled = true;
                IbtnNew.Enabled = true;
                txtId.Text = DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = DgvClient.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLastname1.Text = DgvClient.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLastname2.Text = DgvClient.Rows[e.RowIndex].Cells[3].Value.ToString();
                //txtAddress.Text = DgvClient.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtLocationJ.Text = DgvClient.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtAddresN.Text = DgvClient.Rows[e.RowIndex].Cells[6].Value.ToString();
                //txtDepartment.Text = DgvClient.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtTel.Text = DgvClient.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtTel1.Text = DgvClient.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtEmailN.Text = DgvClient.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
        }

        //private bool VerificaContenido(DataGridView gridView)
        //{
        //    bool bcampo = false;
        //    if (gridView.RowCount > 0)
        //    {
                
        //        foreach (DataGridViewRow dr in gridView.Rows)
        //        {
        //            foreach (DataGridViewCell dc in dr.Cells)
        //            {
        //                if (dc.Value == null || string.IsNullOrEmpty(dc.Value.ToString()))
        //                {
        //                    bcampo = true;
        //                }
        //            }
        //        }
        //    }
        //    return bcampo;
        //}

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            DgvClient.DataSource = clientLog.Read_all_like(txtSearch.Text);
            CreateHeaders();
        }

        //Metodos de interfaz
        private void CreateHeaders()
        {
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            IbtnNew.Enabled = false;
            IbtnCreate.Text = "Crear";
            IbtnDelete.Enabled = false;
            CleanFields();
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        private void BtnReadAll_Click_1(object sender, EventArgs e)
        {
            DgvClient.Columns.Clear();
            DgvClient.DataSource = clientLog.ReadAll();
            CreateHeaders();
        }

        private void CboTypeClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTypeClient.SelectedIndex.Equals(0))
            {
                gpJuridic.Visible = true;
                gpNatural.Visible = false;
                gpJuridic.Location = new Point(11, 56);
            }
            else if (cboTypeClient.SelectedIndex.Equals(1))
            {
                gpJuridic.Visible = false;
                gpNatural.Visible = true;
            }
        }

        private void IbtnNew_Click(object sender, EventArgs e)
        {
            IbtnNew.Enabled = false;
            IbtnCreate.Text = "Crear";
            IbtnDelete.Enabled = false;
            CleanFields();
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        

        private void IbtnDelete_Click(object sender, EventArgs e)
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
                    IbtnDelete.Enabled = false;
                    IbtnCreate.Text = "Crear";
                    //Limpiamos campos
                    CleanFields();
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void CboDptoJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCityJ.Text = "";
            cboCityJ.Items.Clear();
            //Console.WriteLine("index: {0} | index+1: {1}",cboDptoJ.SelectedIndex, cboDptoJ.SelectedIndex + 1);
            List<Municipality> municipalities = municipalityLog.Read_mnps_of_dpt(byte.Parse((cboDptoJ.SelectedIndex + 1).ToString()));
            foreach (var m in municipalities)
            {
                cboCityJ.Items.Add(m.Name);
            }
        }

        private void CboDptoN_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCityN.Text = "";
            cboCityN.Items.Clear();
            //Console.WriteLine("index: {0} | index+1: {1}", cboDptoJ.SelectedIndex, cboDptoJ.SelectedIndex + 1);
            List<Municipality> municipalities = municipalityLog.Read_mnps_of_dpt(byte.Parse((cboDptoN.SelectedIndex + 1).ToString()));
            foreach (var m in municipalities)
            {
                cboCityN.Items.Add(m.Name);
            }
        }
    }
}
