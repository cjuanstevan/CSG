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
using System.Net.Mail;

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
        //tabla articulos
        DataTable dta = new DataTable();
        //Tabla servicios y repuestos
        DataTable dtsr = new DataTable();
        DataColumn column;
        DataRow row;
        Order order;

       
        

        public FrmCotizationViewer()
        {
            InitializeComponent();
        }

        private void FrmCotizationViewer_Load(object sender, EventArgs e)
        {
            order = orderLog.Read_once(Order.Order_number_st);
            //Si la orden es "en espera"D
            if (order.Order_state.Equals("En espera"))
            {
                //Bloqueamos botones guardar y guardar & enviar
                IbtnSave.Enabled = false;
                IbtnSaveSend.Enabled = false;
                //Visibilidad false botones anteriores
                IbtnSave.Visible = false;
                IbtnSaveSend.Visible = false;
                //Movemos los botones a la posicion deseada
                IbtnFacturar.Location = new Point(845, 21);
                IbtnCancel.Location = new Point(764, 21);
                IbtnEdit.Location = new Point(685, 21);
            }
            else if (order.Order_state.Equals("Cotizada"))
            {
                //Ocultamos los botones del if
                IbtnFacturar.Visible = false;
                IbtnCancel.Visible = false;
                IbtnEdit.Visible = false;
            }
            else if(order.Order_state.Equals("Cancelada") || order.Order_state.Equals("Facturada"))
            {
                panel2.Visible = false;
            }      
            txtCotizationId.Text = order.Cotization.Cotization_id;
            txtOrderType.Text = order.Order_type;
            txtOrderNumber.Text = order.Order_number;
            txtOrderState.Text = order.Order_state;
            //Console.WriteLine("Cot_")
            dtpGeneration.Value = order.Cotization.Cotization_generation_date;
            //Agregamos el cliente
            txtClientId.Text = order.Client.Client_id;
            txtClientName.Text = order.Client.Client_name;
            //txtClientL1.Text = order.Client.Client_lastname1;
            //txtClientL2.Text = order.Client.Client_lastname2;
            txtClientAddress.Text = order.Client.Client_address;
            txtClientLocation.Text = order.Client.Client_location;
            txtClientCity.Text = order.Client.Client_city;
            txtClientDpt.Text = order.Client.Client_department;
            txtClientTel1.Text = order.Client.Client_tel1;
            txtClientTel2.Text = order.Client.Client_tel2;
            txtClientEmail.Text = order.Client.Client_email;
            //Agregamos el equipo
            //Article article = articleLog.Read_once(orderArticleLog.Read_code_article_of_order(Order.Order_number_st));
            //txtArticleCode.Text = article.Article_code;
            //txtArticleDescription.Text = article.Article_description;
            CreateDataTables();
            //Agregamos los articulos
            AddArticles();

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
            txtComentarys.Text = cotization.Cotization_comentarys;
            //Cargamos subtotal, descuento, iva y total
            lblSubtotal.Text = cotization.Cotization_subtotal;
            lblDiscount.Text = cotization.Cotization_discount;
            lblIva.Text = cotization.Cotization_iva;
            lblTotal.Text = cotization.Cotization_total;
        }

        private void AddArticles()
        {
            List<Order_articleFK> order_ArticleFKs = orderArticleLog.Read_ArticlesOfOrder(Order.Order_number_st);
            foreach (var oa in order_ArticleFKs)
            {
                Article article = articleLog.Read_once(oa.Article_code);
                //Console.WriteLine("Articulos de orden: " + oa.Article_code);
                row = dta.NewRow();
                row[0] = oa.Article_code;
                row[1] = article.Article_description;
                row[2] = oa.Model;
                row[3] = oa.Especification;
                row[4] = oa.Serial;
                dta.Rows.Add(row);
            }
        }

        private void AddServices()
        {
            List<Cotization_serviceFK> cotization_ServiceFKs = cotizationServiceLog.Read_ServicesOfCotization(txtCotizationId.Text);
            foreach (var cs in cotization_ServiceFKs)
            {
                Service service = serviceLog.Read_once(cs.Service_code);
                //Console.WriteLine("Code: {0} | Actividad: {1}",service.Service_code,service.Service_activity);
                row = dtsr.NewRow();
                row[0] = "Servicio";
                row[1] = service.Service_code;
                row[2] = service.Service_activity;
                row[3] = Int32.Parse("1");
                row[4] = service.Service_cost;
                row[5] = service.Service_cost;
                dtsr.Rows.Add(row);
            }
        }
        private void AddRefactions()
        {
            List<Cotization_refactionFK> cotization_RefactionFKs = cotizationRefactionLog.Read_RefactionsOfCotization(txtCotizationId.Text);
            foreach (var cr in cotization_RefactionFKs)
            {
                Refaction refaction = refactionLog.Read_once(cr.Refaction_code);
                //Console.WriteLine("Code: {0} | Descripción: {1}", refaction.Refaction_code, refaction.Refaction_description);
                row = dtsr.NewRow();
                row[0] = "Refacción";
                row[1] = refaction.Refaction_code;
                row[2] = refaction.Refaction_description;
                row[3] = cr.Refaction_quantity;
                row[4] = refaction.Refaction_unit_price;
                row[5] = cr.Refaction_amount;
                dtsr.Rows.Add(row);
            }
        }

        private void CreateDataTables()
        {
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CODIGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dta.Columns.Add(column);
            // Creamos la segunda columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESCRIPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            // Creamos la tercera columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "MODELO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            // Creamos la cuarta columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ESPECIFICACIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            // Creamos la quinta columna y la agregamos al DataTable.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "SERIAL",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dta.Columns.Add(column);
            DgvArticles.DataSource = dta;





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
                Unique = false
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
        private void UpdateOrderState()
        {
            orderLog.UpdateState(txtOrderNumber.Text, "En espera");
        }
        private void UpdateCotization()
        {
            cotizationLog.UpdateExpirationDate(txtCotizationId.Text, 
                DateTime.Parse(dtpExpiration.Value.ToString("yyyy-MM-dd HH:mm:ss")));
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //DateValidate();
        }
        private bool DateValidate()
        {
            //Console.WriteLine("Dia del año local: " + DateTime.Now.DayOfYear);
            //Console.WriteLine("Dia del año expiration: " + dtpExpiration.Value.DayOfYear);
            if (dtpExpiration.Value.DayOfYear >= DateTime.Now.DayOfYear)
            {
                //MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Debe ingresar una fecha válida o mayor a la presente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        private void SendMail()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("cprueba369@gmail.com");
            //message.To.Add("cjuanstevan@gmail.com");
            message.To.Add(txtClientEmail.Text);
            message.Subject = "Cotización orden " + txtOrderNumber.Text;
            message.SubjectEncoding = Encoding.UTF8;
            message.Bcc.Add("juan-0192@hotmail.com");
            string html = "<html>" +
            "<head></head>" +
            "<body style='color: #000;'>" +
            "<center><h1>COTIZACIÓN</h1></center>" +
            "<table style='width:100%;border: solid black 1px;'>" +
            "<colgroup>" +
            "<col style ='width:50%'/>" +
            "<col style ='width:50%'/>" +
            "</colgroup>" +
            "<tr>" +
            "<td><img src='https://www.evans.com.co/wp-content/uploads/2019/01/evans.png' title='logo_top'/><h2>Valsi de Colombia S.A</td></td>" +
            "<td>" +
            "<table style='width:auto;margin-right: 0px;margin-left: auto;'>" +
            "<tr>" +
            "<td>FECHA</td>" +
            "<td>" + order.Order_reception_date.ToString("yyyy-MM-dd") + "</td>" +
            "</tr>" +
            "<tr>" +
            "<td>COTIZACIÓN</td>" +
            "<td>" + txtCotizationId.Text + "</td>" +
            "</tr>" +
            "<tr>" +
            "<td>ID CLIENTE</td>" +
            "<td>" + txtClientId.Text + "</td>" +
            "</tr>" +
            "<tr>" +
            "<td>VÁLIDO HASTA</td>" +
            "<td>2020-12-31</td>" +
            "</tr>" +
            "</table>" +
            "</td></tr>" +
            "<tr>"+
            "<td colspan='2'"+
            "</table><br>" +
            "<label>Cra. 27 No. 18 - 50</label><br>" +
            "<label>Sucursal principal: Bogotá - Cundinamarca</label><br>" +
            "<label>Teléfono: (57 1) 752 0573 -752 0538</label><br>" +
            "<label>Fax: (0571) + 7520573 Ext.103.</label><br>" +
            "<label>Sitio web: https://www.evans.com.co</label><br><br>" +
            "<h3><b>CLIENTE</b></h3>" +
            "<label>" + order.Client.Client_name + "</label><br>" +
            "<label>[nombre de la empresa]<br>" +
            "<label>" + order.Client.Client_address + "<br>" +
            "<label>" + order.Client.Client_city + "</label><br>" +
            "<label>" + order.Client.Client_tel1 + " - " + order.Client.Client_tel2 + "<br><br>" +
            "<h3><b>DETALLE</b></h3><br>" +
            "<table style='border-collapse: collapse;'>" +
            "<colgroup>" +
            "<col style ='width:10%'/>" +
            "<col style ='width:60%'/>" +
            "<col style ='width:10%'/>" +
            "<col style ='width:10%'/>" +
            "<col style ='width:10%'/>" +
            "</colgroup>" +
            "<tr><td><b>TIPO</b></td><td><b>DESCRIPCIÓN</b></td><td><b>CANTIDAD</b></td><td><b>P. UNITARIO</b></td><td><b>IMPORTE</b></td></tr>";
            for (int i = 0; i < DgvSr.Rows.Count; i++)
            {
                html += "<tr style='border: solid;border-width: 1px 0;'>" +
                    "<td>" + DgvSr.Rows[i].Cells[0].Value.ToString() +
                    "</td><td>" + DgvSr.Rows[i].Cells[2].Value.ToString() +
                    "</td><td>" + DgvSr.Rows[i].Cells[3].Value.ToString() +
                    "</td><td>" + DgvSr.Rows[i].Cells[4].Value.ToString() +
                    "</td><td>" + DgvSr.Rows[i].Cells[5].Value.ToString() + "</td></tr>";
            }
            html += "<tr><td></td><td></td><td></td><td></td><td></td></tr>" +
            "<tr><td colspan='3' rowspan='4'>" + txtComentarys.Text + "</td><td>SUBTOTAL</td><td>" + lblSubtotal.Text + "</td></tr>" +
            "<tr><td>DESCUENTO</td><td>" + lblDiscount.Text + "</td></tr>" +
            "<tr><td>IVA</td><td>" + lblIva.Text + "</td></tr>" +
            "<tr><td>TOTAL</td><td>" + lblTotal.Text + "</td></tr></table><br><br>" +
            "</td>" +
            "</tr></table><br>";
            html += "<table style='width:auto;margin-right: auto;margin-left: 0px;'>" +
            "<tr>" +
            "<td rowspan='4'><img src='https://www.evans.com.co/wp-content/uploads/2019/01/evans.png' title='logo'/></td>" +
            "<td>Control de Servicio y Garantías</td>" +
            "</tr>" +
            "<tr>" +
            "<td>IT</td>" +
            "</tr>" +
            "<tr>" +
            "<td>Evans ®</td>" +
            "</tr>" +
            "<tr>" +
            "<td>(0571) + 7520573 Ext.103.</td>" +
            "</tr>" +
            "</table>"+
            "</body>" +
            "</html>";
            message.Body = html;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Credentials= new System.Net.NetworkCredential("cprueba369@gmail.com", "administrador");
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            try
            {
                client.Send(message);
                MessageBox.Show("Mensaje enviado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepcioón en SendMail(): " + ex.Message);
            }
        }

        private void IbtnSaveSend_Click(object sender, EventArgs e)
        {
            //Validamos que ingrese una fecha de expiración de la cotizacion
            //mayor o igual a presente
            if (DateValidate())
            {
                //Actualizamos la fecha de expiracion de la cotizacion
                UpdateCotization();
                //Enviamos el correo
                SendMail();
                //Estado cambia a Esperando respuesta
                UpdateOrderState();
                //Cambio el estado de los botones
            }
        }

        private void IbtnCancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Abre msgCancel");
            MsgOrderCancel cancel = new MsgOrderCancel();
            cancel.ShowDialog();
            if (cancel.DialogResult.Equals(DialogResult.Yes))
            {
                Console.WriteLine("Cancela la order");
                //Se cancela la orden
                orderLog.UpdateState(Order.Order_number_st, "Cancelada");
            }
        }

        private void IbtnFacturar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de facturar la orden "
                + Order.Order_number_st + " y generar el documento?", "Cuadro de diálogo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Yes))
            {
                //Cambiamos estado de orden a Facturada
                orderLog.UpdateState(Order.Order_number_st, "Facturada");
            }
        }
    }
}
