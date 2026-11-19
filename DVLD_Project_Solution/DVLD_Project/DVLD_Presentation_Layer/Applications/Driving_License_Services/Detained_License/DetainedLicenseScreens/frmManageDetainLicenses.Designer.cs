using System.Windows.Forms;

namespace DVLD_Presentation_Layer.Detained_License.Manage_Detain_Licenses_Screens
{
    partial class frmManageDetainLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDetainLicenses));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRelease = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblUserMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnDetainLicense = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel14 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblTotalCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dgvDetainedLicenses = new GlobalCustomControls.MyGridView();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbIsReleaseFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbFilterBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2GradientButton2 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrlDataGridPagesMoving2 = new DVLD_Presentation_Layer.Global_Controls.ctrlDataGridPagesMoving();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximaze = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ctrlActualDateTime1 = new DVLD_Presentation_Layer.Global_Controls.ctrlActualDateTime();
            this.ctrlRecentDetainActivities1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlRecentDetainActivities();
            this.ctrlDetainReasons_Top5_1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlDetainReasons_Top5_();
            this.ctrlNewDetentionsThisMonth1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsThisMonth();
            this.ctrlNewDetentionsLast30Days1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsLast30Days();
            this.ctrlFinesOverview1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlFinesOverview();
            this.ctrlTotalCurrentlyDetainedLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalCurrentlyDetainedLicenses();
            this.ctrlTotalReleasedLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalReleasedLicenses();
            this.ctrlTotalDetainedLicenses1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedLicenses();
            this.ctrlTotalDetainedFees1 = new DVLD_Presentation_Layer.Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedFees();
            this.ctrlDataGridPagesMoving1 = new DVLD_Presentation_Layer.Global_Controls.ctrlDataGridPagesMoving();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRelease
            // 
            this.btnRelease.Animated = true;
            this.btnRelease.AnimatedGIF = true;
            this.btnRelease.AutoRoundedCorners = true;
            this.btnRelease.BorderColor = System.Drawing.Color.Blue;
            this.btnRelease.BorderRadius = 16;
            this.btnRelease.BorderThickness = 1;
            this.btnRelease.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRelease.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRelease.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRelease.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRelease.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRelease.FillColor = System.Drawing.Color.Blue;
            this.btnRelease.FillColor2 = System.Drawing.Color.Lime;
            resources.ApplyResources(this.btnRelease, "btnRelease");
            this.btnRelease.ForeColor = System.Drawing.Color.White;
            this.btnRelease.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblUserMessage, "lblUserMessage");
            this.lblUserMessage.ForeColor = System.Drawing.Color.Blue;
            this.lblUserMessage.Name = "lblUserMessage";
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
            // btnDetainLicense
            // 
            this.btnDetainLicense.Animated = true;
            this.btnDetainLicense.AnimatedGIF = true;
            this.btnDetainLicense.AutoRoundedCorners = true;
            this.btnDetainLicense.BorderColor = System.Drawing.Color.Blue;
            this.btnDetainLicense.BorderRadius = 16;
            this.btnDetainLicense.BorderThickness = 1;
            this.btnDetainLicense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetainLicense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetainLicense.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetainLicense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetainLicense.FillColor = System.Drawing.Color.Blue;
            this.btnDetainLicense.FillColor2 = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnDetainLicense, "btnDetainLicense");
            this.btnDetainLicense.ForeColor = System.Drawing.Color.White;
            this.btnDetainLicense.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Animated = true;
            this.txtFilterValue.BorderColor = System.Drawing.Color.Blue;
            this.txtFilterValue.BorderRadius = 10;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtFilterValue, "txtFilterValue");
            this.txtFilterValue.ForeColor = System.Drawing.Color.White;
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PlaceholderText = "Type here ...";
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged_1);
            // 
            // guna2HtmlLabel14
            // 
            this.guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2HtmlLabel14, "guna2HtmlLabel14");
            this.guna2HtmlLabel14.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.Animated = true;
            this.guna2GradientButton1.AnimatedGIF = true;
            this.guna2GradientButton1.BorderColor = System.Drawing.Color.Blue;
            this.guna2GradientButton1.BorderRadius = 10;
            this.guna2GradientButton1.BorderThickness = 1;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2GradientButton1, "guna2GradientButton1");
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientButton1.IndicateFocus = true;
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.UseTransparentBackground = true;
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click_1);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblTotalCount, "lblTotalCount");
            this.lblTotalCount.ForeColor = System.Drawing.Color.White;
            this.lblTotalCount.Name = "lblTotalCount";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2HtmlLabel2, "guna2HtmlLabel2");
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2HtmlLabel3, "guna2HtmlLabel3");
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::DVLD_Presentation_Layer.Properties.Resources.software_license1;
            this.guna2PictureBox2.ImageRotate = 0F;
            resources.ApplyResources(this.guna2PictureBox2, "guna2PictureBox2");
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DVLD_Presentation_Layer.Properties.Resources.software_license1;
            this.guna2PictureBox1.ImageRotate = 0F;
            resources.ApplyResources(this.guna2PictureBox1, "guna2PictureBox1");
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.TabStop = false;
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToOrderColumns = true;
            this.dgvDetainedLicenses.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetainedLicenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetainedLicenses.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvDetainedLicenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDetainedLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvDetainedLicenses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainedLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvDetainedLicenses, "dgvDetainedLicenses");
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvDetainedLicenses.ContextMenuStrip = this.guna2ContextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetainedLicenses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetainedLicenses.GridColor = System.Drawing.Color.Blue;
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetainedLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetainedLicenses.RowHeadersVisible = false;
            this.dgvDetainedLicenses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.dgvDetainedLicenses.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.dgvDetainedLicenses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDetainedLicenses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvDetainedLicenses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetainedLicenses.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvDetainedLicenses.ThemeStyle.GridColor = System.Drawing.Color.Blue;
            this.dgvDetainedLicenses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.dgvDetainedLicenses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetainedLicenses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDetainedLicenses.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDetainedLicenses.ThemeStyle.ReadOnly = true;
            this.dgvDetainedLicenses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.dgvDetainedLicenses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvDetainedLicenses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDetainedLicenses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvDetainedLicenses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvDetainedLicenses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem1,
            this.showPersonLicenseHistoryToolStripMenuItem1,
            this.releaseDetainedLicenseToolStripMenuItem1});
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
            resources.ApplyResources(this.guna2ContextMenuStrip1, "guna2ContextMenuStrip1");
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.showPersonDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            resources.ApplyResources(this.showPersonDetailsToolStripMenuItem, "showPersonDetailsToolStripMenuItem");
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem1
            // 
            this.showLicenseDetailsToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.showLicenseDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.showLicenseDetailsToolStripMenuItem1.Name = "showLicenseDetailsToolStripMenuItem1";
            resources.ApplyResources(this.showLicenseDetailsToolStripMenuItem1, "showLicenseDetailsToolStripMenuItem1");
            this.showLicenseDetailsToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem1_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem1
            // 
            this.showPersonLicenseHistoryToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.showPersonLicenseHistoryToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.showPersonLicenseHistoryToolStripMenuItem1.Name = "showPersonLicenseHistoryToolStripMenuItem1";
            resources.ApplyResources(this.showPersonLicenseHistoryToolStripMenuItem1, "showPersonLicenseHistoryToolStripMenuItem1");
            this.showPersonLicenseHistoryToolStripMenuItem1.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem1_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem1
            // 
            this.releaseDetainedLicenseToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.releaseDetainedLicenseToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.releaseDetainedLicenseToolStripMenuItem1.Name = "releaseDetainedLicenseToolStripMenuItem1";
            resources.ApplyResources(this.releaseDetainedLicenseToolStripMenuItem1, "releaseDetainedLicenseToolStripMenuItem1");
            this.releaseDetainedLicenseToolStripMenuItem1.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem1_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.Controls.Add(this.guna2GroupBox2);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2GroupBox1.Controls.Add(this.dgvDetainedLicenses);
            this.guna2GroupBox1.Controls.Add(this.ctrlDataGridPagesMoving2);
            this.guna2GroupBox1.Controls.Add(this.btnRelease);
            this.guna2GroupBox1.Controls.Add(this.btnDetainLicense);
            this.guna2GroupBox1.Controls.Add(this.lblTotalCount);
            this.guna2GroupBox1.Controls.Add(this.guna2PictureBox2);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2GroupBox1, "guna2GroupBox1");
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox2.BorderRadius = 10;
            this.guna2GroupBox2.Controls.Add(this.cbIsReleaseFilter);
            this.guna2GroupBox2.Controls.Add(this.cbFilterBy);
            this.guna2GroupBox2.Controls.Add(this.guna2GradientButton2);
            this.guna2GroupBox2.Controls.Add(this.guna2GradientButton1);
            this.guna2GroupBox2.Controls.Add(this.txtFilterValue);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.Blue;
            this.guna2GroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2GroupBox2, "guna2GroupBox2");
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            // 
            // cbIsReleaseFilter
            // 
            this.cbIsReleaseFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbIsReleaseFilter.BorderColor = System.Drawing.Color.Blue;
            this.cbIsReleaseFilter.BorderRadius = 10;
            this.cbIsReleaseFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbIsReleaseFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsReleaseFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleaseFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbIsReleaseFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsReleaseFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.cbIsReleaseFilter, "cbIsReleaseFilter");
            this.cbIsReleaseFilter.ForeColor = System.Drawing.Color.White;
            this.cbIsReleaseFilter.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.cbIsReleaseFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbIsReleaseFilter.HoverState.ForeColor = System.Drawing.Color.White;
            this.cbIsReleaseFilter.Items.AddRange(new object[] {
            resources.GetString("cbIsReleaseFilter.Items"),
            resources.GetString("cbIsReleaseFilter.Items1"),
            resources.GetString("cbIsReleaseFilter.Items2")});
            this.cbIsReleaseFilter.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbIsReleaseFilter.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbIsReleaseFilter.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbIsReleaseFilter.Name = "cbIsReleaseFilter";
            this.cbIsReleaseFilter.ShadowDecoration.BorderRadius = 15;
            this.cbIsReleaseFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbIsReleaseFilter.ShadowDecoration.Depth = 45;
            this.cbIsReleaseFilter.ShadowDecoration.Enabled = true;
            this.cbIsReleaseFilter.StartIndex = 0;
            this.cbIsReleaseFilter.SelectedIndexChanged += new System.EventHandler(this.cbIsReleaseFilter_SelectedIndexChanged);
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
            resources.ApplyResources(this.cbFilterBy, "cbFilterBy");
            this.cbFilterBy.ForeColor = System.Drawing.Color.White;
            this.cbFilterBy.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.cbFilterBy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbFilterBy.HoverState.ForeColor = System.Drawing.Color.White;
            this.cbFilterBy.Items.AddRange(new object[] {
            resources.GetString("cbFilterBy.Items"),
            resources.GetString("cbFilterBy.Items1"),
            resources.GetString("cbFilterBy.Items2"),
            resources.GetString("cbFilterBy.Items3"),
            resources.GetString("cbFilterBy.Items4"),
            resources.GetString("cbFilterBy.Items5")});
            this.cbFilterBy.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.ShadowDecoration.BorderRadius = 15;
            this.cbFilterBy.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.cbFilterBy.ShadowDecoration.Depth = 45;
            this.cbFilterBy.ShadowDecoration.Enabled = true;
            this.cbFilterBy.StartIndex = 0;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged_1);
            // 
            // guna2GradientButton2
            // 
            this.guna2GradientButton2.Animated = true;
            this.guna2GradientButton2.AnimatedGIF = true;
            this.guna2GradientButton2.AutoRoundedCorners = true;
            this.guna2GradientButton2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.BorderRadius = 16;
            this.guna2GradientButton2.BorderThickness = 1;
            this.guna2GradientButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GradientButton2.FillColor2 = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2GradientButton2, "guna2GradientButton2");
            this.guna2GradientButton2.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientButton2.Image = global::DVLD_Presentation_Layer.Properties.Resources.refresh;
            this.guna2GradientButton2.Name = "guna2GradientButton2";
            this.guna2GradientButton2.Click += new System.EventHandler(this.guna2GradientButton2_Click);
            // 
            // ctrlDataGridPagesMoving2
            // 
            this.ctrlDataGridPagesMoving2.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDataGridPagesMoving2.CurrentPage = 1;
            resources.ApplyResources(this.ctrlDataGridPagesMoving2, "ctrlDataGridPagesMoving2");
            this.ctrlDataGridPagesMoving2.ItemsPerPage = ((short)(10));
            this.ctrlDataGridPagesMoving2.Name = "ctrlDataGridPagesMoving2";
            this.ctrlDataGridPagesMoving2.OnButtonClicked += new System.Action(this.ctrlDataGridPagesMoving2_OnButtonClicked);
            // 
            // guna2ControlBox1
            // 
            resources.ApplyResources(this.guna2ControlBox1, "guna2ControlBox1");
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 5;
            this.guna2ControlBox1.BorderThickness = 1;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Navy;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ControlBox1.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            // 
            // btnMaximaze
            // 
            resources.ApplyResources(this.btnMaximaze, "btnMaximaze");
            this.btnMaximaze.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.BorderRadius = 5;
            this.btnMaximaze.BorderThickness = 1;
            this.btnMaximaze.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximaze.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximaze.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.btnMaximaze.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMaximaze.IconColor = System.Drawing.Color.White;
            this.btnMaximaze.Name = "btnMaximaze";
            this.btnMaximaze.ShadowDecoration.BorderRadius = 10;
            this.btnMaximaze.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            // 
            // btnMinimize
            // 
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderColor = System.Drawing.Color.Transparent;
            this.btnMinimize.BorderRadius = 5;
            this.btnMinimize.BorderThickness = 1;
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.BorderColor = System.Drawing.Color.Aqua;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.Navy;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.ShadowDecoration.BorderRadius = 10;
            this.btnMinimize.ShadowDecoration.Color = System.Drawing.Color.BlueViolet;
            // 
            // ctrlActualDateTime1
            // 
            this.ctrlActualDateTime1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ctrlActualDateTime1, "ctrlActualDateTime1");
            this.ctrlActualDateTime1.Name = "ctrlActualDateTime1";
            // 
            // ctrlRecentDetainActivities1
            // 
            this.ctrlRecentDetainActivities1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlRecentDetainActivities1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlRecentDetainActivities1, "ctrlRecentDetainActivities1");
            this.ctrlRecentDetainActivities1.Name = "ctrlRecentDetainActivities1";
            // 
            // ctrlDetainReasons_Top5_1
            // 
            this.ctrlDetainReasons_Top5_1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDetainReasons_Top5_1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlDetainReasons_Top5_1, "ctrlDetainReasons_Top5_1");
            this.ctrlDetainReasons_Top5_1.Name = "ctrlDetainReasons_Top5_1";
            // 
            // ctrlNewDetentionsThisMonth1
            // 
            this.ctrlNewDetentionsThisMonth1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlNewDetentionsThisMonth1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlNewDetentionsThisMonth1, "ctrlNewDetentionsThisMonth1");
            this.ctrlNewDetentionsThisMonth1.Name = "ctrlNewDetentionsThisMonth1";
            // 
            // ctrlNewDetentionsLast30Days1
            // 
            this.ctrlNewDetentionsLast30Days1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlNewDetentionsLast30Days1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlNewDetentionsLast30Days1, "ctrlNewDetentionsLast30Days1");
            this.ctrlNewDetentionsLast30Days1.Name = "ctrlNewDetentionsLast30Days1";
            // 
            // ctrlFinesOverview1
            // 
            this.ctrlFinesOverview1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlFinesOverview1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlFinesOverview1, "ctrlFinesOverview1");
            this.ctrlFinesOverview1.Name = "ctrlFinesOverview1";
            // 
            // ctrlTotalCurrentlyDetainedLicenses1
            // 
            this.ctrlTotalCurrentlyDetainedLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalCurrentlyDetainedLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlTotalCurrentlyDetainedLicenses1, "ctrlTotalCurrentlyDetainedLicenses1");
            this.ctrlTotalCurrentlyDetainedLicenses1.Name = "ctrlTotalCurrentlyDetainedLicenses1";
            // 
            // ctrlTotalReleasedLicenses1
            // 
            this.ctrlTotalReleasedLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalReleasedLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlTotalReleasedLicenses1, "ctrlTotalReleasedLicenses1");
            this.ctrlTotalReleasedLicenses1.Name = "ctrlTotalReleasedLicenses1";
            // 
            // ctrlTotalDetainedLicenses1
            // 
            this.ctrlTotalDetainedLicenses1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalDetainedLicenses1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlTotalDetainedLicenses1, "ctrlTotalDetainedLicenses1");
            this.ctrlTotalDetainedLicenses1.Name = "ctrlTotalDetainedLicenses1";
            // 
            // ctrlTotalDetainedFees1
            // 
            this.ctrlTotalDetainedFees1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTotalDetainedFees1.CustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.ctrlTotalDetainedFees1, "ctrlTotalDetainedFees1");
            this.ctrlTotalDetainedFees1.Name = "ctrlTotalDetainedFees1";
            // 
            // ctrlDataGridPagesMoving1
            // 
            this.ctrlDataGridPagesMoving1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlDataGridPagesMoving1.CurrentPage = 1;
            this.ctrlDataGridPagesMoving1.ItemsPerPage = ((short)(100));
            resources.ApplyResources(this.ctrlDataGridPagesMoving1, "ctrlDataGridPagesMoving1");
            this.ctrlDataGridPagesMoving1.Name = "ctrlDataGridPagesMoving1";
            // 
            // frmManageDetainLicenseScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.btnMaximaze);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.ctrlActualDateTime1);
            this.Controls.Add(this.guna2HtmlLabel14);
            this.Controls.Add(this.ctrlRecentDetainActivities1);
            this.Controls.Add(this.ctrlDetainReasons_Top5_1);
            this.Controls.Add(this.ctrlNewDetentionsThisMonth1);
            this.Controls.Add(this.ctrlNewDetentionsLast30Days1);
            this.Controls.Add(this.ctrlFinesOverview1);
            this.Controls.Add(this.ctrlTotalCurrentlyDetainedLicenses1);
            this.Controls.Add(this.ctrlTotalReleasedLicenses1);
            this.Controls.Add(this.ctrlTotalDetainedLicenses1);
            this.Controls.Add(this.ctrlTotalDetainedFees1);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageDetainLicenseScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton btnRelease;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblUserMessage;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientButton btnDetainLicense;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel14;
        private Global_Controls.ctrlDataGridPagesMoving ctrlDataGridPagesMoving1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalReleasedLicenses ctrlTotalReleasedLicenses1;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedLicenses ctrlTotalDetainedLicenses1;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalDetainedFees ctrlTotalDetainedFees1;
        private Global_Controls.Detain_Licenses_Controls.ctrlTotalCurrentlyDetainedLicenses ctrlTotalCurrentlyDetainedLicenses1;
        private Global_Controls.ctrlDataGridPagesMoving ctrlDataGridPagesMoving2;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsThisMonth ctrlNewDetentionsThisMonth1;
        private Global_Controls.Detain_Licenses_Controls.ctrlNewDetentionsLast30Days ctrlNewDetentionsLast30Days1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem1;
        private GlobalCustomControls.MyGridView dgvDetainedLicenses;
        private Global_Controls.ctrlActualDateTime ctrlActualDateTime1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Global_Controls.Detain_Licenses_Controls.ctrlRecentDetainActivities ctrlRecentDetainActivities1;
        private Global_Controls.Detain_Licenses_Controls.ctrlDetainReasons_Top5_ ctrlDetainReasons_Top5_1;
        private Global_Controls.Detain_Licenses_Controls.ctrlFinesOverview ctrlFinesOverview1;
        private Guna.UI2.WinForms.Guna2ComboBox cbIsReleaseFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilterBy;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximaze;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
    }
}