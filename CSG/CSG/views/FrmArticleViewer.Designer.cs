namespace CSG.views
{
    partial class FrmArticleViewer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUpdateDate = new System.Windows.Forms.Label();
            this.lblUpdateby = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.lblCreateby = new System.Windows.Forms.Label();
            this.lblWarranty = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUpdateDate);
            this.panel1.Controls.Add(this.lblUpdateby);
            this.panel1.Controls.Add(this.lblCreateDate);
            this.panel1.Controls.Add(this.lblCreateby);
            this.panel1.Controls.Add(this.lblWarranty);
            this.panel1.Controls.Add(this.iconPictureBox1);
            this.panel1.Controls.Add(this.lblCategory);
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 610);
            this.panel1.TabIndex = 0;
            // 
            // lblUpdateDate
            // 
            this.lblUpdateDate.AutoSize = true;
            this.lblUpdateDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateDate.Location = new System.Drawing.Point(33, 534);
            this.lblUpdateDate.Name = "lblUpdateDate";
            this.lblUpdateDate.Size = new System.Drawing.Size(109, 19);
            this.lblUpdateDate.TabIndex = 7;
            this.lblUpdateDate.Text = "updatedate";
            // 
            // lblUpdateby
            // 
            this.lblUpdateby.AutoSize = true;
            this.lblUpdateby.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateby.Location = new System.Drawing.Point(33, 515);
            this.lblUpdateby.Name = "lblUpdateby";
            this.lblUpdateby.Size = new System.Drawing.Size(87, 19);
            this.lblUpdateby.TabIndex = 6;
            this.lblUpdateby.Text = "updateby";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(33, 446);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(103, 19);
            this.lblCreateDate.TabIndex = 5;
            this.lblCreateDate.Text = "createdate";
            // 
            // lblCreateby
            // 
            this.lblCreateby.AutoSize = true;
            this.lblCreateby.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateby.Location = new System.Drawing.Point(33, 427);
            this.lblCreateby.Name = "lblCreateby";
            this.lblCreateby.Size = new System.Drawing.Size(81, 19);
            this.lblCreateby.TabIndex = 4;
            this.lblCreateby.Text = "createby";
            // 
            // lblWarranty
            // 
            this.lblWarranty.AutoSize = true;
            this.lblWarranty.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarranty.Location = new System.Drawing.Point(34, 339);
            this.lblWarranty.Name = "lblWarranty";
            this.lblWarranty.Size = new System.Drawing.Size(80, 19);
            this.lblWarranty.TabIndex = 3;
            this.lblWarranty.Text = "warranty";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Image;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconSize = 165;
            this.iconPictureBox1.Location = new System.Drawing.Point(36, 29);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(382, 165);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(32, 320);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(81, 19);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "category";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(32, 229);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(399, 68);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FrmArticleViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 610);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(468, 649);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(468, 649);
            this.Name = "FrmArticleViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmArticleViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmArticleViewer_FormClosed);
            this.Load += new System.EventHandler(this.FrmArticleViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCategory;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label lblWarranty;
        private System.Windows.Forms.Label lblUpdateDate;
        private System.Windows.Forms.Label lblUpdateby;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label lblCreateby;
    }
}