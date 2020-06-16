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
            //cboWarranty.SelectedIndex = 1;
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
                txtClientName.Text = client.Client_name;
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
                cboCategories.SelectedIndex = (article.Category - 1);
                lblMsgArticle.Text = "";
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
            //Construimos el numero de orden con el prefijo y el consecutivo
            txtNumber.Text = PrOrder[cboType.SelectedIndex] + "-" + orderLog.Read_count().ToString();
            //Validamos el tipo de orden para habilitar o inhablitar algunos controles
            //Console.WriteLine("Mod: " + cboType.SelectedIndex % 2);
            if (cboType.SelectedIndex % 2 == 0)
            {
                txtInvoice.Clear();
                txtInvoice.Enabled = false;
                dtpSaleDate.Enabled = false;
            }
            else if (cboType.SelectedIndex % 2 == 1)
            {
                txtInvoice.Enabled = true;
                dtpSaleDate.Enabled = true;
            }
        }

        private void CboWarranty_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////SI
            //if (cboWarranty.SelectedIndex.Equals(0))
            //{
            //    txtInvoice.Enabled = true;
            //    dtpSaleDate.Enabled = true;
            //}
            ////NO
            //else if (cboWarranty.SelectedIndex.Equals(1))
            //{
            //    txtInvoice.Enabled = false;
            //    dtpSaleDate.Enabled = false;
            //}
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
            txtNumber.Clear();
            Order.Order_number_st = "";
            cboType.SelectedIndex = 0;
            CboType_SelectedIndexChanged(sender, e);
            txtClientId.Clear();
            txtArticleCod.Clear();
            //reseteamos la tabla
            EmptyDatatable();
            txtInvoice.Clear();
            txtReportClient.Clear();
            txtTechnicianId.Clear();
            txtClientId.Focus();
        }

       private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtClientName.Text))
            {
                txtClientId.Focus();
                MessageBox.Show("Ingrese un ID/NIT existente del cliente", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (DgvOa.Rows.Count == 0)
            {
                txtArticleCod.Focus();
                MessageBox.Show("Busque y agregue el equipo a la tabla", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //Siginifica que es una garantía
            if (cboType.SelectedIndex % 2 == 1)
            {
                //Si esta vacio el numero de factura de venta
                if (string.IsNullOrEmpty(txtInvoice.Text))
                {
                    txtInvoice.Focus();
                    MessageBox.Show("Ingrese número de folio o factura", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Si esta vacio el numero de factura de venta
                if (string.IsNullOrEmpty(txtInvoice.Text))
                {
                    txtInvoice.Focus();
                    MessageBox.Show("Ingrese número de folio o factura", "Aviso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Si la fecha de venta es inválida(es mayor al dia presente)
                if (dtpSaleDate.Value.DayOfYear > DateTime.Now.DayOfYear)
                {
                    dtpSaleDate.Focus();
                    MessageBox.Show("La fecha de venta no es válida", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if(string.IsNullOrEmpty(txtReportClient.Text))
            {
                txtReportClient.Focus();
                MessageBox.Show("Digite el reporte del cliente", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(string.IsNullOrEmpty(txtTechnicianName.Text))
            {
                txtTechnicianId.Focus();
                MessageBox.Show("Ingrese un ID existente del técnico a asignar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //Evento del botón "Crear"
        private void IbtnCreate_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Order order = new Order();
                order.Order_number = txtNumber.Text;
                order.Order_reception_date = DateTime.Parse(dtpDateReception.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                order.Order_type = cboType.Text;
                order.Order_invoice = txtInvoice.Text;
                if (txtInvoice.Enabled)
                {
                    order.Order_sale_date = dtpSaleDate.Value;
                }
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
                order.Create_by = UserCache.UserAccount;//Enviar desde el DAO
                //Capturamos el momento de la creacion
                order.Create_date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));//Desde el DAO mejor
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
                
                //Enviamos al caché la variable numero de orden
                Order.Order_number_st = order.Order_number;
                ViewReportOrderCreate();
                ResetControls(sender, e);

            }
        }

        private void ViewReportOrderCreate()
        {
            RptOrderCreate rpt = new RptOrderCreate();
            rpt.ShowDialog();
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
            // Columna 5->Serial
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "SERIAL",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtoa.Columns.Add(column);
            // Columna 6->Quitar.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = " ",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false,
                Namespace = "ACCIONES"
            };
            dtoa.Columns.Add(column);
            DgvOa.DataSource = dtoa;
            DgvOa.Columns.RemoveAt(5);
        }

        private void IbtnAddArticle_Click(object sender, EventArgs e)
        {
            if (!txtArticleCod.Text.Equals(""))
            {
                if (!txtArticleDesc.Text.Equals(""))
                {
                    //Validamos que no exista en el DataTable
                    if (SearchCodeDatatable(dtoa,txtArticleCod.Text))
                    {
                        //Consultamos el articulo
                        Article article = articleLog.Read_once(txtArticleCod.Text);
                        row = dtoa.NewRow();
                        row[0] = article.Article_code;
                        row[1] = article.Article_description;
                        row[2] = txtArticleModel.Text;
                        row[3] = txtArticleEsp.Text;
                        row[4] = txtArticleSerial.Text;
                        row[5] = "";
                        dtoa.Rows.Add(row);
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                        {
                            DataPropertyName = " ",
                            Text = "Ver",
                            HeaderText = " ",
                            FlatStyle = FlatStyle.Standard
                        };
                        //DgvOa.Columns.Add(new DataGridViewImageColumn()
                        //{
                        //    Image = Properties.Resources.quit,
                        //    Name = "someName",
                        //    HeaderText = "Some Text"
                        //});
                        DgvOa.Columns.Add(buttonColumn);
                        DgvOa.Columns.RemoveAt(5);
                        txtArticleCod.Clear();
                        txtArticleCod.Focus();
                    }
                    else
                    {
                        lblMsgArticle.Text = "El artículo ya existe" + txtArticleCod.Text;
                    }
                }
                else
                {
                    //MsgError(txtArticleCod, "El artículo no existe");
                    lblMsgArticle.Text = "El artículo no existe";
                }
                
            }
            else
            {
                //ingrese el codigo del articulo
                //MsgError(txtArticleCod, "Ingrese el código del artículo");
                lblMsgArticle.Text = "Ingrese el código del artículo";
            }
            
        }
        
        private void DgvOa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("e.RowIndex=" + e.RowIndex);
            if (e.RowIndex >= 0)
            {
                //Console.WriteLine(DgvOrders.CurrentCell.GetType());
                if (DgvOa.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewButtonCell")
                {
                    //Console.WriteLine("DataGrid  | Quitamos a : " + DgvOa.Rows[e.RowIndex].Cells[0].Value.ToString());
                    //Console.WriteLine("DataTable | Quitamos a : " + dtoa.Rows[e.RowIndex][0].ToString());
                    DeleteRowDatatable(dtoa, dtoa.Rows[e.RowIndex][0].ToString());
                }
            }
        }

        private bool SearchCodeDatatable(DataTable dt, string code)
        {
            //Recorremos el DataTable dtoa
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr[0].Equals(code))
                {
                    //break;
                    return false;
                    
                }
            }
            return true;
        }

        //Método
        //Recibe en DataTable y un parámetro que borra si lo encuentra en la columna CODIGO
        private void DeleteRowDatatable(DataTable dt, string code)
        {
            //Recorremos el DataTable dtoa
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr[0].Equals(code))
                {
                    dr.Delete();
                }
            }
            dt.AcceptChanges();
        }

        private void EmptyDatatable()
        {
            dtoa.Clear();
        }

        private void DgvOa_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Redimensionamos el tamaño de Codigo y boton.
            DgvOa.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DgvOa.Columns[0].Width = 150;
            DgvOa.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DgvOa.Columns[5].Width = 50;

            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.quit.Width;
                var h = Properties.Resources.quit.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.quit, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void TxtArticleCod_Enter(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            lblMsgArticle.Text = "";
        }

        private void TxtArticleCod_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("Key: " + e.KeyCode);
            if (e.KeyCode.Equals(Keys.Enter))
            {
                //Si txtcodearticle vacio abrimos la consulta de articulos
                if (string.IsNullOrEmpty(txtArticleCod.Text))
                {
                    Console.WriteLine("Ejecutamos ver todo");
                    IbtnArticle_Click(null, e);
                }//Si diferente de vacio
                else
                {
                    Console.WriteLine("Ejecutamos add");
                    IbtnAddArticle_Click(null, e);
                }
                
                
            }
        }

        private void CboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //si combo selecciona entre compresor y hidrolavadora
            if (cboCategories.SelectedIndex >=3 && cboCategories.SelectedIndex <=4)
            {
                lblModel.Visible = true;
                txtArticleModel.Visible = true;
                lblEsp.Visible = true;
                txtArticleEsp.Visible = true;
                lblSerial.Visible = true;
                txtArticleSerial.Visible = true;
            }
            else
            {
                lblModel.Visible = false;
                txtArticleModel.Visible = false;
                lblEsp.Visible = false;
                txtArticleEsp.Visible = false;
                lblSerial.Visible = false;
                txtArticleSerial.Visible = false;
            }
        }
        
        private void TxtClientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                IbtnClient_Click(null, e);
            }
            
        }

        private void LinkEmptyDatatable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dtoa.Rows.Count == 0)
            {
                MessageBox.Show("No hay nada para borrar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Si la tabla tiene mas de un registro 
                if (dtoa.Rows.Count > 1)
                {
                    //Preguntamos antes de vaciarla
                    DialogResult result = MessageBox.Show("¿Esta seguro de quitar todos los registros?", "Aviso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    //Si YES entonces la vaciamos.
                    if (result.Equals(DialogResult.Yes))
                    {
                        EmptyDatatable();
                    }
                }
                else
                {
                    EmptyDatatable();
                }
            }
        }
    }
}
