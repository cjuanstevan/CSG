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
    public partial class FrmOrderCreate : Form , ICom
    {
        private readonly OrderLog orderLog = new OrderLog();
        private readonly ArticleLog articleLog = new ArticleLog();
        private readonly TechnicianLog technicianLog = new TechnicianLog();
        private readonly ClientLog clientLog = new ClientLog();
        private readonly CotizationLog cotizationLog = new CotizationLog();
        private readonly OrderArticleLog orderArticleLog = new OrderArticleLog();
        private readonly CategoryLog categoryLog = new CategoryLog();
        //Objetos
        //Article article;

        //Arreglos
        readonly string[] PrOrder = { "RL", "GL", "RF", "GF", "SD" };
        //readonly string[] TyOrder = { "Reparación Local" };
        private DataTable dtoa = new DataTable();
        private DataColumn column;
        private DataRow row;
        public FrmOrderCreate()
        {
            InitializeComponent();
        }

        //Evento Load del formulario
        private void FrmOrderCreate_Load(object sender, EventArgs e)
        {
            //estado predeterminado de los controles
            cboType.SelectedIndex = 0;
            cboWarranty.SelectedIndex = 1;
            dtpDateReception.CustomFormat = ("yyyy-MM-dd HH:mm:ss");
            LoadCboCategories();
            CreateDataTable();
            timer1.Start();

            //PERMISOS DE USUARIO
            //Si el usuario es Recepcionista
            if (UserCache.UserRol.Equals(Roles.REC))
            {

            }
            //Si el usuario es técnico
            if (UserCache.UserRol.Equals(Roles.TEC))
            {

            }
            //Si el usuario es jefe técnico
            if (UserCache.UserRol.Equals(Roles.JTE))
            {

            }
            //Si el usuario es administrador
            if (UserCache.UserRol.Equals(Roles.ADM))
            {

            }
        }
        private void LoadCboCategories()
        {
            cboCategories.Items.Clear();
            List<Category> categories = categoryLog.Read_all();
            foreach (var c in categories)
            {
                cboCategories.Items.Add(c.Category_name);
            }
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

        private void TxtArticleCod_TextChanged(object sender, EventArgs e)
        {
            txtArticleDesc.Clear();
            //txtArticleModel.Clear();
            //txtArticleSerial.Clear();
            //txtArticleWarranty.Clear();
            bool request = articleLog.Read_once_exist(txtArticleCod.Text);
            if (request)
            {
                Article article = articleLog.Read_once(txtArticleCod.Text);
                txtArticleDesc.Text = article.Article_description;
                //txtArticleModel.Text = article.Article_model;
                //txtArticleSerial.Text = article.Article_serial;
                //txtArticleWarranty.Text = article.Article_warranty.ToString();
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


        /*//DateTime localDate = DateTime.Now;
            Order order = new Order();
            order.Order_number = txtNumber.Text;
            //DateTime.Parse(localDate.ToString("yyyy-MM-dd HH:mm:ss"));
            order.Order_reception_date = DateTime.Parse(dtpDateReception.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            order.Order_end_date = dtpDateReception.Value;
            order.Order_type = cboType.Text;
            //MessageBox.Show("Seleccionó " + cboWarranty.SelectedItem.ToString());
            order.Order_invoice = txtInvoice.Text;
            if (cboWarranty.SelectedIndex.Equals(0))
            {
                order.Order_sale_date = dtpSaleDate.Value;
            }
            //order.Order_state = "RECEPCIÓN";
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
            ResetControls(sender, e);*/

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

        

        private void CboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumber.Text = PrOrder[cboType.SelectedIndex] + "-" + orderLog.Read_count().ToString();
        }

        private void CboWarranty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SI
            if (cboWarranty.SelectedIndex.Equals(0))
            {
                txtInvoice.Enabled = true;
                dtpSaleDate.Enabled = true;
            }
            //NO
            else if (cboWarranty.SelectedIndex.Equals(1))
            {
                txtInvoice.Enabled = false;
                dtpSaleDate.Enabled = false;
            }
        }

        private void BtnReadTechnician_Click(object sender, EventArgs e)
        {
           
        }

        public void TechnicianText(string id)
        {
            txtTechnicianId.Text = id;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dtpDateReception.Value = DateTime.Now;
        }

        private void ResetControls(object sender, EventArgs e)
        {
            cboType.SelectedIndex = 0;
            txtNumber.Clear();
            CboType_SelectedIndexChanged(sender, e);
            txtClientId.Clear();
            txtArticleCod.Clear();
            cboWarranty.SelectedIndex = 1;
            txtInvoice.Clear();
            txtReportClient.Clear();
            txtTechnicianId.Clear();
        }

       

        //Evento del botón "Crear"
        private void IbtnCreate_Click(object sender, EventArgs e)
        {
            //DateTime localDate = DateTime.Now;
            Order order = new Order();
            order.Order_number = txtNumber.Text;
            //DateTime.Parse(localDate.ToString("yyyy-MM-dd HH:mm:ss"));
            order.Order_reception_date = DateTime.Parse(dtpDateReception.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            //order.Order_end_date = dtpDateReception.Value;
            order.Order_type = cboType.Text;
            //MessageBox.Show("Seleccionó " + cboWarranty.SelectedItem.ToString());
            order.Order_invoice = txtInvoice.Text;
            if (cboWarranty.SelectedIndex.Equals(0))
            {
                order.Order_sale_date = dtpSaleDate.Value;
            }
            //order.Order_state -> Se envia desde DAO
            //order.Order_comentarys = ""; -> Por definir funcionalidad
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
            //Capturamos el usuario que creará la orden
            order.Create_by = UserCache.UserAccount;
            //Capturamos el momento de la creacion
            order.Create_date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //Creación de orden
            orderLog.Create(order);
            //Creamos el order_article para que asigne el artículo sobre el cual se va a operar
            //En una orden van n articulos, estos se definen en la tabla
            for (int i = 0; i < dtoa.Rows.Count; i++)
            {
                Order_articleFK order_articleFK = new Order_articleFK
                {
                    Order_number = order.Order_number,
                    Article_code = dtoa.Rows[i][0].ToString(),
                    Model = dtoa.Rows[i][2].ToString(),
                    Especification = dtoa.Rows[i][3].ToString(),
                    Serial = dtoa.Rows[i][4].ToString()
                };
                orderArticleLog.Create(order_articleFK);
            }
            //ResetControls(sender, e);
        }


        private void IbtnClient_Click(object sender, EventArgs e)
        {
            CdoClient cdoClient = new CdoClient();
            cdoClient.com = this;
            cdoClient.ShowDialog();
        }

        private void IbtnArticle_Click(object sender, EventArgs e)
        {
            CdoArticle cdoArticle = new CdoArticle();
            cdoArticle.com = this;
            cdoArticle.ShowDialog();
        }

        private void IbtnTechnician_Click(object sender, EventArgs e)
        {
            CdoTechnician cdoTechnician = new CdoTechnician();
            cdoTechnician.com = this;
            cdoTechnician.ShowDialog();
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
            dtoa.Columns.Add(column);
            // Columna 2->Cliente
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESCRIPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtoa.Columns.Add(column);
            // Columna 3->CIUDAD O MUNICIPIO
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "MODELO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtoa.Columns.Add(column);
            // Columna 4->departamento
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ESPECIFICACIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtoa.Columns.Add(column);
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "SERIAL",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtoa.Columns.Add(column);
            DgvOa.DataSource = dtoa;
        }

        private void IbtnAddArticle_Click(object sender, EventArgs e)
        {
            //Consultamos el articulo
            Article article = articleLog.Read_once(txtArticleCod.Text);
            row = dtoa.NewRow();
            row[0] = article.Article_code;
            row[1] = article.Article_description;
            row[2] = txtArticleModel.Text;
            row[3] = txtArticleEsp.Text;
            row[4] = txtArticleSerial.Text;
            dtoa.Rows.Add(row);
        }
    }
}
