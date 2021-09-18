namespace CSG.views
{
    partial class FrmDocsGenerator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelPpal = new System.Windows.Forms.Panel();
            this.panelGroup1 = new System.Windows.Forms.GroupBox();
            this.lblMsgDoc1 = new System.Windows.Forms.Label();
            this.DgvDocs1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.btnDoc1 = new FontAwesome.Sharp.IconButton();
            this.txtOrderNumberDoc1 = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelPpal.SuspendLayout();
            this.panelGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDocs1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPpal
            // 
            this.panelPpal.BackColor = System.Drawing.Color.White;
            this.panelPpal.Controls.Add(this.panelGroup1);
            this.panelPpal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPpal.Location = new System.Drawing.Point(0, 0);
            this.panelPpal.Name = "panelPpal";
            this.panelPpal.Size = new System.Drawing.Size(982, 646);
            this.panelPpal.TabIndex = 0;
            // 
            // panelGroup1
            // 
            this.panelGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGroup1.Controls.Add(this.lblMsgDoc1);
            this.panelGroup1.Controls.Add(this.DgvDocs1);
            this.panelGroup1.Controls.Add(this.btnDoc1);
            this.panelGroup1.Controls.Add(this.txtOrderNumberDoc1);
            this.panelGroup1.Controls.Add(this.bunifuCustomLabel1);
            this.panelGroup1.Location = new System.Drawing.Point(12, 12);
            this.panelGroup1.Name = "panelGroup1";
            this.panelGroup1.Size = new System.Drawing.Size(958, 97);
            this.panelGroup1.TabIndex = 0;
            this.panelGroup1.TabStop = false;
            this.panelGroup1.Text = "Recepción de orden";
            // 
            // lblMsgDoc1
            // 
            this.lblMsgDoc1.AutoSize = true;
            this.lblMsgDoc1.Location = new System.Drawing.Point(291, 31);
            this.lblMsgDoc1.Name = "lblMsgDoc1";
            this.lblMsgDoc1.Size = new System.Drawing.Size(26, 13);
            this.lblMsgDoc1.TabIndex = 5;
            this.lblMsgDoc1.Text = "msg";
            this.lblMsgDoc1.Visible = false;
            // 
            // DgvDocs1
            // 
            this.DgvDocs1.AllowUserToAddRows = false;
            this.DgvDocs1.AllowUserToDeleteRows = false;
            this.DgvDocs1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvDocs1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvDocs1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvDocs1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvDocs1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvDocs1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DgvDocs1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvDocs1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDocs1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvDocs1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvDocs1.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvDocs1.DoubleBuffered = true;
            this.DgvDocs1.EnableHeadersVisualStyles = false;
            this.DgvDocs1.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.DgvDocs1.HeaderForeColor = System.Drawing.Color.White;
            this.DgvDocs1.Location = new System.Drawing.Point(35, 51);
            this.DgvDocs1.MultiSelect = false;
            this.DgvDocs1.Name = "DgvDocs1";
            this.DgvDocs1.ReadOnly = true;
            this.DgvDocs1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvDocs1.RowHeadersVisible = false;
            this.DgvDocs1.Size = new System.Drawing.Size(893, 40);
            this.DgvDocs1.TabIndex = 4;
            this.DgvDocs1.Visible = false;
            this.DgvDocs1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDocs1_CellContentClick);
            // 
            // btnDoc1
            // 
            this.btnDoc1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoc1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDoc1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnDoc1.IconColor = System.Drawing.Color.Black;
            this.btnDoc1.IconSize = 16;
            this.btnDoc1.Location = new System.Drawing.Point(254, 24);
            this.btnDoc1.Name = "btnDoc1";
            this.btnDoc1.Rotation = 0D;
            this.btnDoc1.Size = new System.Drawing.Size(31, 21);
            this.btnDoc1.TabIndex = 3;
            this.btnDoc1.UseVisualStyleBackColor = true;
            this.btnDoc1.Click += new System.EventHandler(this.BtnDoc1_Click);
            // 
            // txtOrderNumberDoc1
            // 
            this.txtOrderNumberDoc1.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtOrderNumberDoc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderNumberDoc1.Location = new System.Drawing.Point(107, 24);
            this.txtOrderNumberDoc1.Name = "txtOrderNumberDoc1";
            this.txtOrderNumberDoc1.Size = new System.Drawing.Size(141, 20);
            this.txtOrderNumberDoc1.TabIndex = 2;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(32, 27);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(69, 13);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Nro de orden";
            // 
            // FrmDocsGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 646);
            this.Controls.Add(this.panelPpal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDocsGenerator";
            this.Text = "FrmDocsGenerator";
            this.panelPpal.ResumeLayout(false);
            this.panelGroup1.ResumeLayout(false);
            this.panelGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDocs1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPpal;
        private System.Windows.Forms.GroupBox panelGroup1;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtOrderNumberDoc1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private FontAwesome.Sharp.IconButton btnDoc1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid DgvDocs1;
        private System.Windows.Forms.Label lblMsgDoc1;
    }
}