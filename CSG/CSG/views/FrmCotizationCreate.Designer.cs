﻿namespace CSG.views
{
    partial class FrmCotizationCreate
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtComentarys = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IbtnUpdate = new FontAwesome.Sharp.IconButton();
            this.IbtnBack = new FontAwesome.Sharp.IconButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IbtnSearchService = new FontAwesome.Sharp.IconButton();
            this.IbtnAddService = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.nupQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtServiceCode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.DgvServices = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.IbtnAddRefaction = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.NupQR = new System.Windows.Forms.NumericUpDown();
            this.txtRefactionCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DgvRefactions = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpReception_date = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOrderType = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOrderState = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTechnicianContact = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTechnicianName = new System.Windows.Forms.TextBox();
            this.txtTechnicianTelephone = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReportClient = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtArticleCode = new System.Windows.Forms.TextBox();
            this.txtArticleDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtArticleEsp = new System.Windows.Forms.TextBox();
            this.lblEsp = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.txtArticleSerial = new System.Windows.Forms.TextBox();
            this.txtArticleModel = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvServices)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRefactions)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtComentarys);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtReportClient);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 723);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 552);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Comentarios técnicos";
            // 
            // txtComentarys
            // 
            this.txtComentarys.Location = new System.Drawing.Point(18, 568);
            this.txtComentarys.MaxLength = 1000;
            this.txtComentarys.Name = "txtComentarys";
            this.txtComentarys.Size = new System.Drawing.Size(951, 72);
            this.txtComentarys.TabIndex = 32;
            this.txtComentarys.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.IbtnUpdate);
            this.panel2.Controls.Add(this.IbtnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 647);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 74);
            this.panel2.TabIndex = 31;
            // 
            // IbtnUpdate
            // 
            this.IbtnUpdate.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnUpdate.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.IbtnUpdate.IconColor = System.Drawing.Color.Black;
            this.IbtnUpdate.IconSize = 20;
            this.IbtnUpdate.Location = new System.Drawing.Point(880, 24);
            this.IbtnUpdate.Name = "IbtnUpdate";
            this.IbtnUpdate.Rotation = 0D;
            this.IbtnUpdate.Size = new System.Drawing.Size(75, 23);
            this.IbtnUpdate.TabIndex = 4;
            this.IbtnUpdate.Text = "Guardar";
            this.IbtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IbtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IbtnUpdate.UseVisualStyleBackColor = true;
            this.IbtnUpdate.Click += new System.EventHandler(this.IbtnUpdate_Click);
            // 
            // IbtnBack
            // 
            this.IbtnBack.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnBack.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.IbtnBack.IconColor = System.Drawing.Color.Black;
            this.IbtnBack.IconSize = 20;
            this.IbtnBack.Location = new System.Drawing.Point(796, 24);
            this.IbtnBack.Name = "IbtnBack";
            this.IbtnBack.Rotation = 0D;
            this.IbtnBack.Size = new System.Drawing.Size(75, 23);
            this.IbtnBack.TabIndex = 3;
            this.IbtnBack.Text = "Atrás";
            this.IbtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IbtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.IbtnBack.UseVisualStyleBackColor = true;
            this.IbtnBack.Click += new System.EventHandler(this.IbtnBack_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 336);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(955, 214);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.IbtnSearchService);
            this.tabPage1.Controls.Add(this.IbtnAddService);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nupQuantity);
            this.tabPage1.Controls.Add(this.txtServiceCode);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.DgvServices);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(947, 188);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Servicios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // IbtnSearchService
            // 
            this.IbtnSearchService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnSearchService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IbtnSearchService.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnSearchService.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.IbtnSearchService.IconColor = System.Drawing.Color.Black;
            this.IbtnSearchService.IconSize = 15;
            this.IbtnSearchService.Location = new System.Drawing.Point(431, 23);
            this.IbtnSearchService.Name = "IbtnSearchService";
            this.IbtnSearchService.Rotation = 0D;
            this.IbtnSearchService.Size = new System.Drawing.Size(24, 24);
            this.IbtnSearchService.TabIndex = 20;
            this.IbtnSearchService.UseVisualStyleBackColor = true;
            // 
            // IbtnAddService
            // 
            this.IbtnAddService.BackColor = System.Drawing.Color.Transparent;
            this.IbtnAddService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IbtnAddService.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnAddService.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.IbtnAddService.IconColor = System.Drawing.Color.Black;
            this.IbtnAddService.IconSize = 15;
            this.IbtnAddService.Location = new System.Drawing.Point(401, 23);
            this.IbtnAddService.Name = "IbtnAddService";
            this.IbtnAddService.Rotation = 0D;
            this.IbtnAddService.Size = new System.Drawing.Size(24, 24);
            this.IbtnAddService.TabIndex = 19;
            this.IbtnAddService.UseVisualStyleBackColor = false;
            this.IbtnAddService.Click += new System.EventHandler(this.IbtnAddService_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Cantidad";
            // 
            // nupQuantity
            // 
            this.nupQuantity.Location = new System.Drawing.Point(342, 26);
            this.nupQuantity.Name = "nupQuantity";
            this.nupQuantity.Size = new System.Drawing.Size(54, 20);
            this.nupQuantity.TabIndex = 16;
            this.nupQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtServiceCode
            // 
            this.txtServiceCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServiceCode.Location = new System.Drawing.Point(9, 26);
            this.txtServiceCode.Name = "txtServiceCode";
            this.txtServiceCode.Size = new System.Drawing.Size(331, 20);
            this.txtServiceCode.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Código";
            // 
            // DgvServices
            // 
            this.DgvServices.AllowUserToAddRows = false;
            this.DgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvServices.Location = new System.Drawing.Point(7, 49);
            this.DgvServices.Name = "DgvServices";
            this.DgvServices.ReadOnly = true;
            this.DgvServices.Size = new System.Drawing.Size(933, 125);
            this.DgvServices.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.iconButton1);
            this.tabPage2.Controls.Add(this.IbtnAddRefaction);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.NupQR);
            this.tabPage2.Controls.Add(this.txtRefactionCode);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.DgvRefactions);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(947, 188);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Repuestos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconSize = 15;
            this.iconButton1.Location = new System.Drawing.Point(431, 23);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(24, 24);
            this.iconButton1.TabIndex = 26;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // IbtnAddRefaction
            // 
            this.IbtnAddRefaction.BackColor = System.Drawing.Color.Transparent;
            this.IbtnAddRefaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IbtnAddRefaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IbtnAddRefaction.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IbtnAddRefaction.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.IbtnAddRefaction.IconColor = System.Drawing.Color.Black;
            this.IbtnAddRefaction.IconSize = 15;
            this.IbtnAddRefaction.Location = new System.Drawing.Point(401, 23);
            this.IbtnAddRefaction.Name = "IbtnAddRefaction";
            this.IbtnAddRefaction.Rotation = 0D;
            this.IbtnAddRefaction.Size = new System.Drawing.Size(24, 24);
            this.IbtnAddRefaction.TabIndex = 25;
            this.IbtnAddRefaction.UseVisualStyleBackColor = false;
            this.IbtnAddRefaction.Click += new System.EventHandler(this.IbtnAddRefaction_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(336, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Cantidad";
            // 
            // NupQR
            // 
            this.NupQR.Location = new System.Drawing.Point(342, 26);
            this.NupQR.Name = "NupQR";
            this.NupQR.Size = new System.Drawing.Size(54, 20);
            this.NupQR.TabIndex = 22;
            this.NupQR.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtRefactionCode
            // 
            this.txtRefactionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRefactionCode.Location = new System.Drawing.Point(9, 26);
            this.txtRefactionCode.Name = "txtRefactionCode";
            this.txtRefactionCode.Size = new System.Drawing.Size(331, 20);
            this.txtRefactionCode.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Código";
            // 
            // DgvRefactions
            // 
            this.DgvRefactions.AllowUserToAddRows = false;
            this.DgvRefactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvRefactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvRefactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRefactions.Location = new System.Drawing.Point(7, 49);
            this.DgvRefactions.Name = "DgvRefactions";
            this.DgvRefactions.ReadOnly = true;
            this.DgvRefactions.Size = new System.Drawing.Size(933, 125);
            this.DgvRefactions.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dtpReception_date);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtOrder);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtOrderType);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtOrderState);
            this.groupBox4.Location = new System.Drawing.Point(15, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(954, 70);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Información de la orden";
            // 
            // dtpReception_date
            // 
            this.dtpReception_date.Enabled = false;
            this.dtpReception_date.Location = new System.Drawing.Point(472, 18);
            this.dtpReception_date.Name = "dtpReception_date";
            this.dtpReception_date.Size = new System.Drawing.Size(289, 20);
            this.dtpReception_date.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(303, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Fecha de recepción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Orden";
            // 
            // txtOrder
            // 
            this.txtOrder.Enabled = false;
            this.txtOrder.Location = new System.Drawing.Point(59, 18);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.ReadOnly = true;
            this.txtOrder.Size = new System.Drawing.Size(218, 20);
            this.txtOrder.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Tipo";
            // 
            // txtOrderType
            // 
            this.txtOrderType.Enabled = false;
            this.txtOrderType.Location = new System.Drawing.Point(59, 40);
            this.txtOrderType.Name = "txtOrderType";
            this.txtOrderType.ReadOnly = true;
            this.txtOrderType.Size = new System.Drawing.Size(218, 20);
            this.txtOrderType.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(303, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Estado";
            // 
            // txtOrderState
            // 
            this.txtOrderState.Enabled = false;
            this.txtOrderState.Location = new System.Drawing.Point(472, 40);
            this.txtOrderState.Name = "txtOrderState";
            this.txtOrderState.ReadOnly = true;
            this.txtOrderState.Size = new System.Drawing.Size(124, 20);
            this.txtOrderState.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTechnicianContact);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtTechnicianName);
            this.groupBox2.Controls.Add(this.txtTechnicianTelephone);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(15, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(954, 53);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "A cargo de";
            // 
            // txtTechnicianContact
            // 
            this.txtTechnicianContact.Enabled = false;
            this.txtTechnicianContact.Location = new System.Drawing.Point(676, 20);
            this.txtTechnicianContact.Name = "txtTechnicianContact";
            this.txtTechnicianContact.ReadOnly = true;
            this.txtTechnicianContact.Size = new System.Drawing.Size(269, 20);
            this.txtTechnicianContact.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(618, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Contacto";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Técnico";
            // 
            // txtTechnicianName
            // 
            this.txtTechnicianName.Enabled = false;
            this.txtTechnicianName.Location = new System.Drawing.Point(63, 20);
            this.txtTechnicianName.Name = "txtTechnicianName";
            this.txtTechnicianName.ReadOnly = true;
            this.txtTechnicianName.Size = new System.Drawing.Size(214, 20);
            this.txtTechnicianName.TabIndex = 3;
            // 
            // txtTechnicianTelephone
            // 
            this.txtTechnicianTelephone.Enabled = false;
            this.txtTechnicianTelephone.Location = new System.Drawing.Point(372, 20);
            this.txtTechnicianTelephone.Name = "txtTechnicianTelephone";
            this.txtTechnicianTelephone.ReadOnly = true;
            this.txtTechnicianTelephone.Size = new System.Drawing.Size(226, 20);
            this.txtTechnicianTelephone.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(303, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Teléfono";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtArticleEsp);
            this.groupBox1.Controls.Add(this.lblEsp);
            this.groupBox1.Controls.Add(this.lblSerial);
            this.groupBox1.Controls.Add(this.txtArticleSerial);
            this.groupBox1.Controls.Add(this.txtArticleModel);
            this.groupBox1.Controls.Add(this.lblModel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtArticleCode);
            this.groupBox1.Controls.Add(this.txtArticleDescription);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(15, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 74);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Equipo";
            // 
            // txtReportClient
            // 
            this.txtReportClient.Location = new System.Drawing.Point(15, 242);
            this.txtReportClient.Multiline = true;
            this.txtReportClient.Name = "txtReportClient";
            this.txtReportClient.ReadOnly = true;
            this.txtReportClient.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReportClient.Size = new System.Drawing.Size(954, 88);
            this.txtReportClient.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Reporte del cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Código";
            // 
            // txtArticleCode
            // 
            this.txtArticleCode.Enabled = false;
            this.txtArticleCode.Location = new System.Drawing.Point(63, 19);
            this.txtArticleCode.Name = "txtArticleCode";
            this.txtArticleCode.ReadOnly = true;
            this.txtArticleCode.Size = new System.Drawing.Size(214, 20);
            this.txtArticleCode.TabIndex = 9;
            // 
            // txtArticleDescription
            // 
            this.txtArticleDescription.Enabled = false;
            this.txtArticleDescription.Location = new System.Drawing.Point(372, 19);
            this.txtArticleDescription.Name = "txtArticleDescription";
            this.txtArticleDescription.ReadOnly = true;
            this.txtArticleDescription.Size = new System.Drawing.Size(226, 20);
            this.txtArticleDescription.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Descripción";
            // 
            // txtArticleEsp
            // 
            this.txtArticleEsp.Enabled = false;
            this.txtArticleEsp.Location = new System.Drawing.Point(372, 44);
            this.txtArticleEsp.Name = "txtArticleEsp";
            this.txtArticleEsp.ReadOnly = true;
            this.txtArticleEsp.Size = new System.Drawing.Size(226, 20);
            this.txtArticleEsp.TabIndex = 29;
            // 
            // lblEsp
            // 
            this.lblEsp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEsp.AutoSize = true;
            this.lblEsp.Location = new System.Drawing.Point(290, 48);
            this.lblEsp.Name = "lblEsp";
            this.lblEsp.Size = new System.Drawing.Size(76, 13);
            this.lblEsp.TabIndex = 28;
            this.lblEsp.Text = "Especificación";
            // 
            // lblSerial
            // 
            this.lblSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(618, 44);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(33, 13);
            this.lblSerial.TabIndex = 26;
            this.lblSerial.Text = "Serial";
            // 
            // txtArticleSerial
            // 
            this.txtArticleSerial.Enabled = false;
            this.txtArticleSerial.Location = new System.Drawing.Point(676, 41);
            this.txtArticleSerial.Name = "txtArticleSerial";
            this.txtArticleSerial.ReadOnly = true;
            this.txtArticleSerial.Size = new System.Drawing.Size(268, 20);
            this.txtArticleSerial.TabIndex = 27;
            // 
            // txtArticleModel
            // 
            this.txtArticleModel.Enabled = false;
            this.txtArticleModel.Location = new System.Drawing.Point(63, 41);
            this.txtArticleModel.Name = "txtArticleModel";
            this.txtArticleModel.ReadOnly = true;
            this.txtArticleModel.Size = new System.Drawing.Size(214, 20);
            this.txtArticleModel.TabIndex = 25;
            // 
            // lblModel
            // 
            this.lblModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(8, 44);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(42, 13);
            this.lblModel.TabIndex = 24;
            this.lblModel.Text = "Modelo";
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(676, 19);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(268, 20);
            this.txtCategory.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(618, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Categoría";
            // 
            // FrmCotizationCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 723);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCotizationCreate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cotizar orden";
            this.Load += new System.EventHandler(this.FrmCotizationCreate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvServices)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRefactions)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtReportClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderState;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOrderType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTechnicianName;
        private System.Windows.Forms.TextBox txtTechnicianTelephone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtpReception_date;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTechnicianContact;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvRefactions;
        private System.Windows.Forms.TextBox txtServiceCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView DgvServices;
        private System.Windows.Forms.TextBox txtRefactionCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtComentarys;
        private System.Windows.Forms.NumericUpDown nupQuantity;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton IbtnAddService;
        private FontAwesome.Sharp.IconButton IbtnSearchService;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton IbtnAddRefaction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NupQR;
        private FontAwesome.Sharp.IconButton IbtnBack;
        private FontAwesome.Sharp.IconButton IbtnUpdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtArticleCode;
        private System.Windows.Forms.TextBox txtArticleDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtArticleEsp;
        private System.Windows.Forms.Label lblEsp;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.TextBox txtArticleSerial;
        private System.Windows.Forms.TextBox txtArticleModel;
        private System.Windows.Forms.Label lblModel;
    }
}