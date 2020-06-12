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
    public partial class RptOrderCreate : Form
    {
        public RptOrderCreate()
        {
            InitializeComponent();
        }

        private void RptOrderCreate_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Order.Order_number_st))
            {
                var rpt = new report.SystemSupportReport();
                RwOrderCreate.ReportSource = rpt.GetReportOrderCreate(Order.Order_number_st);
            }
            else
            {
                MessageBox.Show("No hay un numero de orden", "Aviso", MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
        }
    }
}
