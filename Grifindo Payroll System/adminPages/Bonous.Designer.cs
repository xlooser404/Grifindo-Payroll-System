namespace Grifindo_Payroll_System.adminPages
{
    partial class Bonous
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
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.closePIC = new System.Windows.Forms.PictureBox();
            this.txtName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetails = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.BonousDGV = new System.Windows.Forms.DataGridView();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.homePIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonousDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
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
            this.label3.Location = new System.Drawing.Point(505, 610);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Back to Home";
            // 
            // homePIC
            // 
            this.homePIC.Image = global::Grifindo_Payroll_System.Properties.Resources.home;
            this.homePIC.Location = new System.Drawing.Point(531, 574);
            this.homePIC.Name = "homePIC";
            this.homePIC.Size = new System.Drawing.Size(34, 33);
            this.homePIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homePIC.TabIndex = 13;
            this.homePIC.TabStop = false;
            this.homePIC.Click += new System.EventHandler(this.homePIC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 34);
            this.label1.TabIndex = 52;
            this.label1.Text = "Bonous Issue Form";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Poppins SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(384, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(318, 37);
            this.label15.TabIndex = 53;
            this.label15.Text = "Grifindo Toys Payroll System";
            // 
            // closePIC
            // 
            this.closePIC.Image = global::Grifindo_Payroll_System.Properties.Resources.close;
            this.closePIC.Location = new System.Drawing.Point(1084, 8);
            this.closePIC.Name = "closePIC";
            this.closePIC.Size = new System.Drawing.Size(36, 34);
            this.closePIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.closePIC.TabIndex = 54;
            this.closePIC.TabStop = false;
            this.closePIC.Click += new System.EventHandler(this.closePIC_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(44, 167);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 35);
            this.txtName.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtName.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtName.StateCommon.Border.Rounding = 20;
            this.txtName.StateCommon.Border.Width = 1;
            this.txtName.TabIndex = 56;
            this.txtName.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 22);
            this.label9.TabIndex = 55;
            this.label9.Text = "Bonous Name";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(44, 238);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(246, 35);
            this.txtCode.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtCode.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtCode.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtCode.StateCommon.Border.Rounding = 20;
            this.txtCode.StateCommon.Border.Width = 1;
            this.txtCode.TabIndex = 58;
            this.txtCode.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 57;
            this.label2.Text = "Bonous Code";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(44, 304);
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(246, 35);
            this.txtDetails.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtDetails.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtDetails.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDetails.StateCommon.Border.Rounding = 20;
            this.txtDetails.StateCommon.Border.Width = 1;
            this.txtDetails.TabIndex = 60;
            this.txtDetails.Text = "Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 59;
            this.label4.Text = "Bonous Details";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(44, 369);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(246, 35);
            this.txtAmount.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtAmount.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtAmount.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAmount.StateCommon.Border.Rounding = 20;
            this.txtAmount.StateCommon.Border.Width = 1;
            this.txtAmount.TabIndex = 62;
            this.txtAmount.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 61;
            this.label5.Text = "Bonous Amount";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 440);
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
            this.btnSave.TabIndex = 84;
            this.btnSave.Values.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(187, 440);
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
            this.btnEdit.TabIndex = 85;
            this.btnEdit.Values.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(106, 494);
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
            this.btnDelete.TabIndex = 86;
            this.btnDelete.Values.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // BonousDGV
            // 
            this.BonousDGV.BackgroundColor = System.Drawing.Color.White;
            this.BonousDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BonousDGV.Location = new System.Drawing.Point(323, 136);
            this.BonousDGV.Name = "BonousDGV";
            this.BonousDGV.Size = new System.Drawing.Size(765, 417);
            this.BonousDGV.TabIndex = 87;
            this.BonousDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BonousDGV_CellClick);
            // 
            // picSearch
            // 
            this.picSearch.Image = global::Grifindo_Payroll_System.Properties.Resources.loupe;
            this.picSearch.Location = new System.Drawing.Point(1029, 93);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(38, 37);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearch.TabIndex = 91;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(687, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 22);
            this.label10.TabIndex = 90;
            this.label10.Text = "Search Here";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(777, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 35);
            this.txtSearch.StateCommon.Border.Color1 = System.Drawing.Color.SpringGreen;
            this.txtSearch.StateCommon.Border.Color2 = System.Drawing.Color.SpringGreen;
            this.txtSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtSearch.StateCommon.Border.Rounding = 20;
            this.txtSearch.StateCommon.Border.Width = 1;
            this.txtSearch.TabIndex = 89;
            this.txtSearch.Text = "type Bonous Code";
            // 
            // Bonous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1129, 650);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.BonousDGV);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.closePIC);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.homePIC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bonous";
            this.Palette = this.CommonPal;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toys";
            ((System.ComponentModel.ISupportInitialize)(this.homePIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonousDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette CommonPal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox homePIC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox closePIC;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtName;
        private System.Windows.Forms.Label label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCode;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDetails;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
        private System.Windows.Forms.DataGridView BonousDGV;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.Label label10;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
    }
}