using CSG.logic;
using CSG.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSG.views
{
    public partial class CdoClient : Form
    {
        private readonly ClientLog clientLog = new ClientLog();
        public ICom com { get; set; }

        private DataTable dtc = new DataTable();
        private DataColumn column;
        private DataRow row;
        public CdoClient()
        {
            InitializeComponent();
        }

        private void CdoClient_Load(object sender, EventArgs e)
        {
            //ReadClients();
            CreateDataTable();
            List<Client> clients = clientLog.ReadAll();
            LoadRowsTable(clients);

        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void ReadClients()
        {
            DgvClient.DataSource = clientLog.ReadAll();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Equals(""))
            {
                //Limpiamos las rows
                dtc = new DataTable();
                CreateDataTable();
                List<Client> clients = clientLog.Read_all_like(txtSearch.Text);
                LoadRowsTable(clients);
               //DgvClient.DataSource = clientLog.Read_all_like(txtSearch.Text);
            }

        }

        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                com.ClientText(DgvClient.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.Close();
            }
        }

        private void LblCreateClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CdoClientCreate create = new CdoClientCreate();
            create.ShowDialog();
        }

        private void LoadRowsTable(List<Client> clients)
        {
            foreach (var c in clients)
            {
                //Console.WriteLine("lista(tipo): " + c.Client_type);
                if (c.Client_type.Equals('j'))
                {
                    row = dtc.NewRow();
                    row[0] = c.Client_id;
                    row[1] = c.Client_name;
                    row[2] = c.Client_city;
                    row[3] = c.Client_department;
                    row[4] = c.Client_address;
                    row[5] = c.Client_tel1;
                    row[6] = c.Client_email;
                    //row["ACCIONES"] = "";
                    dtc.Rows.Add(row);
                }
                else if (c.Client_type.Equals('n'))
                {
                    row = dtc.NewRow();
                    row[0] = c.Client_id;
                    row[1] = c.Client_name + " " + c.Client_lastname1 + " " + c.Client_lastname2;
                    row[2] = c.Client_city;
                    row[3] = c.Client_department;
                    row[4] = c.Client_address;
                    row[5] = c.Client_tel1;
                    row[6] = c.Client_email;
                    //row["ACCIONES"] = "";
                    dtc.Rows.Add(row);
                }
            }
            //Imagen en columna

            //Boton en columna
            //DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            //{
            //    DataPropertyName = "ACCIONES",
            //    Text = "",
            //    HeaderText = "ACCIONES",
            //    FlatStyle = FlatStyle.Standard
            //};
            //DgvClient.Columns.AddRange(buttonColumn);
        }

        private void CreateDataTable()
        {
            //Columna 1->ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ID/NIT",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtc.Columns.Add(column);
            // Columna 2->Cliente
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CLIENTE",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 3->CIUDAD O MUNICIPIO
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CIUDAD/MUNICIPIO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 4->departamento
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DEPARTAMENTO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 5->Dirección
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DIRECCIÓN",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 6->Teléfono
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TELÉFONO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtc.Columns.Add(column);
            // Columna 7->CORREO
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CORREO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtc.Columns.Add(column);
            DgvClient.DataSource = dtc;
            //DgvClient.Columns.RemoveAt(7);
        }

        private void CdoClient_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("Key: " + e.KeyCode);
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        
    }
}
