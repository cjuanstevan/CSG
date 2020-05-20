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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
            CustomizeDesign();
        }
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            //Formulario predeterminado
            OpenChildForm(new FrmOrderRead());
            //BtnReadOrder_Click(sender, e);
        }
        private void CustomizeDesign()
        {
            PlOrdersSubmenu.Visible = false;
            PlMaintenaceSubmenu.Visible = false;
        }

        private void HideSubmenu()
        {
            if (PlOrdersSubmenu.Visible.Equals(true))
                PlOrdersSubmenu.Visible = false;
            if (PlMaintenaceSubmenu.Visible.Equals(true))
                PlMaintenaceSubmenu.Visible = false;
        }

        private void ShowSubmenu(Panel subMenu)
        {
            if (subMenu.Visible.Equals(false))
            {
                HideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void BtnIndex_Click(object sender, EventArgs e)
        {
            HideSubmenu();
            LblNameMain.Text = "TABLERO";
            BtnIndex.BackColor = Color.FromArgb(109, 119, 129);
            BtnOrders.BackColor = Color.FromArgb(39, 40, 36);
            BtnMaintenance.BackColor = Color.FromArgb(39, 40, 36);
            BtnClients.BackColor = Color.FromArgb(111, 111, 109);
            BtnArticles.BackColor = Color.FromArgb(111, 111, 109);
            BtnRefactions.BackColor = Color.FromArgb(111, 111, 109);
            BtnServices.BackColor = Color.FromArgb(111, 111, 109);
            BtnTechnicians.BackColor = Color.FromArgb(111, 111, 109);
            OpenChildForm(new FrmIndex());
        }
        private void BtnOrders_Click(object sender, EventArgs e)
        {
            BtnIndex.BackColor = Color.FromArgb(39, 40, 36);
            BtnOrders.BackColor = Color.FromArgb(109, 119, 129);
            BtnMaintenance.BackColor = Color.FromArgb(39, 40, 36);
            ShowSubmenu(PlOrdersSubmenu);
        }

        private void BtnOrderCreate_Click(object sender, EventArgs e)
        {
            LblNameMain.Text = "CREAR ORDEN";
            BtnOrderCreate.BackColor = Color.FromArgb(127, 127, 127);
            BtnReadOrder.BackColor = Color.FromArgb(111, 111, 109);
            OpenChildForm(new FrmOrderCreate());
        }

        private void BtnReadOrder_Click(object sender, EventArgs e)
        {
            LblNameMain.Text = "CONSULTAR ORDEN";
            BtnOrderCreate.BackColor = Color.FromArgb(111, 111, 109);
            BtnReadOrder.BackColor = Color.FromArgb(127, 127, 127);
            OpenChildForm(new FrmOrderRead());
        }

        private void BtnMaintenance_Click(object sender, EventArgs e)
        {
            BtnIndex.BackColor = Color.FromArgb(39, 40, 36);
            BtnOrders.BackColor = Color.FromArgb(39, 40, 36);
            BtnMaintenance.BackColor = Color.FromArgb(109, 119, 129);
            ShowSubmenu(PlMaintenaceSubmenu);
        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PlChildForm.Controls.Add(childForm);
            PlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            //ShowPropertiesOfSlateBlue(e);
        }

        

        private void BtnClients_Click(object sender, EventArgs e)
        {
            LblNameMain.Text = "CLIENTES";
            BtnMaintenance.BackColor = Color.FromArgb(109, 119, 129);
            BtnClients.BackColor = Color.FromArgb(127, 127, 127);
            BtnArticles.BackColor = Color.FromArgb(111, 111, 109);
            BtnRefactions.BackColor = Color.FromArgb(111, 111, 109);
            BtnServices.BackColor = Color.FromArgb(111, 111, 109);
            BtnTechnicians.BackColor = Color.FromArgb(111, 111, 109);
            OpenChildForm(new FrmClient());
        }

        private void BtnArticles_Click(object sender, EventArgs e)
        {
            LblNameMain.Text = "ARTICULOS";
            BtnMaintenance.BackColor = Color.FromArgb(109, 119, 129);
            BtnClients.BackColor = Color.FromArgb(111, 111, 109);
            BtnArticles.BackColor = Color.FromArgb(127, 127, 127);
            BtnRefactions.BackColor = Color.FromArgb(111, 111, 109);
            BtnServices.BackColor = Color.FromArgb(111, 111, 109);
            BtnTechnicians.BackColor = Color.FromArgb(111, 111, 109);
            OpenChildForm(new FrmArticle());
        }
        private void BtnRefactions_Click(object sender, EventArgs e)
        {
            LblNameMain.Text = "REPUESTOS";
            BtnMaintenance.BackColor = Color.FromArgb(109, 119, 129);
            BtnClients.BackColor = Color.FromArgb(111, 111, 109);
            BtnArticles.BackColor = Color.FromArgb(111, 111, 109);
            BtnRefactions.BackColor = Color.FromArgb(127, 127, 127);
            BtnServices.BackColor = Color.FromArgb(111, 111, 109);
            BtnTechnicians.BackColor = Color.FromArgb(111, 111, 109);
            OpenChildForm(new FrmRefactions());
        }
        private void BtnServices_Click(object sender, EventArgs e)
        {
            LblNameMain.Text = "SERVICIOS";
            BtnMaintenance.BackColor = Color.FromArgb(109, 119, 129);
            BtnClients.BackColor = Color.FromArgb(111, 111, 109);
            BtnArticles.BackColor = Color.FromArgb(111, 111, 109);
            BtnRefactions.BackColor = Color.FromArgb(111, 111, 109);
            BtnServices.BackColor = Color.FromArgb(127, 127, 127);
            BtnTechnicians.BackColor = Color.FromArgb(111, 111, 109);
            OpenChildForm(new FrmService());
        }
        private void BtnTechnician_Click(object sender, EventArgs e)
        {
            LblNameMain.Text = "TECNICOS";
            BtnMaintenance.BackColor = Color.FromArgb(109, 119, 129);
            BtnClients.BackColor = Color.FromArgb(111, 111, 109);
            BtnArticles.BackColor = Color.FromArgb(111, 111, 109);
            BtnRefactions.BackColor = Color.FromArgb(111, 111, 109);
            BtnServices.BackColor = Color.FromArgb(111, 111, 109);
            BtnTechnicians.BackColor = Color.FromArgb(127,127,127);
            OpenChildForm(new FrmTechnician());
        }

        












        //private void ShowPropertiesOfSlateBlue(PaintEventArgs e)
        //{
        //    Color slateBlue = Color.FromName("Brown");
        //    byte g = slateBlue.G;
        //    byte b = slateBlue.B;
        //    byte r = slateBlue.R;
        //    byte a = slateBlue.A;
        //    string text = String.Format("jajajajaja these ARGB values: Alpha:{0}, " +
        //        "red:{1}, green: {2}, blue {3}", new object[] { a, r, g, b });
        //    e.Graphics.DrawString(text,
        //        new Font(this.Font, FontStyle.Italic),
        //        new SolidBrush(slateBlue),
        //        new RectangleF(new PointF(0.0F, 0.0F), this.Size));
        //}
    }
}
