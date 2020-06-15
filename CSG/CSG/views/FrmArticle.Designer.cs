namespace CSG.views
{
    partial class FrmArticle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DgvArticle = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IbtnNew = new FontAwesome.Sharp.IconButton();
            this.BtnReadAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticle)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(186, 16);
            this.label14.TabIndex = 26;
            this.label14.Text = "LISTADO DE ARTÍCULOS";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(79, 58);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(278, 20);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // DgvArticle
            // 
            this.DgvArticle.AllowUserToAddRows = false;
            this.DgvArticle.AllowUserToDeleteRows = false;
            this.DgvArticle.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvArticle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvArticle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvArticle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvArticle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DgvArticle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DgvArticle.ColumnHeadersHeight = 40;
            this.DgvArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvArticle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DgvArticle.Location = new System.Drawing.Point(12, 86);
            this.DgvArticle.MultiSelect = false;
            this.DgvArticle.Name = "DgvArticle";
            this.DgvArticle.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvArticle.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvArticle.RowHeadersVisible = false;
            this.DgvArticle.Size = new System.Drawing.Size(956, 706);
            this.DgvArticle.TabIndex = 0;
            this.DgvArticle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvArticle_CellContentClick);
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
            this.panel2.Controls.Add(this.IbtnNew);
            this.panel2.Controls.Add(this.BtnReadAll);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.DgvArticle);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 821);
            this.panel2.TabIndex = 3;
            // 
            // IbtnNew
            // 
            this.IbtnNew.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnNew.IconChar = FontAwesome.Sharp.IconChar.None;
            this.IbtnNew.IconColor = System.Drawing.Color.Black;
            this.IbtnNew.IconSize = 16;
            this.IbtnNew.Location = new System.Drawing.Point(452, 56);
            this.IbtnNew.Name = "IbtnNew";
            this.IbtnNew.Rotation = 0D;
            this.IbtnNew.Size = new System.Drawing.Size(75, 23);
            this.IbtnNew.TabIndex = 29;
            this.IbtnNew.Text = "Nuevo";
            this.IbtnNew.UseVisualStyleBackColor = true;
            this.IbtnNew.Click += new System.EventHandler(this.IbtnNew_Click);
            // 
            // BtnReadAll
            // 
            this.BtnReadAll.Location = new System.Drawing.Point(371, 56);
            this.BtnReadAll.Name = "BtnReadAll";
            this.BtnReadAll.Size = new System.Drawing.Size(75, 23);
            this.BtnReadAll.TabIndex = 28;
            this.BtnReadAll.Text = "Refrescar";
            this.BtnReadAll.UseVisualStyleBackColor = true;
            this.BtnReadAll.Click += new System.EventHandler(this.BtnReadAll_Click);
            // 
            // FrmArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 821);
            this.Controls.Add(this.panel2);
            this.Name = "FrmArticle";
            this.Text = "FrmArticle";
            this.Load += new System.EventHandler(this.FrmArticle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView DgvArticle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnReadAll;
        private FontAwesome.Sharp.IconButton IbtnNew;
    }
}