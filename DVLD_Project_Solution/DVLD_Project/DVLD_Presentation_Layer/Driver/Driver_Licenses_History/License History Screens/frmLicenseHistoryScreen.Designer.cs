using System.Windows.Forms;

namespace DVLD_Presentation_Layer.LicenseHistory.License_History_Screens
{
    partial class frmLicenseHistoryScreen
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ctrlActualDateTime1 = new DVLD_Presentation_Layer.Global_Controls.ctrlActualDateTime();
            this.ctrlQuickDriverLicensesInfo1 = new DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls.ctrlQuickDriverLicensesInfo();
            this.ctrlInactiveDriverLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls.ctrlInactiveDriverLicenses();
            this.ctrlAciveDriverLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls.ctrlAciveDriverLicenses();
            this.ctrlExpiredDriverLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls.ctrlExpiredDriverLicenses();
            this.ctrlDriverLicenseSummary1 = new DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls.ctrlDriverLicenseSummary();
            this.ctrlTotalInternationalDriverLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Driver_Licences_Controls.ctrlTotalInternationalDriverLicenses();
            this.ctrlTotalLocalDriverLicenses1 = new DVLD_Presentation_Layer.Global_Controls.ctrlTotalLocalDriverLicenses();
            this.ctrlFilterPersonInformation1 = new DVLD_Presentation_Layer.Person.PersonControles.ctrlFilterPersonInformation();
            this.ctrlDriverLicenses1 = new DVLD_Presentation_Layer.DrivingLicense.Driving_License_User_Controls.ctrlDriverLicenses();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(49, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(249, 31);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "Driver Licenses History";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.cyber_security;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(31, 45);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 6;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationInterval = 0;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ctrlActualDateTime1
            // 
            this.ctrlActualDateTime1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlActualDateTime1.Location = new System.Drawing.Point(985, 4);
            this.ctrlActualDateTime1.Name = "ctrlActualDateTime1";
            this.ctrlActualDateTime1.Size = new System.Drawing.Size(212, 64);
            this.ctrlActualDateTime1.TabIndex = 81;
            // 
            // ctrlQuickDriverLicensesInfo1
            // 
            this.ctrlQuickDriverLicensesInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlQuickDriverLicensesInfo1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlQuickDriverLicensesInfo1.Location = new System.Drawing.Point(1203, 281);
            this.ctrlQuickDriverLicensesInfo1.Name = "ctrlQuickDriverLicensesInfo1";
            this.ctrlQuickDriverLicensesInfo1.Size = new System.Drawing.Size(153, 441);
            this.ctrlQuickDriverLicensesInfo1.TabIndex = 80;
            // 
            // ctrlInactiveDriverLicenses1
            // 
            this.ctrlInactiveDriverLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlInactiveDriverLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlInactiveDriverLicenses1.Location = new System.Drawing.Point(22, 190);
            this.ctrlInactiveDriverLicenses1.Name = "ctrlInactiveDriverLicenses1";
            this.ctrlInactiveDriverLicenses1.Size = new System.Drawing.Size(286, 124);
            this.ctrlInactiveDriverLicenses1.TabIndex = 79;
            // 
            // ctrlAciveDriverLicenses1
            // 
            this.ctrlAciveDriverLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlAciveDriverLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlAciveDriverLicenses1.Location = new System.Drawing.Point(22, 63);
            this.ctrlAciveDriverLicenses1.Name = "ctrlAciveDriverLicenses1";
            this.ctrlAciveDriverLicenses1.Size = new System.Drawing.Size(282, 129);
            this.ctrlAciveDriverLicenses1.TabIndex = 78;
            // 
            // ctrlExpiredDriverLicenses1
            // 
            this.ctrlExpiredDriverLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlExpiredDriverLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlExpiredDriverLicenses1.Location = new System.Drawing.Point(24, 446);
            this.ctrlExpiredDriverLicenses1.Name = "ctrlExpiredDriverLicenses1";
            this.ctrlExpiredDriverLicenses1.Size = new System.Drawing.Size(280, 125);
            this.ctrlExpiredDriverLicenses1.TabIndex = 77;
            // 
            // ctrlDriverLicenseSummary1
            // 
            this.ctrlDriverLicenseSummary1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDriverLicenseSummary1.CustomColor = System.Drawing.Color.Transparent;
            this.ctrlDriverLicenseSummary1.Location = new System.Drawing.Point(986, 74);
            this.ctrlDriverLicenseSummary1.Name = "ctrlDriverLicenseSummary1";
            this.ctrlDriverLicenseSummary1.Size = new System.Drawing.Size(364, 201);
            this.ctrlDriverLicenseSummary1.TabIndex = 76;
            // 
            // ctrlTotalInternationalDriverLicenses1
            // 
            this.ctrlTotalInternationalDriverLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalInternationalDriverLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalInternationalDriverLicenses1.Location = new System.Drawing.Point(22, 320);
            this.ctrlTotalInternationalDriverLicenses1.Name = "ctrlTotalInternationalDriverLicenses1";
            this.ctrlTotalInternationalDriverLicenses1.Size = new System.Drawing.Size(282, 129);
            this.ctrlTotalInternationalDriverLicenses1.TabIndex = 75;
            // 
            // ctrlTotalLocalDriverLicenses1
            // 
            this.ctrlTotalLocalDriverLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalLocalDriverLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalLocalDriverLicenses1.Location = new System.Drawing.Point(24, 577);
            this.ctrlTotalLocalDriverLicenses1.Name = "ctrlTotalLocalDriverLicenses1";
            this.ctrlTotalLocalDriverLicenses1.Size = new System.Drawing.Size(285, 128);
            this.ctrlTotalLocalDriverLicenses1.TabIndex = 74;
            // 
            // ctrlFilterPersonInformation1
            // 
            this.ctrlFilterPersonInformation1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlFilterPersonInformation1.EnableAddNewButton = true;
            this.ctrlFilterPersonInformation1.EnableFilter = true;
            this.ctrlFilterPersonInformation1.Location = new System.Drawing.Point(317, 12);
            this.ctrlFilterPersonInformation1.Name = "ctrlFilterPersonInformation1";
            this.ctrlFilterPersonInformation1.Size = new System.Drawing.Size(663, 263);
            this.ctrlFilterPersonInformation1.TabIndex = 4;
            this.ctrlFilterPersonInformation1.OnPersonSelectedByPersonID += new System.Action<int>(this.ctrlFilterPersonInformation1_OnPersonSelectedByPersonID);
            this.ctrlFilterPersonInformation1.OnPersonSelectedByNationalNo += new System.Action<string>(this.ctrlFilterPersonInformation1_OnPersonSelectedByNationalNo);
            this.ctrlFilterPersonInformation1.OnPersonSelectedNotFound += new System.Action(this.ctrlFilterPersonInformation1_OnPersonSelectedNotFound);
            // 
            // ctrlDriverLicenses1
            // 
            this.ctrlDriverLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDriverLicenses1.Location = new System.Drawing.Point(317, 281);
            this.ctrlDriverLicenses1.Name = "ctrlDriverLicenses1";
            this.ctrlDriverLicenses1.Size = new System.Drawing.Size(880, 424);
            this.ctrlDriverLicenses1.TabIndex = 3;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Blue;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(58, 40);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(184, 17);
            this.guna2HtmlLabel3.TabIndex = 82;
            this.guna2HtmlLabel3.Text = "View driver local and inter licenses";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 5;
            this.guna2ControlBox1.BorderThickness = 1;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1322, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 83;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderRadius = 5;
            this.btnMinimize.BorderThickness = 1;
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1219, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 85;
            // 
            // btnMaximaze
            // 
            this.btnMaximaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximaze.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderRadius = 5;
            this.btnMaximaze.BorderThickness = 1;
            this.btnMaximaze.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximaze.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMaximaze.IconColor = System.Drawing.Color.White;
            this.btnMaximaze.Location = new System.Drawing.Point(1271, 4);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 84;
            // 
            // frmLicenseHistoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1380, 788);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.ctrlActualDateTime1);
            this.Controls.Add(this.ctrlQuickDriverLicensesInfo1);
            this.Controls.Add(this.ctrlInactiveDriverLicenses1);
            this.Controls.Add(this.ctrlAciveDriverLicenses1);
            this.Controls.Add(this.ctrlExpiredDriverLicenses1);
            this.Controls.Add(this.ctrlDriverLicenseSummary1);
            this.Controls.Add(this.ctrlTotalInternationalDriverLicenses1);
            this.Controls.Add(this.ctrlTotalLocalDriverLicenses1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.ctrlFilterPersonInformation1);
            this.Controls.Add(this.ctrlDriverLicenses1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Rectangle(0, 0, 1366, 720).Location;
            this.Name = "frmLicenseHistoryScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LicenseHistoryScreen";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DrivingLicense.Driving_License_User_Controls.ctrlDriverLicenses ctrlDriverLicenses1;
        private Person.PersonControles.ctrlFilterPersonInformation ctrlFilterPersonInformation1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Global_Controls.ctrlTotalLocalDriverLicenses ctrlTotalLocalDriverLicenses1;
        private Global_Controls.Driver_Licences_Controls.ctrlExpiredDriverLicenses ctrlExpiredDriverLicenses1;
        private Global_Controls.Driver_Licences_Controls.ctrlDriverLicenseSummary ctrlDriverLicenseSummary1;
        private Global_Controls.Driver_Licences_Controls.ctrlTotalInternationalDriverLicenses ctrlTotalInternationalDriverLicenses1;
        private Global_Controls.Driver_Licences_Controls.ctrlQuickDriverLicensesInfo ctrlQuickDriverLicensesInfo1;
        private Global_Controls.Driver_Licences_Controls.ctrlInactiveDriverLicenses ctrlInactiveDriverLicenses1;
        private Global_Controls.Driver_Licences_Controls.ctrlAciveDriverLicenses ctrlAciveDriverLicenses1;
        private Global_Controls.ctrlActualDateTime ctrlActualDateTime1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
    }
}