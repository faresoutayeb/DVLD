namespace DVLD_Presentation_Layer.Users.UserScreens
{
    partial class frmChangePassword
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblUserMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblScreenMode = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnShowHide1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtbNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtbCurrentPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSaveNewPassword = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnShowHide2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowHide3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.ctrlSmallUserInfoCard1 = new DVLD_Presentation_Layer.Users.User_Controles.ctrlSmallUserInfoCard();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblUserMessage.Location = new System.Drawing.Point(88, 44);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(175, 22);
            this.lblUserMessage.TabIndex = 38;
            this.lblUserMessage.Text = "Edit Loging password";
            // 
            // lblScreenMode
            // 
            this.lblScreenMode.BackColor = System.Drawing.Color.Transparent;
            this.lblScreenMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblScreenMode.ForeColor = System.Drawing.Color.White;
            this.lblScreenMode.Location = new System.Drawing.Point(73, 12);
            this.lblScreenMode.Name = "lblScreenMode";
            this.lblScreenMode.Size = new System.Drawing.Size(257, 31);
            this.lblScreenMode.TabIndex = 36;
            this.lblScreenMode.Text = "Change  User Password";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.AnimationInterval = 0;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnShowHide1
            // 
            this.btnShowHide1.Animated = true;
            this.btnShowHide1.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHide1.BorderColor = System.Drawing.Color.Navy;
            this.btnShowHide1.BorderRadius = 10;
            this.btnShowHide1.BorderThickness = 1;
            this.btnShowHide1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHide1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHide1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowHide1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowHide1.FillColor = System.Drawing.Color.Transparent;
            this.btnShowHide1.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.btnShowHide1.ForeColor = System.Drawing.Color.White;
            this.btnShowHide1.IndicateFocus = true;
            this.btnShowHide1.Location = new System.Drawing.Point(256, 203);
            this.btnShowHide1.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowHide1.Name = "btnShowHide1";
            this.btnShowHide1.Size = new System.Drawing.Size(51, 22);
            this.btnShowHide1.TabIndex = 43;
            this.btnShowHide1.Text = "Show";
            this.btnShowHide1.UseTransparentBackground = true;
            this.btnShowHide1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(94, 150);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(164, 17);
            this.guna2HtmlLabel3.TabIndex = 42;
            this.guna2HtmlLabel3.Text = "a string and unique password";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(76, 132);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(199, 17);
            this.guna2HtmlLabel2.TabIndex = 41;
            this.guna2HtmlLabel2.Text = "Keep youre account secure by using";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(76, 95);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(200, 31);
            this.guna2HtmlLabel1.TabIndex = 40;
            this.guna2HtmlLabel1.Text = "Change Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Animated = true;
            this.txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirmPassword.BorderColor = System.Drawing.Color.Blue;
            this.txtConfirmPassword.BorderRadius = 10;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(38, 325);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtConfirmPassword.PlaceholderText = "Confirm New Password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(279, 44);
            this.txtConfirmPassword.TabIndex = 32;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtbNewPassword
            // 
            this.txtbNewPassword.Animated = true;
            this.txtbNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtbNewPassword.BorderColor = System.Drawing.Color.Blue;
            this.txtbNewPassword.BorderRadius = 10;
            this.txtbNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbNewPassword.DefaultText = "";
            this.txtbNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbNewPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            this.txtbNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtbNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbNewPassword.Location = new System.Drawing.Point(38, 260);
            this.txtbNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtbNewPassword.Name = "txtbNewPassword";
            this.txtbNewPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtbNewPassword.PlaceholderText = "Enter New Password";
            this.txtbNewPassword.SelectedText = "";
            this.txtbNewPassword.Size = new System.Drawing.Size(279, 44);
            this.txtbNewPassword.TabIndex = 31;
            this.txtbNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbNewPassword_Validating);
            // 
            // txtbCurrentPassword
            // 
            this.txtbCurrentPassword.Animated = true;
            this.txtbCurrentPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtbCurrentPassword.BorderColor = System.Drawing.Color.Blue;
            this.txtbCurrentPassword.BorderRadius = 10;
            this.txtbCurrentPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbCurrentPassword.DefaultText = "";
            this.txtbCurrentPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbCurrentPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbCurrentPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbCurrentPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbCurrentPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(70)))));
            this.txtbCurrentPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbCurrentPassword.ForeColor = System.Drawing.Color.White;
            this.txtbCurrentPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbCurrentPassword.Location = new System.Drawing.Point(38, 194);
            this.txtbCurrentPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtbCurrentPassword.Name = "txtbCurrentPassword";
            this.txtbCurrentPassword.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtbCurrentPassword.PlaceholderText = "Current Password";
            this.txtbCurrentPassword.SelectedText = "";
            this.txtbCurrentPassword.Size = new System.Drawing.Size(279, 44);
            this.txtbCurrentPassword.TabIndex = 30;
            this.txtbCurrentPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbCurrentPassword_Validating);
            // 
            // btnSaveNewPassword
            // 
            this.btnSaveNewPassword.Animated = true;
            this.btnSaveNewPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveNewPassword.BorderColor = System.Drawing.Color.Blue;
            this.btnSaveNewPassword.BorderRadius = 10;
            this.btnSaveNewPassword.BorderThickness = 1;
            this.btnSaveNewPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveNewPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveNewPassword.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveNewPassword.FillColor = System.Drawing.Color.Blue;
            this.btnSaveNewPassword.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSaveNewPassword.ForeColor = System.Drawing.Color.White;
            this.btnSaveNewPassword.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnSaveNewPassword.Image = global::DVLD_Presentation_Layer.Properties.Resources.refresh;
            this.btnSaveNewPassword.IndicateFocus = true;
            this.btnSaveNewPassword.Location = new System.Drawing.Point(38, 393);
            this.btnSaveNewPassword.Name = "btnSaveNewPassword";
            this.btnSaveNewPassword.PressedColor = System.Drawing.Color.Blue;
            this.btnSaveNewPassword.Size = new System.Drawing.Size(279, 44);
            this.btnSaveNewPassword.TabIndex = 39;
            this.btnSaveNewPassword.Text = "Update Password";
            this.btnSaveNewPassword.UseTransparentBackground = true;
            this.btnSaveNewPassword.Click += new System.EventHandler(this.btnSaveNewPassword_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.user;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(19, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(48, 53);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 37;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnShowHide2
            // 
            this.btnShowHide2.Animated = true;
            this.btnShowHide2.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHide2.BorderColor = System.Drawing.Color.Navy;
            this.btnShowHide2.BorderRadius = 10;
            this.btnShowHide2.BorderThickness = 1;
            this.btnShowHide2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHide2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHide2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowHide2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowHide2.FillColor = System.Drawing.Color.Transparent;
            this.btnShowHide2.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.btnShowHide2.ForeColor = System.Drawing.Color.White;
            this.btnShowHide2.IndicateFocus = true;
            this.btnShowHide2.Location = new System.Drawing.Point(256, 272);
            this.btnShowHide2.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowHide2.Name = "btnShowHide2";
            this.btnShowHide2.Size = new System.Drawing.Size(51, 22);
            this.btnShowHide2.TabIndex = 44;
            this.btnShowHide2.Text = "Show";
            this.btnShowHide2.UseTransparentBackground = true;
            this.btnShowHide2.Click += new System.EventHandler(this.btnShowHide2_Click);
            // 
            // btnShowHide3
            // 
            this.btnShowHide3.Animated = true;
            this.btnShowHide3.BackColor = System.Drawing.Color.Transparent;
            this.btnShowHide3.BorderColor = System.Drawing.Color.Navy;
            this.btnShowHide3.BorderRadius = 10;
            this.btnShowHide3.BorderThickness = 1;
            this.btnShowHide3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHide3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHide3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowHide3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowHide3.FillColor = System.Drawing.Color.Transparent;
            this.btnShowHide3.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.btnShowHide3.ForeColor = System.Drawing.Color.White;
            this.btnShowHide3.IndicateFocus = true;
            this.btnShowHide3.Location = new System.Drawing.Point(256, 335);
            this.btnShowHide3.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowHide3.Name = "btnShowHide3";
            this.btnShowHide3.Size = new System.Drawing.Size(51, 22);
            this.btnShowHide3.TabIndex = 45;
            this.btnShowHide3.Text = "Show";
            this.btnShowHide3.UseTransparentBackground = true;
            this.btnShowHide3.Click += new System.EventHandler(this.btnShowHide3_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackgroundImage = global::DVLD_Presentation_Layer.Properties.Resources._0aab7292_f56e_4046_a026_82a5e2a985aa;
            this.guna2GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GroupBox1.Controls.Add(this.btnShowHide3);
            this.guna2GroupBox1.Controls.Add(this.btnShowHide2);
            this.guna2GroupBox1.Controls.Add(this.btnShowHide1);
            this.guna2GroupBox1.Controls.Add(this.txtbCurrentPassword);
            this.guna2GroupBox1.Controls.Add(this.btnSaveNewPassword);
            this.guna2GroupBox1.Controls.Add(this.txtbNewPassword);
            this.guna2GroupBox1.Controls.Add(this.txtConfirmPassword);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(864, 89);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(356, 465);
            this.guna2GroupBox1.TabIndex = 79;
            // 
            // ctrlSmallUserInfoCard1
            // 
            this.ctrlSmallUserInfoCard1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlSmallUserInfoCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlSmallUserInfoCard1.Location = new System.Drawing.Point(12, 89);
            this.ctrlSmallUserInfoCard1.Name = "ctrlSmallUserInfoCard1";
            this.ctrlSmallUserInfoCard1.Size = new System.Drawing.Size(846, 463);
            this.ctrlSmallUserInfoCard1.TabIndex = 77;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 5;
            this.guna2ControlBox1.BorderThickness = 1;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1177, 0);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 80;
            // 
            // btnMaximaze
            // 
            this.btnMaximaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximaze.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderRadius = 5;
            this.btnMaximaze.BorderThickness = 1;
            this.btnMaximaze.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximaze.Enabled = false;
            this.btnMaximaze.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.btnMaximaze.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMaximaze.IconColor = System.Drawing.Color.White;
            this.btnMaximaze.Location = new System.Drawing.Point(1126, 0);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 81;
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
            this.btnMinimize.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1074, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 82;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1235, 579);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.ctrlSmallUserInfoCard1);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.lblScreenMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmChangePassword";
            this.Text = "ChangePasswordScreen";
            this.Load += new System.EventHandler(this.ChangePasswordScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtbNewPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtbCurrentPassword;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserMessage;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblScreenMode;
        private Guna.UI2.WinForms.Guna2GradientButton btnSaveNewPassword;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private User_Controles.ctrlSmallUserInfoCard ctrlSmallUserInfoCard1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2Button btnShowHide1;
        private Guna.UI2.WinForms.Guna2Button btnShowHide3;
        private Guna.UI2.WinForms.Guna2Button btnShowHide2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
    }
}