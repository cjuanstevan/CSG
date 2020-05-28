using CSG.cache;
using CSG.logic;
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
        public CdoArticle()
        {
            InitializeComponent();
        }

        private void CdoArticle_Load(object sender, EventArgs e)
        {
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
            DgvArticle.DataSource = articleLog.ReadAll();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Equals(""))
            {
                DgvArticle.DataSource = articleLog.Read_all_like(txtSearch.Text);
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
    }
}
