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
using CSG.validator;
using System.Globalization;

namespace CSG.views
{
    public partial class FrmRefactions : Form
    {
        private readonly RefactionLog refactionLog = new RefactionLog();
        private readonly CotizationRefactionLog cotizationRefactionLog = new CotizationRefactionLog();
        //Tabla
        private DataTable dtr = new DataTable();
        private DataColumn column;
        private DataRow row;

        //DEcimal
        string value;
        decimal number;
        NumberStyles style;
        CultureInfo provider;
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
                        IbtnCreate.Text = "Guardar";
                        IbtnNew.Enabled = true;
                        //Llenamos los campos.
                        txtCode.Text = refaction.Refaction_code;
                        txtDesc.Text = refaction.Refaction_description;
                        txtUnitPrice.Text = refaction.Refaction_unit_price.ToString();
                        txtObs.Text = "";
                    }
                    else
                    {
                        txtCode.Clear();
                        txtCode.Focus();
                    }
                }
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            
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
            IbtnNew.Enabled = false;
            IbtnCreate.Text = "Crear";
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
                    IbtnCreate.Text = "Crear";
                    //Limpiamos campos
                    CleanFields();
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            //DgvRefaction.DataSource = refactionLog.ReadAll();
            //CreateHeaders();
        }
        //Crea la estructura de la tabla en memoria
        private void CreateDataTable()
        {
            //Columna 1->codigo
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CÓDIGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtr.Columns.Add(column);
            // Columna 2->descripcion
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESCRIPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtr.Columns.Add(column);
            // Columna 3->precio unitario
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "PRECIO UNITARIO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false,
            };
            dtr.Columns.Add(column);
            DgvRefaction.DataSource = dtr;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Refaction> refactions = refactionLog.Read_all_like(txtSearch.Text);
            LoadRowsDataTable(refactions);
            //DgvRefaction.DataSource = refactionLog.Read_all_like(txtSearch.Text);
            //CreateHeaders();
        }

        //private void CreateHeaders()
        //{
        //    DgvRefaction.Columns[0].HeaderText = "Código";
        //    DgvRefaction.Columns[1].HeaderText = "Descripción";
        //    DgvRefaction.Columns[2].HeaderText = "Precio Unitario";
        //}

        private void IbtnCreate_Click(object sender, EventArgs e)
        {
            if (IbtnCreate.Text.Equals("Crear"))
            {
                if (ValidateFields())
                {
                    Refaction refaction = new Refaction(txtCode.Text, txtDesc.Text, txtUnitPrice.Text);
                    CleanFields();
                    refactionLog.Create(refaction);
                    IbtnRefresh_Click(null, e);
                    IbtnNew.Enabled = false;
                }
            }
            else if (IbtnCreate.Text.Equals("Guardar"))
            {
                if (ValidateFields())
                {
                    //Guardamos
                    Refaction refaction = new Refaction(txtCode.Text, txtDesc.Text, txtUnitPrice.Text);
                    CleanFields();
                    refactionLog.Update(refaction);
                    IbtnRefresh_Click(null, e);
                    //cambiamos botones
                    txtCode.Enabled = true;
                    txtCode.Focus();
                    IbtnCreate.Text = "Crear";
                    IbtnNew.Enabled = false;
                }
            }

        }

        private bool ValidateFields()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                txtCode.Focus();
                errorProvider1.SetError(txtCode, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                txtDesc.Focus();
                errorProvider1.SetError(txtDesc, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtUnitPrice.Text))
            {
                txtUnitPrice.Focus();
                errorProvider1.SetError(txtUnitPrice, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            return true;
        }

        private void TxtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextbox.LetterAndNumericNoSpace(e);
            if (e.Handled.Equals(true))
            {
                errorProvider1.SetError(txtCode, "Sólo letras y números sin espacios");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidateTextbox.NumericNoSpace(e);
            //if (e.Handled.Equals(true))
            //{
            //    errorProvider1.SetError(txtUnitPrice, "Sólo números sin espacios");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

        private void TxtUnitPrice_Enter(object sender, EventArgs e)
        {
            //TextBox tb = (TextBox)sender;
            //tb.Text = Convert.ToString(tb.Tag);
        }

        private void TxtUnitPrice_Leave(object sender, EventArgs e)
        {
            //TextBox tb = (TextBox)sender;
            //decimal numero = default(decimal);
            //bool bln = decimal.TryParse(tb.Text, out numero);
            //if ((!(bln)))
            //{
            //    // No es un valor decimal válido; limpiamos el control.
            //    tb.Clear();
            //    return;
            //}

            //// En la propiedad Tag guardamos el valor con todos los decimales.
            ////
            //tb.Tag = numero;

            //// Y acto seguido formateamos el valor
            //// a monetario con dos decimales.
            ////
            //tb.Text = string.Format("{0:C2}", numero);
        }

        private void FrmRefactions_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
            CreateDataTable();
        }

        private void IbtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            List<Refaction> refactions = refactionLog.ReadAll();
            LoadRowsDataTable(refactions);
        }
        private void LoadRowsDataTable(List<Refaction> refactions)
        {
            dtr = new DataTable();
            DgvRefaction.Columns.Clear();
            CreateDataTable();
            Cursor.Current = Cursors.WaitCursor;
            foreach (var r in refactions)
            {
                row = dtr.NewRow();
                row[0] = r.Refaction_code;
                row[1] = r.Refaction_description;
                row[2] = r.Refaction_unit_price;
                dtr.Rows.Add(row);                 
            }
            //Editar
            DataGridViewImageColumn imageEdit = new DataGridViewImageColumn
            {
                Image = Properties.Resources.edit,
                Name = "edit",
                HeaderText = "EDITAR"
            };
            DgvRefaction.Columns.Add(imageEdit);
            //Eliminar
            DataGridViewImageColumn imageDelete = new DataGridViewImageColumn
            {
                Image = Properties.Resources.delete,
                Name = "delete",
                HeaderText = "ELIMINAR"
            };
            DgvRefaction.Columns.Add(imageDelete);
        }

        private void IbtnNew_Click(object sender, EventArgs e)
        {
            IbtnNew.Enabled = false;
            IbtnCreate.Text = "Crear";
            CleanFields();
            txtCode.Enabled = true;
            txtCode.Focus();
        }

        private void DgvRefaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DgvRefaction.CurrentCell.ColumnIndex == 3)
                {
                    //Bloqueamos controles
                    IbtnNew.Enabled = true;
                    txtCode.Enabled = false;
                    IbtnCreate.Text = "Guardar";
                    txtCode.Text = DgvRefaction.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtDesc.Text = DgvRefaction.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtUnitPrice.Text = DgvRefaction.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                else if (DgvRefaction.CurrentCell.ColumnIndex == 4)
                {
                    if (cotizationRefactionLog.RefactionsCotizations(DgvRefaction.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        DialogResult dr = MessageBox.Show("¿Desea eliminar el repuesto?" +
                             Environment.NewLine + Environment.NewLine +
                               "Código: " + DgvRefaction.Rows[e.RowIndex].Cells[0].Value.ToString() +
                               Environment.NewLine +
                               "Descripción: " + DgvRefaction.Rows[e.RowIndex].Cells[1].Value.ToString(),
                               "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //Eliminamos
                            refactionLog.Delete(DgvRefaction.Rows[e.RowIndex].Cells[0].Value.ToString());
                            //Actualizamos tabla
                            IbtnRefresh_Click(null, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El repuesto no se puede eliminar porque es utilizado en una o mas" +
                            " cotizaciones");
                    }
                }
            }
        }
    }
}
