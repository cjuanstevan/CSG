﻿using CSG.cache;
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
using System.Globalization;

namespace CSG.views
{
    public partial class FrmCotizationCreate : Form
    {
        private readonly OrderLog orderLog = new OrderLog();
        private readonly OrderArticleLog orderArticleLog = new OrderArticleLog();
        private readonly ArticleLog articleLog = new ArticleLog();
        private readonly ServiceLog serviceLog = new ServiceLog();
        private readonly RefactionLog refactionLog = new RefactionLog();
        private readonly CotizationLog cotizationLog = new CotizationLog();
        private readonly CotizationServiceLog cotizationServiceLog = new CotizationServiceLog();
        private readonly CotizationRefactionLog cotizationRefactionLog = new CotizationRefactionLog();
        private readonly TaxLog taxLog = new TaxLog();
        private readonly CategoryLog categoryLog = new CategoryLog();

        //Data Services
        //DataSet dataSet;
        DataTable dtoa = new DataTable();
        DataTable dts = new DataTable();
        DataTable dtr = new DataTable();
        DataColumn column;
        DataRow row;
        //Objetos
        Order order;
        public FrmCotizationCreate()
        {
            InitializeComponent();
        }

        private void FrmCotizationCreate_Load(object sender, EventArgs e)
        {
            //Estado de los controles del formulario
            txtServiceCode.Focus();
            //Consultamos la orden requerida. pruebas con RL-15
            string order_number = Order.Order_number_st;
            order = orderLog.Read_once(order_number);
            txtOrder.Text = order.Order_number;
            dtpReception_date.Value = order.Order_reception_date;
            txtOrderType.Text = order.Order_type;
            txtOrderState.Text = order.Order_state;
            //Agregamos el objeto Technician
            txtTechnicianName.Text = order.Technician.Technician_name;
            txtTechnicianTelephone.Text = order.Technician.Technician_telephone;
            txtTechnicianContact.Text = order.Technician.Technician_contact;
            //Consultamos el código del equipo asignado a la orden en order_article
            string code = orderArticleLog.Read_code_article_of_order(order.Order_number);
            //Consultamos el artículo con el código de orden anterior
            Article article = articleLog.Read_once(code);
            txtArticleCode.Text = article.Article_code;
            txtArticleDescription.Text = article.Article_description;
            Category category = categoryLog.Read_once(article.Category);
            txtCategory.Text = category.Category_name;
            //Consultamos en order article para traer el modelo->nro lote, especificacion y serial
            Order_articleFK order_ArticleFK = orderArticleLog.Read_ArticleOfOrder(order_number);
            txtArticleModel.Text = order_ArticleFK.Model;
            txtArticleEsp.Text = order_ArticleFK.Especification;
            txtArticleSerial.Text = order_ArticleFK.Serial;
            //Agregamos el campo report client
            txtReportClient.Text = order.Order_report_client;
            AutoCompleteService();
            AutoCompleteRefaction();
            CreateDataTables();
            //Console.WriteLine("IVA: " + taxLog.Read_once_value("19"));
            //Cargamos los articulos asociados a la orden
            //LoadArticlesOfOrder();
        }
        private void LoadArticlesOfOrder()
        {
            //List<Order_articleFK> order_Articles = orderArticleLog.Read_ArticlesOfOrder(Order.Order_number_st);
            //foreach (var oa in order_Articles)
            //{
            //    Article article = articleLog.Read_once(oa.Article_code);
            //    Console.WriteLine("Orden: " + oa.Order_number + " | Articulo: " + oa.Article_code);
            //    row = dtoa.NewRow();
            //    row[0] = article.Article_code;
            //    row[1] = article.Article_description;
            //    row[2] = oa.Model;
            //    row[3] = oa.Especification;
            //    row[4] = oa.Serial;
            //    dtoa.Rows.Add(row);
            //    //Agregamos al combo1
            //    cboArticles1.Items.Add(article.Article_code);
            //    //Agregamos al combo2
            //    cboArticles2.Items.Add(article.Article_code);
            //}
           
        }
        private void AutoCompleteService()
        {
            txtServiceCode.AutoCompleteCustomSource = AddAutoCompleteService();
            txtServiceCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtServiceCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private AutoCompleteStringCollection AddAutoCompleteService()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            List<Service> services = serviceLog.ReadAll();
            foreach (var s in services)
            {
                collection.Add(s.Service_code + " " + s.Service_activity);
            }
            return collection;
        }

