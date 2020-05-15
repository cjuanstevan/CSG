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
    public partial class FrmOrderCreate : Form , ICom
    {
        private readonly OrderLog orderLog = new OrderLog();
        private readonly ArticleLog articleLog = new ArticleLog();
        private readonly TechnicianLog technicianLog = new TechnicianLog();
        private readonly ClientLog clientLog = new ClientLog();
        private readonly CotizationLog cotizationLog = new CotizationLog();
        private readonly OrderArticleLog orderArticleLog = new OrderArticleLog();
        //Objetos
        Article article;

        //Arreglos
        readonly string[] PrOrder = { "RL", "GL", "RF", "GF", "SD" };
        //readonly string[] TyOrder = { "Reparación Local" };
        public FrmOrderCreate()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, EventArgs e)
        {
            CdoClient cdoClient = new CdoClient();
            cdoClient.com = this;
            cdoClient.ShowDialog();
            //FrmClient frmClient = new FrmClient();
            //frmClient.ShowDialog();
            //Form dlg1 = new Form();
            //string texto = dlg1.AutoScaleDimensions.ToString();
            //dlg1.ShowDialog();
        }

        private void TxtClientId_TextChanged(object sender, EventArgs e)
        {
            txtClientName.Clear();
            bool request = clientLog.Read_once_exist(txtClientId.Text);
            if (request)
            {
                LblClientIdMsj.Text = "";
                Client client = clientLog.Read_once(txtClientId.Text);
                txtClientName.Text = client.Client_name + " " + client.Client_lastname1 + " " + client.Client_lastname2;
            }
            else
            {
                LblClientIdMsj.Text = "No se encuentra";
            }
            if (txtClientId.Text.Equals(""))
            {
                LblClientIdMsj.Text = "";
            }
        }

        private void BtnReadArticle_Click(object sender, EventArgs e)
        {
            CdoArticle cdoArticle = new CdoArticle();
            cdoArticle.com = this;
            cdoArticle.ShowDialog();
        }

        private void TxtArticleCod_TextChanged(object sender, EventArgs e)
        {
            txtArticleDesc.Clear();
            txtArticleModel.Clear();
            txtArticleSerial.Clear();
            txtArticleWarranty.Clear();
            bool request = articleLog.Read_once_exist(txtArticleCod.Text);
            if (request)
            {
                article = articleLog.Read_once(txtArticleCod.Text);
                txtArticleDesc.Text = article.Article_description;
                txtArticleModel.Text = article.Article_model;
                txtArticleSerial.Text = article.Article_serial;
                txtArticleWarranty.Text = article.Article_warranty.ToString();
            }
        }

        private void TxtTechnicianId_TextChanged(object sender, EventArgs e)
        {
            txtTechnicianName.Clear();
            txtTechnicianTelephone.Clear();
            txtTechnicianContact.Clear();
            txtTechnicianAlias.Clear();
            bool request = technicianLog.Read_once_exist(txtTechnicianId.Text);
            if (request)
            {
                Technician technician = technicianLog.Read_once(txtTechnicianId.Text);
                txtTechnicianName.Text = technician.Technician_name;
                txtTechnicianTelephone.Text = technician.Technician_telephone;
                txtTechnicianContact.Text = technician.Technician_contact;
                txtTechnicianAlias.Text = technician.Technician_alias;
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Order_number = txtNumber.Text;
            order.Order_reception_date = dtpDateReception.Value;
            order.Order_end_date = dtpDateReception.Value;
            order.Order_type = cboType.Text;
            //MessageBox.Show("Seleccionó " + cboWarranty.SelectedItem.ToString());
            order.Order_invoice = txtInvoice.Text;
            if (cboWarranty.SelectedIndex.Equals(0))
            {
                order.Order_sale_date = dtpSaleDate.Value;
            }
            order.Order_state = "Revisión";
            //order.Order_comentarys = "";
            order.Order_report_client = txtReportClient.Text;
            //Técnico
            Technician t = technicianLog.Read_once(txtTechnicianId.Text);
            order.Technician = t;
            //Cliente
            Client c = clientLog.Read_once(txtClientId.Text);
            order.Client = c;
            //Cotización
            //Creamos cotización
            Cotization cotization = new Cotization
            {
                Cotization_id = "CT-" + PrOrder[cboType.SelectedIndex] + "" + orderLog.Read_count().ToString()
            };
            cotizationLog.Create(cotization);
            //Consultamos la cotización
            Cotization cn = cotizationLog.Read_once(cotization.Cotization_id);
            //MessageBox.Show("Cotizacion: " + cn.Cotization_id);
            order.Cotization = cn;
            //Creación de orden
            orderLog.Create(order);
            //Creamos el order_article para que asigne el artículo sobre el cual se va a operar
            Order_articleFK order_articleFK = new Order_articleFK
            {
                Order = order,
                Article = article
            };
            orderArticleLog.Create(order_articleFK);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Pruebas
            //MessageBox.Show("Prefijo: " + PrOrder[cboType.SelectedIndex]);
            txtNumber.Text = PrOrder[cboType.SelectedIndex] + "-" + orderLog.Read_count().ToString();
            //MessageBox.Show("Consecutivo: " + orderLog.Read_count());
        }

        public void ClientText(string id)
        {
            txtClientId.Text = id;
        }

        public void ArticleText(string code)
        {
            txtArticleCod.Text = code;
        }

        private void FrmOrderCreate_Load(object sender, EventArgs e)
        {
            //estado predeterminado de los controles
            cboWarranty.SelectedIndex = 1;
        }

        private void CboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumber.Text = PrOrder[cboType.SelectedIndex] + "-" + orderLog.Read_count().ToString();
        }

        private void CboWarranty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWarranty.SelectedIndex.Equals(0))
            {
                txtInvoice.Enabled = true;
                dtpSaleDate.Enabled = true;
            }
            else if (cboWarranty.SelectedIndex.Equals(1))
            {
                txtInvoice.Enabled = false;
                dtpSaleDate.Enabled = false;
            }
        }

        private void BtnReadTechnician_Click(object sender, EventArgs e)
        {
            CdoTechnician cdoTechnician = new CdoTechnician();
            cdoTechnician.com = this;
            cdoTechnician.ShowDialog();
        }

        public void TechnicianText(string id)
        {
            txtTechnicianId.Text = id;
        }
    }
}
