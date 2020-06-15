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
    public partial class FrmArticleViewer : Form
    {
        ArticleLog articleLog = new ArticleLog();
        CategoryLog categoryLog = new CategoryLog();
        public FrmArticleViewer()
        {
            InitializeComponent();
        }

        private void FrmArticleViewer_Load(object sender, EventArgs e)
        {
            //Article._code_static = "1HME025";

            if (!string.IsNullOrEmpty(Article._code_static))
            {
                //cargamos la información
                Article article = articleLog.Read_once(Article._code_static);
                this.Text = article.Article_code;
                lblDescription.Text = article.Article_description;
                Category category = categoryLog.Read_once(article.Category);
                lblCategory.Text = "Tipo: "+category.Category_name;
                lblWarranty.Text = "Garantía: " + article.Article_warranty + " año(s)";
                lblCreateby.Text = "Creado por: " + article.Create_by;
                lblCreateDate.Text = "Fecha: " + article.Create_date.ToString("yyyy-MM-dd HH:mm:ss");
                if (!string.IsNullOrEmpty(article.Update_by))
                {
                    lblUpdateby.Text = "Actualizado por: " + article.Update_by;
                    lblUpdateDate.Text = "Fecha: " + article.Update_date.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    lblUpdateby.Text = "Actualizado por: Nunca";
                    lblUpdateDate.Text = "Fecha: No presenta";
                }
            }
        }

        private void FrmArticleViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}