        private void AutoCompleteRefaction()
        {
            txtRefactionCode.AutoCompleteCustomSource = AddAutoCompleteRefaction();
            txtRefactionCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtRefactionCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private AutoCompleteStringCollection AddAutoCompleteRefaction()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            List<Refaction> refactions = refactionLog.ReadAll();
            foreach (var r in refactions)
            {
                collection.Add(r.Refaction_code + " " + r.Refaction_description);
            }
            return collection;
        }
        private void IbtnAddService_Click(object sender, EventArgs e)
        {
            string text = txtServiceCode.Text;
            string[] words = text.Split(' ');
            if (serviceLog.Read_once_exist(words[0]))
            {
                Service service = serviceLog.Read_once(words[0]);
                //Validar que no exista codigo en la tabla
                if (SearchDtCode(dts, words[0]))
                {
                    row = dts.NewRow();
                    row[0] = service.Service_code;
                    row[1] = service.Service_activity;
                    row[2] = Convert.ToInt32(nupQuantity.Value);
                    row[3] = service.Service_type;
                    dts.Rows.Add(row);
                }
                else
                {
                    MessageBox.Show("El servicio ya se agregó al equipo");
                }
            }
            txtServiceCode.Clear();
            txtServiceCode.Focus();
        }

        private void IbtnAddRefaction_Click(object sender, EventArgs e)
        {
            string text = txtRefactionCode.Text;
            string[] words = text.Split(' ');
            if (refactionLog.Read_once_exist(words[0]))
            {
                Refaction refaction = refactionLog.Read_once(words[0]);
                //Validar que no exista codigo en la tabla
                //if (SearchDtCode(dtr, words[0]))
                //{
                if (SearchDtCode(dtr, words[0]))
                {
                    row = dtr.NewRow();
                    row[0] = refaction.Refaction_code;
                    row[1] = refaction.Refaction_description;
                    row[2] = Convert.ToInt32(NupQR.Value);
                    dtr.Rows.Add(row);
                }
                else
                {
                    MessageBox.Show("El repuesto ya se agregó al equipo");
                }
            }
            txtRefactionCode.Clear();
            txtRefactionCode.Focus();
        }

        private void CreateDataTables()
        {
            /*******************SERVICES*************************/
            //Creamos la primer columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CÓDIGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            // Creamos la segunda columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ACTIVIDAD",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            // Creamos la cuarta columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "CANTIDAD",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            // Creamos la quinta columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Char"),
                ColumnName = "TIPO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dts.Columns.Add(column);
            DgvServices.DataSource = dts;


            /*******************REFACTIONS*************************/
            //Creamos la primer columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CÓDIGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtr.Columns.Add(column);
            // Creamos la segunda columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESCRIPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtr.Columns.Add(column);
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CANTIDAD",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtr.Columns.Add(column);
            DgvRefactions.DataSource = dtr;
        }

        private void BtnReadService_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cantidad: " + dts.Rows.Count);
            for (int i = 0; i < dts.Rows.Count; i++)
            {
               Console.WriteLine(dts.Rows[i][0]);
            }
        }

        //Metodo que recorre el DataTable para validar que no se repita el código+articulo
        private bool SearchDtCode(DataTable dt, string text)
        {
            bool request = true;
            //MessageBox.Show("Cantidad: " + dt.Rows.Count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Console.WriteLine(dt.Rows[i][0] + "==" + text);
                if (dt.Rows[i][0].ToString().Equals(text))
                {
                    request = false;
                    break;
                }
            }
            return request;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private bool ValidateData()
        {
            //bool request = true;
            //Validamos que haya agregado servicios
            if (dts.Rows.Count.Equals(0))
            {
                //request = false;
                MessageBox.Show("Agregue servicios");
                return false;
            }
            //Validamos que haya agregado repuestos
            if (dtr.Rows.Count.Equals(0))
            {
                //request = false;
                MessageBox.Show("Agregue repuestos");
                return false;
            }
            //Validamos que haya agregado comentarios técnicos
            if (txtComentarys.Text.Length.Equals(0))
            {
                //request = false;
                MessageBox.Show("Agregue comentarios");
                return false;
            }
            return true;
        }

