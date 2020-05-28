namespace CSG.views
{
    partial class FrmRecoveryAccount
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
            this.label3 = new System.Windows.Forms.Label();
            this.BtnRecoveryAccount = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(244, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "RECUPERAR CUENTA";
            // 
            // BtnRecoveryAccount
            // 
            this.BtnRecoveryAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnRecoveryAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRecoveryAccount.FlatAppearance.BorderSize = 0;
            this.BtnRecoveryAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecoveryAccount.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRecoveryAccount.ForeColor = System.Drawing.Color.LightGray;
            this.BtnRecoveryAccount.Location = new System.Drawing.Point(134, 252);
            this.BtnRecoveryAccount.Name = "BtnRecoveryAccount";
            this.BtnRecoveryAccount.Size = new System.Drawing.Size(400, 36);
            this.BtnRecoveryAccount.TabIndex = 0;
            this.BtnRecoveryAccount.Text = "ENVIAR";
            this.BtnRecoveryAccount.UseVisualStyleBackColor = false;
            this.BtnRecoveryAccount.Click += new System.EventHandler(this.BtnRecoveryAccount_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(134, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(400, 2);
            this.label4.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(134, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(400, 2);
            this.label5.TabIndex = 16;
            // 
            // txtToken
            // 
            this.txtToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtToken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtToken.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToken.ForeColor = System.Drawing.Color.DimGray;
            this.txtToken.Location = new System.Drawing.Point(134, 178);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(400, 20);
            this.txtToken.TabIndex = 2;
            this.txtToken.Text = "TOKEN";
            this.txtToken.Enter += new System.EventHandler(this.TxtToken_Enter);
            this.txtToken.Leave += new System.EventHandler(this.TxtToken_Leave);
            // 
            // txtAccount
            // 
            this.txtAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccount.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount.ForeColor = System.Drawing.Color.DimGray;
            this.txtAccount.Location = new System.Drawing.Point(134, 102);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(400, 20);
            this.txtAccount.TabIndex = 1;
            this.txtAccount.Text = "USUARIO O CORREO ELECTRÓNICO";
            this.txtAccount.Enter += new System.EventHandler(this.TxtAccount_Enter);
            this.txtAccount.Leave += new System.EventHandler(this.TxtAccount_Leave);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Image = global::CSG.Properties.Resources.close;
            this.BtnClose.Location = new System.Drawing.Point(667, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(32, 32);
            this.BtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnClose.TabIndex = 20;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Tai Le", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMessage.Image = global::CSG.Properties.Resources.ok;
            this.lblMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Location = new System.Drawing.Point(131, 222);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(85, 18);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "      message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMessage.Visible = false;
            // 
            // FrmRecoveryAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnRecoveryAccount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRecoveryAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRecoveryAccount";
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnRecoveryAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.PictureBox BtnClose;
    }
}