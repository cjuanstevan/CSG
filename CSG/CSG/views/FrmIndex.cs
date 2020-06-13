using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.persistence;

namespace CSG.views
{
    public partial class FrmIndex : Form
    {
        public FrmIndex()
        {
            InitializeComponent();
        }

        private void FrmIndex_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
        private void LoadDashboardData()
        {
            ArrayList X = new ArrayList();
            X.Add("una");
            X.Add("dos");
            X.Add("tres");
            ArrayList Y = new ArrayList();
            Y.Add(5);
            Y.Add(10);
            Y.Add(20);
            //chartClients.Series[0].Points.DataBindXY(X, Y);
            string[] data = DAOFactory.GetDashboardDAO().DashboardData();
            //chartClients.Series["Clientes"].Points.AddXY("Total", int.Parse(data[0])+ int.Parse(data[1]));
            chartClients.Series["Clientes"].Points.AddY(int.Parse(data[0])+ int.Parse(data[1]));
            //chartClients.Series["Clientes"].Points.AddXY("Total2", int.Parse(data[0]) + int.Parse(data[1]));
            chartClients2.Series[0].Points.AddY(int.Parse(data[0]));
            chartClients2.Series[1].Points.AddY(int.Parse(data[1]));
            //chartClients2.Series[1].Points.AddY(int.Parse(data[1]));
            chartOrderRec.Series[0].Points.AddY(27);
        }
    }
}
