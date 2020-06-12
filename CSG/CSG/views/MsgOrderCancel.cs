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
    public partial class MsgOrderCancel : Form
    {
        public MsgOrderCancel()
        {
            InitializeComponent();
        }

        private void MsgOrderCancel_Load(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.No;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!txtComentarys.Text.Equals(""))
            {
                OrderLog orderLog = new OrderLog();
                orderLog.UpdateComentarys(Order.Order_number_st, txtComentarys.Text);
                DialogResult = DialogResult.Yes;
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Debe ingresar un motivo de cancelación";
            }
            
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
