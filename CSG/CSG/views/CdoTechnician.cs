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
    public partial class CdoTechnician : Form
    {
        private readonly TechnicianLog technicianLog = new TechnicianLog();
        public ICom com { get; set; }
        //Tabla
        private DataTable dtt = new DataTable();
        private DataColumn column;
        private DataRow row;

        public CdoTechnician()
        {
            InitializeComponent();
        }

        //Evento: Carga del formulario
        private void CdoTechnician_Load(object sender, EventArgs e)
        {
            CreateDataTable();
            ReadTechnicians();
            //PERMISOS DE USUARIO
            //Si el usuario es Recepcionista
            if (UserCache.UserRol.Equals(Roles.REC))
            {
                linktechnician.Visible = false;
            }
            //Si el usuario es técnico
            if (UserCache.UserRol.Equals(Roles.TEC))
            {
                linktechnician.Visible = false;
            }
            //Si el usuario es jefe técnico
            if (UserCache.UserRol.Equals(Roles.JTE))
            {
                linktechnician.Visible = true;
            }
            //Si el usuario es administrador
            if (UserCache.UserRol.Equals(Roles.ADM))
            {
                linktechnician.Visible = true;
            }
        }
        
        //Evento: TextChanged txtSearch
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Equals(""))
            {
                //Limpiamos el DataTable
                dtt = new DataTable();
                //Creamos las columnas
                CreateDataTable();
                //Cargamos la lista
                List<Technician> technicians = technicianLog.Read_all_like(txtSearch.Text);
                LoadRowsTable(technicians);
                //DgvTechnician.DataSource = technicianLog.Read_all_like(txtSearch.Text);
            }
        }

        //Evento: Clic en celda de DgvTechnician
        private void DgvTechnician_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                com.TechnicianText(DgvTechnician.Rows[e.RowIndex].Cells[0].Value.ToString());
                this.Close();
            }
        }

        //Funciones

        //Método: Crea las columnas del DataTable
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
            dtt.Columns.Add(column);
            // Columna 2->Nombre
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "NOMBRE",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            // Columna 3->Teléfono
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TELÉFONO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            // Columna 4->Cargo
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "CARGO",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = false
            };
            dtt.Columns.Add(column);
            DgvTechnician.DataSource = dtt;
        }

        //Método: consulta técnicos y los envía como parámetro a loadRowsTable
        private void ReadTechnicians()
        {
            List<Technician> technicians = technicianLog.ReadAll();
            LoadRowsTable(technicians);
        }

        //Método: recibe una lista de técnicos y crea los rows
        private void LoadRowsTable(List<Technician> technicians)
        {
            foreach (var t in technicians)
            {
                row = dtt.NewRow();
                row[0] = t.Technician_id;
                row[1] = t.Technician_name;
                row[2] = t.Technician_contact;
                row[3] = t.Technician_position;
                dtt.Rows.Add(row);
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
