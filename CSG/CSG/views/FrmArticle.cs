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
    public partial class FrmArticle : Form
    {
        private readonly ArticleLog articleLog = new ArticleLog();
        public FrmArticle()
        {
            InitializeComponent();
        }

        private void FrmArticle_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Equals(""))
            {
                txtCode.Focus();
                MessageBox.Show("El código del artículo es obligatorio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (btnCreate.Text.Equals("Crear"))
                {
                    Article article = new Article(txtCode.Text, txtDescription.Text, txtModel.Text, txtSerial.Text, ushort.Parse(nudWarranty.Value.ToString()));
                    CleanFields();
                    txtCode.Focus();
                    articleLog.Create(article);
                    BtnReadAll_Click(sender, e);
                }
                else if (btnCreate.Text.Equals("Guardar"))
                {
                    //Guardamos
                    Article article = new Article(txtCode.Text, txtDescription.Text, txtModel.Text, txtSerial.Text, ushort.Parse(nudWarranty.Value.ToString()));
                    CleanFields();
                    //cambiamos botones
                    txtCode.ReadOnly = false;
                    txtCode.Focus();
                    btnNew.Enabled = false;
                    btnCreate.Text = "Crear";
                    BtnDelete.Enabled = false;
                    articleLog.Update(article);
                    BtnReadAll_Click(sender, e);
                    
                }
            }
        }
        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            //txtSearch.Focus();
            DgvArticle.DataSource = articleLog.ReadAll();
            CreateHeaders();
        }

        private void DgvArticle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("Fila: " + e.RowIndex);
            if (e.RowIndex >= 0)
            {
                txtCode.ReadOnly = true;
                btnCreate.Text = "Guardar";
                BtnDelete.Enabled = true;
                btnNew.Enabled = true;
                txtCode.Text = DgvArticle.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescription.Text = DgvArticle.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtModel.Text = DgvArticle.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSerial.Text = DgvArticle.Rows[e.RowIndex].Cells[3].Value.ToString();
                nudWarranty.Value = decimal.Parse(DgvArticle.Rows[e.RowIndex].Cells[4].Value.ToString());
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
                DialogResult dr = MessageBox.Show("¿Desea eliminar el artículo?" + Environment.NewLine
                    + "Código: " + txtCode.Text + " | Descripción: " + txtDescription.Text, "Mensaje",
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
                    articleLog.Delete(code);
                    //Actualizamos tabla
                    BtnReadAll_Click(sender, e);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            DgvArticle.DataSource = articleLog.Read_all_like(txtSearch.Text);
            CreateHeaders();
        }

        //métodos de interfaz
        private void CleanFields()
        {
            txtCode.Clear();
            txtDescription.Clear();
            txtModel.Clear();
            txtSerial.Clear();
            nudWarranty.Value = 0;
        }

        private void CreateHeaders()
        {
            DgvArticle.Columns[0].HeaderText = "CÓDIGO";
            DgvArticle.Columns[1].HeaderText = "DESCRIPCIÓN";
            DgvArticle.Columns[2].HeaderText = "MODELO";
            DgvArticle.Columns[3].HeaderText = "SERIAL";
            DgvArticle.Columns[4].HeaderText = "GARANTÍA (AÑOS)";
        }

        private void TxtCode_Leave(object sender, EventArgs e)
        {
            if (!txtCode.Text.Equals(""))
            {
                bool response = articleLog.Read_once_exist(txtCode.Text);
                if (response)
                {
                    DialogResult dr = MessageBox.Show("El artículo que intenta crear ya existe. ¿Desea cargar la información en el formulario?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Article article = articleLog.Read_once(txtCode.Text);
                        txtCode.Enabled = false;
                        btnCreate.Text = "Guardar";
                        txtCode.Text = article.Article_code;
                        txtDescription.Text = article.Article_description;
                        txtModel.Text = article.Article_model;
                        txtSerial.Text = article.Article_serial;
                        nudWarranty.Value = article.Article_warranty;
                    }
                }
            }
        }
    }
}
