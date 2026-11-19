namespace DVLD_Presentation_Layer.Users
{
    partial class frmShowUserInfoScreen
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
            this.guna2PictureBox10 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblUserMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ctrlUserLoginInfo1 = new DVLD_Presentation_Layer.Users.UserControles.ctrlUserLoginInfo1();
            this.ctrlSmallUserInfoCard1 = new DVLD_Presentation_Layer.Users.User_Controles.ctrlSmallUserInfoCard();
            this.btnEditUserInfo = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox10
            // 
            this.guna2PictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox10.BorderRadius = 10;
            this.guna2PictureBox10.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox10.Image = global::DVLD_Presentation_Layer.Properties.Resources.user1;
            this.guna2PictureBox10.ImageRotate = 0F;
            this.guna2PictureBox10.Location = new System.Drawing.Point(5, 7);
            this.guna2PictureBox10.Name = "guna2PictureBox10";
            this.guna2PictureBox10.Size = new System.Drawing.Size(61, 52);
            this.guna2PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox10.TabIndex = 23;
            this.guna2PictureBox10.TabStop = false;
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblUserMessage.Location = new System.Drawing.Point(97, 37);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(185, 22);
            this.lblUserMessage.TabIndex = 22;
            this.lblUserMessage.Text = "Show User information";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(72, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 31);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "User information";
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
            // ctrlUserLoginInfo1
            // 
            this.ctrlUserLoginInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlUserLoginInfo1.Location = new System.Drawing.Point(84, 415);
            this.ctrlUserLoginInfo1.Name = "ctrlUserLoginInfo1";
            this.ctrlUserLoginInfo1.Size = new System.Drawing.Size(824, 115);
            this.ctrlUserLoginInfo1.TabIndex = 1;
            // 
            // ctrlSmallUserInfoCard1
            // 
            this.ctrlSmallUserInfoCard1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlSmallUserInfoCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlSmallUserInfoCard1.Location = new System.Drawing.Point(13, 123);
            this.ctrlSmallUserInfoCard1.Name = "ctrlSmallUserInfoCard1";
            this.ctrlSmallUserInfoCard1.Size = new System.Drawing.Size(852, 467);
            this.ctrlSmallUserInfoCard1.TabIndex = 80;
            // 
            // btnEditUserInfo
            // 
            this.btnEditUserInfo.BorderColor = System.Drawing.Color.Blue;
            this.btnEditUserInfo.BorderRadius = 10;
            this.btnEditUserInfo.BorderThickness = 1;
            this.btnEditUserInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditUserInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditUserInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditUserInfo.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditUserInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditUserInfo.FillColor = System.Drawing.Color.Transparent;
            this.btnEditUserInfo.FillColor2 = System.Drawing.Color.Transparent;
            this.btnEditUserInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEditUserInfo.ForeColor = System.Drawing.Color.White;
            this.btnEditUserInfo.Location = new System.Drawing.Point(690, 75);
            this.btnEditUserInfo.Name = "btnEditUserInfo";
            this.btnEditUserInfo.Size = new System.Drawing.Size(169, 42);
            this.btnEditUserInfo.TabIndex = 81;
            this.btnEditUserInfo.Text = "Edit User Info";
            this.btnEditUserInfo.Click += new System.EventHandler(this.btnEditUserInfo_Click);
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(819, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.guna2ControlBox1.Size = new System.Drawing.Size(46, 43);
            this.guna2ControlBox1.TabIndex = 82;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
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
            this.btnMinimize.Location = new System.Drawing.Point(716, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMinimize.Size = new System.Drawing.Size(46, 43);
            this.btnMinimize.TabIndex = 84;
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
            this.btnMaximaze.Location = new System.Drawing.Point(768, 2);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 83;
            // 
            // frmShowUserInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(871, 602);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.btnEditUserInfo);
            this.Controls.Add(this.ctrlSmallUserInfoCard1);
            this.Controls.Add(this.guna2PictureBox10);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowUserInfoScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowUserInfoScreen";
            this.Load += new System.EventHandler(this.ShowUserInfoScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private UserControles.ctrlUserLoginInfo1 ctrlUserLoginInfo1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox10;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserMessage;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private User_Controles.ctrlSmallUserInfoCard ctrlSmallUserInfoCard1;
        private Guna.UI2.WinForms.Guna2GradientButton btnEditUserInfo;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
    }
}