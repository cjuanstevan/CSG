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
        private readonly CategoryLog categoryLog = new CategoryLog();
        private readonly OrderArticleLog orderArticleLog = new OrderArticleLog();

        //Tabla
        private DataTable dta = new DataTable();
        private DataColumn column;
        private DataRow row;
        public FrmArticle()
        {
            InitializeComponent();
        }

        private void FrmArticle_Load(object sender, EventArgs e)
        {
            CreateDataTable();
        }

        private void BtnReadAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            List<Article> articles = articleLog.ReadAll();
            LoadRowsDataTable(articles:articles);

        }
        
        private void LoadRowsDataTable(List<Article> articles)
        {
            dta = new DataTable();
            DgvArticle.Columns.Clear();
            CreateDataTable();
            foreach (var a in articles)
            {
                row = dta.NewRow();
                row[0] = a.Article_code;
                row[1] = a.Article_description;
                row[2] = a.Article_warranty;
                Category c = categoryLog.Read_once(a.Category);
                row[3] = c.Category_name;
                dta.Rows.Add(row);
            }
            label14.Text = "LISTADO DE ARTÍCULOS(" + articles.Count + ")";
            if (DgvArticle.Columns.Count <= 4)
            {
                //Ver
                DataGridViewImageColumn imageView = new DataGridViewImageColumn
                {
                    Image = Properties.Resources.view,
                    Name = "view",
                    HeaderText = "VER"
                };
                DgvArticle.Columns.Add(imageView);

                //Editar
                DataGridViewImageColumn imageEdit = new DataGridViewImageColumn
                {
                    Image = Properties.Resources.edit,
                    Name = "edit",
                    HeaderText = "EDITAR"
                };
                DgvArticle.Columns.Add(imageEdit);
                //Editar
                DataGridViewImageColumn imageDelete = new DataGridViewImageColumn
                {
                    Image = Properties.Resources.delete,
                    Name = "delete",
                    HeaderText = "ELIMINAR"
                };
                DgvArticle.Columns.Add(imageDelete);
            }
        }

        //Crea las columnas del DataTable
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
            dta.Columns.Add(column);
            // Columna 2->descripcion
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESCRIPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            // Columna 3->garantía
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "GARANTÍA(AÑOS)",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            // Columna 4->categoría
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CATEGORÍA",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            DgvArticle.DataSource = dta;
        }

        private void DgvArticle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Ver
                if (DgvArticle.CurrentCell.ColumnIndex == 4)
                {
                    //Enviamos el codigo del articuloa la variable static de la clase Article
                    Article._code_static = DgvArticle.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //Instanciamos y abrimos el formulario de ver
                    FrmArticleViewer articleViewer = new FrmArticleViewer();
                    articleViewer.ShowDialog();
                    if (articleViewer.DialogResult.Equals(DialogResult.Yes))
                    {
                        Article._code_static = "";
                    }
                }
                //Editar
                else if (DgvArticle.CurrentCell.ColumnIndex == 5)
                {
                    //Enviamos el codigo del articuloa la variable static de la clase Article
                    Article._code_static = DgvArticle.Rows[e.RowIndex].Cells[0].Value.ToString();
                    //Instanciamos y abrimos el formulario de editar
                    FrmArticleFields articleFields = new FrmArticleFields();
                    articleFields.ShowDialog();
                    if (articleFields.DialogResult.Equals(DialogResult.Yes))
                    {
                        Article._code_static = "";
                        BtnReadAll_Click(sender, e);
                    }

                }
                //Eliminar
                else if (DgvArticle.CurrentCell.ColumnIndex == 6)
                {
                    if (orderArticleLog.ArticlesOrders(DgvArticle.Rows[e.RowIndex].Cells[0].Value.ToString()))
                    {
                        DialogResult dr = MessageBox.Show("¿Desea eliminar el artículo?" +
                        Environment.NewLine + Environment.NewLine +
                          "Código: " + DgvArticle.Rows[e.RowIndex].Cells[0].Value.ToString() +
                          Environment.NewLine +
                          "Descripción: " + DgvArticle.Rows[e.RowIndex].Cells[1].Value.ToString(),
                          "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            //Eliminamos
                            articleLog.Delete(DgvArticle.Rows[e.RowIndex].Cells[0].Value.ToString());
                            //Actualizamos tabla
                            BtnReadAll_Click(null, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El artículo no se puede eliminar porque es utilizado en varias órdenes");
                    }
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Article> articles = persistence.DAOFactory.GetArticleDAO().Read_all_like(txtSearch.Text);
            LoadRowsDataTable(articles);
        }

        //métodos de interfaz
        private void IbtnNew_Click(object sender, EventArgs e)
        {
            FrmArticleFields articleFields = new FrmArticleFields();
            articleFields.ShowDialog();
            //articleFields.FormClosed += ArticleFields_FormClosed;
            if (articleFields.DialogResult.Equals(DialogResult.Yes))
            {
                Article._code_static = "";
                BtnReadAll_Click(sender, e);
            }
        }
    }
}
