namespace CSG.views
{
    partial class MsgLogout
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnYes = new FontAwesome.Sharp.IconButton();
            this.BtnNo = new FontAwesome.Sharp.IconButton();
            this.IpbLogout = new FontAwesome.Sharp.IconPictureBox();
            this.BtnClose = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IpbLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CERRAR SESIÓN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desea cerrar la sesión?";
            // 
            // BtnYes
            // 
            this.BtnYes.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnYes.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnYes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnYes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnYes.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnYes.IconColor = System.Drawing.Color.Black;
            this.BtnYes.IconSize = 16;
            this.BtnYes.Location = new System.Drawing.Point(67, 221);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Rotation = 0D;
            this.BtnYes.Size = new System.Drawing.Size(161, 35);
            this.BtnYes.TabIndex = 2;
            this.BtnYes.Text = "SI";
            this.BtnYes.UseVisualStyleBackColor = false;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // BtnNo
            // 
            this.BtnNo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnNo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnNo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnNo.IconColor = System.Drawing.Color.Black;
            this.BtnNo.IconSize = 16;
            this.BtnNo.Location = new System.Drawing.Point(253, 221);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Rotation = 0D;
            this.BtnNo.Size = new System.Drawing.Size(161, 35);
            this.BtnNo.TabIndex = 3;
            this.BtnNo.Text = "NO";
            this.BtnNo.UseVisualStyleBackColor = false;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // IpbLogout
            // 
            this.IpbLogout.BackColor = System.Drawing.SystemColors.Control;
            this.IpbLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IpbLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IpbLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.IpbLogout.IconColor = System.Drawing.SystemColors.ControlText;
            this.IpbLogout.IconSize = 95;
            this.IpbLogout.Location = new System.Drawing.Point(177, 32);
            this.IpbLogout.Name = "IpbLogout";
            this.IpbLogout.Padding = new System.Windows.Forms.Padding(10);
            this.IpbLogout.Size = new System.Drawing.Size(106, 90);
            this.IpbLogout.TabIndex = 4;
            this.IpbLogout.TabStop = false;
            this.IpbLogout.Click += new System.EventHandler(this.IconPictureBox1_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.SystemColors.Control;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.BtnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnClose.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.BtnClose.IconColor = System.Drawing.SystemColors.ControlText;
            this.BtnClose.IconSize = 30;
            this.BtnClose.Location = new System.Drawing.Point(410, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(35, 30);
            this.BtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnClose.TabIndex = 5;
            this.BtnClose.TabStop = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.IpbLogout);
            this.panel1.Controls.Add(this.BtnNo);
            this.panel1.Controls.Add(this.BtnYes);
            this.panel1.Controls.Add(this.BtnClose);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 300);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // MsgLogout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MsgLogout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MsgLogout";
            this.Load += new System.EventHandler(this.MsgLogout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IpbLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton BtnYes;
        private FontAwesome.Sharp.IconButton BtnNo;
        private FontAwesome.Sharp.IconPictureBox IpbLogout;
        private FontAwesome.Sharp.IconPictureBox BtnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}