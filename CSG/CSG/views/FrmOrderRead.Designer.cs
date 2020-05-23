namespace CSG.views
{
    partial class FrmOrderRead
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChbAll = new System.Windows.Forms.CheckBox();
            this.RbtTechnician = new System.Windows.Forms.RadioButton();
            this.RbtClient = new System.Windows.Forms.RadioButton();
            this.RbtOrderNumber = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFin = new System.Windows.Forms.DateTimePicker();
            this.DtpIni = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvOrders = new System.Windows.Forms.DataGridView();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ChbAll);
            this.groupBox1.Controls.Add(this.RbtTechnician);
            this.groupBox1.Controls.Add(this.RbtClient);
            this.groupBox1.Controls.Add(this.RbtOrderNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DtpFin);
            this.groupBox1.Controls.Add(this.DtpIni);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DgvOrders);
            this.groupBox1.Controls.Add(this.BtnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 797);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar orden";
            // 
            // ChbAll
            // 
            this.ChbAll.AutoSize = true;
            this.ChbAll.Location = new System.Drawing.Point(106, 15);
            this.ChbAll.Name = "ChbAll";
            this.ChbAll.Size = new System.Drawing.Size(56, 17);
            this.ChbAll.TabIndex = 15;
            this.ChbAll.Text = "Todas";
            this.ChbAll.UseVisualStyleBackColor = true;
            this.ChbAll.CheckedChanged += new System.EventHandler(this.ChbAll_CheckedChanged);
            // 
            // RbtTechnician
            // 
            this.RbtTechnician.AutoSize = true;
            this.RbtTechnician.Location = new System.Drawing.Point(287, 38);
            this.RbtTechnician.Name = "RbtTechnician";
            this.RbtTechnician.Size = new System.Drawing.Size(64, 17);
            this.RbtTechnician.TabIndex = 12;
            this.RbtTechnician.TabStop = true;
            this.RbtTechnician.Text = "Técnico";
            this.RbtTechnician.UseVisualStyleBackColor = true;
            this.RbtTechnician.CheckedChanged += new System.EventHandler(this.RbtTechnician_CheckedChanged);
            // 
            // RbtClient
            // 
            this.RbtClient.AutoSize = true;
            this.RbtClient.Location = new System.Drawing.Point(224, 38);
            this.RbtClient.Name = "RbtClient";
            this.RbtClient.Size = new System.Drawing.Size(57, 17);
            this.RbtClient.TabIndex = 11;
            this.RbtClient.TabStop = true;
            this.RbtClient.Text = "Cliente";
            this.RbtClient.UseVisualStyleBackColor = true;
            this.RbtClient.CheckedChanged += new System.EventHandler(this.RbtClient_CheckedChanged);
            // 
            // RbtOrderNumber
            // 
            this.RbtOrderNumber.AutoSize = true;
            this.RbtOrderNumber.Location = new System.Drawing.Point(106, 38);
            this.RbtOrderNumber.Name = "RbtOrderNumber";
            this.RbtOrderNumber.Size = new System.Drawing.Size(107, 17);
            this.RbtOrderNumber.TabIndex = 10;
            this.RbtOrderNumber.TabStop = true;
            this.RbtOrderNumber.Text = "Número de orden";
            this.RbtOrderNumber.UseVisualStyleBackColor = true;
            this.RbtOrderNumber.CheckedChanged += new System.EventHandler(this.RbtOrderNumber_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Buscar por";
            // 
            // DtpFin
            // 
            this.DtpFin.Enabled = false;
            this.DtpFin.Location = new System.Drawing.Point(106, 88);
            this.DtpFin.Name = "DtpFin";
            this.DtpFin.Size = new System.Drawing.Size(200, 20);
            this.DtpFin.TabIndex = 8;
            // 
            // DtpIni
            // 
            this.DtpIni.Enabled = false;
            this.DtpIni.Location = new System.Drawing.Point(106, 62);
            this.DtpIni.Name = "DtpIni";
            this.DtpIni.Size = new System.Drawing.Size(200, 20);
            this.DtpIni.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Desde";
            // 
            // DgvOrders
            // 
            this.DgvOrders.AllowUserToAddRows = false;
            this.DgvOrders.AllowUserToDeleteRows = false;
            this.DgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvOrders.ColumnHeadersHeight = 40;
            this.DgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvOrders.Location = new System.Drawing.Point(30, 150);
            this.DgvOrders.MultiSelect = false;
            this.DgvOrders.Name = "DgvOrders";
            this.DgvOrders.ReadOnly = true;
            this.DgvOrders.RowHeadersVisible = false;
            this.DgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvOrders.Size = new System.Drawing.Size(903, 617);
            this.DgvOrders.TabIndex = 4;
            this.DgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrders_CellClick);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(345, 121);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 2;
            this.BtnSearch.Text = "Buscar";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(30, 123);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(309, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // FrmOrderRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 821);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmOrderRead";
            this.Text = "FrmOrderRead";
            this.Load += new System.EventHandler(this.FrmOrderRead_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView DgvOrders;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFin;
        private System.Windows.Forms.DateTimePicker DtpIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton RbtTechnician;
        private System.Windows.Forms.RadioButton RbtClient;
        private System.Windows.Forms.RadioButton RbtOrderNumber;
        private System.Windows.Forms.CheckBox ChbAll;
    }
}