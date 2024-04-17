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
            ((System.ComponentModel.ISupportInitialize)(this.homePIC)).BeginInit();
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
            // 
            // Managers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1129, 650);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.homePIC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Managers";
            this.Palette = this.CommonPal;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Managers";
            ((System.ComponentModel.ISupportInitialize)(this.homePIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette CommonPal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox homePIC;
    }
}