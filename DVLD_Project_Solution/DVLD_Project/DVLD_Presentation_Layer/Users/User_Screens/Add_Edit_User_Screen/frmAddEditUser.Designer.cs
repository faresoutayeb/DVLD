using GlobalCustomControls;

namespace DVLD_Presentation_Layer.Users.User_Screens
{
    partial class frmAddEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditUser));
            this.lblUserMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblScreenMode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tabControl1 = new GlobalCustomControls.RoundedTabControl();
            this.tbctrlPersonalInfo = new System.Windows.Forms.TabPage();
            this.ctrlFilterPersonInformation1 = new DVLD_Presentation_Layer.Person.PersonControles.ctrlFilterPersonInformation();
            this.tbctrlLoginInfo = new System.Windows.Forms.TabPage();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblUserIdValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbRoles = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.chkIsActive = new Guna.UI2.WinForms.Guna2CheckBox();
            this.txtBConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtbUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCustomPermissions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chkLockUser = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbctrlPersonalInfo.SuspendLayout();
            this.tbctrlLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblUserMessage.Location = new System.Drawing.Point(84, 40);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(269, 22);
            this.lblUserMessage.TabIndex = 32;
            this.lblUserMessage.Text = "Show, Add, Edit User information";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(9, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(48, 53);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 31;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lblScreenMode
            // 
            this.lblScreenMode.BackColor = System.Drawing.Color.Transparent;
            this.lblScreenMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblScreenMode.ForeColor = System.Drawing.Color.White;
            this.lblScreenMode.Location = new System.Drawing.Point(65, 10);
            this.lblScreenMode.Name = "lblScreenMode";
            this.lblScreenMode.Size = new System.Drawing.Size(164, 31);
            this.lblScreenMode.TabIndex = 30;
            this.lblScreenMode.Text = "Add / Edit User";
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.AutoRoundedCorners = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.Aqua;
            this.btnSave.BorderRadius = 25;
            this.btnSave.BorderThickness = 1;
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
            this.btnSave.Location = new System.Drawing.Point(274, 509);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 53);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNext
            // 
            this.btnNext.Animated = true;
            this.btnNext.AutoRoundedCorners = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderColor = System.Drawing.Color.Aqua;
            this.btnNext.BorderRadius = 19;
            this.btnNext.BorderThickness = 1;
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
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNext.Location = new System.Drawing.Point(509, 318);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(134, 40);
            this.btnNext.TabIndex = 34;
            this.btnNext.Text = "Next";
            this.btnNext.UseTransparentBackground = true;
            this.btnNext.Click += new System.EventHandler(this.btnNextToLoginInfo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbctrlPersonalInfo);
            this.tabControl1.Controls.Add(this.tbctrlLoginInfo);
            this.tabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControl1.Location = new System.Drawing.Point(9, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(689, 426);
            this.tabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Black;
            this.tabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.Blue;
            this.tabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tabControl1.TabIndex = 34;
            this.tabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbctrlPersonalInfo
            // 
            this.tbctrlPersonalInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tbctrlPersonalInfo.Controls.Add(this.ctrlFilterPersonInformation1);
            this.tbctrlPersonalInfo.Controls.Add(this.btnNext);
            this.tbctrlPersonalInfo.Location = new System.Drawing.Point(4, 44);
            this.tbctrlPersonalInfo.Name = "tbctrlPersonalInfo";
            this.tbctrlPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbctrlPersonalInfo.Size = new System.Drawing.Size(681, 378);
            this.tbctrlPersonalInfo.TabIndex = 0;
            this.tbctrlPersonalInfo.Text = "Personal Info";
            // 
            // ctrlFilterPersonInformation1
            // 
            this.ctrlFilterPersonInformation1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlFilterPersonInformation1.EnableAddNewButton = true;
            this.ctrlFilterPersonInformation1.EnableFilter = true;
            this.ctrlFilterPersonInformation1.Location = new System.Drawing.Point(13, 36);
            this.ctrlFilterPersonInformation1.Name = "ctrlFilterPersonInformation1";
            this.ctrlFilterPersonInformation1.Size = new System.Drawing.Size(662, 266);
            this.ctrlFilterPersonInformation1.TabIndex = 3;
            this.ctrlFilterPersonInformation1.OnPersonSelectedByPersonID += new System.Action<int>(this.ctrlFilterPersonInformation1_OnPersonSelectedByPersonID);
            this.ctrlFilterPersonInformation1.OnPersonSelectedByNationalNo += new System.Action<string>(this.ctrlFilterPersonInformation1_OnPersonSelectedByNationalNo);
            this.ctrlFilterPersonInformation1.OnPersonSelectedNotFound += new System.Action(this.ctrlFilterPersonInformation1_OnPersonWeSearchForNotFound);
            this.ctrlFilterPersonInformation1.OnPersonSelectedFound += new System.Action(this.ctrlFilterPersonInformation1_OnPersonWeSearchForFound);
            // 
            // tbctrlLoginInfo
            // 
            this.tbctrlLoginInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.tbctrlLoginInfo.Controls.Add(this.guna2HtmlLabel2);
            this.tbctrlLoginInfo.Controls.Add(this.lblUserIdValue);
            this.tbctrlLoginInfo.Controls.Add(this.cbRoles);
            this.tbctrlLoginInfo.Controls.Add(this.btnBack);
            this.tbctrlLoginInfo.Controls.Add(this.chkIsActive);
            this.tbctrlLoginInfo.Controls.Add(this.txtBConfirmPassword);
            this.tbctrlLoginInfo.Controls.Add(this.txtbUserName);
            this.tbctrlLoginInfo.Controls.Add(this.txtBPassword);
            this.tbctrlLoginInfo.Controls.Add(this.guna2HtmlLabel1);
            this.tbctrlLoginInfo.Controls.Add(this.lblCustomPermissions);
            this.tbctrlLoginInfo.Controls.Add(this.chkLockUser);
            this.tbctrlLoginInfo.Location = new System.Drawing.Point(4, 44);
            this.tbctrlLoginInfo.Name = "tbctrlLoginInfo";
            this.tbctrlLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbctrlLoginInfo.Size = new System.Drawing.Size(681, 378);
            this.tbctrlLoginInfo.TabIndex = 1;
            this.tbctrlLoginInfo.Text = "LoginInfo";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(29, 22);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(62, 22);
            this.guna2HtmlLabel2.TabIndex = 62;
            this.guna2HtmlLabel2.Text = "User ID:";
            // 
            // lblUserIdValue
            // 
            this.lblUserIdValue.BackColor = System.Drawing.Color.Transparent;
            this.lblUserIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblUserIdValue.ForeColor = System.Drawing.Color.White;
            this.lblUserIdValue.Location = new System.Drawing.Point(97, 22);
            this.lblUserIdValue.Name = "lblUserIdValue";
            this.lblUserIdValue.Size = new System.Drawing.Size(39, 22);
            this.lblUserIdValue.TabIndex = 61;
            this.lblUserIdValue.Text = "????";
            // 
            // cbRoles
            // 
            this.cbRoles.BackColor = System.Drawing.Color.Transparent;
            this.cbRoles.BorderColor = System.Drawing.Color.Blue;
            this.cbRoles.BorderRadius = 10;
            this.cbRoles.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbRoles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoles.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbRoles.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbRoles.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbRoles.ForeColor = System.Drawing.Color.White;
            this.cbRoles.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.cbRoles.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbRoles.HoverState.ForeColor = System.Drawing.Color.White;
            this.cbRoles.ItemHeight = 30;
            this.cbRoles.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbRoles.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbRoles.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbRoles.Location = new System.Drawing.Point(340, 59);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.ShadowDecoration.BorderRadius = 15;
            this.cbRoles.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbRoles.ShadowDecoration.Depth = 45;
            this.cbRoles.ShadowDecoration.Enabled = true;
            this.cbRoles.Size = new System.Drawing.Size(249, 36);
            this.cbRoles.TabIndex = 60;
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.AutoRoundedCorners = true;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderColor = System.Drawing.Color.Aqua;
            this.btnBack.BorderRadius = 19;
            this.btnBack.BorderThickness = 1;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.Blue;
            this.btnBack.FillColor2 = System.Drawing.Color.Aqua;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.btnBack.Image = global::DVLD_Presentation_Layer.Properties.Resources.BackFast;
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.Location = new System.Drawing.Point(29, 310);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(134, 40);
            this.btnBack.TabIndex = 36;
            this.btnBack.Text = "Back";
            this.btnBack.UseTransparentBackground = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsActive.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chkIsActive.CheckedState.BorderRadius = 2;
            this.chkIsActive.CheckedState.BorderThickness = 1;
            this.chkIsActive.CheckedState.FillColor = System.Drawing.Color.White;
            this.chkIsActive.CheckMarkColor = System.Drawing.Color.Black;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chkIsActive.ForeColor = System.Drawing.Color.White;
            this.chkIsActive.Location = new System.Drawing.Point(486, 146);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(92, 24);
            this.chkIsActive.TabIndex = 27;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UncheckedState.BorderColor = System.Drawing.Color.Blue;
            this.chkIsActive.UncheckedState.BorderRadius = 2;
            this.chkIsActive.UncheckedState.BorderThickness = 1;
            this.chkIsActive.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkIsActive.UseVisualStyleBackColor = false;
            // 
            // txtBConfirmPassword
            // 
            this.txtBConfirmPassword.Animated = true;
            this.txtBConfirmPassword.BorderColor = System.Drawing.Color.Blue;
            this.txtBConfirmPassword.BorderRadius = 10;
            this.txtBConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBConfirmPassword.DefaultText = "";
            this.txtBConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBConfirmPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtBConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBConfirmPassword.Location = new System.Drawing.Point(29, 191);
            this.txtBConfirmPassword.Name = "txtBConfirmPassword";
            this.txtBConfirmPassword.PlaceholderText = "Confirm password ...";
            this.txtBConfirmPassword.SelectedText = "";
            this.txtBConfirmPassword.Size = new System.Drawing.Size(254, 43);
            this.txtBConfirmPassword.TabIndex = 21;
            this.txtBConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtBConfirmPassword_Validating);
            // 
            // txtbUserName
            // 
            this.txtbUserName.Animated = true;
            this.txtbUserName.BorderColor = System.Drawing.Color.Blue;
            this.txtbUserName.BorderRadius = 10;
            this.txtbUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbUserName.DefaultText = "";
            this.txtbUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbUserName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtbUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbUserName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbUserName.Location = new System.Drawing.Point(29, 59);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.PlaceholderText = "User Name ...";
            this.txtbUserName.SelectedText = "";
            this.txtbUserName.Size = new System.Drawing.Size(254, 43);
            this.txtbUserName.TabIndex = 19;
            // 
            // txtBPassword
            // 
            this.txtBPassword.Animated = true;
            this.txtBPassword.BorderColor = System.Drawing.Color.Blue;
            this.txtBPassword.BorderRadius = 10;
            this.txtBPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBPassword.DefaultText = "";
            this.txtBPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtBPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBPassword.Location = new System.Drawing.Point(29, 127);
            this.txtBPassword.Name = "txtBPassword";
            this.txtBPassword.PlaceholderText = "Password ...";
            this.txtBPassword.SelectedText = "";
            this.txtBPassword.Size = new System.Drawing.Size(254, 43);
            this.txtBPassword.TabIndex = 20;
            this.txtBPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtBPassword_Validating);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(340, 25);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(74, 22);
            this.guna2HtmlLabel1.TabIndex = 25;
            this.guna2HtmlLabel1.Text = "User Role";
            // 
            // lblCustomPermissions
            // 
            this.lblCustomPermissions.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomPermissions.ForeColor = System.Drawing.Color.Blue;
            this.lblCustomPermissions.Location = new System.Drawing.Point(448, 101);
            this.lblCustomPermissions.Name = "lblCustomPermissions";
            this.lblCustomPermissions.Size = new System.Drawing.Size(141, 20);
            this.lblCustomPermissions.TabIndex = 26;
            this.lblCustomPermissions.Text = "Custom permissions";
            // 
            // chkLockUser
            // 
            this.chkLockUser.AutoSize = true;
            this.chkLockUser.BackColor = System.Drawing.Color.Transparent;
            this.chkLockUser.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chkLockUser.CheckedState.BorderRadius = 2;
            this.chkLockUser.CheckedState.BorderThickness = 1;
            this.chkLockUser.CheckedState.FillColor = System.Drawing.Color.White;
            this.chkLockUser.CheckMarkColor = System.Drawing.Color.Black;
            this.chkLockUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.chkLockUser.ForeColor = System.Drawing.Color.White;
            this.chkLockUser.Location = new System.Drawing.Point(353, 146);
            this.chkLockUser.Name = "chkLockUser";
            this.chkLockUser.Size = new System.Drawing.Size(105, 24);
            this.chkLockUser.TabIndex = 23;
            this.chkLockUser.Text = "Lock User";
            this.chkLockUser.UncheckedState.BorderColor = System.Drawing.Color.Blue;
            this.chkLockUser.UncheckedState.BorderRadius = 2;
            this.chkLockUser.UncheckedState.BorderThickness = 1;
            this.chkLockUser.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkLockUser.UseVisualStyleBackColor = false;
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
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(20, 7);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(103, 22);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Set User Role";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(652, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 80;
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
            this.btnMinimize.Location = new System.Drawing.Point(549, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 82;
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
            this.btnMaximaze.Location = new System.Drawing.Point(601, 4);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 81;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(710, 579);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.lblScreenMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_EditUserScreen";
            this.Load += new System.EventHandler(this.Add_EditUserScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbctrlPersonalInfo.ResumeLayout(false);
            this.tbctrlLoginInfo.ResumeLayout(false);
            this.tbctrlLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserMessage;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblScreenMode;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private GlobalCustomControls.RoundedTabControl tabControl1;
        private System.Windows.Forms.TabPage tbctrlPersonalInfo;
        private System.Windows.Forms.TabPage tbctrlLoginInfo;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2TextBox txtBConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtBPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtbUserName;
        private Guna.UI2.WinForms.Guna2CheckBox chkIsActive;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCustomPermissions;
        private Guna.UI2.WinForms.Guna2CheckBox chkLockUser;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public Person.PersonControles.ctrlFilterPersonInformation ctrlFilterPersonInformation1;
        private Guna.UI2.WinForms.Guna2GradientButton btnBack;
        private Guna.UI2.WinForms.Guna2ComboBox cbRoles;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserIdValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
    }
}