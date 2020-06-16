namespace CSG.views
{
    partial class FrmRefactions
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
            this.IbtnCreate = new FontAwesome.Sharp.IconButton();
            this.IbtnNew = new FontAwesome.Sharp.IconButton();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DgvRefaction = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IbtnRefresh = new FontAwesome.Sharp.IconButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRefaction)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.IbtnCreate);
            this.panel1.Controls.Add(this.IbtnNew);
            this.panel1.Controls.Add(this.txtObs);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtDesc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtUnitPrice);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 216);
            this.panel1.TabIndex = 2;
            // 
            // IbtnCreate
            // 
            this.IbtnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnCreate.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnCreate.IconChar = FontAwesome.Sharp.IconChar.CheckDouble;
            this.IbtnCreate.IconColor = System.Drawing.Color.Black;
            this.IbtnCreate.IconSize = 20;
            this.IbtnCreate.Location = new System.Drawing.Point(235, 174);
            this.IbtnCreate.Name = "IbtnCreate";
            this.IbtnCreate.Rotation = 0D;
            this.IbtnCreate.Size = new System.Drawing.Size(253, 32);
            this.IbtnCreate.TabIndex = 29;
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
            this.IbtnNew.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnNew.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.IbtnNew.IconColor = System.Drawing.Color.Black;
            this.IbtnNew.IconSize = 20;
            this.IbtnNew.Location = new System.Drawing.Point(153, 175);
            this.IbtnNew.Name = "IbtnNew";
            this.IbtnNew.Rotation = 0D;
            this.IbtnNew.Size = new System.Drawing.Size(75, 32);
            this.IbtnNew.TabIndex = 28;
            this.IbtnNew.UseVisualStyleBackColor = true;
            this.IbtnNew.Click += new System.EventHandler(this.IbtnNew_Click);
            // 
            // txtObs
            // 
            this.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObs.Location = new System.Drawing.Point(153, 101);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(335, 63);
            this.txtObs.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Observaciones";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(228, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "FORMULARIO DE REPUESTOS";
            // 
            // txtDesc
            // 
            this.txtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc.Location = new System.Drawing.Point(153, 61);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(335, 20);
            this.txtDesc.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Descripción";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUnitPrice.Location = new System.Drawing.Point(153, 81);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(335, 20);
            this.txtUnitPrice.TabIndex = 3;
            this.txtUnitPrice.Enter += new System.EventHandler(this.TxtUnitPrice_Enter);
            this.txtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUnitPrice_KeyPress);
            this.txtUnitPrice.Leave += new System.EventHandler(this.TxtUnitPrice_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Precio Unitario";
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(153, 41);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(335, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCode_KeyPress);
            this.txtCode.Leave += new System.EventHandler(this.TxtCode_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 16);
            this.label14.TabIndex = 26;
            this.label14.Text = "LISTADO DE REPUESTOS";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(79, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(278, 20);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // DgvRefaction
            // 
            this.DgvRefaction.AllowUserToAddRows = false;
            this.DgvRefaction.AllowUserToDeleteRows = false;
            this.DgvRefaction.AllowUserToResizeRows = false;
            this.DgvRefaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvRefaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvRefaction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvRefaction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvRefaction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRefaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvRefaction.ColumnHeadersHeight = 40;
            this.DgvRefaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvRefaction.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvRefaction.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvRefaction.Location = new System.Drawing.Point(12, 66);
            this.DgvRefaction.MultiSelect = false;
            this.DgvRefaction.Name = "DgvRefaction";
            this.DgvRefaction.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRefaction.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvRefaction.RowHeadersVisible = false;
            this.DgvRefaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRefaction.Size = new System.Drawing.Size(956, 526);
            this.DgvRefaction.TabIndex = 0;
            this.DgvRefaction.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRefaction_CellContentClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 40);
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
            this.panel2.Controls.Add(this.DgvRefaction);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 605);
            this.panel2.TabIndex = 3;
            // 
            // IbtnRefresh
            // 
            this.IbtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnRefresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnRefresh.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.IbtnRefresh.IconColor = System.Drawing.Color.Black;
            this.IbtnRefresh.IconSize = 16;
            this.IbtnRefresh.Location = new System.Drawing.Point(363, 37);
            this.IbtnRefresh.Name = "IbtnRefresh";
            this.IbtnRefresh.Rotation = 0D;
            this.IbtnRefresh.Size = new System.Drawing.Size(40, 21);
            this.IbtnRefresh.TabIndex = 29;
            this.IbtnRefresh.UseVisualStyleBackColor = true;
            this.IbtnRefresh.Click += new System.EventHandler(this.IbtnRefresh_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmRefactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 821);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRefactions";
            this.Text = "FrmRefactions";
            this.Load += new System.EventHandler(this.FrmRefactions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRefaction)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView DgvRefaction;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton IbtnCreate;
        private FontAwesome.Sharp.IconButton IbtnNew;
        private FontAwesome.Sharp.IconButton IbtnRefresh;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}