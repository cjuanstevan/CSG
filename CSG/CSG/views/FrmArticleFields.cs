using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.logic;
using CSG.model;

namespace CSG.views
{
    public partial class FrmArticleFields : Form
    {
        ArticleLog articleLog = new ArticleLog();
        CategoryLog categoryLog = new CategoryLog();
        public FrmArticleFields()
        {
            InitializeComponent();
        }

        private void FrmArticleFields_Load(object sender, EventArgs e)
        {
            LoadCategories();
            if (string.IsNullOrEmpty(Article._code_static))
            {
                txtCode.Focus();
                lblTitle.Text = "CREAR ARTÍCULO";
                IbtnDo.Text = "CREAR";
            }
            else
            {
                lblTitle.Text = "EDITAR ARTÍCULO";
                IbtnDo.Text = "GUARDAR";
                txtCode.Enabled = false;
                Article article = articleLog.Read_once(Article._code_static);
                txtCode.Text = article.Article_code;
                txtDescription.Text = article.Article_description;
                Category category = categoryLog.Read_once(article.Category);
                cboCategory.Text = category.Category_name;
                nudWarranty.Value = Convert.ToDecimal(article.Article_warranty);
            }
        }

        private void IbtnDo_Click(object sender, EventArgs e)
        {
            if (IbtnDo.Text.Equals("CREAR"))
            {
                if (ValidateFields())
                {
                    if (ValidateExisting())
                    {
                        Article article = new Article(txtCode.Text, txtDescription.Text,
                        Convert.ToInt32(nudWarranty.Value), Convert.ToByte(cboCategory.SelectedIndex + 1));
                        articleLog.Create(article);
                        DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    else
                    {
                        lblMsg.Text = "El artículo existe en el sistema";
                    }
                    
                }
            }
            else if (IbtnDo.Text.Equals("GUARDAR"))
            {
                if (ValidateFields())
                {
                    Article article = new Article(txtCode.Text, txtDescription.Text,
                        Convert.ToInt32(nudWarranty.Value), Convert.ToByte(cboCategory.SelectedIndex + 1));
                    articleLog.Update(article);
                    DialogResult = DialogResult.Yes;
                    this.Close();
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
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                txtDescription.Focus();
                errorProvider1.SetError(txtDescription, "Campo obligatorio");
                return false;
            }
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(cboCategory.Text))
            {
                cboCategory.Focus();
                errorProvider1.SetError(cboCategory, "Selección obligatoria");
                return false;
            }
            errorProvider1.Clear();
            if (decimal.Zero.Equals(nudWarranty.Value))
            {
                nudWarranty.Focus();
                errorProvider1.SetError(nudWarranty, "Indique un número mayor o igual a 1");
                return false;
            }
            errorProvider1.Clear();
            return true;
        }

        private bool ValidateExisting()
        {
            if (articleLog.Read_once_exist(txtCode.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void LoadCategories()
        {
            cboCategory.Items.Clear();
            List<Category> categories = categoryLog.Read_all();
            foreach (var c in categories)
            {
                cboCategory.Items.Add(c.Category_name);
            }
        }
    }
}
