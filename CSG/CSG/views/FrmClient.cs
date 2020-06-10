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
using CSG.validator;
using CSG.cache;


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
        //
        private string stateButtonJ = "Crear";
        private string stateButtonN = "Crear";
        public FrmClient()
        {
            InitializeComponent();
        }
        //Evento LOAD del formulario
        private void FrmClient_Load(object sender, EventArgs e)
        {
            txtId.Focus();
            //BtnReadAll_Click(sender, e);
            cboTypeClient.SelectedIndex = 0;
            //gpNatural.Visible = false;
            LoadCboDpts();
            //ConstructTable();
        }
        private void ConstructTable()
        {
            CreateDataTable();
            List<Client> clients = clientLog.ReadAll();
            LoadDataTable(clients);
        }
        //Método que carga una lista de clientes en los rows de DataTable y los agrega a la GridView
        private void LoadDataTable(List<Client> clients)
        {
            foreach (var c in clients)
            {
                //Console.WriteLine("lista(tipo): " + c.Client_type);
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
                    row["ACCIONES"] = "";
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
                    row["ACCIONES"] = "";
                    dtc.Rows.Add(row);
                }
            }
            //Imagen en columna

            //Boton en columna
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                DataPropertyName = "ACCIONES",
                Text = "",
                HeaderText = "ACCIONES",
                FlatStyle = FlatStyle.Standard
            };
            DgvClient.Columns.AddRange(buttonColumn);
        }
        //Método que carga el combo de Departamentos en los dos formularios(J & N)
        private void LoadCboDpts()
        {
            cboDptoJ.Items.Clear();
            cboDptoN.Items.Clear();
            List<string> dpts = departmentLog.Read_all_names();
            foreach (var d in dpts)
            {
                cboDptoJ.Items.Add(d);
                cboDptoN.Items.Add(d);
            }

            
        }
        //Muestra un mensaje de 3 segundos en el formulario
        private void MsgRequest(string msg)
        {
            if (lblMsg.Visible == false)
            {
                lblMsg.Visible = true;
                IpbCloseMsg.Visible = true;
                timerMsg.Start();
                lblMsg.Text = "        " + msg;
            }
            //lblMsg.Visible = true;
            
        }
        //Valida los campos obligatorios de juridico
        private bool DataValidateJuridic()
        {
            if (txtNit.Text.Equals(""))
            {
                //MsgWarning("Ingrese NIT");
                txtNit.Focus();
                errorProvider1.SetError(txtNit, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtRut.Text.Equals(""))
            {
                //MsgWarning("Ingrese RUT");
                txtRut.Focus();
                errorProvider1.SetError(txtRut, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtTradename.Text.Equals(""))
            {
                //MsgWarning("Ingrese el nombre comercial");
                txtTradename.Focus();
                errorProvider1.SetError(txtTradename, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (cboLestruct.Text.Equals(""))
            {
                //MsgRequest("Seleccione la estructura jurídica");
                cboLestruct.Focus();
                errorProvider1.SetError(cboLestruct, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtRlegal.Text.Equals(""))
            {
                //MsgRequest("Ingrese el nombre del representante legal");
                txtRlegal.Focus();
                errorProvider1.SetError(txtRlegal, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtAdmin.Text.Equals(""))
            {
                //MsgWarning("Ingrese el nombre del administrador");
                txtAdmin.Focus();
                errorProvider1.SetError(txtAdmin, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtTel1.Text.Equals(""))
            {
                //MsgWarning("Ingrese el número telefónico del administrador");
                txtTel1.Focus();
                errorProvider1.SetError(txtTel1, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (cboDptoJ.Text.Equals(""))
            {
                //MsgWarning("Seleccione el departamento");
                cboDptoJ.Focus();
                errorProvider1.SetError(cboDptoJ, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (cboCityJ.Text.Equals(""))
            {
                //MsgWarning("Seleccione la ciudad o municipio");
                cboCityJ.Focus();
                errorProvider1.SetError(cboCityJ, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtAddresJ.Text.Equals(""))
            {
                //MsgRequest("Ingrese la dirección");
                txtAddresJ.Focus();
                errorProvider1.SetError(txtAddresJ, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtEmailJ.Text.Equals(""))
            {
                //MsgWarning("Ingrese el correo electrónico");
                txtEmailJ.Focus();
                errorProvider1.SetError(txtEmailJ, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            return true;
        }
        //Valida los campos obligatorios de natural
        private bool DataValidateNatural()
        {
            if (txtId.Text.Equals(""))
            {
                //MsgWarning("Ingrese el número de identificación");
                txtId.Focus();
                errorProvider1.SetError(txtId, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtName.Text.Equals(""))
            {
                //MsgWarning("Ingrese el nombre");
                txtName.Focus();
                errorProvider1.SetError(txtName, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtLastname1.Text.Equals(""))
            {
                //MsgWarning("Ingrese el primero apellido");
                txtLastname1.Focus();
                errorProvider1.SetError(txtLastname1, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (cboDptoN.Text.Equals(""))
            {
                //MsgRequest("Seleccione el departamento");
                cboDptoN.Focus();
                errorProvider1.SetError(cboDptoN, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (cboCityN.Text.Equals(""))
            {
                //MsgWarning("Seleccione la ciudad o municipio");
                cboCityN.Focus();
                errorProvider1.SetError(cboCityN, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtAddresN.Text.Equals(""))
            {
                //MsgRequest("Ingrese la dirección de domicilio");
                txtAddresN.Focus();
                errorProvider1.SetError(txtAddresN, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtTel.Text.Equals(""))
            {
                //MsgWarning("Ingrese el número telefónico");
                txtTel.Focus();
                errorProvider1.SetError(txtTel, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (txtEmailN.Text.Equals(""))
            {
                //MsgWarning("Ingrese el correo electrónico");
                txtEmailN.Focus();
                errorProvider1.SetError(txtEmailN, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            return true;
        }

        //Evento del botón IbtnCreate
        private void IbtnCreate_Click(object sender, EventArgs e)
        {
            //validamos el tipo de accion del boton
            if (IbtnCreate.Text.Equals("Crear"))
            {
                //Si tipo empresa
                if (cboTypeClient.SelectedIndex.Equals(0))
                {
                    //validamos los campos de juridico
                    if (DataValidateJuridic())
                    {
                        //creamos el objeto para jurídico
                        Client client = new Client(txtNit.Text, txtTradename.Text, txtAddresJ.Text, txtLocationJ.Text,
                            cboCityJ.Text, cboDptoJ.Text, txtTel1.Text, txtTel2.Text, txtEmailJ.Text,
                            txtRut.Text, txtRlegal.Text, txtAdmin.Text, txtWebsite.Text, txtPostal.Text,
                            txtFax.Text, cboLestruct.Text, 'j', UserCache.UserAccount,
                            DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), "", 
                            DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        CleanFieldsJ();
                        LoadCboDpts();
                        clientLog.Create(client);
                        MsgRequest("Se ha creado el cliente exitosamente.");
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
                            txtAddresN.Text, cboCityN.Text, cboDptoN.Text, txtTel.Text,
                            txtEmailN.Text, 'n', UserCache.UserAccount, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), "", DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        CleanFieldsN();
                        LoadCboDpts();
                        clientLog.Create(client);
                        MsgRequest("Se ha creado el cliente exitosamente.");
                        IbtnRefresh_Click(sender, e);
                    }
                }
                
            }
            else if (IbtnCreate.Text.Equals("Editar"))
            {
                //cambiamos el ícono y texto a 'Guardar'
                this.IbtnCreate.IconChar = FontAwesome.Sharp.IconChar.Save;
                this.IbtnCreate.Text = "Guardar";
                if (cboTypeClient.SelectedIndex.Equals(0))
                {
                    //Estado interno del boton Crear
                    stateButtonJ = "Guardar";
                    //Habilitamos los controles de jurídico
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
                else if (cboTypeClient.SelectedIndex.Equals(1))
                {
                    //Estado interno del boton Crear
                    stateButtonN = "Guardar";
                    //Habilitamos los controles de natural
                    txtId.ReadOnly = true;
                    txtName.ReadOnly = false;
                    txtLastname1.ReadOnly = false;
                    txtLastname2.ReadOnly = false;
                    cboDptoN.Enabled = true;
                    cboCityN.Enabled = true;
                    txtAddresN.ReadOnly = false;
                    txtTel.ReadOnly = false;
                    txtEmailN.ReadOnly = false;
                }
            }
            else if (IbtnCreate.Text.Equals("Guardar"))
            {
                Console.WriteLine("El boton vale Guardar");
                if (cboTypeClient.SelectedIndex.Equals(0))
                {
                    Console.WriteLine("El combo esta en juridico");
                    //validamos los datos de Empresa
                    bool req = DataValidateJuridic();
                    Console.WriteLine("Req: " + req);
                    if (req)
                    {
                        //creamos el objeto jurídico
                        /*
                         string client_id, string client_name, string client_lastname1, string client_lastname2,
            string client_address, string client_city, string client_department, string client_tel1,
            string client_email, string update_by, DateTime update_date
                         
                         */
                        Console.WriteLine("Se valido la informacion para actuaalizar.");
                        Client client = new Client(txtNit.Text, txtTradename.Text, txtAddresJ.Text, txtLocationJ.Text,
                            cboCityJ.Text, cboDptoJ.Text, txtTel1.Text, txtTel2.Text, txtEmailJ.Text,
                            txtRut.Text, txtRlegal.Text, txtAdmin.Text, txtWebsite.Text, txtPostal.Text,
                            txtFax.Text, cboLestruct.Text, 'j', "",
                            DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), UserCache.UserAccount,
                            DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        CleanFieldsJ();
                        LoadCboDpts();
                        clientLog.Update(client);
                        MsgRequest("Se ha actualizado el cliente.");
                        IbtnRefresh_Click(sender, e);
                        //cambiamos botones
                        IbtnCreate.Text = "Crear";
                        //Estado interno del boton Crear
                        stateButtonJ = "Crear";

                    }
                }
                else if (cboTypeClient.SelectedIndex.Equals(1))
                {

                    if (DataValidateNatural())
                    {
                        //creamos objeto natural
                        Client client = new Client(txtId.Text, txtName.Text, txtLastname1.Text, txtLastname2.Text,
                            txtAddresN.Text, cboCityN.Text, cboDptoN.Text, txtTel.Text,
                            txtEmailN.Text, 'n', "", DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), UserCache.UserAccount, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        CleanFieldsN();
                        LoadCboDpts();
                        clientLog.Update(client);
                        MsgRequest("Se ha actualizado el cliente.");
                        IbtnRefresh_Click(sender, e);
                        //cambiamos botones
                        IbtnCreate.Text = "Crear";
                        //Estado interno del boton Crear
                        stateButtonN = "Crear";
                    }
                }
                //LoadCboDpts();
            }
            //LoadCboDpts();
        }
        
        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                if (DgvClient.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewButtonCell")
                {
                    Console.WriteLine("Eliminar "+ DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el cliente " +
                        Environment.NewLine +
                        DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString() + " | " +
                        DgvClient.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //Eliminamos
                        clientLog.Delete(DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString());
                        //habilita botones
                        IbtnCreate.Text = "Crear";
                        //Limpiamos campos
                        CleanFieldsN();
                        CleanFieldsJ();
                        //Cargamos los deptos
                        LoadCboDpts();
                        //Actualizamos tabla
                        IbtnRefresh_Click(sender, e);
                    }
                }
                else
                {
                    Console.WriteLine("Ver datos en form");
                    //Cambiamos el ícono
                    this.IbtnCreate.IconChar = FontAwesome.Sharp.IconChar.Edit;
                    IbtnCreate.Text = "Editar";
                    IbtnNew.Enabled = true;
                    //Consultamos el cliente para saber el tipo(Se puede hace funcion que traiga el char j o n
                    Client client = clientLog.Read_once(DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //Si tipo J->mostramos el formulario de cliente juridico
                    if (client.Client_type.Equals('j'))
                    {
                        //Estado interno del boton Crear
                        stateButtonJ = "Editar";
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
                        //
                        stateButtonN = "Editar";
                        //Inhabilitamos los controles
                        txtId.ReadOnly = true;
                        txtName.ReadOnly = true;
                        txtLastname1.ReadOnly = true;
                        txtLastname2.ReadOnly = true;
                        cboDptoN.Enabled = false;
                        cboCityN.Enabled = false;
                        txtAddresN.ReadOnly = true;
                        txtTel.ReadOnly = true;
                        txtEmailN.ReadOnly = true;
                        //Cambios el tipo a natural.
                        cboTypeClient.SelectedIndex = 1;
                        gpNatural.BringToFront();
                        //Cargamos la informacion
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
        }

        private void TxtId_Leave(object sender, EventArgs e)
        {
            if (!txtId.Text.Equals("") && stateButtonN.Equals("Crear"))
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
            if (!txtNit.Text.Equals("") && stateButtonJ.Equals("Crear"))
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
            cboLestruct.Items.Clear();
            cboLestruct.Items.Add("S.A");
            cboLestruct.Items.Add("S.A.S");
            cboLestruct.Items.Add("LTDA");
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
            //Limpiamos las rows
            dtc = new DataTable();
            CreateDataTable();
            Console.WriteLine("Busca por: " + txtSearch.Text);
            List<Client> clients = clientLog.Read_all_like(txtSearch.Text);
            Console.WriteLine("Cantidad: " + clients.Count);
            LoadDataTable(clients);
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
                IbtnCreate.Text = stateButtonJ;
            }
            else if (cboTypeClient.SelectedIndex.Equals(1))
            {
                gpJuridic.Visible = false;
                gpNatural.Visible = true;
                IbtnCreate.Text = stateButtonN;
            }
        }

        private void IbtnNew_Click(object sender, EventArgs e)
        {
            IbtnNew.Enabled = false;
            IbtnCreate.Text = "Crear";
            CleanFieldsN();
            txtId.ReadOnly = false;
            txtId.Focus();
            errorProvider1.Clear();
        }

        

        //private void IbtnDelete_Click(object sender, EventArgs e)
        //{
        //    if (txtId.Text != "")
        //    {
        //        DialogResult dr = MessageBox.Show("¿Esta seguro de eliminar el cliente " + Environment.NewLine
        //            + txtId.Text + "?", "Mensaje",
        //                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //        if (dr == DialogResult.Yes)
        //        {
        //            //Eliminamos
        //            clientLog.Delete(txtId.Text);
        //            //habilita botones
        //            IbtnCreate.Text = "Crear";
        //            //Limpiamos campos
        //            CleanFieldsN();
        //            //Actualizamos tabla
        //            IbtnRefresh_Click(sender, e);
        //        }
        //    }
        //}

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

        private void DgvClient_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 7)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.delete.Width;
                var h = Properties.Resources.delete.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextbox.NumericNoSpace(e);
            if (e.Handled.Equals(true))
            {
                errorProvider1.SetError(txtId, "Sólo números sin espacios");
            }
            else
            {
                errorProvider1.Clear();
            }
            
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextbox.LetterSpace(e);
            if (e.Handled.Equals(true))
            {
                errorProvider1.SetError(txtName, "Sólo permite letras con espacios");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void TxtLastname1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextbox.LetterSpace(e);
            if (e.Handled.Equals(true))
            {
                errorProvider1.SetError(txtLastname1, "Sólo permite letras con espacios");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void TxtLastname2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextbox.LetterSpace(e);
            if (e.Handled.Equals(true))
            {
                errorProvider1.SetError(txtLastname2, "Sólo permite letras con espacios");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void TxtEmailN_TextChanged(object sender, EventArgs e)
        {
            if (txtAddresN.Text!="")
            {
                if (ValidateTextbox.IsValidEmail(txtEmailN.Text))
                {
                    //MsgWarning("Correcto");
                    errorProvider1.Clear();
                }
                else
                {
                    //MsgWarning("Incorrecto");
                    errorProvider1.SetError(txtEmailN, "ejemplo@dominio.extension (ejemplo@gmail.com)");
                }
            }
        }
        int cont = 0;
        private void TimerMsg_Tick(object sender, EventArgs e)
        {
            if (cont <= 3)
            {
                cont++;
            }
            if (cont == 3)
            {
                lblMsg.Visible = false;
                IpbCloseMsg.Visible = false;
                timerMsg.Stop();
                cont = 0;
            }
        }

        private void IpbCloseMsg_Click(object sender, EventArgs e)
        {
            if (lblMsg.Visible==true)
            {
                lblMsg.Visible = false;
                IpbCloseMsg.Visible = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Boton J: " + stateButtonJ + " | Boton N: " + stateButtonN);
        }
    }
}
