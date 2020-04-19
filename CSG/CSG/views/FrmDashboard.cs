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

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            ShowSubmenu(PlOrdersSubmenu);
        }

        private void BtnMaintenance_Click(object sender, EventArgs e)
        {
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

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //ShowPropertiesOfSlateBlue(e);
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            BtnClients.BackColor = Color.Red;
            BtnTechnician.BackColor = Color.FromArgb(111, 111, 109);
            OpenChildForm(new FrmClient());
        }

        private void BtnTechnician_Click(object sender, EventArgs e)
        {
            BtnClients.BackColor = Color.FromArgb(111, 111, 109);
            BtnTechnician.BackColor = Color.Red;
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
