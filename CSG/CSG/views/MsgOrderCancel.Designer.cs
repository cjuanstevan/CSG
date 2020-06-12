namespace CSG.views
{
    partial class MsgOrderCancel
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
            this.txtComentarys = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClose = new FontAwesome.Sharp.IconPictureBox();
            this.IpbCancel = new FontAwesome.Sharp.IconPictureBox();
            this.BtnBack = new FontAwesome.Sharp.IconButton();
            this.BtnOk = new FontAwesome.Sharp.IconButton();
            this.lblMsg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IpbCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMsg);
            this.panel1.Controls.Add(this.txtComentarys);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.IpbCancel);
            this.panel1.Controls.Add(this.BtnBack);
            this.panel1.Controls.Add(this.BtnOk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 300);
            this.panel1.TabIndex = 8;
            // 
            // txtComentarys
            // 
            this.txtComentarys.Location = new System.Drawing.Point(59, 140);
            this.txtComentarys.Name = "txtComentarys";
            this.txtComentarys.Size = new System.Drawing.Size(347, 68);
            this.txtComentarys.TabIndex = 8;
            this.txtComentarys.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.BtnClose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 28);
            this.panel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motivo de cancelación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnClose.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.BtnClose.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.BtnClose.IconColor = System.Drawing.Color.White;
            this.BtnClose.IconSize = 28;
            this.BtnClose.Location = new System.Drawing.Point(413, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(35, 28);
            this.BtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnClose.TabIndex = 5;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // IpbCancel
            // 
            this.IpbCancel.BackColor = System.Drawing.SystemColors.Control;
            this.IpbCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IpbCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IpbCancel.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.IpbCancel.IconColor = System.Drawing.SystemColors.ControlText;
            this.IpbCancel.IconSize = 90;
            this.IpbCancel.Location = new System.Drawing.Point(177, 34);
            this.IpbCancel.Name = "IpbCancel";
            this.IpbCancel.Padding = new System.Windows.Forms.Padding(10);
            this.IpbCancel.Size = new System.Drawing.Size(106, 90);
            this.IpbCancel.TabIndex = 4;
            this.IpbCancel.TabStop = false;
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBack.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnBack.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnBack.IconColor = System.Drawing.Color.Black;
            this.BtnBack.IconSize = 16;
            this.BtnBack.Location = new System.Drawing.Point(245, 228);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Rotation = 0D;
            this.BtnBack.Size = new System.Drawing.Size(161, 35);
            this.BtnBack.TabIndex = 3;
            this.BtnBack.Text = "VOLVER";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.DarkRed;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnOk.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnOk.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnOk.IconColor = System.Drawing.Color.Black;
            this.BtnOk.IconSize = 16;
            this.BtnOk.Location = new System.Drawing.Point(59, 228);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Rotation = 0D;
            this.BtnOk.Size = new System.Drawing.Size(161, 35);
            this.BtnOk.TabIndex = 2;
            this.BtnOk.Text = "CANCELAR";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(59, 209);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(55, 16);
            this.lblMsg.TabIndex = 9;
            this.lblMsg.Text = "message";
            this.lblMsg.Visible = false;
            // 
            // MsgOrderCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MsgOrderCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MsgOrderCancel";
            this.Load += new System.EventHandler(this.MsgOrderCancel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IpbCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconPictureBox BtnClose;
        private FontAwesome.Sharp.IconPictureBox IpbCancel;
        private FontAwesome.Sharp.IconButton BtnBack;
        private FontAwesome.Sharp.IconButton BtnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtComentarys;
        private System.Windows.Forms.Label lblMsg;
    }
}