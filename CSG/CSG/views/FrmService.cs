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
    public partial class FrmService : Form
    {
        private readonly ServiceLog serviceLog = new ServiceLog();
        public FrmService()
        {
            InitializeComponent();
        }

        private void FrmService_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Equals(""))
            {
                MessageBox.Show("El código es obligatorio");
                txtCode.Focus();
            }
            else
            {
                //validamos el tipo de accion del boton
                if (btnCreate.Text.Equals("Crear"))
                {
                    Service service = new Service(txtCode.Text, txtActivity.Text, txtDuration.Text, txtCost.Text, char.Parse(txtType.Text));
                    CleanFields();
                    txtCode.Focus();
                    serviceLog.Create(service);
                    BtnReadAll_Click(sender, e);
                }
                else if (btnCreate.Text.Equals("Guardar"))
                {
                    //Guardamos
                    Service service = new Service(txtCode.Text, txtActivity.Text, txtDuration.Text, txtCost.Text, char.Parse(txtType.Text));
                    CleanFields();
                    txtCode.ReadOnly = false;
                    txtCode.Focus();
                    btnNew.Enabled = false;
                    btnCreate.Text = "Crear";
                    BtnDelete.Enabled = false;
                    serviceLog.Update(service);
                    BtnReadAll_Click(sender, e);
                }

            }
        }

        private void CleanFields()
        {
            txtCode.Clear();
            txtActivity.Clear();
            txtDuration.Clear();
            txtCost.Clear();
            txtType.Clear();
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
            DgvService.DataSource = serviceLog.ReadAll();
            CreateHeaders();
        }

        private void CreateHeaders()
        {
            DgvService.Columns[0].HeaderText = "CÓDIGO";
            DgvService.Columns[1].HeaderText = "ACTIVIDAD";
            DgvService.Columns[2].HeaderText = "DURACIÓN";
            DgvService.Columns[3].HeaderText = "COSTO";
            DgvService.Columns[4].HeaderText = "TIPO";
        }

        private void DgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCode.ReadOnly = true;
                btnCreate.Text = "Guardar";
                BtnDelete.Enabled = true;
                btnNew.Enabled = true;
                txtCode.Text = DgvService.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtActivity.Text = DgvService.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDuration.Text = DgvService.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCost.Text = DgvService.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtType.Text = DgvService.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnCreate.Text = "Crear";
            BtnDelete.Enabled = false;
            CleanFields();
            txtCode.ReadOnly = false;
            txtCode.Focus();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text != "")
            {
                DialogResult dr = MessageBox.Show("¿Desea eliminar el servicio?" + Environment.NewLine
                    + "Código: " + txtCode.Text + " | Actividad: " + txtActivity.Text, "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string code = txtCode.Text;
                    //Limpiamos campos
                    CleanFields();
                    //habilita botones
                    txtCode.ReadOnly = false;
                    txtCode.Focus();
                    btnNew.Enabled = false;
                    BtnDelete.Enabled = false;
                    btnCreate.Text = "Crear";
                    //Eliminamos
                    serviceLog.Delete(code);
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            DgvService.DataSource = serviceLog.Read_all_like(txtSearch.Text);
            CreateHeaders();
        }
    }
}
