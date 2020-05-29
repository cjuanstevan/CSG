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
    public partial class MsgLogout : Form
    {
        int xFinal;
        bool rebote = false;
        public MsgLogout()
        {
            InitializeComponent();
        }
        private void MsgLogout_Load(object sender, EventArgs e)
        {
            xFinal = Screen.PrimaryScreen.WorkingArea.Height - (this.Size.Height * 2);
            this.TopMost = true;
            //this.Location = new Point
            //    (Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width,
            //    Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point
                ((Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Size.Width / 2),
                Screen.PrimaryScreen.WorkingArea.Height);
            timer1.Start();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void IconPictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.Location);
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width,
                Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height);
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (rebote.Equals(false))
            {
                if (this.Location.Y > xFinal - 10)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - 10);
                }
                else
                {
                    rebote = true;
                }
            }
            else
            {
                if (this.Location.Y <= xFinal)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        
    }
}
