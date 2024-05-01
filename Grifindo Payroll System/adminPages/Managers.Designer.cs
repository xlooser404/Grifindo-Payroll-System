namespace Grifindo_Payroll_System.adminPages
{
    partial class Managers
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
            this.CommonPal = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.homePIC = new System.Windows.Forms.PictureBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.MngDGV = new System.Windows.Forms.DataGridView();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtContact = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSYSCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNic = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.closePIC = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.homePIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MngDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePIC)).BeginInit();
            this.SuspendLayout();
            // 
            // CommonPal
            // 
            this.CommonPal.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.CommonPal.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.CommonPal.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.CommonPal.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.CommonPal.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.CommonPal.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.CommonPal.FormStyles.FormMain.StateCommon.Border.Rounding = 15;
            this.CommonPal.FormStyles.FormMain.StateCommon.Border.Width = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(501, 608);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Back to Home";
            // 
            // homePIC
            // 
            this.homePIC.Image = global::Grifindo_Payroll_System.Properties.Resources.home;
            this.homePIC.Location = new System.Drawing.Point(527, 572);
            this.homePIC.Name = "homePIC";
            this.homePIC.Size = new System.Drawing.Size(34, 33);
            this.homePIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homePIC.TabIndex = 15;
            this.homePIC.TabStop = false;
            this.homePIC.Click += new System.EventHandler(this.homePIC_Click);
            // 
            // picSearch
            // 
            this.picSearch.Image = global::Grifindo_Payroll_System.Properties.Resources.loupe;
            this.picSearch.Location = new System.Drawing.Point(1030, 95);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(38, 37);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearch.TabIndex = 109;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(688, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 22);
            this.label10.TabIndex = 108;
            this.label10.Text = "Search Here";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(778, 97);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 35);
            this.txtSearch.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtSearch.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSearch.StateCommon.Border.Rounding = 20;
            this.txtSearch.StateCommon.Border.Width = 1;
            this.txtSearch.TabIndex = 107;
            this.txtSearch.Text = "type Nic";
            // 
            // MngDGV
            // 
            this.MngDGV.BackgroundColor = System.Drawing.Color.White;
            this.MngDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MngDGV.Location = new System.Drawing.Point(324, 138);
            this.MngDGV.Name = "MngDGV";
            this.MngDGV.Size = new System.Drawing.Size(765, 417);
            this.MngDGV.TabIndex = 106;
            this.MngDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MngDGV_CellClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(107, 496);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 33);
            this.btnDelete.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnDelete.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnDelete.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.btnDelete.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.btnDelete.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDelete.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDelete.StateCommon.Border.Rounding = 15;
            this.btnDelete.StateCommon.Border.Width = 1;
            this.btnDelete.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnDelete.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.SpringGreen;
            this.btnDelete.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.SpringGreen;
            this.btnDelete.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.StatePressed.Back.Color1 = System.Drawing.Color.Lime;
            this.btnDelete.StatePressed.Back.Color2 = System.Drawing.Color.Lime;
            this.btnDelete.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnDelete.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnDelete.StateTracking.Back.Color1 = System.Drawing.Color.Lime;
            this.btnDelete.StateTracking.Back.Color2 = System.Drawing.Color.Lime;
            this.btnDelete.StateTracking.Border.Color1 = System.Drawing.Color.Lime;
            this.btnDelete.StateTracking.Border.Color2 = System.Drawing.Color.Lime;
            this.btnDelete.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDelete.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnDelete.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnDelete.TabIndex = 105;
            this.btnDelete.Values.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(188, 442);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 33);
            this.btnEdit.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnEdit.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnEdit.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.btnEdit.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.btnEdit.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEdit.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnEdit.StateCommon.Border.Rounding = 15;
            this.btnEdit.StateCommon.Border.Width = 1;
            this.btnEdit.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnEdit.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.SpringGreen;
            this.btnEdit.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.SpringGreen;
            this.btnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.StatePressed.Back.Color1 = System.Drawing.Color.Lime;
            this.btnEdit.StatePressed.Back.Color2 = System.Drawing.Color.Lime;
            this.btnEdit.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEdit.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEdit.StateTracking.Back.Color1 = System.Drawing.Color.Lime;
            this.btnEdit.StateTracking.Back.Color2 = System.Drawing.Color.Lime;
            this.btnEdit.StateTracking.Border.Color1 = System.Drawing.Color.Lime;
            this.btnEdit.StateTracking.Border.Color2 = System.Drawing.Color.Lime;
            this.btnEdit.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEdit.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnEdit.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnEdit.TabIndex = 104;
            this.btnEdit.Values.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 33);
            this.btnSave.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.btnSave.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.btnSave.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.btnSave.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.btnSave.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSave.StateCommon.Border.Rounding = 15;
            this.btnSave.StateCommon.Border.Width = 1;
            this.btnSave.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSave.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.SpringGreen;
            this.btnSave.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.SpringGreen;
            this.btnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.StatePressed.Back.Color1 = System.Drawing.Color.Lime;
            this.btnSave.StatePressed.Back.Color2 = System.Drawing.Color.Lime;
            this.btnSave.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave.StateTracking.Back.Color1 = System.Drawing.Color.Lime;
            this.btnSave.StateTracking.Back.Color2 = System.Drawing.Color.Lime;
            this.btnSave.StateTracking.Border.Color1 = System.Drawing.Color.Lime;
            this.btnSave.StateTracking.Border.Color2 = System.Drawing.Color.Lime;
            this.btnSave.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSave.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnSave.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnSave.TabIndex = 103;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(45, 371);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(246, 35);
            this.txtContact.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtContact.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtContact.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtContact.StateCommon.Border.Rounding = 20;
            this.txtContact.StateCommon.Border.Width = 1;
            this.txtContact.TabIndex = 102;
            this.txtContact.Text = "Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 22);
            this.label5.TabIndex = 101;
            this.label5.Text = "Contact No";
            // 
            // txtSYSCode
            // 
            this.txtSYSCode.Location = new System.Drawing.Point(45, 306);
            this.txtSYSCode.Name = "txtSYSCode";
            this.txtSYSCode.Size = new System.Drawing.Size(246, 35);
            this.txtSYSCode.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtSYSCode.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtSYSCode.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSYSCode.StateCommon.Border.Rounding = 20;
            this.txtSYSCode.StateCommon.Border.Width = 1;
            this.txtSYSCode.TabIndex = 100;
            this.txtSYSCode.Text = "Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 22);
            this.label4.TabIndex = 99;
            this.label4.Text = "SYS Access Pass";
            // 
            // txtNic
            // 
            this.txtNic.Location = new System.Drawing.Point(45, 240);
            this.txtNic.Name = "txtNic";
            this.txtNic.Size = new System.Drawing.Size(246, 35);
            this.txtNic.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtNic.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtNic.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtNic.StateCommon.Border.Rounding = 20;
            this.txtNic.StateCommon.Border.Width = 1;
            this.txtNic.TabIndex = 98;
            this.txtNic.Text = "Nic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 97;
            this.label2.Text = "Manager Nic";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 169);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 35);
            this.txtName.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtName.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtName.StateCommon.Border.Rounding = 20;
            this.txtName.StateCommon.Border.Width = 1;
            this.txtName.TabIndex = 96;
            this.txtName.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 22);
            this.label9.TabIndex = 95;
            this.label9.Text = "Manager Name";
            // 
            // closePIC
            // 
            this.closePIC.Image = global::Grifindo_Payroll_System.Properties.Resources.close;
            this.closePIC.Location = new System.Drawing.Point(1085, 10);
            this.closePIC.Name = "closePIC";
            this.closePIC.Size = new System.Drawing.Size(36, 34);
            this.closePIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closePIC.TabIndex = 94;
            this.closePIC.TabStop = false;
            this.closePIC.Click += new System.EventHandler(this.closePIC_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(385, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(318, 37);
            this.label15.TabIndex = 93;
            this.label15.Text = "Grifindo Toys Payroll System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 34);
            this.label1.TabIndex = 92;
            this.label1.Text = "Manager Detail Form";
            // 
            // Managers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1129, 650);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.MngDGV);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSYSCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.closePIC);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.homePIC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Managers";
            this.Palette = this.CommonPal;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Managers";
            ((System.ComponentModel.ISupportInitialize)(this.homePIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MngDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette CommonPal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox homePIC;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.Label label10;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
        private System.Windows.Forms.DataGridView MngDGV;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtContact;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSYSCode;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNic;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox closePIC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
    }
}