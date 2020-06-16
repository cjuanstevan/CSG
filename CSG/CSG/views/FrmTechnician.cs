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
    public partial class FrmTechnician : Form
    {
        private readonly TechnicianLog technicianLog = new TechnicianLog();
        private readonly OrderLog orderLog = new OrderLog();
        //Tabla
        private DataTable dtt = new DataTable();
        private DataColumn column;
        private DataRow row;
        public FrmTechnician()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            
        }

        private void CleanFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtContact.Clear();
            txtAlias.Clear();
            txtTelephone.Clear();
            cboPosition.SelectedIndex = 0;
        }

        private void TxtId_Leave(object sender, EventArgs e)
        {
            if (!txtId.Text.Equals(""))
            {
                bool response = technicianLog.Read_once_exist(txtId.Text);
                if (response)
                {
                    DialogResult dr = MessageBox.Show("El técnico que intenta crear ya existe. ¿Desea cargar la información en el formulario?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Technician technician = technicianLog.Read_once(txtId.Text);
                        txtId.Enabled = false;
                        IbtnCreate.Text = "Guardar";
                        IbtnNew.Enabled = true;
                        txtId.Text = technician.Technician_id;
                        txtName.Text = technician.Technician_name;
                        txtContact.Text = technician.Technician_contact;
                        txtAlias.Text = technician.Technician_alias;
                        txtTelephone.Text = technician.Technician_telephone;
                        cboPosition.Text = technician.Technician_position;
                    }
                }
            }
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            
        }


        private void FrmTechnician_Load(object sender, EventArgs e)
        {
            txtId.Focus();
            CreateDataTable();
        }
        private void CreateDataTable()
        {
            //Columna 1->
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ID",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtt.Columns.Add(column);
            // Columna 2->
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "NOMBRE",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            // Columna 3->
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CONTACTO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            // Columna 4->
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "EMPRESA",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            // Columna 5->
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TELÉFONO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            // Columna 6->categoría
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CARGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            DgvTechnician.DataSource = dtt;
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            IbtnNew.Enabled = false;
            IbtnCreate.Text = "Crear";
            CleanFields();
            txtId.ReadOnly = false;
            txtId.Focus();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                DialogResult dr = MessageBox.Show("¿Desea eliminar el técnico?" + Environment.NewLine
                    + "Código: " + txtId.Text + " | Nombre: " + txtName.Text, "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string code = txtId.Text;
                    //Limpiamos campos
                    CleanFields();
                    //habilita botones
                    txtId.ReadOnly = false;
                    txtId.Focus();
                    IbtnNew.Enabled = false;
                    IbtnCreate.Text = "Crear";
                    //Eliminamos
                    technicianLog.Delete(code);
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

            List<Technician> technicians = technicianLog.Read_all_like(txtSearch.Text);
            LoadRowsDataTable(technicians: technicians);
            //CreateHeaders();
        }

        private void IbtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            List<Technician> technicians = technicianLog.ReadAll();
            LoadRowsDataTable(technicians: technicians);
        }

        private void LoadRowsDataTable(List<Technician> technicians)
        {
            dtt = new DataTable();
            DgvTechnician.Columns.Clear();
            CreateDataTable();
            Cursor.Current = Cursors.WaitCursor;
            foreach (var t in technicians)
            {
                row = dtt.NewRow();
                row[0] = t.Technician_id;
                row[1] = t.Technician_name;
                row[2] = t.Technician_contact;
                row[3] = t.Technician_alias;
                row[4] = t.Technician_telephone;
                row[5] = t.Technician_position;
                dtt.Rows.Add(row);
            }
            //Editar
            DataGridViewImageColumn imageEdit = new DataGridViewImageColumn
            {
                Image = Properties.Resources.edit,
                Name = "edit",
                HeaderText = "EDITAR"
            };
            DgvTechnician.Columns.Add(imageEdit);
            //Eliminar
            DataGridViewImageColumn imageDelete = new DataGridViewImageColumn
            {
                Image = Properties.Resources.delete,
                Name = "delete",
                HeaderText = "ELIMINAR"
            };
            DgvTechnician.Columns.Add(imageDelete);
        }

        private void DgvTechnician_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //6 editar 7 eliminar
                if (DgvTechnician.CurrentCell.ColumnIndex == 6)
                {
                    txtId.Enabled = false;
                    IbtnCreate.Text = "Guardar";
                    IbtnNew.Enabled = true;
                    txtId.Text = DgvTechnician.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtName.Text = DgvTechnician.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtContact.Text = DgvTechnician.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtAlias.Text = DgvTechnician.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtTelephone.Text = DgvTechnician.Rows[e.RowIndex].Cells[4].Value.ToString();
                    cboPosition.Text = DgvTechnician.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
                else if (DgvTechnician.CurrentCell.ColumnIndex == 7)
                {
                    if (orderLog.TechnicianOrders(DgvTechnician.Rows[e.RowIndex].Cells[0].Value.ToString()) == 0)
                    {
                        DialogResult dr = MessageBox.Show("¿Desea eliminar el técnico?" +
                            Environment.NewLine + Environment.NewLine +
                              "ID: " + DgvTechnician.Rows[e.RowIndex].Cells[0].Value.ToString() +
                              Environment.NewLine +
                              "Nombre: " + DgvTechnician.Rows[e.RowIndex].Cells[1].Value.ToString(),
                              "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //Eliminamos
                            technicianLog.Delete(DgvTechnician.Rows[e.RowIndex].Cells[0].Value.ToString());
                            //Actualizamos tabla
                            IbtnRefresh_Click(null, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El técnico no se puede eliminar porque es utilizado en una " +
                            "o más órdenes de servicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void IbtnCreate_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                if (IbtnCreate.Text.Equals("Crear"))
                {
                    Technician technician = new Technician(txtId.Text, txtName.Text, txtContact.Text, txtAlias.Text,
                        txtTelephone.Text, cboPosition.Text);
                    CleanFields();
                    technicianLog.Create(technician);
                    IbtnNew.Enabled = true;
                    IbtnRefresh_Click(null, e);
                    txtId.Focus();
                }
                else if (IbtnCreate.Text.Equals("Guardar"))
                {
                    Technician technician = new Technician(txtId.Text, txtName.Text, txtContact.Text, txtAlias.Text,
                       txtTelephone.Text, cboPosition.Text);
                    CleanFields();
                    technicianLog.Update(technician);
                    IbtnNew.Enabled = true;
                    IbtnRefresh_Click(null, e);
                    txtId.Enabled = true;
                    txtId.Focus();
                    IbtnCreate.Text = "Crear";
                }
            }
        }

        private bool ValidateFields()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtId.Text))
            {
                txtId.Focus();
                errorProvider1.SetError(txtId, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtName.Focus();
                errorProvider1.SetError(txtName, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTelephone.Text))
            {
                txtTelephone.Focus();
                errorProvider1.SetError(txtTelephone, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(cboPosition.Text))
            {
                cboPosition.Focus();
                errorProvider1.SetError(cboPosition, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            return true;
        }

        private void IbtnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                DialogResult dr = MessageBox.Show("Se eliminará la información del formulario." +
                            Environment.NewLine + Environment.NewLine +
                              "¿Desea continuar?",
                              "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    CleanFields();
                    IbtnCreate.Text = "Crear";
                    txtId.Enabled = true;
                }txtId.Focus();
            }
        }
    }
}
