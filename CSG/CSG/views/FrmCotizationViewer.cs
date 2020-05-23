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
    public partial class FrmCotizationViewer : Form
    {
        private readonly OrderLog orderLog = new OrderLog();
        private readonly CotizationLog cotizationLog = new CotizationLog();
        private readonly OrderArticleLog orderArticleLog = new OrderArticleLog();
        private readonly ArticleLog articleLog = new ArticleLog();
        private readonly CotizationServiceLog cotizationServiceLog = new CotizationServiceLog();
        private readonly ServiceLog serviceLog = new ServiceLog();
        private readonly CotizationRefactionLog cotizationRefactionLog = new CotizationRefactionLog();
        private readonly RefactionLog refactionLog = new RefactionLog();
        //Vars
        DataTable dtsr = new DataTable();
        DataColumn column;
        DataRow row;
        public FrmCotizationViewer()
        {
            InitializeComponent();
        }

        private void FrmCotizationViewer_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Orden: " + Order.Order_number_st);
            Order order = orderLog.Read_once(Order.Order_number_st);
            txtCotizationId.Text = order.Cotization.Cotization_id;
            txtOrderType.Text = order.Order_type;
            txtOrderNumber.Text = order.Order_number;
            txtOrderState.Text = order.Order_state;
            //Agregamos el cliente
            txtClientId.Text = order.Client.Client_id;
            txtClientName.Text = order.Client.Client_name;
            txtClientL1.Text = order.Client.Client_lastname1;
            txtClientL2.Text = order.Client.Client_lastname2;
            txtClientAddress.Text = order.Client.Client_address;
            txtClientLocation.Text = order.Client.Client_location;
            txtClientCity.Text = order.Client.Client_city;
            txtClientDpt.Text = order.Client.Client_department;
            txtClientTel1.Text = order.Client.Client_tel1;
            txtClientTel2.Text = order.Client.Client_tel2;
            txtClientEmail.Text = order.Client.Client_email;
            //Agregamos el equipo
            Article article = articleLog.Read_once(orderArticleLog.Read_code_article_of_order(Order.Order_number_st));
            txtArticleCode.Text = article.Article_code;
            txtArticleDescription.Text = article.Article_description;
            CreateDataTable();
            //Agregamos los servicios
            AddServices();
            //Agregamos los repuesto
            AddRefactions();
            //Comentarios
            //Console.WriteLine("Reporte cliente: " + order.Order_report_client);
            string comentarys = "";
            comentarys += "Cliente: "+ Environment.NewLine + order.Order_report_client + 
                Environment.NewLine + Environment.NewLine;
            Cotization cotization = cotizationLog.Read_once(txtCotizationId.Text);
            comentarys += "Técnico: " + Environment.NewLine + cotization.Cotization_comentarys;
            txtComentarys.Text = comentarys;
            //Cargamos subtotal, descuento, iva y total
            lblSubtotal.Text = cotization.Cotization_subtotal.ToString("C2");
            lblDiscount.Text = cotization.Cotization_discount.ToString("C2");
            lblIva.Text = cotization.Cotization_iva.ToString("C2");
            lblTotal.Text = cotization.Cotization_total.ToString("C2");
        }

        private void AddServices()
        {
            List<Cotization_serviceFK> cotization_ServiceFKs = cotizationServiceLog.Read_ServicesOfCotization(txtCotizationId.Text);
            foreach (var cs in cotization_ServiceFKs)
            {
                Service service = serviceLog.Read_once(cs.Service_code);
                Console.WriteLine("Code: {0} | Actividad: {1}",service.Service_code,service.Service_activity);
                row = dtsr.NewRow();
                row[0] = "Servicio";
                row[1] = service.Service_code;
                row[2] = service.Service_activity;
                row[3] = Int32.Parse("1");
                row[4] = Decimal.Parse(service.Service_cost).ToString("C2");
                row[5] = Decimal.Parse(service.Service_cost).ToString("C2");
                dtsr.Rows.Add(row);
            }
        }
        private void AddRefactions()
        {
            List<Cotization_refactionFK> cotization_RefactionFKs = cotizationRefactionLog.Read_RefactionsOfCotization(txtCotizationId.Text);
            foreach (var cr in cotization_RefactionFKs)
            {
                Refaction refaction = refactionLog.Read_once(cr.Refaction_code);
                Console.WriteLine("Code: {0} | Descripción: {1}", refaction.Refaction_code, refaction.Refaction_description);
                row = dtsr.NewRow();
                row[0] = "Refacción";
                row[1] = refaction.Refaction_code;
                row[2] = refaction.Refaction_description;
                row[3] = cr.Refaction_quantity;
                row[4] = refaction.Refaction_unit_price.ToString("C2");
                row[5] = cr.Refaction_amount.ToString("C2");
                dtsr.Rows.Add(row);
            }
        }

        private void CreateDataTable()
        {
            /*******************SERVICES Y REFACTIONS*************************/
            //Creamos la primer columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TIPO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtsr.Columns.Add(column);
            // Creamos la segunda columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CÓDIGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtsr.Columns.Add(column);
            // Creamos la tercera columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESCRIPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtsr.Columns.Add(column);
            // Creamos la cuarta columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "CANTIDAD",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtsr.Columns.Add(column);
            // Creamos la quinta columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "P. UNITARIO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtsr.Columns.Add(column);
            // Creamos la sexta columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "IMPORTE",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtsr.Columns.Add(column);
            DgvSr.DataSource = dtsr;

        }
    }
}
