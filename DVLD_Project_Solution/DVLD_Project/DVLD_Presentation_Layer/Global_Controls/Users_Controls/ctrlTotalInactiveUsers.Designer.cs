namespace DVLD_Presentation_Layer.Global_Controls.Users_Controls
{
    partial class ctrlTotalInactiveUsers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.progbInActiveUserCount = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblPercetage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTotalInActiveUsersCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(25, 15);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(107, 23);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "InActive Users";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(28, 78);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(104, 15);
            this.guna2HtmlLabel2.TabIndex = 9;
            this.guna2HtmlLabel2.Text = "InActive users of total";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.Inactive_Users;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(186, 15);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(67, 63);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // progbInActiveUserCount
            // 
            this.progbInActiveUserCount.BorderRadius = 1;
            this.progbInActiveUserCount.BorderThickness = 1;
            this.progbInActiveUserCount.FillColor = System.Drawing.Color.Transparent;
            this.progbInActiveUserCount.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.progbInActiveUserCount.Location = new System.Drawing.Point(28, 101);
            this.progbInActiveUserCount.Name = "progbInActiveUserCount";
            this.progbInActiveUserCount.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.progbInActiveUserCount.ProgressColor2 = System.Drawing.Color.OrangeRed;
            this.progbInActiveUserCount.Size = new System.Drawing.Size(225, 5);
            this.progbInActiveUserCount.TabIndex = 8;
            this.progbInActiveUserCount.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblPercetage
            // 
            this.lblPercetage.BackColor = System.Drawing.Color.Transparent;
            this.lblPercetage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.lblPercetage.ForeColor = System.Drawing.Color.White;
            this.lblPercetage.Location = new System.Drawing.Point(186, 78);
            this.lblPercetage.Name = "lblPercetage";
            this.lblPercetage.Size = new System.Drawing.Size(44, 17);
            this.lblPercetage.TabIndex = 7;
            this.lblPercetage.Text = "InActive";
            // 
            // lblTotalInActiveUsersCount
            // 
            this.lblTotalInActiveUsersCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalInActiveUsersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTotalInActiveUsersCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTotalInActiveUsersCount.Location = new System.Drawing.Point(37, 41);
            this.lblTotalInActiveUsersCount.Name = "lblTotalInActiveUsersCount";
            this.lblTotalInActiveUsersCount.Size = new System.Drawing.Size(16, 31);
            this.lblTotalInActiveUsersCount.TabIndex = 3;
            this.lblTotalInActiveUsersCount.Text = "0";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox1.Controls.Add(this.lblTotalInActiveUsersCount);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GroupBox1.Controls.Add(this.lblPercetage);
            this.guna2GroupBox1.Controls.Add(this.guna2PictureBox1);
            this.guna2GroupBox1.Controls.Add(this.progbInActiveUserCount);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(282, 125);
            this.guna2GroupBox1.TabIndex = 14;
            // 
            // ctrlTotalInactiveUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "ctrlTotalInactiveUsers";
            this.Size = new System.Drawing.Size(282, 125);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ProgressBar progbInActiveUserCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPercetage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalInActiveUsersCount;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
    }
}
