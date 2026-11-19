using GlobalCustomControls;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens
{
    partial class frmAddEditUserPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUserPermissions));
            this.chkManagePeople = new System.Windows.Forms.CheckBox();
            this.chkAddEditPerson = new System.Windows.Forms.CheckBox();
            this.chkDeletePerson = new System.Windows.Forms.CheckBox();
            this.chkManageUsers = new System.Windows.Forms.CheckBox();
            this.chkAddEditUser = new System.Windows.Forms.CheckBox();
            this.chkEditUserPassword = new System.Windows.Forms.CheckBox();
            this.chkDeleteUser = new System.Windows.Forms.CheckBox();
            this.chkViewApplications = new System.Windows.Forms.CheckBox();
            this.chkManageNewLocalDrivingLicenseApplications = new System.Windows.Forms.CheckBox();
            this.chkEditApplicationType = new System.Windows.Forms.CheckBox();
            this.chkEditApplicationTestType = new System.Windows.Forms.CheckBox();
            this.chkDeleteApplication = new System.Windows.Forms.CheckBox();
            this.chkCancellApplication = new System.Windows.Forms.CheckBox();
            this.chkManageLocalLicenses = new System.Windows.Forms.CheckBox();
            this.chkManageLocalDrivingLicensesScreen = new System.Windows.Forms.CheckBox();
            this.chkIssueFirstLicense = new System.Windows.Forms.CheckBox();
            this.chkRenewLicense = new System.Windows.Forms.CheckBox();
            this.chkReplaceDamagedOrLostLicense = new System.Windows.Forms.CheckBox();
            this.chkViewLocalLicense = new System.Windows.Forms.CheckBox();
            this.chkViewLicenseHistory = new System.Windows.Forms.CheckBox();
            this.chkManageInternationalLicenses = new System.Windows.Forms.CheckBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tcAddEditUserPermissions = new GlobalCustomControls.RoundedTabControl();
            this.tbUserPermissions = new System.Windows.Forms.TabPage();
            this.ctrlUserPermissionsCard1 = new DVLD_Presentation_Layer.Users.Manage_Users_Permissions.User_Permissions_User_Controls.ctrlUserPermissionsCard();
            this.tbAddEditPermissions = new System.Windows.Forms.TabPage();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chkViewDetainedLicenses = new System.Windows.Forms.CheckBox();
            this.chkReleaseLicense = new System.Windows.Forms.CheckBox();
            this.chkIssueInternationalLicense = new System.Windows.Forms.CheckBox();
            this.chkViewInternationalLicense = new System.Windows.Forms.CheckBox();
            this.chkManageTestAppointments = new System.Windows.Forms.CheckBox();
            this.chkScheduleTest = new System.Windows.Forms.CheckBox();
            this.chkTakeTest = new System.Windows.Forms.CheckBox();
            this.chkManageDetainLicenseScreen = new System.Windows.Forms.CheckBox();
            this.chkDetainLicense = new System.Windows.Forms.CheckBox();
            this.chkManageApplicationTypes = new System.Windows.Forms.CheckBox();
            this.chkManageTestTypes = new System.Windows.Forms.CheckBox();
            this.chkViewDrivers = new System.Windows.Forms.CheckBox();
            this.ctrlFindUserFilter2 = new DVLD_Presentation_Layer.Users.User_Controles.ctrlFindUserFilter();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrlFindUserFilter1 = new DVLD_Presentation_Layer.Users.User_Controles.ctrlFindUserFilter();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcAddEditUserPermissions.SuspendLayout();
            this.tbUserPermissions.SuspendLayout();
            this.tbAddEditPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkManagePeople
            // 
            this.chkManagePeople.AutoSize = true;
            this.chkManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManagePeople.ForeColor = System.Drawing.Color.White;
            this.chkManagePeople.Location = new System.Drawing.Point(45, 70);
            this.chkManagePeople.Name = "chkManagePeople";
            this.chkManagePeople.Size = new System.Drawing.Size(126, 21);
            this.chkManagePeople.TabIndex = 0;
            this.chkManagePeople.Text = "Manage People";
            this.chkManagePeople.UseVisualStyleBackColor = true;
            // 
            // chkAddEditPerson
            // 
            this.chkAddEditPerson.AutoSize = true;
            this.chkAddEditPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkAddEditPerson.ForeColor = System.Drawing.Color.White;
            this.chkAddEditPerson.Location = new System.Drawing.Point(45, 104);
            this.chkAddEditPerson.Name = "chkAddEditPerson";
            this.chkAddEditPerson.Size = new System.Drawing.Size(137, 21);
            this.chkAddEditPerson.TabIndex = 1;
            this.chkAddEditPerson.Text = "Add / Edit Person";
            this.chkAddEditPerson.UseVisualStyleBackColor = true;
            // 
            // chkDeletePerson
            // 
            this.chkDeletePerson.AutoSize = true;
            this.chkDeletePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkDeletePerson.ForeColor = System.Drawing.Color.White;
            this.chkDeletePerson.Location = new System.Drawing.Point(45, 138);
            this.chkDeletePerson.Name = "chkDeletePerson";
            this.chkDeletePerson.Size = new System.Drawing.Size(117, 21);
            this.chkDeletePerson.TabIndex = 2;
            this.chkDeletePerson.Text = "Delete Person";
            this.chkDeletePerson.UseVisualStyleBackColor = true;
            // 
            // chkManageUsers
            // 
            this.chkManageUsers.AutoSize = true;
            this.chkManageUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageUsers.ForeColor = System.Drawing.Color.White;
            this.chkManageUsers.Location = new System.Drawing.Point(45, 234);
            this.chkManageUsers.Name = "chkManageUsers";
            this.chkManageUsers.Size = new System.Drawing.Size(119, 21);
            this.chkManageUsers.TabIndex = 3;
            this.chkManageUsers.Text = "Manage Users";
            this.chkManageUsers.UseVisualStyleBackColor = true;
            // 
            // chkAddEditUser
            // 
            this.chkAddEditUser.AutoSize = true;
            this.chkAddEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkAddEditUser.ForeColor = System.Drawing.Color.White;
            this.chkAddEditUser.Location = new System.Drawing.Point(45, 302);
            this.chkAddEditUser.Name = "chkAddEditUser";
            this.chkAddEditUser.Size = new System.Drawing.Size(122, 21);
            this.chkAddEditUser.TabIndex = 4;
            this.chkAddEditUser.Text = "Add / Edit User";
            this.chkAddEditUser.UseVisualStyleBackColor = true;
            // 
            // chkEditUserPassword
            // 
            this.chkEditUserPassword.AutoSize = true;
            this.chkEditUserPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEditUserPassword.ForeColor = System.Drawing.Color.White;
            this.chkEditUserPassword.Location = new System.Drawing.Point(45, 338);
            this.chkEditUserPassword.Name = "chkEditUserPassword";
            this.chkEditUserPassword.Size = new System.Drawing.Size(150, 21);
            this.chkEditUserPassword.TabIndex = 5;
            this.chkEditUserPassword.Text = "Edit User Password";
            this.chkEditUserPassword.UseVisualStyleBackColor = true;
            // 
            // chkDeleteUser
            // 
            this.chkDeleteUser.AutoSize = true;
            this.chkDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkDeleteUser.ForeColor = System.Drawing.Color.White;
            this.chkDeleteUser.Location = new System.Drawing.Point(45, 268);
            this.chkDeleteUser.Name = "chkDeleteUser";
            this.chkDeleteUser.Size = new System.Drawing.Size(102, 21);
            this.chkDeleteUser.TabIndex = 6;
            this.chkDeleteUser.Text = "Delete User";
            this.chkDeleteUser.UseVisualStyleBackColor = true;
            // 
            // chkViewApplications
            // 
            this.chkViewApplications.AutoSize = true;
            this.chkViewApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkViewApplications.ForeColor = System.Drawing.Color.White;
            this.chkViewApplications.Location = new System.Drawing.Point(276, 70);
            this.chkViewApplications.Name = "chkViewApplications";
            this.chkViewApplications.Size = new System.Drawing.Size(136, 21);
            this.chkViewApplications.TabIndex = 7;
            this.chkViewApplications.Text = "View Applications";
            this.chkViewApplications.UseVisualStyleBackColor = true;
            // 
            // chkManageNewLocalDrivingLicenseApplications
            // 
            this.chkManageNewLocalDrivingLicenseApplications.AutoSize = true;
            this.chkManageNewLocalDrivingLicenseApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageNewLocalDrivingLicenseApplications.ForeColor = System.Drawing.Color.White;
            this.chkManageNewLocalDrivingLicenseApplications.Location = new System.Drawing.Point(276, 175);
            this.chkManageNewLocalDrivingLicenseApplications.Name = "chkManageNewLocalDrivingLicenseApplications";
            this.chkManageNewLocalDrivingLicenseApplications.Size = new System.Drawing.Size(328, 21);
            this.chkManageNewLocalDrivingLicenseApplications.TabIndex = 8;
            this.chkManageNewLocalDrivingLicenseApplications.Text = "Manage New Local Driving License Applications";
            this.chkManageNewLocalDrivingLicenseApplications.UseVisualStyleBackColor = true;
            // 
            // chkEditApplicationType
            // 
            this.chkEditApplicationType.AutoSize = true;
            this.chkEditApplicationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEditApplicationType.ForeColor = System.Drawing.Color.White;
            this.chkEditApplicationType.Location = new System.Drawing.Point(276, 373);
            this.chkEditApplicationType.Name = "chkEditApplicationType";
            this.chkEditApplicationType.Size = new System.Drawing.Size(160, 21);
            this.chkEditApplicationType.TabIndex = 9;
            this.chkEditApplicationType.Text = "Edit Application Type";
            this.chkEditApplicationType.UseVisualStyleBackColor = true;
            // 
            // chkEditApplicationTestType
            // 
            this.chkEditApplicationTestType.AutoSize = true;
            this.chkEditApplicationTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkEditApplicationTestType.ForeColor = System.Drawing.Color.White;
            this.chkEditApplicationTestType.Location = new System.Drawing.Point(276, 407);
            this.chkEditApplicationTestType.Name = "chkEditApplicationTestType";
            this.chkEditApplicationTestType.Size = new System.Drawing.Size(192, 21);
            this.chkEditApplicationTestType.TabIndex = 10;
            this.chkEditApplicationTestType.Text = "Edit Application Test Type";
            this.chkEditApplicationTestType.UseVisualStyleBackColor = true;
            // 
            // chkDeleteApplication
            // 
            this.chkDeleteApplication.AutoSize = true;
            this.chkDeleteApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkDeleteApplication.ForeColor = System.Drawing.Color.White;
            this.chkDeleteApplication.Location = new System.Drawing.Point(276, 104);
            this.chkDeleteApplication.Name = "chkDeleteApplication";
            this.chkDeleteApplication.Size = new System.Drawing.Size(141, 21);
            this.chkDeleteApplication.TabIndex = 11;
            this.chkDeleteApplication.Text = "Delete Application";
            this.chkDeleteApplication.UseVisualStyleBackColor = true;
            // 
            // chkCancellApplication
            // 
            this.chkCancellApplication.AutoSize = true;
            this.chkCancellApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkCancellApplication.ForeColor = System.Drawing.Color.White;
            this.chkCancellApplication.Location = new System.Drawing.Point(276, 141);
            this.chkCancellApplication.Name = "chkCancellApplication";
            this.chkCancellApplication.Size = new System.Drawing.Size(143, 21);
            this.chkCancellApplication.TabIndex = 12;
            this.chkCancellApplication.Text = "Cancel Application";
            this.chkCancellApplication.UseVisualStyleBackColor = true;
            // 
            // chkManageLocalLicenses
            // 
            this.chkManageLocalLicenses.AutoSize = true;
            this.chkManageLocalLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageLocalLicenses.ForeColor = System.Drawing.Color.White;
            this.chkManageLocalLicenses.Location = new System.Drawing.Point(276, 243);
            this.chkManageLocalLicenses.Name = "chkManageLocalLicenses";
            this.chkManageLocalLicenses.Size = new System.Drawing.Size(176, 21);
            this.chkManageLocalLicenses.TabIndex = 13;
            this.chkManageLocalLicenses.Text = "Manage Local Licenses";
            this.chkManageLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // chkManageLocalDrivingLicensesScreen
            // 
            this.chkManageLocalDrivingLicensesScreen.AutoSize = true;
            this.chkManageLocalDrivingLicensesScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageLocalDrivingLicensesScreen.ForeColor = System.Drawing.Color.White;
            this.chkManageLocalDrivingLicensesScreen.Location = new System.Drawing.Point(277, 209);
            this.chkManageLocalDrivingLicensesScreen.Name = "chkManageLocalDrivingLicensesScreen";
            this.chkManageLocalDrivingLicensesScreen.Size = new System.Drawing.Size(273, 21);
            this.chkManageLocalDrivingLicensesScreen.TabIndex = 14;
            this.chkManageLocalDrivingLicensesScreen.Text = "Manage Local Driving Licenses Screen";
            this.chkManageLocalDrivingLicensesScreen.UseVisualStyleBackColor = true;
            // 
            // chkIssueFirstLicense
            // 
            this.chkIssueFirstLicense.AutoSize = true;
            this.chkIssueFirstLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkIssueFirstLicense.ForeColor = System.Drawing.Color.White;
            this.chkIssueFirstLicense.Location = new System.Drawing.Point(983, 62);
            this.chkIssueFirstLicense.Name = "chkIssueFirstLicense";
            this.chkIssueFirstLicense.Size = new System.Drawing.Size(144, 21);
            this.chkIssueFirstLicense.TabIndex = 15;
            this.chkIssueFirstLicense.Text = "Issue First License";
            this.chkIssueFirstLicense.UseVisualStyleBackColor = true;
            // 
            // chkRenewLicense
            // 
            this.chkRenewLicense.AutoSize = true;
            this.chkRenewLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkRenewLicense.ForeColor = System.Drawing.Color.White;
            this.chkRenewLicense.Location = new System.Drawing.Point(983, 95);
            this.chkRenewLicense.Name = "chkRenewLicense";
            this.chkRenewLicense.Size = new System.Drawing.Size(123, 21);
            this.chkRenewLicense.TabIndex = 16;
            this.chkRenewLicense.Text = "Renew License";
            this.chkRenewLicense.UseVisualStyleBackColor = true;
            // 
            // chkReplaceDamagedOrLostLicense
            // 
            this.chkReplaceDamagedOrLostLicense.AutoSize = true;
            this.chkReplaceDamagedOrLostLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkReplaceDamagedOrLostLicense.ForeColor = System.Drawing.Color.White;
            this.chkReplaceDamagedOrLostLicense.Location = new System.Drawing.Point(983, 128);
            this.chkReplaceDamagedOrLostLicense.Name = "chkReplaceDamagedOrLostLicense";
            this.chkReplaceDamagedOrLostLicense.Size = new System.Drawing.Size(248, 21);
            this.chkReplaceDamagedOrLostLicense.TabIndex = 17;
            this.chkReplaceDamagedOrLostLicense.Text = "Replace Damaged Or Lost License";
            this.chkReplaceDamagedOrLostLicense.UseVisualStyleBackColor = true;
            // 
            // chkViewLocalLicense
            // 
            this.chkViewLocalLicense.AutoSize = true;
            this.chkViewLocalLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkViewLocalLicense.ForeColor = System.Drawing.Color.White;
            this.chkViewLocalLicense.Location = new System.Drawing.Point(983, 161);
            this.chkViewLocalLicense.Name = "chkViewLocalLicense";
            this.chkViewLocalLicense.Size = new System.Drawing.Size(147, 21);
            this.chkViewLocalLicense.TabIndex = 18;
            this.chkViewLocalLicense.Text = "View Local License";
            this.chkViewLocalLicense.UseVisualStyleBackColor = true;
            // 
            // chkViewLicenseHistory
            // 
            this.chkViewLicenseHistory.AutoSize = true;
            this.chkViewLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkViewLicenseHistory.ForeColor = System.Drawing.Color.White;
            this.chkViewLicenseHistory.Location = new System.Drawing.Point(983, 195);
            this.chkViewLicenseHistory.Name = "chkViewLicenseHistory";
            this.chkViewLicenseHistory.Size = new System.Drawing.Size(157, 21);
            this.chkViewLicenseHistory.TabIndex = 19;
            this.chkViewLicenseHistory.Text = "View License History";
            this.chkViewLicenseHistory.UseVisualStyleBackColor = true;
            // 
            // chkManageInternationalLicenses
            // 
            this.chkManageInternationalLicenses.AutoSize = true;
            this.chkManageInternationalLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageInternationalLicenses.ForeColor = System.Drawing.Color.White;
            this.chkManageInternationalLicenses.Location = new System.Drawing.Point(665, 70);
            this.chkManageInternationalLicenses.Name = "chkManageInternationalLicenses";
            this.chkManageInternationalLicenses.Size = new System.Drawing.Size(220, 21);
            this.chkManageInternationalLicenses.TabIndex = 20;
            this.chkManageInternationalLicenses.Text = "Manage International Licenses";
            this.chkManageInternationalLicenses.UseVisualStyleBackColor = true;
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
            // btnNext
            // 
            this.btnNext.Animated = true;
            this.btnNext.AutoRoundedCorners = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.Blue;
            this.btnNext.FillColor2 = System.Drawing.Color.Aqua;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnNext.IndicateFocus = true;
            this.btnNext.Location = new System.Drawing.Point(1098, 544);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(137, 49);
            this.btnNext.TabIndex = 34;
            this.btnNext.Text = "Next";
            this.btnNext.UseTransparentBackground = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tcAddEditUserPermissions
            // 
            this.tcAddEditUserPermissions.Controls.Add(this.tbUserPermissions);
            this.tcAddEditUserPermissions.Controls.Add(this.tbAddEditPermissions);
            this.tcAddEditUserPermissions.ItemSize = new System.Drawing.Size(180, 40);
            this.tcAddEditUserPermissions.Location = new System.Drawing.Point(50, 77);
            this.tcAddEditUserPermissions.Name = "tcAddEditUserPermissions";
            this.tcAddEditUserPermissions.SelectedIndex = 0;
            this.tcAddEditUserPermissions.Size = new System.Drawing.Size(1260, 651);
            this.tcAddEditUserPermissions.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcAddEditUserPermissions.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcAddEditUserPermissions.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcAddEditUserPermissions.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcAddEditUserPermissions.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcAddEditUserPermissions.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcAddEditUserPermissions.TabButtonIdleState.FillColor = System.Drawing.Color.Black;
            this.tcAddEditUserPermissions.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcAddEditUserPermissions.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcAddEditUserPermissions.TabButtonIdleState.InnerColor = System.Drawing.Color.Black;
            this.tcAddEditUserPermissions.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcAddEditUserPermissions.TabButtonSelectedState.FillColor = System.Drawing.Color.Black;
            this.tcAddEditUserPermissions.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcAddEditUserPermissions.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcAddEditUserPermissions.TabButtonSelectedState.InnerColor = System.Drawing.Color.Blue;
            this.tcAddEditUserPermissions.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcAddEditUserPermissions.TabIndex = 30;
            this.tcAddEditUserPermissions.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tcAddEditUserPermissions.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tbUserPermissions
            // 
            this.tbUserPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tbUserPermissions.Controls.Add(this.btnNext);
            this.tbUserPermissions.Controls.Add(this.ctrlUserPermissionsCard1);
            this.tbUserPermissions.Location = new System.Drawing.Point(4, 44);
            this.tbUserPermissions.Name = "tbUserPermissions";
            this.tbUserPermissions.Padding = new System.Windows.Forms.Padding(3);
            this.tbUserPermissions.Size = new System.Drawing.Size(1252, 603);
            this.tbUserPermissions.TabIndex = 0;
            this.tbUserPermissions.Text = "User Permissions";
            // 
            // ctrlUserPermissionsCard1
            // 
            this.ctrlUserPermissionsCard1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlUserPermissionsCard1.Location = new System.Drawing.Point(6, 6);
            this.ctrlUserPermissionsCard1.MinimumSize = new System.Drawing.Size(750, 400);
            this.ctrlUserPermissionsCard1.Name = "ctrlUserPermissionsCard1";
            this.ctrlUserPermissionsCard1.Size = new System.Drawing.Size(1244, 568);
            this.ctrlUserPermissionsCard1.TabIndex = 37;
            // 
            // tbAddEditPermissions
            // 
            this.tbAddEditPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel8);
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel7);
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel6);
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel5);
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel4);
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel3);
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel2);
            this.tbAddEditPermissions.Controls.Add(this.guna2HtmlLabel1);
            this.tbAddEditPermissions.Controls.Add(this.chkViewDetainedLicenses);
            this.tbAddEditPermissions.Controls.Add(this.chkReleaseLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkIssueInternationalLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkViewInternationalLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkManageTestAppointments);
            this.tbAddEditPermissions.Controls.Add(this.chkScheduleTest);
            this.tbAddEditPermissions.Controls.Add(this.chkTakeTest);
            this.tbAddEditPermissions.Controls.Add(this.chkManageDetainLicenseScreen);
            this.tbAddEditPermissions.Controls.Add(this.chkDetainLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkManageApplicationTypes);
            this.tbAddEditPermissions.Controls.Add(this.chkManageTestTypes);
            this.tbAddEditPermissions.Controls.Add(this.chkViewDrivers);
            this.tbAddEditPermissions.Controls.Add(this.chkManagePeople);
            this.tbAddEditPermissions.Controls.Add(this.chkIssueFirstLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkManageInternationalLicenses);
            this.tbAddEditPermissions.Controls.Add(this.chkAddEditPerson);
            this.tbAddEditPermissions.Controls.Add(this.chkViewLicenseHistory);
            this.tbAddEditPermissions.Controls.Add(this.chkDeletePerson);
            this.tbAddEditPermissions.Controls.Add(this.chkViewLocalLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkManageUsers);
            this.tbAddEditPermissions.Controls.Add(this.chkReplaceDamagedOrLostLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkAddEditUser);
            this.tbAddEditPermissions.Controls.Add(this.chkRenewLicense);
            this.tbAddEditPermissions.Controls.Add(this.chkEditUserPassword);
            this.tbAddEditPermissions.Controls.Add(this.chkManageLocalDrivingLicensesScreen);
            this.tbAddEditPermissions.Controls.Add(this.chkDeleteUser);
            this.tbAddEditPermissions.Controls.Add(this.chkManageLocalLicenses);
            this.tbAddEditPermissions.Controls.Add(this.chkViewApplications);
            this.tbAddEditPermissions.Controls.Add(this.chkCancellApplication);
            this.tbAddEditPermissions.Controls.Add(this.chkManageNewLocalDrivingLicenseApplications);
            this.tbAddEditPermissions.Controls.Add(this.chkDeleteApplication);
            this.tbAddEditPermissions.Controls.Add(this.chkEditApplicationType);
            this.tbAddEditPermissions.Controls.Add(this.chkEditApplicationTestType);
            this.tbAddEditPermissions.Location = new System.Drawing.Point(4, 44);
            this.tbAddEditPermissions.Name = "tbAddEditPermissions";
            this.tbAddEditPermissions.Padding = new System.Windows.Forms.Padding(3);
            this.tbAddEditPermissions.Size = new System.Drawing.Size(1252, 603);
            this.tbAddEditPermissions.TabIndex = 1;
            this.tbAddEditPermissions.Text = "Add Edit Permissions";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(259, 335);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(49, 19);
            this.guna2HtmlLabel8.TabIndex = 60;
            this.guna2HtmlLabel8.Text = "System";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(651, 195);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(97, 19);
            this.guna2HtmlLabel7.TabIndex = 59;
            this.guna2HtmlLabel7.Text = "Detain License";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(973, 27);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(90, 19);
            this.guna2HtmlLabel6.TabIndex = 58;
            this.guna2HtmlLabel6.Text = "Local License";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(651, 27);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(134, 19);
            this.guna2HtmlLabel5.TabIndex = 57;
            this.guna2HtmlLabel5.Text = "International License";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(973, 243);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(31, 19);
            this.guna2HtmlLabel4.TabIndex = 56;
            this.guna2HtmlLabel4.Text = "Test";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(259, 27);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(79, 19);
            this.guna2HtmlLabel3.TabIndex = 55;
            this.guna2HtmlLabel3.Text = "Applications";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(36, 196);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(33, 19);
            this.guna2HtmlLabel2.TabIndex = 54;
            this.guna2HtmlLabel2.Text = "User";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(36, 27);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(47, 19);
            this.guna2HtmlLabel1.TabIndex = 53;
            this.guna2HtmlLabel1.Text = "People";
            // 
            // chkViewDetainedLicenses
            // 
            this.chkViewDetainedLicenses.AutoSize = true;
            this.chkViewDetainedLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkViewDetainedLicenses.ForeColor = System.Drawing.Color.White;
            this.chkViewDetainedLicenses.Location = new System.Drawing.Point(668, 334);
            this.chkViewDetainedLicenses.Name = "chkViewDetainedLicenses";
            this.chkViewDetainedLicenses.Size = new System.Drawing.Size(177, 21);
            this.chkViewDetainedLicenses.TabIndex = 45;
            this.chkViewDetainedLicenses.Text = "View Detained Licenses";
            this.chkViewDetainedLicenses.UseVisualStyleBackColor = true;
            // 
            // chkReleaseLicense
            // 
            this.chkReleaseLicense.AutoSize = true;
            this.chkReleaseLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkReleaseLicense.ForeColor = System.Drawing.Color.White;
            this.chkReleaseLicense.Location = new System.Drawing.Point(668, 298);
            this.chkReleaseLicense.Name = "chkReleaseLicense";
            this.chkReleaseLicense.Size = new System.Drawing.Size(132, 21);
            this.chkReleaseLicense.TabIndex = 44;
            this.chkReleaseLicense.Text = "Release License";
            this.chkReleaseLicense.UseVisualStyleBackColor = true;
            // 
            // chkIssueInternationalLicense
            // 
            this.chkIssueInternationalLicense.AutoSize = true;
            this.chkIssueInternationalLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkIssueInternationalLicense.ForeColor = System.Drawing.Color.White;
            this.chkIssueInternationalLicense.Location = new System.Drawing.Point(667, 104);
            this.chkIssueInternationalLicense.Name = "chkIssueInternationalLicense";
            this.chkIssueInternationalLicense.Size = new System.Drawing.Size(195, 21);
            this.chkIssueInternationalLicense.TabIndex = 34;
            this.chkIssueInternationalLicense.Text = "Issue International License";
            this.chkIssueInternationalLicense.UseVisualStyleBackColor = true;
            // 
            // chkViewInternationalLicense
            // 
            this.chkViewInternationalLicense.AutoSize = true;
            this.chkViewInternationalLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkViewInternationalLicense.ForeColor = System.Drawing.Color.White;
            this.chkViewInternationalLicense.Location = new System.Drawing.Point(667, 137);
            this.chkViewInternationalLicense.Name = "chkViewInternationalLicense";
            this.chkViewInternationalLicense.Size = new System.Drawing.Size(191, 21);
            this.chkViewInternationalLicense.TabIndex = 35;
            this.chkViewInternationalLicense.Text = "View International License";
            this.chkViewInternationalLicense.UseVisualStyleBackColor = true;
            // 
            // chkManageTestAppointments
            // 
            this.chkManageTestAppointments.AutoSize = true;
            this.chkManageTestAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageTestAppointments.ForeColor = System.Drawing.Color.White;
            this.chkManageTestAppointments.Location = new System.Drawing.Point(983, 280);
            this.chkManageTestAppointments.Name = "chkManageTestAppointments";
            this.chkManageTestAppointments.Size = new System.Drawing.Size(200, 21);
            this.chkManageTestAppointments.TabIndex = 36;
            this.chkManageTestAppointments.Text = "Manage Test Appointments";
            this.chkManageTestAppointments.UseVisualStyleBackColor = true;
            // 
            // chkScheduleTest
            // 
            this.chkScheduleTest.AutoSize = true;
            this.chkScheduleTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkScheduleTest.ForeColor = System.Drawing.Color.White;
            this.chkScheduleTest.Location = new System.Drawing.Point(983, 348);
            this.chkScheduleTest.Name = "chkScheduleTest";
            this.chkScheduleTest.Size = new System.Drawing.Size(118, 21);
            this.chkScheduleTest.TabIndex = 37;
            this.chkScheduleTest.Text = "Schedule Test";
            this.chkScheduleTest.UseVisualStyleBackColor = true;
            // 
            // chkTakeTest
            // 
            this.chkTakeTest.AutoSize = true;
            this.chkTakeTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkTakeTest.ForeColor = System.Drawing.Color.White;
            this.chkTakeTest.Location = new System.Drawing.Point(983, 382);
            this.chkTakeTest.Name = "chkTakeTest";
            this.chkTakeTest.Size = new System.Drawing.Size(91, 21);
            this.chkTakeTest.TabIndex = 38;
            this.chkTakeTest.Text = "Take Test";
            this.chkTakeTest.UseVisualStyleBackColor = true;
            // 
            // chkManageDetainLicenseScreen
            // 
            this.chkManageDetainLicenseScreen.AutoSize = true;
            this.chkManageDetainLicenseScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageDetainLicenseScreen.ForeColor = System.Drawing.Color.White;
            this.chkManageDetainLicenseScreen.Location = new System.Drawing.Point(667, 234);
            this.chkManageDetainLicenseScreen.Name = "chkManageDetainLicenseScreen";
            this.chkManageDetainLicenseScreen.Size = new System.Drawing.Size(225, 21);
            this.chkManageDetainLicenseScreen.TabIndex = 39;
            this.chkManageDetainLicenseScreen.Text = "Manage Detain License Screen";
            this.chkManageDetainLicenseScreen.UseVisualStyleBackColor = true;
            // 
            // chkDetainLicense
            // 
            this.chkDetainLicense.AutoSize = true;
            this.chkDetainLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkDetainLicense.ForeColor = System.Drawing.Color.White;
            this.chkDetainLicense.Location = new System.Drawing.Point(668, 264);
            this.chkDetainLicense.Name = "chkDetainLicense";
            this.chkDetainLicense.Size = new System.Drawing.Size(121, 21);
            this.chkDetainLicense.TabIndex = 40;
            this.chkDetainLicense.Text = "Detain License";
            this.chkDetainLicense.UseVisualStyleBackColor = true;
            // 
            // chkManageApplicationTypes
            // 
            this.chkManageApplicationTypes.AutoSize = true;
            this.chkManageApplicationTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageApplicationTypes.ForeColor = System.Drawing.Color.White;
            this.chkManageApplicationTypes.Location = new System.Drawing.Point(276, 280);
            this.chkManageApplicationTypes.Name = "chkManageApplicationTypes";
            this.chkManageApplicationTypes.Size = new System.Drawing.Size(194, 21);
            this.chkManageApplicationTypes.TabIndex = 41;
            this.chkManageApplicationTypes.Text = "Manage Application Types";
            this.chkManageApplicationTypes.UseVisualStyleBackColor = true;
            // 
            // chkManageTestTypes
            // 
            this.chkManageTestTypes.AutoSize = true;
            this.chkManageTestTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkManageTestTypes.ForeColor = System.Drawing.Color.White;
            this.chkManageTestTypes.Location = new System.Drawing.Point(983, 314);
            this.chkManageTestTypes.Name = "chkManageTestTypes";
            this.chkManageTestTypes.Size = new System.Drawing.Size(153, 21);
            this.chkManageTestTypes.TabIndex = 42;
            this.chkManageTestTypes.Text = "Manage Test Types";
            this.chkManageTestTypes.UseVisualStyleBackColor = true;
            // 
            // chkViewDrivers
            // 
            this.chkViewDrivers.AutoSize = true;
            this.chkViewDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkViewDrivers.ForeColor = System.Drawing.Color.White;
            this.chkViewDrivers.Location = new System.Drawing.Point(277, 437);
            this.chkViewDrivers.Name = "chkViewDrivers";
            this.chkViewDrivers.Size = new System.Drawing.Size(105, 21);
            this.chkViewDrivers.TabIndex = 43;
            this.chkViewDrivers.Text = "View Drivers";
            this.chkViewDrivers.UseVisualStyleBackColor = true;
            // 
            // ctrlFindUserFilter2
            // 
            this.ctrlFindUserFilter2.BackColor = System.Drawing.Color.Transparent;
            this.ctrlFindUserFilter2.Location = new System.Drawing.Point(465, 9);
            this.ctrlFindUserFilter2.Name = "ctrlFindUserFilter2";
            this.ctrlFindUserFilter2.Size = new System.Drawing.Size(422, 46);
            this.ctrlFindUserFilter2.TabIndex = 36;
            this.ctrlFindUserFilter2.OnSearchedForUserByUserID += new System.Action<int>(this.ctrlFindUserFilter1_OnSearchedForUserByUserID);
            this.ctrlFindUserFilter2.OnSearchedForUserByUserName += new System.Action<string>(this.ctrlFindUserFilter2_OnSearchedForUserByUserName);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.Blue;
            this.btnSave.FillColor2 = System.Drawing.Color.Aqua;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.IndicateFocus = true;
            this.btnSave.Location = new System.Drawing.Point(541, 701);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(216, 49);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlFindUserFilter1
            // 
            this.ctrlFindUserFilter1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlFindUserFilter1.Location = new System.Drawing.Point(93, 6);
            this.ctrlFindUserFilter1.Name = "ctrlFindUserFilter1";
            this.ctrlFindUserFilter1.Size = new System.Drawing.Size(474, 48);
            this.ctrlFindUserFilter1.TabIndex = 36;
            this.ctrlFindUserFilter1.OnSearchedForUserByUserID += new System.Action<int>(this.ctrlFindUserFilter1_OnSearchedForUserByUserID);
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(1305, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 77;
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
            this.btnMinimize.Location = new System.Drawing.Point(1202, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 79;
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
            this.btnMaximaze.Location = new System.Drawing.Point(1254, 2);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 78;
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.Blue;
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(76, 41);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(204, 17);
            this.guna2HtmlLabel9.TabIndex = 82;
            this.guna2HtmlLabel9.Text = "View ,Find ,Add ,Edit User Permissions";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.password;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(16, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(38, 35);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 81;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 29);
            this.label1.TabIndex = 80;
            this.label1.Text = "Add Edit User Permissions";
            // 
            // frmAddEditUserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1359, 788);
            this.Controls.Add(this.guna2HtmlLabel9);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlFindUserFilter2);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tcAddEditUserPermissions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditUserPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "AddEditUserPermissions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAddEditUserPermissions_Load);
            this.tcAddEditUserPermissions.ResumeLayout(false);
            this.tbUserPermissions.ResumeLayout(false);
            this.tbAddEditPermissions.ResumeLayout(false);
            this.tbAddEditPermissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkManagePeople;
        private System.Windows.Forms.CheckBox chkAddEditPerson;
        private System.Windows.Forms.CheckBox chkDeletePerson;
        private System.Windows.Forms.CheckBox chkManageUsers;
        private System.Windows.Forms.CheckBox chkAddEditUser;
        private System.Windows.Forms.CheckBox chkEditUserPassword;
        private System.Windows.Forms.CheckBox chkDeleteUser;
        private System.Windows.Forms.CheckBox chkViewApplications;
        private System.Windows.Forms.CheckBox chkManageNewLocalDrivingLicenseApplications;
        private System.Windows.Forms.CheckBox chkEditApplicationType;
        private System.Windows.Forms.CheckBox chkEditApplicationTestType;
        private System.Windows.Forms.CheckBox chkDeleteApplication;
        private System.Windows.Forms.CheckBox chkCancellApplication;
        private System.Windows.Forms.CheckBox chkManageLocalLicenses;
        private System.Windows.Forms.CheckBox chkManageLocalDrivingLicensesScreen;
        private System.Windows.Forms.CheckBox chkIssueFirstLicense;
        private System.Windows.Forms.CheckBox chkRenewLicense;
        private System.Windows.Forms.CheckBox chkReplaceDamagedOrLostLicense;
        private System.Windows.Forms.CheckBox chkViewLocalLicense;
        private System.Windows.Forms.CheckBox chkViewLicenseHistory;
        private System.Windows.Forms.CheckBox chkManageInternationalLicenses;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private GlobalCustomControls.RoundedTabControl tcAddEditUserPermissions;
        private System.Windows.Forms.TabPage tbUserPermissions;
        private System.Windows.Forms.TabPage tbAddEditPermissions;
        private System.Windows.Forms.CheckBox chkIssueInternationalLicense;
        private System.Windows.Forms.CheckBox chkViewInternationalLicense;
        private System.Windows.Forms.CheckBox chkManageTestAppointments;
        private System.Windows.Forms.CheckBox chkScheduleTest;
        private System.Windows.Forms.CheckBox chkTakeTest;
        private System.Windows.Forms.CheckBox chkManageDetainLicenseScreen;
        private System.Windows.Forms.CheckBox chkDetainLicense;
        private System.Windows.Forms.CheckBox chkManageApplicationTypes;
        private System.Windows.Forms.CheckBox chkManageTestTypes;
        private System.Windows.Forms.CheckBox chkViewDrivers;
        private Users.User_Controles.ctrlFindUserFilter ctrlFindUserFilter1;
        private System.Windows.Forms.CheckBox chkViewDetainedLicenses;
        private System.Windows.Forms.CheckBox chkReleaseLicense;
        private Users.User_Controles.ctrlFindUserFilter ctrlFindUserFilter2;
        private Users.Manage_Users_Permissions.User_Permissions_User_Controls.ctrlUserPermissionsCard ctrlUserPermissionsCard1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label label1;
    }
}