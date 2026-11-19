using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Detained_License.Detained_License_Screens
{
    partial class frmDetainLicense
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
            this.button2 = new System.Windows.Forms.Button();
            this.cbDetainReasons = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel13 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel12 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtFineFees = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCreatedByUser = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLicenseID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDetainDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDetainID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnShowLicenseHistory = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnShowLicenseInfo = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel14 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ctrlOrdinaryLicenseFilter1 = new DVLD_Presentation_Layer.License.License_User_Controls.ctrlLocalLicenseFilter();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.ctrlTotalDetainedLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedLicenses();
            this.ctrlTotalDetainedFees1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedFees();
            this.ctrlTotalCurrentlyDetainedLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalCurrentlyDetainedLicenses();
            this.ctrlDetainReasons_Top5_1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlDetainReasons_Top5_();
            this.ctrlTotalReleasedLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalReleasedLicenses();
            this.ctrlActualDateTime1 = new DVLD_Presentation_Layer.Global_Controls.ctrlActualDateTime();
            this.ctrlNewDetentionsThisMonth1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsThisMonth();
            this.ctrlNewDetentionsLast30Days1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsLast30Days();
            this.guna2ControlBox4 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox5 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox6 = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button2.Location = new System.Drawing.Point(994, -70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 40);
            this.button2.TabIndex = 11;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // cbDetainReasons
            // 
            this.cbDetainReasons.AutoRoundedCorners = true;
            this.cbDetainReasons.BackColor = System.Drawing.Color.Transparent;
            this.cbDetainReasons.BorderColor = System.Drawing.Color.Blue;
            this.cbDetainReasons.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDetainReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDetainReasons.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbDetainReasons.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDetainReasons.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbDetainReasons.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbDetainReasons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbDetainReasons.ItemHeight = 30;
            this.cbDetainReasons.Location = new System.Drawing.Point(151, 135);
            this.cbDetainReasons.Name = "cbDetainReasons";
            this.cbDetainReasons.Size = new System.Drawing.Size(578, 36);
            this.cbDetainReasons.TabIndex = 21;
            // 
            // guna2HtmlLabel13
            // 
            this.guna2HtmlLabel13.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel13.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel13.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel13.Location = new System.Drawing.Point(137, 137);
            this.guna2HtmlLabel13.Name = "guna2HtmlLabel13";
            this.guna2HtmlLabel13.Size = new System.Drawing.Size(7, 23);
            this.guna2HtmlLabel13.TabIndex = 20;
            this.guna2HtmlLabel13.Text = ":";
            // 
            // guna2HtmlLabel12
            // 
            this.guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel12.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel12.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel12.Location = new System.Drawing.Point(137, 85);
            this.guna2HtmlLabel12.Name = "guna2HtmlLabel12";
            this.guna2HtmlLabel12.Size = new System.Drawing.Size(7, 23);
            this.guna2HtmlLabel12.TabIndex = 19;
            this.guna2HtmlLabel12.Text = ":";
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(24, 137);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(93, 21);
            this.guna2HtmlLabel9.TabIndex = 17;
            this.guna2HtmlLabel9.Text = "Detain Reason";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Animated = true;
            this.txtFineFees.BackColor = System.Drawing.Color.Transparent;
            this.txtFineFees.BorderColor = System.Drawing.Color.Blue;
            this.txtFineFees.BorderRadius = 15;
            this.txtFineFees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFineFees.DefaultText = "";
            this.txtFineFees.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFineFees.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFineFees.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFineFees.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFineFees.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtFineFees.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFineFees.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFineFees.ForeColor = System.Drawing.Color.White;
            this.txtFineFees.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFineFees.Location = new System.Drawing.Point(151, 83);
            this.txtFineFees.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.PlaceholderText = "type detain fees...";
            this.txtFineFees.SelectedText = "";
            this.txtFineFees.Size = new System.Drawing.Size(220, 45);
            this.txtFineFees.TabIndex = 16;
            this.txtFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtFineFees_Validating);
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblCreatedByUser.ForeColor = System.Drawing.Color.White;
            this.lblCreatedByUser.Location = new System.Drawing.Point(549, 82);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(27, 21);
            this.lblCreatedByUser.TabIndex = 15;
            this.lblCreatedByUser.Text = "????";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenseID.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblLicenseID.ForeColor = System.Drawing.Color.White;
            this.lblLicenseID.Location = new System.Drawing.Point(318, 48);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(27, 21);
            this.lblLicenseID.TabIndex = 14;
            this.lblLicenseID.Text = "????";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDetainDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDetainDate.ForeColor = System.Drawing.Color.White;
            this.lblDetainDate.Location = new System.Drawing.Point(549, 45);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(63, 21);
            this.lblDetainDate.TabIndex = 12;
            this.lblDetainDate.Text = "??/??/????";
            // 
            // lblDetainID
            // 
            this.lblDetainID.BackColor = System.Drawing.Color.Transparent;
            this.lblDetainID.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblDetainID.ForeColor = System.Drawing.Color.White;
            this.lblDetainID.Location = new System.Drawing.Point(113, 47);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(27, 21);
            this.lblDetainID.TabIndex = 11;
            this.lblDetainID.Text = "????";
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel11.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(527, 81);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(7, 23);
            this.guna2HtmlLabel11.TabIndex = 10;
            this.guna2HtmlLabel11.Text = ":";
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel10.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(305, 48);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(7, 23);
            this.guna2HtmlLabel10.TabIndex = 9;
            this.guna2HtmlLabel10.Text = ":";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(527, 46);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(7, 23);
            this.guna2HtmlLabel8.TabIndex = 7;
            this.guna2HtmlLabel8.Text = ":";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI Semibold", 12.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(100, 47);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(7, 23);
            this.guna2HtmlLabel7.TabIndex = 6;
            this.guna2HtmlLabel7.Text = ":";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(24, 85);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(60, 21);
            this.guna2HtmlLabel6.TabIndex = 5;
            this.guna2HtmlLabel6.Text = "Fine Fees";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(430, 84);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(70, 21);
            this.guna2HtmlLabel4.TabIndex = 4;
            this.guna2HtmlLabel4.Text = "Created By";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(222, 48);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(67, 21);
            this.guna2HtmlLabel5.TabIndex = 3;
            this.guna2HtmlLabel5.Text = "License ID";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(430, 45);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(77, 21);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Detain Date";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(24, 45);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(62, 21);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Detain ID";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(24, 13);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(167, 22);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Detained Licenses Info";
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Animated = true;
            this.btnDetainLicense.AnimatedGIF = true;
            this.btnDetainLicense.AutoRoundedCorners = true;
            this.btnDetainLicense.BackColor = System.Drawing.Color.Transparent;
            this.btnDetainLicense.BorderColor = System.Drawing.Color.Blue;
            this.btnDetainLicense.BorderRadius = 25;
            this.btnDetainLicense.BorderThickness = 1;
            this.btnDetainLicense.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.btnDetainLicense.DisabledState.CustomBorderColor = System.Drawing.Color.Blue;
            this.btnDetainLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDetainLicense.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDetainLicense.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.Enabled = false;
            this.btnDetainLicense.FillColor = System.Drawing.Color.Blue;
            this.btnDetainLicense.FillColor2 = System.Drawing.Color.Cyan;
            this.btnDetainLicense.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDetainLicense.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnDetainLicense.Location = new System.Drawing.Point(851, 647);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.PressedColor = System.Drawing.Color.Aqua;
            this.btnDetainLicense.Size = new System.Drawing.Size(206, 52);
            this.btnDetainLicense.TabIndex = 17;
            this.btnDetainLicense.Text = "Detain License";
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnShowLicenseHistory
            // 
            this.btnShowLicenseHistory.Animated = true;
            this.btnShowLicenseHistory.AnimatedGIF = true;
            this.btnShowLicenseHistory.AutoRoundedCorners = true;
            this.btnShowLicenseHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnShowLicenseHistory.BorderColor = System.Drawing.Color.Blue;
            this.btnShowLicenseHistory.BorderRadius = 23;
            this.btnShowLicenseHistory.BorderThickness = 1;
            this.btnShowLicenseHistory.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.btnShowLicenseHistory.DisabledState.CustomBorderColor = System.Drawing.Color.Blue;
            this.btnShowLicenseHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnShowLicenseHistory.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnShowLicenseHistory.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnShowLicenseHistory.Enabled = false;
            this.btnShowLicenseHistory.FillColor = System.Drawing.Color.Transparent;
            this.btnShowLicenseHistory.FillColor2 = System.Drawing.Color.Transparent;
            this.btnShowLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowLicenseHistory.ForeColor = System.Drawing.Color.White;
            this.btnShowLicenseHistory.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnShowLicenseHistory.Location = new System.Drawing.Point(1086, 647);
            this.btnShowLicenseHistory.Name = "btnShowLicenseHistory";
            this.btnShowLicenseHistory.PressedColor = System.Drawing.Color.Aqua;
            this.btnShowLicenseHistory.Size = new System.Drawing.Size(204, 49);
            this.btnShowLicenseHistory.TabIndex = 18;
            this.btnShowLicenseHistory.Text = "Show License History";
            this.btnShowLicenseHistory.Click += new System.EventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnShowLicenseInfo
            // 
            this.btnShowLicenseInfo.Animated = true;
            this.btnShowLicenseInfo.AnimatedGIF = true;
            this.btnShowLicenseInfo.AutoRoundedCorners = true;
            this.btnShowLicenseInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnShowLicenseInfo.BorderColor = System.Drawing.Color.Blue;
            this.btnShowLicenseInfo.BorderRadius = 23;
            this.btnShowLicenseInfo.BorderThickness = 1;
            this.btnShowLicenseInfo.DisabledState.BorderColor = System.Drawing.Color.Blue;
            this.btnShowLicenseInfo.DisabledState.CustomBorderColor = System.Drawing.Color.Blue;
            this.btnShowLicenseInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnShowLicenseInfo.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnShowLicenseInfo.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnShowLicenseInfo.Enabled = false;
            this.btnShowLicenseInfo.FillColor = System.Drawing.Color.Transparent;
            this.btnShowLicenseInfo.FillColor2 = System.Drawing.Color.Transparent;
            this.btnShowLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowLicenseInfo.ForeColor = System.Drawing.Color.White;
            this.btnShowLicenseInfo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnShowLicenseInfo.Location = new System.Drawing.Point(613, 650);
            this.btnShowLicenseInfo.Name = "btnShowLicenseInfo";
            this.btnShowLicenseInfo.PressedColor = System.Drawing.Color.Aqua;
            this.btnShowLicenseInfo.Size = new System.Drawing.Size(204, 49);
            this.btnShowLicenseInfo.TabIndex = 19;
            this.btnShowLicenseInfo.Text = "Show License Info";
            this.btnShowLicenseInfo.Click += new System.EventHandler(this.btnShowLicenseInfo_Click);
            // 
            // guna2HtmlLabel14
            // 
            this.guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.guna2HtmlLabel14.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel14.Location = new System.Drawing.Point(64, 12);
            this.guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            this.guna2HtmlLabel14.Size = new System.Drawing.Size(243, 31);
            this.guna2HtmlLabel14.TabIndex = 20;
            this.guna2HtmlLabel14.Text = "Detain Driving License";
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblUserMessage.Location = new System.Drawing.Point(80, 39);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(123, 22);
            this.lblUserMessage.TabIndex = 22;
            this.lblUserMessage.Text = "Detain License";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationInterval = 0;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm1.BorderRadius = 30;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.software_license1;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(46, 31);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 21;
            this.guna2PictureBox1.TabStop = false;
            // 
            // ctrlOrdinaryLicenseFilter1
            // 
            this.ctrlOrdinaryLicenseFilter1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlOrdinaryLicenseFilter1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlOrdinaryLicenseFilter1.FilterEnabled = true;
            this.ctrlOrdinaryLicenseFilter1.Location = new System.Drawing.Point(589, 84);
            this.ctrlOrdinaryLicenseFilter1.Name = "ctrlOrdinaryLicenseFilter1";
            this.ctrlOrdinaryLicenseFilter1.Size = new System.Drawing.Size(776, 323);
            this.ctrlOrdinaryLicenseFilter1.TabIndex = 1;
            this.ctrlOrdinaryLicenseFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected);
            this.ctrlOrdinaryLicenseFilter1.OnControlsNotValidated += new System.Action(this.ctrlOrdinaryLicenseFilter1_OnControlsNotValidated);
            this.ctrlOrdinaryLicenseFilter1.OnNoLicenseFounded += new System.Action(this.ctrlOrdinaryLicenseFilter1_OnNoLicenseFounded);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox1.BorderRadius = 20;
            this.guna2GroupBox1.Controls.Add(this.lblCreatedByUser);
            this.guna2GroupBox1.Controls.Add(this.cbDetainReasons);
            this.guna2GroupBox1.Controls.Add(this.lblDetainDate);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel11);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel8);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel13);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel12);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel9);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel5);
            this.guna2GroupBox1.Controls.Add(this.txtFineFees);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel4);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel6);
            this.guna2GroupBox1.Controls.Add(this.lblLicenseID);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel7);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel10);
            this.guna2GroupBox1.Controls.Add(this.lblDetainID);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(589, 430);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(765, 186);
            this.guna2GroupBox1.TabIndex = 75;
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // ctrlTotalDetainedLicenses1
            // 
            this.ctrlTotalDetainedLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalDetainedLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalDetainedLicenses1.Location = new System.Drawing.Point(12, 84);
            this.ctrlTotalDetainedLicenses1.Name = "ctrlTotalDetainedLicenses1";
            this.ctrlTotalDetainedLicenses1.Size = new System.Drawing.Size(288, 126);
            this.ctrlTotalDetainedLicenses1.TabIndex = 76;
            // 
            // ctrlTotalDetainedFees1
            // 
            this.ctrlTotalDetainedFees1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalDetainedFees1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalDetainedFees1.Location = new System.Drawing.Point(12, 216);
            this.ctrlTotalDetainedFees1.Name = "ctrlTotalDetainedFees1";
            this.ctrlTotalDetainedFees1.Size = new System.Drawing.Size(288, 130);
            this.ctrlTotalDetainedFees1.TabIndex = 77;
            // 
            // ctrlTotalCurrentlyDetainedLicenses1
            // 
            this.ctrlTotalCurrentlyDetainedLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalCurrentlyDetainedLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalCurrentlyDetainedLicenses1.Location = new System.Drawing.Point(299, 81);
            this.ctrlTotalCurrentlyDetainedLicenses1.Name = "ctrlTotalCurrentlyDetainedLicenses1";
            this.ctrlTotalCurrentlyDetainedLicenses1.Size = new System.Drawing.Size(288, 129);
            this.ctrlTotalCurrentlyDetainedLicenses1.TabIndex = 78;
            // 
            // ctrlDetainReasons_Top5_1
            // 
            this.ctrlDetainReasons_Top5_1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDetainReasons_Top5_1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlDetainReasons_Top5_1.Location = new System.Drawing.Point(27, 484);
            this.ctrlDetainReasons_Top5_1.Name = "ctrlDetainReasons_Top5_1";
            this.ctrlDetainReasons_Top5_1.Size = new System.Drawing.Size(550, 253);
            this.ctrlDetainReasons_Top5_1.TabIndex = 79;
            // 
            // ctrlTotalReleasedLicenses1
            // 
            this.ctrlTotalReleasedLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalReleasedLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalReleasedLicenses1.Location = new System.Drawing.Point(12, 350);
            this.ctrlTotalReleasedLicenses1.Name = "ctrlTotalReleasedLicenses1";
            this.ctrlTotalReleasedLicenses1.Size = new System.Drawing.Size(286, 128);
            this.ctrlTotalReleasedLicenses1.TabIndex = 81;
            // 
            // ctrlActualDateTime1
            // 
            this.ctrlActualDateTime1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlActualDateTime1.Location = new System.Drawing.Point(993, 12);
            this.ctrlActualDateTime1.Name = "ctrlActualDateTime1";
            this.ctrlActualDateTime1.Size = new System.Drawing.Size(202, 49);
            this.ctrlActualDateTime1.TabIndex = 82;
            // 
            // ctrlNewDetentionsThisMonth1
            // 
            this.ctrlNewDetentionsThisMonth1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlNewDetentionsThisMonth1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlNewDetentionsThisMonth1.Location = new System.Drawing.Point(304, 350);
            this.ctrlNewDetentionsThisMonth1.Name = "ctrlNewDetentionsThisMonth1";
            this.ctrlNewDetentionsThisMonth1.Size = new System.Drawing.Size(283, 125);
            this.ctrlNewDetentionsThisMonth1.TabIndex = 84;
            // 
            // ctrlNewDetentionsLast30Days1
            // 
            this.ctrlNewDetentionsLast30Days1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlNewDetentionsLast30Days1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlNewDetentionsLast30Days1.Location = new System.Drawing.Point(299, 216);
            this.ctrlNewDetentionsLast30Days1.Name = "ctrlNewDetentionsLast30Days1";
            this.ctrlNewDetentionsLast30Days1.Size = new System.Drawing.Size(288, 129);
            this.ctrlNewDetentionsLast30Days1.TabIndex = 83;
            // 
            // guna2ControlBox4
            // 
            this.guna2ControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.BorderRadius = 5;
            this.guna2ControlBox4.BorderThickness = 1;
            this.guna2ControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox4.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox4.Location = new System.Drawing.Point(1328, 2);
            this.guna2ControlBox4.Name = "guna2ControlBox4";
            this.guna2ControlBox4.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox4.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox4.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox4.TabIndex = 97;
            // 
            // guna2ControlBox5
            // 
            this.guna2ControlBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.BorderRadius = 5;
            this.guna2ControlBox5.BorderThickness = 1;
            this.guna2ControlBox5.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox5.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox5.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox5.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox5.Location = new System.Drawing.Point(1225, 2);
            this.guna2ControlBox5.Name = "guna2ControlBox5";
            this.guna2ControlBox5.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox5.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox5.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox5.TabIndex = 99;
            // 
            // guna2ControlBox6
            // 
            this.guna2ControlBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox6.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox6.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox6.BorderRadius = 5;
            this.guna2ControlBox6.BorderThickness = 1;
            this.guna2ControlBox6.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox6.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox6.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox6.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox6.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox6.Location = new System.Drawing.Point(1277, 2);
            this.guna2ControlBox6.Name = "guna2ControlBox6";
            this.guna2ControlBox6.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox6.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox6.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox6.TabIndex = 98;
            // 
            // frmDetainLicenseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.guna2ControlBox4);
            this.Controls.Add(this.guna2ControlBox5);
            this.Controls.Add(this.guna2ControlBox6);
            this.Controls.Add(this.ctrlNewDetentionsThisMonth1);
            this.Controls.Add(this.ctrlNewDetentionsLast30Days1);
            this.Controls.Add(this.ctrlActualDateTime1);
            this.Controls.Add(this.ctrlTotalReleasedLicenses1);
            this.Controls.Add(this.ctrlDetainReasons_Top5_1);
            this.Controls.Add(this.ctrlTotalCurrentlyDetainedLicenses1);
            this.Controls.Add(this.ctrlTotalDetainedFees1);
            this.Controls.Add(this.ctrlTotalDetainedLicenses1);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2HtmlLabel14);
            this.Controls.Add(this.btnShowLicenseInfo);
            this.Controls.Add(this.btnShowLicenseHistory);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ctrlOrdinaryLicenseFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDetainLicenseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "DetainLicenseScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDetainLicenseScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private License.License_User_Controls.ctrlLocalLicenseFilter ctrlOrdinaryLicenseFilter1;
        private System.Windows.Forms.Button button2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCreatedByUser;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLicenseID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDetainDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDetainID;
        private Guna.UI2.WinForms.Guna2TextBox txtFineFees;
        private Guna.UI2.WinForms.Guna2GradientButton btnDetainLicense;
        private Guna.UI2.WinForms.Guna2GradientButton btnShowLicenseHistory;
        private Guna.UI2.WinForms.Guna2GradientButton btnShowLicenseInfo;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel14;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserMessage;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel12;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel13;
        private Guna.UI2.WinForms.Guna2ComboBox cbDetainReasons;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedLicenses ctrlTotalDetainedLicenses1;
        private Global_Controls.Detain_Licenses_Controls.ctrlDetainReasons_Top5_ ctrlDetainReasons_Top5_1;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalCurrentlyDetainedLicenses ctrlTotalCurrentlyDetainedLicenses1;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedFees ctrlTotalDetainedFees1;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalReleasedLicenses ctrlTotalReleasedLicenses1;
        private Global_Controls.ctrlActualDateTime ctrlActualDateTime1;
        private Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsThisMonth ctrlNewDetentionsThisMonth1;
        private Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsLast30Days ctrlNewDetentionsLast30Days1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox5;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox6;
    }
}