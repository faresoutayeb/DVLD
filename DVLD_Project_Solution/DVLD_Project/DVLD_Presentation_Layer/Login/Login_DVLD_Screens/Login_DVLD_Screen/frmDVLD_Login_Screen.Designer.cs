using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Presentation_Layer
{
    partial class frmDVLD_Login_Screen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDVLD_Login_Screen));
            this.ErrorPLoginScreen = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtbUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.chkRememberMe = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox4 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnShowHide2 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPLoginScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorPLoginScreen
            // 
            this.ErrorPLoginScreen.ContainerControl = this;
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.BorderColor = System.Drawing.Color.Blue;
            this.btnLogin.BorderRadius = 10;
            this.btnLogin.BorderThickness = 1;
            this.btnLogin.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FillColor2 = System.Drawing.Color.Transparent;
            this.btnLogin.FocusedColor = System.Drawing.Color.Transparent;
            this.btnLogin.Font = new System.Drawing.Font("Elephant", 12.25F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ErrorPLoginScreen.SetIconAlignment(this.btnLogin, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.btnLogin.Image = global::DVLD_Presentation_Layer.Properties.Resources.enter;
            this.btnLogin.IndicateFocus = true;
            this.btnLogin.Location = new System.Drawing.Point(524, 357);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(258, 36);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseTransparentBackground = true;
            this.btnLogin.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // txtbUserName
            // 
            this.txtbUserName.Animated = true;
            this.txtbUserName.BackColor = System.Drawing.Color.Transparent;
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
            this.txtbUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtbUserName.ForeColor = System.Drawing.Color.White;
            this.txtbUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbUserName.Location = new System.Drawing.Point(524, 209);
            this.txtbUserName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtbUserName.Name = "txtbUserName";
            this.txtbUserName.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtbUserName.PlaceholderText = "Type UserName";
            this.txtbUserName.SelectedText = "";
            this.txtbUserName.Size = new System.Drawing.Size(258, 42);
            this.txtbUserName.TabIndex = 8;
            this.txtbUserName.TextChanged += new System.EventHandler(this.txtbUserName_TextChanged);
            this.txtbUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtbUserName_Validating);
            // 
            // txtbPassword
            // 
            this.txtbPassword.Animated = true;
            this.txtbPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtbPassword.BorderColor = System.Drawing.Color.Blue;
            this.txtbPassword.BorderRadius = 10;
            this.txtbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbPassword.DefaultText = "";
            this.txtbPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtbPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtbPassword.ForeColor = System.Drawing.Color.White;
            this.txtbPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbPassword.Location = new System.Drawing.Point(524, 269);
            this.txtbPassword.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtbPassword.Name = "txtbPassword";
            this.txtbPassword.PasswordChar = '*';
            this.txtbPassword.PlaceholderForeColor = System.Drawing.Color.White;
            this.txtbPassword.PlaceholderText = "Type Your Password";
            this.txtbPassword.SelectedText = "";
            this.txtbPassword.Size = new System.Drawing.Size(258, 42);
            this.txtbPassword.TabIndex = 9;
            this.txtbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtbPassword_Validating);
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.Animated = true;
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.chkRememberMe.Checked = true;
            this.chkRememberMe.CheckedState.BorderColor = System.Drawing.Color.Blue;
            this.chkRememberMe.CheckedState.BorderRadius = 5;
            this.chkRememberMe.CheckedState.BorderThickness = 1;
            this.chkRememberMe.CheckedState.FillColor = System.Drawing.Color.Black;
            this.chkRememberMe.CheckMarkColor = System.Drawing.Color.Blue;
            this.chkRememberMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRememberMe.Font = new System.Drawing.Font("Elephant", 10.25F);
            this.chkRememberMe.ForeColor = System.Drawing.Color.White;
            this.chkRememberMe.Location = new System.Drawing.Point(653, 318);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(129, 22);
            this.chkRememberMe.TabIndex = 11;
            this.chkRememberMe.Text = "Remember Me";
            this.chkRememberMe.UncheckedState.BorderColor = System.Drawing.Color.Cyan;
            this.chkRememberMe.UncheckedState.BorderRadius = 5;
            this.chkRememberMe.UncheckedState.BorderThickness = 1;
            this.chkRememberMe.UncheckedState.FillColor = System.Drawing.Color.Black;
            this.chkRememberMe.UseVisualStyleBackColor = false;
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(800, 1);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 71;
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
            this.btnMaximaze.Location = new System.Drawing.Point(749, 1);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 72;
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
            this.btnMinimize.Location = new System.Drawing.Point(697, 1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 73;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimationInterval = 0;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.BorderRadius = 5;
            this.guna2ControlBox2.BorderThickness = 1;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1438, -6);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox2.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox2.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox2.TabIndex = 77;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.BorderRadius = 5;
            this.guna2ControlBox3.BorderThickness = 1;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.guna2ControlBox3.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(1387, -6);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox3.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox3.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox3.TabIndex = 78;
            // 
            // guna2ControlBox4
            // 
            this.guna2ControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.BorderRadius = 5;
            this.guna2ControlBox4.BorderThickness = 1;
            this.guna2ControlBox4.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox4.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox4.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.guna2ControlBox4.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox4.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox4.Location = new System.Drawing.Point(1335, -6);
            this.guna2ControlBox4.Name = "guna2ControlBox4";
            this.guna2ControlBox4.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox4.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox4.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox4.TabIndex = 79;
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
            this.btnShowHide2.Location = new System.Drawing.Point(721, 278);
            this.btnShowHide2.Margin = new System.Windows.Forms.Padding(0);
            this.btnShowHide2.Name = "btnShowHide2";
            this.btnShowHide2.Size = new System.Drawing.Size(51, 22);
            this.btnShowHide2.TabIndex = 80;
            this.btnShowHide2.Text = "Show";
            this.btnShowHide2.UseTransparentBackground = true;
            this.btnShowHide2.Click += new System.EventHandler(this.btnShowHide2_Click);
            // 
            // frmDVLD_Login_Screen
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImage = global::DVLD_Presentation_Layer.Properties.Resources.Login_Image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 551);
            this.Controls.Add(this.btnShowHide2);
            this.Controls.Add(this.guna2ControlBox2);
            this.Controls.Add(this.guna2ControlBox3);
            this.Controls.Add(this.guna2ControlBox4);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.chkRememberMe);
            this.Controls.Add(this.txtbPassword);
            this.Controls.Add(this.txtbUserName);
            this.Controls.Add(this.btnLogin);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmDVLD_Login_Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Screen";
            this.Load += new System.EventHandler(this.DVLD_Login_Screen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorPLoginScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider ErrorPLoginScreen;
        private Guna.UI2.WinForms.Guna2CheckBox chkRememberMe;
        private Guna.UI2.WinForms.Guna2TextBox txtbPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtbUserName;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox4;
        private Guna.UI2.WinForms.Guna2Button btnShowHide2;
    }
}

