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
        //Tabla
        private DataTable dtc = new DataTable();
        private DataColumn column;
        private DataRow row;
        public FrmClient()
        {
            InitializeComponent();
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            txtId.Focus();
            //BtnReadAll_Click(sender, e);
            cboTypeClient.SelectedIndex = 0;
            //gpNatural.Visible = false;
            LoadCboDpts();
            ConstructTable();
        }
        private void ConstructTable()
        {
            CreateDataTable();
            List<Client> clients = clientLog.ReadAll();
            LoadDataTable(clients);
        }
        private void LoadDataTable(List<Client> clients)
        {
            foreach (var c in clients)
            {
                if (c.Client_type.Equals('j'))
                {
                    row = dtc.NewRow();
                    row[0] = c.Client_id;
                    row[1] = c.Client_name;
                    row[2] = c.Client_city;
                    row[3] = c.Client_department;
                    row[4] = c.Client_address;
                    row[5] = c.Client_tel1;
                    row[6] = c.Client_email;
                    row["ACCIONES"] = "VER";
                    dtc.Rows.Add(row);
                }
                else if (c.Client_type.Equals('n'))
                {
                    row = dtc.NewRow();
                    row[0] = c.Client_id;
                    row[1] = c.Client_name + " " + c.Client_lastname1 + " " + c.Client_lastname2;
                    row[2] = c.Client_city;
                    row[3] = c.Client_department;
                    row[4] = c.Client_address;
                    row[5] = c.Client_tel1;
                    row[6] = c.Client_email;
                    row["ACCIONES"] = "VER";
                    dtc.Rows.Add(row);
                }
            }
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                DataPropertyName = "ACCIONES",
                Text = "Ver",
                HeaderText = "ACCIONES",
                FlatStyle = FlatStyle.Standard
            };
            DgvClient.Columns.AddRange(buttonColumn);
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
                        CleanFieldsJ();
                        clientLog.Create(client);
                        IbtnRefresh_Click(sender, e);
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
                        CleanFieldsN();
                        clientLog.Create(client);
                        IbtnRefresh_Click(sender, e);
                    }
                }
            }
            else if (IbtnCreate.Text.Equals("Editar"))
            {
                //cambiamos el ícono y texto a 'Guardar'
                this.IbtnCreate.IconChar = FontAwesome.Sharp.IconChar.Save;
                this.IbtnCreate.Text = "Guardar";
                //Habilitamos los controles
                txtNit.ReadOnly = true;
                txtRut.ReadOnly = false;
                txtTradename.ReadOnly = false;
                cboLestruct.Enabled = true;
                txtRlegal.ReadOnly = false;
                txtAdmin.ReadOnly = false;
                txtTel1.ReadOnly = false;
                txtFax.ReadOnly = false;
                txtPostal.ReadOnly = false;
                txtWebsite.ReadOnly = false;
                cboDptoJ.Enabled = true;
                cboCityJ.Enabled = true;
                txtAddresJ.ReadOnly = false;
                txtLocationJ.ReadOnly = false;
                txtEmailJ.ReadOnly = false;
                txtTel2.ReadOnly = false;
            }
            else if (IbtnCreate.Text.Equals("Guardar"))
            {
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
                        CleanFieldsJ();
                        clientLog.Update(client);
                        BtnReadAll_Click(sender, e);
                        //cambiamos botones
                        IbtnCreate.Text = "Crear";
                        IbtnDelete.Enabled = false;
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

        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Cambiamos el ícono
                this.IbtnCreate.IconChar = FontAwesome.Sharp.IconChar.Edit;
                IbtnCreate.Text = "Editar";
                IbtnDelete.Enabled = true;
                IbtnNew.Enabled = true;
                //Consultamos el cliente para saber el tipo(Se puede hace funcion que traiga el char j o n
                Client client = clientLog.Read_once(DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString());
                //Si tipo J->mostramos el formulario de cliente juridico
                if (client.Client_type.Equals('j'))
                {
                    //Inhabilitamos controles para ver la informacion solamente
                    txtNit.ReadOnly = true;
                    txtRut.ReadOnly = true;
                    txtTradename.ReadOnly = true;
                    cboLestruct.Enabled = false;
                    txtRlegal.ReadOnly = true;
                    txtAdmin.ReadOnly = true;
                    txtTel1.ReadOnly = true;
                    txtFax.ReadOnly = true;
                    txtPostal.ReadOnly = true;
                    txtWebsite.ReadOnly = true;
                    cboDptoJ.Enabled = false;
                    cboCityJ.Enabled = false;
                    txtAddresJ.ReadOnly = true;
                    txtLocationJ.ReadOnly = true;
                    txtEmailJ.ReadOnly = true;
                    txtTel2.ReadOnly = true;
                    //Cambiamos el tipo a jurídico
                    cboTypeClient.SelectedIndex = 0;
                    gpJuridic.BringToFront();
                    //Cargamos el formulario
                    txtNit.Text = client.Client_id;
                    txtRut.Text = client.Client_rut;
                    txtTradename.Text = client.Client_name;
                    cboLestruct.Text = client.Client_lstructure;
                    txtRlegal.Text = client.Client_rlegal;
                    txtAdmin.Text = client.Client_adm;
                    txtTel1.Text = client.Client_tel1;
                    txtFax.Text = client.Client_fax;
                    txtWebsite.Text = client.Client_website;
                    cboDptoJ.Text = client.Client_department;
                    cboCityJ.Text = client.Client_city;
                    txtAddresJ.Text = client.Client_address;
                    txtLocationJ.Text = client.Client_location;
                    txtEmailJ.Text = client.Client_email;
                    txtTel2.Text = client.Client_tel2;

                }
                //Si tipo N->mostramos el formulario de cliente natural
                else if (client.Client_type.Equals('n'))
                {
                    cboTypeClient.SelectedIndex = 1;
                    gpNatural.BringToFront();
                    txtId.Text = client.Client_id;
                    txtName.Text = client.Client_name;
                    txtLastname1.Text = client.Client_lastname1;
                    txtLastname2.Text = client.Client_lastname2;
                    cboDptoN.Text = client.Client_department;
                    cboCityN.Text = client.Client_city;
                    txtAddresN.Text = client.Client_address;
                    txtTel.Text = client.Client_tel1;
                    txtEmailN.Text = client.Client_email;
                    txtId.ReadOnly = true;
                }
            }
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
        private void TxtNit_Leave(object sender, EventArgs e)
        {
            if (!txtNit.Text.Equals(""))
            {
                bool response = clientLog.Read_once_exist(txtNit.Text);
                if (response)
                {
                    DialogResult dr = MessageBox.Show("El cliente jurídico que intenta crear ya existe. ¿Desea cargar la información en el formulario?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //Consultamos el cliente con el Id como parametro.
                        Client client = clientLog.Read_once(txtNit.Text);
                        //Desactivamos los campos ineditables.
                        txtNit.Enabled = false;
                        //Cambiamos el tipo de accion del boton
                        IbtnCreate.Text = "Guardar";
                        //Llenamos los campos.
                        txtNit.Text = client.Client_id;
                        txtRut.Text = client.Client_rut;
                        txtTradename.Text = client.Client_name;
                        cboLestruct.Text = client.Client_lstructure;
                        txtRlegal.Text = client.Client_rlegal;
                        txtAdmin.Text = client.Client_adm;
                        txtTel1.Text = client.Client_tel1;
                        txtFax.Text = client.Client_fax;
                        txtPostal.Text = client.Client_postal;
                        txtWebsite.Text = client.Client_website;
                        cboDptoJ.Text = client.Client_department;
                        cboCityJ.Text = client.Client_city;
                        txtAddresJ.Text = client.Client_address;
                        txtLocationJ.Text = client.Client_location;
                        txtEmailJ.Text = client.Client_email;
                        txtTel2.Text = client.Client_tel2;
                    }
                    else
                    {
                        txtNit.Clear();
                        txtNit.Focus();
                    }
                }
            }
        }

        //métodos locales
        private void CleanFieldsN()
        {
            txtId.Clear();
            txtName.Clear();
            txtLastname1.Clear();
            txtLastname2.Clear();
            cboDptoN.Items.Clear();
            cboCityN.Items.Clear();
            txtAddresN.Clear();
            txtTel.Clear();
            txtEmailN.Clear();
            txtId.Focus();
            txtId.ReadOnly = false;
        }

        private void CleanFieldsJ()
        {
            txtNit.Clear();
            txtRut.Clear();
            txtTradename.Clear();
            cboLestruct.Dispose();
            txtRlegal.Clear();
            txtAdmin.Clear();
            txtTel1.Clear();
            txtFax.Clear();
            txtPostal.Clear();
            txtWebsite.Clear();
            cboDptoJ.Items.Clear();
            cboCityJ.Items.Clear();
            txtAddresJ.Clear();
            txtLocationJ.Clear();
            txtEmailJ.Clear();
            txtTel2.Clear();
            txtNit.Focus();
            txtNit.ReadOnly = false;
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
            CleanFieldsN();
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        private void BtnReadAll_Click_1(object sender, EventArgs e)
        {
            
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
            CleanFieldsN();
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
                    CleanFieldsN();
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
        //Crea la estructura de la tabla en memoria
        private void CreateDataTable()
        {
            //Columna 1->ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ID/NIT",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtc.Columns.Add(column);
            // Columna 2->Cliente
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CLIENTE",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 3->CIUDAD O MUNICIPIO
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CIUDAD/MUNICIPIO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 4->departamento
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DEPARTAMENTO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 5->Dirección
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DIRECCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 6->Teléfono
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TELÉFONO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 7->CORREO
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CORREO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 8->Acciones.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ACCIONES",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false,
                Namespace = "ACCIONES"
            };
            dtc.Columns.Add(column);
            DgvClient.DataSource = dtc;
            DgvClient.Columns.RemoveAt(7);
        }

        private void IbtnRefresh_Click(object sender, EventArgs e)
        {
            dtc = new DataTable();
            ConstructTable();
        }
    }
}
