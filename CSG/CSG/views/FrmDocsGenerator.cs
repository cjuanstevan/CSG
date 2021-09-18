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
using CSG.logic;

namespace CSG.views
{
    public partial class FrmDocsGenerator : Form
    {
        private readonly OrderLog orderLog = new OrderLog();
        //Tabla
        private DataTable dtdoc1 = new DataTable();
        private DataColumn column;
        private DataRow row;
        public FrmDocsGenerator()
        {
            InitializeComponent();
            //CreateDataTable();
        }

        private void BtnDoc1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderNumberDoc1.Text))
            {
                //Buscamos la orden--->Cambiar a procedure de objeto
                Order order = orderLog.Read_once_reception_type(txtOrderNumberDoc1.Text);
                Console.WriteLine("Objeto order: '" + order.Order_number + "'");
                if (!string.IsNullOrEmpty(order.Order_number))
                {
                    lblMsgDoc1.Text = "";
                    lblMsgDoc1.Visible = false;
                    DgvDocs1.Visible = true;
                    LoadRowsDataTable(order);
                }
                else
                {
                    lblMsgDoc1.Text = "0 resultados";
                    lblMsgDoc1.Visible = true;
                    DgvDocs1.Visible = false;
                    dtdoc1.Rows.Clear();
                }
            }
            else
            {
                lblMsgDoc1.Visible = true;
                lblMsgDoc1.Text = "Indique el número de la orden";
            }
            
        }

        private void LoadRowsDataTable(Order order)
        {
            dtdoc1 = new DataTable();
            DgvDocs1.Columns.Clear();
            CreateDataTable();
            Cursor.Current = Cursors.WaitCursor;
            row = dtdoc1.NewRow();
            row[0] = order.Order_number;
            row[1] = order.Order_reception_date.ToString("yyyy-MM-dd HH:mm:ss");
            row[2] = order.Order_type;
            row[3] = order.Client.Client_name;
            dtdoc1.Rows.Add(row);
            DataGridViewImageColumn imageView = new DataGridViewImageColumn
            {
                Image = Properties.Resources.report1,
                Name = "open_report",
                HeaderText = "Generar recibido"
            };
            DgvDocs1.Columns.Add(imageView);
        }

        private void CreateDataTable()
        {
            //Columna 1->NÚMERO
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ORDEN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtdoc1.Columns.Add(column);
            // Columna 2->FECHA DE RECEPCIÓN
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "FECHA RECEPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtdoc1.Columns.Add(column);
            // Columna 3->TIPO DE ORDEN
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TIPO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtdoc1.Columns.Add(column);
            // Columna 4->CLIENTE
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CLIENTE",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtdoc1.Columns.Add(column);
            DgvDocs1.DataSource = dtdoc1;
        }

        private void DgvDocs1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DgvDocs1.CurrentCell.ColumnIndex == 4)
                {
                    //Console.WriteLine("Ver reporte ome");
                    Order.Order_number_st = DgvDocs1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Console.WriteLine("Abrir para : " + Order.Order_number_st);
                    ViewReportOrderCreate();
                }
            }
        }

        private void ViewReportOrderCreate()
        {
            RptOrderCreate rpt = new RptOrderCreate();
            rpt.ShowDialog();
        }
    }
}
