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
        private readonly CotizationServiceLog cotizationServiceLog = new CotizationServiceLog();
        //Tabla
        private DataTable dts = new DataTable();
        private DataColumn column;
        private DataRow row;
        public FrmService()
        {
            InitializeComponent();
        }

        private void FrmService_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
            CreateDataTable();
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
                //if (btnCreate.Text.Equals("Crear"))
                //{

                //    //Service service = new Service(txtCode.Text, txtActivity.Text, txtDuration.Text, Convert.ToDecimal(txtCost.Text), char.Parse(txtType.Text));
                //    //CleanFields();
                //    //txtCode.Focus();
                //    //serviceLog.Create(service);
                //    //BtnReadAll_Click(sender, e);
                //}
                //else if (btnCreate.Text.Equals("Guardar"))
                //{
                //    ////Guardamos
                //    //Service service = new Service(txtCode.Text, txtActivity.Text, txtDuration.Text, Convert.ToDecimal(txtCost.Text), char.Parse(txtType.Text));
                //    //CleanFields();
                //    //txtCode.ReadOnly = false;
                //    //txtCode.Focus();
                //    //btnNew.Enabled = false;
                //    //btnCreate.Text = "Crear";
                //    ////BtnDelete.Enabled = false;
                //    //serviceLog.Update(service);
                //    //BtnReadAll_Click(sender, e);
                //}

            }
        }

        private void CleanFields()
        {
            txtCode.Clear();
            txtActivity.Clear();
            nupDuration.Value = decimal.Zero;
            txtCost.Clear();
            cboType.SelectedIndex = 0;
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            //txtSearch.Clear();
            //txtSearch.Focus();
            //DgvService.DataSource = serviceLog.ReadAll();
            //CreateHeaders();
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
            
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            IbtnNew.Enabled = false;
            IBtnCreate.Text = "Crear";
            //BtnDelete.Enabled = false;
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
                    IbtnNew.Enabled = false;
                    //BtnDelete.Enabled = false;
                    IBtnCreate.Text = "Crear";
                    //Eliminamos
                    serviceLog.Delete(code);
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Service> services = serviceLog.Read_all_like(txtSearch.Text);
            LoadRowsDataTable(services: services);
        }

        private void IBtnCreate_Click(object sender, EventArgs e)
        {
            if (IBtnCreate.Text.Equals("Crear"))
            {
                if (ValidateFields())
                {
                    if (!serviceLog.Read_once_exist(txtCode.Text))
                    {
                        Service service = new Service(txtCode.Text, txtActivity.Text, nupDuration.Value.ToString(),
                        txtCost.Text, char.Parse(cboType.Text));
                        CleanFields();
                        serviceLog.Create(service);
                        IbtnRefresh_Click(null, e);
                    }
                    else
                    {
                        MessageBox.Show("El servicio ya existe en el sistema", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }

            }
            else if (IBtnCreate.Text.Equals("Guardar"))
            {
                if (ValidateFields())
                {
                    Service service = new Service(txtCode.Text, txtActivity.Text, nupDuration.Value.ToString(),
                    txtCost.Text, char.Parse(cboType.Text));
                    CleanFields();
                    serviceLog.Update(service);
                    IbtnRefresh_Click(null, e);
                    txtCode.Enabled = true;
                    txtCode.Focus();
                    IBtnCreate.Text = "Crear";
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
            if (string.IsNullOrEmpty(txtActivity.Text))
            {
                txtActivity.Focus();
                errorProvider1.SetError(txtActivity, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCost.Text))
            {
                txtCost.Focus();
                errorProvider1.SetError(txtCost, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (decimal.Zero.Equals(nupDuration.Value))
            {
                nupDuration.Focus();
                errorProvider1.SetError(nupDuration, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(cboType.Text))
            {
                cboType.Focus();
                errorProvider1.SetError(cboType, "Selección obligatoria");
                return false;
            }
            return true;
        }

        private void DgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DgvService.CurrentCell.ColumnIndex == 5)
                {
                    txtCode.Enabled = false;
                    IBtnCreate.Text = "Guardar";
                    IbtnNew.Enabled = true;
                    txtCode.Text = DgvService.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtActivity.Text = DgvService.Rows[e.RowIndex].Cells[1].Value.ToString();
                    nupDuration.Value = Decimal.Parse(DgvService.Rows[e.RowIndex].Cells[3].Value.ToString());
                    txtCost.Text = DgvService.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cboType.Text = DgvService.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
                else if (DgvService.CurrentCell.ColumnIndex == 6)
                {
                    if (cotizationServiceLog.ServicesCotizations(DgvService.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                    Console.WriteLine("Preguntamos");
                        DialogResult dr = MessageBox.Show("¿Desea eliminar el servicio?" +
                            Environment.NewLine + Environment.NewLine +
                              "Código: " + DgvService.Rows[e.RowIndex].Cells[0].Value.ToString() +
                              Environment.NewLine +
                              "Actividad: " + DgvService.Rows[e.RowIndex].Cells[1].Value.ToString(),
                              "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //Eliminamos
                            serviceLog.Delete(DgvService.Rows[e.RowIndex].Cells[0].Value.ToString());
                            //Actualizamos tabla
                            IbtnRefresh_Click(null, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El servicio no se puede eliminar porque es utilizado en una o más cotizaciones");
                    }

                }
            }
        }

        private void IbtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            List<Service> services = serviceLog.ReadAll();
            LoadRowsDataTable(services: services);
        }
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
            dts.Columns.Add(column);
            // Columna 2->descripcion
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ACTIVIDAD",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            // Columna 3->garantía
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "COSTO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            // Columna 4->categoría
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DURACIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            // Columna E->categoría
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Char"),
                ColumnName = "TIPO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            DgvService.DataSource = dts;
        }
        private void LoadRowsDataTable(List<Service> services)
        {
            dts = new DataTable();
            DgvService.Columns.Clear();
            CreateDataTable();
            Cursor.Current = Cursors.WaitCursor;
            foreach (var s in services)
            {
                row = dts.NewRow();
                row[0] = s.Service_code;
                row[1] = s.Service_activity;
                row[2] = s.Service_cost;
                row[3] = s.Service_duration;
                row[4] = s.Service_type;
                dts.Rows.Add(row);
            }
            //label14.Text = "LISTADO DE ARTÍCULOS(" + articles.Count + ")";


            //Editar
            DataGridViewImageColumn imageEdit = new DataGridViewImageColumn
            {
                Image = Properties.Resources.edit,
                Name = "edit",
                HeaderText = "EDITAR"
            };
            DgvService.Columns.Add(imageEdit);
            //Eliminar
            DataGridViewImageColumn imageDelete = new DataGridViewImageColumn
            {
                Image = Properties.Resources.delete,
                Name = "delete",
                HeaderText = "ELIMINAR"
            };
            DgvService.Columns.Add(imageDelete);
        }

        private void IbtnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                DialogResult dr = MessageBox.Show("Se eliminará la información del formulario." +
                            Environment.NewLine + Environment.NewLine +
                              "¿Desea continuar?",
                              "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    CleanFields();
                    IBtnCreate.Text = "Crear";
                    txtCode.Enabled = true;
                }
            }txtCode.Focus();
            
        }
    }
}
