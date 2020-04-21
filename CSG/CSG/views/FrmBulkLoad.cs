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
                        Article_model = DgvVisor.Rows[i].Cells[2].Value.ToString(),
                        Article_serial = DgvVisor.Rows[i].Cells[3].Value.ToString(),
                        Article_warranty = ushort.Parse(DgvVisor.Rows[i].Cells[4].Value.ToString())
                    };
                    articles.Add(a);
                }
                //Enviamos a la logica para que haga cada uno de los insert
                txtResult.Text = bulkLoadLog.BulkLoadArticle(articles);
                
            }
            else if (entity.Equals("CLIENTES"))
            {

            }
            else if (entity.Equals("REFACCIONES"))
            {

            }
            else if (entity.Equals("SERVICIOS"))
            {

            }
            else if (entity.Equals("TECNICOS"))
            {

            }
            //agregamos a la lista elegida
        }
    }
}
