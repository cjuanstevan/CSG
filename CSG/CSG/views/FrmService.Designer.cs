namespace CSG.views
{
    partial class FrmService
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.IBtnCreate = new FontAwesome.Sharp.IconButton();
            this.IbtnNew = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.nupDuration = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DgvService = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IbtnRefresh = new FontAwesome.Sharp.IconButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvService)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboType);
            this.panel1.Controls.Add(this.IBtnCreate);
            this.panel1.Controls.Add(this.IbtnNew);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nupDuration);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtCost);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtActivity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 203);
            this.panel1.TabIndex = 2;
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cboType.Location = new System.Drawing.Point(76, 129);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(56, 21);
            this.cboType.TabIndex = 30;
            // 
            // IBtnCreate
            // 
            this.IBtnCreate.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IBtnCreate.IconChar = FontAwesome.Sharp.IconChar.None;
            this.IBtnCreate.IconColor = System.Drawing.Color.Black;
            this.IBtnCreate.IconSize = 16;
            this.IBtnCreate.Location = new System.Drawing.Point(142, 156);
            this.IBtnCreate.Name = "IBtnCreate";
            this.IBtnCreate.Rotation = 0D;
            this.IBtnCreate.Size = new System.Drawing.Size(350, 23);
            this.IBtnCreate.TabIndex = 29;
            this.IBtnCreate.Text = "Crear";
            this.IBtnCreate.UseVisualStyleBackColor = true;
            this.IBtnCreate.Click += new System.EventHandler(this.IBtnCreate_Click);
            // 
            // IbtnNew
            // 
            this.IbtnNew.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnNew.IconChar = FontAwesome.Sharp.IconChar.None;
            this.IbtnNew.IconColor = System.Drawing.Color.Black;
            this.IbtnNew.IconSize = 16;
            this.IbtnNew.Location = new System.Drawing.Point(75, 156);
            this.IbtnNew.Name = "IbtnNew";
            this.IbtnNew.Rotation = 0D;
            this.IbtnNew.Size = new System.Drawing.Size(53, 23);
            this.IbtnNew.TabIndex = 28;
            this.IbtnNew.UseVisualStyleBackColor = true;
            this.IbtnNew.Click += new System.EventHandler(this.IbtnNew_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "minuto(s)";
            // 
            // nupDuration
            // 
            this.nupDuration.Location = new System.Drawing.Point(76, 108);
            this.nupDuration.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupDuration.Name = "nupDuration";
            this.nupDuration.Size = new System.Drawing.Size(38, 20);
            this.nupDuration.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "FORMULARIO DE SERVICIO";
            // 
            // txtCost
            // 
            this.txtCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCost.Location = new System.Drawing.Point(75, 85);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(118, 20);
            this.txtCost.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Costo";
            // 
            // txtActivity
            // 
            this.txtActivity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActivity.Location = new System.Drawing.Point(76, 65);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(416, 20);
            this.txtActivity.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Actividad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duración";
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(76, 45);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(416, 20);
            this.txtCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(181, 16);
            this.label14.TabIndex = 26;
            this.label14.Text = "LISTADO DE SERVICIOS";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(104, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(253, 20);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // DgvService
            // 
            this.DgvService.AllowUserToAddRows = false;
            this.DgvService.AllowUserToDeleteRows = false;
            this.DgvService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvService.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvService.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvService.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvService.Location = new System.Drawing.Point(12, 68);
            this.DgvService.Name = "DgvService";
            this.DgvService.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvService.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvService.Size = new System.Drawing.Size(956, 346);
            this.DgvService.TabIndex = 0;
            this.DgvService.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvService_CellContentClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Busquedad";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.IbtnRefresh);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.DgvService);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 443);
            this.panel2.TabIndex = 3;
            // 
            // IbtnRefresh
            // 
            this.IbtnRefresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnRefresh.IconChar = FontAwesome.Sharp.IconChar.None;
            this.IbtnRefresh.IconColor = System.Drawing.Color.Black;
            this.IbtnRefresh.IconSize = 16;
            this.IbtnRefresh.Location = new System.Drawing.Point(363, 40);
            this.IbtnRefresh.Name = "IbtnRefresh";
            this.IbtnRefresh.Rotation = 0D;
            this.IbtnRefresh.Size = new System.Drawing.Size(46, 23);
            this.IbtnRefresh.TabIndex = 29;
            this.IbtnRefresh.UseVisualStyleBackColor = true;
            this.IbtnRefresh.Click += new System.EventHandler(this.IbtnRefresh_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 646);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmService";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmService";
            this.Load += new System.EventHandler(this.FrmService_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvService)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtActivity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView DgvService;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nupDuration;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton IBtnCreate;
        private FontAwesome.Sharp.IconButton IbtnNew;
        private System.Windows.Forms.ComboBox cboType;
        private FontAwesome.Sharp.IconButton IbtnRefresh;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}