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
    public partial class FrmOrderRead : Form
    {
        DataTable dto = new DataTable();
        DataColumn column;
        DataRow row;
        List<Order> data;
        //DataGridViewButtonCell buttonCell;
        private readonly OrderLog orderLog = new OrderLog();
        public FrmOrderRead()
        {
            InitializeComponent();
        }

        private void FrmOrderRead_Load(object sender, EventArgs e)
        {
            //Creamos el DataTable
            CreateDataTable();
            //Cargamos el DataTable
            LoadDataTable();

        }

        private void LoadDataTable()
        {
            //Consultamos las ordenes
            List<Order> orders = orderLog.ReadAll();
            data = new List<Order>();
            for (int i = 0; i < orders.Count; i++)
            {
                Order order = orderLog.Read_once(orders[i].Order_number);
                data.Add(order);
                //Console.WriteLine("Order: " + data[i].Order_number + " | Cliente: " + order.Client.Client_name);
                row = dto.NewRow();
                row[0] = data[i].Order_number;
                row[1] = data[i].Order_reception_date;
                row[2] = data[i].Order_type;
                row[3] = data[i].Client.Client_name + " " + data[i].Client.Client_lastname1 + " " + data[i].Client.Client_lastname2;
                row[4] = data[i].Technician.Technician_name;
                row[5] = data[i].Order_state;
                row["ACCIONES"] = "COTIZAR";
                dto.Rows.Add(row);
            }
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                DataPropertyName = "ACCIONES",
                Text = "Ver",
                HeaderText = "ACCIONES",
                FlatStyle = FlatStyle.Standard
            };
            DgvOrders.Columns.AddRange(buttonColumn);
        }

        private void CreateDataTable()
        {
            //Columna 1->Numero de orden
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ORDEN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dto.Columns.Add(column);
            // Columna 2->Fecha de Recepción.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.DateTime"),
                ColumnName = "FECHA DE RECEPCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dto.Columns.Add(column);
            // Columna 3->Tipo de orden
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TIPO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dto.Columns.Add(column);
            // Columna 4->Cliente.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CLIENTE",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dto.Columns.Add(column);
            // Columna 5->Técnico.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TÉCNICO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dto.Columns.Add(column);
            // Columna 6->Estado de la orden.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ESTADO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dto.Columns.Add(column);
            // Columna 7->Acciones.
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ACCIONES",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false,
                Namespace = "ACCIONES"
            };
            dto.Columns.Add(column);
            DgvOrders.DataSource = dto;
            DgvOrders.Columns.RemoveAt(6);
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("e.RowIndex=" + e.RowIndex);
            if (e.RowIndex >= 0)
            {
                //Console.WriteLine(DgvOrders.CurrentCell.GetType());
                if (DgvOrders.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewButtonCell")
                {
                    Console.WriteLine("Cotizar a: " + DgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
            
        }
    }
}
