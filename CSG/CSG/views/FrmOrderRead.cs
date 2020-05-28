using CSG.cache;
using CSG.logic;
using CSG.model;
using System;
using System.Collections;
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
        //LOGICA
        private readonly OrderLog orderLog = new OrderLog();
        //VARIABLES
        private DataTable dto = new DataTable();
        private DataColumn column;
        private DataRow row;
        //private List<Order> data;
        
        public FrmOrderRead()
        {
            InitializeComponent();
        }

        private void FrmOrderRead_Load(object sender, EventArgs e)
        {
            AutoCompleteSearch('o');
            ChbAll.Checked = true;
            RbtOrderNumber.Checked = true;
            //RbtDates.Enabled = false;
            txtSearch.Focus();
            //Creamos el DataTable
            CreateDataTable();
            //Cargamos el DataTable
            List<Order> orders = orderLog.ReadAll();
            LoadDataTable(orders);
        }

        

        private void LoadDataTable(List<Order> orders)
        {
            //PERMISOS DE USUARIO
            //Si el usuario es Recepcionista
            if (UserCache.UserRol.Equals(Roles.REC))
            {
                foreach (var o in orders)
                {
                    //Console.WriteLine("Order: " + o.Order_number + " | State" + o.Order_state);
                    //Si el estado es recepcion
                    //if (o.Order_state.Equals("Recepción"))
                    //{
                    //    row = dto.NewRow();
                    //    row[0] = o.Order_number;
                    //    row[1] = o.Order_reception_date;
                    //    row[2] = o.Order_type;
                    //    row[3] = o.Client.Client_name + " " + o.Client.Client_lastname1 + " " + o.Client.Client_lastname2;
                    //    row[4] = o.Technician.Technician_name;
                    //    row[5] = o.Order_state;
                    //    row["ACCIONES"] = "COTIZAR";
                    //    dto.Rows.Add(row);
                    //}
                    //si el estado es revision
                    if (o.Order_state.Equals("Revisión"))
                    {
                        row = dto.NewRow();
                        row[0] = o.Order_number;
                        row[1] = o.Order_reception_date;
                        row[2] = o.Order_type;
                        row[3] = o.Client.Client_name + " " + o.Client.Client_lastname1 + " " + o.Client.Client_lastname2;
                        row[4] = o.Technician.Technician_name;
                        row[5] = o.Order_state;
                        row["ACCIONES"] = "VER";
                        dto.Rows.Add(row);
                    }
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
                foreach (var o in orders)
                {
                    //Console.WriteLine("Order: " + o.Order_number + " | State" + o.Order_state);
                    //Si el estado es recepcion
                    if (o.Order_state.Equals("Recepción"))
                    {
                        row = dto.NewRow();
                        row[0] = o.Order_number;
                        row[1] = o.Order_reception_date;
                        row[2] = o.Order_type;
                        row[3] = o.Client.Client_name + " " + o.Client.Client_lastname1 + " " + o.Client.Client_lastname2;
                        row[4] = o.Technician.Technician_name;
                        row[5] = o.Order_state;
                        row["ACCIONES"] = "COTIZAR";
                        dto.Rows.Add(row);
                    }
                    //si el estado es revision
                    else if (o.Order_state.Equals("Revisión"))
                    {
                        row = dto.NewRow();
                        row[0] = o.Order_number;
                        row[1] = o.Order_reception_date;
                        row[2] = o.Order_type;
                        row[3] = o.Client.Client_name + " " + o.Client.Client_lastname1 + " " + o.Client.Client_lastname2;
                        row[4] = o.Technician.Technician_name;
                        row[5] = o.Order_state;
                        row["ACCIONES"] = "VER";
                        dto.Rows.Add(row);
                    }
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
            //Console.WriteLine("e.RowIndex=" + e.RowIndex);
            if (e.RowIndex >= 0)
            {
                //Console.WriteLine(DgvOrders.CurrentCell.GetType());
                if (DgvOrders.CurrentCell.GetType().ToString() == "System.Windows.Forms.DataGridViewButtonCell")
                {

                    //Console.WriteLine("Botón: " + DgvOrders.CurrentCell.Value);
                    //Validamos según el valor del botón
                    if (DgvOrders.CurrentCell.Value.Equals("VER"))
                    {
                        //Console.WriteLine("Ver cotización de orden: " + DgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString());
                        //Almacenamos la variable estática número de orden en el modelo
                        Order.Order_number_st = DgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                        //Abrimos el form FrmCotizationViewer
                        FrmCotizationViewer frmCotizationViewer = new FrmCotizationViewer();
                        frmCotizationViewer.ShowDialog();
                    }
                    else if (DgvOrders.CurrentCell.Value.Equals("COTIZAR"))
                    {
                        //Console.WriteLine("Cotizar a: " + DgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString());
                        //Almacenamos la variable estática número de orden en el modelo
                        Order.Order_number_st = DgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                        //Abrimos el form FrmCotizationCreate
                        FrmCotizationCreate frmCotizationCreate = new FrmCotizationCreate();
                        frmCotizationCreate.ShowDialog();
                    }
                }
            }
            
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //Limpiamos las rows
            dto = new DataTable();
            //creamos el Datable
            CreateDataTable();

            //Consulta todas (no tiene en cuenta fechas)
            if (ChbAll.Checked)
            {
                //Consulta por número de orden
                if (RbtOrderNumber.Checked)
                {
                    //si textbox vacio se actualiza la tabla
                    if (txtSearch.Text.Equals(""))
                    {
                        //Refrescamos la tabla
                        List<Order> orders = orderLog.ReadAll();
                        LoadDataTable(orders);
                    }
                    else
                    {
                        //Realizamos la busqueda por número de orden
                        List<Order> orders = orderLog.Read_all_like_number(txtSearch.Text);
                        LoadDataTable(orders);
                    }
                }
                //Consulta por cliente
                else if (RbtClient.Checked)
                {
                    //si textbox vacio se actualiza la tabla
                    if (txtSearch.Text.Equals(""))
                    {
                        //Refrescamos la tabla
                        List<Order> orders = orderLog.ReadAll();
                        LoadDataTable(orders);
                    }
                    else
                    {
                        //Realizamos la busqueda por id de cliente
                        List<Order> orders = orderLog.Read_all_like_client(txtSearch.Text);
                        LoadDataTable(orders);
                    }
                }//Consulta por técnico
                else if (RbtTechnician.Checked)
                {
                    //si textbox vacio se actualiza la tabla
                    if (txtSearch.Text.Equals(""))
                    {
                        //Refrescamos la tabla
                        List<Order> orders = orderLog.ReadAll();
                        LoadDataTable(orders);
                    }
                    else
                    {
                        //Realizamos la busqueda por id de técnico
                        List<Order> orders = orderLog.Read_all_like_technician(txtSearch.Text);
                        LoadDataTable(orders);
                    }
                }


            }
            else if (!ChbAll.Checked)
            {
                //Capturamos las fechas y las formateamos
                DateTime DateI = DateTime.Parse(DtpIni.Value.ToString("yyyy-MM-dd 00:00:00"));
                DateTime DateF = DateTime.Parse(DtpFin.Value.ToString("yyyy-MM-dd 23:59:59"));
                //Console.WriteLine("DateI: " + DateI + " | DateF: " + DateF);

                //Si txtSearch vacio
                if (txtSearch.Text.Equals(""))
                {
                    //Consulta solamente por rango de fechas
                    List<Order> orders = orderLog.Read_all_DateReception(DateI, DateF);
                    LoadDataTable(orders);
                }
                //sino esta vacio el txt
                else
                {
                    /*Console.WriteLine("Orden?" + RbtOrderNumber.Checked);
                    Console.WriteLine("Cliente?" + RbtClient.Checked);
                    Console.WriteLine("Técnico?" + RbtTechnician.Checked);*/
                    //Si radio boton orden chequeado
                    if (RbtOrderNumber.Checked)
                    {
                        List<Order> orders = orderLog.Read_all_like_number_daterange(txtSearch.Text, DateI, DateF);
                        LoadDataTable(orders);
                    }
                    //si radio boton cliente chequeado
                    else if (RbtClient.Checked)
                    {
                        List<Order> orders = orderLog.Read_all_like_client_daterange(txtSearch.Text, DateI, DateF);
                        LoadDataTable(orders);
                    }
                    //si radio botón técnico cheaqueado
                    else if (RbtTechnician.Checked)
                    {
                        List<Order> orders = orderLog.Read_all_like_technician_daterange(txtSearch.Text, DateI, DateF);
                        LoadDataTable(orders);
                    }
                }


            }
        }

        private void ChbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbAll.Checked)
            {
                //inhabilita las fechas de inicio y fin
                DtpIni.Enabled = false;
                DtpFin.Enabled = false;
            }
            else
            {
                //habilita las fechas de inicio y fin
                DtpIni.Enabled = true;
                DtpFin.Enabled = true;
            }
        }

        private void RbtOrderNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtOrderNumber.Checked.Equals(true))
            {
                //Console.WriteLine("Número de orden checked");
                //Invocamos el método automcompletar
                AutoCompleteSearch('o');
            }
            
        }

        private void RbtClient_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtClient.Checked.Equals(true))
            {
                //Console.WriteLine("Cliente checked");
                //Invocamos el método automcompletar
                AutoCompleteSearch('c');
            }
        }

        private void RbtTechnician_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtTechnician.Checked.Equals(true))
            {
                //Console.WriteLine("Técnico checked");
                //Invocamos el método automcompletar
                AutoCompleteSearch('t');
            }
        }

        private void AutoCompleteSearch(char rbt)
        {
            if (rbt.Equals('o'))
            {
                txtSearch.AutoCompleteCustomSource = AutocompleteOrder();
            }
            else if (rbt.Equals('c'))
            {
                txtSearch.AutoCompleteCustomSource = AutocompleteClient();
            }
            else if (rbt.Equals('t'))
            {
                txtSearch.AutoCompleteCustomSource = AutocompleteTechnician();
            }
            txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private AutoCompleteStringCollection AutocompleteOrder()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            List<Order> orders = orderLog.ReadAll();
            foreach (var o in orders)
            {
                collection.Add(o.Order_number);
            }
            return collection;
        }

        private AutoCompleteStringCollection AutocompleteClient()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            List<Order> orders = orderLog.ReadAll();
            foreach (var o in orders)
            {
                collection.Add(o.Client.Client_id);
            }
            return collection;
        }

        private AutoCompleteStringCollection AutocompleteTechnician()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            List<Order> orders = orderLog.ReadAll();
            foreach (var o in orders)
            {
                collection.Add(o.Technician.Technician_id);
            }
            return collection;
        }
    }
}
