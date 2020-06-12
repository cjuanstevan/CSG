namespace CSG.views
{
    partial class RptOrderCreate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RwOrderCreate = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // RwOrderCreate
            // 
            this.RwOrderCreate.ActiveViewIndex = -1;
            this.RwOrderCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RwOrderCreate.Cursor = System.Windows.Forms.Cursors.Default;
            this.RwOrderCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RwOrderCreate.Location = new System.Drawing.Point(0, 0);
            this.RwOrderCreate.Name = "RwOrderCreate";
            this.RwOrderCreate.Size = new System.Drawing.Size(1046, 735);
            this.RwOrderCreate.TabIndex = 0;
            // 
            // RptOrderCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 735);
            this.Controls.Add(this.RwOrderCreate);
            this.Name = "RptOrderCreate";
            this.Text = "Reporte de recepción de orden";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RptOrderCreate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RwOrderCreate;
    }
}