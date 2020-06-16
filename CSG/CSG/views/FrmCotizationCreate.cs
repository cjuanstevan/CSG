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
            //Article article = articleLog.Read_once(code);
            //txtArticleCode.Text = article.Article_code;
            //txtArticleDescription.Text = article.Article_description;
            //Agregamos el campo report client
            txtReportClient.Text = order.Order_report_client;
            AutoCompleteService();
            AutoCompleteRefaction();
            CreateDataTables();
            //Console.WriteLine("IVA: " + taxLog.Read_once_value("19"));
            //Cargamos los articulos asociados a la orden
            LoadArticlesOfOrder();
        }
        private void LoadArticlesOfOrder()
        {
            List<Order_articleFK> order_Articles = orderArticleLog.Read_ArticlesOfOrder(Order.Order_number_st);
            foreach (var oa in order_Articles)
            {
                Article article = articleLog.Read_once(oa.Article_code);
                Console.WriteLine("Orden: " + oa.Order_number + " | Articulo: " + oa.Article_code);
                row = dtoa.NewRow();
                row[0] = article.Article_code;
                row[1] = article.Article_description;
                row[2] = oa.Model;
                row[3] = oa.Especification;
                row[4] = oa.Serial;
                dtoa.Rows.Add(row);
                //Agregamos al combo1
                cboArticles1.Items.Add(article.Article_code);
                //Agregamos al combo2
                cboArticles2.Items.Add(article.Article_code);
            }
           
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
                if (SearchDtCode(dts, words[0] + cboArticles1.SelectedItem.ToString()))
                {
                    row = dts.NewRow();
                    row[0] = service.Service_code;
                    row[1] = service.Service_activity;
                    row[2] = cboArticles1.SelectedItem.ToString();
                    row[3] = Convert.ToInt32(nupQuantity.Value);
                    row[4] = service.Service_type;
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
        private void BtnAddService_Click(object sender, EventArgs e)
        {            
            string text = txtServiceCode.Text;
            string[] words = text.Split(' ');
            //Console.WriteLine(words[0]);
            if (serviceLog.Read_once_exist(words[0]))
            {
                Service service = serviceLog.Read_once(words[0]);
                //Validar que no exista codigo en la tabla
                if (SearchDtCode(dts, words[0]))
                {
                    row = dts.NewRow();
                    row[0] = service.Service_code;
                    row[1] = service.Service_activity;
                    row[2] = service.Service_duration;
                    row[3] = service.Service_cost;
                    row[4] = service.Service_type;
                    dts.Rows.Add(row);
                }
                else
                {
                    MessageBox.Show("El servicio ya se agregó");
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
                if (SearchDtCode(dtr, words[0] + cboArticles2.SelectedItem.ToString()))
                {
                    row = dtr.NewRow();
                    row[0] = refaction.Refaction_code;
                    row[1] = refaction.Refaction_description;
                    row[2] = cboArticles2.SelectedItem.ToString();
                    row[3] = Convert.ToInt32(NupQR.Value);
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
        private void BtnAddRefaction_Click(object sender, EventArgs e)
        {
            string text = txtRefactionCode.Text;
            string[] words = text.Split(' ');
            if (refactionLog.Read_once_exist(words[0]))
            {
                Refaction refaction = refactionLog.Read_once(words[0]);
                //Validar que no exista codigo en la tabla
                if (SearchDtCode(dtr, words[0]))
                {
                    row = dtr.NewRow();
                    row[0] = refaction.Refaction_code;
                    row[1] = refaction.Refaction_description;
                    row[2] = refaction.Refaction_unit_price.ToString("C2");
                    dtr.Rows.Add(row);
                }
                else
                {
                    MessageBox.Show("El repuesto ya se agregó");
                }
                
            }
            txtRefactionCode.Clear();
            txtRefactionCode.Focus();
        }


        private void CreateDataTables()
        {
            /*******************ORDER ARTICLES*************************/
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
            // Creamos la tercera columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "SERVICIO DE",
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
            //dataSet = new DataSet();
            //dataSet.Tables.Add(dts);
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
            // Creamos la tercera columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "REPUESTO DE",
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
            //column = new DataColumn
            //{
            //    DataType = System.Type.GetType("System.String"),
            //    ColumnName = "DESCRIPCIÓN",
            //    AutoIncrement = false,
            //    ReadOnly = true,
            //    Unique = false
            //};
            //dtr.Columns.Add(column);
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
                if ((dt.Rows[i][0].ToString() + dt.Rows[i][2].ToString()).ToString().Equals(text))
                {
                    request = false;
                    break;
                }
            }
            return request;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DateTime localDate = DateTime.Now;
                //Console.WriteLine(localDate);
                //Console.WriteLine(localDate.ToString("yyyy-MM-dd HH:mm:ss"));
                Cotization cotization = new Cotization();
                cotization.Cotization_id = order.Cotization.Cotization_id;
                cotization.Cotization_generation_date = DateTime.Parse(localDate.ToString("yyyy-MM-dd HH:mm:ss"));
                //cotization.Cotization_expiration_date = null;
                //Calculamos la cantidad de servicios y repuestos
                byte quantity = 0;
                quantity = Convert.ToByte(dts.Rows.Count + dtr.Rows.Count);
                cotization.Cotization_quantity = quantity;
                //Capturamos los comentarios técnicos
                cotization.Cotization_comentarys = txtComentarys.Text;
                //Calculamos el subtotal
                Decimal subtotal = 0.00m;
                //Obtenemos la suma de los servicios
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    Service service = serviceLog.Read_once(dts.Rows[i][0].ToString());
                    //Console.WriteLine("Costo: " + service.Service_cost);
                    
                    //Creamos cotization_service (DETALLES)
                    Cotization_serviceFK cotization_ServiceFK = new Cotization_serviceFK
                    {
                        Cotization_id = order.Cotization.Cotization_id,
                        Service_code = service.Service_code,
                        Actionof = dts.Rows[i][2].ToString(),
                        Service_quantity = Convert.ToByte(dts.Rows[i][3].ToString()),
                        Service_amount = 0.00m//service.Service_cost * Convert.ToByte(dts.Rows[i][3])
                    };
                    cotizationServiceLog.Create(cotization_ServiceFK);
                    subtotal += cotization_ServiceFK.Service_amount;
                }
                //Obtenemos la suma de los repuestos
                for (int i = 0; i < dtr.Rows.Count; i++)
                {
                    Refaction refaction = refactionLog.Read_once(dtr.Rows[i][0].ToString());
                    //Console.WriteLine("Costo: " + refaction.Refaction_unit_price);
                    
                    //Creamos cotization_refaction (DETALLES)
                    Cotization_refactionFK cotization_RefactionFK = new Cotization_refactionFK
                    {
                        Cotization_id = order.Cotization.Cotization_id,
                        Refaction_code = refaction.Refaction_code,
                        Replacementof = dtr.Rows[i][2].ToString(),
                        Refaction_quantity = Convert.ToByte(dtr.Rows[i][3].ToString()),
                        Refaction_amount = Convert.ToDecimal(refaction.Refaction_unit_price * Convert.ToByte(dtr.Rows[i][3].ToString()))
                    };
                    cotizationRefactionLog.Create(cotization_RefactionFK);
                    subtotal += cotization_RefactionFK.Refaction_amount;
                }
                cotization.Cotization_subtotal = subtotal;
                Console.WriteLine("Subtotal: " + subtotal);
                //Definimos el descuento->preguntar a EVANS si maneja descuento
                cotization.Cotization_discount = 0;
                //DEfinimos el IVA->por ahora se hará con el 19%. pero se debe tener en cuenta el IVA
                //de cada servicio y respuesto.
                decimal im = taxLog.Read_once_value("19");
                //Calculamos el IVA
                decimal iva = subtotal * im;
                cotization.Cotization_iva = iva;
                Console.WriteLine("IVA: " + iva);
                decimal total = subtotal + iva;
                cotization.Cotization_total = total;
                Console.WriteLine("Total: " + total);
                //Agregamos el usuario que la actualizará
                cotization.Update_by = UserCache.UserAccount;
                //Agregamos la fecha de actualizacion
                cotization.Update_date = cotization.Cotization_generation_date;
                //Actualizamos la cotización
                cotizationLog.Update(cotization);
                //Cambiamos el estado de la orden
                orderLog.UpdateState(order.Order_number, "Cotizada");
            }
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

        
    }
}
