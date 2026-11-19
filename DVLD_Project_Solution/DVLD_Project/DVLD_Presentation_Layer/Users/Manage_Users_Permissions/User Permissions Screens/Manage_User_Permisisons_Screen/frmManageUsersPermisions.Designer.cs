using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Manage_Users_Permissions.User_Permissions_Screens
{
    partial class frmManageUsersPermisions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.button1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtbFilterBy = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRecordsCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.showPermisionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addEditPermissionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dgvUsersPermissions = new GlobalCustomControls.MyGridView();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbFilterByActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientButton3 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ctrlTodaySystemOverview1 = new DVLD_Presentation_Layer.Global_Controls.Users_Controls.ctrlTodaySystemOverview();
            this.ctrlRolesUsersDistribution1 = new DVLD_Presentation_Layer.Global_Controls.Users_Controls.ctrlRolesUsersDistribution();
            this.ctrlWelcomeUser1 = new DVLD_Presentation_Layer.Main_Menue.Main_Menue_Controls.ctrlWelcomeUser();
            this.ctrlDataGridPagesMoving1 = new DVLD_Presentation_Layer.Global_Controls.ctrlDataGridPagesMoving();
            this.ctrlTotalOnlineUsers1 = new DVLD_Presentation_Layer.Global_Controls.Users_Controls.ctrlTotalOnlineUsers();
            this.ctrlTotalLockedUsers1 = new DVLD_Presentation_Layer.Global_Controls.Users_Controls.ctrlTotalLockedUsers();
            this.ctrlTotalRoles1 = new DVLD_Presentation_Layer.Global_Controls.Roles_Controls.ctrlTotalRoles();
            this.ctrlTotalInactiveUsers1 = new DVLD_Presentation_Layer.Global_Controls.Users_Controls.ctrlTotalInactiveUsers();
            this.ctrlTotalUsers1 = new DVLD_Presentation_Layer.Global_Controls.Users_Controls.ctrlTotalUsers();
            this.ctrlTotalActiveUsers1 = new DVLD_Presentation_Layer.Global_Controls.Users_Controls.ctrlTotalActiveUsers();
            this.guna2ContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersPermissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(51, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 29);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "Manage Users Permissions";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // button1
            // 
            this.button1.Animated = true;
            this.button1.AutoRoundedCorners = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BorderColor = System.Drawing.Color.Blue;
            this.button1.BorderThickness = 1;
            this.button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button1.FillColor = System.Drawing.Color.Blue;
            this.button1.FillColor2 = System.Drawing.Color.Aqua;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.button1.Image = global::DVLD_Presentation_Layer.Properties.Resources.add__1_;
            this.button1.IndicateFocus = true;
            this.button1.Location = new System.Drawing.Point(433, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 36);
            this.button1.TabIndex = 40;
            this.button1.Text = "Add Permissions";
            this.button1.UseTransparentBackground = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterBy.BorderColor = System.Drawing.Color.Blue;
            this.cbFilterBy.BorderRadius = 10;
            this.cbFilterBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterBy.ForeColor = System.Drawing.Color.White;
            this.cbFilterBy.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.cbFilterBy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbFilterBy.HoverState.ForeColor = System.Drawing.Color.White;
            this.cbFilterBy.ItemHeight = 30;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "User Id",
            "Person Id",
            "Full Name",
            "Users Name",
            "Is Active"});
            this.cbFilterBy.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbFilterBy.Location = new System.Drawing.Point(7, 6);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.ShadowDecoration.BorderRadius = 15;
            this.cbFilterBy.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.ShadowDecoration.Depth = 45;
            this.cbFilterBy.ShadowDecoration.Enabled = true;
            this.cbFilterBy.Size = new System.Drawing.Size(165, 36);
            this.cbFilterBy.StartIndex = 0;
            this.cbFilterBy.TabIndex = 42;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtbFilterBy
            // 
            this.txtbFilterBy.Animated = true;
            this.txtbFilterBy.BorderColor = System.Drawing.Color.Blue;
            this.txtbFilterBy.BorderRadius = 10;
            this.txtbFilterBy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbFilterBy.DefaultText = "";
            this.txtbFilterBy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbFilterBy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbFilterBy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbFilterBy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbFilterBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtbFilterBy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbFilterBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbFilterBy.ForeColor = System.Drawing.Color.White;
            this.txtbFilterBy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbFilterBy.Location = new System.Drawing.Point(178, 6);
            this.txtbFilterBy.Name = "txtbFilterBy";
            this.txtbFilterBy.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtbFilterBy.PlaceholderText = "Type here ...";
            this.txtbFilterBy.SelectedText = "";
            this.txtbFilterBy.Size = new System.Drawing.Size(241, 36);
            this.txtbFilterBy.TabIndex = 43;
            this.txtbFilterBy.Visible = false;
            this.txtbFilterBy.TextChanged += new System.EventHandler(this.txtbFilter_TextChanged);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.White;
            this.lblRecordsCount.Location = new System.Drawing.Point(773, 19);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(31, 23);
            this.lblRecordsCount.TabIndex = 46;
            this.lblRecordsCount.Text = "????";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(675, 19);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(92, 23);
            this.guna2HtmlLabel3.TabIndex = 45;
            this.guna2HtmlLabel3.Text = "Total Users : ";
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPermisionsToolStripMenuItem1,
            this.addEditPermissionsToolStripMenuItem1});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(186, 48);
            // 
            // showPermisionsToolStripMenuItem1
            // 
            this.showPermisionsToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.showPermisionsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.showPermisionsToolStripMenuItem1.Name = "showPermisionsToolStripMenuItem1";
            this.showPermisionsToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.showPermisionsToolStripMenuItem1.Text = "Show Permisions";
            this.showPermisionsToolStripMenuItem1.Click += new System.EventHandler(this.showPermisionsToolStripMenuItem_Click);
            // 
            // addEditPermissionsToolStripMenuItem1
            // 
            this.addEditPermissionsToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.addEditPermissionsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.addEditPermissionsToolStripMenuItem1.Name = "addEditPermissionsToolStripMenuItem1";
            this.addEditPermissionsToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.addEditPermissionsToolStripMenuItem1.Text = "Add Edit Permissions";
            this.addEditPermissionsToolStripMenuItem1.Click += new System.EventHandler(this.addEditPermissionsToolStripMenuItem_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::DVLD_Presentation_Layer.Properties.Resources.bus_driver;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(11, 6);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(34, 39);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 39;
            this.guna2PictureBox2.TabStop = false;
            // 
            // dgvUsersPermissions
            // 
            this.dgvUsersPermissions.AllowUserToAddRows = false;
            this.dgvUsersPermissions.AllowUserToDeleteRows = false;
            this.dgvUsersPermissions.AllowUserToOrderColumns = true;
            this.dgvUsersPermissions.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsersPermissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsersPermissions.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvUsersPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvUsersPermissions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvUsersPermissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsersPermissions.ColumnHeadersHeight = 40;
            this.dgvUsersPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvUsersPermissions.ContextMenuStrip = this.guna2ContextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsersPermissions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsersPermissions.GridColor = System.Drawing.Color.Blue;
            this.dgvUsersPermissions.Location = new System.Drawing.Point(17, 117);
            this.dgvUsersPermissions.Name = "dgvUsersPermissions";
            this.dgvUsersPermissions.ReadOnly = true;
            this.dgvUsersPermissions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsersPermissions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsersPermissions.RowHeadersVisible = false;
            this.dgvUsersPermissions.Size = new System.Drawing.Size(826, 231);
            this.dgvUsersPermissions.TabIndex = 77;
            this.dgvUsersPermissions.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.dgvUsersPermissions.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dgvUsersPermissions.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsersPermissions.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvUsersPermissions.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsersPermissions.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvUsersPermissions.ThemeStyle.GridColor = System.Drawing.Color.Blue;
            this.dgvUsersPermissions.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.dgvUsersPermissions.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsersPermissions.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsersPermissions.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvUsersPermissions.ThemeStyle.ReadOnly = true;
            this.dgvUsersPermissions.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvUsersPermissions.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvUsersPermissions.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsersPermissions.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvUsersPermissions.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvUsersPermissions.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.bus_driver;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(17, 9);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(34, 39);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 58;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(57, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(232, 26);
            this.guna2HtmlLabel1.TabIndex = 57;
            this.guna2HtmlLabel1.Text = "Manage Users Permissions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(69, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Show add edit user permissions /roles";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.cbFilterByActive);
            this.guna2GroupBox1.Controls.Add(this.guna2GradientButton2);
            this.guna2GroupBox1.Controls.Add(this.guna2GradientButton3);
            this.guna2GroupBox1.Controls.Add(this.txtbFilterBy);
            this.guna2GroupBox1.Controls.Add(this.cbFilterBy);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(17, 54);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(826, 49);
            this.guna2GroupBox1.TabIndex = 78;
            // 
            // cbFilterByActive
            // 
            this.cbFilterByActive.BackColor = System.Drawing.Color.Transparent;
            this.cbFilterByActive.BorderColor = System.Drawing.Color.Blue;
            this.cbFilterByActive.BorderRadius = 10;
            this.cbFilterByActive.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterByActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilterByActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterByActive.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterByActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterByActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilterByActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFilterByActive.ForeColor = System.Drawing.Color.White;
            this.cbFilterByActive.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.cbFilterByActive.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbFilterByActive.HoverState.ForeColor = System.Drawing.Color.White;
            this.cbFilterByActive.ItemHeight = 30;
            this.cbFilterByActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbFilterByActive.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterByActive.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterByActive.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbFilterByActive.Location = new System.Drawing.Point(178, 6);
            this.cbFilterByActive.Name = "cbFilterByActive";
            this.cbFilterByActive.ShadowDecoration.BorderRadius = 15;
            this.cbFilterByActive.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterByActive.ShadowDecoration.Depth = 45;
            this.cbFilterByActive.ShadowDecoration.Enabled = true;
            this.cbFilterByActive.Size = new System.Drawing.Size(165, 36);
            this.cbFilterByActive.StartIndex = 0;
            this.cbFilterByActive.TabIndex = 60;
            this.cbFilterByActive.Visible = false;
            this.cbFilterByActive.SelectedIndexChanged += new System.EventHandler(this.cbFilterByActive_SelectedIndexChanged);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.Animated = true;
            this.guna2GradientButton2.AnimatedGIF = true;
            this.guna2GradientButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BorderColor = System.Drawing.Color.Blue;
            this.guna2GradientButton2.BorderRadius = 10;
            this.guna2GradientButton2.BorderThickness = 1;
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientButton2.IndicateFocus = true;
            this.guna2GradientButton2.Location = new System.Drawing.Point(678, 8);
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Size = new System.Drawing.Size(135, 34);
            this.guna2GradientButton2.TabIndex = 59;
            this.guna2GradientButton2.Text = "Hard Refresh";
            this.guna2GradientButton2.UseTransparentBackground = true;
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // guna2GradientButton3
            // 
            this.guna2GradientButton3.Animated = true;
            this.guna2GradientButton3.AutoRoundedCorners = true;
            this.guna2GradientButton3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.BorderColor = System.Drawing.Color.Cyan;
            this.guna2GradientButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton3.FillColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.FocusedColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GradientButton3.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientButton3.Image = global::DVLD_Presentation_Layer.Properties.Resources.refresh;
            this.guna2GradientButton3.Location = new System.Drawing.Point(430, 8);
            this.guna2GradientButton3.Name = "guna2GradientButton3";
            this.guna2GradientButton3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2GradientButton3.Size = new System.Drawing.Size(46, 34);
            this.guna2GradientButton3.TabIndex = 58;
            this.guna2GradientButton3.UseTransparentBackground = true;
            this.guna2GradientButton3.Click += new System.EventHandler(this.guna2GradientButton3_Click);
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox2.BorderRadius = 10;
            this.guna2GroupBox2.Controls.Add(this.guna2GroupBox1);
            this.guna2GroupBox2.Controls.Add(this.dgvUsersPermissions);
            this.guna2GroupBox2.Controls.Add(this.guna2PictureBox1);
            this.guna2GroupBox2.Controls.Add(this.ctrlDataGridPagesMoving1);
            this.guna2GroupBox2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox2.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GroupBox2.Controls.Add(this.button1);
            this.guna2GroupBox2.Controls.Add(this.lblRecordsCount);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(439, 196);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(860, 399);
            this.guna2GroupBox2.TabIndex = 79;
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
            this.guna2ControlBox1.Location = new System.Drawing.Point(1287, 2);
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
            this.btnMinimize.Location = new System.Drawing.Point(1184, 2);
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
            this.btnMaximaze.Location = new System.Drawing.Point(1236, 2);
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            this.btnMaximaze.Size = new System.Drawing.Size(46, 43);
            this.btnMaximaze.TabIndex = 84;
            // 
            // ctrlTodaySystemOverview1
            // 
            this.ctrlTodaySystemOverview1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTodaySystemOverview1.Location = new System.Drawing.Point(39, 183);
            this.ctrlTodaySystemOverview1.Name = "ctrlTodaySystemOverview1";
            this.ctrlTodaySystemOverview1.Size = new System.Drawing.Size(368, 120);
            this.ctrlTodaySystemOverview1.TabIndex = 82;
            // 
            // ctrlRolesUsersDistribution1
            // 
            this.ctrlRolesUsersDistribution1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlRolesUsersDistribution1.Location = new System.Drawing.Point(39, 305);
            this.ctrlRolesUsersDistribution1.Name = "ctrlRolesUsersDistribution1";
            this.ctrlRolesUsersDistribution1.Size = new System.Drawing.Size(375, 421);
            this.ctrlRolesUsersDistribution1.TabIndex = 81;
            // 
            // ctrlWelcomeUser1
            // 
            this.ctrlWelcomeUser1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlWelcomeUser1.Location = new System.Drawing.Point(83, 70);
            this.ctrlWelcomeUser1.Name = "ctrlWelcomeUser1";
            this.ctrlWelcomeUser1.Size = new System.Drawing.Size(157, 99);
            this.ctrlWelcomeUser1.TabIndex = 80;
            // 
            // ctrlDataGridPagesMoving1
            // 
            this.ctrlDataGridPagesMoving1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDataGridPagesMoving1.CurrentPage = 1;
            this.ctrlDataGridPagesMoving1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ctrlDataGridPagesMoving1.ItemsPerPage = ((short)(10));
            this.ctrlDataGridPagesMoving1.Location = new System.Drawing.Point(17, 354);
            this.ctrlDataGridPagesMoving1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlDataGridPagesMoving1.Name = "ctrlDataGridPagesMoving1";
            this.ctrlDataGridPagesMoving1.Size = new System.Drawing.Size(826, 42);
            this.ctrlDataGridPagesMoving1.TabIndex = 47;
            this.ctrlDataGridPagesMoving1.OnButtonClicked += new System.Action(this.ctrlDataGridPagesMoving1_OnButtonClicked);
            // 
            // ctrlTotalOnlineUsers1
            // 
            this.ctrlTotalOnlineUsers1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalOnlineUsers1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalOnlineUsers1.Location = new System.Drawing.Point(733, 62);
            this.ctrlTotalOnlineUsers1.Name = "ctrlTotalOnlineUsers1";
            this.ctrlTotalOnlineUsers1.Size = new System.Drawing.Size(283, 128);
            this.ctrlTotalOnlineUsers1.TabIndex = 54;
            // 
            // ctrlTotalLockedUsers1
            // 
            this.ctrlTotalLockedUsers1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalLockedUsers1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalLockedUsers1.Location = new System.Drawing.Point(1026, 598);
            this.ctrlTotalLockedUsers1.Name = "ctrlTotalLockedUsers1";
            this.ctrlTotalLockedUsers1.Size = new System.Drawing.Size(287, 128);
            this.ctrlTotalLockedUsers1.TabIndex = 53;
            // 
            // ctrlTotalRoles1
            // 
            this.ctrlTotalRoles1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalRoles1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalRoles1.Location = new System.Drawing.Point(1022, 61);
            this.ctrlTotalRoles1.Name = "ctrlTotalRoles1";
            this.ctrlTotalRoles1.Size = new System.Drawing.Size(288, 129);
            this.ctrlTotalRoles1.TabIndex = 51;
            // 
            // ctrlTotalInactiveUsers1
            // 
            this.ctrlTotalInactiveUsers1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalInactiveUsers1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalInactiveUsers1.Location = new System.Drawing.Point(439, 598);
            this.ctrlTotalInactiveUsers1.Name = "ctrlTotalInactiveUsers1";
            this.ctrlTotalInactiveUsers1.Size = new System.Drawing.Size(286, 131);
            this.ctrlTotalInactiveUsers1.TabIndex = 50;
            // 
            // ctrlTotalUsers1
            // 
            this.ctrlTotalUsers1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalUsers1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalUsers1.Location = new System.Drawing.Point(439, 62);
            this.ctrlTotalUsers1.Name = "ctrlTotalUsers1";
            this.ctrlTotalUsers1.Size = new System.Drawing.Size(288, 131);
            this.ctrlTotalUsers1.TabIndex = 49;
            // 
            // ctrlTotalActiveUsers1
            // 
            this.ctrlTotalActiveUsers1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalActiveUsers1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.ctrlTotalActiveUsers1.Location = new System.Drawing.Point(731, 598);
            this.ctrlTotalActiveUsers1.Name = "ctrlTotalActiveUsers1";
            this.ctrlTotalActiveUsers1.Size = new System.Drawing.Size(289, 134);
            this.ctrlTotalActiveUsers1.TabIndex = 48;
            // 
            // frmManageUsersPermisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1339, 788);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.ctrlTodaySystemOverview1);
            this.Controls.Add(this.ctrlRolesUsersDistribution1);
            this.Controls.Add(this.ctrlWelcomeUser1);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlTotalOnlineUsers1);
            this.Controls.Add(this.ctrlTotalLockedUsers1);
            this.Controls.Add(this.ctrlTotalRoles1);
            this.Controls.Add(this.ctrlTotalInactiveUsers1);
            this.Controls.Add(this.ctrlTotalUsers1);
            this.Controls.Add(this.ctrlTotalActiveUsers1);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageUsersPermisions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ManageUsersPermisions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManageUsersPermisions_Load);
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersPermissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientButton button1;
        private Guna.UI2.WinForms.Guna2TextBox txtbFilterBy;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Global_Controls.ctrlDataGridPagesMoving ctrlDataGridPagesMoving1;
        private Global_Controls.Users_Controls.ctrlTotalUsers ctrlTotalUsers1;
        private Global_Controls.Users_Controls.ctrlTotalActiveUsers ctrlTotalActiveUsers1;
        private Global_Controls.Roles_Controls.ctrlTotalRoles ctrlTotalRoles1;
        private Global_Controls.Users_Controls.ctrlTotalInactiveUsers ctrlTotalInactiveUsers1;
        private Global_Controls.Users_Controls.ctrlTotalLockedUsers ctrlTotalLockedUsers1;
        private Global_Controls.Users_Controls.ctrlTotalOnlineUsers ctrlTotalOnlineUsers1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecordsCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPermisionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addEditPermissionsToolStripMenuItem1;
        private GlobalCustomControls.MyGridView dgvUsersPermissions;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton3;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Global_Controls.Users_Controls.ctrlTodaySystemOverview ctrlTodaySystemOverview1;
        private Global_Controls.Users_Controls.ctrlRolesUsersDistribution ctrlRolesUsersDistribution1;
        private Main_Menue.Main_Menue_Controls.ctrlWelcomeUser ctrlWelcomeUser1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterByActive;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
    }
}