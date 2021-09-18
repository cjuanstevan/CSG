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
using System.Windows.Forms.DataVisualization.Charting;
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
            //ÓRDENES
            string[] data_order = DAOFactory.GetDashboardDAO().Dashboard_Order();
            lblTotalGral.Text = (int.Parse(data_order[0]) + int.Parse(data_order[1]) + int.Parse(data_order[2]) +
                int.Parse(data_order[3]) + int.Parse(data_order[4])).ToString();
            chartOrderRec.Series[0].Points.AddY(int.Parse(data_order[0]));
            chartOrderCot.Series[0].Points.AddY(int.Parse(data_order[1]));
            chartOrderEE.Series[0].Points.AddY(int.Parse(data_order[2]));
            chartOrderCancel.Series[0].Points.AddY(int.Parse(data_order[3]));
            chartOrderFact.Series[0].Points.AddY(int.Parse(data_order[4]));
            //order_articles
            string[,] data_ordArt = DAOFactory.GetDashboardDAO().Dashboard_OrderArticleTop3();
            chartOrderArticle.Series["SeriesTop1"].LegendText = data_ordArt[0, 0];
            chartOrderArticle.Series["SeriesTop2"].LegendText = data_ordArt[1, 0];
            chartOrderArticle.Series["SeriesTop3"].LegendText = data_ordArt[2, 0];
            chartOrderArticle.Series["SeriesTop1"].Points.AddY(int.Parse(data_ordArt[0, 1]));
            chartOrderArticle.Series["SeriesTop2"].Points.AddY(int.Parse(data_ordArt[1, 1]));
            chartOrderArticle.Series["SeriesTop3"].Points.AddY(int.Parse(data_ordArt[2, 1]));

            //ARTICULOS
            string[,] data_categories = DAOFactory.GetDashboardDAO().Dashboard_CategoryXarticle();
            //chart1.Series[0].Points.AddY(int.Parse(data_order[0]));
            chartCategoryXarticle.Series["SeriesTop1"].LegendText = data_categories[0, 0];
            chartCategoryXarticle.Series["SeriesTop2"].LegendText = data_categories[1, 0];
            chartCategoryXarticle.Series["SeriesTop3"].LegendText = data_categories[2, 0];
            chartCategoryXarticle.Series["SeriesTop4"].LegendText = data_categories[3, 0];
            chartCategoryXarticle.Series["SeriesTop5"].LegendText = data_categories[4, 0];
            //chartCategoryXarticle.Series["SeriesTop6"].LegendText = data_categories[5, 0];

            chartCategoryXarticle.Series["SeriesTop1"].Points.AddY(int.Parse(data_categories[0, 1]));
            chartCategoryXarticle.Series["SeriesTop2"].Points.AddY(int.Parse(data_categories[1, 1]));
            chartCategoryXarticle.Series["SeriesTop3"].Points.AddY(int.Parse(data_categories[2, 1]));
            chartCategoryXarticle.Series["SeriesTop4"].Points.AddY(int.Parse(data_categories[3, 1]));
            chartCategoryXarticle.Series["SeriesTop5"].Points.AddY(int.Parse(data_categories[4, 1]));
            //chartCategoryXarticle.Series["SeriesTop6"].Points.AddY(int.Parse(data_categories[5, 1]));
            int suma = 0;
            for (int i = 0; i < 5; i++)
            {
                suma += int.Parse(data_categories[i, 1]);
            }
            lblTotArticles.Text = suma.ToString();
            //chartCategoryXarticle.Series["SeriesTop1"].Points.AddXY(data_categories[0, 0], int.Parse(data_categories[0, 1]));
            //chartCategoryXarticle.Series["SeriesTop2"].Points.AddXY(data_categories[1, 0], int.Parse(data_categories[1, 1]));
            //chartCategoryXarticle.Series["SeriesTop3"].Points.AddXY(data_categories[2, 0], int.Parse(data_categories[2, 1]));
            //chartCategoryXarticle.Series["SeriesTop4"].Points.AddXY(data_categories[3, 0], int.Parse(data_categories[3, 1]));
            //chartCategoryXarticle.Series["SeriesTop5"].Points.AddXY(data_categories[4, 0], int.Parse(data_categories[4, 1]));
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
            lblTotalClients.Text = (int.Parse(data[0]) + int.Parse(data[1])).ToString();
            //chartClients.Series["Clientes"].Points.AddXY("Total", int.Parse(data[0])+ int.Parse(data[1]));
            chartClients.Series["Clientes"].Points.AddY(int.Parse(data[0])+ int.Parse(data[1]));
            //chartClients.Series["Clientes"].Points.AddXY("Total2", int.Parse(data[0]) + int.Parse(data[1]));
            chartClients2.Series[0].Points.AddY(int.Parse(data[0]));
            chartClients2.Series[1].Points.AddY(int.Parse(data[1]));
            //chartClients2.Series[1].Points.AddY(int.Parse(data[1]));
            //chartOrderRec.Series[0].Points.AddY(27);
        }

        private void Ipb3D_Click(object sender, EventArgs e)
        {
            if (Ipb3D.Tag.ToString() == "off")
            {
                //Cambiamos la apariencia del boton a ToggleOn
                Ipb3D.IconChar = FontAwesome.Sharp.IconChar.ToggleOn;
                Ipb3D.Tag = "on";
                lbl3Dstate.ForeColor = Color.Green;
                lbl3Dstate.Text = "Activado";
                //Activamos el 3D
                chartOrderRec.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartOrderCot.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartOrderEE.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartOrderCancel.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartOrderFact.ChartAreas[0].Area3DStyle.Enable3D = true;
                chartOrderArticle.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else if (Ipb3D.Tag.ToString() == "on")
            {
                //Cambiamos la apariencia del boton a ToggleOff
                Ipb3D.IconChar = FontAwesome.Sharp.IconChar.ToggleOff;
                Ipb3D.Tag = "off";
                lbl3Dstate.ForeColor = Color.Black;
                lbl3Dstate.Text = "Desactivado";
                //Desactivamos el 3D
                chartOrderRec.ChartAreas[0].Area3DStyle.Enable3D = false;
                chartOrderCot.ChartAreas[0].Area3DStyle.Enable3D = false;
                chartOrderEE.ChartAreas[0].Area3DStyle.Enable3D = false;
                chartOrderCancel.ChartAreas[0].Area3DStyle.Enable3D = false;
                chartOrderFact.ChartAreas[0].Area3DStyle.Enable3D = false;
                chartOrderArticle.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
        }

        private void Ipb3D_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Ipb3D, "Active o desactive 3D");
        }
    }
}
