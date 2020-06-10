using CSG.cache;
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
    public partial class CdoArticle : Form
    {
        private readonly ArticleLog articleLog = new ArticleLog();
        public ICom com { get; set; }

        private DataTable dta = new DataTable();
        private DataColumn column;
        private DataRow row;
        public CdoArticle()
        {
            InitializeComponent();
        }

        private void CdoArticle_Load(object sender, EventArgs e)
        {
            CreateDataTable();
            ReadArticles();

            //PERMISOS DE USUARIO
            //Si el usuario es Recepcionista
            if (UserCache.UserRol.Equals(Roles.REC))
            {
                linkarticle.Visible = false;
            }
            //Si el usuario es técnico
            if (UserCache.UserRol.Equals(Roles.TEC))
            {
                linkarticle.Visible = false;
            }
            //Si el usuario es jefe técnico
            if (UserCache.UserRol.Equals(Roles.JTE))
            {
                linkarticle.Visible = true;
            }
            //Si el usuario es administrador
            if (UserCache.UserRol.Equals(Roles.ADM))
            {
                linkarticle.Visible = true;
            }
        }

        private void ReadArticles()
        {
            List<Article> articles = articleLog.ReadAll();
            LoadRowsTable(articles);
            //DgvArticle.DataSource = articleLog.ReadAll();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Equals(""))
            {
                //Limpiamos las rows
                dta = new DataTable();
                CreateDataTable();
                List<Article> articles = articleLog.Read_all_like(txtSearch.Text);
                LoadRowsTable(articles);
                //DgvArticle.DataSource = articleLog.Read_all_like(txtSearch.Text);
            }
        }

        private void DgvArticle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                com.ArticleText(DgvArticle.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.Close();
            }
        }
        private void LoadRowsTable(List<Article> articles)
        {
            foreach (var a in articles)
            {
                row = dta.NewRow();
                row[0] = a.Article_code;
                row[1] = a.Article_description;
                row[2] = a.Article_warranty;
                row[3] = a.Category;
                dta.Rows.Add(row);
            }
            
        }
        private void CreateDataTable()
        {
            //Columna 1->ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CÓDIGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dta.Columns.Add(column);
            // Columna 2->Cliente
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESCRIPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            // Columna 3->CIUDAD O MUNICIPIO
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "GARANTÍA",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            // Columna 4->departamento
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Byte"),
                ColumnName = "CATEGORÍA",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            DgvArticle.DataSource = dta;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
