namespace CSG
{
    partial class PruebaEncriptar
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
            this.txtencriptar = new System.Windows.Forms.TextBox();
            this.BtnEncriptar = new System.Windows.Forms.Button();
            this.BtnDesencriptar = new System.Windows.Forms.Button();
            this.txtdesencriptar = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtencriptar
            // 
            this.txtencriptar.Location = new System.Drawing.Point(154, 29);
            this.txtencriptar.Name = "txtencriptar";
            this.txtencriptar.Size = new System.Drawing.Size(192, 20);
            this.txtencriptar.TabIndex = 0;
            // 
            // BtnEncriptar
            // 
            this.BtnEncriptar.Location = new System.Drawing.Point(352, 26);
            this.BtnEncriptar.Name = "BtnEncriptar";
            this.BtnEncriptar.Size = new System.Drawing.Size(75, 23);
            this.BtnEncriptar.TabIndex = 1;
            this.BtnEncriptar.Text = "Encriptar";
            this.BtnEncriptar.UseVisualStyleBackColor = true;
            this.BtnEncriptar.Click += new System.EventHandler(this.BtnEncriptar_Click);
            // 
            // BtnDesencriptar
            // 
            this.BtnDesencriptar.Location = new System.Drawing.Point(352, 88);
            this.BtnDesencriptar.Name = "BtnDesencriptar";
            this.BtnDesencriptar.Size = new System.Drawing.Size(75, 23);
            this.BtnDesencriptar.TabIndex = 3;
            this.BtnDesencriptar.Text = "Desencriptar";
            this.BtnDesencriptar.UseVisualStyleBackColor = true;
            this.BtnDesencriptar.Click += new System.EventHandler(this.BtnDesencriptar_Click);
            // 
            // txtdesencriptar
            // 
            this.txtdesencriptar.Location = new System.Drawing.Point(154, 90);
            this.txtdesencriptar.Name = "txtdesencriptar";
            this.txtdesencriptar.Size = new System.Drawing.Size(192, 20);
            this.txtdesencriptar.TabIndex = 2;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(87, 186);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(415, 102);
            this.txtResult.TabIndex = 4;
            this.txtResult.Text = "";
            // 
            // PruebaEncriptar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 342);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.BtnDesencriptar);
            this.Controls.Add(this.txtdesencriptar);
            this.Controls.Add(this.BtnEncriptar);
            this.Controls.Add(this.txtencriptar);
            this.Name = "PruebaEncriptar";
            this.Text = "PruebaEncriptar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtencriptar;
        private System.Windows.Forms.Button BtnEncriptar;
        private System.Windows.Forms.Button BtnDesencriptar;
        private System.Windows.Forms.TextBox txtdesencriptar;
        private System.Windows.Forms.RichTextBox txtResult;
    }
}