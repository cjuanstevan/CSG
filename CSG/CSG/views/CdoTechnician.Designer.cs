namespace CSG.views
{
    partial class CdoTechnician
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
            this.LblCreateClient = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DgvTechnician = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTechnician)).BeginInit();
            this.SuspendLayout();
            // 
            // LblCreateClient
            // 
            this.LblCreateClient.AutoSize = true;
            this.LblCreateClient.Location = new System.Drawing.Point(19, 9);
            this.LblCreateClient.Name = "LblCreateClient";
            this.LblCreateClient.Size = new System.Drawing.Size(70, 13);
            this.LblCreateClient.TabIndex = 7;
            this.LblCreateClient.TabStop = true;
            this.LblCreateClient.Text = "Crear técnico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Busquedad de técnicos";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DgvTechnician);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(22, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 317);
            this.panel1.TabIndex = 5;
            // 
            // DgvTechnician
            // 
            this.DgvTechnician.AllowUserToAddRows = false;
            this.DgvTechnician.AllowUserToDeleteRows = false;
            this.DgvTechnician.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvTechnician.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTechnician.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvTechnician.Location = new System.Drawing.Point(15, 50);
            this.DgvTechnician.Name = "DgvTechnician";
            this.DgvTechnician.ReadOnly = true;
            this.DgvTechnician.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTechnician.Size = new System.Drawing.Size(615, 243);
            this.DgvTechnician.TabIndex = 1;
            this.DgvTechnician.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTechnician_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(268, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // CdoTechnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 374);
            this.Controls.Add(this.LblCreateClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(714, 413);
            this.Name = "CdoTechnician";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Técnicos";
            this.Load += new System.EventHandler(this.CdoTechnician_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTechnician)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LblCreateClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DgvTechnician;
        private System.Windows.Forms.TextBox txtSearch;
    }
}