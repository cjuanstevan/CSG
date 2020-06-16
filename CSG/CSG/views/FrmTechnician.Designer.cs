namespace CSG.views
{
    partial class FrmTechnician
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.IbtnCreate = new FontAwesome.Sharp.IconButton();
            this.IbtnNew = new FontAwesome.Sharp.IconButton();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DgvTechnician = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IbtnRefresh = new FontAwesome.Sharp.IconButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTechnician)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboPosition);
            this.panel1.Controls.Add(this.IbtnCreate);
            this.panel1.Controls.Add(this.IbtnNew);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtAlias);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTelephone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtContact);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 173);
            this.panel1.TabIndex = 2;
            // 
            // cboPosition
            // 
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.Items.AddRange(new object[] {
            "CARGO 1",
            "CARGO 2",
            "CARGO 3"});
            this.cboPosition.Location = new System.Drawing.Point(448, 89);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(253, 21);
            this.cboPosition.TabIndex = 28;
            // 
            // IbtnCreate
            // 
            this.IbtnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IbtnCreate.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnCreate.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IbtnCreate.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            this.IbtnCreate.IconColor = System.Drawing.Color.Black;
            this.IbtnCreate.IconSize = 16;
            this.IbtnCreate.Location = new System.Drawing.Point(153, 124);
            this.IbtnCreate.Name = "IbtnCreate";
            this.IbtnCreate.Rotation = 0D;
            this.IbtnCreate.Size = new System.Drawing.Size(192, 26);
            this.IbtnCreate.TabIndex = 27;
            this.IbtnCreate.Text = "Crear";
            this.IbtnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IbtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IbtnCreate.UseVisualStyleBackColor = true;
            this.IbtnCreate.Click += new System.EventHandler(this.IbtnCreate_Click);
            // 
            // IbtnNew
            // 
            this.IbtnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnNew.Enabled = false;
            this.IbtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IbtnNew.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnNew.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.IbtnNew.IconColor = System.Drawing.Color.Black;
            this.IbtnNew.IconSize = 16;
            this.IbtnNew.Location = new System.Drawing.Point(91, 124);
            this.IbtnNew.Name = "IbtnNew";
            this.IbtnNew.Rotation = 0D;
            this.IbtnNew.Size = new System.Drawing.Size(55, 26);
            this.IbtnNew.TabIndex = 26;
            this.IbtnNew.UseVisualStyleBackColor = true;
            this.IbtnNew.Click += new System.EventHandler(this.IbtnNew_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(223, 21);
            this.label12.TabIndex = 25;
            this.label12.Text = "FORMULARIO DE TÉCNICO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(376, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cargo";
            // 
            // txtAlias
            // 
            this.txtAlias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlias.Location = new System.Drawing.Point(448, 69);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(253, 20);
            this.txtAlias.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(376, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Empresa";
            // 
            // txtName
            // 
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.Location = new System.Drawing.Point(448, 49);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(253, 20);
            this.txtName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(376, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nombre*";
            // 
            // txtTelephone
            // 
            this.txtTelephone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelephone.Location = new System.Drawing.Point(92, 89);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(253, 20);
            this.txtTelephone.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Teléfono*";
            // 
            // txtContact
            // 
            this.txtContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContact.Location = new System.Drawing.Point(92, 69);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(253, 20);
            this.txtContact.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contacto";
            // 
            // txtId
            // 
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtId.Location = new System.Drawing.Point(92, 49);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(253, 20);
            this.txtId.TabIndex = 0;
            this.txtId.Leave += new System.EventHandler(this.TxtId_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identidad*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(196, 21);
            this.label14.TabIndex = 26;
            this.label14.Text = "LISTADO DE TÉCNICOS";
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(92, 58);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(253, 20);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // DgvTechnician
            // 
            this.DgvTechnician.AllowUserToAddRows = false;
            this.DgvTechnician.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvTechnician.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvTechnician.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvTechnician.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvTechnician.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvTechnician.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvTechnician.ColumnHeadersHeight = 40;
            this.DgvTechnician.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvTechnician.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvTechnician.Location = new System.Drawing.Point(12, 86);
            this.DgvTechnician.MultiSelect = false;
            this.DgvTechnician.Name = "DgvTechnician";
            this.DgvTechnician.ReadOnly = true;
            this.DgvTechnician.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvTechnician.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvTechnician.RowHeadersVisible = false;
            this.DgvTechnician.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvTechnician.Size = new System.Drawing.Size(956, 549);
            this.DgvTechnician.TabIndex = 0;
            this.DgvTechnician.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTechnician_CellContentClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 61);
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
            this.panel2.Controls.Add(this.DgvTechnician);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 648);
            this.panel2.TabIndex = 3;
            // 
            // IbtnRefresh
            // 
            this.IbtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IbtnRefresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnRefresh.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.IbtnRefresh.IconColor = System.Drawing.Color.Black;
            this.IbtnRefresh.IconSize = 16;
            this.IbtnRefresh.Location = new System.Drawing.Point(353, 58);
            this.IbtnRefresh.Name = "IbtnRefresh";
            this.IbtnRefresh.Rotation = 0D;
            this.IbtnRefresh.Size = new System.Drawing.Size(44, 20);
            this.IbtnRefresh.TabIndex = 29;
            this.IbtnRefresh.UseVisualStyleBackColor = true;
            this.IbtnRefresh.Click += new System.EventHandler(this.IbtnRefresh_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmTechnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 821);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTechnician";
            this.Text = "FrmTechnician";
            this.Load += new System.EventHandler(this.FrmTechnician_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTechnician)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView DgvTechnician;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton IbtnCreate;
        private FontAwesome.Sharp.IconButton IbtnNew;
        private System.Windows.Forms.ComboBox cboPosition;
        private FontAwesome.Sharp.IconButton IbtnRefresh;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}