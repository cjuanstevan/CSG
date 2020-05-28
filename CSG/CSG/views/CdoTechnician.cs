using CSG.cache;
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
    public partial class CdoTechnician : Form
    {
        private readonly TechnicianLog technicianLog = new TechnicianLog();
        public ICom com { get; set; }
        public CdoTechnician()
        {
            InitializeComponent();
        }

        private void CdoTechnician_Load(object sender, EventArgs e)
        {
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

        private void ReadTechnicians()
        {
            DgvTechnician.DataSource = technicianLog.ReadAll();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Equals(""))
            {
                DgvTechnician.DataSource = technicianLog.Read_all_like(txtSearch.Text);
            }
        }

        private void DgvTechnician_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            com.TechnicianText(DgvTechnician.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.Close();
        }
    }
}
