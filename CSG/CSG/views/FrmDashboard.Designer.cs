namespace CSG.views
{
    partial class FrmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.Plmain = new System.Windows.Forms.Panel();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.PlMaintenaceSubmenu = new System.Windows.Forms.Panel();
            this.BtnTechnicians = new System.Windows.Forms.Button();
            this.BtnServices = new System.Windows.Forms.Button();
            this.BtnRefactions = new System.Windows.Forms.Button();
            this.BtnArticles = new System.Windows.Forms.Button();
            this.BtnClients = new System.Windows.Forms.Button();
            this.BtnMaintenance = new System.Windows.Forms.Button();
            this.PlOrdersSubmenu = new System.Windows.Forms.Panel();
            this.BtnInvoices = new System.Windows.Forms.Button();
            this.BtnReports = new System.Windows.Forms.Button();
            this.BtnOrderRead = new System.Windows.Forms.Button();
            this.BtnOrderCreate = new System.Windows.Forms.Button();
            this.BtnOrders = new System.Windows.Forms.Button();
            this.BtnIndex = new System.Windows.Forms.Button();
            this.PlLogo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.PlTop = new System.Windows.Forms.Panel();
            this.IpbUser = new FontAwesome.Sharp.IconPictureBox();
            this.PnlUserDates = new System.Windows.Forms.Panel();
            this.linkBtnEdit = new System.Windows.Forms.LinkLabel();
            this.lblUserDefinition = new System.Windows.Forms.Label();
            this.lblUserRol = new System.Windows.Forms.Label();
            this.LblNameMain = new System.Windows.Forms.Label();
            this.PlChildForm = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Plmain.SuspendLayout();
            this.PlMaintenaceSubmenu.SuspendLayout();
            this.PlOrdersSubmenu.SuspendLayout();
            this.PlLogo.SuspendLayout();
            this.PlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IpbUser)).BeginInit();
            this.PnlUserDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Plmain
            // 
            this.Plmain.AutoScroll = true;
            this.Plmain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(36)))));
            this.Plmain.Controls.Add(this.BtnLogout);
            this.Plmain.Controls.Add(this.PlMaintenaceSubmenu);
            this.Plmain.Controls.Add(this.BtnMaintenance);
            this.Plmain.Controls.Add(this.PlOrdersSubmenu);
            this.Plmain.Controls.Add(this.BtnOrders);
            this.Plmain.Controls.Add(this.BtnIndex);
            this.Plmain.Controls.Add(this.PlLogo);
            this.Plmain.Dock = System.Windows.Forms.DockStyle.Left;
            this.Plmain.Location = new System.Drawing.Point(0, 0);
            this.Plmain.Name = "Plmain";
            this.Plmain.Size = new System.Drawing.Size(282, 721);
            this.Plmain.TabIndex = 0;
            // 
            // BtnLogout
            // 
            this.BtnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnLogout.FlatAppearance.BorderSize = 0;
            this.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnLogout.Image = global::CSG.Properties.Resources.logout;
            this.BtnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogout.Location = new System.Drawing.Point(0, 691);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(265, 52);
            this.BtnLogout.TabIndex = 8;
            this.BtnLogout.Text = "Cerrar sesión";
            this.BtnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLogout.UseVisualStyleBackColor = true;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // PlMaintenaceSubmenu
            // 
            this.PlMaintenaceSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(109)))));
            this.PlMaintenaceSubmenu.Controls.Add(this.BtnTechnicians);
            this.PlMaintenaceSubmenu.Controls.Add(this.BtnServices);
            this.PlMaintenaceSubmenu.Controls.Add(this.BtnRefactions);
            this.PlMaintenaceSubmenu.Controls.Add(this.BtnArticles);
            this.PlMaintenaceSubmenu.Controls.Add(this.BtnClients);
            this.PlMaintenaceSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlMaintenaceSubmenu.Location = new System.Drawing.Point(0, 439);
            this.PlMaintenaceSubmenu.Name = "PlMaintenaceSubmenu";
            this.PlMaintenaceSubmenu.Size = new System.Drawing.Size(265, 252);
            this.PlMaintenaceSubmenu.TabIndex = 6;
            // 
            // BtnTechnicians
            // 
            this.BtnTechnicians.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTechnicians.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnTechnicians.FlatAppearance.BorderSize = 0;
            this.BtnTechnicians.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTechnicians.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnTechnicians.Location = new System.Drawing.Point(0, 204);
            this.BtnTechnicians.Name = "BtnTechnicians";
            this.BtnTechnicians.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnTechnicians.Size = new System.Drawing.Size(265, 51);
            this.BtnTechnicians.TabIndex = 4;
            this.BtnTechnicians.Text = "Técnicos";
            this.BtnTechnicians.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTechnicians.UseVisualStyleBackColor = true;
            this.BtnTechnicians.Click += new System.EventHandler(this.BtnTechnician_Click);
            // 
            // BtnServices
            // 
            this.BtnServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnServices.FlatAppearance.BorderSize = 0;
            this.BtnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnServices.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnServices.Location = new System.Drawing.Point(0, 153);
            this.BtnServices.Name = "BtnServices";
            this.BtnServices.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnServices.Size = new System.Drawing.Size(265, 51);
            this.BtnServices.TabIndex = 3;
            this.BtnServices.Text = "Servicios";
            this.BtnServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnServices.UseVisualStyleBackColor = true;
            this.BtnServices.Click += new System.EventHandler(this.BtnServices_Click);
            // 
            // BtnRefactions
            // 
            this.BtnRefactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRefactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnRefactions.FlatAppearance.BorderSize = 0;
            this.BtnRefactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefactions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnRefactions.Location = new System.Drawing.Point(0, 102);
            this.BtnRefactions.Name = "BtnRefactions";
            this.BtnRefactions.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnRefactions.Size = new System.Drawing.Size(265, 51);
            this.BtnRefactions.TabIndex = 2;
            this.BtnRefactions.Text = "Repuestos";
            this.BtnRefactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefactions.UseVisualStyleBackColor = true;
            this.BtnRefactions.Click += new System.EventHandler(this.BtnRefactions_Click);
            // 
            // BtnArticles
            // 
            this.BtnArticles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnArticles.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnArticles.FlatAppearance.BorderSize = 0;
            this.BtnArticles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnArticles.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnArticles.Location = new System.Drawing.Point(0, 51);
            this.BtnArticles.Name = "BtnArticles";
            this.BtnArticles.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnArticles.Size = new System.Drawing.Size(265, 51);
            this.BtnArticles.TabIndex = 1;
            this.BtnArticles.Text = "Articulos";
            this.BtnArticles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnArticles.UseVisualStyleBackColor = true;
            this.BtnArticles.Click += new System.EventHandler(this.BtnArticles_Click);
            // 
            // BtnClients
            // 
            this.BtnClients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnClients.FlatAppearance.BorderSize = 0;
            this.BtnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClients.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnClients.Location = new System.Drawing.Point(0, 0);
            this.BtnClients.Name = "BtnClients";
            this.BtnClients.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnClients.Size = new System.Drawing.Size(265, 51);
            this.BtnClients.TabIndex = 0;
            this.BtnClients.Text = "Clientes";
            this.BtnClients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClients.UseVisualStyleBackColor = true;
            this.BtnClients.Click += new System.EventHandler(this.BtnClients_Click);
            // 
            // BtnMaintenance
            // 
            this.BtnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMaintenance.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnMaintenance.FlatAppearance.BorderSize = 0;
            this.BtnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaintenance.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnMaintenance.Image = global::CSG.Properties.Resources.maintenance;
            this.BtnMaintenance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMaintenance.Location = new System.Drawing.Point(0, 387);
            this.BtnMaintenance.Name = "BtnMaintenance";
            this.BtnMaintenance.Size = new System.Drawing.Size(265, 52);
            this.BtnMaintenance.TabIndex = 5;
            this.BtnMaintenance.Text = "Mantenimiento";
            this.BtnMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMaintenance.UseVisualStyleBackColor = true;
            this.BtnMaintenance.Click += new System.EventHandler(this.BtnMaintenance_Click);
            // 
            // PlOrdersSubmenu
            // 
            this.PlOrdersSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(109)))));
            this.PlOrdersSubmenu.Controls.Add(this.BtnInvoices);
            this.PlOrdersSubmenu.Controls.Add(this.BtnReports);
            this.PlOrdersSubmenu.Controls.Add(this.BtnOrderRead);
            this.PlOrdersSubmenu.Controls.Add(this.BtnOrderCreate);
            this.PlOrdersSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlOrdersSubmenu.Location = new System.Drawing.Point(0, 183);
            this.PlOrdersSubmenu.Name = "PlOrdersSubmenu";
            this.PlOrdersSubmenu.Size = new System.Drawing.Size(265, 204);
            this.PlOrdersSubmenu.TabIndex = 4;
            // 
            // BtnInvoices
            // 
            this.BtnInvoices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnInvoices.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnInvoices.FlatAppearance.BorderSize = 0;
            this.BtnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInvoices.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnInvoices.Location = new System.Drawing.Point(0, 153);
            this.BtnInvoices.Name = "BtnInvoices";
            this.BtnInvoices.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnInvoices.Size = new System.Drawing.Size(265, 51);
            this.BtnInvoices.TabIndex = 3;
            this.BtnInvoices.Text = "Generar factura";
            this.BtnInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInvoices.UseVisualStyleBackColor = true;
            // 
            // BtnReports
            // 
            this.BtnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReports.FlatAppearance.BorderSize = 0;
            this.BtnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReports.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnReports.Location = new System.Drawing.Point(0, 102);
            this.BtnReports.Name = "BtnReports";
            this.BtnReports.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnReports.Size = new System.Drawing.Size(265, 51);
            this.BtnReports.TabIndex = 2;
            this.BtnReports.Text = "Reportes";
            this.BtnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReports.UseVisualStyleBackColor = true;
            // 
            // BtnOrderRead
            // 
            this.BtnOrderRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOrderRead.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOrderRead.FlatAppearance.BorderSize = 0;
            this.BtnOrderRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrderRead.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnOrderRead.Location = new System.Drawing.Point(0, 51);
            this.BtnOrderRead.Name = "BtnOrderRead";
            this.BtnOrderRead.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnOrderRead.Size = new System.Drawing.Size(265, 51);
            this.BtnOrderRead.TabIndex = 1;
            this.BtnOrderRead.Text = "Consultar";
            this.BtnOrderRead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrderRead.UseVisualStyleBackColor = true;
            this.BtnOrderRead.Click += new System.EventHandler(this.BtnOrderRead_Click);
            // 
            // BtnOrderCreate
            // 
            this.BtnOrderCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOrderCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOrderCreate.FlatAppearance.BorderSize = 0;
            this.BtnOrderCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrderCreate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnOrderCreate.Location = new System.Drawing.Point(0, 0);
            this.BtnOrderCreate.Name = "BtnOrderCreate";
            this.BtnOrderCreate.Padding = new System.Windows.Forms.Padding(31, 0, 0, 0);
            this.BtnOrderCreate.Size = new System.Drawing.Size(265, 51);
            this.BtnOrderCreate.TabIndex = 0;
            this.BtnOrderCreate.Text = "Crear";
            this.BtnOrderCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrderCreate.UseVisualStyleBackColor = true;
            this.BtnOrderCreate.Click += new System.EventHandler(this.BtnOrderCreate_Click);
            // 
            // BtnOrders
            // 
            this.BtnOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOrders.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOrders.FlatAppearance.BorderSize = 0;
            this.BtnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrders.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnOrders.Image = global::CSG.Properties.Resources.orders;
            this.BtnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrders.Location = new System.Drawing.Point(0, 131);
            this.BtnOrders.Name = "BtnOrders";
            this.BtnOrders.Size = new System.Drawing.Size(265, 52);
            this.BtnOrders.TabIndex = 3;
            this.BtnOrders.Text = "Ordenes";
            this.BtnOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOrders.UseVisualStyleBackColor = true;
            this.BtnOrders.Click += new System.EventHandler(this.BtnOrders_Click);
            // 
            // BtnIndex
            // 
            this.BtnIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnIndex.FlatAppearance.BorderSize = 0;
            this.BtnIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.BtnIndex.Image = global::CSG.Properties.Resources.dashboard;
            this.BtnIndex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIndex.Location = new System.Drawing.Point(0, 79);
            this.BtnIndex.Name = "BtnIndex";
            this.BtnIndex.Size = new System.Drawing.Size(265, 52);
            this.BtnIndex.TabIndex = 1;
            this.BtnIndex.Text = "Tablero";
            this.BtnIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIndex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnIndex.UseVisualStyleBackColor = true;
            this.BtnIndex.Click += new System.EventHandler(this.BtnIndex_Click);
            // 
            // PlLogo
            // 
            this.PlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(36)))));
            this.PlLogo.Controls.Add(this.pictureBox1);
            this.PlLogo.Controls.Add(this.label4);
            this.PlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlLogo.Location = new System.Drawing.Point(0, 0);
            this.PlLogo.Name = "PlLogo";
            this.PlLogo.Size = new System.Drawing.Size(265, 79);
            this.PlLogo.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(23, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Control de Servicios y Garantías";
            // 
            // PlTop
            // 
            this.PlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(36)))));
            this.PlTop.Controls.Add(this.IpbUser);
            this.PlTop.Controls.Add(this.PnlUserDates);
            this.PlTop.Controls.Add(this.LblNameMain);
            this.PlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlTop.Location = new System.Drawing.Point(282, 0);
            this.PlTop.Name = "PlTop";
            this.PlTop.Size = new System.Drawing.Size(982, 75);
            this.PlTop.TabIndex = 1;
            // 
            // IpbUser
            // 
            this.IpbUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(40)))), ((int)(((byte)(36)))));
            this.IpbUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.IpbUser.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.IpbUser.IconColor = System.Drawing.Color.White;
            this.IpbUser.IconSize = 75;
            this.IpbUser.Location = new System.Drawing.Point(892, 0);
            this.IpbUser.Name = "IpbUser";
            this.IpbUser.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.IpbUser.Size = new System.Drawing.Size(90, 75);
            this.IpbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IpbUser.TabIndex = 6;
            this.IpbUser.TabStop = false;
            // 
            // PnlUserDates
            // 
            this.PnlUserDates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlUserDates.Controls.Add(this.linkBtnEdit);
            this.PnlUserDates.Controls.Add(this.lblUserDefinition);
            this.PnlUserDates.Controls.Add(this.lblUserRol);
            this.PnlUserDates.Location = new System.Drawing.Point(673, 0);
            this.PnlUserDates.Name = "PnlUserDates";
            this.PnlUserDates.Size = new System.Drawing.Size(219, 79);
            this.PnlUserDates.TabIndex = 4;
            // 
            // linkBtnEdit
            // 
            this.linkBtnEdit.AutoSize = true;
            this.linkBtnEdit.Location = new System.Drawing.Point(158, 52);
            this.linkBtnEdit.Name = "linkBtnEdit";
            this.linkBtnEdit.Size = new System.Drawing.Size(49, 18);
            this.linkBtnEdit.TabIndex = 4;
            this.linkBtnEdit.TabStop = true;
            this.linkBtnEdit.Text = "Cuenta";
            this.linkBtnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBtnEdit_LinkClicked);
            // 
            // lblUserDefinition
            // 
            this.lblUserDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserDefinition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUserDefinition.Location = new System.Drawing.Point(3, 11);
            this.lblUserDefinition.Name = "lblUserDefinition";
            this.lblUserDefinition.Size = new System.Drawing.Size(208, 19);
            this.lblUserDefinition.TabIndex = 2;
            this.lblUserDefinition.Text = "user_definition";
            this.lblUserDefinition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserRol
            // 
            this.lblUserRol.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUserRol.Location = new System.Drawing.Point(6, 30);
            this.lblUserRol.Name = "lblUserRol";
            this.lblUserRol.Size = new System.Drawing.Size(205, 19);
            this.lblUserRol.TabIndex = 3;
            this.lblUserRol.Text = "user_rol";
            this.lblUserRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblNameMain
            // 
            this.LblNameMain.AutoSize = true;
            this.LblNameMain.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNameMain.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblNameMain.Location = new System.Drawing.Point(58, 30);
            this.LblNameMain.Name = "LblNameMain";
            this.LblNameMain.Size = new System.Drawing.Size(85, 22);
            this.LblNameMain.TabIndex = 0;
            this.LblNameMain.Text = "TABLERO";
            // 
            // PlChildForm
            // 
            this.PlChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(109)))));
            this.PlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlChildForm.Location = new System.Drawing.Point(282, 75);
            this.PlChildForm.Name = "PlChildForm";
            this.PlChildForm.Size = new System.Drawing.Size(982, 646);
            this.PlChildForm.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSG.Properties.Resources.logo_prueba_edit;
            this.pictureBox1.Location = new System.Drawing.Point(75, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 721);
            this.Controls.Add(this.PlChildForm);
            this.Controls.Add(this.PlTop);
            this.Controls.Add(this.Plmain);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1280, 760);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Servicios y Garantías";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.Plmain.ResumeLayout(false);
            this.PlMaintenaceSubmenu.ResumeLayout(false);
            this.PlOrdersSubmenu.ResumeLayout(false);
            this.PlLogo.ResumeLayout(false);
            this.PlLogo.PerformLayout();
            this.PlTop.ResumeLayout(false);
            this.PlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IpbUser)).EndInit();
            this.PnlUserDates.ResumeLayout(false);
            this.PnlUserDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Plmain;
        private System.Windows.Forms.Panel PlLogo;
        private System.Windows.Forms.Button BtnIndex;
        private System.Windows.Forms.Panel PlOrdersSubmenu;
        private System.Windows.Forms.Button BtnInvoices;
        private System.Windows.Forms.Button BtnReports;
        private System.Windows.Forms.Button BtnOrderRead;
        private System.Windows.Forms.Button BtnOrderCreate;
        private System.Windows.Forms.Button BtnOrders;
        private System.Windows.Forms.Panel PlMaintenaceSubmenu;
        private System.Windows.Forms.Button BtnServices;
        private System.Windows.Forms.Button BtnRefactions;
        private System.Windows.Forms.Button BtnArticles;
        private System.Windows.Forms.Button BtnClients;
        private System.Windows.Forms.Button BtnMaintenance;
        private System.Windows.Forms.Button BtnTechnicians;
        private System.Windows.Forms.Panel PlTop;
        private System.Windows.Forms.Panel PlChildForm;
        private System.Windows.Forms.Label LblNameMain;
        private System.Windows.Forms.Label lblUserDefinition;
        private System.Windows.Forms.Label lblUserRol;
        private System.Windows.Forms.Panel PnlUserDates;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkBtnEdit;
        private FontAwesome.Sharp.IconPictureBox IpbUser;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}