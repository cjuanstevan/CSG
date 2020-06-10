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
        public FrmTechnician()
        {
            InitializeComponent();
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
                    //Technician technician = new Technician(txtId.Text, txtName.Text, txtContact.Text, txtAlias.Text, txtTelephone.Text, txtPosition.Text);
                    CleanFields();
                    //technicianLog.Create(technician);
                    BtnReadAll_Click(sender, e);
                }
                else if (btnCreate.Text.Equals("Guardar"))
                {
                    //Guardamos
                    //Technician technician = new Technician(txtId.Text, txtName.Text, txtContact.Text, txtAlias.Text, txtTelephone.Text, txtPosition.Text);
                    CleanFields();
                    //technicianLog.Update(technician);
                    BtnReadAll_Click(sender, e);
                    //cambiamos botones
                    btnCreate.Text = "Crear";
                    BtnDelete.Enabled = false;
                }

            }
        }

        private void CleanFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtContact.Clear();
            txtAlias.Clear();
            txtTelephone.Clear();
            txtPosition.Clear();
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
                        btnCreate.Text = "Guardar";
                        txtId.Text = technician.Technician_id;
                        txtName.Text = technician.Technician_name;
                        txtContact.Text = technician.Technician_contact;
                        txtAlias.Text = technician.Technician_alias;
                        txtTelephone.Text = technician.Technician_telephone;
                        txtPosition.Text = technician.Technician_position;
                    }
                }
            }
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            DgvTechnician.DataSource = technicianLog.ReadAll();
            CreateHeaders();
        }

        private void CreateHeaders()
        {
            DgvTechnician.Columns[0].HeaderText = "Identidad";
            DgvTechnician.Columns[1].HeaderText = "Nombre";
            DgvTechnician.Columns[2].HeaderText = "Contacto";
            DgvTechnician.Columns[3].HeaderText = "Empresa";
            DgvTechnician.Columns[4].HeaderText = "Teléfono";
            DgvTechnician.Columns[5].HeaderText = "Cargo";
        }

        private void FrmTechnician_Load(object sender, EventArgs e)
        {
            txtId.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnCreate.Text = "Crear";
            BtnDelete.Enabled = false;
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
                    btnNew.Enabled = false;
                    BtnDelete.Enabled = false;
                    btnCreate.Text = "Crear";
                    //Eliminamos
                    technicianLog.Delete(code);
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            DgvTechnician.DataSource = technicianLog.Read_all_like(txtSearch.Text);
            CreateHeaders();
        }

        private void DgvTechnician_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.ReadOnly = true;
                btnCreate.Text = "Guardar";
                BtnDelete.Enabled = true;
                btnNew.Enabled = true;
                txtId.Text = DgvTechnician.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = DgvTechnician.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtContact.Text = DgvTechnician.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAlias.Text = DgvTechnician.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTelephone.Text = DgvTechnician.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPosition.Text = DgvTechnician.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
    }
}
