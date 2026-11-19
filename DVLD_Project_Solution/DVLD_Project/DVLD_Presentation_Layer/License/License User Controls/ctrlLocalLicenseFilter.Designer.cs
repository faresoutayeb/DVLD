namespace DVLD_Presentation_Layer.License.License_User_Controls
{
    partial class ctrlLocalLicenseFilter
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
            this.components = new System.ComponentModel.Container();
            this.btnSearch = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtLicenseID = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilters = new Guna.UI2.WinForms.Guna2GroupBox();
            this.ctrlLicenseInfo1 = new DVLD_Presentation_Layer.License.License_User_Controls.ctrlLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Animated = true;
            this.btnSearch.AutoRoundedCorners = true;
            this.btnSearch.BorderColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderRadius = 12;
            this.btnSearch.BorderThickness = 1;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FillColor = System.Drawing.Color.Blue;
            this.btnSearch.FillColor2 = System.Drawing.Color.Aqua;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSearch.IndicateFocus = true;
            this.btnSearch.Location = new System.Drawing.Point(108, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 26);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseTransparentBackground = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Animated = true;
            this.txtLicenseID.BorderColor = System.Drawing.Color.Blue;
            this.txtLicenseID.BorderRadius = 10;
            this.txtLicenseID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLicenseID.DefaultText = "";
            this.txtLicenseID.DisabledState.BorderColor = System.Drawing.Color.Aqua;
            this.txtLicenseID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtLicenseID.DisabledState.ForeColor = System.Drawing.Color.White;
            this.txtLicenseID.DisabledState.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtLicenseID.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtLicenseID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLicenseID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtLicenseID.Location = new System.Drawing.Point(0, 0);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtLicenseID.PlaceholderText = "Type License ID";
            this.txtLicenseID.SelectedText = "";
            this.txtLicenseID.Size = new System.Drawing.Size(174, 40);
            this.txtLicenseID.TabIndex = 0;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbFilters
            // 
            this.gbFilters.BorderColor = System.Drawing.Color.Blue;
            this.gbFilters.BorderRadius = 10;
            this.gbFilters.BorderThickness = 0;
            this.gbFilters.Controls.Add(this.btnSearch);
            this.gbFilters.Controls.Add(this.txtLicenseID);
            this.gbFilters.CustomBorderColor = System.Drawing.Color.Blue;
            this.gbFilters.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.gbFilters.FillColor = System.Drawing.Color.Transparent;
            this.gbFilters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbFilters.Location = new System.Drawing.Point(3, 0);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(229, 48);
            this.gbFilters.TabIndex = 17;
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(0, 48);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(776, 273);
            this.ctrlLicenseInfo1.TabIndex = 14;
            this.ctrlLicenseInfo1.OnNoLicenseFound += new System.Action(this.ctrlLicenseInfo1_OnNoLicenseFound);
            // 
            // ctrlLocalLicenseFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "ctrlLocalLicenseFilter";
            this.Size = new System.Drawing.Size(768, 316);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public Guna.UI2.WinForms.Guna2TextBox txtLicenseID;
        public Guna.UI2.WinForms.Guna2GradientButton btnSearch;
        private Guna.UI2.WinForms.Guna2GroupBox gbFilters;
    }
}
