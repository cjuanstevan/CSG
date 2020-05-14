using CSG.logic;
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
    public partial class CdoClient : Form
    {
        private readonly ClientLog clientLog = new ClientLog();
        public ICom com { get; set; }
        public CdoClient()
        {
            InitializeComponent();
        }

        private void CdoClient_Load(object sender, EventArgs e)
        {
            ReadClients();
        }
        
        private void ReadClients()
        {
            DgvClient.DataSource = clientLog.ReadAll();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Equals(""))
            {
                DgvClient.DataSource = clientLog.Read_all_like(txtSearch.Text);
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
    }
}
