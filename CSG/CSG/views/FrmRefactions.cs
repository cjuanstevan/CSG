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
    public partial class FrmRefactions : Form
    {
        private readonly RefactionLog refactionLog = new RefactionLog();
        public FrmRefactions()
        {
            InitializeComponent();
        }

        private void TxtCode_Leave(object sender, EventArgs e)
        {
            if (!txtCode.Text.Equals(""))
            {
                bool response = refactionLog.Read_once_exist(txtCode.Text);
                if (response)
                {
                    DialogResult dr = MessageBox.Show("El repuesto que intenta crear ya existe. ¿Desea cargar la información en el formulario?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //Consultamos el cliente con el Id como parametro.
                        Refaction refaction = refactionLog.Read_once(txtCode.Text);
                        //Desactivamos los campos ineditables.
                        txtCode.Enabled = false;
                        //Cambiamos el tipo de accion del boton
                        btnCreate.Text = "Guardar";
                        //Llenamos los campos.
                        txtCode.Text = refaction.Refaction_code;
                        txtDesc.Text = refaction.Refaction_description;
                        txtUnitPrice.Text = refaction.Refaction_unit_price.ToString();
                        txtObs.Text = "";
                    }
                }
            }
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
                    Refaction refaction = new Refaction(txtCode.Text, txtDesc.Text, decimal.Parse(txtUnitPrice.Text));
                    CleanFields();
                    refactionLog.Create(refaction);
                    BtnReadAll_Click(sender, e);
                }
                else if (btnCreate.Text.Equals("Guardar"))
                {
                    //Guardamos
                    Refaction refaction = new Refaction(txtCode.Text, txtDesc.Text, decimal.Parse(txtUnitPrice.Text));
                    CleanFields();
                    refactionLog.Update(refaction);
                    BtnReadAll_Click(sender, e);
                    //cambiamos botones
                    btnCreate.Text = "Crear";
                    BtnDelete.Enabled = false;
                }
            }
        }

        private void CleanFields()
        {
            txtCode.Clear();
            txtDesc.Clear();
            txtUnitPrice.Clear();
            txtObs.Clear();
            txtCode.Focus();
            txtCode.ReadOnly = false;
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
                DialogResult dr = MessageBox.Show("¿Desea eliminar el repuesto " + txtCode.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Eliminamos
                    refactionLog.Delete(txtCode.Text);
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

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            DgvRefaction.DataSource = refactionLog.ReadAll();
            CreateHeaders();
        }

        private void DgvRefaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCode.ReadOnly = true;
                btnCreate.Text = "Guardar";
                BtnDelete.Enabled = true;
                btnNew.Enabled = true;
                txtCode.Text = DgvRefaction.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDesc.Text = DgvRefaction.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUnitPrice.Text = DgvRefaction.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            DgvRefaction.DataSource = refactionLog.Read_all_like(txtSearch.Text);
            CreateHeaders();
        }

        private void CreateHeaders()
        {
            DgvRefaction.Columns[0].HeaderText = "Código";
            DgvRefaction.Columns[1].HeaderText = "Descripción";
            DgvRefaction.Columns[2].HeaderText = "Precio Unitario";
        }
    }
}