        private void IbtnUpdate_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");
            if (ValidateData())
            {
                DateTime localDate = DateTime.Now;
                Cotization cotization = new Cotization();
                cotization.Cotization_id = order.Cotization.Cotization_id;
                cotization.Cotization_generation_date = DateTime.Parse(localDate.ToString("yyyy-MM-dd HH:mm:ss"));
                //Calculamos la cantidad de servicios y repuestos
                byte quantity = 0;
                quantity = Convert.ToByte(dts.Rows.Count + dtr.Rows.Count);
                cotization.Cotization_quantity = quantity;
                //Capturamos los comentarios técnicos
                cotization.Cotization_comentarys = txtComentarys.Text;
                //Calculamos el subtotal
                Decimal Dsubtotal = 0m;
                //Obtenemos la suma de los servicios
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    Service service = serviceLog.Read_once(dts.Rows[i][0].ToString());
                    //Creamos cotization_service (DETALLES)
                    Cotization_serviceFK cotization_ServiceFK = new Cotization_serviceFK
                    {
                        Cotization_id = order.Cotization.Cotization_id,
                        Service_code = service.Service_code,
                        Actionof = txtArticleCode.Text,
                        Service_quantity = Convert.ToByte(dts.Rows[i][2].ToString()),
                    };
                    //Capturamos el costo en string
                    string strCost = service.Service_cost;
                    //Lo convertimos a decimal
                    decimal decCost = decimal.Parse(strCost, culture);
                    //Lo multiplicamos por la cantidad
                    decimal decAmount = decCost * cotization_ServiceFK.Service_quantity;
                    //Lo agregamos al objeto en formato string
                    cotization_ServiceFK.Service_amount = decAmount.ToString().Replace(',', '.');
                    //Lo sumamos en el subtotal
                    Dsubtotal += decAmount;
                    //Creamos el objeto cotization service
                    cotizationServiceLog.Create(cotization_ServiceFK);
                }
                //Obtenemos la suma de los repuestos
                for (int i = 0; i < dtr.Rows.Count; i++)
                {
                    Refaction refaction = refactionLog.Read_once(dtr.Rows[i][0].ToString());
                    //Creamos cotization_refaction (DETALLES)
                    Cotization_refactionFK cotization_RefactionFK = new Cotization_refactionFK
                    {
                        Cotization_id = order.Cotization.Cotization_id,
                        Refaction_code = refaction.Refaction_code,
                        Replacementof = txtArticleCode.Text,
                        Refaction_quantity = Convert.ToByte(dtr.Rows[i][2].ToString()),
                    };
                    //Capturamos el precio unitario en string
                    string strPrice = refaction.Refaction_unit_price;
                    //Lo convertimos a decimal
                    decimal decPrice = decimal.Parse(strPrice, culture);
                    //Lo multiplicamos por la cantidad
                    decimal decAmountr = decPrice * cotization_RefactionFK.Refaction_quantity;
                    //Lo agregamos al objeto en formato string
                    cotization_RefactionFK.Refaction_amount = decAmountr.ToString().Replace(',', '.');
                    //Lo sumamos en el subtotal
                    Dsubtotal += decAmountr;
                    //Creamos el objeto cotization refaction
                    cotizationRefactionLog.Create(cotization_RefactionFK);
                    //subtotal += Decimal.Parse(cotization_RefactionFK.Refaction_amount);
                }
                Console.WriteLine("Subtotal decimal: " + Dsubtotal);
                Console.WriteLine("Subtotal string: " + Dsubtotal.ToString().Replace(',', '.'));
                cotization.Cotization_subtotal = Dsubtotal.ToString().Replace(',', '.');
                //Definimos el descuento->preguntar a EVANS si maneja descuento
                cotization.Cotization_discount = "0";
                //DEfinimos el IVA del subtotal->por ahora se hará con el 19%. pero se debe tener en cuenta el IVA
                //Consultamos el iva codigo 19
                decimal im = taxLog.Read_once_value("19");
                //Calculamos el IVA
                decimal iva = Dsubtotal * im;
                //Agregamos el string del iva al objeto cotization
                cotization.Cotization_iva = iva.ToString().Replace(',', '.');
                decimal total = Dsubtotal + iva;
                cotization.Cotization_total = total.ToString().Replace(',', '.');
                //Agregamos el usuario que la actualizará
                cotization.Update_by = UserCache.UserAccount;
                //Agregamos la fecha de actualizacion
                cotization.Update_date = cotization.Cotization_generation_date;
                //Actualizamos la cotización
                cotizationLog.Update(cotization);
                //Cambiamos el estado de la orden
                orderLog.UpdateState(order.Order_number, "Cotizada");
                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void IbtnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
