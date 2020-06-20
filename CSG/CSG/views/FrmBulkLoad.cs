using CSG.model;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSG.logic;

namespace CSG.views
{
    public partial class FrmBulkLoad : Form
    {
        private readonly BulkLoadLog bulkLoadLog = new BulkLoadLog();
        public FrmBulkLoad()
        {
            InitializeComponent();
        }


        DataTableCollection tableCollection;
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Libro de Excel|*.xlsx|Libro de Excel 97-2003|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
        }

        private void CboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            DgvVisor.DataSource = dt;
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            //Qué entidad vamos a afectar
            MessageBox.Show("Crear en: " + cboSheet.SelectedItem.ToString());
            string entity = cboSheet.SelectedItem.ToString();
            if (entity.Equals("ARTICULOS"))
            {
                //creamos la lista de Articulos
                List<Article> articles = new List<Article>();
                //recorremos el DataGridView y agregamos cada fila a la lista
                int rows = DgvVisor.RowCount;
                MessageBox.Show("Cantidad de filas: " + rows);
                for (int i = 0; i < rows; i++)
                {
                    Article a = new Article
                    {
                        Article_code = DgvVisor.Rows[i].Cells[0].Value.ToString(),
                        Article_description = DgvVisor.Rows[i].Cells[1].Value.ToString(),
                        //Article_model = DgvVisor.Rows[i].Cells[2].Value.ToString(),
                        //Article_serial = DgvVisor.Rows[i].Cells[3].Value.ToString(),
                        Article_warranty = int.Parse(DgvVisor.Rows[i].Cells[4].Value.ToString()),
                        Create_by = "Bulkload",
                        Create_date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    articles.Add(a);
                }
                //Enviamos a la logica para que haga cada uno de los insert
                txtResult.Text = bulkLoadLog.BulkLoadArticle(articles);
                
            }
            else if (entity.Equals("CLIENTES"))
            {
                //creamos la lista de Clientes
                List<Client> clients = new List<Client>();
                //recorremos el DataGridView y agregamos cada fila a la lista
                int rows = DgvVisor.RowCount;
                MessageBox.Show("Cantidad de filas: " + rows);
                for (int i = 0; i < rows; i++)
                {
                    Client c = new Client
                    {
                        Client_id = DgvVisor.Rows[i].Cells[0].Value.ToString(),
                        Client_name = DgvVisor.Rows[i].Cells[1].Value.ToString(),
                        Client_address = DgvVisor.Rows[i].Cells[2].Value.ToString(),
                        Client_location = DgvVisor.Rows[i].Cells[3].Value.ToString(),
                        Client_city = DgvVisor.Rows[i].Cells[4].Value.ToString(),
                        Client_department = DgvVisor.Rows[i].Cells[5].Value.ToString(),
                        Client_tel1 = DgvVisor.Rows[i].Cells[6].Value.ToString(),
                        Client_tel2 = DgvVisor.Rows[i].Cells[7].Value.ToString(),
                        Client_email = DgvVisor.Rows[i].Cells[8].Value.ToString(),
                    };
                    clients.Add(c);
                }
                //Enviamos a la logica para que haga cada uno de los insert
                txtResult.Text = bulkLoadLog.BulkLoadClient(clients);
            }
            else if (entity.Equals("REFACCIONES"))
            {
                //creamos la lista de Refactions
                List<Refaction> refactions = new List<Refaction>();
                //recorremos el DataGridView y agregamos cada fila a la lista
                int rows = DgvVisor.RowCount;
                MessageBox.Show("Cantidad de filas: " + rows);
                for (int i = 0; i < rows; i++)
                {
                    Refaction r = new Refaction
                    {
                        Refaction_code = DgvVisor.Rows[i].Cells[0].Value.ToString(),
                        Refaction_description = DgvVisor.Rows[i].Cells[1].Value.ToString(),
                        Refaction_unit_price = DgvVisor.Rows[i].Cells[2].Value.ToString()
                    };
                    refactions.Add(r);
                }
                //Enviamos a la logica para que haga cada uno de los insert
                txtResult.Text = bulkLoadLog.BulkLoadRefaction(refactions);
            }
            else if (entity.Equals("SERVICIOS"))
            {
                //creamos la lista de Services
                List<Service> services = new List<Service>();
                //recorremos el DataGridView y agregamos cada fila a la lista
                int rows = DgvVisor.RowCount;
                MessageBox.Show("Cantidad de filas: " + rows);
                for (int i = 0; i < rows; i++)
                {
                    Service s = new Service
                    {
                        Service_code = DgvVisor.Rows[i].Cells[0].Value.ToString(),
                        Service_activity = DgvVisor.Rows[i].Cells[1].Value.ToString(),
                        Service_duration = DgvVisor.Rows[i].Cells[2].Value.ToString(),
                        Service_cost = decimal.Round(decimal.Parse(DgvVisor.Rows[i].Cells[3].Value.ToString()), 2).ToString().Replace(',', '.'),
                        Service_type = char.Parse(DgvVisor.Rows[i].Cells[4].Value.ToString())
                    };
                    services.Add(s);
                    Console.WriteLine(
                        //"Codigo: " + "(" + s.Service_code.Length + ")" + s.Service_code +
                        //"  | Activity: " + "(" + s.Service_activity.Length + ")" + s.Service_activity +
                        //" | Duration: " + s.Service_duration + "(" + s.Service_duration.Length + ")" +
                        " | Cost: " + "(" + s.Service_cost.Length + ")" + s.Service_cost +
                        " | Type: " + "(" + s.Service_type.ToString().Length + ")" + s.Service_type);
                }
                //Enviamos a la logica para que haga cada uno de los insert
                txtResult.Text = bulkLoadLog.BulkLoadService(services);
            }
            else if (entity.Equals("TECNICOS"))
            {
                //creamos la lista de Technicians
                List<Technician> technicians = new List<Technician>();
                //recorremos el DataGridView y agregamos cada fila a la lista
                int rows = DgvVisor.RowCount;
                MessageBox.Show("Cantidad de filas: " + rows);
                for (int i = 0; i < rows; i++)
                {
                    Technician t = new Technician
                    {
                        Technician_id = DgvVisor.Rows[i].Cells[0].Value.ToString(),
                        Technician_name = DgvVisor.Rows[i].Cells[1].Value.ToString(),
                        Technician_contact = DgvVisor.Rows[i].Cells[2].Value.ToString(),
                        Technician_alias = DgvVisor.Rows[i].Cells[3].Value.ToString(),
                        Technician_telephone = DgvVisor.Rows[i].Cells[4].Value.ToString(),
                        Technician_position = DgvVisor.Rows[i].Cells[5].Value.ToString(),
                        Create_by = "Bulkload",
                        Create_date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    technicians.Add(t);
                }
                //Enviamos a la logica para que haga cada uno de los insert
                txtResult.Text = bulkLoadLog.BulkLoadTechnician(technicians);
            }
        }
    }
}
